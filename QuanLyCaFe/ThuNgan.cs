
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;

namespace QuanLyCaFe
{
    public partial class ThuNgan : Form
    {
        List<SanPham_DTO> listsp = null;
        List<HoaDon_DTO> listhd = null;
        List<CTHoaDon_DTO> listCTHD = null;
        List<NhanVien_DTO> listNV = null;

        ImageList ilsSmall = null;
        ImageList ilsLagre = null;

        private string _message;

        public ThuNgan()
        {
            InitializeComponent();
            lvOrder.View = View.Details;

            lvOrder.Columns.Add("Mã SP", 70);
            lvOrder.Columns.Add("Tên SP", 180);
            lvOrder.Columns.Add("Giá", 100);
            lvOrder.Columns.Add("SL", 60);
            lvOrder.FullRowSelect = true;
            txtSL.Text = "1";
            string[] s = { "Quản Lí", "Thu Ngân", "Pha Chế", "Kho" };
            cbbChucVu.Items.AddRange(s);

        }
        public ThuNgan(string Message) : this()
        {
            _message = Message;
            txtMaNV.Text = _message;
            txtMaNhanVien.Text = _message;
        }
        private void ThuNgan_Load(object sender, EventArgs e)
        {
            LoadFrom();
            txtMaHD.Enabled = false;
            #region Thêm cột cho listview bằng code
            ColumnHeader colName = new ColumnHeader();
            colName.Text = "Tên SP";
            colName.Width = 195;
            lvSP.Columns.Add(colName);

            ColumnHeader colFounded = new ColumnHeader();
            colFounded.Text = "Mã SP";
            colFounded.Width = 64;
            lvSP.Columns.Add(colFounded);

            ColumnHeader colFullName = new ColumnHeader();
            colFullName.Text = "Loại SP";
            colFullName.Width = 195;
            lvSP.Columns.Add(colFullName);

            ColumnHeader colWebsite = new ColumnHeader();
            colWebsite.Text = "Đơn Giá";
            colWebsite.Width = 173;
            lvSP.Columns.Add(colWebsite);
            #endregion
            
            txtMaNhanVien.Enabled = txtHoNhanVien.Enabled = txtTenNhanVien.Enabled = txtTenDem.Enabled = dTPNgaySinh.Enabled
                = dTPNgayThem.Enabled = txtSoDienThoai.Enabled = txtSoDienThoai.Enabled = txtThanhTien.Enabled 
                = cbbChucVu.Enabled = txtEmail.Enabled = dTPNgayTao.Enabled = false;
            ThongTinNhanVien();
        }
        private void ThongTinNhanVien()
        {
            NhanVien_BUS nv = new NhanVien_BUS();
            listNV = nv.LayDanhSach();

            for (int i = 0; i < listNV.Count; i++)
            {
                if(listNV[i].MaNV.ToString() == txtMaNhanVien.Text.ToString() && listNV[i].ChucVu == "Thu Ngân")
                {
                    txtHoNhanVien.Text = listNV[i].HoNV.ToString();
                    txtTenDem.Text = listNV[i].TenDem.ToString();
                    txtTenNhanVien.Text = listNV[i].TenNV.ToString();
                    txtEmail.Text = listNV[i].Email.ToString();
                    //DateTime dt = DateTime.ParseExact(listNV[i].NgaySinh.ToString(), "yyyy-MM-dd h:mm:ss tt", CultureInfo.InvariantCulture);
                    dTPNgaySinh.Value = DateTime.ParseExact(listNV[i].NgaySinh.ToString(), "yyyy-MM-dd h:mm:ss tt", CultureInfo.InvariantCulture);
                    dTPNgayThem.Value = DateTime.ParseExact(listNV[i].NgayThem.ToString(), "yyyy-MM-dd h:mm:ss tt", CultureInfo.InvariantCulture);
                    cbbChucVu.SelectedItem = listNV[i].ChucVu.ToString();
                    if (listNV[i].GioiTinh.ToString() == "Nam")
                    {
                        radNam.Checked = true;
                    }
                    else
                    {
                        radNu.Checked = true;
                    }
                    txtSoDienThoai.Text = listNV[i].SDT.ToString();
                }
            }
        }
        private void LoadFrom()
        {
            HoaDon_BUS hd = new HoaDon_BUS();
            listhd = hd.LayDanhSachHoaDonChoTN();

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = hd.LayDanhSachHoaDonChoQl();

            CTHoaDon_BUS cthd = new CTHoaDon_BUS();
            listCTHD = cthd.LayDanhSachCTHoaDon();
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.DataSource = listCTHD;

            SanPham_BUS sp = new SanPham_BUS();
            listsp = sp.LayDanhSachSanPham();

            ilsLagre = new ImageList();
            ilsLagre.ColorDepth = ColorDepth.Depth24Bit;
            ilsLagre.ImageSize = new Size(100, 100);
            lvSP.LargeImageList = ilsLagre;

            ilsSmall = new ImageList();
            ilsSmall.ColorDepth = ColorDepth.Depth8Bit;
            ilsSmall.ImageSize = new Size(30, 30);
            lvSP.SmallImageList = ilsSmall;

            foreach (SanPham_DTO mySPTemp in listsp)
            {
                ListViewItem lvi = new ListViewItem(mySPTemp.TenSP.ToString());
                lvi.SubItems.Add(mySPTemp.MaSP.ToString());
                lvi.SubItems.Add(mySPTemp.LoaiSP.ToString());
                lvi.SubItems.Add(mySPTemp.DonGia.ToString());

                string strFileName = "data/hinhanh/" + mySPTemp.IconUrl;
                Bitmap bm = new Bitmap(strFileName);
                ilsLagre.Images.Add(strFileName, bm);
                ilsSmall.Images.Add(strFileName, bm);
                lvi.ImageKey = strFileName;
                lvSP.Items.Add(lvi);
                lvSP.FullRowSelect = true;
            }
            if(listhd.Count == 0)
            {
                txtMaHD.Text = "501";
            }
            else
            {
                txtMaHD.Text = (int.Parse(listhd[listhd.Count - 1].MaHD.ToString()) + 1).ToString();
            }            
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvOrder.SelectedItems.Count > 0)
            {
                lvOrder.Items.Remove(lvOrder.SelectedItems[0]);
            }
            txtSL.Text = "1";
        }

