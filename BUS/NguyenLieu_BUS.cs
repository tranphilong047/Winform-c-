using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class NguyenLieu_BUS
    {
        public List<NguyenLieu_DTO> LayDanhSachNguyenLieu()
        {
            NguyenLieu_DAO objnguyenLieu_DAO = new NguyenLieu_DAO();
            return objnguyenLieu_DAO.DanhDachNguyenLieu();
        }
        public void XoaNguyenLieu(NguyenLieu_DTO nl)
        {
            NguyenLieu_DAO dao = new NguyenLieu_DAO();
            dao.XoaNguyenLieu(nl);
        }
        public void SuaThongTinNguyenLieu(NguyenLieu_DTO nl)
        {
            NguyenLieu_DAO dao = new NguyenLieu_DAO();
            dao.SuaThongTinNguyenLieu(nl);
        }
        public void ThemNguyenLieu(NguyenLieu_DTO nl, int TrangThai)
        {
            NguyenLieu_DAO dao = new NguyenLieu_DAO();
            dao.ThemNguyenLieu(nl, TrangThai);

        }
        public List<NguyenLieu_DTO> TimTheoMaNL(string manl)
        {
            NguyenLieu_DAO objnguyenLieu_DAO = new NguyenLieu_DAO();
            return objnguyenLieu_DAO.TimTheoMa(manl);
        }
    }
}
