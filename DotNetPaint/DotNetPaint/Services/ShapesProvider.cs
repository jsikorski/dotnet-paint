using System;
using System.Drawing;
using DotNetPaint.Models;
using Rectangle = DotNetPaint.Models.Rectangle;

namespace DotNetPaint.Services
{
    public class ShapesProvider
    {
        public IShape GetShape(DrawingContext drawingContext, Point start, Point end)
        {
            var pen = (Pen)drawingContext.Pen.Clone();
            var brush = (Brush)drawingContext.Brush.Clone();

            switch (drawingContext.ShapeType)
            {
                case ShapeType.Line:
                    return new Line(pen, start, end);
                case ShapeType.Rectangle:
                    return new Rectangle(pen, brush, start, end);
                case ShapeType.Ellipse:
                    return new Ellipse(pen, brush, start, end);
                default:
                    throw new ArgumentException("Unknown shape type.");
            }
        }
    }
}