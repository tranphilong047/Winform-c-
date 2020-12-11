using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CTHoaDon_DTO
    {
        public int MaHoaDon { get; set; }
        public int MaSanPham { get; set; }
        public int SoLuongCTHD { get; set; }
        public CTHoaDon_DTO()
        {

        }
        public CTHoaDon_DTO(int _MaHoaDon, int _MaSanPham, int _SoLuong)
        {
            MaHoaDon = _MaHoaDon;
            MaSanPham = _MaSanPham;
            SoLuongCTHD = _SoLuong;
        }
    }
}
