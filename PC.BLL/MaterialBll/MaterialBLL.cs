using System;
using System.Collections.Generic;
using System.Text;
using PC.Model.Models;
using PC.IDAL.IMaterialDAL;
using PC.DAL.MaterialDal;
using Dapper;
using System.Data.SqlClient;
using PC.IBLL.MaterialBLL;
using PC.Model.ViewModel;

namespace PC.BLL.MaterialBll
{
    public class MaterialBLL : IMaterialBLL
    {
        private IMaterialDAL _dal;
        public MaterialBLL(IMaterialDAL dal)
        {
            _dal = dal;
        }

        /// <summary>
        /// 显示物料信息
        /// </summary>
        /// <returns></returns>
        public List<MaterialTableModel> ShowMaterial()
        {
            return _dal.ShowMaterial();
        }

        /// <summary>
        /// 显示物料下拉信息
        /// </summary>
        /// <returns></returns>
        public List<MaterialTypeTableModel> GetTypes()
        {
            return _dal.GetTypes();
        }

        /// <summary>
        /// 多条件查询物料信息
        /// </summary>
        /// <param name="materialid"></param>
        /// <param name="materialname"></param>
        /// <param name="materialprice"></param>
        /// <returns></returns>
        public PageShowMaterial SelMaterial(string Materialid, string Materialname, float Materialprice, float Materialprice1, int PageIndex = 1, int PageSize = 3)
        {
            return _dal.SelMaterial(Materialid, Materialname, Materialprice,Materialprice1, PageIndex, PageSize);
        }

        /// <summary>
        /// 添加物料
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        public int AddMaterial(MaterialTableModel mod)
        {
            return _dal.AddMaterial(mod);
        }
    }
}
