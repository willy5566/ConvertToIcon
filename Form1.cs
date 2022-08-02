using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConvertToIcon
{
    public partial class Form1 : Form
    {
        string inputPath = "";
        Image inputImg;
        public Point origin;
        ScreenForm screenForm;
        
        public Form1()
        {
            InitializeComponent();
            //choosesc = new UserActivityHook();
            //choosesc.OnMouseActivity += new MouseEventHandler(choose_OnMouseActivity);
            screenForm = new ScreenForm();
            screenForm.Initial(this);
        }
        public Icon ConvertToIcon(Image image, bool nullTonull = false)
        {
            if (image == null)
            {
                if (nullTonull) { return null; }
                throw new ArgumentNullException("image");
            }

            using (MemoryStream msImg = new MemoryStream()
                              , msIco = new MemoryStream())
            {
                image.Save(msImg, ImageFormat.Png);

                using (BinaryWriter bin = new BinaryWriter(msIco))
                {
                    //寫圖標頭部
                    bin.Write((short)0);           //0-1保留
                    bin.Write((short)1);           //2-3文件類型。1=圖標, 2=光標
                    bin.Write((short)1);           //4-5圖像數量（圖標可以包含多個圖像）

                    bin.Write((byte)image.Width);  //6圖標寬度
                    bin.Write((byte)image.Height); //7圖標高度
                    bin.Write((byte)0);            //8顏色數（若像素位深>=8，填0。這是顯然的，達到8bpp的顏色數最少是256，byte不夠表示）
                    bin.Write((byte)0);            //9保留。必須為0
                    bin.Write((short)0);           //10-11調色板
                    bin.Write((short)32);          //12-13位深
                    bin.Write((int)msImg.Length);  //14-17位圖數據大小
                    bin.Write(22);                 //18-21位圖數據起始字節

                    //寫圖像數據
                    bin.Write(msImg.ToArray());

                    bin.Flush();
                    bin.Seek(0, SeekOrigin.Begin);
                    return new Icon(msIco);
                }
            }
        }

        private void SaveIcon_Click(object sender, EventArgs e)
        {          
            Icon icon = ConvertToIcon(inputImg);
            SaveIcon(icon, inputPath);
            icon.Dispose();
            inputImg.Dispose();
        }

        private void SaveIcon(Icon icon, string savePath)
        {
            MemoryStream memoryStream = new MemoryStream();
            icon.Save(memoryStream);
            string path;
            if (savePath == string.Empty)
                path = "test";
            else
                path = savePath;
            FileStream fileStream = new FileStream(Path.GetFileNameWithoutExtension(path) + ".ico", FileMode.Create, FileAccess.Write);
            memoryStream.WriteTo(fileStream);
            fileStream.Close();
            memoryStream.Close();
        }

        private void pbImgShow_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() != DialogResult.OK)
                return;

            LoadImage(open.FileName);
        }

        private void LoadImage(string path)
        {
            if (inputImg != null)
                inputImg.Dispose();
            inputPath = path;
            inputImg = new Bitmap(inputPath);
            pbImgShow.Invalidate();
        }

        public void LoadImage(Bitmap img)
        {
            if (inputImg != null)
                inputImg.Dispose();
            inputImg = img;
            pbImgShow.Invalidate();
        }

        private void pbImgShow_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void pbImgShow_DragDrop(object sender, DragEventArgs e)
        {
            string[] filePaths = (string[])e.Data.GetData(DataFormats.FileDrop);
            inputPath = filePaths[0];

            LoadImage(inputPath);
        }

        private void pbImgShow_Paint(object sender, PaintEventArgs e)
        {
            if (inputImg != null)
            {
                Rectangle rect = new Rectangle(0, 0, pbImgShow.Width, pbImgShow.Height);
                e.Graphics.DrawImage(inputImg, rect);
            }
        }

        private void btnScreen_Click(object sender, EventArgs e)
        {
            if (chbFromHide.Checked)
            {
                this.Visible = false;
                System.Threading.Thread.Sleep(200); // 不延遲會擷取到視窗還存在的圖
            }
            screenForm.UpdateScreenImg();
            screenForm.Show();          
        }

        public Bitmap GetScreen(Point origin, Size size)
        {
            int width = size.Width;
            int height = size.Height;
            if (width == 0 || height == 0)
                return new Bitmap(1, 1);
            Bitmap screenImg = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(screenImg);
            g.CopyFromScreen(origin, new Point(0, 0), size);
            IntPtr dc1 = g.GetHdc();
            g.ReleaseHdc(dc1);

            return screenImg;
        }
    }
}
