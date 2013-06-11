using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;
using BlackBeltCoder;
using DotNetPaint.Models;

namespace DotNetPaint.Views
{
    public partial class MainWindow : Form
    {
        private DrawingContext _drawingContext;
        private ToolStripButton _lastSelectedShapeTypeSelector;

        public MainWindow()
        {
            InitializeComponent();
            InitializeGraphics();

            drawingArea.CanUndoChanged += newValue => undo.Enabled = newValue;
            drawingArea.CanRedoChanged += newValue => redo.Enabled = newValue;

            _lastSelectedShapeTypeSelector = lineSelector;

            _drawingContext = new DrawingContext
                {
                    ShapeType = ShapeType.Line,
                    Pen = new Pen(penColorSelector.Value, int.Parse(penWidthSelector.Text)),
                    Brush = Brushes.Transparent
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
            SelectShapeType(ShapeType.Rectangle, (ToolStripButton)sender);
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
            var text = ((ToolStripMenuItem)sender).Text;
            penWidthSelector.Text = text;
            _drawingContext.Pen.Width = int.Parse(text);
        }

        private void PenStyleSelectorValueClick(object sender, EventArgs e)
        {
            var text = ((ToolStripMenuItem)sender).Text;
            var value = (DashStyle)Enum.Parse(typeof(DashStyle), text);
            _drawingContext.Pen.DashStyle = value;
            penStyleSelector.Text = text.Substring(0, 1);
        }

        private void PenColorSelectorClick(object sender, ColorPickerEventArgs e)
        {
            _drawingContext.Pen.Color = e.Value;
        }

        private void FillStyleSelectorClick(object sender, EventArgs e)
        {
            var text = ((ToolStripMenuItem)sender).Text;

            switch (text)
            {
                case "None":
                    solidFillColorSelector.Visible = false;
                    gradientFillFirstColorSelector.Visible = false;
                    gradientFillSecondColorSelector.Visible = false;
                    _drawingContext.Brush = Brushes.Transparent;
                    break;
                case "Solid":
                    solidFillColorSelector.Visible = true;
                    gradientFillFirstColorSelector.Visible = false;
                    gradientFillSecondColorSelector.Visible = false;
                    _drawingContext.Brush = new SolidBrush(solidFillColorSelector.Value);
                    break;
                case "Gradient":
                    solidFillColorSelector.Visible = false;
                    gradientFillFirstColorSelector.Visible = true;
                    gradientFillSecondColorSelector.Visible = true;
                    SetGradient();
                    break;
            }

            fillStyleSelector.Text = text.Substring(0, 1);
        }

        private void SetGradient()
        {
            var gradient = new LinearGradientBrush(new Point(0, 0), new Point(5, 5),
                                                   gradientFillFirstColorSelector.Value,
                                                   gradientFillSecondColorSelector.Value);
            _drawingContext.Brush = gradient;
        }

        private void SolidFillColorSelectorClick(object sender, ColorPickerEventArgs e)
        {
            _drawingContext.Brush = new SolidBrush(e.Value);
        }

        private void GradientFillColorSelectorClick(object sender, ColorPickerEventArgs e)
        {
            SetGradient();
        }

        private void UndoClick(object sender, EventArgs e)
        {
            drawingArea.Undo();
        }

        private void RedoClick(object sender, EventArgs e)
        {
            drawingArea.Redo();
        }

        private void Save(object sender, EventArgs e)
        {
            var fileDialog = new SaveFileDialog { Filter = "dotnet-paint files (*.dnp)|*.dnp" };
            fileDialog.ShowDialog(this);

            if (string.IsNullOrEmpty(fileDialog.FileName))
                return;

            ExecuteAsync(() => drawingArea.SaveToFile(fileDialog.FileName), "Saving...");
        }

        private new void Load(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog { Filter = "dotnet-paint files (*.dnp)|*.dnp" };
            fileDialog.ShowDialog(this);

            if (string.IsNullOrEmpty(fileDialog.FileName))
                return;

            ExecuteAsync(() => drawingArea.LoadFromFile(fileDialog.FileName), "Loading...");
        }

        private void ExecuteAsync(Action action, string statusMessage)
        {
            ThreadPool.QueueUserWorkItem(
                state =>
                    {
                        try
                        {
                            Invoke(new Action(() => statusIndicator.Text = statusMessage));
                            action();
                            Invoke(new Action(() => statusIndicator.Text = "Ready"));
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Some error occured.", "Error");
                        }
                    });
        }
    }
}
