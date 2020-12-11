using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class PhieuNhap_BUS
    {
        public List<PhieuNhap_DTO> LayDanhSachPhieuNhap()
        {
            PhieuNhap_DAO objsanPham_DAO = new PhieuNhap_DAO();
            return objsanPham_DAO.layDanhSachPhieuNhap();
        }
       
        public void ThemDanhSachPN(PhieuNhap_DTO pnDTO,int trangthai)
        {

            PhieuNhap_DAO objsanPham_DAO = new PhieuNhap_DAO();
            objsanPham_DAO.themDanhSachPN(pnDTO,trangthai);
        }
        public void XoaDanhSachPN(PhieuNhap_DTO pnDTO)
        {

            PhieuNhap_DAO objsanPham_DAO = new PhieuNhap_DAO();
            objsanPham_DAO.XoaDanhSachPN(pnDTO);
        }
    }
}
