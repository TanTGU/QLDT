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
            LoadGiangVien();
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
            // tìm theo MaGV
            string maGV = txtMaGV.Text;
            string sql = "select T.MaGV, HoTen, D.MaDV, TenDV, NamHoc, HocKy from GIANGVIEN G,DONVI D, THOIKHOABIEU T " +
                "where T.MaGV='" + maGV + "' and T.MaGV=G.MaGV and D.MaDV=G.MaDV";
            DataTable dt = new DataTable();
            dt = CSDL.LayDuLieu(sql);
            if (dt.Rows.Count > 0)
            {
                // add Thông tin giảng viên
                // add listGV
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
                MessageBox.Show("Không có giảng viên cần tìm. Vui lòng nhập lại!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                txtTimMaGV.Focus();
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

        private void listGV_Click(object sender, EventArgs e)
        {
            // 1. Thông tin giảng viên
            string maGV = listGV.SelectedItems[0].SubItems[0].Text;
            string maDV = listGV.SelectedItems[0].SubItems[2].Text;
            //string sqlGV = "select distinct G.MaGV, HoTen, D.MaDV, TenDV from GIANGVIEN G, DONVI D where G.MaGV='"+maGV+"' and D.MaDV='"+maDV+"' and G.MaDV = D.MaDV";
            string sqlGV = "select distinct G.MaGV, HoTen, D.MaDV, TenDV, NamHoc, HocKy from GIANGVIEN G, DONVI D, THOIKHOABIEU T where G.MaGV='" + maGV + "' and D.MaDV='" + maDV + "' and G.MaDV = D.MaDV and T.MaGV = G.MaGV";
            DataTable dtGV = new DataTable();
            dtGV = CSDL.LayDuLieu(sqlGV);
            if (dtGV.Rows.Count > 0)
            {
                txtMaGV.Text = dtGV.Rows[0][0].ToString();
                txtTenGV.Text = dtGV.Rows[0][1].ToString();
                txtMaDV.Text = dtGV.Rows[0][2].ToString();
                txtTenDV.Text = dtGV.Rows[0][3].ToString();                
                txtNamHoc.Text = dtGV.Rows[0][4].ToString();
                txtHocKy.Text = dtGV.Rows[0][5].ToString();
                // chưa xử lí được GV không tồn tại trong thời khóa biểu
            }
            else
            {
                txtMaGV.Text = "";
                txtTenGV.Text = "";
                txtMaDV.Text = "";
                txtTenDV.Text = "";
                txtNamHoc.Text = "";
                txtHocKy.Text = "";
            }
            // 2. Thời khóa biểu giảng dạy
            string sqlGD = "select ROW_NUMBER()over(order by MaGV) as STT, T.MaMH, TenMH, NhomHP, Thu, TietGiangDay from THOIKHOABIEU T, MONHOC M where T.MaGV='"+maGV+"' and T.MaMH = M.MaMH";
            DataTable dtGD = new DataTable();
            dtGD = CSDL.LayDuLieu(sqlGD);
            if(dtGD.Rows.Count > 0)
            {
                listTKBGD.Items.Clear();
                for(int i=0; i<dtGD.Rows.Count; i++)
                {
                    listTKBGD.Items.Add(dtGD.Rows[i][0].ToString());
                    listTKBGD.Items[i].SubItems.Add(dtGD.Rows[i][1].ToString());
                    listTKBGD.Items[i].SubItems.Add(dtGD.Rows[i][2].ToString());
                    listTKBGD.Items[i].SubItems.Add(dtGD.Rows[i][3].ToString());
                    listTKBGD.Items[i].SubItems.Add(dtGD.Rows[i][4].ToString());
                    listTKBGD.Items[i].SubItems.Add(dtGD.Rows[i][5].ToString());
                }
            }
            else
            {
                listTKBGD.Items.Clear();
            }
        }

        private void txtTimMaGV_MouseDown(object sender, MouseEventArgs e)
        {
            txtTimMaGV.Text = "";
            txtTimMaGV.ForeColor = Color.Black;
        }

        private void listGV_KeyDown(object sender, KeyEventArgs e)
        {
            // thực hiên ngay sau khi nhấn, người dùng tương tác với phím
            //string magv = listGV.SelectedItems[0].SubItems[0].Text;
            //string sql = "select T.MaGV, HoTen, D.MaDV, TenDV, NamHoc, HocKy from GIANGVIEN G,DONVI D, THOIKHOABIEU T " +
            //    "where T.MaGV='" + magv + "' and T.MaGV=G.MaGV and D.MaDV=G.MaDV";
            //DataTable dt = new DataTable();
            //dt = CSDL.LayDuLieu(sql);
            //if (dt.Rows.Count > 0)
            //{
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        txtMaGV.Text = dt.Rows[i][0].ToString();
            //        txtTenGV.Text = dt.Rows[i][1].ToString();
            //        txtMaDV.Text = dt.Rows[i][2].ToString();
            //        txtTenDV.Text = dt.Rows[i][3].ToString();
            //        txtNamHoc.Text = dt.Rows[i][4].ToString();
            //        txtHocKy.Text = dt.Rows[i][5].ToString();
            //    }
            //}
            //else
            //{
            //    txtMaGV.Text = "";
            //    txtTenGV.Text = "";
            //    txtMaDV.Text = "";
            //    txtTenGV.Text = "";
            //    txtNamHoc.Text = "";
            //    txtHocKy.Text = "";
            //}
        }

        private void listGV_KeyUp(object sender, KeyEventArgs e)
        {
            // thực hiện ngay lâp tức, người dùng tương tác với phím
            // NOTE: lỗi tên đơn vị
            string maGV = listGV.SelectedItems[0].SubItems[0].Text;
            string sql = "select T.MaGV, HoTen, D.MaDV, TenDV, NamHoc, HocKy from GIANGVIEN G,DONVI D, THOIKHOABIEU T " +
                "where T.MaGV='" + maGV + "' and T.MaGV=G.MaGV and D.MaDV=G.MaDV";
            DataTable dt = new DataTable();
            dt = CSDL.LayDuLieu(sql);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    txtMaGV.Text = dt.Rows[i][0].ToString();
                    txtTenGV.Text = dt.Rows[i][1].ToString();
                    txtMaDV.Text = dt.Rows[i][2].ToString();
                    txtTenDV.Text = dt.Rows[i][3].ToString();
                    txtNamHoc.Text = dt.Rows[i][4].ToString();
                    txtHocKy.Text = dt.Rows[i][5].ToString();
                }
            }
            else
            {
                txtMaGV.Text = "";
                txtTenGV.Text = "";
                txtMaDV.Text = "";
                txtTenGV.Text = "";
                txtNamHoc.Text = "";
                txtHocKy.Text = "";
            }
            string sqlGD = "select ROW_NUMBER()over(order by MaGV) as STT, T.MaMH, TenMH, NhomHP, Thu, TietGiangDay from THOIKHOABIEU T, MONHOC M where T.MaGV='" + maGV + "' and T.MaMH = M.MaMH";
            DataTable dtGD = new DataTable();
            dtGD = CSDL.LayDuLieu(sqlGD);
            if (dtGD.Rows.Count > 0)
            {
                listTKBGD.Items.Clear();
                for (int i = 0; i < dtGD.Rows.Count; i++)
                {
                    listTKBGD.Items.Add(dtGD.Rows[i][0].ToString());
                    listTKBGD.Items[i].SubItems.Add(dtGD.Rows[i][1].ToString());
                    listTKBGD.Items[i].SubItems.Add(dtGD.Rows[i][2].ToString());
                    listTKBGD.Items[i].SubItems.Add(dtGD.Rows[i][3].ToString());
                    listTKBGD.Items[i].SubItems.Add(dtGD.Rows[i][4].ToString());
                    listTKBGD.Items[i].SubItems.Add(dtGD.Rows[i][5].ToString());
                }
            }
            else
            {
                listTKBGD.Items.Clear();
            }
        }
    }
}
