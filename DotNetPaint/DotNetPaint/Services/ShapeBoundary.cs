using System;
using System.Drawing;
using DotNetPaint.Models;
using Rectangle = System.Drawing.Rectangle;

namespace DotNetPaint.Services
{
    public static class ShapeBoundary
    {
         public static Rectangle GetFor(IShape shape)
         {
             var start = shape.Start;
             var end = shape.End;

             var topLeft = new Point(Math.Min(start.X, end.X), Math.Min(end.Y, start.Y));
             int width = Math.Abs(end.X - start.X);
             int height = Math.Abs(end.Y - start.Y);

             return new Rectangle(topLeft, new Size(width, height));
         }
    }
}