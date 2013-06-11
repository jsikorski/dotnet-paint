﻿using System;
using System.Drawing;
using System.Runtime.Serialization;

namespace DotNetPaint.Models
{
    [Serializable]
    public class Line : IShape, ISerializable
    {
        public Pen Pen { get; set; }
        public Brush Brush { get; set; }
        public Point Start { get; set; }
        public Point End { get; set; }

        public Line(Pen pen, Point start, Point end)
        {
            Pen = pen;
            Brush = Brushes.Transparent;
            Start = start;
            End = end;
        }

        public void Draw(Graphics graphics)
        {
            graphics.DrawLine(Pen, Start, End);
        }

        public Line(SerializationInfo info, StreamingContext context)
        {
            this.Deserialize(info);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            this.Serialize(info);
        }
    }
}