using System.Drawing;

namespace DotNetPaint.Models
{
    public interface IDrawable
    {
        Point Start { get; }
        Point End { get; set; }
        void Draw(Graphics graphics);
    }
}