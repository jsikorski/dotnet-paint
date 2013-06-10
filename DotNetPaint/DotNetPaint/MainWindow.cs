using System;
using System.Windows.Forms;

namespace DotNetPaint
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeGraphics();
        }

        private void InitializeGraphics()
        {
            DoubleBuffered = true;
        }

        private void ExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
