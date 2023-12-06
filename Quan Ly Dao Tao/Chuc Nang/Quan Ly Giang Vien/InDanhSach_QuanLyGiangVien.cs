using Quan_Ly_Dao_Tao.BaoCao.From;
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
    public partial class InDanhSach_QuanLyGiangVien : UserControl
    {
        public InDanhSach_QuanLyGiangVien()
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

        private void InDanhSach_QuanLyGiangVien_Load(object sender, EventArgs e)
        {
            CSDL.KetNoi();
            DataTable dt = new DataTable();
            String sql = @"select * from donvi";
            dt = CSDL.LayDuLieu(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbdonvi.Items.Add(dt.Rows[i][1].ToString());
            }
           
            string sql1 = "select * From GIANGVIEN ";
            DataTable dt1 = new DataTable();
            dt1 = CSDL.LayDuLieu(sql1);
            listDS.Items.Clear();
            int stt = 0;
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                stt++;
                listDS.Items.Add(stt.ToString());
                listDS.Items[i].SubItems.Add(dt1.Rows[i][0].ToString());
                listDS.Items[i].SubItems.Add(dt1.Rows[i][1].ToString());
                listDS.Items[i].SubItems.Add(dt1.Rows[i][3].ToString());
                DateTime date = Convert.ToDateTime(dt1.Rows[i][2].ToString());
                listDS.Items[i].SubItems.Add(date.ToString("dd/MM/yyyy"));

                listDS.Items[i].SubItems.Add(dt1.Rows[i][4].ToString());
                listDS.Items[i].SubItems.Add(dt1.Rows[i][5].ToString());
                listDS.Items[i].SubItems.Add(dt1.Rows[i][8].ToString());
                listDS.Items[i].SubItems.Add(dt1.Rows[i][9].ToString());
            }
            lbSL.Text = stt.ToString() + " giảng viên";
        }

        private void cbdonvi_SelectedIndexChanged(object sender, EventArgs e)
        {

            string dv = cbdonvi.SelectedItem.ToString();
            string sql = "select MaDV,TenDV from DONVI where TenDV= N'" + dv + "'";
            DataTable dt = new DataTable();
            dt = CSDL.LayDuLieu(sql);
            txtMaDV.Text = dt.Rows[0][0].ToString();
            txtTenDV.Text = dt.Rows[0][1].ToString();
            string sql1 = "select * From GIANGVIEN where MaDV= '" + dt.Rows[0][0].ToString() + "'";
            DataTable dt1 = new DataTable();
            dt1 = CSDL.LayDuLieu(sql1);
            listDS.Items.Clear();
            int stt = 0;
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                stt++;
                listDS.Items.Add(stt.ToString());
                listDS.Items[i].SubItems.Add(dt1.Rows[i][0].ToString());
                listDS.Items[i].SubItems.Add(dt1.Rows[i][1].ToString());
                listDS.Items[i].SubItems.Add(dt1.Rows[i][3].ToString());
                DateTime date = Convert.ToDateTime(dt1.Rows[i][2].ToString());
                listDS.Items[i].SubItems.Add(date.ToString("dd/MM/yyyy"));
                
                listDS.Items[i].SubItems.Add(dt1.Rows[i][4].ToString());
                listDS.Items[i].SubItems.Add(dt1.Rows[i][5].ToString());
                listDS.Items[i].SubItems.Add(dt1.Rows[i][8].ToString());
                listDS.Items[i].SubItems.Add(dt1.Rows[i][9].ToString());
            }
            lbSL.Text = stt.ToString() + " giảng viên";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(txtMaDV.Text == "")
            {
                MessageBox.Show("Vui lòng chọn đơn vị cần xuất danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                InDanhSachGiangVien f = new InDanhSachGiangVien(txtMaDV.Text);
                f.ShowDialog();
            }
        }
    }
}
