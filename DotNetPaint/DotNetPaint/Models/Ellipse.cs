using System.Drawing;
using DotNetPaint.Services;

namespace DotNetPaint.Models
{
    public class Ellipse : IShape
    {
        public Pen Pen { get; set; }
        public Point Start { get; private set; }
        public Point End { get; set; }

        public Ellipse(Pen pen, Point start, Point end)
        {
            Pen = pen;
            Start = start;
            End = end;
        }

        public void Draw(Graphics graphics)
        {
            var boundary = ShapeBoundary.GetFor(this);
            graphics.DrawEllipse(Pen, boundary);
        }
    }
}