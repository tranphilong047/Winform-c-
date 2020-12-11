using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    class DataProvider
    {
        private static string chuoiKetNoi = @"Data Source=DESKTOP-3988CEP;Initial Catalog=QuanLyCafeThuc;Integrated Security=True";
        
        //Để thuận tiện sử dụng ở nhiều nới do đó tạo ra phương thức TaoKetNoi()
        public static SqlConnection TaoKetNoi()
        {
            SqlConnection con = null;
                con = new SqlConnection(chuoiKetNoi);
                con.Open();
            return con;
        }
        public static void NgatKetNoi(SqlConnection con)
        {
            con.Close();
        }
    }
}
