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
using BUS;
using DTO;

namespace QuanLyCaFe
{
    public partial class DangNhap : Form
    {
        List<NhanVien_DTO> listnv = null;
        public DangNhap()
        {
            InitializeComponent();

        }
        private void xetChucVu()
        {
           
            NhanVien_BUS sp = new NhanVien_BUS();
            listnv = sp.LayDanhSach();

            if (txtTenDangNhap.Text.Length > 0 && txtPass.Text.Length > 0)
            {
                for (int i = 0; i < listnv.Count; i++)
                {

                    if (listnv[i].MaNV.ToString() == txtTenDangNhap.Text && listnv[i].Pass.ToString() == txtPass.Text)
                    {
                        if (listnv[i].ChucVu == "Quản Lý")
                        {
                            QuanLy frm = new QuanLy(txtTenDangNhap.Text);
                            frm.Show();
                            this.Hide();
                        }
                        if (listnv[i].ChucVu == "Thu Ngân")
                        {
                            ThuNgan frm = new ThuNgan(txtTenDangNhap.Text);
                            frm.Show();
                            this.Hide();
                        }
                        if (listnv[i].ChucVu == "Kho")
                        {
                            this.Hide();
                            Kho frm = new Kho(txtTenDangNhap.Text);
                            frm.Show();
                        }
                        if(listnv[i].ChucVu == "Pha Chế")
                        {
                            this.Hide();
                            PhaChe frm = new PhaChe(txtTenDangNhap.Text);
                            frm.Show();
                        }
                        break;
                    }
                    else
                    {
                        if(i == listnv.Count -1)
                        {
                            MessageBox.Show("Tên đăng nhập hoặc mật khẩu không hợp lê!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa điền tên đăng nhập hoặc mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
        public static string ChucVu1 = "";

        private void btnDangNhap_Click_1(object sender, EventArgs e)
        {
            xetChucVu();
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("BẠN MUỐN kẾT THÚC?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
            
                
                Application.Exit(); 
               
            }
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            NhanVien_BUS sp = new NhanVien_BUS();
            listnv = sp.LayDanhSach();

            if (txtTenDangNhap.Text.Length > 0 && txtPass.Text.Length > 0)
            {
                for (int i = 0; i < listnv.Count; i++)
                {

                    if (listnv[i].MaNV.ToString() == txtTenDangNhap.Text && listnv[i].Pass.ToString() == txtPass.Text)
                    {
                        lblDangNhap.Visible = lblTenTaiKhoan.Visible = lblMatKhau.Visible = txtTenDangNhap.Visible = txtPass.Visible
                            = btnDangNhap.Visible = btnDoiMatKhau.Visible = btnThoat.Visible = btnDoiMatKhau.Visible = pnlHinhAnh.Visible = pnlThuc.Visible = false;
                        DoiMatKhau frm = new DoiMatKhau(txtTenDangNhap.Text);
                        frm.MdiParent = this;
                        frm.Show();
                        break;
                    }
                    else
                    {
                        if (i == listnv.Count - 1)
                        {
                            MessageBox.Show("Tên đăng nhập hoặc mật khẩu không hợp lê!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa điền tên đăng nhập hoặc mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
