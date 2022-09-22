
namespace ConvertToIcon
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnSaveIcon = new System.Windows.Forms.Button();
            this.pbImgShow = new System.Windows.Forms.PictureBox();
            this.btnScreen = new System.Windows.Forms.Button();
            this.chbFromHide = new System.Windows.Forms.CheckBox();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.msTrayIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miClose = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pbImgShow)).BeginInit();
            this.msTrayIcon.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSaveIcon
            // 
            this.btnSaveIcon.BackColor = System.Drawing.Color.White;
            this.btnSaveIcon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSaveIcon.BackgroundImage")));
            this.btnSaveIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSaveIcon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveIcon.Location = new System.Drawing.Point(12, 274);
            this.btnSaveIcon.Name = "btnSaveIcon";
            this.btnSaveIcon.Size = new System.Drawing.Size(30, 30);
            this.btnSaveIcon.TabIndex = 0;
            this.btnSaveIcon.UseVisualStyleBackColor = false;
            this.btnSaveIcon.Click += new System.EventHandler(this.SaveIcon_Click);
            // 
            // pbImgShow
            // 
            this.pbImgShow.AllowDrop = true;
            this.pbImgShow.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbImgShow.BackgroundImage")));
            this.pbImgShow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbImgShow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImgShow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbImgShow.Location = new System.Drawing.Point(12, 12);
            this.pbImgShow.Name = "pbImgShow";
            this.pbImgShow.Size = new System.Drawing.Size(256, 256);
            this.pbImgShow.TabIndex = 1;
            this.pbImgShow.TabStop = false;
            this.pbImgShow.Click += new System.EventHandler(this.pbImgShow_Click);
            this.pbImgShow.DragDrop += new System.Windows.Forms.DragEventHandler(this.pbImgShow_DragDrop);
            this.pbImgShow.DragEnter += new System.Windows.Forms.DragEventHandler(this.pbImgShow_DragEnter);
            this.pbImgShow.Paint += new System.Windows.Forms.PaintEventHandler(this.pbImgShow_Paint);
            // 
            // btnScreen
            // 
            this.btnScreen.BackColor = System.Drawing.Color.White;
            this.btnScreen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnScreen.BackgroundImage")));
            this.btnScreen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnScreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScreen.Location = new System.Drawing.Point(48, 274);
            this.btnScreen.Name = "btnScreen";
            this.btnScreen.Size = new System.Drawing.Size(30, 30);
            this.btnScreen.TabIndex = 2;
            this.btnScreen.UseVisualStyleBackColor = false;
            this.btnScreen.Click += new System.EventHandler(this.btnScreen_Click);
            // 
            // chbFromHide
            // 
            this.chbFromHide.AutoSize = true;
            this.chbFromHide.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.chbFromHide.Location = new System.Drawing.Point(84, 274);
            this.chbFromHide.Name = "chbFromHide";
            this.chbFromHide.Size = new System.Drawing.Size(178, 30);
            this.chbFromHide.TabIndex = 3;
            this.chbFromHide.Text = "截圖時隱藏視窗";
            this.chbFromHide.UseVisualStyleBackColor = true;
            // 
            // trayIcon
            // 
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "Icon Creator";
            this.trayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseDoubleClick);
            // 
            // msTrayIcon
            // 
            this.msTrayIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miClose});
            this.msTrayIcon.Name = "msTrayIcon";
            this.msTrayIcon.ShowImageMargin = false;
            this.msTrayIcon.Size = new System.Drawing.Size(156, 48);
            // 
            // miClose
            // 
            this.miClose.Name = "miClose";
            this.miClose.Size = new System.Drawing.Size(155, 22);
            this.miClose.Text = "關閉";
            this.miClose.Click += new System.EventHandler(this.miClose_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 312);
            this.Controls.Add(this.chbFromHide);
            this.Controls.Add(this.btnScreen);
            this.Controls.Add(this.pbImgShow);
            this.Controls.Add(this.btnSaveIcon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Icon";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pbImgShow)).EndInit();
            this.msTrayIcon.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSaveIcon;
        private System.Windows.Forms.PictureBox pbImgShow;
        private System.Windows.Forms.Button btnScreen;
        private System.Windows.Forms.CheckBox chbFromHide;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip msTrayIcon;
        private System.Windows.Forms.ToolStripMenuItem miClose;
    }
}

