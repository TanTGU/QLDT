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

namespace Quan_Ly_Dao_Tao.Chuc_Nang.Quan_Ly_Thoi_Khoa_Bieu
{
    public partial class InThoiKhoaBieu_QuanLyThoiKhoaBieu : UserControl
    {
        public InThoiKhoaBieu_QuanLyThoiKhoaBieu()
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

        private void listGD_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
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
                    e.Graphics.DrawString(listGV.Name, new Font(FontFamily.GenericSansSerif, 12), Brushes.Black, e.Bounds.Left, e.Bounds.Top);
                }
            }

        }

        private void listGD_DrawItem(object sender, DrawListViewItemEventArgs e)
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
                    e.Graphics.DrawString(listTKBGD.Name, new Font(FontFamily.GenericSansSerif, 12), Brushes.Black, e.Bounds.Left, e.Bounds.Top);
                }
            }

        }

        private void InThoiKhoaBieu_QuanLyThoiKhoaBieu_Load(object sender, EventArgs e)
        {
            LoadNamHoc();
            LoadHocKy();
            LoadDonVi();
            txtTimMaGV.Focus();
            demGV(listGV);
        }
        // combobox NAMHOC
        private void LoadNamHoc()
        {
            string sql = "select * from NAMHOC";
            DataTable dt = new DataTable();
            dt = CSDL.LayDuLieu(sql);
            if (dt.Rows.Count > 0)
            {
                for(int i=0; i<dt.Rows.Count; i++)
                {
                    cboNamHoc.Items.Add(dt.Rows[i][0].ToString());
                }
            }
        }

        // combobox HOCKY
        private void LoadHocKy()
        {
            for(int i=1; i<=2; i++)
            {
                cboHocKy.Items.Add(i);
            }
        }

        // combobox DONVI
        private void LoadDonVi()
        {
            string sql = "select * from DONVI";
            DataTable dt = new DataTable();
            dt = CSDL.LayDuLieu(sql);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cboDonVi.Items.Add(dt.Rows[i][1].ToString());
                }
            }
        }

        // LoadGiangVien
        private void LoadGiangVien()
        {
            string sql = "select MaGV, HoTen, MaDV from GIANGVIEN";
            DataTable dt = new DataTable();
            dt = CSDL.LayDuLieu(sql);
            if (dt.Rows.Count > 0)
            {
                listGV.Items.Clear();
                for(int i=0; i<dt.Rows.Count; i++)
                {
                    listGV.Items.Add(dt.Rows[i][0].ToString());
                    listGV.Items[i].SubItems.Add(dt.Rows[i][1].ToString());
                    listGV.Items[i].SubItems.Add(dt.Rows[i][2].ToString());
                }
            }
        }
        
        // đếm số giảng viên trong listGV
        private void demGV(ListView lv)
        {
            int count = lv.Items.Count;
            lblDemGV.Text = count.ToString() + " giảng viên";
        }


        private void btnTim_Click(object sender, EventArgs e)
        {
            // tìm theo MaMH
            string sql = "select MaGV, HoTen, MaDV from GIANGVIEN where MaGV='"+txtTimMaGV.Text+"'";
            DataTable dt = new DataTable();
            dt = CSDL.LayDuLieu(sql);
            if (dt.Rows.Count > 0)
            {
                listGV.Items.Clear();
                for(int i=0;i < dt.Rows.Count; i++)
                {
                    listGV.Items.Add(dt.Rows[i][0].ToString());
                    listGV.Items[i].SubItems.Add(dt.Rows[i][1].ToString());
                    listGV.Items[i].SubItems.Add(dt.Rows[i][2].ToString());
                }
            }
            else
            {
                listGV.Items.Clear();
            }
            demGV(listGV);
        }

        private void cboDonVi_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select MaGV, HoTen, D.MaDV from GIANGVIEN G, DONVI D where TenDV=N'"+cboDonVi.SelectedItem.ToString()+"' and G.MaDV = D.MaDV";
            DataTable dt = new DataTable();
            dt = CSDL.LayDuLieu(sql);
            if (dt.Rows.Count > 0)
            {
                listGV.Items.Clear();
                for(int i=0; i<dt.Rows.Count; i++)
                {
                    listGV.Items.Add(dt.Rows[i][0].ToString());
                    listGV.Items[i].SubItems.Add(dt.Rows[i][1].ToString());
                    listGV.Items[i].SubItems.Add(dt.Rows[i][2].ToString());
                }
            }
            else
            {
                listGV.Items.Clear();
            }
            demGV(listGV);
        }
    }
}
