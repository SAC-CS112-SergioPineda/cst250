using System.Globalization;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using System.Windows.Forms;
using ServiceStack;
using OfficeOpenXml;
using System.IO;

namespace FileAssignment6
{
    public partial class FrmInventory : Form
    {

        private List<Thing> thingsInMyPocket = new List<Thing>();
        BindingSource thingsBindingSource = new BindingSource();




        public FrmInventory()
        {
            InitializeComponent();
            this.Load += FrmInventory_Load;
        }


        private void FrmInventory_Load(object sender, EventArgs e)
        {
            txtValue.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", 0);
            txtValue.Leave += TxtValue_Leave; // Fomrat on leaving the TxtB=ox
            thingsBindingSource.DataSource = thingsInMyPocket;
            gridInventory.DataSource = thingsBindingSource;
            UpdateSummaryLabels();
        }
        private void TxtValue_Leave(object sender, EventArgs e)
        {
            decimal value;
            if (Decimal.TryParse(txtValue.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out value))
            {
                txtValue.Text = string.Format(CultureInfo.CurrentCulture, "{0:C2}", value);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string valueText = txtValue.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(valueText, out decimal value))
            {
                MessageBox.Show("Value must be a valid decimal number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (value < 0)
            {
                MessageBox.Show("Value cannot be negative.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Add to inventory (example, depends on your grid or list logic)
            // Example adding to DataGridView
            gridInventory.Rows.Add(name, value);

            txtName.Clear();
            txtValue.Clear();
        }


        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Save File";
                saveFileDialog.Filter =
                    "Text Files (*.txt)|*.txt|" +
                    "CSV Files  (*.csv)|*.csv|" +
                    "JSON Files (*.json)|*.json|" +
                    "XML Files  (*.xml)|*.xml|" +
                    "Excel Files (*.xlsx)|*.xlsx|" +
                    "All Files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;

                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    return;

                string fileName = saveFileDialog.FileName;
                try
                {
                    if (fileName.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
                    {
                        string json = ServiceStack.Text.JsonSerializer
                                            .SerializeToString(thingsInMyPocket);
                        File.WriteAllText(fileName, json);
                    }
                    else if (fileName.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
                    {
                        string csv = ServiceStack.Text.CsvSerializer
                                           .SerializeToCsv(thingsInMyPocket);
                        File.WriteAllText(fileName, csv);
                    }
                    else if (fileName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                    {
                        // overwrite first, then append each line
                        File.WriteAllText(fileName, string.Empty);
                        foreach (Thing thing in thingsInMyPocket)
                            File.AppendAllText(fileName, thing + Environment.NewLine);
                    }
                    else if (fileName.EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
                    {
                        var serializer = new XmlSerializer(typeof(List<Thing>));
                        using (var fs = File.Create(fileName))
                        {
                            serializer.Serialize(fs, thingsInMyPocket);
                        }
                    }
                    else if (fileName.EndsWith(".xlsx", StringComparison.OrdinalIgnoreCase))
                    {
                        // — NEW: Excel via EPPlus —

                        ExcelPackage.License.SetNonCommercialPersonal("Thomas Pineda");
                        using (var pkg = new ExcelPackage(new FileInfo(fileName)))
                        {
                            var ws = pkg.Workbook.Worksheets.Add("Inventory");
                            // headers
                            ws.Cells[1, 1].Value = "Id";
                            ws.Cells[1, 2].Value = "Name";
                            ws.Cells[1, 3].Value = "Value";

                            // data rows
                            for (int i = 0; i < thingsInMyPocket.Count; i++)
                            {
                                var thing = thingsInMyPocket[i];
                                int row = i + 2;
                                ws.Cells[row, 1].Value = thing.Id;
                                ws.Cells[row, 2].Value = thing.Name;
                                ws.Cells[row, 3].Value = thing.Value;
                                // optionally: ws.Cells[row,3].Style.Numberformat.Format = "$#,##0.00";
                            }

                            // auto-fit columns
                            ws.Cells[ws.Dimension.Address].AutoFitColumns();

                            pkg.Save();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Unsupported file extension. Please use .txt, .csv, .json, .xml, or .xlsx");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving file: " + ex.Message);
                }
            }
        }
        private void MenuLoad_Click(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog())
            {
                // Filter includes all supported file types clearly
                dlg.Filter =
                    "JSON files (*.json)|*.json|" +
                    "CSV files (*.csv)|*.csv|" +
                    "Text files (*.txt)|*.txt|" +
                    "XML files (*.xml)|*.xml|" +
                    "Excel files (*.xlsx)|*.xlsx|" +
                    "All files (*.*)|*.*";

                if (dlg.ShowDialog() != DialogResult.OK)
                    return;  // User cancelled the operation

                try
                {
                    string fileName = dlg.FileName;
                    string ext = Path.GetExtension(fileName).ToLowerInvariant();

                    // JSON files loading
                    if (ext == ".json")
                    {
                        string json = File.ReadAllText(fileName);
                        thingsInMyPocket = ServiceStack.Text.JsonSerializer
                            .DeserializeFromString<List<Thing>>(json);
                    }
                    // CSV files loading
                    else if (ext == ".csv")
                    {
                        string csv = File.ReadAllText(fileName);
                        thingsInMyPocket = ServiceStack.Text.CsvSerializer
                            .DeserializeFromString<List<Thing>>(csv);
                    }
                    // TXT files loading (manual parsing)
                    else if (ext == ".txt")
                    {
                        string[] lines = File.ReadAllLines(fileName);
                        thingsInMyPocket.Clear();

                        foreach (var line in lines)
                        {
                            var parts = line.Split(',');
                            if (parts.Length >= 3)
                            {
                                thingsInMyPocket.Add(new Thing
                                {
                                    Id = int.Parse(parts[0].Split('=')[1].Trim()),
                                    Name = parts[1].Split('=')[1].Trim(),
                                    Value = decimal.Parse(parts[2].Split('=')[1].Trim())
                                });
                            }
                            else
                            {
                                throw new FormatException("TXT file format invalid on line: " + line);
                            }
                        }
                    }
                    // XML files loading using XmlSerializer
                    else if (ext == ".xml")
                    {
                        var serializer = new XmlSerializer(typeof(List<Thing>));
                        using (var fs = File.OpenRead(fileName))
                            thingsInMyPocket = (List<Thing>)serializer.Deserialize(fs);
                    }
                    // Excel (.xlsx) files loading using EPPlus
                    else if (ext == ".xlsx")
                    {
                        ; // Important for EPPlus license issue
                        using (var pkg = new ExcelPackage(new FileInfo(fileName)))
                        {
                            var ws = pkg.Workbook.Worksheets.FirstOrDefault()
                                ?? throw new InvalidOperationException("No worksheet found in Excel file.");

                            thingsInMyPocket.Clear();

                            // Assuming data starts from the second row (first row is headers)
                            int lastRow = ws.Dimension.End.Row;
                            for (int row = 2; row <= lastRow; row++)
                            {
                                thingsInMyPocket.Add(new Thing
                                {
                                    Id = ws.Cells[row, 1].GetValue<int>(),
                                    Name = ws.Cells[row, 2].GetValue<string>(),
                                    Value = ws.Cells[row, 3].GetValue<decimal>()
                                });
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Unsupported file type: " + ext);
                        return;
                    }

                    // Refresh your DataGridView binding after successful load
                    thingsBindingSource.DataSource = thingsInMyPocket;
                    thingsBindingSource.ResetBindings(false);
                    UpdateSummaryLabels();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading file: " + ex.Message);
                }
            }
        }
        private void RaidoLeastValuable_CheckedChanged(object sender, EventArgs e)
        {
            var leastValuable = (from thing in thingsInMyPocket
                                 orderby thing.Value
                                 select thing).Take(3).ToList();

            thingsBindingSource.DataSource = leastValuable;
            thingsBindingSource.ResetBindings(false);
            UpdateSummaryLabels();
        }

        private void RadioMostValuable_CheckedChanged(object sender, EventArgs e)
        {
            var mostValuable = thingsInMyPocket.OrderByDescending(Thing => Thing.Value).Take(3).ToList();

            thingsBindingSource.DataSource = mostValuable;
            thingsBindingSource.ResetBindings(false);
            UpdateSummaryLabels();
        }

        private void RadioShowAll_CheckedChange(object sender, EventArgs e)
        {

            var sortedItems = thingsInMyPocket.OrderBy(thing => thing.Id).ToList();
            thingsBindingSource.DataSource = sortedItems;
            thingsBindingSource.ResetBindings(false);
            UpdateSummaryLabels();
        }

        private void RangeMinMax_Click(object sender, EventArgs e)
        {
            var rangeList = thingsInMyPocket
               .Where(thing =>
                   thing.Value >= rangeTrackBar1.LowerValue &&
                   thing.Value <= rangeTrackBar1.UpperValue)
               .ToList();
            thingsBindingSource.DataSource = rangeList;
            thingsBindingSource.ResetBindings(false);
            UpdateSummaryLabels();

        }
        private void UpdateSummaryLabels()
        {
            // grab whatever is currently bound
            var items = thingsBindingSource.DataSource as IEnumerable<Thing>;
            if (items == null)
            {
                lblTotalItems.Text = "Items: 0";
                lblTotalValue.Text = "Total: $0.00";
                return;
            }

            int count = items.Count();
            decimal total = items.Sum(t => t.Value);

            lblTotalItems.Text = $"Items: {count}";
            lblTotalValue.Text = $"Total: {total:C2}";
        }
        
        private void SetMaxValue()
        {
            {
                decimal maxValuedItem = 0;
                foreach (Thing thing in thingsInMyPocket)
                {
                    if (thing.Value > maxValuedItem)
                    {
                        maxValuedItem = (decimal)thing.Value;

                    }
                    rangeTrackBar1.MaxValue = (int)maxValuedItem;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // 1) Grab the user’s query
            string query = txtSearch.Text.Trim();

            // 2) Build the result set
            List<Thing> results;
            if (int.TryParse(query, out int id))
            {
                // numeric → match Id
                results = thingsInMyPocket
                    .Where(t => t.Id == id)
                    .ToList();
            }
            else
            {
                // otherwise match Name (case-insensitive substring)
                results = thingsInMyPocket
                    .Where(t => t.Name
                        .IndexOf(query, StringComparison.CurrentCultureIgnoreCase) >= 0)
                    .ToList();
            }

            // 3) Bind to the grid—just like your radio buttons do
            thingsBindingSource.DataSource = results;
            thingsBindingSource.ResetBindings(false);
            UpdateSummaryLabels();

            // 4) And write each one to the console
            Console.WriteLine($"Search for \"{query}\" returned {results.Count} result(s):");
            foreach (var thing in results)
            {
                Console.WriteLine(thing);  // calls Thing.ToString()
            }
        }
    }
}

