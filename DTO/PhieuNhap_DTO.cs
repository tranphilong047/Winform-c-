
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhieuNhap_DTO
    {
        public int MaPN { get; set; }
        public DateTime NgayTaoPN { get; set; }
        public int MaNhanVien { get; set; }
        public int MaNhaCungCap { get; set; }
        public decimal TongTien { get; set; }
        public PhieuNhap_DTO()
        {

        }

    }
}
