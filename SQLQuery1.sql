--create database QuanLyCafe


use [QuanLyCafe];
--tạo bảng
--Nhân viên
go
create table NhanVien
(
	MaNV int IDENTITY(100,1) PRIMARY KEY,
	HoNV nvarchar(30) not null ,
	TenDem nvarchar(30)not null,
	TenNV nvarchar(50) not null,
	NgaySinh datetime not null,
	GioiTinh nvarchar(10) not null,
	SDT varchar(20) not null,
	Email nvarchar(30) not null,
	ChucVu nvarchar(30) not null,
	NgayThem datetime not null,
	Pass nvarchar(20) not null,
	TrangThai int not null,
)
--Hóa Đơn 
go
create table HoaDon
(
	MaHD int IDENTITY(500,1) PRIMARY KEY,
	ThanhTienHD Money not null,
	NgayTaoHD datetime not null,
	MaNhanVienHD int,
	TrangThai int not null
)
--Chi tiết hóa đơn
go
create table CTHoaDon
(
	MaHoaDon int,
	MaSanPham int,	
	SoLuongCTHD int not null,
	TrangThai int not null
	
	constraint pk_HoaDon_SanPham_CTHoaDon primary key (MaHoaDon, MaSanPham)
)


--Sản Phẩm
go
create table SanPham
(
	MaSP int IDENTITY(1000,1) PRIMARY KEY,
	TenSP nvarchar(50),
	LoaiSP nvarchar(30),
	DonGia Money,
	IconUrl nvarchar(30),
	NgayTao datetime null,
	TrangThai int null
)
--Nhà cung cấp
go
create table NhaCungCap
(
	MaNhaCC int IDENTITY(1500,1)PRIMARY KEY,
	TenNhaCC nvarchar(50) not null,
	SoDTNCC nvarchar(20) not null,
	EmailNCC nvarchar(30) not null,
	TrangThai int null
)

--Phiếu nhập
go
create table PhieuNhap
(
	MaPN int IDENTITY(2000,1) PRIMARY KEY,
	NgayTaoPN datetime not null,
	MaNhanVien int not null,
	MaNhaCungCap int not null,
	TongTien Money not null,
	TrangThai int not null
)


--Chi tiết phiếu xuất
go
create table CTPhieuNhap
(
	MaPhieuNhap int,
	MaNguyenLieu int,
	SoLuong int not null,
	DonGiaCTPN Money not null,
	ThanhTien Money not null,
	TrangThai int not null
	constraint pk_MaphieuNhap_MaNL primary KEY (MaPhieuNhap, MaNguyenLieu)
)
--Nguyên Liệu
go
create table NguyenLieu
(
	MaNL int IDENTITY(2500,1) PRIMARY KEY,
	TenNguyenLieu nvarchar(50) not null,
	DonViTinh nvarchar(30) not null,
	DonGiaNL Money not null,
	TrangThai int not null
)


--Tạo khóa ngoại 
-- hóa đơn
go
alter table [dbo].[CTHoaDon]
add constraint fk_HOADON_CTHOADON FOREIGN KEY (MaHoaDon) REFERENCES  [dbo].[HoaDon](MaHD);

go
alter table [dbo].[CTHoaDon]
add constraint fk_CTHOADON_SANPHAM FOREIGN KEY (MaSanPham) REFERENCES  [dbo].[SanPham](MaSP);
go
alter table [dbo].[HoaDon] 
add constraint fk_HoaDon_NhanVien FOREIGN KEY (MaNhanVienHD) REFERENCES [dbo].[NhanVien](MaNV);
go
alter table[dbo].[CTPhieuNhap]
add constraint fk_NguyenLieu_CTPhieuNhap FOREIGN KEY (MaNguyenLieu) REFERENCES [dbo].[NguyenLieu](MaNL);
go
alter table [dbo].[PhieuNhap]
add constraint fk_NhaCungCap_PhieuNhap FOREIGN KEY (MaNhaCungCap) REFERENCES [dbo].[NhaCungCap](MaNhaCC);
go
alter table[dbo].[CTPhieuNhap]
add constraint fk_PhieuNhap_CTPhieuNhap FOREIGN KEY (MaPhieuNhap) REFERENCES [dbo].[PhieuNhap](MaPN);
go
alter table [dbo].[PhieuNhap] 
add constraint fk_NhanVien_PhieuNhap FOREIGN KEY (MaNhanVien) REFERENCES [dbo].[NhanVien](MaNV);

