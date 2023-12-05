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
    public partial class QuanLyGiangDay_QuanLyGiangVien : UserControl
    {
        public QuanLyGiangDay_QuanLyGiangVien()
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

        private void listMH_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
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

        private void QuanLyGiangDay_QuanLyGiangVien_Load(object sender, EventArgs e)
        {

            LoadDonVi();
            LoadGiangVien();
            LoadMonHOc();
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

        private void LoadMonHOc()
        {
            string sql = "select MaMH,TenMH from MONHOC";
            DataTable dt = new DataTable();
            dt = CSDL.LayDuLieu(sql);
            if (dt.Rows.Count > 0)
            {
                listGV.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    listMH.Items.Add(dt.Rows[i][0].ToString());
                    listMH.Items[i].SubItems.Add(dt.Rows[i][1].ToString());
                   
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
        }

        void LayDSGiangDay()
        {
            listGD.Items.Clear();
            string sql = "select M.MaMH ,M.TenMH from CHUYENMON C, MONHOC M,GIANGVIEN G where C.MaGV = G.MaGV and C.MaMH=M.MaMH and C.MaGV ='" + listGV.SelectedItems[0].SubItems[0].Text + "'";
            string sqlMH = "select ROW_NUMBER()over(order by NhomHP) as STT, M.MaMH, TenMH from MONHOC M, GIANGVIEN G, THOIKHOABIEU T where T.MaGV = G.MaGV and M.MaMH = T.MaMH and T.MaGV='" + listGV.SelectedItems[0].SubItems[0].Text + "'";
            DataTable dtMH = new DataTable();
            dtMH = CSDL.LayDuLieu(sql);
            if (dtMH.Rows.Count > 0)
            {

                for (int i = 0; i < dtMH.Rows.Count; i++)
                {
                    listGD.Items.Add(dtMH.Rows[i][0].ToString());
                    listGD.Items[i].SubItems.Add(dtMH.Rows[i][1].ToString());
                    //listMH.Items[i].SubItems.Add(dtMH.Rows[i][2].ToString());
                }
            }
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
                listGD.Items.Clear();
                string sql = "select M.MaMH ,M.TenMH from CHUYENMON C, MONHOC M,GIANGVIEN G where C.MaGV = G.MaGV and C.MaMH=M.MaMH and C.MaGV ='" + listGV.SelectedItems[0].SubItems[0].Text + "'";
                string sqlMH = "select ROW_NUMBER()over(order by NhomHP) as STT, M.MaMH, TenMH from MONHOC M, GIANGVIEN G, THOIKHOABIEU T where T.MaGV = G.MaGV and M.MaMH = T.MaMH and T.MaGV='" + listGV.SelectedItems[0].SubItems[0].Text + "'";
                DataTable dtMH = new DataTable();
                dtMH = CSDL.LayDuLieu(sql);
                if (dtMH.Rows.Count > 0)
                {
                    
                    for (int i = 0; i < dtMH.Rows.Count; i++)
                    {
                        listGD.Items.Add(dtMH.Rows[i][0].ToString());
                        listGD.Items[i].SubItems.Add(dtMH.Rows[i][1].ToString());
                        //listMH.Items[i].SubItems.Add(dtMH.Rows[i][2].ToString());
                    }
                }
            }
            /* private void demGV(ListView lv)
    {
    int count = lv.Items.Count;
    lblDemGV.Text = count.ToString() + " giảng viên";
    }
    private void demMH(ListView lv)
    {
    int count = lv.Items.Count;
    lblDemMH.Text = count.ToString() + " môn học";
    }
    */
        }

         private void listMH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listMH.SelectedItems.Count > 0)
            {
                string sql = "select MaMH, TenMH from MONHOC where MaMH='" + listMH.SelectedItems[0].SubItems[0].Text + "'";
                DataTable dt = new DataTable();
                dt = CSDL.LayDuLieu(sql);
                if (dt.Rows.Count > 0)
                {
                    txtMaMH.Text = dt.Rows[0][0].ToString();
                    txtTenMH.Text = dt.Rows[0][1].ToString();

                }
            }
        }

        private void button4_Click(object sender, EventArgs e)//tim gv
        {
            string sql = "select MaGV, HoTen, MaDV from GIANGVIEN where MaGV ='" + txtTimMaGV.Text + "'";
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

        private void listGD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listGD.SelectedItems.Count > 0)
            {
                string sql = "select MaMH, TenMH from MONHOC where MaMH='" + listGD.SelectedItems[0].SubItems[0].Text + "'";
                DataTable dt = new DataTable();
                dt = CSDL.LayDuLieu(sql);
                if (dt.Rows.Count > 0)
                {
                    txtMaMH.Text = dt.Rows[0][0].ToString();
                    txtTenMH.Text = dt.Rows[0][1].ToString();

                }
            }
        }

        private void btnTimMH_Click(object sender, EventArgs e)
        {
            string sql = "select MaMH, TenMH from MONHOC where MaMH='" + txtTimMaMH.Text + "'";
            DataTable dt = new DataTable();
            dt = CSDL.LayDuLieu(sql);
            if (dt.Rows.Count > 0)
            {
                listMH.Items.Clear();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    listMH.Items.Add(dt.Rows[i][0].ToString());
                    listMH.Items[i].SubItems.Add(dt.Rows[i][1].ToString());
                    
                }
            }
        }

        private void btnThemMH_Click(object sender, EventArgs e)
        {
            string magv = listGV.SelectedItems[0].SubItems[0].Text;
            string mamh = listMH.SelectedItems[0].SubItems[0].Text;
            string sql = $"insert into CHUYENMON(MaGV, MaMH) values('{magv}', '{mamh}')";
            try
            {
                CSDL.XuLy(sql);
                LayDSGiangDay();
                MessageBox.Show("Đã thêm thông tin chuyên môn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Không thể thêm thông tin chuyên môn. Vui lòng kiểm tra và thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaMH_Click(object sender, EventArgs e)
        {
            try
            {
                string magv = listGV.SelectedItems[0].SubItems[0].Text;
                string mamh = listGD.SelectedItems[0].SubItems[0].Text;
                string sql = $"delete CHUYENMON where MaGV = '{magv}' and MaMH = '{mamh}'";
                CSDL.XuLy(sql);
                LayDSGiangDay();
                MessageBox.Show("Đã xóa thông tin chuyen môn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Không thể xóa thông tin chuyên môn. Vui lòng kiểm tra và thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
