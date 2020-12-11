using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
namespace BUS
{
    public class NhanVien_BUS
    {
        public List<NhanVien_DTO> LayDanhSach()
        {
            NhanVien_DAO objnhanVien_DAO = new NhanVien_DAO();
            return objnhanVien_DAO.LayDanhSachNhanVien();
        }
        public void XoaNhanVien(NhanVien_DTO nv)
        {
            NhanVien_DAO dao = new NhanVien_DAO();
            dao.XoaNhanVien(nv);
        }
        public void SuaNhanVien(NhanVien_DTO nv)
        {
            NhanVien_DAO dao = new NhanVien_DAO();
            dao.SuaThongTinNhanVien(nv);
        }
        public void ThemNhanVien(NhanVien_DTO nv,int TrangThai)
        {
            NhanVien_DAO dao = new NhanVien_DAO();
            dao.ThemNhanVien(nv,TrangThai);

        }
        public void DoiMatKhau(string MatKhau, string MaNV)
        {
            NhanVien_DAO objnhanvien_DAO = new NhanVien_DAO();
            objnhanvien_DAO.DoiMatKhau(MatKhau, MaNV);
        }
        public List<NhanVien_DTO> TimNhanVienTheoMa(string MaNV)
        {
            NhanVien_DAO objnhanVien_DAO = new NhanVien_DAO();
            return objnhanVien_DAO.TimNhanVienTheoMa(MaNV);
        }
    }
}
