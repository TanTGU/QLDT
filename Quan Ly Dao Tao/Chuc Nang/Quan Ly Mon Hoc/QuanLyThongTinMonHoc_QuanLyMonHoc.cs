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
using static System.Net.Mime.MediaTypeNames;

namespace Quan_Ly_Dao_Tao.Chuc_Nang.Quan_Ly_Mon_Hoc
{
    public partial class QuanLyThongTinMonHoc_QuanLyMonHoc : UserControl
    {
        public QuanLyThongTinMonHoc_QuanLyMonHoc()
        {
            InitializeComponent();
        }
        
        private void listDS_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            // Tô màu nền
            e.Graphics.FillRectangle(Brushes.RoyalBlue, e.Bounds);
            // vẽ lại dòng tiêu đề với font in đậm và màu trắng
            e.Graphics.DrawString(e.Header.Text, new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold), Brushes.White, e.Bounds);

        }

        private void listDS_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
            if (e.Item != null)
            {
                if (e.ItemIndex == 0) // Nếu là dòng tiêu đề
                {
                }
                else // Nếu là các dòng dữ liệu
                {
                    // Vẽ các dòng dữ liệu với màu chữ đen và font size nhỏ hơn
                    e.Graphics.DrawString(listDS.Name, new Font(FontFamily.GenericSansSerif, 12), Brushes.Black, e.Bounds.Left, e.Bounds.Top);
                }
            }

        }

        private void QuanLyThongTinMonHoc_QuanLyMonHoc_Load(object sender, EventArgs e)
        {
            CSDL.KetNoi();
            DataTable dt = new DataTable();
            String sql = @"select * from donvi";
            dt = CSDL.LayDuLieu(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbdonvi.Items.Add(dt.Rows[i][1].ToString());              
            }
            
        }

        private void cbdonvi_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dv = cbdonvi.SelectedItem.ToString();
            string sql = "select MaDV from DONVI where TenDV= N'" + dv + "'";
            DataTable dt = new DataTable();
            dt = CSDL.LayDuLieu(sql);
            DataTable dt1 = new DataTable();
            String sql1 = @"select * from NGANH where MaDV='" + dt.Rows[0][0].ToString() + "'";
            dt1 = CSDL.LayDuLieu(sql1);
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                cbnganhhoc.Items.Clear();
                cbnganhhoc.Items.Add(dt1.Rows[i][1].ToString());
                cbnganhhoc1.Items.Add(dt1.Rows[i][1].ToString());
            }
        }

        private void cbnganhhoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dv = cbnganhhoc.SelectedItem.ToString();
            string sql = "select MaMH,TenMH from MONHOC where TenNganh = N'" + dv + "'";
            DataTable dt = new DataTable();
            dt = CSDL.LayDuLieu(sql);
            listDS.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listDS.Items.Add(dt.Rows[i][0].ToString());
                listDS.Items[i].SubItems.Add(dt.Rows[i][1].ToString());               
            }
        }

        private void listDS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listDS.SelectedItems.Count != 0)
            {
                string txt = listDS.SelectedItems[0].SubItems[0].Text;

                string sql = "select * from MONHOC where MaMH='" + txt + "'";
                DataTable dt = new DataTable();
                dt = CSDL.LayDuLieu(sql);
                txtMaHP.Text= dt.Rows[0][0].ToString();
                txttenMH.Text = dt.Rows[0][1].ToString();
                nTinhChi.Text = dt.Rows[0][2].ToString();
                nLythuyet.Text = dt.Rows[0][3].ToString();
                nthucHanh.Text = dt.Rows[0][4].ToString();
                cbnganhhoc1.Text = dt.Rows[0][6].ToString();
                string TQ = dt.Rows[0][5].ToString();
                if(TQ==null)
                {
                    txtMaTQ.Text = "";
                    txttenTQ.Text = "";
                }
                else{
                    string sql1 = "select MaMH,TenMH from MONHOC where MaMH = N'" + TQ + "'";
                    DataTable dt1 = new DataTable();
                    dt1 = CSDL.LayDuLieu(sql1);
                    for (int j = 0; j < dt1.Rows.Count; j++)
                    {
                        txtMaTQ.Text = dt1.Rows[0][0].ToString();
                        txttenTQ.Text = dt1.Rows[0][1].ToString();
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)//tim
        {
            string ma = txtMH.Text;
            string sql = "select * from MONHOC where MaMH='" + ma + "'";
            DataTable dt = new DataTable();
            dt = CSDL.LayDuLieu(sql);
            listDS.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listDS.Items.Add(dt.Rows[i][0].ToString());
                listDS.Items[i].SubItems.Add(dt.Rows[i][1].ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)//them
        {
            string maHP = txtMaHP.Text ;
            string tenHP =txttenMH.Text ;
            string tinchi = nTinhChi.Text ;
            string lt =nLythuyet.Text ;
            string th = nthucHanh.Text ;
            string nganhhoc = cbnganhhoc1.Text;
            string maTQ = txtMaTQ.Text == "" ? "null" : "'" + txtMaTQ.Text + "'";
            string tenTQ =txttenTQ.Text == "" ? "" : "'" + txttenTQ.Text + "'";
            if (maHP == "")
            {
                MessageBox.Show("Vui lòng nhập mã môn học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if (tenHP == "")
            {
                MessageBox.Show("Vui lòng nhập tên môn học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if (tinchi == "")
            {
                MessageBox.Show("Vui lòng nhập số tín chỉ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if (lt == "")
            {
                MessageBox.Show("Vui lòng nhập số tiết lý thuyết!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if (th == "")
            {
                MessageBox.Show("Vui lòng nhập số tiết thực hành!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if (nganhhoc == "")
            {
                MessageBox.Show("Vui lòng nhập ngành học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            string insert = "insert into MONHOC(MaMH, TenMH, SoTC, SoTietLT, SoTietTH, MaMHTienQuyet, TenNganh) ";
            string value = $"values('{maHP}', N'{tenHP}', {tinchi}, {lt}, {th}, {maTQ}, N'{nganhhoc}')";
            string sql = insert + value;
            /*try
            {
                CSDL.XuLy(sql);

                MessageBox.Show("Đã thêm thông tin môn mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Thêm thông tin môn học mới không thành công. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           */
            CSDL.XuLy(sql);
            //CSDL.GhiLenhXuLySQL(sql);
            MessageBox.Show("Đã thêm thông tin môn mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        private void button3_Click(object sender, EventArgs e)//cap nhat/ sua
        {
            string maHP = txtMaHP.Text;
            string tenHP = txttenMH.Text;
            string tinchi = nTinhChi.Text;
            string lt = nLythuyet.Text;
            string th = nthucHanh.Text;
            string nganhhoc = cbnganhhoc1.Text;
            string maTQ = txtMaTQ.Text == "" ? "null" : "'" + txtMaTQ.Text + "'";
            if (maHP == "")
            {
                MessageBox.Show("Vui lòng nhập mã môn học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if (tenHP == "")
            {
                MessageBox.Show("Vui lòng nhập tên môn học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if (tinchi == "")
            {
                MessageBox.Show("Vui lòng nhập số tín chỉ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if (lt == "")
            {
                MessageBox.Show("Vui lòng nhập số tiết lý thuyết!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if (th == "")
            {
                MessageBox.Show("Vui lòng nhập số tiết thực hành!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if (nganhhoc == "")
            {
                MessageBox.Show("Vui lòng nhập ngành học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            string sql = $"update MONHOC set MaMH = '{maHP}',TenMH = N'{tenHP}',SoTC = {tinchi},SoTietLT = {lt},SoTietTH = {th},MaMHTienQuyet = {maTQ},TenNganh = N'{nganhhoc}' where MaMH = '{maHP}'";
            /*try
            {
                CSDL.XuLy(sql);

                MessageBox.Show("Đã sửa  thông tin môn học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Sửa thông tin môn học không thành công. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
            CSDL.XuLy(sql);
            //CSDL.GhiLenhXuLySQL(sql);
            MessageBox.Show("Đã sửa thông tin môn học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button4_Click(object sender, EventArgs e)//xoa
        {
            string maHP = txtMaHP.Text;
            if (maHP=="")
            {
                MessageBox.Show("Vui lòng chọn môn học cần xóa cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            string sql = $"Delete MONHOC where MaMH = '{maHP}'";
            DialogResult result = MessageBox.Show($"Bạn thật sự muốn xóa môn {maHP}?", "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                /*try
                {
                    CSDL.XuLy(sql);
                    //CSDL.GhiLenhXuLySQL(sql);
                    MessageBox.Show("Đã xóa  thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Không thể xóa thông tin môn học!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }*/
                CSDL.XuLy(sql);
                //CSDL.GhiLenhXuLySQL(sql);
                MessageBox.Show("Đã xóa  thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
