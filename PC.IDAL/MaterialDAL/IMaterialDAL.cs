using System;
using System.Collections.Generic;
using System.Text;
using PC.Model.Models;

namespace PC.IDAL.IMaterialDAL
{
    public interface IMaterialDAL
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
        List<MaterialTableModel> SelMaterial(string Materialid, string Materialname, float Materialprice, float Materialprice1);
    }
}
