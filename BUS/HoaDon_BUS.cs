using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class HoaDon_BUS
    {
        public List<HoaDon_DTO> LayDanhSachHoaDonChoQl()
        {
            HoaDon_DAO objhoadon_DAO = new HoaDon_DAO();
            return objhoadon_DAO.layDanhSachHoaDonChoQL();
        }
        public List<HoaDon_DTO> LayDanhSachHoaDonChoTN()
        {
            HoaDon_DAO objhoadon_DAO = new HoaDon_DAO();
            return objhoadon_DAO.layDanhSachHoaDonChoTN();
        }
        public void ThemDanhSachHoaDon(HoaDon_DTO hdDTO, int TrangThai)
        {
            HoaDon_DAO objhoadon_DAO = new HoaDon_DAO();
            objhoadon_DAO.themDanhSachHoaDOn(hdDTO, TrangThai);
        }
        public void XoaDanhSachHoaDon(HoaDon_DTO hdDTO)
        {
            HoaDon_DAO objhoadon_DAO = new HoaDon_DAO();
            objhoadon_DAO.XoaDanhSachHoaDon(hdDTO);
        }
    }
}
