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
    public partial class TraCuuLichDayHoc_QuanLyThoiKhoaBieu : UserControl
    {
        public TraCuuLichDayHoc_QuanLyThoiKhoaBieu()
        {
            InitializeComponent();
        }

        private void listMH_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            // Tô màu nền
            e.Graphics.FillRectangle(Brushes.RoyalBlue, e.Bounds);
            // vẽ lại dòng tiêu đề với font in đậm và màu trắng
            e.Graphics.DrawString(e.Header.Text, new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold), Brushes.White, e.Bounds);

        }

        private void listHP_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
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

        private void listHP_DrawItem(object sender, DrawListViewItemEventArgs e)
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
                    e.Graphics.DrawString(listHP.Name, new Font(FontFamily.GenericSansSerif, 12), Brushes.Black, e.Bounds.Left, e.Bounds.Top);
                }
            }
        }

        private void TraCuuLichDayHoc_QuanLyThoiKhoaBieu_Load(object sender, EventArgs e)
        {
            CSDL.KetNoi();
            string sql = "select * from DONVI";
            LoadComboBox(sql);
        }
        void LoadComboBox(string sql)
        {
            DataTable dt = new DataTable();
            dt = CSDL.LayDuLieu(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cboDonVi.Items.Add(dt.Rows[i][0].ToString());
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (cboDonVi.SelectedIndex != -1 && !string.IsNullOrEmpty(txtTimMaMH.Text))
            {
                string sql = "select MaMH, TenMH from MONHOC, NGANH where MaDV='" + cboDonVi.SelectedItem.ToString() + "' and MaMH='" + txtTimMaMH.Text + "' and MONHOC.TenNganh = NGANH.TenNganh";
                DataTable dt = new DataTable();
                dt = CSDL.LayDuLieu(sql);
                int dem = dt.Rows.Count;
                if (dem > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        string maMH = row["MaMH"].ToString();
                        string tenMH = row["TenMH"].ToString();

                        if (!IsMonHocDaTonTai(maMH))
                        {
                            ListViewItem listItem = new ListViewItem(maMH);
                            listItem.SubItems.Add(tenMH);
                            listMH.Items.Add(listItem);
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Không có môn học cần tìm",
                                    "Thông báo",
                                     MessageBoxButtons.OKCancel,
                                     MessageBoxIcon.Information);
                }


            }
            else
            {
                MessageBox.Show("Dữ liệu không được để trống. Vui lòng nhập lại!",
                                "Thông báo",
                                MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Error);
            }
        }

        // hàm kiểm tra môn học có tồn tại trong listMH chưa
        private bool IsMonHocDaTonTai(string maMH)
        {
            foreach (ListViewItem item in listMH.Items)
            {
                if (item.Text == maMH)
                {
                    return true; // Môn học đã tồn tại trong ListView
                }
            }
            return false; // Môn học chưa tồn tại trong ListView
        }

    }
}
