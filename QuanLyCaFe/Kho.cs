using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DTO;
using BUS;
using System.Globalization;

namespace QuanLyCaFe
{
    public partial class Kho : Form
    {
        List<PhieuNhap_DTO> listpn = null;
        List<NhanVien_DTO> listnv = null;
        List<NguyenLieu_DTO> listnl = null;
        List<CTPhieuNhap_DTO> listctpn = null;

        private string _message;
        public Kho()
        {
            InitializeComponent();
            LoadDSNL();
        }
        private void Load_fromNhapHang()
        {
           

            PhieuNhap_BUS pn = new PhieuNhap_BUS();
            listpn = pn.LayDanhSachPhieuNhap();
            dgvHD.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHD.RowHeadersVisible = false;
            dgvHD.AutoGenerateColumns = false;
            dgvHD.DataSource = listpn;

            NhanVien_BUS nv = new NhanVien_BUS();
            listnv = nv.LayDanhSach();

            for (int i = 0; i < listnv.Count; i++)
            {
                if (listnv[i].MaNV.ToString() == txtMaNhanVien.Text)
                {
                    txtTenNV.Text = listnv[i].MaNV.ToString();
                    txtTenNhanVien.Text = listnv[i].MaNV.ToString();
                    break;
                }

            }
        }
        public Kho(string Message) : this()
        {
            _message = Message;
            txtMaNhanVien.Text = _message;
        }
        private void Load_fromCTNhapHang()
        {
            

            CTPhieuNhap_BUS ctpn = new CTPhieuNhap_BUS();
            listctpn = ctpn.LayDanhSachCTPN();

            dtgCTPN.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgCTPN.RowHeadersVisible = false;
            dtgCTPN.AutoGenerateColumns = false;
            dtgCTPN.DataSource = listctpn;


        }
        private void tabKho_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            NhaCungCap_BUS ncc = new NhaCungCap_BUS();
            cbbNCC.DataSource = ncc.LayDanhSachNhaCungCap();
            cbbNCC.DisplayMember = "TenNhaCC";
            cbbNCC.ValueMember = "MaNhaCC";
            NguyenLieu_BUS nl = new NguyenLieu_BUS();
            cbbTenNL.DataSource = nl.LayDanhSachNguyenLieu();
            cbbTenNL.DisplayMember = "TenNguyenLieu";
            cbbTenNL.ValueMember = "MaNL";
            Load_fromNhapHang();
        }
        
        private void ThongTinNhanVien()
        {
            NhanVien_BUS nv = new NhanVien_BUS();
            listnv = nv.LayDanhSach();

            for (int i = 0; i < listnv.Count; i++)
            {
                if (listnv[i].MaNV.ToString() == txtMaNhanVien.Text.ToString() && listnv[i].ChucVu == "Kho")
                {
                    txtHoNhanVien.Text = listnv[i].HoNV.ToString();
                    txtTenDem.Text = listnv[i].TenDem.ToString();
                    txtTenNhanVien.Text = listnv[i].TenNV.ToString();
                    txtEmail.Text = listnv[i].Email.ToString();
                    //DateTime dt = DateTime.ParseExact(listNV[i].NgaySinh.ToString(), "yyyy-MM-dd h:mm:ss tt", CultureInfo.InvariantCulture);
                    dTPNgaySinh.Value = DateTime.ParseExact(listnv[i].NgaySinh.ToString(), "yyyy-MM-dd h:mm:ss tt", CultureInfo.InvariantCulture);
                    dTPNgayThem.Value = DateTime.ParseExact(listnv[i].NgayThem.ToString(), "yyyy-MM-dd h:mm:ss tt", CultureInfo.InvariantCulture);
                    cbbChucVu.SelectedItem = listnv[i].ChucVu.ToString();
                    if (listnv[i].GioiTinh.ToString() == "Nam")
                    {
                        radNam.Checked = true;
                    }
                    else
                    {
                        radNu.Checked = true;
                    }
                    txtSoDienThoai.Text = listnv[i].SDT.ToString();
                }
            }
        }
        
