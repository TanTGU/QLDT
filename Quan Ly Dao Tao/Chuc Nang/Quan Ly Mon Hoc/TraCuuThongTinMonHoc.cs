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

namespace Quan_Ly_Dao_Tao.Chuc_Nang.Quan_Ly_Mon_Hoc
{
    public partial class TraCuuThongTinMonHoc : UserControl
    {
        public TraCuuThongTinMonHoc()
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

        private void cbdonvi_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dv = cbdonvi.SelectedItem.ToString();
            string sql = "select MaDV from DONVI where TenDV= N'" + dv + "'";
            DataTable dt = new DataTable();
            dt = CSDL.LayDuLieu(sql);
            DataTable dt1 = new DataTable();
            String sql1 = @"select * from NGANH where MaDV='" + dt.Rows[0][0].ToString() + "'";
            dt1 = CSDL.LayDuLieu(sql1);
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                cbnganhhoc.Items.Clear();
                cbnganhhoc.Items.Add(dt1.Rows[i][1].ToString());
                cbnganhhoc1.Items.Add(dt1.Rows[i][1].ToString());
            }
        }

        private void TraCuuThongTinMonHoc_Load(object sender, EventArgs e)
        {
            CSDL.KetNoi();
            DataTable dt = new DataTable();
            String sql = @"select * from donvi";
            dt = CSDL.LayDuLieu(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbdonvi.Items.Add(dt.Rows[i][1].ToString());
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ma = txtMH.Text;
            string sql = "select * from MONHOC where MaMH='" + ma + "'";
            DataTable dt = new DataTable();
            dt = CSDL.LayDuLieu(sql);
            listDS.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listDS.Items.Add(dt.Rows[i][0].ToString());
                listDS.Items[i].SubItems.Add(dt.Rows[i][1].ToString());
            }
        }

        private void cbnganhhoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dv = cbnganhhoc.SelectedItem.ToString();
            string sql = "select MaMH,TenMH from MONHOC where TenNganh = N'" + dv + "'";
            DataTable dt = new DataTable();
            dt = CSDL.LayDuLieu(sql);
            listDS.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listDS.Items.Add(dt.Rows[i][0].ToString());
                listDS.Items[i].SubItems.Add(dt.Rows[i][1].ToString());
            }
        }

        private void listDS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listDS.SelectedItems.Count != 0)
            {
                string txt = listDS.SelectedItems[0].SubItems[0].Text;

                string sql = "select * from MONHOC where MaMH='" + txt + "'";
                DataTable dt = new DataTable();
                dt = CSDL.LayDuLieu(sql);
                txtMaHP.Text = dt.Rows[0][0].ToString();
                txttenMH.Text = dt.Rows[0][1].ToString();
                nTinChi.Text = dt.Rows[0][2].ToString();
                nLythuyet.Text = dt.Rows[0][3].ToString();
                nthucHanh.Text = dt.Rows[0][4].ToString();
                cbnganhhoc1.Text = dt.Rows[0][6].ToString();
                string TQ = dt.Rows[0][5].ToString();
                if (TQ == null)
                {
                    txtMaTQ.Text = "null";
                    txttenTQ.Text = "null";
                }
                else
                {
                    string sql1 = "select MaMH,TenMH from MONHOC where MaMH = N'" + TQ + "'";
                    DataTable dt1 = new DataTable();
                    dt1 = CSDL.LayDuLieu(sql1);
                    for (int j = 0; j < dt1.Rows.Count; j++)
                    {
                        txtMaTQ.Text = dt1.Rows[0][0].ToString();
                        txttenTQ.Text = dt1.Rows[0][1].ToString();
                    }
                }
            }
        }
    }
}
