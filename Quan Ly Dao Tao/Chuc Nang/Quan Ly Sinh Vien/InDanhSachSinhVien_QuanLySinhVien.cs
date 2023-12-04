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

namespace Quan_Ly_Dao_Tao.Chuc_Nang.Quan_Ly_Sinh_Vien
{
    public partial class InDanhSachSinhVien_QuanLySinhVien : UserControl
    {
        public InDanhSachSinhVien_QuanLySinhVien()
        {
            InitializeComponent();
        }

        void LayDSDonVi()
        {
            string sql = "select *from DONVI";
            DataTable dt = CSDL.LayDuLieu(sql);
            cbDonVi.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbDonVi.Items.Add(dt.Rows[i][1].ToString());
            }
        }

        string LayMaDV(string Ten)
        {
            string sql = "select MaDV from DONVI where TenDV = N'" + Ten + "'";
            DataTable dt = CSDL.LayDuLieu(sql);
            string Ma = "";
            if (dt.Rows.Count > 0)
            {
                Ma = dt.Rows[0][0].ToString();
            }
            return Ma;
        }

        string LayMaLop(string Ten)
        {
            string sql = "select MaLop from LOP where TenLop = N'" + Ten + "'";
            DataTable dt = CSDL.LayDuLieu(sql);
            string Ma = "";
            if (dt.Rows.Count > 0)
            {
                Ma = dt.Rows[0][0].ToString();
            }
            return Ma;
        }

        void LayDSSinhVien()
        {
            string sql = "select MaSV, HoTen, NgaySinh, GioiTinh, CCCD, SoDT, DiaChi from SINHVIEN where MaLop = '"+LayMaLop(cbLop.Text)+"'";
            listDS.Items.Clear();
            DataTable dt = CSDL.LayDuLieu(sql);
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                listDS.Items.Add((i+1).ToString());
                listDS.Items[i].SubItems.Add(dt.Rows[i][0].ToString());
                listDS.Items[i].SubItems.Add(dt.Rows[i][1].ToString());
                DateTime date = Convert.ToDateTime(dt.Rows[i][2].ToString());
                listDS.Items[i].SubItems.Add(date.ToString("dd/MM/yyyy"));
                listDS.Items[i].SubItems.Add(dt.Rows[i][3].ToString());
                listDS.Items[i].SubItems.Add(dt.Rows[i][4].ToString());
                listDS.Items[i].SubItems.Add(dt.Rows[i][5].ToString());
                listDS.Items[i].SubItems.Add(dt.Rows[i][6].ToString());
            }
            lbSL.Text = listDS.Items.Count.ToString() + " sinh viên";
        }

        private void label1_Click(object sender, EventArgs e)
        {

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

        private void InDanhSachSinhVien_QuanLySinhVien_Load(object sender, EventArgs e)
        {
            LayDSDonVi();
        }

        private void cbDonVi_SelectedIndexChanged(object sender, EventArgs e)
        {
            string MaDV = LayMaDV(cbDonVi.Text);
            string sql = "select LOP.TenLop from LOP, NGANH, DONVI where DONVI.MaDV = NGANH.MaDV and NGANH.MaNganh = LOP.MaNganh and DONVI.TenDV = N'" + cbDonVi.Text + "'";
            DataTable dt = CSDL.LayDuLieu(sql);
            cbLop.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbLop.Items.Add(dt.Rows[i][0].ToString());
            }
        }

        private void cbLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string sql = "select Lop.TenLop, NGANH.TenNganh, BACDAOTAO.Ten, GIANGVIEN.HoTen  from LOP, BACDAOTAO, GIANGVIEN, NGANH where LOP.MaNganh =NGANH.MaNganh and LOP.BacDaoTao =BACDAOTAO.Ma and GIANGVIEN.MaGV = LOP.GVCN and LOP.MaLop = '"+LayMaLop(cbLop.Text)+"'";
            tbDonVi.Text = cbDonVi.Text;
            DataTable dt = CSDL.LayDuLieu(sql);
            if(dt.Rows.Count > 0)
            {
                tbTenLop.Text = dt.Rows[0][0].ToString();
                tbNganh.Text = dt.Rows[0][1].ToString();
                tbBac.Text = dt.Rows[0][2].ToString();
                tbGVCN.Text = dt.Rows[0][3].ToString();
            }
            LayDSSinhVien();
        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            if(tbTenLop.Text == "")
            {
                MessageBox.Show("Vui lòng lớp cần in danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            else
            {
                InDanhSachSinhVien f = new InDanhSachSinhVien(LayMaLop(tbTenLop.Text));
                f.ShowDialog();
            }
        }
    }
}
