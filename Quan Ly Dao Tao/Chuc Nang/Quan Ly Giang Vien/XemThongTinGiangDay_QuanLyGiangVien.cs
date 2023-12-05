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
    public partial class XemThongTinGiangDay_QuanLyGiangVien : UserControl
    {
        public XemThongTinGiangDay_QuanLyGiangVien()
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
                    e.Graphics.DrawString(listGD.Name, new Font(FontFamily.GenericSansSerif, 12), Brushes.Black, e.Bounds.Left, e.Bounds.Top);
                }
            }

        }

        private void cboDonVi_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select MaGV, HoTen, D.MaDV from GIANGVIEN G, DONVI D where TenDV=N'" + cboDonVi.SelectedItem.ToString() + "' and G.MaDV = D.MaDV";
            DataTable dt = new DataTable();
            dt = CSDL.LayDuLieu(sql);
            if (dt.Rows.Count > 0)
            {
                listGV.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
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

        private void listGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listGV.SelectedItems.Count > 0)
            {
                // 1. Thông tin giảng viên
                string sqlGV = "select MaGV, HoTen,D.MaDV, TenDV from GIANGVIEN G, DONVI D where MaGV=N'" + listGV.SelectedItems[0].SubItems[0].Text + "' and G.MaDV = D.MaDV";
                DataTable dtGV = new DataTable();
                dtGV = CSDL.LayDuLieu(sqlGV);
                if (dtGV.Rows.Count > 0)
                {
                    txtMaGV.Text = dtGV.Rows[0][0].ToString();
                    txtTenGV.Text = dtGV.Rows[0][1].ToString();
                    txtDonVi.Text = dtGV.Rows[0][2].ToString();
                }
                // 2. Thông tin môn học
                string sqlMH = "select ROW_NUMBER()over(order by NhomHP) as STT, M.MaMH, TenMH from MONHOC M, GIANGVIEN G, THOIKHOABIEU T where T.MaGV = G.MaGV and M.MaMH = T.MaMH and T.MaGV='" + listGV.SelectedItems[0].SubItems[0].Text + "'";
                DataTable dtMH = new DataTable();
                dtMH = CSDL.LayDuLieu(sqlMH);
                if (dtMH.Rows.Count > 0)
                {
                    listGD.Items.Clear();
                    for (int i = 0; i < dtMH.Rows.Count; i++)
                    {
                        listGD.Items.Add(dtMH.Rows[i][0].ToString());
                        listGD.Items[i].SubItems.Add(dtMH.Rows[i][1].ToString());
                        listGD.Items[i].SubItems.Add(dtMH.Rows[i][2].ToString());
                    }
                }
                demGV(listGV);
                demMH(listGD);

            }
        }

        private void listGD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listGD.SelectedItems.Count > 0)
            {
                string sql = "select MaMH, TenMH from MONHOC where MaMH='" + listGD.SelectedItems[0].SubItems[1].Text + "'";
                DataTable dt = new DataTable();
                dt = CSDL.LayDuLieu(sql);
                if (dt.Rows.Count > 0)
                {
                    txtMaMH.Text = dt.Rows[0][0].ToString();
                    txtTenMH.Text = dt.Rows[0][1].ToString();

                }
            }
        }

        private void XemThongTinGiangDay_QuanLyGiangVien_Load(object sender, EventArgs e)
        {
            LoadDonVi();
            LoadGiangVien();
            demGV(listGV);
        }
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
        private void LoadGiangVien()
        {
            string sql = "select MaGV, HoTen, MaDV from GIANGVIEN";
            DataTable dt = new DataTable();
            dt = CSDL.LayDuLieu(sql);
            if (dt.Rows.Count > 0)
            {
                listGV.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    listGV.Items.Add(dt.Rows[i][0].ToString());
                    listGV.Items[i].SubItems.Add(dt.Rows[i][1].ToString());
                    listGV.Items[i].SubItems.Add(dt.Rows[i][2].ToString());
                }
            }
        }
        private void demGV(ListView lv)
        {
            int count = lv.Items.Count;
            lblDemGV.Text = count.ToString() + " giảng viên";
        }
        private void demMH(ListView lv)
        {
            int count = lv.Items.Count;
            lblDemMH.Text = count.ToString() + " môn học";
        }

        private void button4_Click(object sender, EventArgs e)//tim theo ma giang vien
        {
            string sql = "select MaGV, HoTen, MaDV from GIANGVIEN where MaGV ='"+txtTimMaGV.Text+"'";
            DataTable dt = new DataTable();
            dt = CSDL.LayDuLieu(sql);
            if (dt.Rows.Count > 0)
            {
                listGV.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    listGV.Items.Add(dt.Rows[i][0].ToString());
                    listGV.Items[i].SubItems.Add(dt.Rows[i][1].ToString());
                    listGV.Items[i].SubItems.Add(dt.Rows[i][2].ToString());
                }
            }
        }
    }
}
