using System.Drawing;

namespace DotNetPaint.Models
{
    public interface IDrawable
    {
        void Draw(Graphics graphics);
    }
}