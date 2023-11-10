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
using Quan_Ly_Dao_Tao.Database;

namespace Quan_Ly_Dao_Tao.Chuc_Nang.Quan_Ly_Hoc_Phi
{
    public partial class NopHocPhi_QuanLyHocPhi : UserControl
    {
        public NopHocPhi_QuanLyHocPhi()
        {
            InitializeComponent();
        }
        void LayDSDonVi()
        {
            string sql = "select * from DONVI";
            DataTable dt = CSDL.LayDuLieu(sql);
            cbdonvi.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbdonvi.Items.Add(dt.Rows[i][1].ToString());
            }


        }

        void LayDSLop()
        {
            string sql = "select * from LOP";
            DataTable dt = CSDL.LayDuLieu(sql);
            cblop.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cblop.Items.Add(dt.Rows[i][1].ToString());
            }


        }

        void LayDSHocKy()
        {
            string sql = "select THOIKHOABIEU.HocKy from THOIKHOABIEU";
            DataTable dt = CSDL.LayDuLieu(sql);
            cbHK.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbHK.Items.Add(dt.Rows[i][0].ToString());
            }


        }

        void LayDSNamhoc()
        {
            string sql = "select * from NAMHOC";
            DataTable dt = CSDL.LayDuLieu(sql);
            cbnamhoc.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbnamhoc.Items.Add(dt.Rows[i][0].ToString());
            }


        }
        private void listDS_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            // Tô màu nền
            e.Graphics.FillRectangle(Brushes.RoyalBlue, e.Bounds);
            // vẽ lại dòng tiêu đề với font in đậm và màu trắng
            e.Graphics.DrawString(e.Header.Text, new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold), Brushes.White, e.Bounds);

        }

        private void listMH_ControlRemoved(object sender, ControlEventArgs e)
        {

        }

        private void listMH_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
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

        private void NopHocPhi_QuanLyHocPhi_Load(object sender, EventArgs e)
        {
            LayDSDonVi();
            LayDSLop();
            LayDSHocKy();
            LayDSNamhoc();
        }

        private void btntim_Click(object sender, EventArgs e)
        {
            string sql = "";
            DataTable dt = CSDL.LayDuLieu(sql);
            listDS.Items.Clear();

        }
    }
}
