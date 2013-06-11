using System.Drawing;
using DotNetPaint.Models;

namespace DotNetPaint
{
    public class DrawingContext
    {
        public ShapeType ShapeType { get; set; }
        public Pen Pen { get; set; }
        public Brush Brush { get; set; }
    }
}