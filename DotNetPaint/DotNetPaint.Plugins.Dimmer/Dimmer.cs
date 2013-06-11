using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DotNetPaint.Common;

namespace DotNetPaint.Plugins.Dimmer
{
    public class Dimmer : IPlugin
    {
        public ToolStripItem AddButton(ToolStrip container)
        {
            var button = new ToolStripButton(Resources.Dark) { ToolTipText = "Darker" };
            container.Items.Add(button);
            return button;
        }

        public void Execute(IEnumerable<IShape> shapes)
        {
            shapes.ToList().ForEach(shape =>
            {
                shape.Pen.Color = ControlPaint.Dark(shape.Pen.Color);

                if (shape.Brush == Brushes.Transparent)
                    return;

                var solidBrush = shape.Brush as SolidBrush;
                if (solidBrush != null)
                    solidBrush.Color = ControlPaint.Dark(solidBrush.Color);

                var linearGradientBrush = shape.Brush as LinearGradientBrush;
                if (linearGradientBrush != null)
                {
                    var firstColor = ControlPaint.Dark(linearGradientBrush.LinearColors[0]);
                    var secondColor = ControlPaint.Dark(linearGradientBrush.LinearColors[1]);
                    linearGradientBrush.LinearColors = new[] { firstColor, secondColor };
                }
            });
        }
    }
}
