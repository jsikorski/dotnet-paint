using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using DotNetPaint.Models;
using System.Linq;
using Rectangle = DotNetPaint.Models.Rectangle;

namespace DotNetPaint
{
    public class DrawingArea : PictureBox
    {
        private readonly IList<IDrawable> _shapes;

        private bool _isDrawing;
        private int _startX;
        private int _startY;
        private int _endX;
        private int _endY;

        public DrawingArea()
        {
            InitializeComponent();
            _shapes = new List<IDrawable>();
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
            _startX = e.X;
            _startY = e.Y;
            _isDrawing = true;
        }

        private void DrawingAreaMouseMove(object sender, MouseEventArgs e)
        {
            if (!_isDrawing)
                return;

            _endX = e.X;
            _endY = e.Y;
            Invalidate();
        }

        private void DrawingAreaMouseUp(object sender, MouseEventArgs e)
        {
            _shapes.Add(new Rectangle(Pens.Black, Brushes.Red, new Point(_startX, _startY), new Point(e.X, e.Y)));
            _isDrawing = false;
            Invalidate();
        }

        private void DrawingAreaPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            _shapes.ToList().ForEach(shape => shape.Draw(e.Graphics));
            e.Graphics.DrawRectangle(Pens.Black, 500, 500, -100, -100);
            e.Graphics.DrawLine(Pens.Black, _startX, _startY, _endX, _endY);
        }
    }
}