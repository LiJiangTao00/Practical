using System;
using System.Collections.Generic;
using System.Text;
using PC.Model.Models;
using PC.IDAL.IMaterialDAL;
using Dapper;
using System.Data.SqlClient;
using System.Linq;

namespace PC.DAL.MaterialDal
{
    public class MaterialDAL : IMaterialDAL  // 接口
    {
        //连接数据库
        SqlConnection conn = new SqlConnection("Data Source=192.168.43.93;Initial Catalog=Practial;User ID=sa;pwd=12345");

        /// <summary>
        /// 显示物料信息
        /// </summary>
        /// <returns></returns>
        public List<MaterialTableModel> ShowMaterial()
        {
            return conn.Query<MaterialTableModel>("select * from MaterialTable").ToList();
        }

        /// <summary>
        /// 显示物料下拉信息
        /// </summary>
        /// <returns></returns>
        public List<MaterialTypeTableModel> GetTypes()
        {
            return conn.Query<MaterialTypeTableModel>("select * from MaterialTypeTable").ToList();
        }
    }
}
