﻿using System.Drawing;

namespace DotNetPaint.Models
{
    public class Line : IShape
    {
        public Pen Pen { get; set; }
        public Point Start { get; set; }
        public Point End { get; set; }

        public Line(Pen pen, Point start, Point end)
        {
            Pen = pen;
            Start = start;
            End = end;
        }

        public void Draw(Graphics graphics)
        {
            graphics.DrawLine(Pen, Start, End);
        }
    }
}