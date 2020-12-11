using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAO
{
    public class SanPham_DAO
    {
        public List<SanPham_DTO> layDanhSachSanPham()
        {
            List<SanPham_DTO> listSP = new List<SanPham_DTO>();
            #region Tạo Kết Nối
            SqlConnection con = DataProvider.TaoKetNoi();

           
            #endregion
            if (con != null)
            {

                #region Tạo đối tượng truy vấn 

                SqlCommand command = new SqlCommand();

                command.CommandText = @"SELECT MaSP, TenSP, LoaiSP, DonGia, IconUrl, NgayTao FROM SanPham where TrangThai = 1";
                command.Connection = con;

                SqlDataReader dataReader = command.ExecuteReader();
                #endregion
                while (dataReader.Read())
                {
                    SanPham_DTO sp = new SanPham_DTO();
                        sp.MaSP = (int)dataReader[0];
                        sp.TenSP = dataReader["TenSP"].ToString();
                        sp.LoaiSP = dataReader["LoaiSP"].ToString();
                        sp.DonGia = (decimal)dataReader["DonGia"];
                        sp.IconUrl = dataReader["IconUrl"].ToString();
                        sp.NgayTao = (DateTime)dataReader["NgayTao"];
                    listSP.Add(sp);
                }
                #region đóng kết nối
                dataReader.Close();
                con.Close();
                #endregion
            }
            return listSP;
        }
        public void XoaSanPham(SanPham_DTO sp)
        {
            SqlConnection con = DataProvider.TaoKetNoi();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = @"UPDATE SanPham SET TrangThai = 0 WHERE MaSP = @MaSP";
            cmd.Parameters.AddWithValue(@"MaSP", sp.MaSP);
            cmd.Connection = con;

            cmd.ExecuteNonQuery();

            con.Close();
        }
        public void ThemSanPham(SanPham_DTO sp,int TrangThai)
        {
            SqlConnection con = DataProvider.TaoKetNoi();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = string.Format("INSERT INTO SanPham (TenSP, LoaiSP, DonGia, IconUrl, NgayTao, TrangThai) VALUES(N'{0}' ,N'{1}',{2},'{3}',N'{4}',{5})"
                , sp.TenSP, sp.LoaiSP, sp.DonGia, sp.IconUrl,sp.NgayTao.ToString("yyyy/MM/dd"), TrangThai);

            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            DataProvider.NgatKetNoi(con);
        }
        public void SuaThongTinSanPham(SanPham_DTO sp)
        {
            SqlConnection con = DataProvider.TaoKetNoi();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = @"UPDATE SanPham SET TenSP = @TenSP, LoaiSP = @LoaiSP, DonGia = @DonGia,IconUrl = @IconUrl, NgayTao = @NgayTao WHERE MaSP = @MaSP";

            cmd.Parameters.Add("@TenSP", SqlDbType.NVarChar, 255);
            cmd.Parameters.Add("@LoaiSP", SqlDbType.NVarChar, 255);
            cmd.Parameters.Add("@DonGia", SqlDbType.NVarChar, 255);
            cmd.Parameters.Add("@IconUrl", SqlDbType.NVarChar, 255);
            cmd.Parameters.Add("@NgayTao", SqlDbType.NVarChar, 255);


            cmd.Parameters["@TenSP"].Value = sp.TenSP;
            cmd.Parameters["@LoaiSP"].Value = sp.LoaiSP;
            cmd.Parameters["@DonGia"].Value = sp.DonGia;
            cmd.Parameters["@IconUrl"].Value = sp.IconUrl;
            cmd.Parameters["@NgayTao"].Value = sp.NgayTao.ToString("yyyy/MM/dd");


            cmd.Parameters.AddWithValue(@"MaSP", sp.MaSP);

            cmd.Connection = con;

            cmd.ExecuteNonQuery();

            con.Close();
        }
        public List<SanPham_DTO> TimSanPhamTheoMa(string MaSP)
        {
            List<SanPham_DTO> listSP = new List<SanPham_DTO>();
            #region Tạo Kết Nối
            SqlConnection con = DataProvider.TaoKetNoi();


            #endregion
            if (con != null)
            {

                #region Tạo đối tượng truy vấn 

                SqlCommand command = new SqlCommand();

                command.CommandText = @"SELECT MaSP, TenSP, LoaiSP, DonGia, IconUrl, NgayTao FROM SanPham where TrangThai = 1 and MaSP = "+MaSP+"";
                command.Connection = con;

                SqlDataReader dataReader = command.ExecuteReader();
                #endregion
                while (dataReader.Read())
                {
                    SanPham_DTO sp = new SanPham_DTO();
                    sp.MaSP = (int)dataReader[0];
                    sp.TenSP = dataReader["TenSP"].ToString();
                    sp.LoaiSP = dataReader["LoaiSP"].ToString();
                    sp.DonGia = (decimal)dataReader["DonGia"];
                    sp.IconUrl = dataReader["IconUrl"].ToString();
                    sp.NgayTao = (DateTime)dataReader["NgayTao"];
                    listSP.Add(sp);
                }
                #region đóng kết nối
                dataReader.Close();
                con.Close();
                #endregion
            }
            return listSP;
        }
    }
}
