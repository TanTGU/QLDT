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

namespace Quan_Ly_Dao_Tao.Chuc_Nang.Quan_Ly_Sinh_Vien
{
    public partial class QuanLyLopHoc_QuanLySinhVien : UserControl
    {
        public QuanLyLopHoc_QuanLySinhVien()
        {
            InitializeComponent();
        }

        void LayDSDonVi()
        {
            string sql = "select *from DONVI";
            DataTable dt = CSDL.LayDuLieu(sql);
            cbDonVi.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbDonVi.Items.Add(dt.Rows[i][1].ToString());
            }
        }
        void LamMoiThongTinLop()
        {
            tbMaLop.Text = "";
            tbTenLop.Text = "";
            tbMaDV.Text = tbMaDV_1.Text;
            tbTenDonVi.Text = tbTenDV_1.Text;
            cbNganh.Text = "";
            cbBac.Text = "";
            tbMaGVCN.Text = "";
            tbTenGVCN.Text = "";
            tbMaNganh_1.Text = "";
            tbTenNganh_1.Text = "";
        }

        void LayDSNganh()
        {
            string sql = "select * from NGANH where MaDV = '" + LayMaDV(cbDonVi.Text) + "'";
            DataTable dt = CSDL.LayDuLieu(sql);
            cbNganh.Items.Clear();
            for(int i = 0; i < dt.Rows.Count;i++)
            {
                cbNganh.Items.Add(dt.Rows[i][1].ToString());
            }
        }

        string LayMaDV(string Ten)
        {
            string sql = "select MaDV from DONVI where TenDV = N'" + Ten + "'";
            DataTable dt = CSDL.LayDuLieu(sql);
            string Ma = "";
            if (dt.Rows.Count > 0)
            {
                Ma = dt.Rows[0][0].ToString();
            }
            return Ma;
        }

        string LayMaLop(string Ten)
        {
            string sql = "select MaLop from LOP where TenLop = N'" + Ten + "'";
            DataTable dt = CSDL.LayDuLieu(sql);
            string Ma = "";
            if (dt.Rows.Count > 0)
            {
                Ma = dt.Rows[0][0].ToString();
            }
            return Ma;
        }
        void LayThongTinDV()
        {
            string sql = "select * from DONVI where TenDV = N'"+cbDonVi.Text+"'";
            DataTable dt = CSDL.LayDuLieu(sql);
            if(dt.Rows.Count > 0)
            {
                tbMaDV_1.Text = dt.Rows[0][0].ToString();
                tbTenDV_1.Text = dt.Rows[0][1].ToString();
                tbSDT.Text = dt.Rows[0][2].ToString();
            }
        }

