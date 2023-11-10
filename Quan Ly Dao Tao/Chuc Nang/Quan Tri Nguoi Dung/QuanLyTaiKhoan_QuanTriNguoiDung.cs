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
            LayDSTaiKhoan();
        }

        private void cbPhanLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select TAIKHOAN.TK, LOAITAIKHOAN.TenLoai from TAIKHOAN, LOAITAIKHOAN where TAIKHOAN.LoaiTK = LOAITAIKHOAN.MaLoai and LOAITAIKHOAN.TenLoai = N'"+cbPhanLoai.Text+"'";
            DataTable dt = CSDL.LayDuLieu(sql);
            listDS.Items.Clear();
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                listDS.Items.Add(dt.Rows[i][0].ToString());
                listDS.Items[i].SubItems.Add(dt.Rows[i][1].ToString());
            }    
        }

        private void listDS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listDS.SelectedItems.Count == 0)
            {
                //string sql = "select TAIKHOAN.MaGV, TAIKHOAN.TenHienThi from TAIKHOAN, LOAITAIKHOAN where TAIKHOAN.LoaiTK = LOAITAIKHOAN.MaLoai and TK = '" + listDS.SelectedItems[0].SubItems[0].Text +"'";
                //DataTable dt = CSDL.LayDuLieu(sql);
                //if(dt.Rows.Count > 0)
                //{
                //    if (dt.Rows[0][0].ToString() == null)
                //    {
                //        tbMaGV.Text = "";m
                //    }
                //    tbHoTen.Text = dt.Rows[0][1].ToString();
                //    tbTK.Text = listDS.SelectedItems[0].SubItems[0].Text;
                //    tbLoaiTK.Text = cbPhanLoai.Text;
                //}
            }
        }
    }
}
