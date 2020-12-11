using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
namespace BUS
{
    public class SanPham_BUS
    {
        public List<SanPham_DTO> LayDanhSachSanPham()
        {
            SanPham_DAO objsanPham_DAO = new SanPham_DAO();
            return objsanPham_DAO.layDanhSachSanPham();
        }
        public void ThemSanPham(SanPham_DTO sp,int trangthai)
        {
            SanPham_DAO dao = new SanPham_DAO();
            dao.ThemSanPham(sp,trangthai);
        }
        public void XoaSanPham(SanPham_DTO sp)
        {
            SanPham_DAO dao = new SanPham_DAO();
            dao.XoaSanPham(sp);
        }
        public void SuaThongTinSanPham(SanPham_DTO sp)
        {
            SanPham_DAO dao = new SanPham_DAO();
            dao.SuaThongTinSanPham(sp);
        }
        public List<SanPham_DTO> TimSanPhamTheoMa(string MaSP)
        {
            SanPham_DAO objsanPham_DAO = new SanPham_DAO();
            return objsanPham_DAO.TimSanPhamTheoMa(MaSP);
        }
    }
}
