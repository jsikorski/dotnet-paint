using System.Drawing;

namespace DotNetPaint.Models
{
    public interface IShape : IDrawable
    {
        Pen Pen { get; set; }
        Brush Brush { get; set; }
        Point Start { get; set; }
        Point End { get; set; }
    }
}