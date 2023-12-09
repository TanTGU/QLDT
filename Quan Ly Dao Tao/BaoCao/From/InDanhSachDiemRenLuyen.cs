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
    public partial class InDanhSachDiemRenLuyen : Form
    {
        string MaLop = "";
        string NamHoc = "";
        string HocKy = "";
        public InDanhSachDiemRenLuyen(string maLop, string namHoc, string hocKy)
        {
            InitializeComponent();
            MaLop = maLop;
            NamHoc = namHoc;
            HocKy = hocKy;
        }

        private void InDanhSachDiemRenLuyen_Load(object sender, EventArgs e)
        {
            string select = "SELECT SINHVIEN.MaSV, HoTen, LOP.TenLop, DIEMRENLUYEN.Diem, UPPER(DONVI.TenDV) COLLATE SQL_Latin1_General_CP1_CI_AS as TenDV, DIEMRENLUYEN.NamHoc, DIEMRENLUYEN.HocKy, ";
            string casewhen = "CASE WHEN DIEMRENLUYEN.Diem < 35 THEN N'Kém' WHEN DIEMRENLUYEN.Diem < 50 THEN N'Yếu' WHEN DIEMRENLUYEN.Diem < 65 THEN N'Trung bình' WHEN DIEMRENLUYEN.Diem < 80 THEN N'Khá' WHEN DIEMRENLUYEN.Diem < 90 THEN N'Tốt' ELSE N'Xuất sắc' END AS XepLoai ";
            string from = "from SINHVIEN, DIEMRENLUYEN, DONVI, LOP, NGANH ";
            string where = $"where SINHVIEN.MaLop = LOP.MaLop and LOP.MaNganh = NGANH.MaNganh and NGANH.MaDV = DONVI.MaDV and DIEMRENLUYEN.MaSV = SINHVIEN.MaSV and SINHVIEN.MaLop = '{MaLop}' and NamHoc = '{NamHoc}' and HocKy = {HocKy}";
            string sql = select + casewhen + from + where;
            DataTable dt = CSDL.LayDuLieu(sql);
            InDanhSachDiemRenLuyen_CrystalReport cry = new InDanhSachDiemRenLuyen_CrystalReport();
            cry.SetDataSource(dt);
            crystalReportViewer1.ReportSource = cry;
        }
    }
}