--insert dữ liệu
go
insert into NhanVien(HoNV,TenDem,TenNV,NgaySinh,GioiTinh,SDT,Email,ChucVu,NgayThem,Pass,TrangThai) 
			values (N'Trần',N'Phi',N'Long','2000-08-08',N'Nam','0382965484','tranphilong047@gmail.com',N'Quản Lý','2020-05-05','123',1);
insert into NhanVien(HoNV,TenDem,TenNV,NgaySinh,GioiTinh,SDT,Email,ChucVu,NgayThem,Pass,TrangThai) 
			values (N'Nguyễn',N'Văn',N'A','1999-05-02',N'Nữ','0908321123','nguyenvana@gmail.com',N'Thu Ngân','2020-03-02','123',1);
insert into NhanVien(HoNV,TenDem,TenNV,NgaySinh,GioiTinh,SDT,Email,ChucVu,NgayThem,Pass,TrangThai) 
			values (N'Lê',N'Ngọc',N'B','2003-01-07',N'Nam','0987654321','lengocb@gmail.com',N'Kho','2020-09-02','123',1);
insert into NhanVien(HoNV,TenDem,TenNV,NgaySinh,GioiTinh,SDT,Email,ChucVu,NgayThem,Pass,TrangThai) 
			values (N'Hoàng',N'Dược',N'Sư','2001-05-03',N'Nữ','0912345678','hoangduocsu@gmail.com',N'Pha Chế','2020-04-01','123',1);
go
insert into [dbo].[NhaCungCap](TenNhaCC, SoDTNCC, EmailNCC, TrangThai) values(N'Công ty TNHH Cà Phê Triều Nguyên', '0927364527', 'trieunguyen@gmail.com', 1)
insert into [dbo].[NhaCungCap](TenNhaCC, SoDTNCC, EmailNCC, TrangThai) values(N'Cà phê AVC HEMERA', '0536846836486', 'hemera@gmail.com', 1)
insert into [dbo].[NhaCungCap](TenNhaCC, SoDTNCC, EmailNCC, TrangThai) values(N'Sơn Việt Coffee', '082647637486', 'sonviet@gmail.com', 1)
insert into [dbo].[NhaCungCap](TenNhaCC, SoDTNCC, EmailNCC, TrangThai) values(N'Cà phê Liên Đồng', '0637638627', 'liendong@gmail.com', 1)
insert into [dbo].[NhaCungCap](TenNhaCC, SoDTNCC, EmailNCC, TrangThai) values(N'Nguyên liệu trà sữa Xuân Thịnh', '0864587673', 'xuanthinh@gmail.com', 1)
insert into [dbo].[NhaCungCap](TenNhaCC, SoDTNCC, EmailNCC, TrangThai) values(N'Siêu thị nguyên liệu', '07548653764', 'sieuthinguyenlieu@gmail.com', 1)
insert into [dbo].[NhaCungCap](TenNhaCC, SoDTNCC, EmailNCC, TrangThai) values(N'Công ty TNHH Vua An Toàn', '02767253648', 'vuantoan@gmail.com', 1)

