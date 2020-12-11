using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class NhaCungCap_BUS
    {
        public List<NhaCungCap_DTO> LayDanhSachNhaCungCap()
        {
            NhaCungCap_DAO objnhaCungCap_DAO = new NhaCungCap_DAO();
            return objnhaCungCap_DAO.LayDanhSachNhaCungCap();
        }
        public void XoaNhaCungCap(NhaCungCap_DTO ncc)
        {
            NhaCungCap_DAO dao = new NhaCungCap_DAO();
            dao.XoaNhaCungCap(ncc);
        }
        public void SuaThongTinNhaCungCap(NhaCungCap_DTO ncc)
        {
            NhaCungCap_DAO dao = new NhaCungCap_DAO();
            dao.SuaThongTinNhaCungCap(ncc);
        }
        public void ThemNhaCungCap(NhaCungCap_DTO ncc, int TrangThai)
        {
            NhaCungCap_DAO dao = new NhaCungCap_DAO();
            dao.ThemNhaCungCap(ncc, TrangThai);

        }
        public List<NhaCungCap_DTO> TimKiemNhaCungCap(string MaNCC)
        {
            NhaCungCap_DAO objnhaCungCap_DAO = new NhaCungCap_DAO();
            return objnhaCungCap_DAO.TimKiemNhaCungCap(MaNCC);
        }
    }
}
