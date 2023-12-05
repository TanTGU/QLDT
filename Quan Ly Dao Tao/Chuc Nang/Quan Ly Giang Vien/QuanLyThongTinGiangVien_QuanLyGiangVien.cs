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

namespace Quan_Ly_Dao_Tao.Chuc_Nang.Quan_Ly_Giang_Vien
{
    public partial class QuanLyThongTinGiangVien_QuanLyGiangVien : UserControl
    {
        public QuanLyThongTinGiangVien_QuanLyGiangVien()
        {
            InitializeComponent();
        }

        void LaySLGV()
        {
            lbSL.Text = listDS.Items.Count.ToString() + " giảng viên";
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void QuanLyThongTinGiangVien_QuanLyGiangVien_Load(object sender, EventArgs e)
        {
            CSDL.KetNoi();
            DataTable dt = new DataTable();
            String sql = @"select * from donvi";
            dt = CSDL.LayDuLieu(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbdonvi.Items.Add(dt.Rows[i][1].ToString());;
                cbdonvi1.Items.Add(dt.Rows[i][0].ToString());
            }
            cbGioi.Items.Add("Nam");
            cbGioi.Items.Add("Nữ");
            string sql1 = "select MaGV, HoTen, MaDV From GIANGVIEN ";
            DataTable dt1= new DataTable();
            dt1 = CSDL.LayDuLieu(sql1);//
            listDS.Items.Clear();
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                listDS.Items.Add(dt1.Rows[i][0].ToString());
                listDS.Items[i].SubItems.Add(dt1.Rows[i][1].ToString());
                listDS.Items[i].SubItems.Add(dt1.Rows[i][2].ToString());
            }
            LaySLGV();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            //ggtttt
            string ma = txtMaGv.Text;
            string sql = "select MaGV, HoTen, MaDV From GIANGVIEN where MaGV='" + ma+"'";
            DataTable dt = new DataTable();
            dt = CSDL.LayDuLieu(sql);
            listDS.Items.Clear();
            listDS.Items.Add(dt.Rows[0][0].ToString());
            listDS.Items[0].SubItems.Add(dt.Rows[0][1].ToString());
            listDS.Items[0].SubItems.Add(dt.Rows[0][2].ToString());
            LaySLGV();
        }

        private void listDS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listDS.SelectedItems.Count != 0)
            {
                string txt = listDS.SelectedItems[0].SubItems[0].Text;
                
                string sql = "select * from GIANGVIEN where MaGV='" + txt+"'";
                DataTable dt = new DataTable();
                dt = CSDL.LayDuLieu(sql);
                
                txtGV.Text = dt.Rows[0][0].ToString();
                txtHoten.Text = dt.Rows[0][1].ToString();
                d1.Text = dt.Rows[0][2].ToString();
                cbGioi.Text = dt.Rows[0][3].ToString();
                txtSDT.Text = dt.Rows[0][4].ToString();
                txtEmail.Text = dt.Rows[0][5].ToString();
                txtDiachi.Text = dt.Rows[0][6].ToString();
                cbdonvi1.Text = dt.Rows[0][7].ToString();
                txtHH.Text = dt.Rows[0][8].ToString();
                txtHV.Text = dt.Rows[0][9].ToString(); 
            }
            LaySLGV();
        }

        private void cbdonvi_SelectedIndexChanged(object sender, EventArgs e)
        {
           
                string dv = cbdonvi.SelectedItem.ToString();
                string sql = "select MaDV from DONVI where TenDV= N'" + dv + "'";
                DataTable dt = new DataTable();
                dt = CSDL.LayDuLieu(sql);
                string sql1 = "select MaGV, HoTen, MaDV From GIANGVIEN where MaDV= '" + dt.Rows[0][0].ToString() + "'";
                DataTable dt1 = new DataTable();
                dt1 = CSDL.LayDuLieu(sql1);
                listDS.Items.Clear();
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    listDS.Items.Add(dt1.Rows[i][0].ToString());
                    listDS.Items[i].SubItems.Add(dt1.Rows[i][1].ToString());
                    listDS.Items[i].SubItems.Add(dt1.Rows[i][2].ToString());
                }
            LaySLGV();

        }

        private void button1_Click(object sender, EventArgs e)//them
        {
            if (txtGV.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã giáo viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if (txtHoten.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã giáo viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if (txtSDT.Text == "")
            {
                MessageBox.Show("Vui lòng số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Vui lòng nhập email!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if (txtDiachi.Text == "")
            {
                MessageBox.Show("Vui lòng nhập địa chỉ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            
            string gv = txtGV.Text ;
            string hoten = txtHoten.Text;
            string ngaysinh =d1.Value.ToString("yyyy/MM/dd") ;
            string gt = cbGioi.Text ;
            string sdt = txtSDT.Text ;
            string email = txtEmail.Text ;
            string diachi = txtDiachi.Text ;
            string dv = cbdonvi1.Text ;
            string hocham = txtHH.Text ;
            string hocvi = txtHV.Text ;
            string insert = "insert into GIANGVIEN(MaGV, HoTen, NgaySinh, GioiTinh, SoDT, Email, DiaChi, MaDV, HocHam, HocVi) ";
            string values = $" values ('{gv}', N'{hoten}', '{ngaysinh}', N'{gt}', '{sdt}', '{email}', N'{diachi}', '{dv}', N'{hocham}', N'{hocvi}')";
            string sql = insert + values;
            try
            {
                CSDL.XuLy(sql);
                
                MessageBox.Show("Đã thêm thông tin giảng viên mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Thêm thông tin giảng viên mới không thành công. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)// sua hay cap nhat
        {

            if (txtGV.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã giáo viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if (txtHoten.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã giáo viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if (txtSDT.Text == "")
            {
                MessageBox.Show("Vui lòng số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Vui lòng nhập email!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if (txtDiachi.Text == "")
            {
                MessageBox.Show("Vui lòng nhập địa chỉ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            string gv = txtGV.Text;
            string hoten = txtHoten.Text;
            string ngaysinh = d1.Value.ToString("yyyy/MM/dd");
            string gt = cbGioi.Text;
            string sdt = txtSDT.Text;
            string email = txtEmail.Text;
            string diachi = txtDiachi.Text;
            string dv = cbdonvi1.Text;
            string hocham = txtHH.Text;
            string hocvi = txtHV.Text;

            string sql = $"update GIANGVIEN set MaGV = '{gv}',HoTen = N'{hoten}',NgaySinh = '{ngaysinh}',GioiTinh = N'{gt}',SoDT= '{sdt}',Email = '{email}',DiaChi = N'{diachi}',MaDV = '{dv}',HocHam = N'{hocham}',HocVi = N'{hocvi}' where MaGV ='{gv}'  ";

            try
            {
                CSDL.XuLy(sql);

                MessageBox.Show("Đã sửa thông tin giảng viên mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Sửa thông tin giảng viên mới không thành công. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)//xoa
        {
            string gv = txtGV.Text;
            string hoten = txtHoten.Text;
            if (gv == "" || hoten == "" )
            {
                MessageBox.Show("Vui lòng chọn giảng viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            string sql = $"Delete GIANGVIEN where MaGV = '{gv}'";
            DialogResult result = MessageBox.Show($"Bạn thật sự muốn sinh viên {gv}?", "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    CSDL.XuLy(sql);
                    
                    MessageBox.Show("Đã xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Không thể xóa thông tin sinh viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
