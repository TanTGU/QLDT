//using Quan_Ly_Dao_Tao.Chuc_Nang.Quan_Tri_Nguoi_Dung;
using Quan_Ly_Dao_Tao.Database;
using Quan_Ly_Dao_Tao.Menu;
using Quan_Ly_Dao_Tao.Menu.Nhan_vien_phong_Dao_tao;
using Quan_Ly_Dao_Tao.Menu.Quan_ly_diem;
using Quan_Ly_Dao_Tao.Trang_Chu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Quan_Ly_Dao_Tao
{
    public partial class TrangChu : Form
    {
        bool Thoat = true;
        public TrangChu()
        {
            InitializeComponent();
        }
        void Add_UserControl(UserControl user)
        {
            user.Dock = DockStyle.Fill;
            panel.Controls.Clear();
            panel.Controls.Add(user);
            user.BringToFront();
        }

        void VeTrangChu()
        {
            switch(CSDL.LoaiTaiKhoan)
            {
                case "GV":
                    UserGiaoVienGiangDay_TrangChu user = new UserGiaoVienGiangDay_TrangChu();
                    Add_UserControl(user);
                    lbLoaiTK.Text = "Giáo viên giảng dạy";
                    break;
                case "GVCN":
                    UserGiaoVienChuNhiem_TrangChu user1 = new UserGiaoVienChuNhiem_TrangChu();
                    Add_UserControl(user1);
                    lbLoaiTK.Text = "Giáo viên chủ nhiệm";
                    break;
                case "GVK":
                    UserGiaoVuKhoa_TrangChu user2 = new UserGiaoVuKhoa_TrangChu();
                    Add_UserControl(user2);
                    lbLoaiTK.Text = "Giáo vụ Khoa";
                    break;
                case "NVPCTCTSV":
                    UserNhanVienPhongCTCTSV_TrangChu user3 = new UserNhanVienPhongCTCTSV_TrangChu();
                    Add_UserControl(user3);
                    lbLoaiTK.Text = "Nhân viên phòng Công tác chính trị Sinh viên";
                    break;
                case "NVPDT":
                    UserNhanVienPhongDaoTao_TrangChu user4 = new UserNhanVienPhongDaoTao_TrangChu();
                    Add_UserControl(user4);
                    lbLoaiTK.Text = "Nhân viên phòng Đào tạo";
                    break;
                case "NVPTV":
                    UserNhanVienPhongDaoTao_TrangChu user5 = new UserNhanVienPhongDaoTao_TrangChu();
                    Add_UserControl(user5);
                    lbLoaiTK.Text = "Nhân viên phòng Tài vụ";
                    break;
                default:
                    MessageBox.Show("Hệ thống đã xảy ra lỗi, vui lòng thử lại sau!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
            
        }
        private void TrangChu_Load(object sender, EventArgs e)
        {
            lbTenHienThi.Text = CSDL.TenHienThi;

            VeTrangChu();

            tooltip.SetToolTip(panel3,"Trang Chủ");
            tooltip.SetToolTip(pictureBox1, "Trang Chủ");
            tooltip.SetToolTip(label1, "Trang Chủ");
            tooltip.SetToolTip(label2, "Trang Chủ");

            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            VeTrangChu();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            VeTrangChu();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            VeTrangChu();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            VeTrangChu();
        }

        private void panel3_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void TrangChu_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Thoat)
                Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangNhap dn = new DangNhap();
            dn.Show();
        }
    }
}
