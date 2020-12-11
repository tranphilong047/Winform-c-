using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class CTPhieuNhap_BUS
    {
        public List<CTPhieuNhap_DTO> LayDanhSachCTPN()
        {
            CTPhieuNhap_DAO objsanPham_DAO = new CTPhieuNhap_DAO();
            return objsanPham_DAO.DanhDachCTPhieuNhap();
        }

        public void ThemDanhSachCTPN(CTPhieuNhap_DTO ctpnDTO,int trangthai)
        {

            CTPhieuNhap_DAO objsanPham_DAO = new CTPhieuNhap_DAO();
            objsanPham_DAO.themDanhSachCTPN(ctpnDTO,trangthai);
        }
        public void LuuTongTienCTPhieuNhap(int MaPhieuNhap)
        {

            CTPhieuNhap_DAO objsanPham_DAO = new CTPhieuNhap_DAO();
            objsanPham_DAO.LuuTongTienCTPhieuNhap(MaPhieuNhap);
        }
        public List<CTPhieuNhap_DTO> TimCTPhieuNhap(int MaPN)
        {
            CTPhieuNhap_DAO objsanPham_DAO = new CTPhieuNhap_DAO();
            return objsanPham_DAO.TimCTPhieuNhap(MaPN);
        }
        public void XoaDanhSachCTPN(CTPhieuNhap_DTO ctpnDTO)
        {

            CTPhieuNhap_DAO objsanPham_DAO = new CTPhieuNhap_DAO();
            objsanPham_DAO.XoaDanhSachCTPN(ctpnDTO);
        }
    }
}
