using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConvertToIcon
{
    public partial class ScreenForm : Form
    {
        Point start, end, origin;
        Size size;
        bool flag = false;
        Bitmap screenImg;
        Form1 mainForm;
        public ScreenForm()
        {
            InitializeComponent();
        }

        public void Initial(Form1 form)
        {
            Location = new Point(0, 0);
            Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            mainForm = form;
        }

        public void UpdateScreenImg()
        {
            if (screenImg != null)
                screenImg.Dispose();
            screenImg = new Bitmap(Size.Width, Size.Height);
            Graphics g = Graphics.FromImage(screenImg);
            g.CopyFromScreen(Location, Location, Size);
            IntPtr dc1 = g.GetHdc();
            g.ReleaseHdc(dc1);
        }

        private void ScreenForm_Paint(object sender, PaintEventArgs e)
        {
            if (screenImg == null)
                return;

            e.Graphics.DrawImage(screenImg, Location);
            if (flag)
                e.Graphics.DrawRectangle(Pens.Red, new Rectangle(origin, size));
        }

        private void ScreenForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                flag = false;
                Invalidate();
                Hide();
                //Bitmap bmp = mainForm.GetScreen(origin, size);
                Bitmap bmp = screenImg.Clone(new Rectangle(origin, size), System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                
                mainForm.LoadImage(bmp);
                if (mainForm.Visible == false)
                    mainForm.Show();
            }
        }

        private void ScreenForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Hide();
                if (mainForm.Visible == false)
                    mainForm.Show();
            }
        }

        private void ScreenForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && flag)
            {
                end = e.Location;
                origin = new Point(
                    start.X > end.X ? end.X : start.X,
                    start.Y > end.Y ? end.Y : start.Y);
                size = new Size(
                    Math.Abs(start.X - end.X) + 1,
                    Math.Abs(start.Y - end.Y) + 1);

                Invalidate();
            }
        }

        private void ScreenForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                start = e.Location;
                flag = true;
            }
        }
    }
}
