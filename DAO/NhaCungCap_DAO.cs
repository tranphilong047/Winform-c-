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
    public class NhaCungCap_DAO
    {
        public List<NhaCungCap_DTO> LayDanhSachNhaCungCap()
        {
            List<NhaCungCap_DTO> listNCC = new List<NhaCungCap_DTO>();
            #region Tạo Kết Nối
            SqlConnection con = DataProvider.TaoKetNoi();
            #endregion
            if (con != null)
            {
                #region Tạo đối tượng truy vấn 
                SqlCommand command = new SqlCommand();
                command.CommandText = @"select * from NhaCungCap where TrangThai = 1";
                command.Connection = con;

                SqlDataReader dataReader = command.ExecuteReader();
                #endregion
                while (dataReader.Read())
                {
                    NhaCungCap_DTO ncc = new NhaCungCap_DTO();
                        ncc.MaNhaCC = (int)dataReader[0];
                        ncc.TenNhaCC = dataReader["TenNhaCC"].ToString();
                        ncc.SoDTNCC = dataReader["SoDTNCC"].ToString();
                        ncc.EmailNCC = dataReader["EmailNCC"].ToString();
                    listNCC.Add(ncc);
                }
                #region đóng kết nối
                dataReader.Close();
                con.Close();
                #endregion
            }
            return listNCC;
        }
        public void XoaNhaCungCap(NhaCungCap_DTO ncc)
        {
            SqlConnection con = DataProvider.TaoKetNoi();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = @"UPDATE NhaCungCap SET TrangThai = 0 WHERE MaNhaCC = @MaNhaCC";
            cmd.Parameters.AddWithValue(@"MaNhaCC", ncc.MaNhaCC);
            cmd.Connection = con;

            cmd.ExecuteNonQuery();

            con.Close();
        }
        public void SuaThongTinNhaCungCap(NhaCungCap_DTO ncc)
        {
            SqlConnection con = DataProvider.TaoKetNoi();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = @"UPDATE NhaCungCap SET TenNhaCC = @TenNhaCC, SoDTNCC = @SoDTNCC, EmailNCC = @EmailNCC WHERE MaNhaCC = @MaNhaCC";

            cmd.Parameters.Add("@TenNhaCC", SqlDbType.NVarChar, 255);
            cmd.Parameters.Add("@SoDTNCC", SqlDbType.NVarChar, 255);
            cmd.Parameters.Add("@EmailNCC", SqlDbType.NVarChar, 255);

            cmd.Parameters["@TenNhaCC"].Value = ncc.TenNhaCC;
            cmd.Parameters["@SoDTNCC"].Value = ncc.SoDTNCC;
            cmd.Parameters["@EmailNCC"].Value = ncc.EmailNCC;

            cmd.Parameters.AddWithValue(@"MaNhaCC", ncc.MaNhaCC); ;

            cmd.Connection = con;

            cmd.ExecuteNonQuery();

            con.Close();
        }
        public void ThemNhaCungCap(NhaCungCap_DTO ncc, int TrangThai)
        {
            SqlConnection con = DataProvider.TaoKetNoi();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = string.Format("insert into NhaCungCap (TenNhaCC, SoDTNCC, EmailNCC, TrangThai) values('{0}' ,{1},'{2}','{3}')"
                , ncc.TenNhaCC, ncc.SoDTNCC, ncc.EmailNCC, TrangThai);

            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            DataProvider.NgatKetNoi(con);
        }
        public List<NhaCungCap_DTO> TimKiemNhaCungCap(string MaNCC)
        {
            List<NhaCungCap_DTO> listNCC = new List<NhaCungCap_DTO>();
            #region Tạo Kết Nối
            SqlConnection con = DataProvider.TaoKetNoi();
            #endregion
            if (con != null)
            {
                #region Tạo đối tượng truy vấn 
                SqlCommand command = new SqlCommand();
                command.CommandText = @"select * from NhaCungCap where TrangThai = 1 and MaNhaCC = "+MaNCC+";";
                command.Connection = con;

                SqlDataReader dataReader = command.ExecuteReader();
                #endregion
                while (dataReader.Read())
                {
                    NhaCungCap_DTO ncc = new NhaCungCap_DTO();
                    ncc.MaNhaCC = (int)dataReader[0];
                    ncc.TenNhaCC = dataReader["TenNhaCC"].ToString();
                    ncc.SoDTNCC = dataReader["SoDTNCC"].ToString();
                    ncc.EmailNCC = dataReader["EmailNCC"].ToString();
                    listNCC.Add(ncc);
                }
                #region đóng kết nối
                dataReader.Close();
                con.Close();
                #endregion
            }
            return listNCC;
        }
    }
}
