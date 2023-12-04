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
    public partial class InDanhSachSinhVien : Form
    {
        string MaLop = "";
        public InDanhSachSinhVien(string MaLop)
        {
            InitializeComponent();
            this.MaLop = MaLop;
        }

        private void InDanhSachSinhVien_Load(object sender, EventArgs e)
        {
            string sql = $"select MaSV, SINHVIEN.HoTen, SINHVIEN.GioiTinh, convert(varchar(10), SINHVIEN.NgaySinh, 103) as NgaySinh, TenDV, TenLop, TenNganh, BACDAOTAO.Ma as Bac, GIANGVIEN.HoTen as GVCN  FROM SINHVIEN, LOP, DONVI, NGANH, BACDAOTAO, GIANGVIEN where GIANGVIEN.MaGV = LOP.GVCN and BACDAOTAO.Ma = LOP.BacDaoTao and SINHVIEN.MaLop = LOP.MaLop and SINHVIEN.MaNganh = NGANH.MaNganh and NGANH.MaDV = DONVI.MaDV and LOP.MaLop = '{MaLop}'";
            DataTable dt = CSDL.LayDuLieu(sql);
            InDanhSachSinhVien_CrystalReport cry = new InDanhSachSinhVien_CrystalReport();
            cry.SetDataSource(dt);
            crystalReportViewer1.ReportSource = cry;
        }
    }
}
