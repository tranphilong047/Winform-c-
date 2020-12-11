using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDon_DTO
    {
        public int MaHD { get; set; }
        public decimal ThanhTienHD { get; set; }
        public DateTime NgayTaoHD { get; set; }
        public int MaNhanVienHD { get; set; }

        public HoaDon_DTO()
        {

        }
        public HoaDon_DTO(int _MaHD, decimal _ThanhTien, DateTime _NgayTao, int _MaNhanVien)
        {
            MaHD = _MaHD;
            ThanhTienHD = _ThanhTien;
            NgayTaoHD = _NgayTao;
            MaNhanVienHD = _MaNhanVien;
        }
    }
}
