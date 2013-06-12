using System;
using System.Drawing;
using System.Runtime.Serialization;
using DotNetPaint.Common;
using DotNetPaint.Services;

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

        public void MakeSymetric()
        {
            var bonduary = ShapeBoundary.GetFor(this);
            var width = bonduary.Width;
            var height = bonduary.Height;
            var min = Math.Min(bonduary.Width, bonduary.Height);
            var max = Math.Max(bonduary.Width, bonduary.Height);

            if (End.X > Start.X && End.Y > Start.Y)
            {
                if (width/2 > height)
                    End = new Point(Start.X + max, Start.Y);
                else if (height/2 > width)
                    End = new Point(Start.X, Start.Y + max);
                else
                   End = new Point(Start.X + min, Start.Y + min); 
            }
            else if (End.X < Start.X && End.Y > Start.Y)
            {
                if (width/2 > height)
                    End = new Point(Start.X - max, Start.Y);
                else if (height/2 > width)
                    End = new Point(Start.X, Start.Y + max);
                else
                   End = new Point(Start.X - min, Start.Y + min);
            }
            else if (End.X > Start.X && End.Y < Start.Y)
            {
                if (width/2 > height)
                    End = new Point(Start.X + max, Start.Y);
                else if (height/2 > width)
                    End = new Point(Start.X, Start.Y - max);
                else
                   End = new Point(Start.X + min, Start.Y - min); 
            }
            else if (End.X < Start.X)
            {
                if (width / 2 > height)
                    End = new Point(Start.X - max, Start.Y);
                else if (height / 2 > width)
                    End = new Point(Start.X, Start.Y - max);
                else
                    End = new Point(Start.X - min, Start.Y - min);
            }
        }
    }
}