go
insert into SanPham(TenSP, LoaiSP, DonGia, IconUrl, NgayTao, TrangThai) values (N'Trà vải trái cây',N'Trà', 35, '7b4afced_tra-vai-trai-cay.jpg', '2020-03-02', 1)
insert into SanPham(TenSP, LoaiSP, DonGia, IconUrl, NgayTao, TrangThai) values (N'Trà paloma',N'Trà', 45, 'bfec0e11_paloma-ice-tea-7-.png', '2020-05-09', 1)
insert into SanPham(TenSP, LoaiSP, DonGia, IconUrl, NgayTao, TrangThai) values (N'Bí đỏ phô mai đá xay',N'Đá xay', 50, 'bi-do-pho-mai-da-xay.jpg', '2020-05-03', 1)
insert into SanPham(TenSP, LoaiSP, DonGia, IconUrl, NgayTao, TrangThai) values (N'Cafe đen',N'Cafe', 35, 'cafeden.jpg', '2020-06-02', 1)
insert into SanPham(TenSP, LoaiSP, DonGia, IconUrl, NgayTao, TrangThai) values (N'Caramel macchiato',N'Cafe', 55, 'CARAMELMACCHIATO.jpg', '2020-09-02', 1)
insert into SanPham(TenSP, LoaiSP, DonGia, IconUrl, NgayTao, TrangThai) values (N'Yaua trái cây',N'Yaua', 35, 'fced927c_yaua-trai-cay.jpg', '2020-05-09', 1)
insert into SanPham(TenSP, LoaiSP, DonGia, IconUrl, NgayTao, TrangThai) values (N'Tắc xí muội đá xay',N'Đá xay', 40, 'tac-xi-muoi-da-xay.jpg', '2020-08-09', 1)
insert into SanPham(TenSP, LoaiSP, DonGia, IconUrl, NgayTao, TrangThai) values (N'Trà đào (Special)',N'Trà', 35, 'tra-dao.jpg', '2020-02-09', 1)
insert into SanPham(TenSP, LoaiSP, DonGia, IconUrl, NgayTao, TrangThai) values (N'Trà xanh latte nóng',N'Trà', 35, 'tra-xanh-latte-nong-.jpg', '2020-04-09', 1)

go
insert into NguyenLieu(TenNguyenLieu, DonViTinh, DonGiaNL, TrangThai) values (N'Cà phê bột', 'gam', 50, 1)
insert into NguyenLieu(TenNguyenLieu, DonViTinh, DonGiaNL, TrangThai) values (N'Sữa đặc', 'lít', 80, 1)
insert into NguyenLieu(TenNguyenLieu, DonViTinh, DonGiaNL, TrangThai) values (N'Sữa tươi không đường', 'lít', 30000, 1)
insert into NguyenLieu(TenNguyenLieu, DonViTinh, DonGiaNL, TrangThai) values (N'Bột Onemix', 'gam', 40, 1)
insert into NguyenLieu(TenNguyenLieu, DonViTinh, DonGiaNL, TrangThai) values (N'Bột cacao', 'gam', 30, 1)
insert into NguyenLieu(TenNguyenLieu, DonViTinh, DonGiaNL, TrangThai) values (N'Bột socola', 'gam', 35, 1)
insert into NguyenLieu(TenNguyenLieu, DonViTinh, DonGiaNL, TrangThai) values (N'Trà nhài', 'gam', 20, 1)
insert into NguyenLieu(TenNguyenLieu, DonViTinh, DonGiaNL, TrangThai) values (N'Trà sen', 'gam', 20, 1)
insert into NguyenLieu(TenNguyenLieu, DonViTinh, DonGiaNL, TrangThai) values (N'Hạt cà phê', 'gam', 70, 1)
insert into NguyenLieu(TenNguyenLieu, DonViTinh, DonGiaNL, TrangThai) values (N'Bột Matcha', 'gam', 30, 1)
insert into NguyenLieu(TenNguyenLieu, DonViTinh, DonGiaNL, TrangThai) values (N'Đường', 'kg', 20, 1)
insert into NguyenLieu(TenNguyenLieu, DonViTinh, DonGiaNL, TrangThai) values (N'Mứt hoa quả', 'gam', 50, 1)

