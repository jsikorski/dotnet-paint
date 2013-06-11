using System;
using System.Drawing;
using System.Runtime.Serialization;
using DotNetPaint.Common;
using DotNetPaint.Services;

namespace DotNetPaint.Models
{
    [Serializable]
    public class Ellipse : IShape, ISerializable
    {
        public Pen Pen { get; set; }
        public Brush Brush { get; set; }
        public Point Start { get; set; }
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

        public Ellipse(SerializationInfo info, StreamingContext context)
        {
            this.Deserialize(info);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            this.Serialize(info);
        }
    }
}