using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Dapper;
using System.Linq;

namespace PC.Common.Helpers
{
    public class DapperHelper<T>
    {
        public List<T> Query(string sql)
        {
            //1.109
            ///Data Source=192.168.43.93;Initial Catalog=Practial;User ID=sa;Pwd=12345
            using (SqlConnection con = new SqlConnection(@"Data Source=192.168.43.93;Initial Catalog=Practial;User ID=sa;Pwd=12345"))
            {
                List<T> list = con.Query<T>(sql).ToList();
                return list;
            }
        }
        public int Execute(string sql)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=192.168.43.93;Initial Catalog=Practial;User ID=sa;Pwd=12345"))
            {
                int res = con.Execute(sql);
                return res;
            }
        }
        public T ShowProc(string proc, DynamicParameters par)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=192.168.43.93;Initial Catalog=Practial;User ID=sa;Pwd=12345"))
            {
                return con.Query<T>(proc, par, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
            }
        }
    }
}
