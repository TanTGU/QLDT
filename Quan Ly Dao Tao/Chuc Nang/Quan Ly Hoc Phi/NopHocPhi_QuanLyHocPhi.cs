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

namespace Quan_Ly_Dao_Tao.Chuc_Nang.Quan_Ly_Hoc_Phi
{
    public partial class NopHocPhi_QuanLyHocPhi : UserControl
    {
        public NopHocPhi_QuanLyHocPhi()
        {
            InitializeComponent();
        }
        List<double> ThanhTien = new List<double>();
        double TongCong = 0;
        void LayDSDonVi()
        {
            string sql = "select * from DONVI";
            DataTable dt = CSDL.LayDuLieu(sql);
            cbdonvi.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbdonvi.Items.Add(dt.Rows[i][1].ToString());
            }


        }
        string MaSV = "";

        void LayDSLop()
        {
            string sql = "select LOP.TenLop from LOP, NGANH, DONVI where NGANH.MaNganh = LOP.MaNganh and NGANH.MaDV = DONVI.MaDV and DONVI.TenDV = N'"+cbdonvi.Text+"'";
            DataTable dt = CSDL.LayDuLieu(sql);
            cblop.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cblop.Items.Add(dt.Rows[i][0].ToString());
            }


        }

        void LayDSHocKy()
        {
            string sql = "select THOIKHOABIEU.HocKy from THOIKHOABIEU";
            DataTable dt = CSDL.LayDuLieu(sql);
            cbhocky.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbhocky.Items.Add(dt.Rows[i][0].ToString());
            }


        }

        void LayDSNamhoc()
        {
            string sql = "select * from NAMHOC";
            DataTable dt = CSDL.LayDuLieu(sql);
            cbnamhoc.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbnamhoc.Items.Add(dt.Rows[i][0].ToString());
            }


        }

        bool KiemTraDuLieuTrong()
        {
            if (cbdonvi.Text == "" || cblop.Text == "" || cbhocky.Text == "" || cbnamhoc.Text == "")
                return true;
            return false;
        }

        private void listDS_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            // Tô màu nền
            e.Graphics.FillRectangle(Brushes.RoyalBlue, e.Bounds);
            // vẽ lại dòng tiêu đề với font in đậm và màu trắng
            e.Graphics.DrawString(e.Header.Text, new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold), Brushes.White, e.Bounds);

        }

        private void listMH_ControlRemoved(object sender, ControlEventArgs e)
        {

        }

        private void listMH_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
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

        private void NopHocPhi_QuanLyHocPhi_Load(object sender, EventArgs e)
        {
            LayDSDonVi();
            //LayDSLop();
            //LayDSHocKy();
            LayDSNamhoc();
        }

        private void btntim_Click(object sender, EventArgs e)
        {
            //string sql = "select MaSV, HoTen from SINHVIEN where MaSV= '" + tbMSSV.Text + "'";
            //DataTable dt = CSDL.LayDuLieu(sql);
            //listDS.Items.Clear();
            //if (dt.Rows.Count > 0)
            //{
            //    listDS.Items.Add(dt.Rows[0][0].ToString());
            //    listDS.Items[0].SubItems.Add(dt.Rows[0][1].ToString());
            //}
            //else
            //{
            //    MessageBox.Show("Không tìm thấy sinh viên!", "Thông báo");
            //}
            if(KiemTraDuLieuTrong())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin cần tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            if(tbMSSV.Text == "")
            {
                string sql = "select distinct SINHVIEN.MaSV, SINHVIEN.HoTen from DANGKYHOCPHAN, SINHVIEN, LOP where SINHVIEN.MaSV = DANGKYHOCPHAN.MaSV and SINHVIEN.MaLop = LOP.MaLop and HocKy = " + cbhocky.Text + " and NamHoc = '" + cbnamhoc.Text + "' and LOP.TenLop = N'" + cblop.Text + "'";
                DataTable dt = CSDL.LayDuLieu(sql);
                listDS.Items.Clear();
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có sinh viên đăng ký!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        listDS.Items.Add(dt.Rows[i][0].ToString());
                        listDS.Items[i].SubItems.Add(dt.Rows[i][1].ToString());
                    }
                    return;
                }
            }
            else
            {
                string sql = "select distinct SINHVIEN.MaSV, SINHVIEN.HoTen from DANGKYHOCPHAN, SINHVIEN, LOP where SINHVIEN.MaSV = DANGKYHOCPHAN.MaSV and SINHVIEN.MaLop = LOP.MaLop and HocKy = " + cbhocky.Text + " and NamHoc = '" + cbnamhoc.Text + "' and LOP.TenLop = N'" + cblop.Text + "' and SINHVIEN.MaSV = '"+tbMSSV.Text+"'";
                DataTable dt = CSDL.LayDuLieu(sql);
                listDS.Items.Clear();
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có sinh viên đăng ký!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        listDS.Items.Add(dt.Rows[i][0].ToString());
                        listDS.Items[i].SubItems.Add(dt.Rows[i][1].ToString());
                    }
                    return;
                }
            }

        }

        private void cblop_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cbdonvi_SelectedIndexChanged(object sender, EventArgs e)
        {
            LayDSLop();
        }

        void LayThongTinHocPhi()
        {
            try
            {
                string sql = "";
                string select = "select MONHOC.MaMH, MONHOC.TenMH, MONHOC.SoTC, HOCPHI.SoTien, (MONHOC.SoTC * HOCPHI.SoTien) as ThanhTien from DANGKYHOCPHAN, MONHOC, HOCPHI, NGANH ";
                string where = "where DANGKYHOCPHAN.MaMH = MONHOC.MaMH and MONHOC.TenNganh = NGANH.TenNganh and HOCPHI.MaNganh = NGANH.MaNganh and DANGKYHOCPHAN.MaSV = '" + MaSV + "' and HocKy = " + tbhocky.Text + " and NamHoc = '" + tbnamhoc.Text + "'";
                sql = select + where;
                DataTable dt = CSDL.LayDuLieu(sql);
                ThanhTien.Clear();
                TongCong = 0;
                listMH.Items.Clear();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        listMH.Items.Add((i + 1).ToString());
                        listMH.Items[i].SubItems.Add(dt.Rows[i][0].ToString());
                        listMH.Items[i].SubItems.Add(dt.Rows[i][1].ToString());
                        listMH.Items[i].SubItems.Add(dt.Rows[i][2].ToString());
                        listMH.Items[i].SubItems.Add(string.Format("{0:#,##0}", dt.Rows[i][3]));
                        listMH.Items[i].SubItems.Add(string.Format("{0:#,##0}", dt.Rows[i][4]));
                        ThanhTien.Add(Convert.ToDouble(dt.Rows[i][4].ToString()));
                        TongCong += ThanhTien[i];
                    }
                    tbtongcong.Text = (string.Format("{0:#,##0}", TongCong));

                    sql = "select *from DONGHOCPHI where MaSV = '" + tbMSSV1.Text + "' and HocKy = " + tbhocky.Text + " and NamHoc = '" + tbnamhoc.Text + "'";
                    DataTable dt1 = CSDL.LayDuLieu(sql);
                    if (dt1.Rows.Count > 0)
                    {
                        //btnnop.Enabled = false;
                        tbtrangthai.Text = "Đã nộp học phí";
                    }
                    else
                    {
                        //btnnop.Enabled = true;
                        tbtrangthai.Text = "Chưa nộp học phí";
                    }
                }
            }
            catch
            {
                MessageBox.Show("Hệ thống đã xảy ra lỗi. Vui lòng thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listDS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listDS.SelectedItems.Count > 0)
            {
                tbMSSV1.Text = listDS.SelectedItems[0].SubItems[0].Text;
                tbhoten.Text = listDS.SelectedItems[0].SubItems[1].Text;
                tbdonvi.Text = cbdonvi.Text;
                tblop.Text = cblop.Text;
                tbnamhoc.Text = cbnamhoc.Text;
                tbhocky.Text = cbhocky.Text;
                
                MaSV = tbMSSV1.Text;
                LayThongTinHocPhi();
            }
        }

        private void btnxuat_Click(object sender, EventArgs e)
        {
            if(listMH.Items.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn thông tin cần xuất hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if(tbtrangthai.Text == "Chưa nộp học phí")
            {
                MessageBox.Show("Sinh viên chưa chưa học phí. Không thể xuất hóa đơn", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            InHoaDonDongHocPhi f = new InHoaDonDongHocPhi(tbMSSV1.Text, tbnamhoc.Text, tbhocky.Text);
            f.ShowDialog();
        }

        string LayMaLop(string Ten)
        {
            string result = "";
            string sql = $"select MaLop from LOP where TenLop = N'{Ten}'";
            DataTable dt = CSDL.LayDuLieu(sql);
            if (dt.Rows.Count > 0)
                result = dt.Rows[0][0].ToString();
            return result;
        }

        private void btnnop_Click(object sender, EventArgs e)
        {
            if (tbtrangthai.Text != "Chưa nộp học phí")
            {
                MessageBox.Show("Sinh viên đã nộp học phí", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                DateTime now = DateTime.Now;


                Random random = new Random();
                int randomNumber1 = random.Next(10, 99); 
                int randomNumber2 = random.Next(10, 99); 

                string TongCong = tbtongcong.Text.Replace(",", "");

                string Ma = $"{now.Day:D2}{now.Month:D2}{now.Year}{now.Hour:D2}{now.Minute:D2}{randomNumber1:D2}{randomNumber2:D2}";
                string sql = $"insert into DONGHOCPHI(SoPhieu, MaSV, MaLop,HocKy,NamHoc,SoTienDong, ThoiGianNop) values('{Ma}', '{tbMSSV1.Text}', '{LayMaLop(tblop.Text)}', {tbhocky.Text}, '{tbnamhoc.Text}', {TongCong}, '{DateTime.Now.ToString("yyyy/MM/dd")}')";
                DialogResult result = MessageBox.Show("Nộp học phí cho sinh viên " + tbhoten.Text + "?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    CSDL.XuLy(sql);
                    //CSDL.GhiLenhXuLySQL(sql);
                    LayThongTinHocPhi();
                    MessageBox.Show("Đã nộp học phí thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
