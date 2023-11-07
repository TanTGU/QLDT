using Quan_Ly_Dao_Tao.Menu;
using Quan_Ly_Dao_Tao.Menu.Nhan_vien_phong_Dao_tao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Dao_Tao
{
    public partial class UserNhanVienPhongDaoTao_TrangChu : UserControl
    {
        public UserNhanVienPhongDaoTao_TrangChu()
        {
            InitializeComponent();
        }

        void Add_UserControl(UserControl user)
        {
            user.Dock = DockStyle.Fill;
            this.Controls.Clear();
            this.Controls.Add(user);
            user.BringToFront();
        }

        private void UserNhanVienPhongDaoTao_TrangChu_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Click(object sender, EventArgs e)
        {
            QuanLySinhVien_Menu user = new QuanLySinhVien_Menu();
            Add_UserControl(user);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            QuanLySinhVien_Menu user = new QuanLySinhVien_Menu();
            Add_UserControl(user);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            QuanLySinhVien_Menu user = new QuanLySinhVien_Menu();
            Add_UserControl(user);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            QuanLySinhVien_Menu user = new QuanLySinhVien_Menu();
            Add_UserControl(user);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Click(object sender, EventArgs e)
        {
            QuanTriNguoiDung_Menu user = new QuanTriNguoiDung_Menu();
            Add_UserControl(user);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            QuanTriNguoiDung_Menu user = new QuanTriNguoiDung_Menu();
            Add_UserControl(user);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            QuanTriNguoiDung_Menu user = new QuanTriNguoiDung_Menu();
            Add_UserControl(user);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            QuanTriNguoiDung_Menu user = new QuanTriNguoiDung_Menu();
            Add_UserControl(user);
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            QuanLyGiangVien_Menu user = new QuanLyGiangVien_Menu();
            Add_UserControl(user);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            QuanLyGiangVien_Menu user = new QuanLyGiangVien_Menu();
            Add_UserControl(user);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            QuanLyGiangVien_Menu user = new QuanLyGiangVien_Menu();
            Add_UserControl(user);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            QuanLyGiangVien_Menu user = new QuanLyGiangVien_Menu();
            Add_UserControl(user);
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            QuanLyMonHoc_Menu user = new QuanLyMonHoc_Menu();
            Add_UserControl(user);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            QuanLyMonHoc_Menu user = new QuanLyMonHoc_Menu();
            Add_UserControl(user);
        }

        private void label8_Click(object sender, EventArgs e)
        {
            QuanLyMonHoc_Menu user = new QuanLyMonHoc_Menu();
            Add_UserControl(user);
        }

        private void label7_Click(object sender, EventArgs e)
        {
            QuanLyMonHoc_Menu user = new QuanLyMonHoc_Menu();
            Add_UserControl(user);
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            QuanLyThoiKhoaBieu user = new QuanLyThoiKhoaBieu();
            Add_UserControl(user);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            QuanLyThoiKhoaBieu user = new QuanLyThoiKhoaBieu();
            Add_UserControl(user);
        }

        private void label10_Click(object sender, EventArgs e)
        {
            QuanLyThoiKhoaBieu user = new QuanLyThoiKhoaBieu();
            Add_UserControl(user);
        }

        private void label9_Click(object sender, EventArgs e)
        {
            QuanLyThoiKhoaBieu user = new QuanLyThoiKhoaBieu();
            Add_UserControl(user);
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            QuanLyDangKyHocPhan_Menu user = new QuanLyDangKyHocPhan_Menu();
            Add_UserControl(user);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            QuanLyDangKyHocPhan_Menu user = new QuanLyDangKyHocPhan_Menu();
            Add_UserControl(user);
        }

        private void label12_Click(object sender, EventArgs e)
        {
            QuanLyDangKyHocPhan_Menu user = new QuanLyDangKyHocPhan_Menu();
            Add_UserControl(user);
        }

        private void label11_Click(object sender, EventArgs e)
        {
            QuanLyDangKyHocPhan_Menu user = new QuanLyDangKyHocPhan_Menu();
            Add_UserControl(user);
        }
    }
}
