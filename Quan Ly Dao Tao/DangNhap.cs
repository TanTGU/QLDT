using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Quan_Ly_Dao_Tao.Database;

namespace Quan_Ly_Dao_Tao
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void btDN_Click(object sender, EventArgs e)
        {
            string tk = tbTK.Text;
            string mk = tbMK.Text;
            if(tk == "" || mk == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            try
            {
                
                string sql = "select * from TAIKHOAN";
                DataTable dt = CSDL.LayDuLieu(sql);
                bool DK = false;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (tk == dt.Rows[i][0].ToString() && mk == dt.Rows[i][1].ToString())
                    {
                        CSDL.TenHienThi = dt.Rows[i][3].ToString();
                        CSDL.LoaiTaiKhoan = dt.Rows[i][2].ToString();
                        if (dt.Rows[i][4].ToString() != null)
                            CSDL.MaGV = dt.Rows[i][4].ToString();
                        DK = true;
                        CSDL.TK = tk;
                        CSDL.MK = mk;
                    }
                }
                if(DK)
                {
                    TrangChu trangChu = new TrangChu();
                    trangChu.Show();
                    this.Hide();
                    return;
                }
                else
                {
                    MessageBox.Show("Thông tin đăng nhập không chính xác, Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Hệ thống đã xảy ra lỗi, vui lòng thử lại sau!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
            CSDL.KetNoi();
            tbTK.Focus();
        }

        private void DangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void cbLuuMK_CheckedChanged(object sender, EventArgs e)
        {
            if (cbLuuMK.Checked == true)
                tbMK.UseSystemPasswordChar = false;
            else tbMK.UseSystemPasswordChar = true;
        }

        private void tbTK_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                tbMK.Focus();
            }
        }

        private void tbMK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btDN_Click(sender, e);
            }
        }
    }
}
