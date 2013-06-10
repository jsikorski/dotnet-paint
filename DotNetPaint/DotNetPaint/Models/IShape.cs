using System.Drawing;

namespace DotNetPaint.Models
{
    public interface IShape : IDrawable
    {
        Point Start { get; }
        Point End { get; set; }
    }
}