        private void btnResetNL_Click(object sender, EventArgs e)
        {
            lvOrder.Items.Clear();
            txtSL.Text = "1";
            txtThanhTien.Text = "";
        }

        private void btnCong_Click(object sender, EventArgs e)
        {
            txtSL.Text = (int.Parse(txtSL.Text) + 1).ToString();
        }

        private void btnTru_Click(object sender, EventArgs e)
        {
            txtSL.Text = (int.Parse(txtSL.Text) - 1).ToString();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangNhap frm = new DangNhap();
            frm.Show();
        }
        private void ThuNgan_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (lvSP.SelectedItems.Count > 0 && txtSL.Text.Length > 0)
            {      
                if(lvOrder.Items.Count <= 0)
                {
                    ListViewItem item = new ListViewItem(lvSP.FocusedItem.SubItems[1].Text);
                    item.SubItems.Add(lvSP.FocusedItem.SubItems[0].Text);
                    item.SubItems.Add(lvSP.FocusedItem.SubItems[3].Text);
                    item.SubItems.Add(txtSL.Text);
                    lvOrder.Items.Add(item);
                }
                else
                {
                    for (int i = 0; i < lvOrder.Items.Count; i++)
                    {
                        if (lvOrder.Items[i].SubItems[0].Text == lvSP.FocusedItem.SubItems[1].Text)
                        {
                            lvOrder.Items[i].SubItems[3].Text = (int.Parse(lvOrder.Items[i].SubItems[3].Text) + int.Parse(txtSL.Text)).ToString();
                            break;
                        }
                        else if (lvOrder.Items[i].SubItems[0].Text != lvSP.FocusedItem.SubItems[1].Text && i == lvOrder.Items.Count - 1)
                        {
                            ListViewItem item = new ListViewItem(lvSP.FocusedItem.SubItems[1].Text);
                            item.SubItems.Add(lvSP.FocusedItem.SubItems[0].Text);
                            item.SubItems.Add(lvSP.FocusedItem.SubItems[3].Text);
                            item.SubItems.Add(txtSL.Text);
                            lvOrder.Items.Add(item);
                            ++i;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn sản phẩm hay số lượng = 0", "Thông báo", MessageBoxButtons.OK);
            }
            double s = 0;
            for (int i = 0; i < lvOrder.Items.Count; i++)
            {
                s += double.Parse(lvOrder.Items[i].SubItems[2].Text) * double.Parse(lvOrder.Items[i].SubItems[3].Text);
            }
            txtThanhTien.Text = s.ToString();
            txtSL.Text = "1";
        }

        private void txtSL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnThoatThongTin_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangNhap frm = new DangNhap();
            frm.Show();
        }

        private void TaoCTHD()
        {
            for (int i = 0; i < lvOrder.Items.Count; i++)
            {
                CTHoaDon_DTO cthdThem = new CTHoaDon_DTO();
                cthdThem.MaHoaDon = int.Parse(txtMaHD.Text);
                cthdThem.MaSanPham = int.Parse(lvOrder.Items[i].SubItems[0].Text);
                cthdThem.SoLuongCTHD = int.Parse(lvOrder.Items[i].SubItems[3].Text);

                CTHoaDon_BUS cthdBus = new CTHoaDon_BUS();
                cthdBus.ThemDanhSachCTHoaDon(cthdThem, 1);
            }
            lvSP.Items.Clear();
            LoadFrom();
        }
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            string x = "";
            string MaHD = txtMaHD.Text;
            string Bang = "Sản phẩm" + "\t\t  " + "SL" + "\t   " + "Đơn giá";
            for (int i = 0; i < lvOrder.Items.Count; i++)
            {
                //double gia = Double.Parse("lvOrder.Items[i].SubItems[2].Text");
                if (lvOrder.Items[i].SubItems[1].Text.Length > 25)
                {
                    x += lvOrder.Items[i].SubItems[1].Text + "\t   " + lvOrder.Items[i].SubItems[3].Text + "\t   " + lvOrder.Items[i].SubItems[2].Text + "\n";
                }
                else
                {
                    int KhoangTrang = 25 - lvOrder.Items[i].SubItems[1].Text.Length;
                    string KT = " ";
                    for (int z = 0; z < KhoangTrang; z++)
                    {
                        KT += " ";
                    }
                    x += lvOrder.Items[i].SubItems[1].Text + KT + "\t   " + lvOrder.Items[i].SubItems[3].Text + "\t   " + lvOrder.Items[i].SubItems[2].Text + "\n";
                }

            }
            string HoaDon = "Mã hóa đơn: " + MaHD + "\t\t" + dTPNgayTao.Value + "\n\n" + Bang + "\n" + x + "\n" + "Thành tiền: " + "\t\t\t " + txtThanhTien.Text;
            DialogResult result = MessageBox.Show(HoaDon, "Bạn có muốn thanh toán hay không?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (txtThanhTien.Text.Length > 0)
                {
                    HoaDon_DTO hdThem = new HoaDon_DTO();
                    hdThem.ThanhTienHD = (decimal)(long.Parse(txtThanhTien.Text));
                    hdThem.NgayTaoHD = (DateTime)dTPNgayTao.Value;
                    hdThem.MaNhanVienHD = int.Parse(txtMaNV.Text);

                    HoaDon_BUS hdBus = new HoaDon_BUS();
                    hdBus.ThemDanhSachHoaDon(hdThem, 1);
                    TaoCTHD();
                    lvOrder.Items.Clear();
                    txtSL.Text = "1";
                    txtThanhTien.Text = "";
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn sản phẩm để thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }                
            
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            DoiMatKhau frm = new DoiMatKhau(txtMaNV.Text);
            frm.Show();
            this.Hide();
        }

        private void btnThoatFormHD_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangNhap frm = new DangNhap();
            frm.Show();
        }

        private void btnThoatCTHD_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangNhap frm = new DangNhap();
            frm.Show();
        }

        private void ThuNgan_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
