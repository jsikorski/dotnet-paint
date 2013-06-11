namespace DotNetPaint.Views
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lineSelector = new System.Windows.Forms.ToolStripButton();
            this.rectangleSelector = new System.Windows.Forms.ToolStripButton();
            this.ellipseSelector = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.penColorSelector = new BlackBeltCoder.ColorToolStripDropDownButton();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.penWidthSelector = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.penStyleSelector = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.drawingArea = new DrawingArea();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drawingArea)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.loadToolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.loadToolStripMenuItem.Text = "Save";
            // 
            // loadToolStripMenuItem1
            // 
            this.loadToolStripMenuItem1.Name = "loadToolStripMenuItem1";
            this.loadToolStripMenuItem1.Size = new System.Drawing.Size(100, 22);
            this.loadToolStripMenuItem1.Text = "Load";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Enabled = false;
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Enabled = false;
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 540);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // lineSelector
            // 
            this.lineSelector.Checked = true;
            this.lineSelector.CheckState = System.Windows.Forms.CheckState.Checked;
            this.lineSelector.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lineSelector.Image = global::DotNetPaint.Properties.Resources.line;
            this.lineSelector.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lineSelector.Name = "lineSelector";
            this.lineSelector.Size = new System.Drawing.Size(29, 20);
            this.lineSelector.Text = "toolStripButton1";
            this.lineSelector.ToolTipText = "Line";
            this.lineSelector.Click += new System.EventHandler(this.LineSelectorClick);
            // 
            // rectangleSelector
            // 
            this.rectangleSelector.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rectangleSelector.Image = global::DotNetPaint.Properties.Resources.rectangle;
            this.rectangleSelector.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rectangleSelector.Name = "rectangleSelector";
            this.rectangleSelector.Size = new System.Drawing.Size(29, 20);
            this.rectangleSelector.Text = "toolStripButton2";
            this.rectangleSelector.ToolTipText = "Rectangle";
            this.rectangleSelector.Click += new System.EventHandler(this.RectangleSelectorClick);
            // 
            // ellipseSelector
            // 
            this.ellipseSelector.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ellipseSelector.Image = global::DotNetPaint.Properties.Resources.ellipse;
            this.ellipseSelector.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ellipseSelector.Name = "ellipseSelector";
            this.ellipseSelector.Size = new System.Drawing.Size(29, 20);
            this.ellipseSelector.Text = "toolStripButton3";
            this.ellipseSelector.ToolTipText = "Ellipse";
            this.ellipseSelector.Click += new System.EventHandler(this.EllipseSelectorClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(29, 6);
            // 
            // penColorSelector
            // 
            this.penColorSelector.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.penColorSelector.Image = ((System.Drawing.Image)(resources.GetObject("penColorSelector.Image")));
            this.penColorSelector.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.penColorSelector.Name = "penColorSelector";
            this.penColorSelector.Size = new System.Drawing.Size(29, 20);
            this.penColorSelector.Text = "colorToolStripDropDownButton1";
            this.penColorSelector.ToolTipText = "Pen color";
            this.penColorSelector.Value = System.Drawing.Color.Black;
            this.penColorSelector.Click += new BlackBeltCoder.ColorToolStripDropDownButton.ColorPaletteEventHandler(this.PenColorSelectorClick);
            // 
            // toolStrip
            // 
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lineSelector,
            this.rectangleSelector,
            this.ellipseSelector,
            this.toolStripSeparator1,
            this.penWidthSelector,
            this.penStyleSelector,
            this.penColorSelector});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(32, 516);
            this.toolStrip.TabIndex = 2;
            this.toolStrip.Text = "toolStrip1";
            // 
            // penWidthSelector
            // 
            this.penWidthSelector.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.penWidthSelector.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5});
            this.penWidthSelector.Image = ((System.Drawing.Image)(resources.GetObject("penWidthSelector.Image")));
            this.penWidthSelector.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.penWidthSelector.Name = "penWidthSelector";
            this.penWidthSelector.Size = new System.Drawing.Size(29, 19);
            this.penWidthSelector.Text = "1";
            this.penWidthSelector.ToolTipText = "Pen width";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(86, 22);
            this.toolStripMenuItem1.Text = "1";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.PenWidthSelectorValueClick);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(86, 22);
            this.toolStripMenuItem2.Text = "3";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.PenWidthSelectorValueClick);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(86, 22);
            this.toolStripMenuItem3.Text = "5";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.PenWidthSelectorValueClick);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(86, 22);
            this.toolStripMenuItem4.Text = "7";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.PenWidthSelectorValueClick);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(86, 22);
            this.toolStripMenuItem5.Text = "15";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.PenWidthSelectorValueClick);
            // 
            // penStyleSelector
            // 
            this.penStyleSelector.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.penStyleSelector.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem6,
            this.toolStripMenuItem7,
            this.toolStripMenuItem8});
            this.penStyleSelector.Image = ((System.Drawing.Image)(resources.GetObject("penStyleSelector.Image")));
            this.penStyleSelector.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.penStyleSelector.Name = "penStyleSelector";
            this.penStyleSelector.Size = new System.Drawing.Size(29, 19);
            this.penStyleSelector.Text = "S";
            this.penStyleSelector.ToolTipText = "Pen style";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem6.Text = "Solid";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.PenStyleSelectorValueClick);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem7.Text = "Dot";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.PenStyleSelectorValueClick);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem8.Text = "Dash";
            this.toolStripMenuItem8.Click += new System.EventHandler(this.PenStyleSelectorValueClick);
            // 
            // drawingArea
            // 
            this.drawingArea.BackColor = System.Drawing.Color.White;
            this.drawingArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawingArea.DrawingContext = null;
            this.drawingArea.Location = new System.Drawing.Point(32, 24);
            this.drawingArea.Name = "drawingArea";
            this.drawingArea.Size = new System.Drawing.Size(752, 516);
            this.drawingArea.TabIndex = 3;
            this.drawingArea.TabStop = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.drawingArea);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "DotNet Paint";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drawingArea)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private DrawingArea drawingArea;
        private System.Windows.Forms.ToolStripButton lineSelector;
        private System.Windows.Forms.ToolStripButton rectangleSelector;
        private System.Windows.Forms.ToolStripButton ellipseSelector;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private BlackBeltCoder.ColorToolStripDropDownButton penColorSelector;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripDropDownButton penWidthSelector;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripDropDownButton penStyleSelector;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
    }
}

