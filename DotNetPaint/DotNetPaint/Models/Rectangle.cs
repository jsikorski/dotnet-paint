using System;
using System.Drawing;
using DotNetPaint.Services;

namespace DotNetPaint.Models
{
    public class Rectangle : IShape
    {
        public Pen Pen { get; set; }
        public Brush Brush { get; set; }
        public Point Start { get; set; }
        public Point End { get; set; }

        public Rectangle(Pen pen, Brush brush, Point start, Point end)
        {
            Pen = pen;
            Brush = brush;
            Start = start;
            End = end;
        }

        public void Draw(Graphics graphics)
        {
            var boundary = ShapeBoundary.GetFor(this);
            graphics.DrawRectangle(Pen, boundary);
            graphics.FillRectangle(Brush, boundary);
        }
    }
}