        private void btnThemNL_Click(object sender, EventArgs e)
        {

        }
        private void Kho_Load(object sender, EventArgs e)
        {
            string[] s = { "Quản Lí", "Thu Ngân", "Pha Chế", "Kho" };
            cbbChucVu.Items.AddRange(s);
            ThongTinNhanVien();
        }

        private void btnTao_Click(object sender, EventArgs e)
        {

            if (txtTenNV.Text.Trim() == "")
            {
                MessageBox.Show("Chưa Nhập Tên Nhân Viên", "Thông Báo", MessageBoxButtons.OK);
                txtTenNV.Focus();
                return;
            }
            if (cbbNCC.Text.Trim() == "")
            {
                MessageBox.Show("Chưa Nhập Tên Nhà Cung Cấp", "Thông Báo", MessageBoxButtons.OK);
                cbbNCC.Focus();
                return;
            }
            if (dTPNgayTao.Text.Trim() == "")
            {
                MessageBox.Show("Chưa Nhập Ngày Tạo", "Thông Báo", MessageBoxButtons.OK);
                dTPNgayTao.Focus();
                return;
            }
            PhieuNhap_DTO npThem = new PhieuNhap_DTO();

            npThem.NgayTaoPN = (DateTime)dTPNgayTao.Value;
            npThem.MaNhanVien = int.Parse(txtTenNV.Text);
            npThem.MaNhaCungCap = int.Parse(cbbNCC.SelectedValue.ToString().Trim());
            npThem.TongTien = (decimal)long.Parse("0");
            PhieuNhap_BUS pn = new PhieuNhap_BUS();
            pn.ThemDanhSachPN(npThem,1);

            Load_fromNhapHang();
            txtTongTien.Text = "0";

            btnTao.Enabled = false;
            btnThemHD.Enabled = true;
            btnLuu.Enabled = true;
        }

        private void cbbTenNL_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            NguyenLieu_BUS nl = new NguyenLieu_BUS();
            listnl = nl.LayDanhSachNguyenLieu();

            for (int i = 0; i < listnl.Count; i++)
            {
                if (listnl[i].MaNL.ToString() == cbbTenNL.SelectedValue.ToString())
                {
                    txtDonGia.Text = listnl[i].DonGiaNL.ToString();
                }
            }

