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

        /// <summary>
        /// 多条件查询物料信息
        /// </summary>
        /// <param name="materialid"></param>
        /// <param name="materialname"></param>
        /// <param name="materialprice"></param>
        /// <returns></returns>
        public List<MaterialTableModel> SelMaterial(string Materialid, string Materialname, float Materialprice, float Materialprice1)
        {
            List<MaterialTableModel> list1 = conn.Query<MaterialTableModel>($"select * from MaterialTable").ToList();
            
            if (Materialprice!=0)
            {
                list1 = conn.Query<MaterialTableModel>($"select * from MaterialTable where Material_Price between {Materialprice} and {Materialprice1} ").ToList();
            }
            else
            {
                list1 = conn.Query<MaterialTableModel>($"select * from MaterialTable").ToList();
            }
            if (Materialid != null)
            {
                list1 = list1.Where(m => m.Material_Id.Contains(Materialid) && m.Material_Name.Contains(Materialname) && m.Material_Price.Equals(Materialprice)).ToList();
            }
            if(Materialid == null && Materialname == null && Materialprice == 0)
            {
                list1 = conn.Query<MaterialTableModel>("select * from MaterialTable").ToList();
            }
            if (Materialid == null || Materialname == null || Materialprice == 0)
            {
                list1 = conn.Query<MaterialTableModel>("select * from MaterialTable").ToList();
            }
            if (Materialname != null)
            {
                list1 = list1.Where(m => m.Material_Id.Contains(Materialid) && m.Material_Name.Contains(Materialname) && m.Material_Price.Equals(Materialprice)).ToList();
            }
            return list1;
        }
    }
}
