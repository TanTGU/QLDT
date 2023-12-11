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
    public partial class InDanhSachDKHP : Form
    {
        string MaMH = "";
        string NhomHP = "";
        string NamHoc = "";
        string HocKy = "";
        public InDanhSachDKHP(string maMH, string nhomHP, string namHoc, string hocKy)
        {
            InitializeComponent();
            MaMH = maMH;
            NhomHP = nhomHP;
            NamHoc = namHoc;
            HocKy = hocKy;
        }

        private void InDanhSachDKHP_Load(object sender, EventArgs e)
        {
            string select = "select SINHVIEN.MaSV, SINHVIEN.HoTen, LOP.TenLop as MaLop, MONHOC.MaMH, MONHOC.TenMH, NhomHP, HocKy, NamHoc, MONHOC.SoTC ";
            string from = "from DANGKYHOCPHAN, SINHVIEN, MONHOC, LOP ";
            string where = $"where SINHVIEN.MaLop = LOP.MaLop and MONHOC.MaMH = DANGKYHOCPHAN.MaMH and SINHVIEN.MaSV = DANGKYHOCPHAN.MaSV and DANGKYHOCPHAN.MaMH = '{MaMH}' and NhomHP = '{NhomHP}' and NamHoc = '{NamHoc}' and HocKy = {HocKy}";
            string sql = select + from + where;
            DataTable dt = CSDL.LayDuLieu(sql);
            InDanhSachDKHP_CrystalReport cry = new InDanhSachDKHP_CrystalReport();
            cry.SetDataSource(dt);
            crystalReportViewer1.ReportSource = cry;
        }
    }
}