            TinhThanhTien();
        }
        private void TinhThanhTien()
        {
            if (txtSL.Text == "" || txtDonGia.Text == "")
            {
                txtThanhTien.Text = "";
            }
            else
            {
                double soThuNhat = double.Parse(txtDonGia.Text);
                double soThuHai = double.Parse(txtSL.Text);
                double kq = soThuHai * soThuNhat;
                txtThanhTien.Text = kq.ToString();
            }
        }

        private void txtSL_TextChanged(object sender, EventArgs e)
        {
            TinhThanhTien();
        }

        private void btnThemHD_Click(object sender, EventArgs e)
        {
            if (txtMaPN.Text.Trim() == "")
            {
                MessageBox.Show("Chưa Nhập Mã Phiếu", "Thông Báo", MessageBoxButtons.OK);
                txtMaPN.Focus();
                return;
            }
            if (cbbTenNL.Text.Trim() == "")
            {
                MessageBox.Show("Chưa Nhập Tên Nguyên Liệu", "Thông Báo", MessageBoxButtons.OK);
                cbbTenNL.Focus();
                return;
            }

            if (txtSL.Text.Trim() == "")
            {
                MessageBox.Show("Chưa Nhập Số Lượng", "Thông Báo", MessageBoxButtons.OK);
                txtSL.Focus();
                return;
            }

            CTPhieuNhap_DTO ctpnThem = new CTPhieuNhap_DTO();
            ctpnThem.MaPhieuNhap = int.Parse(txtMaPN.Text);
            ctpnThem.MaNguyenLieu = int.Parse(cbbTenNL.SelectedValue.ToString());
            //npThem.MaPN = int.Parse("1");
            ctpnThem.SoLuong = int.Parse(txtSL.Text);
            ctpnThem.DonGiaCTPN = (decimal)double.Parse(txtDonGia.Text);
            ctpnThem.ThanhTien = (decimal)double.Parse(txtThanhTien.Text);
            CTPhieuNhap_BUS ctpn = new CTPhieuNhap_BUS();
            ctpn.ThemDanhSachCTPN(ctpnThem,1);

            Load_fromCTNhapHang();
            double TongTien = double.Parse(txtTongTien.Text);
            double thanhtien = double.Parse(txtThanhTien.Text);
            double kq = TongTien + thanhtien;
            txtTongTien.Text = kq.ToString();
            
        }

        private void btnLưu_Click(object sender, EventArgs e)
        {
           

            PhieuNhap_DTO npluu = new PhieuNhap_DTO();
            npluu.NgayTaoPN = (DateTime)dTPNgayTao.Value;
            npluu.MaNhanVien = int.Parse(txtTenNV.Text);
            //npThem.MaPN = int.Parse("1");
            npluu.MaNhaCungCap = int.Parse(cbbNCC.SelectedValue.ToString().Trim());
            npluu.TongTien = (decimal)long.Parse(txtTongTien.Text);
            CTPhieuNhap_BUS ctpn = new CTPhieuNhap_BUS();
            ctpn.LuuTongTienCTPhieuNhap(int.Parse(txtMaPN.Text));

            Load_fromNhapHang();
        }

        private void txtTenNV_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvHD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvHD.CurrentRow.Index;
            txtMaPN.Text = dgvHD.Rows[i].Cells[0].Value.ToString();


        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (txtMaPN.Text.Trim() == "")
            {
                MessageBox.Show("Chưa Nhập Mã Phiếu", "Thông Báo", MessageBoxButtons.OK);
                txtMaPN.Focus();
                return;
            }
            Load_timCTNhapHang();
        }
        private void Load_timCTNhapHang()
        {
            
            CTPhieuNhap_BUS ctpnBUS = new CTPhieuNhap_BUS();
            List<CTPhieuNhap_DTO> listctpn = new List<CTPhieuNhap_DTO>();
            listctpn = ctpnBUS.TimCTPhieuNhap(int.Parse(txtMaPN.Text));
            dtgCTPN.DataSource = listctpn;
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            DoiMatKhau frm = new DoiMatKhau(txtMaNhanVien.Text);
            frm.Show();
            this.Hide();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangNhap frm = new DangNhap();
            frm.Show();
        }

        private void btnThoatThongTin_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangNhap frm = new DangNhap();
            frm.Show();
        }

        private void btnThoatNL_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangNhap frm = new DangNhap();
            frm.Show();
        }
        private void LoadDSNL()
        {
            NguyenLieu_BUS nl = new NguyenLieu_BUS();
            List<NguyenLieu_DTO> dsnl = nl.LayDanhSachNguyenLieu();

            dataGridViewQLNguyenLieu.MultiSelect = false;
            dataGridViewQLNguyenLieu.AutoGenerateColumns = false;
            dataGridViewQLNguyenLieu.DataSource = dsnl;
            dataGridViewQLNguyenLieu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //dataGridViewQlSanPham.ReadOnly = true;
            dataGridViewQLNguyenLieu.RowHeadersVisible = false;
        }

        private void dataGridViewQLNguyenLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewQLNguyenLieu.SelectedRows.Count > 0)
            {
                NguyenLieu_DTO nl = (NguyenLieu_DTO)dataGridViewQLNguyenLieu.SelectedRows[0].DataBoundItem;

                txtMaNLKho.Text = nl.MaNL.ToString();
                txtTenNLKho.Text = nl.TenNguyenLieu.ToString();
                txtDonViTinhKho.Text = nl.DonViTinh.ToString();
                txtDonGiaNL.Text = nl.DonGiaNL.ToString();
            }
        }

        private void btnTimKiemNL_Click(object sender, EventArgs e)
        {
            List<NguyenLieu_DTO> listnl = new List<NguyenLieu_DTO>();
            NguyenLieu_BUS nl = new NguyenLieu_BUS();
            listnl = nl.TimTheoMaNL(txtMaNLTimKiem.Text);
            dataGridViewQLNguyenLieu.DataSource = listnl;
        }

        private void Kho_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            DangNhap frm = new DangNhap();
            frm.Show();
        }

        private void Kho_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có thật sự muốn thoát?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                DangNhap frm = new DangNhap();
                frm.Show();
                this.Hide();
            }
        }
    }
}
