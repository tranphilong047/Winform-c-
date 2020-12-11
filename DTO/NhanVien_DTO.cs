using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVien_DTO
    {
        public int MaNV { get; set; }
        public string HoNV { get; set; }
        public string TenDem { get; set; }
        public string TenNV { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public string ChucVu { get; set; }
        public DateTime NgayThem { get; set; }
        public string Pass { get; set; }

        public NhanVien_DTO()
        {

        }
        public NhanVien_DTO(int _MaNV, string _HoNV, string _TenDem, string _TenNV, DateTime _NgaySinh, string _GioiTinh,string _SDT, string _Email, string _ChucVu, DateTime _NgayThem, string _Pass)
        {
            MaNV = _MaNV;
            HoNV = _HoNV;
            TenDem = _TenDem;
            TenNV = _TenNV;
            NgaySinh = _NgaySinh;
            GioiTinh = _GioiTinh;
            SDT = _SDT;
            Email = _Email;
            ChucVu = _ChucVu;
            NgayThem = _NgayThem;
            Pass = _Pass;
        }
       
    }
}
