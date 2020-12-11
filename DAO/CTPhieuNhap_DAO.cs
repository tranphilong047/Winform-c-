
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class CTPhieuNhap_DAO
    {
        public List<CTPhieuNhap_DTO> DanhDachCTPhieuNhap()
        {
            List<CTPhieuNhap_DTO> listCTPN = new List<CTPhieuNhap_DTO>();
            #region Tạo Kết Nối
            SqlConnection con = DataProvider.TaoKetNoi();
            #endregion
            if (con != null)
            {
                #region Tạo đối tượng truy vấn 
                SqlCommand command = new SqlCommand();
                command.CommandText = @"SELECT MaPhieuNhap,MaNguyenLieu,SoLuong,DonGiaCTPN,ThanhTien from CTPhieuNhap where TrangThai = 1";
                command.Connection = con;

                SqlDataReader dataReader = command.ExecuteReader();
                #endregion
                while (dataReader.Read())
                {
                    CTPhieuNhap_DTO ctpn = new CTPhieuNhap_DTO();
                    if (dataReader.IsDBNull(0) != null)
                    {
                        ctpn.MaPhieuNhap = (int)dataReader[0];
                    }
                    if (dataReader.IsDBNull(1) != null)
                    {
                        ctpn.MaNguyenLieu = (int)dataReader["MaNguyenLieu"];
                    }
                    if (dataReader.IsDBNull(2) != null)
                    {
                        ctpn.SoLuong = (int)dataReader["SoLuong"];
                    }
                    if (dataReader.IsDBNull(3) != null)
                    {
                        ctpn.DonGiaCTPN = (decimal)dataReader["DonGiaCTPN"];
                    }
                    if (dataReader.IsDBNull(4) != null)
                    {
                        ctpn.ThanhTien = (decimal)dataReader["ThanhTien"];
                    }

                    listCTPN.Add(ctpn);
                }
                #region đóng kết nối
                dataReader.Close();
                con.Close();
                #endregion
            }
            return listCTPN;
        }
        public void themDanhSachCTPN(CTPhieuNhap_DTO ctpnDTO,int trangthai)
        {
            List<CTPhieuNhap_DTO> listPN = new List<CTPhieuNhap_DTO>();
            #region Tạo Kết Nối
            SqlConnection con = DataProvider.TaoKetNoi();

            #endregion
            if (con != null)
            {
                
                SqlCommand command = new SqlCommand();

                command.CommandText = string.Format("INSERT INTO CTPhieuNhap(MaPhieuNhap,MaNguyenLieu,SoLuong,DonGiaCTPN,ThanhTien,TrangThai) VALUES({0}, {1}, {2}, {3}, {4},{5})"
                    , ctpnDTO.MaPhieuNhap, ctpnDTO.MaNguyenLieu, ctpnDTO.SoLuong, ctpnDTO.DonGiaCTPN, ctpnDTO.ThanhTien,trangthai);
                command.Connection = con;
                command.ExecuteNonQuery();

                DataProvider.NgatKetNoi(con);

            }
        }
        public void LuuTongTienCTPhieuNhap(int MaPhieuNhap)
        {
            List<CTPhieuNhap_DTO> listPN = new List<CTPhieuNhap_DTO>();
            #region Tạo Kết Nối
            SqlConnection con = DataProvider.TaoKetNoi();

            #endregion
            if (con != null)
            {
                SqlCommand command = new SqlCommand();

                command.CommandText = string.Format("UPDATE PhieuNhap SET TongTien = (SELECT SUM(ThanhTien) FROM  CTPhieuNhap WHERE MaPhieuNhap = {0}) WHERE MaPN = {0}"
                    , MaPhieuNhap);
                command.Connection = con;
                command.ExecuteNonQuery();

                DataProvider.NgatKetNoi(con);

            } 
        }
        public List<CTPhieuNhap_DTO> TimCTPhieuNhap(int MaPN)
        {
            List<CTPhieuNhap_DTO> listCTPN = new List<CTPhieuNhap_DTO>();
            #region Tạo Kết Nối
            SqlConnection con = DataProvider.TaoKetNoi();
            #endregion
            if (con != null)
            {
                #region Tạo đối tượng truy vấn 
                SqlCommand command = new SqlCommand();
                command.CommandText = @"SELECT MaPhieuNhap,MaNguyenLieu,SoLuong,DonGiaCTPN,ThanhTien from CTPhieuNhap where TrangThai = 1 and MaPhieuNhap= '" + MaPN + "' ";
                command.Connection = con;

                SqlDataReader dataReader = command.ExecuteReader();
                #endregion
                while (dataReader.Read())
                {
                    CTPhieuNhap_DTO ctpn = new CTPhieuNhap_DTO();
                    if (dataReader.IsDBNull(0) != null)
                    {
                        ctpn.MaPhieuNhap = (int)dataReader[0];
                    }
                    if (dataReader.IsDBNull(1) != null)
                    {
                        ctpn.MaNguyenLieu = (int)dataReader["MaNguyenLieu"];
                    }
                    if (dataReader.IsDBNull(2) != null)
                    {
                        ctpn.SoLuong = (int)dataReader["SoLuong"];
                    }
                    if (dataReader.IsDBNull(3) != null)
                    {
                        ctpn.DonGiaCTPN = (decimal)dataReader["DonGiaCTPN"];
                    }
                    if (dataReader.IsDBNull(4) != null)
                    {
                        ctpn.ThanhTien = (decimal)dataReader["ThanhTien"];
                    }

                    listCTPN.Add(ctpn);
                }
                #region đóng kết nối
                dataReader.Close();
                con.Close();
                #endregion
            }
            return listCTPN;
        }
        public void XoaDanhSachCTPN(CTPhieuNhap_DTO ctpnDTO)
        {
            List<CTPhieuNhap_DTO> listCTPN = new List<CTPhieuNhap_DTO>();
            #region Tạo Kết Nối
            SqlConnection con = DataProvider.TaoKetNoi();

            #endregion
            if (con != null)
            {
                SqlCommand command = new SqlCommand();

                command.CommandText = @"UPDATE CTPhieuNhap set TrangThai = 0 where MaPhieuNhap = @MaPhieuNhap";
                command.Parameters.AddWithValue(@"MaPhieuNhap", ctpnDTO.MaPhieuNhap);
                command.Connection = con;
                command.ExecuteNonQuery();

                DataProvider.NgatKetNoi(con);

            }
        }
    }
}
