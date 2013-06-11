using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using DotNetPaint.Common;

namespace DotNetPaint.Plugins.Brightener
{
    public class Brightener : IPlugin
    {
        public ToolStripItem AddButton(ToolStrip container)
        {
            var button = new ToolStripButton(Resources.Sun) {ToolTipText = "Brighter"};
            container.Items.Add(button);
            return button;
        }

        public void Execute(IEnumerable<IShape> shapes)
        {
            shapes.ToList().ForEach(shape =>
                                        {
                                            shape.Pen.Color = ControlPaint.Light(shape.Pen.Color);

                                            if (shape.Brush == Brushes.Transparent)
                                                return;

                                            var solidBrush = shape.Brush as SolidBrush;
                                            if (solidBrush != null)
                                                solidBrush.Color = ControlPaint.Light(solidBrush.Color);

                                            var linearGradientBrush = shape.Brush as LinearGradientBrush;
                                            if (linearGradientBrush != null)
                                            {
                                                var firstColor = ControlPaint.Light(linearGradientBrush.LinearColors[0]);
                                                var secondColor = ControlPaint.Light(linearGradientBrush.LinearColors[1]);
                                                linearGradientBrush.LinearColors = new[] {firstColor, secondColor};
                                            }
                                        });
        }
    }
}
