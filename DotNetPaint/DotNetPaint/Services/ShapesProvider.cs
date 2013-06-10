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
            switch (drawingContext.ShapeType)
            {
                case ShapeType.Line:
                    return new Line(Pens.Black, start, end);
                case ShapeType.Rectangle:
                    return new Rectangle(Pens.Black, Brushes.Red, start, end);
                case ShapeType.Ellipse:
                    return new Ellipse(Pens.Black, Brushes.Red, start, end);
                default:
                    throw new ArgumentException("Unknown shape type.");
            }
        }
    }
}