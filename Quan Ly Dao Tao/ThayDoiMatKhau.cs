using Quan_Ly_Dao_Tao.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Dao_Tao
{
    public partial class ThayDoiMatKhau : Form
    {
        string TK = "";
        string MK = "";
        public ThayDoiMatKhau(string TK, string MK)
        {
            InitializeComponent();
            this.TK = TK;
            this.MK = MK;
        }

        private void ThayDoiMatKhau_Load(object sender, EventArgs e)
        {
            string sql = $"select TenHienThi from TAIKHOAN where TK = '{TK}'";
            DataTable dt = CSDL.LayDuLieu(sql);
            if(dt.Rows.Count > 0 )
            {
                tbTK.Text = TK;
                tbTen.Text = dt.Rows[0][0].ToString();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                tbMKCu.UseSystemPasswordChar = false;
            }
            else
                tbMKCu.UseSystemPasswordChar = true;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                tbMKMoi1.UseSystemPasswordChar = false;
            }
            else
                tbMKMoi1.UseSystemPasswordChar = true;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                tbMKMoi2.UseSystemPasswordChar = false;
            }
            else
                tbMKMoi2.UseSystemPasswordChar = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(tbMKCu.Text == "" || tbMKMoi1.Text == "" || tbMKMoi2.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if (!(MK.Equals(tbMKCu.Text, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Mật khẩu hiện tại không trùng khớp. Vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!(tbMKMoi1.Text.Equals(tbMKMoi2.Text, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Mật khẩu mới và nhắc lại mật khẩu không trùng khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string sql = $"UPDATE TAIKHOAN SET MK = '{tbMKMoi2.Text}' WHERE TK = '{tbTK.Text}'";
                CSDL.XuLy(sql);
                CSDL.GhiLenhXuLySQL(sql);
                MessageBox.Show("Đã thay đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            catch
            {
                MessageBox.Show("Thay đổi mật khẩu không thành công. vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
