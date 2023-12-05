﻿using Quan_Ly_Dao_Tao.Database;
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
    public partial class DangKyHocPhan_QuanLyDangKyHocPhan : UserControl
    {
        public DangKyHocPhan_QuanLyDangKyHocPhan()
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

        private void listDK_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
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

        private void listDK_DrawItem(object sender, DrawListViewItemEventArgs e)
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
                    e.Graphics.DrawString(listDK.Name, new Font(FontFamily.GenericSansSerif, 12), Brushes.Black, e.Bounds.Left, e.Bounds.Top);
                }
            }

        }

        private void DangKyHocPhan_QuanLyDangKyHocPhan_Load(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cbMonHoc.Text == "")
            {
                MessageBox.Show("Vui lòng chọn năm học cần tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if (cbHocKy.Text == "")
            {
                MessageBox.Show("Vui lòng chọn học kỳ cần tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if (tbTimKiem.Text == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            lbMaSV.Text = "";
            lbLop.Text = "";
            lbHoTen.Text = "";
            lbNganh.Text = "";
            string sql = @"select SINHVIEN.MaSV, HoTen, TenLop, TenNganh from SINHVIEN, LOP, NGANH where LOP.MaLop = SINHVIEN.MaLop and SINHVIEN.MaNganh = NGANH.MaNganh and SINHVIEN.MaSV='" + tbTimKiem.Text + "'";
            DataTable dt = new DataTable();
            dt = CSDL.LayDuLieu(sql);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy thông tin sinh viên phù hợp! Vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                lbMaSV.Text = dt.Rows[0][0].ToString();
                lbLop.Text = dt.Rows[0][2].ToString();
                lbHoTen.Text = dt.Rows[0][1].ToString();
                lbNganh.Text = dt.Rows[0][3].ToString();
            }
        }

        private void cbNganh_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select distinct MONHOC.TenMH from THOIKHOABIEU, MONHOC where THOIKHOABIEU.MaMH = MONHOC.MaMH and MONHOC.TenNganh = N'"+cbNganh.Text+"' and NamHoc = '"+cbNamHoc.Text+"' and HocKy = " + cbHocKy.Text;
            cbMonHoc.Items.Clear();
            DataTable dt = CSDL.LayDuLieu(sql);
            if(dt.Rows.Count > 0)
            {
                for(int i = 0; i < dt.Rows.Count; i++)
                    cbMonHoc.Items.Add(dt.Rows[i][0].ToString());
            }
        }

        private void cbMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string select = "select THOIKHOABIEU.MaMH, MONHOC.TenMH, THOIKHOABIEU.NhomHP, THOIKHOABIEU.Thu, THOIKHOABIEU.TietGiangDay";
            string from = "from THOIKHOABIEU, MONHOC";
            string where = "where THOIKHOABIEU.MaMH = MONHOC.MaMH and MONHOC.TenNganh = N'"+cbNganh.Text+"' and NamHoc = '"+cbNamHoc.Text+"' and HocKy = "+cbHocKy.Text+" and MONHOC.TenMH = N'"+cbMonHoc.Text+"'";
            string sql = select + " " + from + " " + where;
            listMH.Items.Clear();
            DataTable dt = CSDL.LayDuLieu(sql);
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                int n = listMH.Items.Count;
                listMH.Items.Add(dt.Rows[i][0].ToString());
                listMH.Items[n].SubItems.Add(dt.Rows[i][1].ToString());
                listMH.Items[n].SubItems.Add(dt.Rows[i][2].ToString());
                listMH.Items[n].SubItems.Add(dt.Rows[i][3].ToString());
                listMH.Items[n].SubItems.Add(dt.Rows[i][4].ToString());
            }
        }
    }
}
