using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class HoaDon_DAO
    {
        public List<HoaDon_DTO> layDanhSachHoaDonChoQL()
        {
            List<HoaDon_DTO> listHD = new List<HoaDon_DTO>();
            #region Tạo Kết Nối
            SqlConnection con = DataProvider.TaoKetNoi();

            #endregion
            if (con != null)
            {
                #region Tạo đối tượng truy vấn 

                SqlCommand command = new SqlCommand();

                command.CommandText = @"SELECT MaHD, ThanhTienHD, NgayTaoHD, MaNhanVienHD FROM HoaDon where TrangThai = 1";
                command.Connection = con;

                SqlDataReader dataReader = command.ExecuteReader();
                #endregion
                while (dataReader.Read())
                {
                    HoaDon_DTO hd = new HoaDon_DTO();
                    if (dataReader.IsDBNull(0) != null)
                    {
                        hd.MaHD = (int)dataReader[0];
                    }
                    if (dataReader.IsDBNull(1) != null)
                    {
                        hd.ThanhTienHD = (decimal)dataReader["ThanhTienHD"];
                    }
                    if (dataReader.IsDBNull(2) != null)
                    {
                        hd.NgayTaoHD = (DateTime)dataReader["NgayTaoHD"];
                    }
                    if (dataReader.IsDBNull(3) != null)
                    {
                        hd.MaNhanVienHD = (int)dataReader["MaNhanVienHD"];
                    }

                    listHD.Add(hd);
                }
                #region đóng kết nối
                dataReader.Close();
                con.Close();
                #endregion
            }
            return listHD;
        }
        public List<HoaDon_DTO> layDanhSachHoaDonChoTN()
        {
            List<HoaDon_DTO> listHD = new List<HoaDon_DTO>();
            #region Tạo Kết Nối
            SqlConnection con = DataProvider.TaoKetNoi();

            #endregion
            if (con != null)
            {
                #region Tạo đối tượng truy vấn 

                SqlCommand command = new SqlCommand();

                command.CommandText = @"SELECT MaHD, ThanhTienHD, NgayTaoHD, MaNhanVienHD FROM HoaDon";
                command.Connection = con;

                SqlDataReader dataReader = command.ExecuteReader();
                #endregion
                while (dataReader.Read())
                {
                    HoaDon_DTO hd = new HoaDon_DTO();
                    if (dataReader.IsDBNull(0) != null)
                    {
                        hd.MaHD = (int)dataReader[0];
                    }
                    if (dataReader.IsDBNull(1) != null)
                    {
                        hd.ThanhTienHD = (decimal)dataReader["ThanhTienHD"];
                    }
                    if (dataReader.IsDBNull(2) != null)
                    {
                        hd.NgayTaoHD = (DateTime)dataReader["NgayTaoHD"];
                    }
                    if (dataReader.IsDBNull(3) != null)
                    {
                        hd.MaNhanVienHD = (int)dataReader["MaNhanVienHD"];
                    }

                    listHD.Add(hd);
                }
                #region đóng kết nối
                dataReader.Close();
                con.Close();
                #endregion
            }
            return listHD;
        }
        public void themDanhSachHoaDOn(HoaDon_DTO hdDTO, int TrangThai)
        {
            List<HoaDon_DTO> listHD = new List<HoaDon_DTO>();
            #region Tạo Kết Nối
            SqlConnection con = DataProvider.TaoKetNoi();
            
            #endregion
            if (con != null)
            {
                SqlCommand command = new SqlCommand();

                command.CommandText = string.Format("INSERT INTO HOADON(THANHTIENHD, NGAYTAOHD, MANHANVIENHD, TRANGTHAI) VALUES({0}, '{1}', {2}, {3})"
                    , hdDTO.ThanhTienHD, hdDTO.NgayTaoHD, hdDTO.MaNhanVienHD, TrangThai);
                command.Connection = con;
                command.ExecuteNonQuery();

                DataProvider.NgatKetNoi(con);
            }
        }
        public void XoaDanhSachHoaDon(HoaDon_DTO hdDTO)
        {
            List<HoaDon_DTO> listHD = new List<HoaDon_DTO>();
            #region Tạo Kết Nối
            SqlConnection con = DataProvider.TaoKetNoi();

            #endregion
            if (con != null)
            {
                SqlCommand command = new SqlCommand();

                command.CommandText = @"UPDATE HOADON set TrangThai = 0 where MaHD = @MaHD";
                command.Parameters.AddWithValue(@"MaHD", hdDTO.MaHD);
                command.Connection = con;
                command.ExecuteNonQuery();

                DataProvider.NgatKetNoi(con);

            }
        }
    }
}
