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

namespace Quan_Ly_Dao_Tao.Chuc_Nang.Quan_Ly_Diem
{
    public partial class NhapDiemRenLuyen_QuanLyDiem : UserControl
    {
        public NhapDiemRenLuyen_QuanLyDiem()
        {
            InitializeComponent();//
        }
        string MaLop, TenLop;
        void layDSNamhoc()
        {
            string sql = "select distinct NAMHOC.NamHoc, DIEMRENLUYEN.HocKy from DIEMRENLUYEN, NAMHOC";//
            DataTable dt = CSDL.LayDuLieu(sql);
            cbNamHoc.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbNamHoc.Items.Add(dt.Rows[i][0].ToString());
                //cbHK.Items.Add(dt.Rows[i][1].ToString());
            }
        }


        private void listLop_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            // Tô màu nền
            e.Graphics.FillRectangle(Brushes.RoyalBlue, e.Bounds);
            // vẽ lại dòng tiêu đề với font in đậm và màu trắng
            e.Graphics.DrawString(e.Header.Text, new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold), Brushes.White, e.Bounds);

        }

        private void listDS_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            // Tô màu nền
            e.Graphics.FillRectangle(Brushes.RoyalBlue, e.Bounds);
            // vẽ lại dòng tiêu đề với font in đậm và màu trắng
            e.Graphics.DrawString(e.Header.Text, new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold), Brushes.White, e.Bounds);

        }

        private void listLop_DrawItem(object sender, DrawListViewItemEventArgs e)
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
                    e.Graphics.DrawString(listLop.Name, new Font(FontFamily.GenericSansSerif, 12), Brushes.Black, e.Bounds.Left, e.Bounds.Top);
                }
            }

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

        void LayDSLop()
        {
            string sql = "select MaLop, TenLop from LOP";
            DataTable dt = CSDL.LayDuLieu(sql);
            listLop.Items.Clear();
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                listLop.Items.Add(dt.Rows[i][0].ToString());
                listLop.Items[i].SubItems.Add(dt.Rows[i][1].ToString());
            }
        }

        private void NhapDiemRenLuyen_QuanLyDiem_Load(object sender, EventArgs e)
        {
            layDSNamhoc();
            LayDSLop();
        }

        void LayDSSinhVien(string MaLop)
        {
            string select = "SELECT SINHVIEN.MaSV, HoTen, MaLop, DIEMRENLUYEN.Diem FROM SINHVIEN ";
            string leftjion = $"LEFT JOIN DIEMRENLUYEN ON DIEMRENLUYEN.MaSV = SINHVIEN.MaSV AND DIEMRENLUYEN.NamHoc = '{cbNamHoc.Text}' AND DIEMRENLUYEN.HocKy = {cbHK.Text} ";
            string where = $"where MaLop = '{MaLop}'";
            string sql = select + leftjion + where;
            DataTable dt = CSDL.LayDuLieu(sql);
            listDS.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listDS.Items.Add((i + 1).ToString());
                listDS.Items[i].SubItems.Add(dt.Rows[i][0].ToString());
                listDS.Items[i].SubItems.Add(dt.Rows[i][1].ToString());
                listDS.Items[i].SubItems.Add(dt.Rows[i][2].ToString());
                if (dt.Rows[i][3] != null)
                    listDS.Items[i].SubItems.Add(dt.Rows[i][3].ToString());
            }
            lbTong.Text = listDS.Items.Count.ToString();
        }

        private void listLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbHK.Text == "" || cbNamHoc.Text == "")
            {
                MessageBox.Show("Vui lòng chọn thông tin học kỳ - năm học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if(listLop.SelectedItems.Count > 0)
            {
                LayDSSinhVien(listLop.SelectedItems[0].SubItems[0].Text);
                MaLop = listLop.SelectedItems[0].SubItems[0].Text;
                TenLop = listLop.SelectedItems[0].SubItems[1].Text;
            }
            
        }

        private void cbNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        bool KiemTraDuLieuTonTai(string MaSV)
        {
            string sql = $"select * from DIEMRENLUYEN where MaSV = '{txtMSSV.Text}' AND HocKy = {cbHK.Text} AND NamHoc = '{cbNamHoc.Text}'";
            DataTable dt = CSDL.LayDuLieu(sql);
            if(dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbHK.Text == "" || cbNamHoc.Text == "")
            {
                MessageBox.Show("Vui lòng chọn thông tin học kỳ - năm học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if (txtMSSV.Text == "")
            {
                MessageBox.Show("Vui lòng chọn thông sinh viên cần nhập điểm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            string sql;
            if(KiemTraDuLieuTonTai(txtMSSV.Text))
            {
                try
                {
                    sql = $"UPDATE DIEMRENLUYEN SET Diem = {numDiem.Value.ToString()} WHERE MaSV = '{txtMSSV.Text}' AND HocKy = {cbHK.Text} AND NamHoc = '{cbNamHoc.Text}'";
                    CSDL.XuLy(sql);
                    //CSDL.GhiLenhXuLySQL(sql);
                    LayDSSinhVien(MaLop);
                    MessageBox.Show("Đã nhập điểm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Nhập điểm không thành công. Vui lòng kiểm tra và thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                try
                {
                    sql = $"insert into DIEMRENLUYEN (MaSV, HocKy, NamHoc, Diem) values ('{txtMSSV.Text}', {cbHK.Text}, '{cbNamHoc.Text}', {numDiem.Value.ToString()})";
                    CSDL.XuLy(sql);
                    //CSDL.GhiLenhXuLySQL(sql);
                    LayDSSinhVien(MaLop);
                    MessageBox.Show("Đã nhập điểm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Nhập điểm không thành công. Vui lòng kiểm tra và thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void cbHK_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listDS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listDS.SelectedItems.Count > 0)
            {
                txtLop.Text = TenLop;
                txtMSSV.Text = listDS.SelectedItems[0].SubItems[1].Text;
                txtHoTen.Text = listDS.SelectedItems[0].SubItems[2].Text;
                numDiem.Value = 0;
                if (listDS.SelectedItems[0].SubItems[4].Text != "")
                    numDiem.Value = Convert.ToInt32(listDS.SelectedItems[0].SubItems[4].Text);
            }
        }
    }
}
