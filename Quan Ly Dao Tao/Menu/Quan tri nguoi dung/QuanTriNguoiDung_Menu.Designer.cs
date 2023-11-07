namespace Quan_Ly_Dao_Tao.Menu.Nhan_vien_phong_Dao_tao
{
    partial class QuanTriNguoiDung_Menu
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btTraCuu = new System.Windows.Forms.Button();
            this.btQuanLyTaiKhoan = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel1.Controls.Add(this.btTraCuu);
            this.panel1.Controls.Add(this.btQuanLyTaiKhoan);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1359, 35);
            this.panel1.TabIndex = 0;
            // 
            // btTraCuu
            // 
            this.btTraCuu.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btTraCuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btTraCuu.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTraCuu.ForeColor = System.Drawing.Color.White;
            this.btTraCuu.Location = new System.Drawing.Point(202, -2);
            this.btTraCuu.Name = "btTraCuu";
            this.btTraCuu.Size = new System.Drawing.Size(205, 40);
            this.btTraCuu.TabIndex = 1;
            this.btTraCuu.Text = "Tra cứu tài khoản";
            this.btTraCuu.UseVisualStyleBackColor = true;
            this.btTraCuu.Click += new System.EventHandler(this.btTraCuu_Click);
            // 
            // btQuanLyTaiKhoan
            // 
            this.btQuanLyTaiKhoan.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btQuanLyTaiKhoan.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btQuanLyTaiKhoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btQuanLyTaiKhoan.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btQuanLyTaiKhoan.ForeColor = System.Drawing.Color.Navy;
            this.btQuanLyTaiKhoan.Location = new System.Drawing.Point(-2, -2);
            this.btQuanLyTaiKhoan.Name = "btQuanLyTaiKhoan";
            this.btQuanLyTaiKhoan.Size = new System.Drawing.Size(205, 40);
            this.btQuanLyTaiKhoan.TabIndex = 0;
            this.btQuanLyTaiKhoan.Text = "Quản lý tài khoản";
            this.btQuanLyTaiKhoan.UseVisualStyleBackColor = false;
            this.btQuanLyTaiKhoan.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel
            // 
            this.panel.Location = new System.Drawing.Point(0, 34);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1359, 577);
            this.panel.TabIndex = 1;
            // 
            // QuanTriNguoiDung_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.panel);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "QuanTriNguoiDung_Menu";
            this.Size = new System.Drawing.Size(1359, 611);
            this.Load += new System.EventHandler(this.NhanVienPhongDaoTao_Menu_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btTraCuu;
        private System.Windows.Forms.Button btQuanLyTaiKhoan;
        private System.Windows.Forms.Panel panel;
    }
}
