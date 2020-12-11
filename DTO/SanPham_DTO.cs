using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SanPham_DTO
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public string LoaiSP { get; set; }
        public decimal DonGia { get; set; }
        public string IconUrl { get; set; }
        public DateTime NgayTao { get; set; }
        public SanPham_DTO()
        {

        }
        public SanPham_DTO(int _MaSP, string _TenSP, string _LoaiSP, decimal _DonGia, string _IconUrl, DateTime _NgayTao)
        {
            MaSP = _MaSP;
            TenSP = _TenSP;
            LoaiSP = _LoaiSP;
            DonGia = _DonGia;
            IconUrl = _IconUrl;
            NgayTao = _NgayTao;
        }
    }
}
