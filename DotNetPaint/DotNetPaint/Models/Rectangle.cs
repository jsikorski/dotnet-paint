using System;
using System.Drawing;

namespace DotNetPaint.Models
{
    public class Rectangle : IDrawable
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
            var topLeft = new Point(Math.Min(Start.X, End.X), Math.Min(End.Y, Start.Y));

            int width = Math.Abs(End.X - Start.X);
            int height = Math.Abs(End.Y - Start.Y);
            
            graphics.DrawRectangle(Pen, topLeft.X, topLeft.Y, width, height);
            graphics.FillRectangle(Brush, topLeft.X, topLeft.Y, width, height);
        }
    }
}