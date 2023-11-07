using Quan_Ly_Dao_Tao.Chuc_Nang.Quan_Ly_Sinh_Vien;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Dao_Tao.Menu.Nhan_vien_phong_Dao_tao
{
    public partial class QuanLySinhVien_Menu : UserControl
    {
        public QuanLySinhVien_Menu()
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

        void RestPanel()
        {
            foreach (Control cn in panel1.Controls)
            {
                if (cn is Panel)
                {
                    Panel bt = cn as Panel;
                    bt.BackColor = Color.RoyalBlue;
                    bt.ForeColor = Color.White;
                }
            }

        }

        void RestButton()
        {
            foreach (Control cn in panel1.Controls)
            {
                if (cn is Button)
                {
                    Button bt = cn as Button;
                    bt.BackColor = Color.RoyalBlue;
                    bt.ForeColor = Color.White;
                }
            }

        }

        private void QuanLySinhVien_Menu_Load(object sender, EventArgs e)
        {
            QuanLyThongTinSinhVien_QuanLySinhVien user = new QuanLyThongTinSinhVien_QuanLySinhVien();
            Add_UserControl(user);
        }

        private void bt1_Click(object sender, EventArgs e)
        {
            RestButton();
            RestPanel();

            bt1.BackColor = Color.WhiteSmoke;
            bt1.ForeColor = Color.Navy;

            QuanLyThongTinSinhVien_QuanLySinhVien user = new QuanLyThongTinSinhVien_QuanLySinhVien();
            Add_UserControl(user);
        }

        private void bt2_Click(object sender, EventArgs e)
        {
            RestButton();
            RestPanel();

            bt2.BackColor = Color.WhiteSmoke;
            bt2.ForeColor = Color.Navy;

            TraCuuSinhVien_QuanLySinhVien user = new TraCuuSinhVien_QuanLySinhVien();
            Add_UserControl(user);
        }

        private void bt3_Click(object sender, EventArgs e)
        {
            RestButton();
            RestPanel();

            bt3.BackColor = Color.WhiteSmoke;
            bt3.ForeColor = Color.Navy;

            QuanLyLopHoc_QuanLySinhVien user = new QuanLyLopHoc_QuanLySinhVien();
            Add_UserControl(user);
        }

        private void bt4_Click(object sender, EventArgs e)
        {
            RestButton();
            RestPanel();

            bt4.BackColor = Color.WhiteSmoke;
            bt4.ForeColor = Color.Navy;

            TraCuuLopHoc_QuanLySinhVien user = new TraCuuLopHoc_QuanLySinhVien();
            Add_UserControl(user);
        }

        private void bt5_Click(object sender, EventArgs e)
        {
            RestButton();
            RestPanel();

            bt5.BackColor = Color.WhiteSmoke;
            bt5.ForeColor = Color.Navy;

            InDanhSachSinhVien_QuanLySinhVien user = new InDanhSachSinhVien_QuanLySinhVien();
            Add_UserControl(user);
        }
    }
}
