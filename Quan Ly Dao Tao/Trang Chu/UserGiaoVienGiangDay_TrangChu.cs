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

namespace Quan_Ly_Dao_Tao.Trang_Chu
{
    public partial class UserGiaoVienGiangDay_TrangChu : UserControl
    {
        public UserGiaoVienGiangDay_TrangChu()
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

        private void panel2_Click(object sender, EventArgs e)
        {
            ThongTinSinhVien_Menu user = new ThongTinSinhVien_Menu();
            Add_UserControl(user);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ThongTinSinhVien_Menu user = new ThongTinSinhVien_Menu();
            Add_UserControl(user);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            ThongTinSinhVien_Menu user = new ThongTinSinhVien_Menu();
            Add_UserControl(user);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            ThongTinSinhVien_Menu user = new ThongTinSinhVien_Menu();
            Add_UserControl(user);
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            QuanLyDiemThi_Menu user = new QuanLyDiemThi_Menu();
            Add_UserControl(user);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            QuanLyDiemThi_Menu user = new QuanLyDiemThi_Menu();
            Add_UserControl(user);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            QuanLyDiemThi_Menu user = new QuanLyDiemThi_Menu();
            Add_UserControl(user);
        }

        private void UserGiaoVienGiangDay_TrangChu_Load(object sender, EventArgs e)
        {

        }
    }
}
