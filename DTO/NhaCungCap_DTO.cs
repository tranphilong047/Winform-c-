using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhaCungCap_DTO
    {
        public int MaNhaCC { get; set; }
        public string TenNhaCC { get; set; }
        public string SoDTNCC { get; set; }
        public string EmailNCC { get; set; }
        public NhaCungCap_DTO()
        {

        }
        public NhaCungCap_DTO(int _MaNhaCC, string _TenNhaCC, string _SoDTNCC, string _EmailNCC)
        {
            MaNhaCC = _MaNhaCC;
            TenNhaCC = _TenNhaCC;
            SoDTNCC = _SoDTNCC;
            EmailNCC = _EmailNCC;

        }
    }
}
