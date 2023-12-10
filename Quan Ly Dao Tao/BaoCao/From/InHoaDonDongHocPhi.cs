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
    public partial class InHoaDonDongHocPhi : Form
    {
        string MaSV = "";
        string NamHoc = "";
        string HK = "";
        public InHoaDonDongHocPhi(string MaSV, string NamHoc, string HK)
        {
            InitializeComponent();
            this.MaSV = MaSV;
            this.NamHoc = NamHoc;
            this.HK = HK;
        }

        private void InHoaDonDongHocPhi_Load(object sender, EventArgs e)
        {

            string select = "select SINHVIEN.MaSV, SINHVIEN.HoTen, TenLop, DONGHOCPHI.HocKy, DONGHOCPHI.NamHoc, MONHOC.MaMH, MONHOC.TenMH, MONHOC.SoTC, HOCPHI.SoTien as DonGia, (MONHOC.SoTC * HOCPHI.SoTien) as ThanhTien, DONGHOCPHI.SoPhieu, DONGHOCPHI.SoTienDong,  convert(varchar(10), DONGHOCPHI.ThoiGianNop, 103) as ThoiGianNop";
            string from = " from DONGHOCPHI, DANGKYHOCPHAN, MONHOC, HOCPHI, SINHVIEN, LOP";
            string where = $" where SINHVIEN.MaLop = LOP.MaLop and SINHVIEN.MaSV = DONGHOCPHI.MaSV and DONGHOCPHI.MaSV = DANGKYHOCPHAN.MaSV and DANGKYHOCPHAN.MaMH = MONHOC.MaMH and SINHVIEN.MaNganh = HOCPHI.MaNganh and SINHVIEN.MaSV = '{MaSV}' and DONGHOCPHI.NamHoc = '{NamHoc}' and DONGHOCPHI.HocKy = {HK}";
            string sql = select + from + where;
            DataTable dt = CSDL.LayDuLieu(sql);
            InHoaDon_CrystalReport cry = new InHoaDon_CrystalReport();
            cry.SetDataSource(dt);
            crystalReportViewer1.ReportSource = cry;
        }
    }
}
