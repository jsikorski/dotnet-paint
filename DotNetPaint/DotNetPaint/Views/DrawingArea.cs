using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using DotNetPaint.Common;
using DotNetPaint.Models;
using DotNetPaint.Services;

namespace DotNetPaint.Views
{
    public class DrawingArea : PictureBox
    {
        public DrawingContext DrawingContext { get; set; }
        private readonly ShapesProvider _shapesProvider;

        public IList<IShape> Shapes { get; private set; }
        private IShape _currentlyDrawnShape;
        private bool IsDrawing
        {
            get { return _currentlyDrawnShape != null; }
        }

        private readonly IList<IShape> _undoneShapes;
        
        private bool _canUndo;
        private bool _canRedo;

        public bool CanUndo
        {
            get { return _canUndo; }
            set
            {
                if (_canUndo == value)
                    return;

                _canUndo = value;
                HandleAction(CanUndoChanged, _canUndo);
            }
        }

        public bool CanRedo
        {
            get { return _canRedo; }
            set
            {
                if (_canRedo == value)
                    return;

                _canRedo = value;
                HandleAction(CanRedoChanged, _canRedo);
            }
        }

        public event Action<bool> CanUndoChanged;
        public event Action<bool> CanRedoChanged;

        public DrawingArea()
        {
            InitializeComponent();
            Shapes = new List<IShape>();
            _undoneShapes = new List<IShape>();
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

            if (ModifierKeys == Keys.Shift)
                _currentlyDrawnShape.MakeSymetric();
            
            Invalidate();
        }

        private void DrawingAreaMouseUp(object sender, MouseEventArgs e)
        {
            if (!IsDrawing || e.Button != MouseButtons.Left)
                return;

            Shapes.Add(_currentlyDrawnShape);
            _currentlyDrawnShape = null;
            _undoneShapes.Clear();
            UpdateUndoRedo();
            Invalidate();
        }

        private void UpdateUndoRedo()
        {
            CanUndo = Shapes.Any();
            CanRedo = _undoneShapes.Any();
        }

        private void DrawingAreaPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Shapes.ToList().ForEach(shape => shape.Draw(e.Graphics));

            if (IsDrawing)
                _currentlyDrawnShape.Draw(e.Graphics);
        }

        public void Undo()
        {
            if (!CanUndo)
                return;

            var lastShape = Shapes.Last();
            Shapes.Remove(lastShape);
            _undoneShapes.Add(lastShape);
            UpdateUndoRedo();
            Invalidate();
        }

        public void Redo()
        {
            if (!CanRedo)
                return;

            var undoneShape = _undoneShapes.Last();
            _undoneShapes.Remove(undoneShape);
            Shapes.Add(undoneShape);
            UpdateUndoRedo();
            Invalidate();
        }

        private void HandleAction(Action<bool> action, bool value)
        {
            var handler = action;
            if (handler != null) 
                handler(value);
        }

        public void SetShapes(IList<IShape> shapes)
        {
            Shapes = shapes;
            _undoneShapes.Clear();
            UpdateUndoRedo();
            Invalidate();
        }

        public void Restart()
        {
            Shapes.Clear();
            _undoneShapes.Clear();
            _currentlyDrawnShape = null;
            UpdateUndoRedo();
            Invalidate();
        }
    }
}