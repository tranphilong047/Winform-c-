using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NguyenLieu_DTO
    {
        public int MaNL { get; set; }
        public string TenNguyenLieu { get; set; }
        public string DonViTinh { get; set; }
        public decimal DonGiaNL { get; set; }
        public object DonGia { get; set; }

        public NguyenLieu_DTO()
        {

        }
        public NguyenLieu_DTO(int _MaNL, string _TenNguyenLieu, string _DonViTinh, decimal _DonGiaNL)
        {
            MaNL = _MaNL;
            TenNguyenLieu = _TenNguyenLieu;
            DonViTinh = _DonViTinh;
            DonGiaNL = _DonGiaNL;
        }
    }
}
