using Quan_Ly_Dao_Tao.BaoCao.CrystalReport;
using Quan_Ly_Dao_Tao.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Dao_Tao.BaoCao.From
{
    public partial class InDanhSachTaiKhoan : Form
    {
        public InDanhSachTaiKhoan()
        {
            InitializeComponent();
        }

        private void InDanhSachTaiKhoan_Load(object sender, EventArgs e)
        {
            string sql = $"select TK, MK, TenLoai, TenHienThi from TAIKHOAN, LOAITAIKHOAN where LoaiTK = LOAITAIKHOAN.MaLoai order by TenLoai asc";
            DataTable dt = CSDL.LayDuLieu(sql);
            InDanhSachTaiKhoan_CrystalReport cry = new InDanhSachTaiKhoan_CrystalReport();
            cry.SetDataSource(dt);
            crystalReportViewer1.ReportSource = cry;
        }
    }
}
