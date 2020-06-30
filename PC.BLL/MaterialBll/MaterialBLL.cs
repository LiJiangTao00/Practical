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

        /// <summary>
        /// 显示活动列表
        /// </summary>
        /// <returns></returns>
        public List<ActivityTableModel> ShowActivity()
        {
            return _dal.ShowActivity();
        }

        /// <summary>
        /// 显示物料订单信息
        /// </summary>
        /// <returns></returns>
        public List<ShowMaterialApprove> GetShowMaterialApprove()
        {
            return _dal.GetShowMaterialApprove();
        }

        /// <summary>
        /// 显示订单表
        /// </summary>
        /// <returns></returns>
        public List<OrderTableModel> GetOrder()
        {
            return _dal.GetOrder();
        }

        /// <summary>
        /// 显示用户信息
        /// </summary>
        /// <returns></returns>
        public List<UserTableModel> GetUsers()
        {
            return _dal.GetUsers();
        }

        /// <summary>
        /// 显示产品组
        /// </summary>
        /// <returns></returns>
        public List<ProductTableModel> GetProduct()
        {
            return _dal.GetProduct();
        }

        /// <summary>
        /// 显示部门
        /// </summary>
        /// <returns></returns>
        public List<DepartmentTableModel> GetDepartment()
        {
            return _dal.GetDepartment();
        }

        /// <summary>
        /// 显示职位
        /// </summary>
        /// <returns></returns>
        public List<JobTableModel> GetJob()
        {
            return _dal.GetJob();
        }

        /// <summary>
        /// 显示地区
        /// </summary>
        /// <returns></returns>
        public List<PlaceTableModel> GetPlace()
        {
            return _dal.GetPlace();
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
        public PageShowMaterial SelOrder(string Material_Id, string Material_Name, string Order_Proposer, DateTime? Order_ApplyTime, int PageIndex = 1, int PageSize = 1, int Order_State = -1)
        {

            return _dal.SelOrder(Material_Id, Material_Name, Order_Proposer, Order_ApplyTime, PageIndex, PageSize, Order_State);
        }

        /// <summary>
        /// 显示物料审批
        /// </summary>
        /// <returns></returns>
        public List<ApprovalMaterial> GetApproval()
        {
            return _dal.GetApproval();
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
        public PageShowMaterial SelApproval(string Material_Id, string Material_Name, string Order_Proposer, DateTime? Order_SubmissionTime, DateTime? Order_ApproveTime, int PageIndex = 1, int PageSize = 1, int Material_Approval = -1)
        {
            return _dal.SelApproval(Material_Id, Material_Name, Order_Proposer, Order_SubmissionTime, Order_ApproveTime, PageIndex, PageSize, Material_Approval);
        }

        /// <summary>
        /// 反填物料
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public List<ShowFill> Fill(int Id)
        {
            return _dal.Fill(Id);
        }

        /// <summary>
        /// 反填物料审批
        /// </summary>
        /// <returns></returns>
        public List<ApprovalMaterial> FillApproval(int Id)
        {
            return _dal.FillApproval(Id);
        }

        /// <summary>
        /// 反填物料订单
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public List<ShowMaterialApprove> ShowMaterialFill(int Id)
        {
            return _dal.ShowMaterialFill(Id);
        }
    }
}
