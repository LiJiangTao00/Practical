using Microsoft.AspNetCore.Mvc;

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

        /// <summary>
        /// 编辑物料
        /// </summary>
        /// <returns></returns>
        public IActionResult UpdMaterial(int Id)
        {
            ViewBag.Id = Id;
            return View();
        }
    }
}
