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
    public partial class TraCuuLopHoc_QuanLySinhVien : UserControl
    {
        public TraCuuLopHoc_QuanLySinhVien()
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

        void LayDSNganh()
        {
            string sql = "select * from NGANH where MaDV = '" + LayMaDV(cbDonVi.Text) + "'";
            DataTable dt = CSDL.LayDuLieu(sql);
            cbNganh.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbNganh.Items.Add(dt.Rows[i][1].ToString());
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

        private void TraCuuLopHoc_QuanLySinhVien_Load(object sender, EventArgs e)
        {
            LayDSDonVi();
            string sql1 = "select Ten from BACDAOTAO";
            DataTable dt1 = CSDL.LayDuLieu(sql1);
            cbBac.Items.Clear();
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                cbBac.Items.Add(dt1.Rows[i][0].ToString());
            }
        }

        private void listDS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listDS.SelectedItems.Count > 0)
            {
                tbMaLop.Text = listDS.SelectedItems[0].SubItems[0].Text;
                tbTenLop.Text = listDS.SelectedItems[0].SubItems[1].Text;
                tbMaDV.Text = LayMaDV(cbDonVi.Text);
                tbTenDonVi.Text = cbDonVi.Text;
                string sql = "select TenNganh, BACDAOTAO.Ten, GVCN, GIANGVIEN.HoTen from LOP, BACDAOTAO, GIANGVIEN, NGANH where LOP.MaNganh =NGANH.MaNganh and LOP.BacDaoTao =BACDAOTAO.Ma and GIANGVIEN.MaGV = LOP.GVCN and LOP.MaLop = '" + tbMaLop.Text + "'";
                DataTable dt = CSDL.LayDuLieu(sql);
                if (dt.Rows.Count > 0)
                {
                    cbNganh.Text = dt.Rows[0][0].ToString();
                    cbBac.Text = dt.Rows[0][1].ToString();
                    tbMaGVCN.Text = dt.Rows[0][2].ToString();
                    tbTenGVCN.Text = dt.Rows[0][3].ToString();
                }
            }
        }
        void LamMoiThongTinLop()
        {
            tbMaLop.Text = "";
            tbTenLop.Text = "";
            tbMaDV.Text = LayMaDV(cbDonVi.Text);
            tbTenDonVi.Text = cbDonVi.Text;
            cbNganh.Text = "";
            cbBac.Text = "";
            tbMaGVCN.Text = "";
            tbTenGVCN.Text = "";
        }
        private void cbDonVi_SelectedIndexChanged(object sender, EventArgs e)
        {
            LayDSNganh();
            string MaDV = LayMaDV(cbDonVi.Text);
            string sql = "select LOP. MaLop, LOP.TenLop from LOP, NGANH, DONVI where DONVI.MaDV = NGANH.MaDV and NGANH.MaNganh = LOP.MaNganh and DONVI.TenDV = N'" + cbDonVi.Text + "'";
            DataTable dt = CSDL.LayDuLieu(sql);
            listDS.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listDS.Items.Add(dt.Rows[i][0].ToString());
                listDS.Items[i].SubItems.Add(dt.Rows[i][1].ToString());
            }
            LamMoiThongTinLop();
        }
    }
}
