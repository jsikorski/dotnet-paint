using System.Collections.Generic;
using System.Windows.Forms;

namespace DotNetPaint.Common
{
    public interface IPlugin
    {
        ToolStripItem AddButton(ToolStrip container);
        void Execute(IEnumerable<IShape> shapes);
    }
}