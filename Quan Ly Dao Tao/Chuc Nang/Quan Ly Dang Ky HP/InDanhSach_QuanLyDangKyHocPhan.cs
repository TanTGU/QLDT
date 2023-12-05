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

namespace Quan_Ly_Dao_Tao.Chuc_Nang.Quan_Ly_Dang_Ky_HP
{
    public partial class InDanhSach_QuanLyDangKyHocPhan : UserControl
    {
        public InDanhSach_QuanLyDangKyHocPhan()
        {
            InitializeComponent();
        }

        void LayTenNganh()
        {
            string sql = @"select * from NGANH";
            DataTable dt = new DataTable();
            dt = CSDL.LayDuLieu(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbNganh.Items.Add(dt.Rows[i][1].ToString());
            }

        }

        private void listMH_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
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

        private void listMH_DrawItem(object sender, DrawListViewItemEventArgs e)
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
                    e.Graphics.DrawString(listMH.Name, new Font(FontFamily.GenericSansSerif, 12), Brushes.Black, e.Bounds.Left, e.Bounds.Top);
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

        private void InDanhSach_QuanLyDangKyHocPhan_Load(object sender, EventArgs e)
        {
            CSDL.KetNoi();
            string sql = @" select * from NAMHOC";
            DataTable dt = new DataTable();
            dt = CSDL.LayDuLieu(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbNamHoc.Items.Add(dt.Rows[i][0].ToString());
            }
            LayTenNganh();
        }

        private void cbNganh_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select distinct MONHOC.TenMH from THOIKHOABIEU, MONHOC where THOIKHOABIEU.MaMH = MONHOC.MaMH and MONHOC.TenNganh = N'" + cbNganh.Text + "' and NamHoc = '" + cbNamHoc.Text + "' and HocKy = " + cbHocKy.Text;
            cbMonHoc.Items.Clear();
            DataTable dt = CSDL.LayDuLieu(sql);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                    cbMonHoc.Items.Add(dt.Rows[i][0].ToString());
            }
            cbMonHoc.Text = "";
            listMH.Items.Clear();
            lbMaHP.Text = "...";
            lbTenHP.Text = "...";
            lbNhomHP.Text = "...";
            lbHocKy.Text = "...";
            lbNamHoc.Text = "...";
            lbGiangVien.Text = "...";
        }

        private void cbMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string select = "select THOIKHOABIEU.MaMH, MONHOC.TenMH, THOIKHOABIEU.NhomHP, THOIKHOABIEU.Thu, THOIKHOABIEU.TietGiangDay";
            string from = "from THOIKHOABIEU, MONHOC";
            string where = "where THOIKHOABIEU.MaMH = MONHOC.MaMH and MONHOC.TenNganh = N'" + cbNganh.Text + "' and NamHoc = '" + cbNamHoc.Text + "' and HocKy = " + cbHocKy.Text + " and MONHOC.TenMH = N'" + cbMonHoc.Text + "'";
            string sql = select + " " + from + " " + where;
            listMH.Items.Clear();
            DataTable dt = CSDL.LayDuLieu(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int n = listMH.Items.Count;
                listMH.Items.Add(dt.Rows[i][0].ToString());
                listMH.Items[n].SubItems.Add(dt.Rows[i][1].ToString());
                listMH.Items[n].SubItems.Add(dt.Rows[i][2].ToString());
                listMH.Items[n].SubItems.Add(dt.Rows[i][3].ToString());
                listMH.Items[n].SubItems.Add(dt.Rows[i][4].ToString());
            }
        }

        private void listMH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listMH.SelectedItems.Count > 0)
            {
                lbMaHP.Text = listMH.SelectedItems[0].SubItems[0].Text;
                lbTenHP.Text = listMH.SelectedItems[0].SubItems[1].Text;
                lbNhomHP.Text = listMH.SelectedItems[0].SubItems[2].Text;
                lbHocKy.Text = cbHocKy.Text;
                lbNamHoc.Text = cbNamHoc.Text;

                string select = "select GIANGVIEN.HoTen";
                string from = "from THOIKHOABIEU, GIANGVIEN";
                string where = "where THOIKHOABIEU.MaGV = GIANGVIEN. MaGV and MaMH = '"+lbMaHP.Text+"' and NhomHP = '"+lbNhomHP.Text+"' and HocKy = "+lbHocKy.Text+" and NamHoc = '"+lbNamHoc.Text+"'";
                string sql = select + " " + from + " " + where;
                DataTable dt = CSDL.LayDuLieu(sql);
                if(dt.Rows.Count > 0)
                {
                    lbGiangVien.Text = dt.Rows[0][0].ToString();
                }
                else
                {
                    lbGiangVien.Text = "Chưa xác định";
                }
                LoadSinhVienDangKy();
            }
        }
        private void LoadSinhVienDangKy()
        {
            listDS.Items.Clear();
            if (listMH.SelectedItems.Count > 0)
            {
                string sql = "select ROW_NUMBER()over(order by S.MaSV) as STT, D.MaSV, HoTen, MaLop from SINHVIEN S, DANGKYHOCPHAN D " +
                    "where MaMH='" + listMH.SelectedItems[0].SubItems[0].Text + "' and NhomHP='" + listMH.SelectedItems[0].SubItems[2].Text + "' and S.MaSV = D.MaSV";
                DataTable dt = new DataTable();
                dt = CSDL.LayDuLieu(sql);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        listDS.Items.Add(dt.Rows[i][0].ToString());
                        listDS.Items[i].SubItems.Add(dt.Rows[i][1].ToString());
                        listDS.Items[i].SubItems.Add(dt.Rows[i][2].ToString());
                        listDS.Items[i].SubItems.Add(dt.Rows[i][3].ToString());
                    }
                    DemSinhVienDangKy(listDS);
                }
            }
        }
        private void DemSinhVienDangKy(ListView lv)
        {
            int dem = lv.Items.Count;
            lblDemSV.Text = dem.ToString() + " sinh viên";

        }
    }
}
