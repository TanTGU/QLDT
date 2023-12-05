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

        private void listLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cbNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
