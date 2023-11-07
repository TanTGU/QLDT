using Quan_Ly_Dao_Tao.Chuc_Nang.Quan_Ly_Diem;
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
    public partial class QuanLyDiemRenLuyen_Menu : UserControl
    {
        public QuanLyDiemRenLuyen_Menu()
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

        private void QuanLyDiemRenLuyen_Menu_Load(object sender, EventArgs e)
        {
            NhapDiemRenLuyen_QuanLyDiem user = new NhapDiemRenLuyen_QuanLyDiem();
            Add_UserControl(user);
        }

        private void bt1_Click(object sender, EventArgs e)
        {
            RestButton();
            RestPanel();

            bt1.BackColor = Color.WhiteSmoke;
            bt1.ForeColor = Color.Navy;

            NhapDiemRenLuyen_QuanLyDiem user = new NhapDiemRenLuyen_QuanLyDiem();
            Add_UserControl(user);
        }

        private void bt2_Click(object sender, EventArgs e)
        {
            RestButton();
            RestPanel();

            bt2.BackColor = Color.WhiteSmoke;
            bt2.ForeColor = Color.Navy;

            TraCuuDiemRenLuyen_QuanLyDiem user = new TraCuuDiemRenLuyen_QuanLyDiem();
            Add_UserControl(user);
        }

        private void bt3_Click(object sender, EventArgs e)
        {
            RestButton();
            RestPanel();

            bt3.BackColor = Color.WhiteSmoke;
            bt3.ForeColor = Color.Navy;

            InDanhSachDiemRenLuyen_QuanLyDiem user = new InDanhSachDiemRenLuyen_QuanLyDiem();
            Add_UserControl(user);
        }
    }
}
