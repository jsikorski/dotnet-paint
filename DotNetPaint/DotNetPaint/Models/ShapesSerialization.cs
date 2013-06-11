using System.Drawing;
using System.Runtime.Serialization;
using DotNetPaint.Infrastructure;

namespace DotNetPaint.Models
{
    public static class ShapesSerialization
    {
         public static void Serialize(this IShape shape, SerializationInfo serializationInfo)
         {
             serializationInfo.AddPen("Pen", shape.Pen);
             serializationInfo.AddBrush("Brush", shape.Brush);
             serializationInfo.AddValue("Start", shape.Start);
             serializationInfo.AddValue("End", shape.End);
         }

        public static void Deserialize(this IShape shape, SerializationInfo serializationInfo)
        {
            shape.Pen = serializationInfo.GetPen("Pen");
            shape.Brush = serializationInfo.GetBrush("Brush");
            shape.Start = serializationInfo.GetValue<Point>("Start");
            shape.End = serializationInfo.GetValue<Point>("End");
        }
    }
}