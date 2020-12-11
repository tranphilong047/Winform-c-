using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using System.Diagnostics.Tracing;
using System.Globalization;
using System.IO;

namespace QuanLyCaFe
{
    public partial class QuanLy : Form
    {   
        string imageName = "";
        string imagePath = "";
        private string _message;

        public QuanLy()
        {
            InitializeComponent();
            

        }
        #region NhanVien
        public void Enabledcontrol()
        {
            txtHoNhanVien.Enabled = false;
            txtTenDem.Enabled = false;
            txtTenNhanVien.Enabled = false;
            dateTimeNgaySinh.Enabled = false;
            cbbGioiTinh.Enabled = false;
            cbbChucVu.Enabled = false;
            dateTimeNgayThem.Enabled = false;
            txtSoDienThoai.Enabled = false;
            txtEmail.Enabled = false;
            txtPass.Enabled = false;
        }
        private void LoadDSNV()
        { 
            cbbChucVu.Items.Add("Thu Ngân");
            cbbChucVu.Items.Add("Quản Lý");
            cbbChucVu.Items.Add("Kho");
            cbbChucVu.Items.Add("Pha Chế");


            cbbGioiTinh.Items.Add("Nam");
            cbbGioiTinh.Items.Add("Nữ");

            //Enabledcontrol();
           

            NhanVien_BUS nv = new NhanVien_BUS();
            List<NhanVien_DTO> dsnv = nv.LayDanhSach();
            dataGridViewQLNhanVien.MultiSelect = false;
            dataGridViewQLNhanVien.AutoGenerateColumns = false;
            dataGridViewQLNhanVien.DataSource = dsnv;

            dataGridViewQLNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //dataGridViewQLNhanVien.ReadOnly = true;
            dataGridViewQLNhanVien.RowHeadersVisible = false;
            

        }
        private void ResetNV()
        {
            txtMaNhanVien.Text = "";
            txtHoNhanVien.Text = "";
            txtTenDem.Text = "";
            txtTenNhanVien.Text = "";
            dateTimeNgaySinh.Text = "";
            txtSoDienThoai.Text = "";
            txtEmail.Text = "";
            dateTimeNgayThem.Text = "";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (dataGridViewQLNhanVien.SelectedRows.Count > 0)
            {
                NhanVien_DTO nv = (NhanVien_DTO)dataGridViewQLNhanVien.SelectedRows[0].DataBoundItem;

                if (MessageBox.Show("Bạn có chắc muốn xóa Nhân Viên " + nv.MaNV + " không?", "Cảnh báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    NhanVien_BUS nv1 = new NhanVien_BUS();
                    nv1.XoaNhanVien(nv);
                    MessageBox.Show("Đã xóa thành công sinh viên");
                    LoadDSNV();
                    ResetNV();
                }
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtHoNhanVien.Text.Trim() == "" ||
                txtHoNhanVien.Text.Trim() == "" ||
               txtTenDem.Text.Trim() == "" ||
               txtTenNhanVien.Text.Trim() == "" ||
               txtSoDienThoai.Text.Trim() == "" ||
               txtEmail.Text.Trim() == "" ||
               txtPass.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập đầy đủ thông tin", "Thông báo");
            }
            else
            {
                NhanVien_DTO nv = new NhanVien_DTO();
                nv.HoNV = txtHoNhanVien.Text;
                nv.TenDem = txtTenDem.Text;
                nv.TenNV = txtTenNhanVien.Text;
                nv.NgaySinh = dateTimeNgaySinh.Value;
                nv.GioiTinh = cbbGioiTinh.Text;
                nv.SDT = txtSoDienThoai.Text;
                nv.Email = txtEmail.Text;
                nv.ChucVu = cbbChucVu.Text;
                nv.NgayThem = dateTimeNgayThem.Value;
                nv.Pass = txtPass.Text;

                NhanVien_BUS dtBus = new NhanVien_BUS();
                dtBus.ThemNhanVien(nv, 1);
                MessageBox.Show("Đã Thêm 1 nhân viên mới");
                LoadDSNV();
                ResetNV();
            }
            
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetNV();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {

            if (dataGridViewQLNhanVien.SelectedRows.Count > 0)
            {
                NhanVien_DTO nv = (NhanVien_DTO)dataGridViewQLNhanVien.SelectedRows[0].DataBoundItem;

                
                nv.HoNV = txtHoNhanVien.Text;
                nv.TenDem = txtTenDem.Text;
                nv.TenNV = txtTenNhanVien.Text;
                nv.NgaySinh = dateTimeNgaySinh.Value;
                nv.GioiTinh = cbbGioiTinh.Text;
                nv.SDT = txtSoDienThoai.Text;
                nv.Email = txtEmail.Text;
                nv.ChucVu = cbbChucVu.Text;
                nv.NgayThem = dateTimeNgayThem.Value;
                nv.Pass = txtPass.Text;

                NhanVien_BUS dtBus = new NhanVien_BUS();
                dtBus.SuaNhanVien(nv);
                MessageBox.Show("Đã Sữa 1 nhân viên ");
                LoadDSNV();
                ResetNV();
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangNhap frm = new DangNhap();
            frm.Show();
            
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("BẠN MUỐN kẾT THÚC?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // đóng form
                this.Close();
            }
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            List<NhanVien_DTO> listnv = new List<NhanVien_DTO>();
            NhanVien_BUS nv = new NhanVien_BUS();
            listnv = nv.TimNhanVienTheoMa(txtTimKiemMa.Text);
            dataGridViewQLNhanVien.DataSource = listnv;
        }
        private void btnHuyTimKiem_Click(object sender, EventArgs e)
        {
            LoadDSNV();
        }
        private void dataGridViewQLNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewQLNhanVien.SelectedRows.Count > 0)
            {
                NhanVien_DTO nv = (NhanVien_DTO)dataGridViewQLNhanVien.SelectedRows[0].DataBoundItem;
                txtMaNhanVien.Text = nv.MaNV.ToString();
                txtHoNhanVien.Text = nv.HoNV.ToString();
                txtTenDem.Text = nv.TenDem.ToString();
                txtTenNhanVien.Text = nv.TenNV.ToString();
                cbbGioiTinh.Text = nv.GioiTinh.ToString();
                cbbChucVu.Text = nv.ChucVu.ToString();
                dateTimeNgaySinh.Text = nv.NgaySinh.ToString("yyyy/MM/dd");
                txtSoDienThoai.Text = nv.SDT.ToString();
                txtEmail.Text = nv.Email.ToString();
                txtPass.Text = nv.Pass.ToString();
                dateTimeNgayThem.Text = nv.NgayThem.ToString("yyyy/MM/dd");
            }
        }

        #endregion
        #region SanPham
        private void LoadDSSP()
        {
            SanPham_BUS sp = new SanPham_BUS();
            List<SanPham_DTO> dssp = sp.LayDanhSachSanPham();
            dataGridViewQlSanPham.MultiSelect = false;
            dataGridViewQlSanPham.AutoGenerateColumns = false;
            dataGridViewQlSanPham.DataSource = dssp;
            dataGridViewQlSanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //dataGridViewQlSanPham.ReadOnly = true;
            dataGridViewQlSanPham.RowHeadersVisible = false;
        }
        private void ResetSP()
        {
            txtMaSanPham.Text = "";
            txtTenSanPham.Text = "";
            txtLoaiSanPham.Text = "";
            txtDonGia.Text = "";
            dateTimeNgayTapSP.Text = "";
            lblTenSanPham.Text = "";
            ptbSanPham.Image = null;
        }
        private void btnXoaSanPham_Click(object sender, EventArgs e)
        {
            if (dataGridViewQlSanPham.SelectedRows.Count > 0)
            {
                SanPham_DTO sp = (SanPham_DTO)dataGridViewQlSanPham.SelectedRows[0].DataBoundItem;

                if (MessageBox.Show("Bạn có chắc muốn xóa sản phẩm " + sp.MaSP + " không?", "Cảnh báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    SanPham_BUS sp1 = new SanPham_BUS();
                    sp1.XoaSanPham(sp);
                    MessageBox.Show("Đã xóa thành công sản phẩm");
                    LoadDSSP();
                    ResetSP();
                }
            }
        }
        private void btnThoatfrmSanPham_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("BẠN MUỐN kẾT THÚC?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // đóng form
                this.Close();
            }
        }
        private void btnBackSanPhan_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangNhap frm = new DangNhap();
            frm.Show();
        }
        private void btnResetSanPham_Click(object sender, EventArgs e)
        {
            ResetSP();
        }
        private void ptbSanPham_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "JPG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|JPEG Files (*.jpeg)|*.jpeg|GIF Files (*.gif)|*.gif|All files (*.*)|*.*";
            dialog.InitialDirectory = @"C:\";
            dialog.Title = "Choose icon for football club";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap bmp = new Bitmap(dialog.FileName);
                ptbSanPham.Image = bmp;
                imageName = dialog.SafeFileName;
                imagePath = dialog.FileName;
            }
        }
        private void btnThemSanPham_Click(object sender, EventArgs e)
        {
            if (txtTenSanPham.Text.Trim() == "" ||
                txtLoaiSanPham.Text.Trim() == "" ||
               txtDonGia.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập đầy đủ thông tin", "Thông báo");
            }
            else
            {
                SanPham_DTO sp = new SanPham_DTO();
                sp.TenSP = txtTenSanPham.Text;
                sp.LoaiSP = txtLoaiSanPham.Text;
                sp.DonGia = decimal.Parse(txtDonGia.Text);
                sp.IconUrl = imageName;
                sp.NgayTao = dateTimeNgayTapSP.Value;

                if (imagePath != "")
                {
                    DirectoryInfo di = Directory.CreateDirectory("data/hinhanh");
                    string path = System.IO.Path.Combine(di.FullName, imageName);
                    System.IO.File.Copy(imagePath, path, true);
                }

                SanPham_BUS dtBus = new SanPham_BUS();
                dtBus.ThemSanPham(sp, 1);
                MessageBox.Show("Đã Thêm 1 Sản Phẩm mới");
                LoadDSSP();
                ResetSP();
            }
        }
        private void btnSuaSanPham_Click(object sender, EventArgs e)
        {
            if (dataGridViewQlSanPham.SelectedRows.Count > 0)
            {
                SanPham_DTO sp = (SanPham_DTO)dataGridViewQlSanPham.SelectedRows[0].DataBoundItem;
                sp.TenSP = txtTenSanPham.Text;
                sp.LoaiSP = txtLoaiSanPham.Text;
                sp.DonGia = decimal.Parse(txtDonGia.Text);
                sp.NgayTao = dateTimeNgayTapSP.Value;


                SanPham_BUS spBus = new SanPham_BUS();
                spBus.SuaThongTinSanPham(sp);
                MessageBox.Show("Đã Sửa 1 Sản Phẩm ");
                LoadDSSP();
                ResetSP();
            }
        }
        private void btnTimKiemSP_Click(object sender, EventArgs e)
        {
            List<SanPham_DTO> listsp = new List<SanPham_DTO>();
            SanPham_BUS sp = new SanPham_BUS();
            listsp = sp.TimSanPhamTheoMa(txtTimKiemSP.Text);
            dataGridViewQlSanPham.DataSource = listsp;
        }
        private void btnBackSP_Click(object sender, EventArgs e)
        {
            LoadDSSP();
        }
        private void dataGridViewQlSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewQlSanPham.SelectedRows.Count > 0)
            {
                SanPham_DTO sp = (SanPham_DTO)dataGridViewQlSanPham.SelectedRows[0].DataBoundItem;

                txtMaSanPham.Text = sp.MaSP.ToString();
                txtTenSanPham.Text = sp.TenSP.ToString();
                txtLoaiSanPham.Text = sp.LoaiSP.ToString();
                txtDonGia.Text = sp.DonGia.ToString();
                dateTimeNgayTapSP.Text = sp.NgayTao.ToString("yyyy/MM/dd");
                lblTenSanPham.Text = sp.TenSP.ToString();
                ptbSanPham.Image = Image.FromFile("data\\hinhanh\\" + sp.IconUrl.ToString());
            }
        }
        private void dataGridViewQlSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        #endregion
        #region NguyenLieu
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
        private void ResetNL()
        {
            txtMaNguyenLieu.Text = "";
            txtTenNguyenLieu.Text = "";
            txtDonViTinh.Text = "";
            txtDonGiaNguyenLieu.Text = "";

        }
        private void btnThemNL_Click(object sender, EventArgs e)
        {
            if (txtTenNguyenLieu.Text.Trim() == "" ||
                txtDonViTinh.Text.Trim() == "" ||
               txtDonGiaNguyenLieu.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập đầy đủ thông tin", "Thông báo");
            }
            else
            {
                NguyenLieu_DTO nl = new NguyenLieu_DTO();
                nl.TenNguyenLieu = txtTenNguyenLieu.Text;
                nl.DonViTinh = txtDonViTinh.Text;
                nl.DonGiaNL = decimal.Parse(txtDonGiaNguyenLieu.Text);
            

                NguyenLieu_BUS dtBus = new NguyenLieu_BUS();
                dtBus.ThemNguyenLieu(nl, 1);
                MessageBox.Show("Đã Thêm 1 Nguyên Liệu mới");
                LoadDSNL();
                ResetNL();
            }
            
        }

        private void btnXoaNL_Click(object sender, EventArgs e)
        {
            if (dataGridViewQLNguyenLieu.SelectedRows.Count > 0)
            {
                NguyenLieu_DTO nl = (NguyenLieu_DTO)dataGridViewQLNguyenLieu.SelectedRows[0].DataBoundItem;

                if (MessageBox.Show("Bạn có chắc muốn xóa sản phẩm " + nl.MaNL + " không?", "Cảnh báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    NguyenLieu_BUS nl1 = new NguyenLieu_BUS();
                    nl1.XoaNguyenLieu(nl);
                    MessageBox.Show("Đã xóa thành công sản phẩm");
                    LoadDSNL();
                    ResetNL();
                }
            }
        }

        private void btnResetNL_Click(object sender, EventArgs e)
        {
            ResetNL();
        }

        private void btnSuaNL_Click(object sender, EventArgs e)
        {
            if (dataGridViewQLNguyenLieu.SelectedRows.Count > 0)
            {
                NguyenLieu_DTO nl = (NguyenLieu_DTO)dataGridViewQLNguyenLieu.SelectedRows[0].DataBoundItem;
                nl.TenNguyenLieu = txtTenNguyenLieu.Text;
                nl.DonViTinh = txtDonViTinh.Text;
                nl.DonGiaNL = decimal.Parse(txtDonGiaNguyenLieu.Text);


                NguyenLieu_BUS dtBus = new NguyenLieu_BUS();
                dtBus.SuaThongTinNguyenLieu(nl);
                MessageBox.Show("Đã Sữa 1 Nguyên Liệu ");
                LoadDSNL();
                ResetNL();
            }
        }

        private void btnBackNL_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangNhap frm = new DangNhap();
            frm.Show();
        }

        private void btnThoatNL_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("BẠN MUỐN kẾT THÚC?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // đóng form
                this.Close();
            }
        }
        private void btnTimKiemNL_Click(object sender, EventArgs e)
        {
            List<NguyenLieu_DTO> listnl = new List<NguyenLieu_DTO>();
            NguyenLieu_BUS nl = new NguyenLieu_BUS();
            listnl = nl.TimTheoMaNL(txtMaNLTimKiemQL.Text);
            dataGridViewQLNguyenLieu.DataSource = listnl;
        }
        private void btnHuyTimKiemNL_Click(object sender, EventArgs e)
        {
            LoadDSNL();
        }
        private void dataGridViewQLNguyenLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewQLNguyenLieu.SelectedRows.Count > 0)
            {
                NguyenLieu_DTO nl = (NguyenLieu_DTO)dataGridViewQLNguyenLieu.SelectedRows[0].DataBoundItem;

                txtMaNguyenLieu.Text = nl.MaNL.ToString();
                txtTenNguyenLieu.Text = nl.TenNguyenLieu.ToString();
                txtDonViTinh.Text = nl.DonViTinh.ToString();
                txtDonGiaNguyenLieu.Text = nl.DonGiaNL.ToString();
            }
        }
        private void dataGridViewQLNguyenLieu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        #endregion
        #region NhaCungCap
        private void LoadDSNCC()
        {
            NhaCungCap_BUS ncc = new NhaCungCap_BUS();
            List<NhaCungCap_DTO> dsncc = ncc.LayDanhSachNhaCungCap();


            dataGridViewQLNhaCungCap.MultiSelect = false;
            dataGridViewQLNhaCungCap.AutoGenerateColumns = false;
            dataGridViewQLNhaCungCap.DataSource = dsncc;
            dataGridViewQLNhaCungCap.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewQLNhaCungCap.RowHeadersVisible = false;
        }
        private void ResetNCC()
        {
            txtMaNhaCungCap.Text = "";
            txtTenNhaCungCap.Text = "";
            txtSoDTNCC.Text = "";
            txtEmailNCC.Text = "";
            txtTimKiemNCC.Text = "";
        }
        private void btnThemNCC_Click(object sender, EventArgs e)
        {
            if (txtTenNhaCungCap.Text.Trim() == "" ||
                txtSoDTNCC.Text.Trim() == "" ||
               txtEmailNCC.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập đầy đủ thông tin", "Thông báo");
            }
            else
            {

                NhaCungCap_DTO ncc = new NhaCungCap_DTO();
                ncc.TenNhaCC = txtTenNhaCungCap.Text;
                ncc.SoDTNCC = txtSoDTNCC.Text;
                ncc.EmailNCC = txtEmailNCC.Text;


                NhaCungCap_BUS dtBus = new NhaCungCap_BUS();
                dtBus.ThemNhaCungCap(ncc, 1);
                MessageBox.Show("Đã Thêm 1 nhà cung cấp ");
                LoadDSNCC();
                ResetNCC();
            }
        }

        private void bntXoaNCC_Click(object sender, EventArgs e)
        {
            if (dataGridViewQLNhaCungCap.SelectedRows.Count > 0)
            {
                NhaCungCap_DTO ncc = (NhaCungCap_DTO)dataGridViewQLNhaCungCap.SelectedRows[0].DataBoundItem;

                if (MessageBox.Show("Bạn có chắc muốn xóa nhà cung cấp " + ncc.MaNhaCC + " không?", "Cảnh báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    NhaCungCap_BUS ncc1 = new NhaCungCap_BUS();
                    ncc1.XoaNhaCungCap(ncc);
                    MessageBox.Show("Đã xóa thành công nhà cung cấp");
                    LoadDSNCC();
                    ResetNCC();
                }
            }
        }
        private void btnSuaNCC_Click(object sender, EventArgs e)
        {
            if (dataGridViewQLNhaCungCap.SelectedRows.Count > 0)
            {
                NhaCungCap_DTO ncc = (NhaCungCap_DTO)dataGridViewQLNhaCungCap.SelectedRows[0].DataBoundItem;
                ncc.TenNhaCC = txtTenNhaCungCap.Text;
                ncc.SoDTNCC = txtSoDTNCC.Text;
                ncc.EmailNCC = txtEmailNCC.Text;


                NhaCungCap_BUS dtBus = new NhaCungCap_BUS();
                dtBus.SuaThongTinNhaCungCap(ncc);
                MessageBox.Show("Đã Sữa 1 nhà cung cấp ");
                LoadDSNCC();
                ResetNCC();
            }
        }
        private void btnResetNCC_Click(object sender, EventArgs e)
        {
            ResetNCC();
        }

        private void btnBackNCC_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangNhap frm = new DangNhap();
            frm.Show();
        }

        private void btnThoatNCC_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("BẠN MUỐN kẾT THÚC?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // đóng form
                this.Close();
            }
        }
        private void btnTimKiemNCC_Click(object sender, EventArgs e)
        {
            List<NhaCungCap_DTO> listncc = new List<NhaCungCap_DTO>();
            NhaCungCap_BUS ncc = new NhaCungCap_BUS();
            listncc = ncc.TimKiemNhaCungCap(txtTimKiemNCC.Text);
            dataGridViewQLNhaCungCap.DataSource = listncc;
        }
        private void btnBackTimKiem_Click(object sender, EventArgs e)
        {
            LoadDSNCC();
        }
        private void dataGridViewQLNhaCungCap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewQLNhaCungCap.SelectedRows.Count > 0)
            {
                NhaCungCap_DTO ncc = (NhaCungCap_DTO)dataGridViewQLNhaCungCap.SelectedRows[0].DataBoundItem;

                txtMaNhaCungCap.Text = ncc.MaNhaCC.ToString();
                txtTenNhaCungCap.Text = ncc.TenNhaCC.ToString();
                txtSoDTNCC.Text = ncc.SoDTNCC.ToString();
                txtEmailNCC.Text = ncc.EmailNCC.ToString();
            }
        }
        private void dataGridViewQLNhaCungCap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        #endregion
        #region NhapHang
        private void Load_fromCTNhapHang()
        {

            CTPhieuNhap_BUS ctpn = new CTPhieuNhap_BUS();
            List<CTPhieuNhap_DTO> listctpn = null;
            listctpn = ctpn.LayDanhSachCTPN();
            dataGridViewQLDSCTHD.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewQLDSCTHD.RowHeadersVisible = false;
            dataGridViewQLDSCTHD.AutoGenerateColumns = false;
            dataGridViewQLDSCTHD.DataSource = listctpn;

        }
        private void Load_fromNhapHang()
        {


            PhieuNhap_BUS pn = new PhieuNhap_BUS();
            List<PhieuNhap_DTO> listpn = pn.LayDanhSachPhieuNhap();
            dataGridViewQLDSHD.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewQLDSHD.RowHeadersVisible = false;
            dataGridViewQLDSHD.AutoGenerateColumns = false;
            dataGridViewQLDSHD.DataSource = listpn;

        }
        private void Load_timCTNhapHang()
        {

            CTPhieuNhap_BUS ctpnBUS = new CTPhieuNhap_BUS();
            List<CTPhieuNhap_DTO> listctpn = new List<CTPhieuNhap_DTO>();
            listctpn = ctpnBUS.TimCTPhieuNhap(int.Parse(txtMaPhieuNhap.Text));
            dataGridViewQLDSCTHD.DataSource = listctpn;
        }
        public void LoadNhap()
        {
            Load_fromNhapHang();
            Load_fromCTNhapHang();
        }
        private void btnTim_Click(object sender, EventArgs e)
        {
            if (txtMaPhieuNhap.Text.Trim() == "")
            {
                MessageBox.Show("Chưa Chọn Hóa Đơn Nhập", "Thông Báo", MessageBoxButtons.OK);
                txtMaPhieuNhap.Focus();
                return;
            }
            Load_timCTNhapHang();
        }
        private void btnBackNH_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangNhap frm = new DangNhap();
            frm.Show();
        }
        private void btnXoaPhieuNhap_Click(object sender, EventArgs e)
        {
            if (dataGridViewQLDSHD.SelectedRows.Count > 0)
            {
                PhieuNhap_DTO pn = (PhieuNhap_DTO)dataGridViewQLDSHD.SelectedRows[0].DataBoundItem;

                if (MessageBox.Show("Bạn có chắc muốn xóa Phiếu Nhập " + pn.MaPN + " không?", "Cảnh báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    PhieuNhap_BUS pn1 = new PhieuNhap_BUS();
                    pn1.XoaDanhSachPN(pn);
                    MessageBox.Show("Đã xóa thành công phiếu nhập");
                    Load_fromNhapHang();
                    
                }
            }
        }
        private void btnXoaCTPhieuNhap_Click(object sender, EventArgs e)
        {
            if (dataGridViewQLDSCTHD.SelectedRows.Count > 0)
            {
                CTPhieuNhap_DTO ctpn = (CTPhieuNhap_DTO)dataGridViewQLDSCTHD.SelectedRows[0].DataBoundItem;

                if (MessageBox.Show("Bạn có chắc muốn xóa sản phẩm trong Phiếu Nhập " + ctpn.MaPhieuNhap + " không?", "Cảnh báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    CTPhieuNhap_BUS pn1 = new CTPhieuNhap_BUS();
                    pn1.XoaDanhSachCTPN(ctpn);
                    MessageBox.Show("Đã xóa thành công Sản phẩm trong phiếu nhập");
                    Load_fromCTNhapHang();

                }
            }
        }
        private void dataGridViewQLDSHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridViewQLDSHD.CurrentRow.Index;
            txtMaPhieuNhap.Text = dataGridViewQLDSHD.Rows[i].Cells[0].Value.ToString();
        }
        #endregion
        #region BanHang
        private void Load_fromCTBanHang()
        {

            CTHoaDon_BUS cthd = new CTHoaDon_BUS();
            List<CTHoaDon_DTO> listcthd = null;
            listcthd = cthd.LayDanhSachCTHoaDon();
            dataGridViewCTHoaDonQL.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewCTHoaDonQL.RowHeadersVisible = false;
            dataGridViewCTHoaDonQL.AutoGenerateColumns = false;
            dataGridViewCTHoaDonQL.DataSource = listcthd;

        }
        private void Load_fromBanHang()
        {


            HoaDon_BUS hd = new HoaDon_BUS();
            List<HoaDon_DTO> listhd = hd.LayDanhSachHoaDonChoQl();
            dataGridViewHoaDonQL.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewHoaDonQL.RowHeadersVisible = false;
            dataGridViewHoaDonQL.AutoGenerateColumns = false;
            dataGridViewHoaDonQL.DataSource = listhd;

        }
        private void Load_timCTBanHang()
        {

            CTHoaDon_BUS cthdBUS = new CTHoaDon_BUS();
            List<CTHoaDon_DTO> listcthd = new List<CTHoaDon_DTO>();
            listcthd = cthdBUS.TimCTHoaDon(int.Parse(txtMaHoaDonQL.Text));
            dataGridViewCTHoaDonQL.DataSource = listcthd;
        }
        private void btnTimKiemHD_Click(object sender, EventArgs e)
        {
            if (txtMaHoaDonQL.Text.Trim() == "")
            {
                MessageBox.Show("Chưa Chọn Hóa Đơn Bán", "Thông Báo", MessageBoxButtons.OK);
                txtMaHoaDonQL.Focus();
                return;
            }
            Load_timCTBanHang();
        }
        private void btnXoaHoaDon_Click(object sender, EventArgs e)
        {
            if (dataGridViewHoaDonQL.SelectedRows.Count > 0)
            {
                HoaDon_DTO hd = (HoaDon_DTO)dataGridViewHoaDonQL.SelectedRows[0].DataBoundItem;

                if (MessageBox.Show("Bạn có chắc muốn xóa Hóa Đơn " + hd.MaHD + " không?", "Cảnh báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    HoaDon_BUS hd1 = new HoaDon_BUS();
                    hd1.XoaDanhSachHoaDon(hd);
                    MessageBox.Show("Đã xóa thành công Hóa Đơn");
                    Load_fromBanHang();

                }
            }
        }
        private void btnXoaCTHoaDon_Click(object sender, EventArgs e)
        {
            if (dataGridViewCTHoaDonQL.SelectedRows.Count > 0)
            {
                CTHoaDon_DTO cthd = (CTHoaDon_DTO)dataGridViewCTHoaDonQL.SelectedRows[0].DataBoundItem;

                if (MessageBox.Show("Bạn có chắc muốn xóa Sản Phẩm trong Hóa Đơn " + cthd.MaHoaDon + " không?", "Cảnh báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    CTHoaDon_BUS cthd1 = new CTHoaDon_BUS();
                    cthd1.XoaDanhSachCTHoaDon(cthd);
                    MessageBox.Show("Đã xóa thành công Sản Phẩm trong Hóa Đơn");
                    Load_fromCTBanHang();

                }
            }
        }
        private void btnbackBH_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangNhap frm = new DangNhap();
            frm.Show();
        }
        public void LoadBan()
        {
            Load_fromBanHang();
            Load_fromCTBanHang();
        }
        private void dataGridViewHoaDonQL_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridViewHoaDonQL.CurrentRow.Index;
            txtMaHoaDonQL.Text = dataGridViewHoaDonQL.Rows[i].Cells[0].Value.ToString();
        }
        #endregion
        #region DongHo
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDongHo.Text = DateTime.Now.ToLongTimeString();
        }

        #endregion
        #region ThongTin
        public QuanLy(string Message) : this()
        {
            _message = Message;
            txtMaNhanVien.Text = _message;
        }
        private void ThongTinNhanVien()
        {
            NhanVien_BUS nv = new NhanVien_BUS();
            List<NhanVien_DTO> listNV = nv.LayDanhSach();

            for (int i = 0; i < listNV.Count; i++)
            {
                if (listNV[i].MaNV.ToString() == txtMaNhanVien.Text.ToString() && listNV[i].ChucVu == "Quản Lý")
                {
                    txtMaNhanVienQL.Text = listNV[i].MaNV.ToString();
                    txtHoNhanVienQL.Text = listNV[i].HoNV.ToString();
                    txtTenDemQL.Text = listNV[i].TenDem.ToString();
                    txtTenNhanVienQL.Text = listNV[i].TenNV.ToString();
                    txtEmailQL.Text = listNV[i].Email.ToString();
                    //DateTime dt = DateTime.ParseExact(listNV[i].NgaySinh.ToString(), "yyyy-MM-dd h:mm:ss tt", CultureInfo.InvariantCulture);
                    dTPNgaySinh.Value = DateTime.ParseExact(listNV[i].NgaySinh.ToString(), "yyyy-MM-dd h:mm:ss tt", CultureInfo.InvariantCulture);
                    dTPNgayThem.Value = DateTime.ParseExact(listNV[i].NgayThem.ToString(), "yyyy-MM-dd h:mm:ss tt", CultureInfo.InvariantCulture);
                    cbbChucVuQLL.SelectedItem = listNV[i].ChucVu.ToString();
                    if (listNV[i].GioiTinh.ToString() == "Nam")
                    {
                        radNam.Checked = true;
                    }
                    else
                    {
                        radNu.Checked = true;
                    }
                    txtSoDienThoaiQL.Text = listNV[i].SDT.ToString();
                }
            }
        }
        private void btnThoatThongTin_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangNhap frm = new DangNhap();
            frm.Show();
        }
        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            DoiMatKhau frm = new DoiMatKhau(txtMaNhanVien.Text);
            frm.Show();
            this.Hide();
        }
        #endregion
        private void QuanLy_Load(object sender, EventArgs e)
        {
            LoadDSNV();
            LoadDSSP();
            LoadDSNL();
            LoadDSNCC();
            LoadNhap();
            LoadBan();
            timer1.Start();
            ThongTinNhanVien();
        }

        private void QuanLy_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            DangNhap frm = new DangNhap();
            frm.Show();

        }

        private void QuanLy_FormClosing(object sender, FormClosingEventArgs e)
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
