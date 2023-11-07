using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Dao_Tao.Chuc_Nang.Quan_Tri_Nguoi_Dung
{
    public partial class UserQuanTriNguoiDung_Menu : UserControl
    {
        public UserQuanTriNguoiDung_Menu()
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
                    //bt.FlatStyle = FlatStyle.Flat;
                    //bt.FlatStyle
                }
            }

        }

        private void UserQuanTriNguoiDung_Menu_Load(object sender, EventArgs e)
        {
            UserQuanTriNguoiDung_QuanLyTaiKhoan user = new UserQuanTriNguoiDung_QuanLyTaiKhoan();
            Add_UserControl(user);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RestButton();
            RestPanel();

            btQuanTri.BackColor = Color.WhiteSmoke;
            btQuanTri.ForeColor = Color.Black;

            UserQuanTriNguoiDung_QuanLyTaiKhoan user = new UserQuanTriNguoiDung_QuanLyTaiKhoan();
            Add_UserControl(user);
        }

        private void btTraCuu_Click(object sender, EventArgs e)
        {
            RestButton();
            RestPanel();

            btTraCuu.BackColor = Color.WhiteSmoke;
            btTraCuu.ForeColor = Color.Black;

            UserQuanTriNguoiDung_TimKiemTaiKhoan user = new UserQuanTriNguoiDung_TimKiemTaiKhoan();
            Add_UserControl(user);
        }
    }
}
