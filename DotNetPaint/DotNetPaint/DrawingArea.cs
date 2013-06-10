using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using DotNetPaint.Models;
using System.Linq;
using DotNetPaint.Services;

namespace DotNetPaint
{
    public class DrawingArea : PictureBox
    {
        public DrawingContext DrawingContext { get; set; }
        private readonly ShapesProvider _shapesProvider;

        private readonly IList<IShape> _shapes;
        private IShape _currentlyDrawnShape;
        private bool IsDrawing
        {
            get { return _currentlyDrawnShape != null; }
        }

        public DrawingArea()
        {
            InitializeComponent();
            _shapes = new List<IShape>();
            _shapesProvider = new ShapesProvider();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // DrawingArea
            // 
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawingAreaPaint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DrawingAreaMouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DrawingAreaMouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DrawingAreaMouseUp);
            this.ResumeLayout(false);

        }

        private void DrawingAreaMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            var start = new Point(e.X, e.Y);
            var end = new Point(e.X, e.Y);
            _currentlyDrawnShape = _shapesProvider.GetShape(DrawingContext, start, end);
        }

        private void DrawingAreaMouseMove(object sender, MouseEventArgs e)
        {
            if (!IsDrawing)
                return;

            _currentlyDrawnShape.End = new Point(e.X, e.Y);
            Invalidate();
        }

        private void DrawingAreaMouseUp(object sender, MouseEventArgs e)
        {
            if (!IsDrawing || e.Button != MouseButtons.Left)
                return;

            _shapes.Add(_currentlyDrawnShape);
            _currentlyDrawnShape = null;
            Invalidate();
        }

        private void DrawingAreaPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            _shapes.ToList().ForEach(shape => shape.Draw(e.Graphics));

            if (IsDrawing)
                _currentlyDrawnShape.Draw(e.Graphics);
        }
    }
}