using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class PhieuNhap_DAO
    {
        public List<PhieuNhap_DTO> layDanhSachPhieuNhap()
        {
            List<PhieuNhap_DTO> listPN = new List<PhieuNhap_DTO>();
            #region Tạo Kết Nối
            SqlConnection con = DataProvider.TaoKetNoi();


            #endregion
            if (con != null)
            {

                #region Tạo đối tượng truy vấn 

                SqlCommand command = new SqlCommand();

                command.CommandText = @"SELECT MaPN, NgayTaoPN, MaNhanVien, MaNhaCungCap, TongTien FROM PhieuNhap where TrangThai = 1";
                command.Connection = con;

                SqlDataReader dataReader = command.ExecuteReader();
                #endregion
                while (dataReader.Read())
                {
                    PhieuNhap_DTO pn = new PhieuNhap_DTO();
                    if (dataReader.IsDBNull(0) != null)
                    {
                        pn.MaPN = (int)dataReader["MaPN"];
                    }
                    if (dataReader.IsDBNull(1) != null)
                    {
                        pn.NgayTaoPN = (DateTime)dataReader["NgayTaoPN"];
                    }
                    if (dataReader.IsDBNull(2) != null)
                    {
                        pn.MaNhanVien = (int)dataReader["MaNhanVien"];
                    }
                    if (dataReader.IsDBNull(3) != null)
                    {
                        pn.MaNhaCungCap = (int)dataReader["MaNhaCungCap"];
                    }
                    if (dataReader.IsDBNull(4) != null)
                    {
                        pn.TongTien = (decimal)dataReader["TongTien"];
                    }

                    listPN.Add(pn);
                }


                #region đóng kết nối
                dataReader.Close();
                con.Close();
                #endregion
            }
            return listPN;


        }
        public void themDanhSachPN(PhieuNhap_DTO pnDTO,int trangthai)
        {
            List<PhieuNhap_DTO> listPN = new List<PhieuNhap_DTO>();
            #region Tạo Kết Nối
            SqlConnection con = DataProvider.TaoKetNoi();

            #endregion
            if (con != null)
            {
               

                SqlCommand command = new SqlCommand();

                command.CommandText = string.Format("INSERT INTO PhieuNhap(MaNhanVien,MaNhaCungCap,NgayTaoPN,TongTien,TrangThai) VALUES({0}, {1}, '{2}', {3},{4})"
                    , pnDTO.MaNhanVien, pnDTO.MaNhaCungCap, pnDTO.NgayTaoPN, pnDTO.TongTien,trangthai);
                command.Connection = con;
                command.ExecuteNonQuery();

                DataProvider.NgatKetNoi(con);

            }
        }
        public void XoaDanhSachPN(PhieuNhap_DTO pnDTO)
        {
            List<PhieuNhap_DTO> listPN = new List<PhieuNhap_DTO>();
            #region Tạo Kết Nối
            SqlConnection con = DataProvider.TaoKetNoi();

            #endregion
            if (con != null)
            {
                SqlCommand command = new SqlCommand();

                command.CommandText = @"UPDATE PhieuNhap set TrangThai = 0 where MaPN = @MaPN";
                command.Parameters.AddWithValue(@"MaPN", pnDTO.MaPN);
                command.Connection = con;
                command.ExecuteNonQuery();

                DataProvider.NgatKetNoi(con);

            }
        }

    }
}
