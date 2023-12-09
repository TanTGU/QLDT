using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quan_Ly_Dao_Tao.Database;

namespace Quan_Ly_Dao_Tao.Chuc_Nang.Quan_Tri_Nguoi_Dung
{
    public partial class QuanLyTaiKhoan_QuanTriNguoiDung : UserControl
    {
        public QuanLyTaiKhoan_QuanTriNguoiDung()
        {
            InitializeComponent();
        }

        void LayDSTaiKhoan()
        {
            string sql = "select TAIKHOAN.TK, LOAITAIKHOAN.TenLoai from TAIKHOAN, LOAITAIKHOAN where TAIKHOAN.LoaiTK = LOAITAIKHOAN.MaLoai";
            DataTable dt = CSDL.LayDuLieu(sql);
            listDS.Items.Clear();
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                listDS.Items.Add(dt.Rows[i][0].ToString());
                listDS.Items[i].SubItems.Add(dt.Rows[i][1].ToString());
            }    
        }

        void LayDSLoaiTK()
        {
            string sql = "select *from LOAITAIKHOAN";
            cbPhanLoai.Items.Clear();
            DataTable dt = CSDL.LayDuLieu(sql);
            for(int i = 0;i < dt.Rows.Count;i++)
            {
                cbPhanLoai.Items.Add(dt.Rows[i][1].ToString());
            }    
        }

        private void listDS_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            // Tô màu nền
            e.Graphics.FillRectangle(Brushes.RoyalBlue, e.Bounds);
            // vẽ lại dòng tiêu đề với font in đậm và màu trắng
            e.Graphics.DrawString(e.Header.Text, new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold), Brushes.White, e.Bounds);

        }

        private void listDS_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
            if (e.Item != null)
            {
                if (e.ItemIndex == 0) // Nếu là dòng tiêu đề
                {
                }
                else // Nếu là các dòng dữ liệu
                {
                    // Vẽ các dòng dữ liệu với màu chữ đen và font size nhỏ hơn
                    e.Graphics.DrawString(listDS.Name, new Font(FontFamily.GenericSansSerif, 12), Brushes.Black, e.Bounds.Left, e.Bounds.Top);
                }
            }

        }

        private void QuanLyTaiKhoan_QuanTriNguoiDung_Load(object sender, EventArgs e)
        {
            //LayDSTaiKhoan();
            LayDSLoaiTK();
        }
        void LayDS()
        {
            string sql = "select TAIKHOAN.TK, LOAITAIKHOAN.TenLoai from TAIKHOAN, LOAITAIKHOAN where TAIKHOAN.LoaiTK = LOAITAIKHOAN.MaLoai and LOAITAIKHOAN.TenLoai = N'" + cbPhanLoai.Text + "'";
            DataTable dt = CSDL.LayDuLieu(sql);
            listDS.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listDS.Items.Add(dt.Rows[i][0].ToString());
                listDS.Items[i].SubItems.Add(dt.Rows[i][1].ToString());
            }
            tbLoaiTK.Text = cbPhanLoai.Text;
        }

        private void cbPhanLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            LayDS();
        }

        private void listDS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listDS.SelectedItems.Count > 0)
            {
                string sql = "select TAIKHOAN.MaGV, TAIKHOAN.TenHienThi, TenLoai, MK from TAIKHOAN, LOAITAIKHOAN where TAIKHOAN.LoaiTK = LOAITAIKHOAN.MaLoai and TK = '" + listDS.SelectedItems[0].SubItems[0].Text + "'";
                DataTable dt = CSDL.LayDuLieu(sql);
                if (dt.Rows.Count > 0)
                {
                    tbHoTen.Text = dt.Rows[0][1].ToString();
                    tbTK.Text = listDS.SelectedItems[0].SubItems[0].Text;
                    tbLoaiTK.Text = cbPhanLoai.Text;
                    tbLoaiTK.Text = dt.Rows[0][2].ToString();
                    tbMK.Text = dt.Rows[0][3].ToString();
                    cbPhanLoai.Text = listDS.SelectedItems[0].SubItems[1].Text;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(tbTimKiem.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập thông tin tài khoản cần tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            listDS.Items.Clear();
            string sql = "select TK, TenLoai from TAIKHOAN, LOAITAIKHOAN where TAIKHOAN.LoaiTK = LOAITAIKHOAN.MaLoai and TK like '%"+tbTimKiem.Text+"%'";
            DataTable dt = CSDL.LayDuLieu(sql);
            if(dt.Rows.Count > 0)
            {
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    listDS.Items.Add(dt.Rows[i][0].ToString());
                    listDS.Items[i].SubItems.Add(dt.Rows[i][1].ToString());
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy tài khoản phù hợp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        bool KiemTraTrungLap (string TK)
        {
            string sql = $"select * from TAIKHOAN where TK = '{TK}'";
            DataTable dt = CSDL.LayDuLieu(sql);
            if(dt.Rows.Count > 0 )
                return true;
            return false;
        }
        string LayMaLoaiTK(string Ten)
        {
            string result = "";
            string sql = $"select MaLoai from LOAITAIKHOAN where TenLoai = N'{Ten}'";
            DataTable dt = CSDL.LayDuLieu(sql);
            if( dt.Rows.Count > 0 )
                result = dt.Rows[0][0].ToString();
            return result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(tbTK.Text == "" || tbMK.Text == "" || tbLoaiTK.Text == "" || tbHoTen.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if(KiemTraTrungLap(tbTK.Text))
            {
                MessageBox.Show("Tài khoản đã tồn tại. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                string sql = $"insert into TAIKHOAN(TK, MK, LoaiTK, TenHienThi, MaGV) values ('{tbTK.Text}', '{tbMK.Text}', '{LayMaLoaiTK(cbPhanLoai.Text)}', N'{tbHoTen.Text}', null)";
                CSDL.XuLy(sql);
               
                CSDL.GhiLenhXuLySQL(sql);
                LayDS();
                MessageBox.Show("Dã thêm tài khoản mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            catch
            {
                MessageBox.Show("Không thể thêm tài khoản mới. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (tbTK.Text == "" || tbMK.Text == "" || tbLoaiTK.Text == "" || tbHoTen.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            try
            {
                string sql = $"UPDATE TAIKHOAN SET MK = '{tbMK.Text}', TenHienThi = N'{tbHoTen.Text}' WHERE TK = '{tbTK.Text}'";
                CSDL.XuLy(sql);
                LayDS();
                CSDL.GhiLenhXuLySQL(sql);
                MessageBox.Show("Đã cập nhật tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            catch
            {
                MessageBox.Show("Không thể cập nhật thông tin tài khoản. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbTK.Text == "" || tbMK.Text == "" || tbLoaiTK.Text == "" || tbHoTen.Text == "")
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            string sql = $"DELETE FROM TAIKHOAN WHERE TK = '{tbTK.Text}'";
            DialogResult result = MessageBox.Show($"Bạn thật sự muốn tài khoản {tbTK.Text}?", "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    CSDL.XuLy(sql);
                    LayDS();
                    CSDL.GhiLenhXuLySQL(sql);
                    MessageBox.Show("Đã xóa tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Không thể xóa tài khoản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
