using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CTPhieuNhap_DTO
    {
        public int MaPhieuNhap { get; set; }
        public int MaNguyenLieu { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGiaCTPN { get; set; }
        public decimal ThanhTien { get; set; }
        public CTPhieuNhap_DTO()
        {

        }
    }
}
