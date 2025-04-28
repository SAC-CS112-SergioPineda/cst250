using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace FileAssignment6
{
    public class RangeTrackBar : Control
    {
        private int lowerValue = 10;
        private int upperValue = 90;
        private int minValue = 0;
        private int maxValue = 100;
        private int tickFrequency = 10;

        public Color LowerColor { get; set; } = Color.DarkRed;
        public Color UpperColor { get; set; } = Color.Teal;
        public Color TrackColor { get; set; } = Color.LightGray;
        public Color TickColor { get; set; } = Color.LightGray;
        public Color LabelColor { get; set; } = Color.Gray;

        private Rectangle lowerThumb;
        private Rectangle upperThumb;
        private bool draggingLower;
        private bool draggingUpper;

        // Expose a MouseUp event
        public new event EventHandler MouseUp;

        public int TickFrequency
        {
            get => tickFrequency;
            set
            {
                if (value > 0 && value <= (maxValue - minValue))
                {
                    tickFrequency = value;
                    Invalidate();
                }
            }
        }

        public int MinValue
        {
            get => minValue;
            set
            {
                minValue = value;
                if (minValue > lowerValue) lowerValue = minValue;
                if (minValue > upperValue) upperValue = minValue;
                UpdateThumbPositions();
                Invalidate();
            }
        }

        public int MaxValue
        {
            get => maxValue;
            set
            {
                maxValue = value;
                if (maxValue < lowerValue) lowerValue = maxValue;
                if (maxValue < upperValue) upperValue = maxValue;
                UpdateThumbPositions();
                Invalidate();
            }
        }

        public int LowerValue
        {
            get => lowerValue;
            set
            {
                int newVal = Math.Min(Math.Max(value, minValue), upperValue);
                if (lowerValue != newVal)
                {
                    lowerValue = newVal;
                    UpdateThumbPositions();
                    Invalidate();
                }
            }
        }

        public int UpperValue
        {
            get => upperValue;
            set
            {
                int newVal = Math.Max(Math.Min(value, maxValue), lowerValue);
                if (upperValue != newVal)
                {
                    upperValue = newVal;
                    UpdateThumbPositions();
                    Invalidate();
                }
            }
        }

        public RangeTrackBar()
        {
            DoubleBuffered = true;
            MinimumSize = new Size(100, 50);
            UpdateThumbPositions();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            draggingLower = draggingUpper = false;
            OnClick(EventArgs.Empty);
            MouseUp?.Invoke(this, e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            int padding = 10;
            // draw the track
            Rectangle trackRect = new Rectangle(
                padding,
                5,
                Width - 2 * padding,
                4);

            using (Brush trackBrush = new SolidBrush(TrackColor))
            using (Pen tickPen = new Pen(TickColor))
            using (Brush lowerBrush = new SolidBrush(LowerColor))
            using (Brush upperBrush = new SolidBrush(UpperColor))
            using (Brush labelBrush = new SolidBrush(LabelColor))
            {
                e.Graphics.FillRectangle(trackBrush, trackRect);
                DrawThumb(e.Graphics, lowerThumb, lowerBrush);
                DrawThumb(e.Graphics, upperThumb, upperBrush);
                DrawTicks(e.Graphics, tickPen, trackRect, padding);
                DrawLabels(e.Graphics, labelBrush);
            }
        }

        private void DrawThumb(Graphics g, Rectangle thumb, Brush color)
        {
            Point[] pts = {
                new Point(thumb.X, thumb.Y),
                new Point(thumb.X + thumb.Width, thumb.Y),
                new Point(thumb.X + thumb.Width, thumb.Y + thumb.Height),
                new Point(thumb.X + thumb.Width/2, thumb.Y + thumb.Height + 10),
                new Point(thumb.X, thumb.Y + thumb.Height)
            };
            g.FillPolygon(color, pts);
        }

        private void DrawTicks(Graphics g, Pen pen, Rectangle track, int padding)
        {
            int range = maxValue - minValue;
            int tickCount = Math.Max(1, range / tickFrequency);
            for (int i = 0; i <= tickCount; i++)
            {
                int x = track.Left + (int)(i * (track.Width / (double)tickCount));
                g.DrawLine(pen, x, track.Top - 2, x, track.Bottom + 2);
            }
        }

        private void DrawLabels(Graphics g, Brush brush)
        {
            string lowText = lowerValue.ToString();
            string highText = upperValue.ToString();
            SizeF lowSz = g.MeasureString(lowText, Font);
            SizeF highSz = g.MeasureString(highText, Font);

            float lowX = lowerThumb.Left + (lowerThumb.Width - lowSz.Width) / 2f;
            float highX = upperThumb.Left + (upperThumb.Width - highSz.Width) / 2f;

            g.DrawString(lowText, Font, brush, lowX, lowerThumb.Bottom + 4);
            g.DrawString(highText, Font, brush, highX, upperThumb.Bottom + 4);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (lowerThumb.Contains(e.Location))
                draggingLower = true;
            else if (upperThumb.Contains(e.Location))
                draggingUpper = true;
            else
            {
                int val = PositionToValue(e.X, 10);
                if (val < lowerValue) { LowerValue = val; draggingLower = true; }
                else if (val > upperValue) { UpperValue = val; draggingUpper = true; }
            }

            // if both are at the minimum, drag the upper one
            if (upperValue == minValue && draggingLower)
            {
                draggingLower = false;
                draggingUpper = true;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (!draggingLower && !draggingUpper) return;
            int val = PositionToValue(e.X, 10);
            if (draggingLower) LowerValue = val;
            else UpperValue = val;
        }

        private int PositionToValue(int position, int padding)
        {
            double scale = (Width - 2.0 * padding) / (maxValue - minValue);
            int val = (int)((position - padding) / scale + minValue);
            return Math.Max(minValue, Math.Min(maxValue, val));
        }

        private void UpdateThumbPositions()
        {
            int padding = 10;
            int thumbSize = 10;

            lowerThumb = new Rectangle(
                ValueToPosition(lowerValue, padding),
                5,
                thumbSize,
                thumbSize);

            upperThumb = new Rectangle(
                ValueToPosition(upperValue, padding),
                5,
                thumbSize,
                thumbSize);
        }

        private int ValueToPosition(int value, int padding)
        {
            double scale = (Width - 2.0 * padding) / (maxValue - minValue);
            return (int)(padding + scale * (value - minValue));
        }
    }
}
