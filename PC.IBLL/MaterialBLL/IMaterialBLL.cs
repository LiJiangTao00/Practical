using System;
using System.Collections.Generic;
using System.Text;
using PC.Model.Models;
using PC.DAL.MaterialDal;
using PC.IDAL.IMaterialDAL;
using PC.Model.ViewModel;

namespace PC.IBLL.MaterialBLL
{
    public interface IMaterialBLL
    {
        /// <summary>
        /// 显示物料信息
        /// </summary>
        /// <returns></returns>
        List<MaterialTableModel> ShowMaterial();

        /// <summary>
        /// 显示物料下拉信息
        /// </summary>
        /// <returns></returns>
        List<MaterialTypeTableModel> GetTypes();

        /// <summary>
        /// 多条件查询物料
        /// </summary>
        /// <returns></returns>
        PageShowMaterial SelMaterial(string Materialid, string Materialname, float Materialprice,float Materialprice1, int PageIndex = 1, int PageSize = 3);

        /// <summary>
        /// 添加物料
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        int AddMaterial(MaterialTableModel mod);
    }
}
