using System.Drawing;

namespace DotNetPaint.Models
{
    public class Line : IDrawable
    {
        public Pen Pen { get; set; }
        public Point Begin { get; set; }
        public Point End { get; set; }

        public Line(Pen pen, Point begin, Point end)
        {
            Pen = pen;
            Begin = begin;
            End = end;
        }

        public void Draw(Graphics graphics)
        {
            graphics.DrawLine(Pen, Begin, End);
        }
    }
}