        string LayMaNganh(string Ten)
        {
            string MaNganh = "";
            string sql = "select * from NGANH where TenNganh = N'"+Ten+"'";
            DataTable dt = CSDL.LayDuLieu(sql);
            if(dt.Rows.Count > 0)
                MaNganh = dt.Rows[0][0].ToString();
            return MaNganh;
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

        private void QuanLyLopHoc_QuanLySinhVien_Load(object sender, EventArgs e)
        {
            LayDSDonVi();
            string sql1 = "select Ten from BACDAOTAO";
            DataTable dt1 = CSDL.LayDuLieu(sql1);
            cbBac.Items.Clear();
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                cbBac.Items.Add(dt1.Rows[i][0].ToString());
            }
        }
        void LayDSLop()
        {
            string MaDV = LayMaDV(cbDonVi.Text);
            string sql = "select LOP. MaLop, LOP.TenLop from LOP, NGANH, DONVI where DONVI.MaDV = NGANH.MaDV and NGANH.MaNganh = LOP.MaNganh and DONVI.TenDV = N'" + cbDonVi.Text + "'";
            DataTable dt = CSDL.LayDuLieu(sql);
            listDS.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listDS.Items.Add(dt.Rows[i][0].ToString());
                listDS.Items[i].SubItems.Add(dt.Rows[i][1].ToString());
            }
        }

        private void cbDonVi_SelectedIndexChanged(object sender, EventArgs e)
        {
            LayDSNganh();
            LayDSLop();
            LayThongTinDV();
            LamMoiThongTinLop();
            tbMaDV_1.Enabled = false;
        }

        private void listDS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listDS.SelectedItems.Count > 0)
            {
                tbMaLop.Text = listDS.SelectedItems[0].SubItems[0].Text;
                tbTenLop.Text = listDS.SelectedItems[0].SubItems[1].Text;
                tbMaDV.Text = LayMaDV(cbDonVi.Text);
                tbTenDonVi.Text = cbDonVi.Text;
                string sql = "select TenNganh, BACDAOTAO.Ten, GVCN, GIANGVIEN.HoTen from LOP, BACDAOTAO, GIANGVIEN, NGANH where LOP.MaNganh = NGANH.MaNganh and LOP.BacDaoTao =BACDAOTAO.Ma and GIANGVIEN.MaGV = LOP.GVCN and LOP.MaLop = '"+tbMaLop.Text+"'";
                DataTable dt = CSDL.LayDuLieu(sql);
                if (dt.Rows.Count > 0)
                {
                    cbNganh.Text = dt.Rows[0][0].ToString();
                    cbBac.Text = dt.Rows[0][1].ToString();
                    tbMaGVCN.Text = dt.Rows[0][2].ToString();
                    tbTenGVCN.Text = dt.Rows[0][3].ToString();
                    tbTenNganh_1.Text = cbNganh.Text;
                    tbMaNganh_1.Text = LayMaNganh(cbNganh.Text);
                }
                else
                {
                    sql = $"select TenNganh, BACDAOTAO.Ten from LOP, BACDAOTAO, NGANH where LOP.MaNganh = NGANH.MaNganh and LOP.BacDaoTao =BACDAOTAO.Ma and LOP.MaLop = '{tbMaLop.Text}'";
                    dt = CSDL.LayDuLieu(sql);
                    if (dt.Rows.Count > 0)
                    {
                        cbNganh.Text = dt.Rows[0][0].ToString();
                        cbBac.Text = dt.Rows[0][1].ToString();
                    }
                }
                tbMaNganh_1.Enabled = false;
                tbMaLop.Enabled = false;
                LayThongTinDV();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            tbMaDV_1.Text = "";
            tbMaDV_1.Enabled = true;

            tbTenDV_1.Text = "";
            tbSDT.Text = "";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            tbMaNganh_1.Text = "";
            tbMaNganh_1.Enabled = true;

            tbTenNganh_1.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tbMaLop.Enabled = true;
            tbMaLop.Text = "";
            tbTenLop.Text = "";
            cbNganh.Text = "";
            cbBac.Text = "";
            tbMaGVCN.Text = "";
            tbTenGVCN.Text = "";

        }

        private bool IsNumericLengthValid(string input, int expectedLength)
        {
            // Kiểm tra xem chuỗi có phải là số không
            if (!long.TryParse(input, out _))
            {
                return false;
            }

            // Kiểm tra chiều dài của chuỗi
            return input.Length == expectedLength;
        }

        bool KiemTraSoDT(string SoDT)
        {
            if (!IsNumericLengthValid(SoDT, 10))
            {
                return true;

            }
            return false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (tbMaDV_1.Text == "" || tbTenDV_1.Text == "" || tbSDT.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if(KiemTraSoDT(tbSDT.Text))
            {
                MessageBox.Show("Số điện thoại phải có định dạng 10 số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbSDT.Focus();
                return;
            }
            try
            {
                string sql = $"insert into DONVI(MaDV, TenDV, SoDT) values('{tbMaDV_1.Text}', N'{tbTenDV_1.Text}', '{tbSDT.Text}')";
                CSDL.XuLy(sql);
                //CSDL.GhiLenhXuLySQL(sql);
                LayDSDonVi();
                tbMaDV_1.Enabled = false;
                MessageBox.Show("Đã thêm thông tin đơn vị mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            catch
            {
                MessageBox.Show("Không thể thêm đơn vị mới. Vui lòng kiểm tra và thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (tbMaDV_1.Text == "" || tbTenDV_1.Text == "" || tbSDT.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if (KiemTraSoDT(tbSDT.Text))
            {
                MessageBox.Show("Số điện thoại phải có định dạng 10 số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbSDT.Focus();
                return;
            }
            try
            {
                string sql = $"UPDATE DONVI SET TenDV = N'{tbTenDV_1.Text}', SoDT = '{tbSDT.Text}' WHERE MaDV = '{tbMaDV_1.Text}'";
                CSDL.XuLy(sql);
                //CSDL.GhiLenhXuLySQL(sql);
                LayDSDonVi();
                tbMaDV_1.Enabled = false;
                MessageBox.Show("Đã cập nhật thông tin đơn vị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            catch
            {
                MessageBox.Show("Không thể cập nhật thông tin đơn vị. Vui lòng kiểm tra và thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbMaDV_1.Text == "" || tbTenDV_1.Text == "")
            {
                MessageBox.Show("Vui lòng chọn đơn vị cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            string sql = $"Delete DONVI where MaDV = '{tbMaDV_1.Text}'";
            DialogResult result = MessageBox.Show($"Bạn thật sự muốn đơn vị {tbTenDV_1.Text}?", "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    CSDL.XuLy(sql);
                    LayDSDonVi();
                    tbMaDV_1.Enabled = false;
                    tbMaDV_1.Text = "";
                    tbTenDV_1.Text = "";
                    //CSDL.GhiLenhXuLySQL(sql);
                    MessageBox.Show("Đã xóa đơn vị thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Không thể xóa thông tin đơn vị!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (tbMaNganh_1.Text == "" || tbTenNganh_1.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if (tbMaDV_1.Text == "" || tbTenDV_1.Text == "")
            {
                MessageBox.Show("Thông tin đơn vị không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                string sql = $"insert into NGANH(MaNganh,TenNganh,MaDV) values('{tbMaNganh_1.Text}', N'{tbTenNganh_1.Text}','{tbMaDV_1.Text}')";
                CSDL.XuLy(sql);
                //CSDL.GhiLenhXuLySQL(sql);
                LayDSNganh();
                tbMaNganh_1.Enabled = false;
                MessageBox.Show("Đã thêm thông tin ngành mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            catch
            {
                MessageBox.Show("Không thể thêm ngành mới. Vui lòng kiểm tra và thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (tbMaNganh_1.Text == "" || tbTenNganh_1.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if (tbMaDV_1.Text == "" || tbTenDV_1.Text == "")
            {
                MessageBox.Show("Thông tin đơn vị không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                string sql = $"UPDATE NGANH SET TenNganh = N'{tbTenNganh_1.Text}', MaDV = '{tbMaDV.Text}' WHERE MaNganh = '{tbMaNganh_1.Text}';";
                CSDL.XuLy(sql);
                //CSDL.GhiLenhXuLySQL(sql);
                LayDSNganh();
                tbMaNganh_1.Enabled = false;
                MessageBox.Show("Đã cập nhật thông tin ngành!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            catch
            {
                MessageBox.Show("Không thể cập nhật thông tin ngành. Vui lòng kiểm tra và thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (tbMaNganh_1.Text == "" || tbTenNganh_1.Text == "")
            {
                MessageBox.Show("Vui lòng chọn ngành cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            string sql = $"DELETE FROM NGANH WHERE MaNganh = '{tbMaNganh_1.Text}'";
            DialogResult result = MessageBox.Show($"Bạn thật sự muốn ngành {tbTenNganh_1.Text}?", "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    CSDL.XuLy(sql);
                    LayDSNganh();
                    tbMaNganh_1.Enabled = false;
                    //CSDL.GhiLenhXuLySQL(sql);
                    tbMaNganh_1.Text = "";
                    tbTenNganh_1.Text = "";
                    MessageBox.Show("Đã xóa thông tin ngành thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Không thể xóa thông tin ngành!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        bool KiemTraDuLieuTrong()
        {
            if(tbMaLop.Text == "" || tbTenLop.Text == "" || tbMaDV.Text == "" || cbNganh.Text == "" || cbBac.Text == "")
                return true;
            return false;
        }
        bool KiemTraGVCN(string MaGV, string MaDV)
        {
            string sql = $"select * from GIANGVIEN where MaGV = '{MaGV}' and MaDV = '{MaDV}'";
            DataTable dt = CSDL.LayDuLieu(sql);
            if(dt.Rows.Count == 0)
                return true;
            return false;
        }

        string LayMaBacDaoTao(string Ten)
        {
            string result = "";
            string sql = $"select Ma from BACDAOTAO where Ten = N'{Ten}'";
            DataTable dt = CSDL.LayDuLieu(sql);
            if (dt.Rows.Count > 0)
                result = dt.Rows[0][0].ToString();
            return result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(KiemTraDuLieuTrong())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắc buộc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if(tbMaGVCN.Text != "")
                if(KiemTraGVCN(tbMaGVCN.Text, tbMaDV.Text))
                {
                    MessageBox.Show("Thông tin GVCN không chính xác hoặc không thuộc đơn vị này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            try
            {
                string GVCN = (tbMaGVCN.Text == "" ? "null" : "'" + tbMaGVCN.Text + "'");
                string sql = $"insert into LOP(MaLop, TenLop, MaNganh, BacDaoTao, HinhThucDaoTao, GVCN) values('{tbMaLop.Text}', N'{tbTenLop.Text}', '{tbMaNganh_1.Text}', '{LayMaBacDaoTao(cbBac.Text)}', 'CQ', {GVCN})";
                CSDL.XuLy(sql);
                //CSDL.GhiLenhXuLySQL(sql);
                LayDSLop();
                MessageBox.Show("Đã thêm thông tin lớp mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            catch
            {
                MessageBox.Show("Thêm lớp mới không thành công. Vui lòng kiểm tra và thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        void LayThongTinNganh(string TenNganh)
        {
            string sql = $"select * from NGANH where TenNganh = N'{TenNganh}'";
            DataTable dt = CSDL.LayDuLieu(sql);
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                tbMaNganh_1.Text = dt.Rows[i][0].ToString();
                tbTenNganh_1.Text = dt.Rows[i][1].ToString();
                tbMaNganh_1.Enabled = false;
            }
        }

        private void cbNganh_SelectedIndexChanged(object sender, EventArgs e)
        {
            LayThongTinNganh(cbNganh.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (KiemTraDuLieuTrong())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắc buộc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if (tbMaGVCN.Text != "")
                if (KiemTraGVCN(tbMaGVCN.Text, tbMaDV.Text))
                {
                    MessageBox.Show("Thông tin GVCN không chính xác hoặc không thuộc đơn vị này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            try
            {
                string GVCN = (tbMaGVCN.Text == "" ? "null" : "'" + tbMaGVCN.Text + "'");
                string sql = $"UPDATE LOP SET TenLop = N'{tbTenLop.Text}', MaNganh = '{tbMaNganh_1.Text}', BacDaoTao = '{LayMaBacDaoTao(cbBac.Text)}', HinhThucDaoTao = 'CQ', GVCN = {GVCN} WHERE MaLop = '{tbMaLop.Text}'";
                CSDL.XuLy(sql);
                //CSDL.GhiLenhXuLySQL(sql);
                LayDSLop();
                MessageBox.Show("Đã cập nhật thông tin lớp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            catch
            {
                MessageBox.Show("Cập nhật thông tin lớp không thành công. Vui lòng kiểm tra và thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(tbMaLop.Text == "" || tbTenLop.Text == "")
            {
                MessageBox.Show("Vui lòng chọn lớp cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            string sql = $"DELETE FROM LOP WHERE MaLop = '{tbMaLop.Text}'";
            DialogResult result = MessageBox.Show($"Bạn thật sự muốn lớp {tbTenLop.Text}?", "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    CSDL.XuLy(sql);
                    LayDSLop();
                    tbMaLop.Enabled = false;
                    //CSDL.GhiLenhXuLySQL(sql);
                    tbMaLop.Text = "";
                    tbTenLop.Text = "";
                    tbMaGVCN.Text = "";
                    tbTenGVCN.Text = "";
                    cbNganh.Text = "";
                    cbBac.Text = "";
                    MessageBox.Show("Đã xóa thông tin lớp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Không thể xóa thông tin lớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tbMaGVCN_Leave(object sender, EventArgs e)
        {
            if(tbMaDV.Text == "")
            {
                MessageBox.Show("Vui lòng chọn thông tin đơn vị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if (tbMaGVCN.Text == "")
                tbTenGVCN.Text = "";
            else
            {
                string sql = $"select HoTen, MaDV from GIANGVIEN where MaGV = '{tbMaGVCN.Text}'";
                DataTable dt = CSDL.LayDuLieu(sql);
                if(dt.Rows.Count > 0)
                {
                    if (dt.Rows[0][1].ToString() != tbMaDV.Text)
                    {
                        MessageBox.Show($"Giảng viên {dt.Rows[0][0].ToString()} không thuộc đơn vị này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        tbTenGVCN.Text = dt.Rows[0][0].ToString();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin giáo viên chủ nhiệm. Vui lòng kiểm tra và thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
