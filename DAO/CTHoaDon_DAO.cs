using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class CTHoaDon_DAO
    {
        public List<CTHoaDon_DTO> layDanhSachCTHoaDon()
        {
            List<CTHoaDon_DTO> listCTHD = new List<CTHoaDon_DTO>();
            #region Tạo Kết Nối
            SqlConnection con = DataProvider.TaoKetNoi();

            #endregion
            if (con != null)
            {

                #region Tạo đối tượng truy vấn 

                SqlCommand command = new SqlCommand();

                command.CommandText = @"SELECT MaHoaDon, MaSanPham, SoLuongCTHD FROM CTHoaDon where TrangThai = 1";
                command.Connection = con;

                SqlDataReader dataReader = command.ExecuteReader();
                #endregion
                while (dataReader.Read())
                {
                    CTHoaDon_DTO cthd = new CTHoaDon_DTO();
                    if (dataReader.IsDBNull(0) != null)
                    {
                        cthd.MaHoaDon = (int)dataReader[0];
                    }
                    if (dataReader.IsDBNull(1) != null)
                    {
                        cthd.MaSanPham = (int)dataReader["MaSanPham"];
                    }
                    if (dataReader.IsDBNull(2) != null)
                    {
                        cthd.SoLuongCTHD = (int)dataReader["SoLuongCTHD"];
                    }                   
                    listCTHD.Add(cthd);
                }
                #region đóng kết nối
                dataReader.Close();
                con.Close();
                #endregion
            }
            return listCTHD;
        }
        public void themDanhSachCTHoaDon(CTHoaDon_DTO cthdDTO, int TrangThai)
        {
            List<CTHoaDon_DTO> listHD = new List<CTHoaDon_DTO>();
            #region Tạo Kết Nối
            SqlConnection con = DataProvider.TaoKetNoi();

            #endregion
            if (con != null)
            {
                SqlCommand command = new SqlCommand();

                command.CommandText = string.Format("INSERT INTO CTHOADON(MAHOADON, MASANPHAM, SOLUONGCTHD, TRANGTHAI) VALUES ({0}, {1}, {2}, {3})"
                    ,cthdDTO.MaHoaDon, cthdDTO.MaSanPham, cthdDTO.SoLuongCTHD, TrangThai);
                command.Connection = con;
                command.ExecuteNonQuery();

                DataProvider.NgatKetNoi(con);
            }


        }
        public List<CTHoaDon_DTO> TimCTHoaDon(int MaHD)
        {
            List<CTHoaDon_DTO> listCTHD = new List<CTHoaDon_DTO>();
            #region Tạo Kết Nối
            SqlConnection con = DataProvider.TaoKetNoi();

            #endregion
            if (con != null)
            {

                #region Tạo đối tượng truy vấn 

                SqlCommand command = new SqlCommand();

                command.CommandText = @"SELECT MaHoaDon, MaSanPham, SoLuongCTHD FROM CTHoaDon where TrangThai = 1 and MaHoaDon = "+MaHD+"";
                command.Connection = con;

                SqlDataReader dataReader = command.ExecuteReader();
                #endregion
                while (dataReader.Read())
                {
                    CTHoaDon_DTO cthd = new CTHoaDon_DTO();
                    if (dataReader.IsDBNull(0) != null)
                    {
                        cthd.MaHoaDon = (int)dataReader[0];
                    }
                    if (dataReader.IsDBNull(1) != null)
                    {
                        cthd.MaSanPham = (int)dataReader["MaSanPham"];
                    }
                    if (dataReader.IsDBNull(2) != null)
                    {
                        cthd.SoLuongCTHD = (int)dataReader["SoLuongCTHD"];
                    }
                    listCTHD.Add(cthd);
                }
                #region đóng kết nối
                dataReader.Close();
                con.Close();
                #endregion
            }
            return listCTHD;
        }
        public void XoaDanhSachCTHoaDon(CTHoaDon_DTO cthdDTO)
        {
            List<CTHoaDon_DTO> listCTHD = new List<CTHoaDon_DTO>();
            #region Tạo Kết Nối
            SqlConnection con = DataProvider.TaoKetNoi();

            #endregion
            if (con != null)
            {
                SqlCommand command = new SqlCommand();

                command.CommandText = @"UPDATE CTHOADON set TrangThai = 0 where MaHoaDon = @MaHoaDon";
                command.Parameters.AddWithValue(@"MaHoaDon", cthdDTO.MaHoaDon);
                command.Connection = con;
                command.ExecuteNonQuery();

                DataProvider.NgatKetNoi(con);

            }
        }
    }
}
