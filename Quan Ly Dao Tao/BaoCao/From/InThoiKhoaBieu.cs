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
    public partial class InThoiKhoaBieu : Form
    {
        string maGV = "";
        public InThoiKhoaBieu(string maGV)
        {
            InitializeComponent();
            this.maGV = maGV;
        }

        private void InThoiKhoaBieu_Load(object sender, EventArgs e)
        {            
            string sql = "select D.MaDV, TenDV, T.MaGV, HoTen, T.MaMH, TenMH, NhomHP, Thu, TietGiangDay, NamHoc, HocKy, GhiChu from GIANGVIEN G, THOIKHOABIEU T, DONVI D, MONHOC M " +
                "where T.MaGV='"+maGV+"' and T.MaGV=G.MaGV and T.MaMH = M.MaMH and G.MaDV = D.MaDV";
            DataTable dt = CSDL.LayDuLieu(sql);
            InThoiKhoaBieu_CrystalReport cry = new InThoiKhoaBieu_CrystalReport();
            cry.SetDataSource(dt);
            crystalReportViewer1.ReportSource = cry;
        }
    }
}
