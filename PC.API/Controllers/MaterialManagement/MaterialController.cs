using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PC.Model.Models;
using PC.IDAL.IMaterialDAL;
using PC.DAL.MaterialDal;
using PC.IBLL.MaterialBLL;
using PC.BLL.MaterialBll;
using Microsoft.AspNetCore.Routing;

namespace PC.API.Controllers.MaterialManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        /// <summary>
        /// 实现继承接口
        /// </summary>
        private IMaterialBLL _bll;
        public MaterialController(IMaterialBLL bll)
        {
            _bll = bll;
        }

        /// <summary>
        /// 显示物料信息
        /// </summary>
        /// <returns></returns>
        [Route("ShowMaterial")]
        [HttpGet]
        public List<MaterialTableModel> ShowMaterial()
        {
            return _bll.ShowMaterial();
        }

        /// <summary>
        /// 显示物料下拉信息
        /// </summary>
        /// <returns></returns>
        [Route("GetTypes")]
        [HttpGet]
        public List<MaterialTypeTableModel> GetTypes()
        {
            return _bll.GetTypes();
        }

        /// <summary>
        /// 多条件查询物料信息
        /// </summary>
        /// <param name="materialid"></param>
        /// <param name="materialname"></param>
        /// <param name="materialprice"></param>
        /// <returns></returns>
        [Route("SelMaterial")]
        [HttpGet]
        public List<MaterialTableModel> SelMaterial(string Materialid, string Materialname, float Materialprice, float Materialprice1)
        {
            return _bll.SelMaterial(Materialid, Materialname, Materialprice,Materialprice1);
        }
    }
}
