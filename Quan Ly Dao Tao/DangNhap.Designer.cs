namespace Quan_Ly_Dao_Tao
{
    partial class DangNhap
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DangNhap));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.cbLuuMK = new System.Windows.Forms.CheckBox();
            this.btDN = new System.Windows.Forms.Button();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tbTK = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.tbMK = new System.Windows.Forms.TextBox();
            this.picAnh = new System.Windows.Forms.PictureBox();
            this.picMK = new System.Windows.Forms.PictureBox();
            this.pictLogo = new System.Windows.Forms.PictureBox();
            this.picTK = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picAnh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTK)).BeginInit();
            this.SuspendLayout();
            // 
            // cbLuuMK
            // 
            this.cbLuuMK.AutoSize = true;
            this.cbLuuMK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbLuuMK.Font = new System.Drawing.Font("#9Slide02 Noi dung dai", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLuuMK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbLuuMK.Location = new System.Drawing.Point(310, 226);
            this.cbLuuMK.Name = "cbLuuMK";
            this.cbLuuMK.Size = new System.Drawing.Size(125, 23);
            this.cbLuuMK.TabIndex = 59;
            this.cbLuuMK.Text = "Hiện mật khẩu";
            this.cbLuuMK.UseVisualStyleBackColor = true;
            this.cbLuuMK.CheckedChanged += new System.EventHandler(this.cbLuuMK_CheckedChanged);
            // 
            // btDN
            // 
            this.btDN.BackColor = System.Drawing.Color.RoyalBlue;
            this.btDN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btDN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDN.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btDN.Location = new System.Drawing.Point(309, 259);
            this.btDN.Name = "btDN";
            this.btDN.Size = new System.Drawing.Size(257, 45);
            this.btDN.TabIndex = 58;
            this.btDN.Text = "Đăng nhập";
            this.btDN.UseVisualStyleBackColor = false;
            this.btDN.Click += new System.EventHandler(this.btDN_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Navy;
            this.panel1.Location = new System.Drawing.Point(309, 211);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 1);
            this.panel1.TabIndex = 61;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Navy;
            this.panel3.Location = new System.Drawing.Point(309, 159);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(250, 1);
            this.panel3.TabIndex = 62;
            // 
            // tbTK
            // 
            this.tbTK.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbTK.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTK.Location = new System.Drawing.Point(339, 137);
            this.tbTK.Name = "tbTK";
            this.tbTK.Size = new System.Drawing.Size(220, 20);
            this.tbTK.TabIndex = 64;
            this.tbTK.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbTK_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(304, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 27);
            this.label1.TabIndex = 63;
            this.label1.Text = "Thông tin đăng nhập";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // tbMK
            // 
            this.tbMK.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbMK.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMK.Location = new System.Drawing.Point(339, 189);
            this.tbMK.Name = "tbMK";
            this.tbMK.Size = new System.Drawing.Size(220, 20);
            this.tbMK.TabIndex = 65;
            this.tbMK.UseSystemPasswordChar = true;
            this.tbMK.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbMK_KeyDown);
            // 
            // picAnh
            // 
            this.picAnh.Image = global::Quan_Ly_Dao_Tao.Properties.Resources.Data_security_05;
            this.picAnh.Location = new System.Drawing.Point(35, 56);
            this.picAnh.Name = "picAnh";
            this.picAnh.Size = new System.Drawing.Size(253, 274);
            this.picAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAnh.TabIndex = 57;
            this.picAnh.TabStop = false;
            // 
            // picMK
            // 
            this.picMK.Image = global::Quan_Ly_Dao_Tao.Properties.Resources.padlock;
            this.picMK.Location = new System.Drawing.Point(308, 184);
            this.picMK.Name = "picMK";
            this.picMK.Size = new System.Drawing.Size(25, 25);
            this.picMK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMK.TabIndex = 60;
            this.picMK.TabStop = false;
            // 
            // pictLogo
            // 
            this.pictLogo.Image = global::Quan_Ly_Dao_Tao.Properties.Resources.Logo_trường_Đại_học_Tiền_Giang1;
            this.pictLogo.Location = new System.Drawing.Point(495, 13);
            this.pictLogo.Name = "pictLogo";
            this.pictLogo.Size = new System.Drawing.Size(70, 70);
            this.pictLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictLogo.TabIndex = 66;
            this.pictLogo.TabStop = false;
            // 
            // picTK
            // 
            this.picTK.Image = global::Quan_Ly_Dao_Tao.Properties.Resources.user;
            this.picTK.Location = new System.Drawing.Point(309, 131);
            this.picTK.Name = "picTK";
            this.picTK.Size = new System.Drawing.Size(25, 25);
            this.picTK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picTK.TabIndex = 67;
            this.picTK.TabStop = false;
            // 
            // DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 347);
            this.Controls.Add(this.cbLuuMK);
            this.Controls.Add(this.btDN);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.tbTK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picAnh);
            this.Controls.Add(this.picMK);
            this.Controls.Add(this.pictLogo);
            this.Controls.Add(this.picTK);
            this.Controls.Add(this.tbMK);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "DangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý đào tạo trường Đại học Tiền Giang";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DangNhap_FormClosing);
            this.Load += new System.EventHandler(this.DangNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picAnh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTK)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.CheckBox cbLuuMK;
        private System.Windows.Forms.Button btDN;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox tbTK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.PictureBox picAnh;
        private System.Windows.Forms.PictureBox picMK;
        private System.Windows.Forms.PictureBox pictLogo;
        private System.Windows.Forms.PictureBox picTK;
        private System.Windows.Forms.TextBox tbMK;
    }
}