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
        /// 显示活动列表
        /// </summary>
        /// <returns></returns>
        List<ActivityTableModel> ShowActivity();

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

        /// <summary>
        /// 显示物料订单信息
        /// </summary>
        /// <returns></returns>
        List<ShowMaterialApprove> GetShowMaterialApprove();

        /// <summary>
        /// 显示订单表
        /// </summary>
        /// <returns></returns>
        List<OrderTableModel> GetOrder();

        /// <summary>
        /// 显示用户信息
        /// </summary>
        /// <returns></returns>
        List<UserTableModel> GetUsers();

        /// <summary>
        /// 显示产品组
        /// </summary>
        /// <returns></returns>
        List<ProductTableModel> GetProduct();

        /// <summary>
        /// 显示部门
        /// </summary>
        /// <returns></returns>
        List<DepartmentTableModel> GetDepartment();

        /// <summary>
        /// 显示职位
        /// </summary>
        /// <returns></returns>
        List<JobTableModel> GetJob();

        /// <summary>
        /// 显示地区
        /// </summary>
        /// <returns></returns>
        List<PlaceTableModel> GetPlace();

        /// <summary>
        /// 查询订单
        /// </summary>
        /// <returns></returns>
        PageShowMaterial SelOrder(string Material_Id, string Material_Name, string Order_Proposer, DateTime? Order_ApplyTime, int PageIndex = 1, int PageSize = 1, int Order_State = -1);

        /// <summary>
        /// 显示物料审批
        /// </summary>
        /// <returns></returns>
        List<ApprovalMaterial> GetApproval();

        /// <summary>
        /// 查询审批物料
        /// </summary>
        /// <returns></returns>
        PageShowMaterial SelApproval(string Material_Id, string Material_Name, string Order_Proposer, DateTime? Order_SubmissionTime, DateTime? Order_ApproveTime, int PageIndex = 1, int PageSize = 1, int Material_Approval = -1);

        /// <summary>
        /// 反填物料
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        List<ShowFill> Fill(int Id);

        /// <summary>
        /// 反填物料审批
        /// </summary>
        /// <returns></returns>
        List<ApprovalMaterial> FillApproval(int Id);

        /// <summary>
        /// 反填物料订单
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        List<ShowMaterialApprove> ShowMaterialFill(int Id);

        /// <summary>
        /// 编辑物料信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int UpdMaterial(MaterialTableModel model);

        /// <summary>
        /// 反填物料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        MaterialTableModel Fillmaterial(int Id);
    }
}
