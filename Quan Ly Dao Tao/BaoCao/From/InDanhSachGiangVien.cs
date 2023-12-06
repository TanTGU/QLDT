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
    public partial class InDanhSachGiangVien : Form
    {
        string MaDV = "";
        public InDanhSachGiangVien(string MaDV)
        {
            InitializeComponent();
            this.MaDV = MaDV;
        }

        private void InDanhSachGiangVien_Load(object sender, EventArgs e)
        {
            string sql = $"select MaGV, G.HoTen, convert(varchar(10), G.NgaySinh, 103) as NgaySinh, GioiTinh, G.SoDT, Email, DiaChi, D.MaDV, HocHam, HocVi, UPPER(TenDV) COLLATE SQL_Latin1_General_CP1_CI_AS as TenDV from GIANGVIEN G, DONVI D where G.MaDV = D.MaDV and D.MaDV = '{MaDV}'";
            DataTable dt = CSDL.LayDuLieu(sql);
            InDanhSachGiangVien_CrystalReport cry = new InDanhSachGiangVien_CrystalReport();
            cry.SetDataSource(dt);
            crystalReportViewer1.ReportSource = cry;
        }
    }
}
