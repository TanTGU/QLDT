using Quan_Ly_Dao_Tao.Chuc_Nang.Quan_Tri_Nguoi_Dung;
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
    public partial class QuanTriNguoiDung_Menu : UserControl
    {
        public QuanTriNguoiDung_Menu()
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

        private void NhanVienPhongDaoTao_Menu_Load(object sender, EventArgs e)
        {
            QuanLyTaiKhoan_QuanTriNguoiDung user = new QuanLyTaiKhoan_QuanTriNguoiDung();
            Add_UserControl(user);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RestButton();
            RestPanel();

            btQuanLyTaiKhoan.BackColor = Color.WhiteSmoke;
            btQuanLyTaiKhoan.ForeColor = Color.Navy;

            QuanLyTaiKhoan_QuanTriNguoiDung user = new QuanLyTaiKhoan_QuanTriNguoiDung();
            Add_UserControl(user);
        }

        private void btTraCuu_Click(object sender, EventArgs e)
        {
            RestButton();
            RestPanel();

            btTraCuu.BackColor = Color.WhiteSmoke;
            btTraCuu.ForeColor = Color.Navy;

            TraCuuTaiKhoan_QuanTriNguoiDung user = new TraCuuTaiKhoan_QuanTriNguoiDung();
            Add_UserControl(user);
        }
    }
}
