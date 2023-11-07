using Quan_Ly_Dao_Tao.Chuc_Nang.Quan_Ly_Mon_Hoc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Dao_Tao.Menu
{
    public partial class ThongTinMonHoc_Menu : UserControl
    {
        public ThongTinMonHoc_Menu()
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

        private void ThongTinMonHoc_Menu_Load(object sender, EventArgs e)
        {
            TraCuuThongTinMonHoc user = new TraCuuThongTinMonHoc();
            Add_UserControl(user);
        }

        private void bt1_Click(object sender, EventArgs e)
        {
            RestButton();
            RestPanel();

            bt1.BackColor = Color.WhiteSmoke;
            bt1.ForeColor = Color.Navy;

            TraCuuThongTinMonHoc user = new TraCuuThongTinMonHoc();
            Add_UserControl(user);
        }
    }
}
