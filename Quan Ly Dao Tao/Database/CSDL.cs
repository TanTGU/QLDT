using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Quan_Ly_Dao_Tao.Database
{
    internal class CSDL
    {
        public static string svName = @"THAVICO-0HN4EKU\SQLEXPRESS";
        public static string dbName = "QLDT";
        
        public static string MaGV = "";
        public static string TenHienThi = "";
        public static string LoaiTaiKhoan = "";
        public static SqlConnection cn;

        public static void KetNoi()
        {
            string sql = @"Data Source=" + svName + ";Initial Catalog=" + dbName + ";Integrated Security=True";
            cn = new SqlConnection(sql);

        }
        public static DataTable LayDuLieu(string sql)
        {
            SqlDataAdapter data = new SqlDataAdapter(sql, cn);
            DataTable dt = new DataTable();
            data.Fill(dt);
            return dt;
        }
        public static void XuLy(string sql)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.ExecuteNonQuery();
            cn.Close();
        }
    }
}
