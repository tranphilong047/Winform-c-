using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;

namespace QuanLyCaFe
{
    public partial class DoiMatKhau : Form
    {
        List<NhanVien_DTO> listNV = null;
        private string _message;
        public DoiMatKhau()
        {
            InitializeComponent();
        }
        public DoiMatKhau(string Message) : this()
        {
            _message = Message;
            txtMaNV.Text = _message;
        }
        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            NhanVien_BUS nv = new NhanVien_BUS();
            listNV = nv.LayDanhSach();
            if (txtMKHienTai.Text.Length > 0 && txtMKMoi.Text.Length > 0)
            {
                for (int i = 0; i < listNV.Count; i++)
                {
                    if (txtMaNV.Text == listNV[i].MaNV.ToString() && txtMKHienTai.Text == listNV[i].Pass.ToString())
                    {
                        DialogResult result = MessageBox.Show("Bạn có thật sự muốn đổi mật khẩu?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if(result == DialogResult.Yes)
                        {
                            NhanVien_BUS NVBus = new NhanVien_BUS();
                            NVBus.DoiMatKhau(txtMKMoi.Text, txtMaNV.Text);
                            MessageBox.Show("Bạn đã đổi mật khẩu thành công", "Thông báo");
                        }
                        break;
                    }
                    else
                    {
                        if (i == listNV.Count - 1)
                        {
                            MessageBox.Show("Mật khẩu hiện tại không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                    }
                }
            }

        }

        private void DoiMatKhau_Load(object sender, EventArgs e)
        {
            txtMaNV.Enabled = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DoiMatKhau_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có thật sự muốn thoát?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            DangNhap frm = new DangNhap();
            frm.Show();
            this.Hide();
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            DangNhap frm = new DangNhap();
            frm.Show();
        }
    }
}
