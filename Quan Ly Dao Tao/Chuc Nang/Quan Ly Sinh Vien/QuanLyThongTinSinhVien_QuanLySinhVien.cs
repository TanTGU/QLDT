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

namespace Quan_Ly_Dao_Tao.Chuc_Nang.Quan_Ly_Sinh_Vien
{
    public partial class QuanLyThongTinSinhVien_QuanLySinhVien : UserControl
    {
        public QuanLyThongTinSinhVien_QuanLySinhVien()
        {
            InitializeComponent();
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

        void LayDSDonVi()
        {
            string sql = "select *from DONVI";
            DataTable dt = CSDL.LayDuLieu(sql);
            cbDonVi.Items.Clear();
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                cbDonVi.Items.Add(dt.Rows[i][1].ToString());
            }
        }

        private void QuanLyThongTinSinhVien_QuanLySinhVien_Load(object sender, EventArgs e)
        {
            LayDSDonVi();
        }

        string LayMaDV(string Ten)
        {
            string sql = "select MaDV from DONVI where TenDV = N'"+Ten+"'";
            DataTable dt = CSDL.LayDuLieu(sql);
            string Ma = "";
            if(dt.Rows.Count > 0)
            {
                Ma = dt.Rows[0][0].ToString();
            }
            return Ma;
        }

        string LayMaLop(string Ten)
        {
            string sql = "select MaLop from LOP where TenLop = N'" + Ten + "'";
            DataTable dt = CSDL.LayDuLieu(sql);
            string Ma = "";
            if (dt.Rows.Count > 0)
            {
                Ma = dt.Rows[0][0].ToString();
            }
            return Ma;
        }

        void LamMoi()
        {
            tbMaSV.Text = "";
            tbHoTen.Text = "";
            dateNgaySinh.Value = DateTime.Now;
            cbGioiTinh.Text = "";
            tbCCCD.Text = "";
            tbSoDT.Text = "";
            tbEmail.Text = "";
            tbDiaChi.Text = "";
            tbMaLop.Text = "";
            tbTenLop.Text = "";
            tbNganhHoc.Text = "";
            cbHinhThucDaoTao.Text = "";
            cbBacDaoTao.Text = "";
        }

        private void cbDonVi_SelectedIndexChanged(object sender, EventArgs e)
        {
            LamMoi();
            string MaDV = LayMaDV(cbDonVi.Text);
            string sql = "select LOP.TenLop from LOP, NGANH, DONVI where DONVI.MaDV = NGANH.MaDV and NGANH.MaNganh = LOP.MaNganh and DONVI.TenDV = N'"+ cbDonVi.Text + "'";
            DataTable dt = CSDL.LayDuLieu(sql);
            cbLop.Items.Clear();
            for(int i = 0; i < dt.Rows.Count;i++)
            {
                cbLop.Items.Add(dt.Rows[i][0].ToString());
            }
        }

        private void cbLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            LamMoi();
            string MaLop = LayMaLop(cbLop.Text);
            string sql = "select MaSV, HoTen from SINHVIEN where MaLop = '"+MaLop+"'";
            listDS.Items.Clear();
            DataTable dt = CSDL.LayDuLieu(sql);
            for(int i = 0;i < dt.Rows.Count;i++)
            {
                listDS.Items.Add(dt.Rows[i][0].ToString());
                listDS.Items[i].SubItems.Add(dt.Rows[i][1].ToString());
            }
        }

        private void listDS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listDS.SelectedItems.Count > 0)
            {
                string sql = @"select MaSV, HoTen, NgaySinh, GioiTinh, CCCD, SoDT, Email, DiaChi, SINHVIEN.MaLop, LOP.TenLop, NGANH.TenNganh, HINHTHUCDAOTAO.Ten, BACDAOTAO.Ten  from SINHVIEN, LOP, NGANH, HINHTHUCDAOTAO, BACDAOTAO where NGANH.MaNganh = LOP.MaNganh and LOP.HinhThucDaoTao = HINHTHUCDAOTAO.Ma and LOP.BacDaoTao = BACDAOTAO.Ma and SINHVIEN.MaLop = LOP.MaLop and SINHVIEN.MaSV = '" + listDS.SelectedItems[0].SubItems[0].Text +"'";
                DataTable dt = CSDL.LayDuLieu(sql);
                if(dt.Rows.Count > 0)
                {
                    tbMaSV.Text = dt.Rows[0][0].ToString();
                    tbHoTen.Text = dt.Rows[0][1].ToString();
                    dateNgaySinh.Value = Convert.ToDateTime(dt.Rows[0][2].ToString());
                    cbGioiTinh.Text = dt.Rows[0][3].ToString();
                    tbCCCD.Text = dt.Rows[0][4].ToString();
                    tbSoDT.Text = dt.Rows[0][5].ToString();
                    tbEmail.Text = dt.Rows[0][6].ToString();
                    tbDiaChi.Text = dt.Rows[0][7].ToString();
                    tbMaLop.Text = dt.Rows[0][8].ToString();
                    tbTenLop.Text = dt.Rows[0][9].ToString();
                    tbNganhHoc.Text = dt.Rows[0][10].ToString();
                    cbHinhThucDaoTao.Text = dt.Rows[0][11].ToString();
                    cbBacDaoTao.Text = dt.Rows[0][12].ToString();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LamMoi();
            if(tbTimMaLop.Text =="")
            {
                MessageBox.Show("Vui lòng nhập mã lớp cần tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            listDS.Items.Clear();
            string sql = "select DONVI.TenDV, LOP.TenLop from LOP, DONVI, NGANH where LOP.MaNganh = NGANH.MaNganh and DONVI.MaDV = NGANH.MaDV and LOP.MaLop = '"+tbTimMaLop.Text+"'";
            DataTable dt = CSDL.LayDuLieu(sql);
            if(dt.Rows.Count > 0)
            {
                cbDonVi.Text = dt.Rows[0][0].ToString();
                cbLop.Text = dt.Rows[0][1].ToString();

                string MaLop = LayMaLop(cbLop.Text);
                string sql1 = "select MaSV, HoTen from SINHVIEN where MaLop = '" + MaLop + "'";
                listDS.Items.Clear();
                DataTable dt1 = CSDL.LayDuLieu(sql1);
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    listDS.Items.Add(dt1.Rows[i][0].ToString());
                    listDS.Items[i].SubItems.Add(dt1.Rows[i][1].ToString());
                }

            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin lớp phù hợp. Vui lòng thử lại!", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
        }
    }
}
