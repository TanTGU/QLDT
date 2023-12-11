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
    public partial class InDanhSachMonHoc : Form
    {
        string TenNganh = "";
        public InDanhSachMonHoc(string tenNganh)
        {
            InitializeComponent();
            TenNganh = tenNganh;
        }

        private void InDanhSachMonHoc_Load(object sender, EventArgs e)
        {
            string select = "select MaMH, TenMH, SoTC, SoTietLT, SoTietTH, UPPER(TenDV) COLLATE SQL_Latin1_General_CP1_CI_AS as TenDV, NGANH.TenNganh ";
            string from = "from MONHOC, DONVI, NGANH ";
            string where = $"where MONHOC.TenNganh = NGANH.TenNganh and NGANH.MaDV = DONVI.MaDV and MONHOC.TenNganh = N'{TenNganh}'";
            string sql = select + from + where;
            DataTable dt = CSDL.LayDuLieu(sql);
            InDanhDachMonHoc_CrystalReport cry = new InDanhDachMonHoc_CrystalReport();
            cry.SetDataSource(dt);
            crystalReportViewer1.ReportSource = cry;
        }
    }
}
