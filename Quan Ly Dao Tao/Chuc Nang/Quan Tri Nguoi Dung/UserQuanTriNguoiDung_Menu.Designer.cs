namespace Quan_Ly_Dao_Tao.Chuc_Nang.Quan_Tri_Nguoi_Dung
{
    partial class UserQuanTriNguoiDung_Menu
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
            this.btQuanTri = new System.Windows.Forms.Button();
            this.btTraCuu = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel1.Controls.Add(this.btTraCuu);
            this.panel1.Controls.Add(this.btQuanTri);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1359, 37);
            this.panel1.TabIndex = 0;
            // 
            // btQuanTri
            // 
            this.btQuanTri.BackColor = System.Drawing.SystemColors.Control;
            this.btQuanTri.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btQuanTri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btQuanTri.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btQuanTri.ForeColor = System.Drawing.Color.Black;
            this.btQuanTri.Location = new System.Drawing.Point(-9, -4);
            this.btQuanTri.Name = "btQuanTri";
            this.btQuanTri.Size = new System.Drawing.Size(197, 42);
            this.btQuanTri.TabIndex = 0;
            this.btQuanTri.Text = "Quản trị người dùng";
            this.btQuanTri.UseVisualStyleBackColor = false;
            this.btQuanTri.Click += new System.EventHandler(this.button1_Click);
            // 
            // btTraCuu
            // 
            this.btTraCuu.BackColor = System.Drawing.Color.RoyalBlue;
            this.btTraCuu.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btTraCuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btTraCuu.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTraCuu.ForeColor = System.Drawing.Color.White;
            this.btTraCuu.Location = new System.Drawing.Point(187, -4);
            this.btTraCuu.Name = "btTraCuu";
            this.btTraCuu.Size = new System.Drawing.Size(209, 42);
            this.btTraCuu.TabIndex = 1;
            this.btTraCuu.Text = "Tra cứu tài khoản";
            this.btTraCuu.UseVisualStyleBackColor = false;
            this.btTraCuu.Click += new System.EventHandler(this.btTraCuu_Click);
            // 
            // panel
            // 
            this.panel.Location = new System.Drawing.Point(0, 36);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1359, 575);
            this.panel.TabIndex = 1;
            // 
            // UserQuanTriNguoiDung_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "UserQuanTriNguoiDung_Menu";
            this.Size = new System.Drawing.Size(1359, 611);
            this.Load += new System.EventHandler(this.UserQuanTriNguoiDung_Menu_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btQuanTri;
        private System.Windows.Forms.Button btTraCuu;
        private System.Windows.Forms.Panel panel;
    }
}
