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

namespace Quan_Ly_Dao_Tao.Chuc_Nang.Quan_Ly_Hoc_Phi
{
    public partial class BaoCao_QuanLyHocPhi : UserControl
    {
        public BaoCao_QuanLyHocPhi()
        {
            InitializeComponent();
        }

        bool KiemTraDuLieuTrong()
        {
            if (cbDonVi.Text == "" || cbLop.Text == "" || cbNamHoc.Text == "" || cbHocKy.Text == "")
                return true;
            return false;
        }
        void LayDSDonVi()
        {
            string sql = "select * from DONVI";
            DataTable dt = CSDL.LayDuLieu(sql);
            cbDonVi.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbDonVi.Items.Add(dt.Rows[i][1].ToString());
            }


        }

        void LayDSLop()
        {
            string sql = "select LOP.TenLop from LOP, NGANH, DONVI where NGANH.MaNganh = LOP.MaNganh and NGANH.MaDV = DONVI.MaDV and DONVI.TenDV = N'" + cbDonVi.Text + "'";
            DataTable dt = CSDL.LayDuLieu(sql);
            cbLop.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbLop.Items.Add(dt.Rows[i][0].ToString());
            }


        }

        void LayDSHocKy()
        {
            string sql = "select THOIKHOABIEU.HocKy from THOIKHOABIEU";
            DataTable dt = CSDL.LayDuLieu(sql);
            cbHocKy.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbHocKy.Items.Add(dt.Rows[i][0].ToString());
            }


        }

        void LayDSNamhoc()
        {
            string sql = "select * from NAMHOC";
            DataTable dt = CSDL.LayDuLieu(sql);
            cbNamHoc.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbNamHoc.Items.Add(dt.Rows[i][0].ToString());
            }


        }

        void LaySoLuongSinhVienDangKy()
        {
            string sql = "";
            string select = "select count (distinct DANGKYHOCPHAN.MaSV) from DANGKYHOCPHAN, SINHVIEN, NGANH, LOP ";
            string where = "where SINHVIEN.MaLop = LOP.MaLop and DANGKYHOCPHAN.MaSV = SINHVIEN.MaSV and SINHVIEN.MaNganh = NGANH.MaNganh and LOP.MaNganh = NGANH.MaNganh and DANGKYHOCPHAN.NamHoc = '"+cbNamHoc.Text+"' and HocKy = "+cbHocKy.Text+" and LOP.MaLop = '"+tbMaLop.Text+"'";
            sql = select + where;
            DataTable dt = CSDL.LayDuLieu(sql);
            tbSLDK.Text = dt.Rows[0][0].ToString();
        }
        void LayDanhSachSinhVien()
        {
            listDSDongHP.Items.Clear();
            listDSChuaDongHP.Items.Clear();
            int DongHP = 0;
            int ChuaDongHP = 0;
            string select = "select distinct SINHVIEN.MaSV, SINHVIEN.HoTen, SINHVIEN.MaLop, DANGKYHOCPHAN.HocKy, DANGKYHOCPHAN.NamHoc";
            string from = "from DANGKYHOCPHAN, SINHVIEN, NGANH, LOP";
            string where = "where SINHVIEN.MaLop = LOP.MaLop and DANGKYHOCPHAN.MaSV = SINHVIEN.MaSV and SINHVIEN.MaNganh = NGANH.MaNganh and LOP.MaNganh = NGANH.MaNganh and DANGKYHOCPHAN.NamHoc = '"+cbNamHoc.Text+"' and HocKy = "+cbHocKy.Text+" and LOP.MaLop = '"+tbMaLop.Text+"'";
            string sql = select + " " + from + " " + where;
            DataTable dt = CSDL.LayDuLieu(sql);
            for(int i =0;  i < dt.Rows.Count; i++)
            {
                select = "select MaSV";
                from = "from DONGHOCPHI";
                where = "where MaSV = '" + dt.Rows[i][0].ToString() +"' and NamHoc = '"+cbNamHoc.Text+"' and HocKy = "+cbHocKy.Text+"";
                sql = select + " " + from + " " + where;
                DataTable dt1 = CSDL.LayDuLieu(sql);
                if (dt1.Rows.Count > 0)
                {
                    DongHP++;
                    int n = listDSDongHP.Items.Count;
                    listDSDongHP.Items.Add((n + 1).ToString());
                    listDSDongHP.Items[n].SubItems.Add(dt.Rows[i][0].ToString());
                    listDSDongHP.Items[n].SubItems.Add(dt.Rows[i][1].ToString());
                    listDSDongHP.Items[n].SubItems.Add(dt.Rows[i][2].ToString());
                    listDSDongHP.Items[n].SubItems.Add(dt.Rows[i][3].ToString());
                    listDSDongHP.Items[n].SubItems.Add(dt.Rows[i][4].ToString());

                    select = "select distinct (MONHOC.SoTC * HOCPHI.SoTien) as ThanhTien";
                    from = "from DANGKYHOCPHAN, MONHOC, HOCPHI, NGANH";
                    where = "where DANGKYHOCPHAN.MaMH = MONHOC.MaMH and MONHOC.TenNganh = NGANH.TenNganh and HOCPHI.MaNganh = NGANH.MaNganh and DANGKYHOCPHAN.MaSV = '"+ dt.Rows[i][0].ToString() + "' and HocKy = "+cbHocKy.Text+" and NamHoc = '"+cbNamHoc.Text+"'";
                    sql = select + " " + from + " " + where;
                    DataTable dt2 = CSDL.LayDuLieu(sql);
                    if(dt2.Rows.Count > 0)
                        listDSDongHP.Items[n].SubItems.Add(string.Format("{0:#,##0}", dt2.Rows[0][0]));
                }
                else
                {
                    ChuaDongHP++;
                    int n = listDSChuaDongHP.Items.Count;
                    listDSChuaDongHP.Items.Add((n + 1).ToString());
                    listDSChuaDongHP.Items[n].SubItems.Add(dt.Rows[i][0].ToString());
                    listDSChuaDongHP.Items[n].SubItems.Add(dt.Rows[i][1].ToString());
                    listDSChuaDongHP.Items[n].SubItems.Add(dt.Rows[i][2].ToString());
                    listDSChuaDongHP.Items[n].SubItems.Add(dt.Rows[i][3].ToString());
                    listDSChuaDongHP.Items[n].SubItems.Add(dt.Rows[i][4].ToString());

                    select = "select distinct (MONHOC.SoTC * HOCPHI.SoTien) as ThanhTien";
                    from = "from DANGKYHOCPHAN, MONHOC, HOCPHI, NGANH";
                    where = "where DANGKYHOCPHAN.MaMH = MONHOC.MaMH and MONHOC.TenNganh = NGANH.TenNganh and HOCPHI.MaNganh = NGANH.MaNganh and DANGKYHOCPHAN.MaSV = '" + dt.Rows[i][0].ToString() + "' and HocKy = " + cbHocKy.Text + " and NamHoc = '" + cbNamHoc.Text + "'";
                    sql = select + " " + from + " " + where;
                    DataTable dt2 = CSDL.LayDuLieu(sql);
                    if (dt2.Rows.Count > 0)
                        listDSChuaDongHP.Items[n].SubItems.Add(string.Format("{0:#,##0}", dt2.Rows[0][0]));
                }
                tbSLDaDongHP.Text = DongHP.ToString();
                lbDaDongHP.Text = DongHP.ToString() + " sinh viên";

                tbSLChuaDongHP.Text = ChuaDongHP.ToString();
                lbChuaDongHP.Text = ChuaDongHP.ToString() + " sinh viên";
            }
        }
        void LayDanhSachSinhVienChuaDangKy()
        {

        }

        private void listDS1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            // Tô màu nền
            e.Graphics.FillRectangle(Brushes.RoyalBlue, e.Bounds);
            // vẽ lại dòng tiêu đề với font in đậm và màu trắng
            e.Graphics.DrawString(e.Header.Text, new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold), Brushes.White, e.Bounds);

        }

        private void listDS2_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            // Tô màu nền
            e.Graphics.FillRectangle(Brushes.RoyalBlue, e.Bounds);
            // vẽ lại dòng tiêu đề với font in đậm và màu trắng
            e.Graphics.DrawString(e.Header.Text, new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold), Brushes.White, e.Bounds);

        }

        private void listDS1_DrawItem(object sender, DrawListViewItemEventArgs e)
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
                    e.Graphics.DrawString(listDSDongHP.Name, new Font(FontFamily.GenericSansSerif, 12), Brushes.Black, e.Bounds.Left, e.Bounds.Top);
                }
            }

        }

        private void listDS2_DrawItem(object sender, DrawListViewItemEventArgs e)
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
                    e.Graphics.DrawString(listDSChuaDongHP.Name, new Font(FontFamily.GenericSansSerif, 12), Brushes.Black, e.Bounds.Left, e.Bounds.Top);
                }
            }

        }

        private void BaoCao_QuanLyHocPhi_Load(object sender, EventArgs e)
        {
            LayDSDonVi();
            LayDSNamhoc();
            //LayDSHocKy();
            LayDSNamhoc();
        }

        private void cbDonVi_SelectedIndexChanged(object sender, EventArgs e)
        {
            LayDSLop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(KiemTraDuLieuTrong())
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin cần tìm kiếm", "Thông báo",  MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            string sql = "";
            string select = "select Lop.MaLop, Lop.TenLop, DONVI.TenDV, GIANGVIEN.HoTen from LOP, NGANH, DONVI, GIANGVIEN ";
            string where = "where LOP.MaNganh = NGANH.MaNganh and NGANH.MaDV =DONVI. MaDV and GVCN = GIANGVIEN.MaGV and TenLop = N'"+cbLop.Text+"'";
            sql = select + where;
            DataTable dt = CSDL.LayDuLieu(sql);
            if(dt.Rows.Count > 0 )
            {
                tbMaLop.Text = dt.Rows[0][0].ToString();
                tbTenLop.Text = dt.Rows[0][1].ToString();
                tbDonVi.Text = dt.Rows[0][2].ToString();
                tbGVCN.Text = dt.Rows[0][3].ToString();
                sql = "select count (*) from SINHVIEN where MaLop = '"+tbMaLop.Text+"'";
                DataTable dt1 = CSDL.LayDuLieu(sql);
                if( dt1.Rows.Count > 0 )
                    tbSiSo.Text = dt1.Rows[0][0].ToString();
            }
            else
            {
                MessageBox.Show("Dữ liệu nhập không hợp lệ. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            LaySoLuongSinhVienDangKy();
            LayDanhSachSinhVien();
        }
    }
}
