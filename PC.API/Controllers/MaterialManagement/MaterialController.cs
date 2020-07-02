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
using PC.Model.ViewModel;
using Newtonsoft.Json;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace PC.API.Controllers.MaterialManagement
{
    [Route("api/[Controller]/[Action]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private IWebHostEnvironment _hostEnvironment;
        /// <summary>
        /// 实现继承接口
        /// </summary>
        private IMaterialBLL _bll;
        public MaterialController(IMaterialBLL bll, IWebHostEnvironment hostEnvironment)
        {
            _bll = bll;
            _hostEnvironment = hostEnvironment;
        }

        /// <summary>
        /// 显示物料信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<MaterialTableModel> ShowMaterial()
        {
            return _bll.ShowMaterial();
        }

        /// <summary>
        /// 显示物料下拉信息
        /// </summary>
        /// <returns></returns>
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
        [HttpGet]
        public PageShowMaterial SelMaterial(string Materialid, string Materialname, float Materialprice, float Materialprice1, int PageIndex = 1, int PageSize = 3)
        {
            return _bll.SelMaterial(Materialid, Materialname, Materialprice,Materialprice1, PageIndex, PageSize);
        }

        /// <summary>
        /// 添加物料
        /// </summary>
        /// <param name="mod"></param>
        /// <returns></returns>
        [HttpPost]
        public int AddMaterial(string obj)
        {
            MaterialTableModel m = JsonConvert.DeserializeObject<MaterialTableModel>(obj);
            var s = m.Material_Image;
            if (Request.Form.Files.Count > 0)
            {
                //获取物理路径 webtootpath
                string path = _hostEnvironment.ContentRootPath + "\\wwwroot\\img";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                var file = Request.Form.Files[0];
                string fileExt = file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                string filename = Guid.NewGuid().ToString() + "." + fileExt;
                string fileFullName = path + "\\" + filename;
                using (FileStream fs = System.IO.File.Create(fileFullName))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
                m.Material_Image = "/img/" + filename;
            }

                return _bll.AddMaterial(m);
        }

        /// <summary>
        /// 显示活动列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<ActivityTableModel> ShowActivity()
        {
            return _bll.ShowActivity();
        }

        /// <summary>
        /// 显示物料订单信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<ShowMaterialApprove> GetShowMaterialApprove()
        {
            return _bll.GetShowMaterialApprove();
        }

        /// <summary>
        /// 显示订单表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<OrderTableModel> GetOrder()
        {
            return _bll.GetOrder();
        }

        /// <summary>
        /// 显示用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<UserTableModel> GetUsers()
        {
            return _bll.GetUsers();
        }

        /// <summary>
        /// 显示产品组
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<ProductTableModel> GetProduct()
        {
            return _bll.GetProduct();
        }

        /// <summary>
        /// 显示部门
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<DepartmentTableModel> GetDepartment()
        {
            return _bll.GetDepartment();
        }

        /// <summary>
        /// 显示职位
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<JobTableModel> GetJob()
        {
            return _bll.GetJob();
        }

        /// <summary>
        /// 显示地区
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<PlaceTableModel> GetPlace()
        {
            return _bll.GetPlace();
        }

        /// <summary>
        /// 查询订单
        /// </summary>
        /// <param name="Material_Id">物料编号</param>
        /// <param name="Material_Name">物料名称</param>
        /// <param name="Order_State">物料状态</param>
        /// <param name="Order_Proposer">申请人</param>
        /// <param name="Order_ApplyTime">申请时间</param>
        /// <param name="PageIndex">当前页</param>
        /// <param name="PageSize">页大小</param>
        /// <returns></returns>
        [HttpGet]
        public PageShowMaterial SelOrder(string Material_Id, string Material_Name, string Order_Proposer, DateTime? Order_ApplyTime, int PageIndex = 1, int PageSize = 1, int Order_State = -1)
        {

            return _bll.SelOrder(Material_Id, Material_Name, Order_Proposer, Order_ApplyTime, PageIndex, PageSize, Order_State);
        }

        /// <summary>
        /// 显示物料审批
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<ApprovalMaterial> GetApproval()
        {
            return _bll.GetApproval();
        }

        /// <summary>
        /// 查询审批物料
        /// </summary>
        /// <param name="Material_Id">物料编号</param>
        /// <param name="Material_Name">物料名称</param>
        /// <param name="Order_Proposer">申请人</param>
        /// <param name="Order_ApplyTime">申请时间</param>
        /// <param name="Order_ApproveTime">审批时间</param>
        /// <param name="PageIndex">当前页</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="Material_Approval">审批类型</param>
        /// <returns></returns>
       [HttpGet]
        public PageShowMaterial SelApproval(string Material_Id, string Material_Name, string Order_Proposer, DateTime? Order_SubmissionTime, DateTime? Order_ApproveTime, int PageIndex = 1, int PageSize = 1, int Material_Approval = -1)
        {
            return _bll.SelApproval(Material_Id, Material_Name, Order_Proposer, Order_SubmissionTime, Order_ApproveTime, PageIndex, PageSize, Material_Approval);
        }

        /// <summary>
        /// 反填物料
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public ShowFill Fill(int Id)
        {
            return _bll.Fill(Id).First();
        }

        /// <summary>
        /// 反填物料审批
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ApprovalMaterial FillApproval(int Id)
        {
            return _bll.FillApproval(Id).First();
        }

        /// <summary>
        /// 反填物料订单
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public ShowMaterialApprove ShowMaterialFill(int Id)
        {
            return _bll.ShowMaterialFill(Id).First();
        }

        /// <summary>
        /// 修改物料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
       [HttpPost]
        public int UpdMaterial([FromForm]MaterialTableModel model)
        {
            return _bll.UpdMaterial(model);
        }
    }
}
