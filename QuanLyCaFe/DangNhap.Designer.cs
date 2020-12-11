namespace QuanLyCaFe
{
    partial class DangNhap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DangNhap));
            this.lblDangNhap = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.txtTenDangNhap = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.lblTenTaiKhoan = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lblMatKhau = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.txtPass = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.pnlThuc = new System.Windows.Forms.Panel();
            this.btnDoiMatKhau = new Bunifu.Framework.UI.BunifuThinButton2();
            this.pnlHinhAnh = new System.Windows.Forms.Panel();
            this.btnThoat = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btnDangNhap = new Bunifu.Framework.UI.BunifuThinButton2();
            this.SuspendLayout();
            // 
            // lblDangNhap
            // 
            this.lblDangNhap.AutoSize = true;
            this.lblDangNhap.BackColor = System.Drawing.Color.Transparent;
            this.lblDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDangNhap.Location = new System.Drawing.Point(500, 9);
            this.lblDangNhap.Name = "lblDangNhap";
            this.lblDangNhap.Size = new System.Drawing.Size(269, 55);
            this.lblDangNhap.TabIndex = 9;
            this.lblDangNhap.Text = "Đăng Nhập";
            // 
            // txtTenDangNhap
            // 
            this.txtTenDangNhap.BackColor = System.Drawing.Color.LightGray;
            this.txtTenDangNhap.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenDangNhap.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenDangNhap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtTenDangNhap.HintForeColor = System.Drawing.Color.Empty;
            this.txtTenDangNhap.HintText = "";
            this.txtTenDangNhap.isPassword = false;
            this.txtTenDangNhap.LineFocusedColor = System.Drawing.Color.Blue;
            this.txtTenDangNhap.LineIdleColor = System.Drawing.Color.Gray;
            this.txtTenDangNhap.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.txtTenDangNhap.LineThickness = 3;
            this.txtTenDangNhap.Location = new System.Drawing.Point(539, 147);
            this.txtTenDangNhap.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.Size = new System.Drawing.Size(317, 38);
            this.txtTenDangNhap.TabIndex = 1;
            this.txtTenDangNhap.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // lblTenTaiKhoan
            // 
            this.lblTenTaiKhoan.AutoSize = true;
            this.lblTenTaiKhoan.BackColor = System.Drawing.Color.Transparent;
            this.lblTenTaiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenTaiKhoan.Location = new System.Drawing.Point(405, 160);
            this.lblTenTaiKhoan.Name = "lblTenTaiKhoan";
            this.lblTenTaiKhoan.Size = new System.Drawing.Size(103, 25);
            this.lblTenTaiKhoan.TabIndex = 17;
            this.lblTenTaiKhoan.Text = "Tài Khoản";
            // 
            // lblMatKhau
            // 
            this.lblMatKhau.AutoSize = true;
            this.lblMatKhau.BackColor = System.Drawing.Color.Transparent;
            this.lblMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatKhau.Location = new System.Drawing.Point(411, 260);
            this.lblMatKhau.Name = "lblMatKhau";
            this.lblMatKhau.Size = new System.Drawing.Size(97, 25);
            this.lblMatKhau.TabIndex = 18;
            this.lblMatKhau.Text = "Mật Khẩu";
            // 
            // txtPass
            // 
            this.txtPass.BackColor = System.Drawing.Color.LightGray;
            this.txtPass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPass.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPass.HintForeColor = System.Drawing.Color.Empty;
            this.txtPass.HintText = "";
            this.txtPass.isPassword = true;
            this.txtPass.LineFocusedColor = System.Drawing.Color.Blue;
            this.txtPass.LineIdleColor = System.Drawing.Color.Gray;
            this.txtPass.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.txtPass.LineThickness = 3;
            this.txtPass.Location = new System.Drawing.Point(539, 242);
            this.txtPass.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(317, 43);
            this.txtPass.TabIndex = 2;
            this.txtPass.Text = "123";
            this.txtPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // pnlThuc
            // 
            this.pnlThuc.BackColor = System.Drawing.Color.Transparent;
            this.pnlThuc.BackgroundImage = global::QuanLyCaFe.Properties.Resources.thuccofe;
            this.pnlThuc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlThuc.Location = new System.Drawing.Point(78, 21);
            this.pnlThuc.Name = "pnlThuc";
            this.pnlThuc.Size = new System.Drawing.Size(220, 91);
            this.pnlThuc.TabIndex = 22;
            // 
            // btnDoiMatKhau
            // 
            this.btnDoiMatKhau.ActiveBorderThickness = 1;
            this.btnDoiMatKhau.ActiveCornerRadius = 20;
            this.btnDoiMatKhau.ActiveFillColor = System.Drawing.Color.Cyan;
            this.btnDoiMatKhau.ActiveForecolor = System.Drawing.Color.Transparent;
            this.btnDoiMatKhau.ActiveLineColor = System.Drawing.Color.Cyan;
            this.btnDoiMatKhau.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnDoiMatKhau.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDoiMatKhau.BackgroundImage")));
            this.btnDoiMatKhau.ButtonText = "Đổi Mật Khẩu";
            this.btnDoiMatKhau.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDoiMatKhau.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoiMatKhau.ForeColor = System.Drawing.Color.Blue;
            this.btnDoiMatKhau.IdleBorderThickness = 1;
            this.btnDoiMatKhau.IdleCornerRadius = 20;
            this.btnDoiMatKhau.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDoiMatKhau.IdleForecolor = System.Drawing.Color.Cyan;
            this.btnDoiMatKhau.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDoiMatKhau.Location = new System.Drawing.Point(462, 317);
            this.btnDoiMatKhau.Margin = new System.Windows.Forms.Padding(5);
            this.btnDoiMatKhau.Name = "btnDoiMatKhau";
            this.btnDoiMatKhau.Size = new System.Drawing.Size(172, 40);
            this.btnDoiMatKhau.TabIndex = 20;
            this.btnDoiMatKhau.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDoiMatKhau.Click += new System.EventHandler(this.btnDoiMatKhau_Click);
            // 
            // pnlHinhAnh
            // 
            this.pnlHinhAnh.BackColor = System.Drawing.Color.Silver;
            this.pnlHinhAnh.BackgroundImage = global::QuanLyCaFe.Properties.Resources.hdn;
            this.pnlHinhAnh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlHinhAnh.Location = new System.Drawing.Point(54, 141);
            this.pnlHinhAnh.Name = "pnlHinhAnh";
            this.pnlHinhAnh.Size = new System.Drawing.Size(288, 301);
            this.pnlHinhAnh.TabIndex = 19;
            // 
            // btnThoat
            // 
            this.btnThoat.ActiveBorderThickness = 1;
            this.btnThoat.ActiveCornerRadius = 20;
            this.btnThoat.ActiveFillColor = System.Drawing.Color.Red;
            this.btnThoat.ActiveForecolor = System.Drawing.Color.Transparent;
            this.btnThoat.ActiveLineColor = System.Drawing.Color.Red;
            this.btnThoat.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnThoat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnThoat.BackgroundImage")));
            this.btnThoat.ButtonText = "Thoát";
            this.btnThoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThoat.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.Color.Red;
            this.btnThoat.IdleBorderThickness = 1;
            this.btnThoat.IdleCornerRadius = 20;
            this.btnThoat.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnThoat.IdleForecolor = System.Drawing.Color.Red;
            this.btnThoat.IdleLineColor = System.Drawing.Color.Red;
            this.btnThoat.Location = new System.Drawing.Point(727, 389);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(5);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(129, 40);
            this.btnThoat.TabIndex = 4;
            this.btnThoat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click_1);
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.ActiveBorderThickness = 1;
            this.btnDangNhap.ActiveCornerRadius = 20;
            this.btnDangNhap.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btnDangNhap.ActiveForecolor = System.Drawing.Color.Transparent;
            this.btnDangNhap.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btnDangNhap.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnDangNhap.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDangNhap.BackgroundImage")));
            this.btnDangNhap.ButtonText = "Đăng Nhập";
            this.btnDangNhap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDangNhap.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangNhap.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnDangNhap.IdleBorderThickness = 1;
            this.btnDangNhap.IdleCornerRadius = 20;
            this.btnDangNhap.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnDangNhap.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.btnDangNhap.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btnDangNhap.Location = new System.Drawing.Point(684, 317);
            this.btnDangNhap.Margin = new System.Windows.Forms.Padding(5);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(172, 40);
            this.btnDangNhap.TabIndex = 3;
            this.btnDangNhap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(926, 494);
            this.Controls.Add(this.pnlThuc);
            this.Controls.Add(this.btnDoiMatKhau);
            this.Controls.Add(this.pnlHinhAnh);
            this.Controls.Add(this.lblMatKhau);
            this.Controls.Add(this.lblTenTaiKhoan);
            this.Controls.Add(this.lblDangNhap);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.txtTenDangNhap);
            this.Controls.Add(this.btnDangNhap);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Quán Thức Coffee";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Bunifu.Framework.UI.BunifuThinButton2 btnDangNhap;
        private Bunifu.Framework.UI.BunifuCustomLabel lblDangNhap;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtTenDangNhap;
        private Bunifu.Framework.UI.BunifuThinButton2 btnThoat;
        private Bunifu.Framework.UI.BunifuCustomLabel lblTenTaiKhoan;
        private Bunifu.Framework.UI.BunifuCustomLabel lblMatKhau;
        private System.Windows.Forms.Panel pnlHinhAnh;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtPass;
        private Bunifu.Framework.UI.BunifuThinButton2 btnDoiMatKhau;
        private System.Windows.Forms.Panel pnlThuc;
    }
}

