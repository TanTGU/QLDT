using Quan_Ly_Dao_Tao.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Quan_Ly_Dao_Tao.Chuc_Nang.Quan_Ly_Thoi_Khoa_Bieu
{
    public partial class LapLichDayHoc_QuanLyThoiKhoaBieu : UserControl
    {
        public LapLichDayHoc_QuanLyThoiKhoaBieu()
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
        private void LapLichDayHoc_QuanLyThoiKhoaBieu_Load(object sender, EventArgs e)
        {
            LoadDonVi();
            addHocKy();
            addThu();
        }        

        private void btnTim_Click(object sender, EventArgs e)
        {     
            if (cboDonVi.SelectedIndex != -1 && !string.IsNullOrEmpty(txtTimMaMH.Text))
            {                
                string sql = "select MaMH, TenMH from MONHOC, NGANH where MaDV='"+cboDonVi.SelectedItem.ToString()+"' and MaMH='"+txtTimMaMH.Text+"' and MONHOC.TenNganh = NGANH.TenNganh";
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

        
        private void addHocKy()
        {
            cboHocKy.Items.Add("1");
            cboHocKy.Items.Add("2");
        }
        private void addThu()
        {
            cboThu.Items.Add("2");
            cboThu.Items.Add("3");
            cboThu.Items.Add("4");
            cboThu.Items.Add("5");
            cboThu.Items.Add("6");
            cboThu.Items.Add("7");
        }
        public void LoadDonVi()
        {
            string sql = "select MaDV from DONVI";
            DataTable dt = new DataTable();
            dt = CSDL.LayDuLieu(sql);
            for(int i=0; i<dt.Rows.Count; i++)
            {
                cboDonVi.Items.Add(dt.Rows[i][0].ToString());
            }
        }

        private void listMH_Click(object sender, EventArgs e)
        {
            txtMaMH.Text = listMH.SelectedItems[0].SubItems[0].Text;
            txtTenMH.Text = listMH.SelectedItems[0].SubItems[1].Text;            
            DataTable dt = new DataTable();
            dt = CSDL.LayDuLieu("select SoTC from MONHOC where MaMH ='"+ listMH.SelectedItems[0].SubItems[0].Text + "'");
            txtSoTC.Text = dt.Rows[0][0].ToString();

            // txt tiết
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {            
            //string query = "INSERT INTO MONHOC (MaMH, TenMH, NhomHP) VALUES (@MaMH, @TenMH, @NhomHP)";
            //CSDL.XuLy(query); 
            //command.Parameters.AddWithValue("@MaMH", txtMaMH.Text);
            //command.Parameters.AddWithValue("@TenMH", txtTenMH.Text);
            //command.Parameters.AddWithValue("@NhomHP", txtNhom.Text);

            //command.ExecuteNonQuery(); // Thực hiện thêm dữ liệu

            //// Cập nhật ListView
            //ListViewItem item = new ListViewItem(txtMaMH.Text);
            //item.SubItems.Add(txtTenMH.Text);
            //item.SubItems.Add(txtNhom.Text);
            //listHP.Items.Add(item);

        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }
        private void cboDonVi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
