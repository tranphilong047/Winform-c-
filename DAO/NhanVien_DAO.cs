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
    public class NhanVien_DAO
    {
        public List<NhanVien_DTO> LayDanhSachNhanVien()
        {
            List<NhanVien_DTO> listNV = new List<NhanVien_DTO>();
            #region Tạo Kết Nối
            SqlConnection con = DataProvider.TaoKetNoi();
            #endregion
            if (con != null)
            {
                #region Tạo đối tượng truy vấn 
                SqlCommand command = new SqlCommand();
                command.CommandText = @"select * from NhanVien where TrangThai = 1";
                command.Connection = con;

                SqlDataReader dataReader = command.ExecuteReader();
                #endregion
                while (dataReader.Read())
                {
                    NhanVien_DTO nv = new NhanVien_DTO();
                        nv.MaNV = (int)dataReader[0];
                        nv.HoNV = dataReader["HoNV"].ToString();
                        nv.TenDem = dataReader["TenDem"].ToString();
                        nv.TenNV = dataReader["TenNV"].ToString();
                        nv.NgaySinh = (DateTime)dataReader["NgaySinh"];
                        nv.GioiTinh = dataReader["GioiTinh"].ToString();
                        nv.SDT = dataReader["SDT"].ToString();
                        nv.Email = dataReader["Email"].ToString();
                        nv.ChucVu = dataReader["ChucVu"].ToString();
                        nv.NgayThem = (DateTime)dataReader["NgayThem"];
                        nv.Pass = dataReader["Pass"].ToString();
                    listNV.Add(nv);
                }
                #region đóng kết nối
                dataReader.Close();
                con.Close();
                #endregion
            }
            return listNV;
        }
        public void ThemNhanVien( NhanVien_DTO nv,int TrangThai)
        {
            SqlConnection con = DataProvider.TaoKetNoi();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = string.Format("INSERT INTO NHANVIEN (HoNV, TenDem, TenNV,NgaySinh,GioiTinh,SDT,Email,ChucVu,NgayThem,Pass,TrangThai) VALUES(N'{0}' ,N'{1}',N'{2}','{3}',N'{4}','{5}','{6}',N'{7}','{8}','{9}',{10})"
                , nv.HoNV, nv.TenDem, nv.TenNV, nv.NgaySinh.ToString("yyyy/MM/dd"),nv.GioiTinh,nv.SDT,nv.Email,nv.ChucVu,nv.NgayThem.ToString("yyyy/MM/dd"),nv.Pass,TrangThai);

            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            DataProvider.NgatKetNoi(con);
        }
        public void XoaNhanVien(NhanVien_DTO nv)
        {
            SqlConnection con = DataProvider.TaoKetNoi();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = @"UPDATE NhanVien SET TrangThai = 0 WHERE MaNV = @MaNV";
            cmd.Parameters.AddWithValue(@"MaNV", nv.MaNV);
            cmd.Connection = con;

            cmd.ExecuteNonQuery();

            con.Close();
        }
        public void SuaThongTinNhanVien(NhanVien_DTO nv)
        {
            SqlConnection con = DataProvider.TaoKetNoi();
            SqlCommand cmd = new SqlCommand();

             cmd.CommandText= @"UPDATE NhanVien SET HoNV = @HoNV, TenDem = @TenDem, TenNV = @TenNV,NgaySinh = @NgaySinh,GioiTinh=@GioiTinh,SDT = @SDT,Email=@Email,ChucVu = @ChucVu,NgayThem= @NgayThem,Pass= @Pass WHERE MaNV = @MaNV";


            

            cmd.Parameters.Add("@HoNV", SqlDbType.NVarChar, 255);
            cmd.Parameters.Add("@TenDem", SqlDbType.NVarChar, 255);
            cmd.Parameters.Add("@TenNV", SqlDbType.NVarChar,255);
            cmd.Parameters.Add("@NgaySinh", SqlDbType.DateTime);
            cmd.Parameters.Add("@GioiTinh", SqlDbType.NVarChar,255);
            cmd.Parameters.Add("@SDT", SqlDbType.NVarChar,255);
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar,255);
            cmd.Parameters.Add("@ChucVu", SqlDbType.NVarChar,255);
            cmd.Parameters.Add("@NgayThem", SqlDbType.DateTime);
            cmd.Parameters.Add("@Pass", SqlDbType.NVarChar,255);

            
            cmd.Parameters["@HoNV"].Value = nv.HoNV;
            cmd.Parameters["@TenDem"].Value = nv.TenDem;
            cmd.Parameters["@TenNV"].Value = nv.TenNV;
            cmd.Parameters["@NgaySinh"].Value = nv.NgaySinh.ToString("yyyy/MM/dd");
            cmd.Parameters["@GioiTinh"].Value = nv.GioiTinh;
            cmd.Parameters["@SDT"].Value = nv.SDT;
            cmd.Parameters["@Email"].Value = nv.Email;
            cmd.Parameters["@ChucVu"].Value = nv.ChucVu;
            cmd.Parameters["@NgayThem"].Value = nv.NgayThem.ToString("yyyy/MM/dd");
            cmd.Parameters["@Pass"].Value = nv.Pass;
            
            cmd.Parameters.AddWithValue(@"MaNV", nv.MaNV);
            
            cmd.Connection = con;
            
            cmd.ExecuteNonQuery();

            con.Close();
        }
        public void DoiMatKhau(string MatKhau, string MaNV)
        {
            List<NhanVien_DTO> ds = new List<NhanVien_DTO>();

            SqlConnection con = DataProvider.TaoKetNoi();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = string.Format("UPDATE NHANVIEN SET PASS = '{1}' WHERE MANV = {0}"
                , MaNV, MatKhau);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();

            DataProvider.NgatKetNoi(con);
        }
        public List<NhanVien_DTO> TimNhanVienTheoMa(string MaNV)
        {
            List<NhanVien_DTO> listNV = new List<NhanVien_DTO>();
            #region Tạo Kết Nối
            SqlConnection con = DataProvider.TaoKetNoi();
            #endregion
            if (con != null)
            {
                #region Tạo đối tượng truy vấn 
                SqlCommand command = new SqlCommand();
                command.CommandText = @"select * from NhanVien where TrangThai = 1 and MaNV like "+MaNV+"";
                command.Connection = con;

                SqlDataReader dataReader = command.ExecuteReader();
                #endregion
                while (dataReader.Read())
                {
                    NhanVien_DTO nv = new NhanVien_DTO();
                    nv.MaNV = (int)dataReader[0];
                    nv.HoNV = dataReader["HoNV"].ToString();
                    nv.TenDem = dataReader["TenDem"].ToString();
                    nv.TenNV = dataReader["TenNV"].ToString();
                    nv.NgaySinh = (DateTime)dataReader["NgaySinh"];
                    nv.GioiTinh = dataReader["GioiTinh"].ToString();
                    nv.SDT = dataReader["SDT"].ToString();
                    nv.Email = dataReader["Email"].ToString();
                    nv.ChucVu = dataReader["ChucVu"].ToString();
                    nv.NgayThem = (DateTime)dataReader["NgayThem"];
                    nv.Pass = dataReader["Pass"].ToString();
                    listNV.Add(nv);
                }
                #region đóng kết nối
                dataReader.Close();
                con.Close();
                #endregion
            }
            return listNV;
        }
    }
}
