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
            int width = End.X - Start.X;
            int height = End.Y - Start.Y;

            Point topLeft = Start;
            
            if (width < 0 && height < 0)
                topLeft = End;
            else if (width < 0 && height > 0)
                topLeft = new Point(End.X, Start.Y);
            else if (width > 0 && height < 0)
                topLeft = new Point(Start.X, End.Y);

            graphics.DrawRectangle(Pen, topLeft.X, topLeft.Y, Math.Abs(width), Math.Abs(height));
            graphics.FillRectangle(Brush, topLeft.X, topLeft.Y, Math.Abs(width), Math.Abs(height));
        }
    }
}