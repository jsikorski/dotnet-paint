using System;
using System.Windows.Forms;
using DotNetPaint.Models;

namespace DotNetPaint
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

            _drawingContext = new DrawingContext();
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
    }
}
