using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PC.Model.Models;
using PC.IDAL.IMaterialDAL;
using PC.DAL.MaterialDal;
using PC.IBLL.MaterialBLL;
using PC.BLL.MaterialBll;

namespace PC.MVC.Controllers.MaterialManagement
{
    public class MaterialController : Controller
    {
        
        public IActionResult ShowMaterial()
        {
            return View();
        }

        /// <summary>
        /// 添加物料
        /// </summary>
        /// <returns></returns>
        public IActionResult AddMaterial()
        {
            return View();
        }

        /// <summary>
        /// 显示物料订单表
        /// </summary>
        /// <returns></returns>
        public IActionResult GetShowMaterialApprove()
        {
            return View();
        }

        /// <summary>
        /// 显示物料审批
        /// </summary>
        /// <returns></returns>
        public IActionResult GetApproval()
        {
            return View();
        }

        /// <summary>
        /// 显示柱状图
        /// </summary>
        /// <returns></returns>
        public IActionResult BarGraph()
        {
            return View();
        }
    }
}
