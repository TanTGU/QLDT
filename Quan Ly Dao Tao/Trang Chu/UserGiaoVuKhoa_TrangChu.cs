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
    public partial class UserGiaoVuKhoa_TrangChu : UserControl
    {
        public UserGiaoVuKhoa_TrangChu()
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

        private void panel3_Click(object sender, EventArgs e)
        {
            ThongTinGiangVien_Menu user = new ThongTinGiangVien_Menu();
            Add_UserControl(user);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ThongTinGiangVien_Menu user = new ThongTinGiangVien_Menu();
            Add_UserControl(user);
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            ThongTinMonHoc_Menu user = new ThongTinMonHoc_Menu();
            Add_UserControl(user);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ThongTinMonHoc_Menu user = new ThongTinMonHoc_Menu();
            Add_UserControl(user);
        }

        private void label8_Click(object sender, EventArgs e)
        {
            ThongTinMonHoc_Menu user = new ThongTinMonHoc_Menu();
            Add_UserControl(user);
        }

        private void label7_Click(object sender, EventArgs e)
        {
            ThongTinMonHoc_Menu user = new ThongTinMonHoc_Menu();
            Add_UserControl(user);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            ThongTinGiangVien_Menu user = new ThongTinGiangVien_Menu();
            Add_UserControl(user);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            ThongTinGiangVien_Menu user = new ThongTinGiangVien_Menu();
            Add_UserControl(user);
        }
    }
}
