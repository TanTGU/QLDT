using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Quan_Ly_Dao_Tao.Database;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Quan_Ly_Dao_Tao.Chuc_Nang.Quan_Ly_Sinh_Vien
{
    public partial class QuanLyThongTinSinhVien_QuanLySinhVien : UserControl
    {
        public QuanLyThongTinSinhVien_QuanLySinhVien()
        {
            InitializeComponent();
        }
        bool Chon = true;

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

        static string TaoChuoiMoi(string[] mangChuoi)
        {
            // Lấy phần tử cuối cùng trong mảng
            string phanTuCuoi = mangChuoi[mangChuoi.Length - 1];

            // Tách phần số cuối cùng
            string soCuoi = phanTuCuoi.Substring(6);

            // Chuyển đổi số cuối cùng thành số nguyên
            int soNguyen = int.Parse(soCuoi);

            // Tăng số nguyên lên 1
            soNguyen++;

            // Tạo chuỗi mới với số nguyên đã tăng
            string chuoiMoi = $"{phanTuCuoi.Substring(0, 6)}{soNguyen:D3}";

            return chuoiMoi;
        }

        string LayMaSVMoi()
        {
            string[] MaSV;
            string result = "";
            if (listDS.Items.Count > 0)
            {
                MaSV = new string[listDS.Items.Count];
                for (int i = 0; i < listDS.Items.Count; i++)
                {
                    MaSV[i] = listDS.Items[i].SubItems[0].Text;
                }
                result = TaoChuoiMoi(MaSV);
            }
            return result;
        }

        void LayDuLieuKhoiTao()
        {
            cbGioiTinh.Items.Clear();
            cbGioiTinh.Items.Add("Nam");
            cbGioiTinh.Items.Add("Nữ");

            string sql1 = "select Ten from BACDAOTAO";
            DataTable dt1 = CSDL.LayDuLieu(sql1);
            cbBacDaoTao.Items.Clear();
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                cbBacDaoTao.Items.Add(dt1.Rows[i][0].ToString());
            }

            string sql2 = "select Ten from HINHTHUCDAOTAO";
            DataTable dt2 = CSDL.LayDuLieu(sql2);
            cbHinhThucDaoTao.Items.Clear();
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                cbHinhThucDaoTao.Items.Add(dt2.Rows[i][0].ToString());
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

        void LamMoi()
        {
            tbMaSV.Text = "";
            tbHoTen.Text = "";
            dateNgaySinh.Value = DateTime.Now;
            cbGioiTinh.Text = "";
            tbCCCD.Text = "";
            tbSoDT.Text = "";
            tbEmail.Text = "";
            tbDiaChi.Text = "";
            tbMaLop.Text = "";
            tbTenLop.Text = "";
            tbNganhHoc.Text = "";
            cbHinhThucDaoTao.Text = "";
            cbBacDaoTao.Text = "";
        }

        string LayMaSVDau(string TenLop)
        {
            string MaSV = "";
            string sql = "select MaSV from SINHVIEN, LOP where SINHVIEN.MaLop = LOP.MaLop and Lop.TenLop = N'" + TenLop + "'";
            DataTable dt = CSDL.LayDuLieu(sql);
            if (dt.Rows.Count > 0)
                MaSV = dt.Rows[0][0].ToString();
            return MaSV;
        }
        List<string> LayDSSinhVien(string MSSV)
        {
            List<string> list = new List<string>();
            string kyTuDau = MSSV.Substring(0, 6);
            string sql = "select MaSV from SINHVIEN where MaSV like '" + kyTuDau + "%'";
            DataTable dt = CSDL.LayDuLieu(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
                list.Add(dt.Rows[i][0].ToString());
            return list;
        }

        bool KiemTraTrungLap(string MSSV)
        {
            string sql = "select MaSV from SINHVIEN where MaSV like '" + MSSV + "'";
            DataTable dt = CSDL.LayDuLieu(sql);
            if (dt.Rows.Count > 0)
                return true;
            return false;
        }

        string LayMSSV_TiepTheo(string TenLop)
        {
            string result = "";
            List<string> list = LayDSSinhVien(LayMaSVDau(TenLop));
            if (list.Count == 0)
                return result;

            string MSSV_Dau = list[0];

            string soCuoi = MSSV_Dau.Substring(6);

            int soNguyen = 1;

            while (true)
            {
                result = $"{MSSV_Dau.Substring(0, 6)}{soNguyen:D3}";
                if (KiemTraTrungLap(result))
                    soNguyen++;
                else
                    break;
            }

            return result;
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

        

        private void QuanLyThongTinSinhVien_QuanLySinhVien_Load(object sender, EventArgs e)
        {
            LayDSDonVi();
            LayDuLieuKhoiTao();
        }

        

        private void cbDonVi_SelectedIndexChanged(object sender, EventArgs e)
        {
            LamMoi();
            string MaDV = LayMaDV(cbDonVi.Text);
            string sql = "select LOP.TenLop from LOP, NGANH, DONVI where DONVI.MaDV = NGANH.MaDV and NGANH.MaNganh = LOP.MaNganh and DONVI.TenDV = N'"+ cbDonVi.Text + "'";
            DataTable dt = CSDL.LayDuLieu(sql);
            cbLop.Items.Clear();
            for(int i = 0; i < dt.Rows.Count;i++)
            {
                cbLop.Items.Add(dt.Rows[i][0].ToString());
            }
            cbLop.Text = "";
            listDS.Items.Clear();
            tbTimKiem.Text = "";
        }

        void LayThongTinLop(string TenLop)
        {
            string select = "select distinct MaLop, TenLop, NGANH.TenNganh, BACDAOTAO.Ten, HINHTHUCDAOTAO.Ten from LOP, HINHTHUCDAOTAO, BACDAOTAO, NGANH ";
            string where = "where LOP.HinhThucDaoTao = HINHTHUCDAOTAO.Ma and LOP.BacDaoTao = BACDAOTAO.Ma and LOP.MaNganh = NGANH.MaNganh and TenLop = N'"+TenLop+"'";
            string sql = select + where;
            DataTable dt = CSDL.LayDuLieu(sql);
            if(dt.Rows.Count > 0)
            {
                tbMaLop.Text = dt.Rows[0][0].ToString();
                tbTenLop.Text = dt.Rows[0][1].ToString();
                tbNganhHoc.Text = dt.Rows[0][2].ToString();
                cbBacDaoTao.Text = dt.Rows[0][3].ToString();
                cbHinhThucDaoTao.Text = dt.Rows[0][4].ToString();
            }
        }

        void LayDSSinhVien()
        {
            string MaLop = LayMaLop(cbLop.Text);
            string sql = "select MaSV, HoTen from SINHVIEN where MaLop = '" + MaLop + "'";
            listDS.Items.Clear();
            DataTable dt = CSDL.LayDuLieu(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listDS.Items.Add(dt.Rows[i][0].ToString());
                listDS.Items[i].SubItems.Add(dt.Rows[i][1].ToString());
            }
        }

        private void cbLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            LamMoi();
            LayDSSinhVien();
            LayThongTinLop(cbLop.Text);
        }

        private void listDS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listDS.SelectedItems.Count > 0)
            {
                string sql = @"select MaSV, HoTen, NgaySinh, GioiTinh, CCCD, SoDT, Email, DiaChi, SINHVIEN.MaLop, LOP.TenLop, NGANH.TenNganh, HINHTHUCDAOTAO.Ten, BACDAOTAO.Ten  from SINHVIEN, LOP, NGANH, HINHTHUCDAOTAO, BACDAOTAO where NGANH.MaNganh = LOP.MaNganh and LOP.BacDaoTao = BACDAOTAO.Ma and SINHVIEN.MaLop = LOP.MaLop and SINHVIEN.HinhThucDaoTao = HINHTHUCDAOTAO.Ma and SINHVIEN.MaSV = '" + listDS.SelectedItems[0].SubItems[0].Text +"'";
                DataTable dt = CSDL.LayDuLieu(sql);
                if(dt.Rows.Count > 0)
                {
                    tbMaSV.Text = dt.Rows[0][0].ToString();
                    tbHoTen.Text = dt.Rows[0][1].ToString();
                    dateNgaySinh.Value = Convert.ToDateTime(dt.Rows[0][2].ToString());
                    cbGioiTinh.Text = dt.Rows[0][3].ToString();
                    tbCCCD.Text = dt.Rows[0][4].ToString();
                    tbSoDT.Text = dt.Rows[0][5].ToString();
                    tbEmail.Text = dt.Rows[0][6].ToString();
                    tbDiaChi.Text = dt.Rows[0][7].ToString();
                    tbMaLop.Text = dt.Rows[0][8].ToString();
                    tbTenLop.Text = dt.Rows[0][9].ToString();
                    tbNganhHoc.Text = dt.Rows[0][10].ToString();
                    cbHinhThucDaoTao.Text = dt.Rows[0][11].ToString();
                    cbBacDaoTao.Text = dt.Rows[0][12].ToString();
                }
                Chon = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LamMoi();
            if(tbTimKiem.Text =="")
            {
                MessageBox.Show("Vui lòng nhập MSSV cần tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            listDS.Items.Clear();
            string sql = "select MaSV, HoTen, DONVI.TenDV, LOP.TenLop from SINHVIEN, LOP, DONVI, NGANH where LOP.MaNganh = NGANH.MaNganh and DONVI.MaDV = NGANH.MaDV and LOP.MaLop = SINHVIEN.MaLop and MaSV = '"+tbTimKiem.Text+"'";
            DataTable dt = CSDL.LayDuLieu(sql);
            if(dt.Rows.Count > 0)
            {
                cbDonVi.Text = dt.Rows[0][2].ToString();
                cbLop.Text = dt.Rows[0][3].ToString();
                listDS.Items.Clear();
                listDS.Items.Add(dt.Rows[0][0].ToString());
                listDS.Items[0].SubItems.Add(dt.Rows[0][1].ToString());
                

            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin sinh viên phù hợp. Vui lòng thử lại!", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
        }
        
        
        

        private void button5_Click(object sender, EventArgs e)
        {
            tbMaSV.Text = "";
            tbHoTen.Text = "";
            dateNgaySinh.Value = DateTime.Now;
            cbGioiTinh.Text = "";
            tbCCCD.Text = "";
            tbSoDT.Text = "";
            tbEmail.Text = "";
            
            tbDiaChi.Text = "";

            if(cbLop.Text != "")
                tbMaSV.Text = LayMSSV_TiepTheo(cbLop.Text);
            Chon = true;
        }

        private bool IsNumericLengthValid(string input, int expectedLength)
        {
            // Kiểm tra xem chuỗi có phải là số không
            if (!long.TryParse(input, out _))
            {
                return false;
            }

            // Kiểm tra chiều dài của chuỗi
            return input.Length == expectedLength;
        }

        bool KiemTraSoCCCD()
        {
            if (!IsNumericLengthValid(tbCCCD.Text, 12))
            {
                return true;
                
            }
            return false;
        }
        bool KiemTraSoDT()
        {
            if (!IsNumericLengthValid(tbSoDT.Text, 10))
            {
                return true;

            }
            return false;
        }

        bool KiemTraDuLieuTrong()
        {
            if (tbMaSV.Text == "" || tbHoTen.Text == "" || cbGioiTinh.Text == "")
                return true;
            return false;
        }

        string LayMaNganh(string Ten)
        {
            string result = "";
            string sql = "select MaNganh from NGANH where TenNganh = N'"+Ten+"'";
            DataTable dt = CSDL.LayDuLieu(sql);
            if (dt.Rows.Count > 0)
                result = dt.Rows[0][0].ToString();
            return result;
        }

        string LayMaHinhThucDaoTao(string Ten)
        {
            string result = "";
            string sql = "select Ma from HINHTHUCDAOTAO where Ten = N'" + Ten + "'";
            DataTable dt = CSDL.LayDuLieu(sql);
            if (dt.Rows.Count > 0)
                result = dt.Rows[0][0].ToString();
            return result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(tbMaLop.Text == "")
            {
                MessageBox.Show("Vui lòng chọn lớp cần thêm sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if(KiemTraDuLieuTrong())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắc buộc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if(tbCCCD.Text !="")
            {
                if(KiemTraSoCCCD())
                {
                    MessageBox.Show("CCCD phải có định dạng 12 số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbCCCD.Focus();
                    return;
                }
                
            }
            if (tbSoDT.Text != "")
            {
                if (KiemTraSoDT())
                {
                    MessageBox.Show("Số điện thoại phải có định dạng 10 số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbSoDT.Focus();
                    return;
                }

            }
            string CCCD = (tbCCCD.Text == "" ? "null" : "'" + tbCCCD.Text + "'");
            string SoDT = (tbSoDT.Text == "" ? "null" : "'" + tbSoDT.Text + "'");
            string DiaChi = (tbDiaChi.Text == "" ? "null" : "N'" + tbDiaChi.Text + "'");
            
            string insert = "insert into SINHVIEN(MaSV, HoTen, NgaySinh, GioiTinh, CCCD, SoDT, Email, DiaChi, MaLop, MaNganh, HinhThucDaoTao) ";
            string values = "values('"+tbMaSV.Text+"', N'"+tbHoTen.Text+"', '"+dateNgaySinh.Value.ToString("yyyy/MM/dd")+"', N'"+cbGioiTinh.Text+ "', "+CCCD+", "+SoDT+", '"+tbEmail.Text+"', "+DiaChi+", '"+LayMaLop(cbLop.Text)+"', '"+LayMaNganh(tbNganhHoc.Text)+"', '"+LayMaHinhThucDaoTao(cbHinhThucDaoTao.Text)+"')";
            string sql = insert + values;
            CSDL.XuLy(sql);
            LayDSSinhVien();
            MessageBox.Show("Đã thêm thông tin sinh viên mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tbHoTen_TextChanged(object sender, EventArgs e)
        {
            
        }

        // Hàm chuyển đổi chuỗi có dấu sang không dấu
        private string ConvertToUnSign(string input)
        {
            string regex = "\\p{IsCombiningDiacriticalMarks}+";

            string temp = input.Normalize(NormalizationForm.FormD);
            return Regex.Replace(temp, regex, string.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }

        private void tbHoTen_Leave(object sender, EventArgs e)
        {
            if (tbMaSV.Text != "" && tbMaSV.Text != "" && Chon == true)
            {
                // Bước 1: Lấy từ cuối cùng trong tbHoTen
                string hoTen = tbHoTen.Text;
                string[] arrTen = hoTen.Split(' ');
                string lastTen = arrTen[arrTen.Length - 1];

                // Chuyển về tiếng Việt viết thường không dấu
                string lastTenWithoutDau = ConvertToUnSign(lastTen.ToLower());

                // Bước 2: thêm MaSV + "@tgu.edu.vn"
                string maSV = tbMaSV.Text;
                string email = lastTenWithoutDau + maSV + "@tgu.edu.vn";

                // Bước 3: Gán kết quả vào tbEmail
                tbEmail.Text = email;
            }


        }

        private void tbMaSV_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbMaSV_Leave(object sender, EventArgs e)
        {
            
        }

        private void tbHoTen_Enter(object sender, EventArgs e)
        {
            
        }

        private void tbMaSV_Enter(object sender, EventArgs e)
        {
            
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }
    }
}
