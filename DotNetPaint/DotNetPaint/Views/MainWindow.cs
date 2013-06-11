using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using BlackBeltCoder;
using DotNetPaint.Models;

namespace DotNetPaint.Views
{
    public partial class MainWindow : Form
    {
        private readonly DrawingContext _drawingContext;
        private ToolStripButton _lastSelectedShapeTypeSelector;

        public MainWindow()
        {
            InitializeComponent();
            InitializeGraphics();

            _lastSelectedShapeTypeSelector = lineSelector;

            _drawingContext = new DrawingContext
                {
                    ShapeType = ShapeType.Line, 
                    Pen = new Pen(penColorSelector.Value, int.Parse(penWidthSelector.Text))
                };

            drawingArea.DrawingContext = _drawingContext;
        }

        private void InitializeGraphics()
        {
            DoubleBuffered = true;
        }

        private void ExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LineSelectorClick(object sender, EventArgs e)
        {
            SelectShapeType(ShapeType.Line, (ToolStripButton)sender);
        }

        private void RectangleSelectorClick(object sender, EventArgs e)
        {
            SelectShapeType(ShapeType.Rectangle, (ToolStripButton) sender);
        }

        private void EllipseSelectorClick(object sender, EventArgs e)
        {
            SelectShapeType(ShapeType.Ellipse, (ToolStripButton)sender);
        }

        private void SelectShapeType(ShapeType shapeType, ToolStripButton selector)
        {
            _lastSelectedShapeTypeSelector.Checked = false;
            
            _drawingContext.ShapeType = shapeType;
            selector.Checked = true;

            _lastSelectedShapeTypeSelector = selector;
        }

        private void PenWidthSelectorValueClick(object sender, EventArgs e)
        {
            var text = ((ToolStripMenuItem) sender).Text;
            penWidthSelector.Text = text;
            _drawingContext.Pen.Width = int.Parse(text);
        }

        private void PenStyleSelectorValueClick(object sender, EventArgs e)
        {
            var text = ((ToolStripMenuItem) sender).Text;
            var value = (DashStyle) Enum.Parse(typeof(DashStyle), text);
            _drawingContext.Pen.DashStyle = value;
            penStyleSelector.Text = text.Substring(0, 1);
        }

        private void PenColorSelectorClick(object sender, ColorPickerEventArgs e)
        {
            _drawingContext.Pen.Color = e.Value;
        }
    }
}