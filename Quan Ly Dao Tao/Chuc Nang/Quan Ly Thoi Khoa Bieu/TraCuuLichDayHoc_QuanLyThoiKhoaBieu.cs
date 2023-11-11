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
            LoadDonVi();
            LoadKhoiTao();
        }
        private void LoadKhoiTao()
        {
            // học kì
            cboHocKy.Items.Add("1");
            cboHocKy.Items.Add("2");

            // thứ
            cboThu.Items.Add("2");
            cboThu.Items.Add("3");
            cboThu.Items.Add("4");
            cboThu.Items.Add("5");
            cboThu.Items.Add("6");
            cboThu.Items.Add("7");
        }
        public void LoadDonVi()
        {
            string sql = "select * from DONVI";
            DataTable dt = new DataTable();
            dt = CSDL.LayDuLieu(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cboDonVi.Items.Add(dt.Rows[i][1].ToString());
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (txtTimMaMH.Text == "")
            {
                MessageBox.Show("Vui lòng nhập vào mã môn học!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string sql = "select MH.MaMH, MH.TenMH from MONHOC MH join NGANH N on MH.TenNganh = N.TenNganh join DONVI DV on N.MaDV = DV.MaDV where MH.MaMH = '" + txtTimMaMH.Text + "'";
            DataTable dt = new DataTable();
            dt = CSDL.LayDuLieu(sql);
            if (dt.Rows.Count > 0)
            {
                listMH.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
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
            }
            else
            {
                MessageBox.Show("Không tìm thấy môn học cần tìm. Vui lòng thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void listMH_Click(object sender, EventArgs e)
        {
            txtMaMH.Text = listMH.SelectedItems[0].SubItems[0].Text;
            DataTable dt = new DataTable();
            string sql = "select TenMH, NamHoc, SoTC, HocKy, NhomHP, Thu, THOIKHOABIEU.MaGV,TietGiangDay,HoTen from THOIKHOABIEU inner join MONHOC on THOIKHOABIEU.MaMH = MONHOC.MaMH inner join GIANGVIEN on THOIKHOABIEU.MaGV = GIANGVIEN.MaGV where MONHOC.MaMH='" + txtMaMH.Text + "' ";
            dt = CSDL.LayDuLieu(sql);
            // theo như sql là có tới 2 dòng nhưng khác nhóm HP
            if (dt.Rows.Count > 0)
            {
                txtTenMH.Text = dt.Rows[0][0].ToString();
                txtNamHoc.Text = dt.Rows[0][1].ToString();
                txtSoTC.Text = dt.Rows[0][2].ToString();
                cboHocKy.Text = dt.Rows[0][3].ToString();
                cboHocKy.Text = dt.Rows[0][4].ToString();
                cboThu.Text = dt.Rows[0][5].ToString();
                txtMaGV.Text = dt.Rows[0][6].ToString();
                txtTiet.Text = dt.Rows[0][7].ToString();
                txtTenGV.Text = dt.Rows[0][8].ToString();
            }
            else
            {
                txtMaMH.Text = listMH.SelectedItems[0].Text;
                txtTenMH.Text = listMH.SelectedItems[0].SubItems[1].Text;
                txtSoTC.Text = "";
                cboHocKy.Text = "";
                cboHocKy.Text = "";
                cboThu.Text = "";
                txtMaGV.Text = "";
                txtTiet.Text = "";
                txtTenGV.Text = "";
            }
        }

        private void cboDonVi_SelectedIndexChanged(object sender, EventArgs e)
        {
            listMH.Items.Clear();
            if (cboDonVi.SelectedIndex != -1)
            {
                string sql = "select MH.MaMH, MH.TenMH from MONHOC MH join NGANH N on MH.TenNganh = N.TenNganh join DONVI DV on N.MaDV = DV.MaDV where DV.TenDV = N'" + cboDonVi.SelectedItem.ToString() + "'";
                DataTable dt = new DataTable();
                dt = CSDL.LayDuLieu(sql);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    listMH.Items.Add(dt.Rows[i][0].ToString());
                    listMH.Items[i].SubItems.Add(dt.Rows[i][1].ToString());
                }
            }
        }
    }
}
