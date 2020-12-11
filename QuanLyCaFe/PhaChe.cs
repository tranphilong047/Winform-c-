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
    public partial class PhaChe : Form
    {
        private string _message;

        public PhaChe()
        {
            InitializeComponent();
        }
        public PhaChe(string Message) : this()
        {
            _message = Message;
            txtMaNhanVien.Text = _message;
        }
        private void ThongTinNhanVien()
        {
            NhanVien_BUS nv = new NhanVien_BUS();
            List<NhanVien_DTO> listnv = nv.LayDanhSach();

            for (int i = 0; i < listnv.Count; i++)
            {
                if (listnv[i].MaNV.ToString() == txtMaNhanVien.Text.ToString() && listnv[i].ChucVu == "Pha Chế")
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
        private void PhaChe_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            Application.Exit();
        }

        private void PhaChe_Load(object sender, EventArgs e)
        {
            ThongTinNhanVien();
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            DoiMatKhau frm = new DoiMatKhau(txtMaNhanVien.Text);
            frm.Show();
            this.Hide();
        }

        private void btnThoatThongTin_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangNhap frm = new DangNhap();
            frm.Show();
        }

        private void PhaChe_FormClosing(object sender, FormClosingEventArgs e)
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
