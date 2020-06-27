using System;
using System.Collections.Generic;
using System.Text;
using PC.Model.Models;
using PC.IDAL.IMaterialDAL;
using Dapper;
using System.Data.SqlClient;
using System.Linq;
using PC.Model.ViewModel;

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
        public PageShowMaterial SelMaterial(string Materialid, string Materialname, float Materialprice = -1, float Materialprice1 = -1,int PageIndex = 1, int PageSize = 3)
       {

            string sql = "select * from MaterialTable where 1=1";
            if (Materialid!= null)
            {
                sql += " and Material_Id like '%" + Materialid + "%'";
            }
            if (Materialname!=null)
            {
                sql += " and Material_Name like '%" + Materialname + "%'";
            }
            if (Materialprice!=-1)
            {
                sql += " and Material_Price >"+Materialprice;
            }
               

            if (Materialprice1 != -1)
            {
                sql += " and Material_Price <" + Materialprice1;
            }
           // sql += " and Id between" + (PageIndex - 1) * PageSize + 1 + " and  " + PageIndex * PageSize;

            List<MaterialTableModel> list = new List<MaterialTableModel>();
            list= conn.Query<MaterialTableModel>(sql).ToList();

            var pagelist = list.Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList();

            PageShowMaterial PageShowData= new PageShowMaterial();
            PageShowData.PageShowMateriallist = pagelist;
            PageShowData.DataCount = list.Count();
            PageShowData.PageSize = PageSize;

            return PageShowData;
        }

        /// <summary>
        /// 添加物料
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        public int AddMaterial(MaterialTableModel mod)
        {
            return conn.Execute($"insert into MaterialTable values('{mod.Material_TypeId}','{mod.Material_Id}','{mod.Material_Name}','{mod.Material_Desc}','{mod.Material_Image}','{mod.Material_Price}','{mod.Material_Number}','{mod.Material_State}')");
        }
    }
}
