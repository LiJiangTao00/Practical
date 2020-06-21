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
    }
}
