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

namespace Quan_Ly_Dao_Tao.Chuc_Nang.Quan_Ly_Hoc_Phi
{
    public partial class ThietLapMucHocPhi_QuanLyHocPhi : UserControl
    {
        public ThietLapMucHocPhi_QuanLyHocPhi()
        {
            InitializeComponent();
        }

        void LayDSDonVi()
        {
            string sql = "select * from DONVI";
            DataTable dt = CSDL.LayDuLieu(sql);
            cbDonVi.Items.Clear();
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                cbDonVi.Items.Add(dt.Rows[i][1].ToString());
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

        private void listDS_DrawColumnHeader_1(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            // Tô màu nền
            e.Graphics.FillRectangle(Brushes.RoyalBlue, e.Bounds);
            // vẽ lại dòng tiêu đề với font in đậm và màu trắng
            e.Graphics.DrawString(e.Header.Text, new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold), Brushes.White, e.Bounds);

        }

        private void listDS_DrawItem_1(object sender, DrawListViewItemEventArgs e)
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

        private void ThietLapMucHocPhi_QuanLyHocPhi_Load(object sender, EventArgs e)
        {
            LayDSDonVi();
        }

        private void cbDonVi_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select NGANH.MaNganh, NGANH.TenNganh, HOCPHI.SoTien from DONVI, NGANH, HOCPHI where DONVI.MaDV = NGANH.MaDV and HOCPHI.MaNganh = NGANH.MaNganh and DONVI.TenDV = N'"+cbDonVi.Text+"'";
            DataTable dt = CSDL.LayDuLieu(sql);
            listDS.Items.Clear();
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                listDS.Items.Add(dt.Rows[i][0].ToString());
                listDS.Items[i].SubItems.Add(dt.Rows[i][1].ToString());
                listDS.Items[i].SubItems.Add(dt.Rows[i][2].ToString());
            }
        }

        private void listDS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listDS.SelectedItems.Count > 0)
            {
                tbMaNganh.Text = listDS.SelectedItems[0].SubItems[0].Text;
                tbTenNganh.Text = listDS.SelectedItems[0].SubItems[1].Text;
                tbMucHocPhi.Text = listDS.SelectedItems[0].SubItems[2].Text;
                tbDonVi.Text = cbDonVi.Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "select NGANH.MaNganh, NGANH.TenNganh, HOCPHI.SoTien, DONVI.TenDV from DONVI, NGANH, HOCPHI where DONVI.MaDV = NGANH.MaDV and HOCPHI.MaNganh = NGANH.MaNganh and NGANH.MaNganh = N'"+tbTK.Text+"'";
            DataTable dt = CSDL.LayDuLieu(sql);
            listDS.Items.Clear();
            listDS.Items.Add(dt.Rows[0][0].ToString());
            listDS.Items[0].SubItems.Add(dt.Rows[0][1].ToString());
            listDS.Items[0].SubItems.Add(dt.Rows[0][2].ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
