using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class CTHoaDon_BUS
    {
        public List<CTHoaDon_DTO> LayDanhSachCTHoaDon()
        {
            CTHoaDon_DAO objcthoadon_DAO = new CTHoaDon_DAO();
            return objcthoadon_DAO.layDanhSachCTHoaDon();
        }
        public void ThemDanhSachCTHoaDon(CTHoaDon_DTO cthdDTO, int TrangThai)
        {
            CTHoaDon_DAO objcthoadon_DAO = new CTHoaDon_DAO();
            objcthoadon_DAO.themDanhSachCTHoaDon(cthdDTO, TrangThai);
        }
        public List<CTHoaDon_DTO> TimCTHoaDon(int MaHD)
        {
            CTHoaDon_DAO objcthoadon_DAO = new CTHoaDon_DAO();
            return objcthoadon_DAO.TimCTHoaDon(MaHD);
        }
        public void XoaDanhSachCTHoaDon(CTHoaDon_DTO cthdDTO)
        {
            CTHoaDon_DAO objcthoadon_DAO = new CTHoaDon_DAO();
            objcthoadon_DAO.XoaDanhSachCTHoaDon(cthdDTO);
        }
    }
}
