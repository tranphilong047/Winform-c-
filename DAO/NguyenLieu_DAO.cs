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
    public class NguyenLieu_DAO
    {
        public List<NguyenLieu_DTO> DanhDachNguyenLieu()
        {
            List<NguyenLieu_DTO> listNL = new List<NguyenLieu_DTO>();
            #region Tạo Kết Nối
            SqlConnection con = DataProvider.TaoKetNoi();
            #endregion
            if (con != null)
            {
                #region Tạo đối tượng truy vấn 
                SqlCommand command = new SqlCommand();
                command.CommandText = @"select * from NguyenLieu where TrangThai = 1";
                command.Connection = con;

                SqlDataReader dataReader = command.ExecuteReader();
                #endregion
                while (dataReader.Read())
                {
                    NguyenLieu_DTO nl = new NguyenLieu_DTO();
                        nl.MaNL = (int)dataReader[0];
                        nl.TenNguyenLieu = dataReader["TenNguyenLieu"].ToString();
                        nl.DonViTinh = dataReader["DonViTinh"].ToString();
                        nl.DonGiaNL = (decimal)dataReader["DonGiaNL"];
                    listNL.Add(nl);
                }
                #region đóng kết nối
                dataReader.Close();
                con.Close();
                #endregion
            }
            return listNL;
        }
        public void XoaNguyenLieu(NguyenLieu_DTO nl)
        {
            SqlConnection con = DataProvider.TaoKetNoi();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = @"UPDATE NguyenLieu SET TrangThai = 0 WHERE MaNL = @MaNL";
            cmd.Parameters.AddWithValue(@"MaNL", nl.MaNL);
            cmd.Connection = con;

            cmd.ExecuteNonQuery();

            con.Close();
        }
        public void SuaThongTinNguyenLieu(NguyenLieu_DTO nl)
        {
            SqlConnection con = DataProvider.TaoKetNoi();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = @"UPDATE NguyenLieu SET TenNguyenLieu = @TenNguyenLieu, DonViTinh = @DonViTinh, DonGiaNL = @DonGiaNL WHERE MaNL = @MaNL";

            cmd.Parameters.Add("@TenNguyenLieu", SqlDbType.NVarChar, 255);
            cmd.Parameters.Add("@DonViTinh", SqlDbType.NVarChar, 255);
            cmd.Parameters.Add("@DonGiaNL", SqlDbType.NVarChar, 255);

            cmd.Parameters["@TenNguyenLieu"].Value = nl.TenNguyenLieu;
            cmd.Parameters["@DonViTinh"].Value = nl.DonViTinh;
            cmd.Parameters["@DonGiaNL"].Value = nl.DonGiaNL;
            
            cmd.Parameters.AddWithValue(@"MaNL", nl.MaNL); ;

            cmd.Connection = con;

            cmd.ExecuteNonQuery();

            con.Close();
        }
        public void ThemNguyenLieu(NguyenLieu_DTO nl, int TrangThai)
        {
            SqlConnection con = DataProvider.TaoKetNoi();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = string.Format("insert into NguyenLieu(TenNguyenLieu, DonViTinh, DonGiaNL, TrangThai) values(N'{0}' ,N'{1}','{2}','{3}')"
                ,nl.TenNguyenLieu,nl.DonViTinh,nl.DonGiaNL,TrangThai);

            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            DataProvider.NgatKetNoi(con);
        }
        public List<NguyenLieu_DTO> TimTheoMa(string manl)
        {
            List<NguyenLieu_DTO> listNL = new List<NguyenLieu_DTO>();
            #region Tạo Kết Nối
            SqlConnection con = DataProvider.TaoKetNoi();
            #endregion
            if (con != null)
            {
                #region Tạo đối tượng truy vấn 
                SqlCommand command = new SqlCommand();
                command.CommandText = @"select * from NguyenLieu where TrangThai = 1 and MaNL = "+manl+"";
                command.Connection = con;

                SqlDataReader dataReader = command.ExecuteReader();
                #endregion
                while (dataReader.Read())
                {
                    NguyenLieu_DTO nl = new NguyenLieu_DTO();
                    nl.MaNL = (int)dataReader[0];
                    nl.TenNguyenLieu = dataReader["TenNguyenLieu"].ToString();
                    nl.DonViTinh = dataReader["DonViTinh"].ToString();
                    nl.DonGiaNL = (decimal)dataReader["DonGiaNL"];
                    listNL.Add(nl);
                }
                #region đóng kết nối
                dataReader.Close();
                con.Close();
                #endregion
            }
            return listNL;
        }
    }
}
