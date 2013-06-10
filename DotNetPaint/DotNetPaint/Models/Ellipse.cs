using System.Drawing;
using DotNetPaint.Services;

namespace DotNetPaint.Models
{
    public class Ellipse : IShape
    {
        public Pen Pen { get; set; }
        public Brush Brush { get; set; }
        public Point Start { get; private set; }
        public Point End { get; set; }

        public Ellipse(Pen pen, Brush brush, Point start, Point end)
        {
            Pen = pen;
            Brush = brush;
            Start = start;
            End = end;
        }

        public void Draw(Graphics graphics)
        {
            var boundary = ShapeBoundary.GetFor(this);
            graphics.DrawEllipse(Pen, boundary);
            graphics.FillEllipse(Brush, boundary);
        }
    }
}