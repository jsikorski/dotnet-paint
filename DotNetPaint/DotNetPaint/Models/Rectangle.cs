using System;
using System.Drawing;
using System.Runtime.Serialization;
using DotNetPaint.Services;

namespace DotNetPaint.Models
{
    [Serializable]
    public class Rectangle : IShape, ISerializable
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

        public Rectangle(SerializationInfo info, StreamingContext context)
        {
            this.Deserialize(info);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            this.Serialize(info);
        }
    }
}