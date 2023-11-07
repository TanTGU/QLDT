namespace Quan_Ly_Dao_Tao.Menu
{
    partial class QuanLyThoiKhoaBieu
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
            this.panel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bt3 = new System.Windows.Forms.Button();
            this.bt2 = new System.Windows.Forms.Button();
            this.bt1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Location = new System.Drawing.Point(0, 34);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1359, 577);
            this.panel.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel1.Controls.Add(this.bt3);
            this.panel1.Controls.Add(this.bt2);
            this.panel1.Controls.Add(this.bt1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1359, 35);
            this.panel1.TabIndex = 6;
            // 
            // bt3
            // 
            this.bt3.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.bt3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt3.ForeColor = System.Drawing.Color.White;
            this.bt3.Location = new System.Drawing.Point(425, -3);
            this.bt3.Name = "bt3";
            this.bt3.Size = new System.Drawing.Size(236, 40);
            this.bt3.TabIndex = 2;
            this.bt3.Text = "In thời khóa biểu";
            this.bt3.UseVisualStyleBackColor = true;
            this.bt3.Click += new System.EventHandler(this.bt3_Click);
            // 
            // bt2
            // 
            this.bt2.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.bt2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt2.ForeColor = System.Drawing.Color.White;
            this.bt2.Location = new System.Drawing.Point(202, -2);
            this.bt2.Name = "bt2";
            this.bt2.Size = new System.Drawing.Size(224, 40);
            this.bt2.TabIndex = 1;
            this.bt2.Text = "Tra cứu lịch dạy học";
            this.bt2.UseVisualStyleBackColor = true;
            this.bt2.Click += new System.EventHandler(this.bt2_Click);
            // 
            // bt1
            // 
            this.bt1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bt1.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.bt1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt1.ForeColor = System.Drawing.Color.Navy;
            this.bt1.Location = new System.Drawing.Point(-2, -2);
            this.bt1.Name = "bt1";
            this.bt1.Size = new System.Drawing.Size(205, 40);
            this.bt1.TabIndex = 0;
            this.bt1.Text = "Lập lịch dạy học";
            this.bt1.UseVisualStyleBackColor = false;
            this.bt1.Click += new System.EventHandler(this.bt1_Click);
            // 
            // QuanLyThoiKhoaBieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "QuanLyThoiKhoaBieu";
            this.Size = new System.Drawing.Size(1359, 611);
            this.Load += new System.EventHandler(this.QuanLyThoiKhoaBieu_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bt3;
        private System.Windows.Forms.Button bt2;
        private System.Windows.Forms.Button bt1;
    }
}
