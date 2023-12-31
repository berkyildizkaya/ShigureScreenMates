using System;
using System.Drawing;
using System.Windows.Forms;

namespace Shigure
{
    public partial class Form1 : Form
    {
        private PictureBox pictureBox;
        private ContextMenuStrip formContextMenuStrip;
        private ToolStripMenuItem toggleTopMostMenuItem;

        public Form1()
        {
            InitializeComponent();
            InitializePictureBox();
            InitializeFormContextMenu();
            TransparencyKey = Color.White;
            BackColor = Color.White;
            //TopMost = true;
            Icon = Properties.Resources.app;
        }

        private void InitializePictureBox()
        {
            pictureBox = new PictureBox();
            pictureBox.Image = Properties.Resources.Transparent1_100x100;
            pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox.BackColor = Color.Transparent;
            pictureBox.MouseDoubleClick += PictureBox_MouseDoubleClick;
            Controls.Add(pictureBox);

            SetFormProperties();
        }

        private void PictureBox_MouseDoubleClick(object? sender, MouseEventArgs e)
        {
            Environment.Exit(0);
            Application.Exit();
        }

        private void InitializeFormContextMenu()
        {
            formContextMenuStrip = new ContextMenuStrip();

            toggleTopMostMenuItem = new ToolStripMenuItem("Toggle TopMost");
            toggleTopMostMenuItem.Click += ToggleTopMostMenuItem_Click;

            formContextMenuStrip.Items.Add(toggleTopMostMenuItem);
            ContextMenuStrip = formContextMenuStrip;
        }

        private void ToggleTopMostMenuItem_Click(object sender, EventArgs e)
        {
            TopMost = !TopMost;
            toggleTopMostMenuItem.Checked = TopMost;
        }

        private void SetFormProperties()
        {
            FormBorderStyle = FormBorderStyle.None;

            StartPosition = FormStartPosition.Manual;
            Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - pictureBox.Width,
                                 Screen.PrimaryScreen.WorkingArea.Height - pictureBox.Height);
            Opacity = 1;
        }
    }
}
