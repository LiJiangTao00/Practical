using System;
using System.Collections.Generic;
using System.Text;
using PC.Model.Models;
using PC.IDAL.IMaterialDAL;
using Dapper;
using System.Data.SqlClient;
using System.Linq;
using PC.Model.ViewModel;
using PC.DAL.Activity;
using PC.DAL.UserDAL;
using NPOI.SS.Formula.Functions;

namespace PC.DAL.MaterialDal
{
    public class MaterialDAL : IMaterialDAL  // 接口
    {

        SqlConnection conn = new SqlConnection("Data Source=192.168.43.93;Initial Catalog=Practial;User ID=sa;pwd=12345");
        /// <summary>
        /// 显示物料信息
        /// </summary>
        /// <returns></returns>
        public List<MaterialTableModel> ShowMaterial()
        {
            using (SqlConnection conn = new SqlConnection("Data Source=192.168.43.93;Initial Catalog=Practial;User ID=sa;pwd=12345"))
            {
                return conn.Query<MaterialTableModel>($"select * from MaterialTable m join MaterialTypeTable t on m.Material_TypeId = t.Id").ToList();
            }
        }


        /// <summary>
        /// 显示活动列表
        /// </summary>
        /// <returns></returns>
        public List<ActivityTableModel> ShowActivity()
        {
            using (SqlConnection conn = new SqlConnection("Data Source=192.168.43.93;Initial Catalog=Practial;User ID=sa;pwd=12345"))
            {
                return conn.Query<ActivityTableModel>("select * from ActivityTable").ToList();
            }
        }

        /// <summary>
        /// 显示物料下拉信息
        /// </summary>
        /// <returns></returns>
        public List<MaterialTypeTableModel> GetTypes()
        {
            using (SqlConnection conn = new SqlConnection("Data Source=192.168.43.93;Initial Catalog=Practial;User ID=sa;pwd=12345"))
            {
                return conn.Query<MaterialTypeTableModel>("select * from MaterialTypeTable").ToList();
            }
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

            string sql = "select * from MaterialTable m join MaterialTypeTable t on m.Material_TypeId = t.Id where 1=1";
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
            using (SqlConnection conn = new SqlConnection("Data Source=192.168.43.93;Initial Catalog=Practial;User ID=sa;pwd=12345"))
            {
                var sql = $"insert into MaterialTable values('{mod.Material_Id}','{mod.Material_Name}',{mod.Material_TypeId},{mod.Material_Price},{mod.Material_Number},{mod.Material_LastNumber},'{mod.Material_Desc}','{mod.Material_Image}',{mod.Material_State},2,1,'2020-05-06',0,2,'{mod.Material_PlaceName}')";
                return conn.Execute(sql);
            }
        }

        /// <summary>
        /// 显示订单表
        /// </summary>
        /// <returns></returns>
        public List<OrderTableModel> GetOrder()
        {
            using (SqlConnection conn = new SqlConnection("Data Source=192.168.43.93;Initial Catalog=Practial;User ID=sa;pwd=12345"))
            {
                return conn.Query<OrderTableModel>("select * from OrderTable").ToList();
            }
        }

        /// <summary>
        /// 显示用户信息
        /// </summary>
        /// <returns></returns>
        public List<UserTableModel> GetUsers()
        {
            using (SqlConnection conn = new SqlConnection("Data Source=192.168.43.93;Initial Catalog=Practial;User ID=sa;pwd=12345"))
            {
                return conn.Query<UserTableModel>("select * from UserTable").ToList();
            }
        }

        /// <summary>
        /// 显示产品组
        /// </summary>
        /// <returns></returns>
        public List<ProductTableModel> GetProduct()
        {
            using (SqlConnection conn = new SqlConnection("Data Source=192.168.43.93;Initial Catalog=Practial;User ID=sa;pwd=12345"))
            {
                return conn.Query<ProductTableModel>("select * from ProductTable").ToList();
            }
        }

        /// <summary>
        /// 显示部门
        /// </summary>
        /// <returns></returns>
        public List<DepartmentTableModel> GetDepartment()
        {
            using (SqlConnection conn = new SqlConnection("Data Source=192.168.43.93;Initial Catalog=Practial;User ID=sa;pwd=12345"))
            {
                return conn.Query<DepartmentTableModel>("select * from DepartmentTable").ToList();
            }
        }

        /// <summary>
        /// 显示职位
        /// </summary>
        /// <returns></returns>
        public List<JobTableModel> GetJob()
        {
            using (SqlConnection conn = new SqlConnection("Data Source=192.168.43.93;Initial Catalog=Practial;User ID=sa;pwd=12345"))
            {
                return conn.Query<JobTableModel>("select * from JobTable").ToList();
            }
        }

        /// <summary>
        /// 显示地区
        /// </summary>
        /// <returns></returns>
        public List<PlaceTableModel> GetPlace()
        {
            using (SqlConnection conn = new SqlConnection("Data Source=192.168.43.93;Initial Catalog=Practial;User ID=sa;pwd=12345"))
            {
                return conn.Query<PlaceTableModel>("select * from PlaceTable").ToList();
            }
        }

        /// <summary>
        /// 显示物料订单信息
        /// </summary>
        /// <returns></returns>
        public List<ShowMaterialApprove> GetShowMaterialApprove()
        {
            List<ShowMaterialApprove> list = (from m in ShowMaterial()
                                              join o in GetOrder()
                                              on m.Id equals o.Order_MId
                                              join t in GetTypes()
                                              on m.Material_TypeId equals t.Id
                                              join a in ShowActivity()
                                              on m.Material_Activity_Id equals a.Id
                                              join u in GetUsers()
                                              on o.Order_User_Id equals u.Id
                                              join p in GetProduct()
                                              on o.Order_Product_Id equals p.Id
                                              join d in GetDepartment()
                                              on o.Order_Department_Id equals d.Id
                                              join j in GetJob()
                                              on o.Order_Job_Id equals j.Id
                                              join g in GetPlace()
                                              on o.Order_Area_Id equals g.Id
                                              select new ShowMaterialApprove
                                              {
                                                 Material_Id = m.Material_Id,
                                                 Material_Name = m.Material_Name,
                                                 Material_Image = m.Material_Image,
                                                 MType_Name = t.MType_Name,
                                                 Order_Proposer = o.Order_Proposer,
                                                 Place_Name = g.Place_Name,
                                                 Order_ApplyTime = o.Order_ApplyTime,
                                                 Order_State = o.Order_State,
                                                 Activity_Name = a.Activity_Name,
                                                 Material_Price = m.Material_Price,
                                                 Material_Number = m.Material_Number,
                                                  Product_Name = p.Product_Name,
                                                  Department_Name = d.Department_Name,
                                                  Job_Name = j.Job_Name,
                                                  User_Phone = u.User_Phone
                                              }).ToList();
            return list;
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

            string sql = "select o.Id,m.Material_Id,m.Material_Name,m.Material_Image,t.MType_Name,o.Order_Proposer,g.Place_Name,o.Order_ApplyTime,o.Order_State,a.Activity_Name,m.Material_Price,m.Material_Number,p.Product_Name,d.Department_Name,j.Job_Name,u.User_Phone from  MaterialTable m  join OrderTable o on o.Order_MId = m.Id join MaterialTypeTable t on m.Material_TypeId = t.Id join ActivityTable a on m.Material_Activity_Id = a.Id join UserTable u on o.Order_User_Id = u.Id join ProductTable p on o.Order_Product_Id = p.Id join DepartmentTable d on o.Order_Department_Id = d.Id join JobTable j on o.Order_Job_Id = j.Id join PlaceTable g on o.Order_Area_Id = g.Id where 1 = 1";

            if (Material_Id != null)
            {
                sql += " and Material_Id like '%" + Material_Id + "%'";
            }
            if (Material_Name != null)
            {
                sql += " and Material_Name like '%" + Material_Name + "%'";
            }
            if (Order_State != -1)
            {
                sql += " and Order_State = '" + Order_State + "'";
            }
            if (Order_Proposer != null)
            {
                sql += " and Order_Proposer like '%" + Order_Proposer + "%'" ;
            }
            if (Order_ApplyTime != null)
            {
                sql += " and Order_ApplyTime = '" + Order_ApplyTime +"'" ;
            }

            List<ShowMaterialApprove> list = new List<ShowMaterialApprove>();
            list = conn.Query<ShowMaterialApprove>(sql).ToList();

            var pagelist = list.Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList();

            PageShowMaterial PageShowData = new PageShowMaterial();
            PageShowData.PageShowMateriallist1 = pagelist;
            PageShowData.DataCount = list.Count();
            PageShowData.PageSize = PageSize;

            return PageShowData;
        }

        /// <summary>
        /// 显示物料审批
        /// </summary>
        /// <returns></returns>
        public List<ApprovalMaterial> GetApproval()
        {
                List<ApprovalMaterial> list = (from m in ShowMaterial()
                                               join o in GetOrder()
                                               on m.Id equals o.Order_MId
                                               join t in GetTypes()
                                               on m.Material_TypeId equals t.Id
                                               join a in ShowActivity()
                                               on m.Material_Activity_Id equals a.Id
                                               join u in GetUsers()
                                               on o.Order_User_Id equals u.Id
                                               join p in GetProduct()
                                               on o.Order_Product_Id equals p.Id
                                               join d in GetDepartment()
                                               on o.Order_Department_Id equals d.Id
                                               join j in GetJob()
                                               on o.Order_Job_Id equals j.Id
                                               join g in GetPlace()
                                               on o.Order_Area_Id equals g.Id
                                               select new ApprovalMaterial
                                               {
                                                   Material_Id = m.Material_Id,
                                                   Material_Name = m.Material_Name,
                                                   Material_Image = m.Material_Image,
                                                   MType_Name = t.MType_Name,
                                                   Order_Proposer = o.Order_Proposer,
                                                   Place_Name = g.Place_Name,
                                                   Order_SubmissionTime = o.Order_SubmissionTime,
                                                   Order_ApproveTime = o.Order_ApproveTime,
                                                   Material_Approval = m.Material_Approval,
                                                   Activity_Name = a.Activity_Name,
                                                   Material_Price = m.Material_Price,
                                                   Material_Number = m.Material_Number,
                                                   Product_Name = p.Product_Name,
                                                   Department_Name = d.Department_Name,
                                                   Job_Name = j.Job_Name,
                                                   User_Phone = u.User_Phone,
                                                   Order_ApplyTime = o.Order_ApplyTime
                                               }).ToList();
                return list;
           
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

            string sql = "select * from  MaterialTable m  join OrderTable o on o.Order_MId = m.Id join MaterialTypeTable t on m.Material_TypeId = t.Id join ActivityTable a on m.Material_Activity_Id = a.Id join UserTable u on o.Order_User_Id = u.Id join ProductTable p on o.Order_Product_Id = p.Id join DepartmentTable d on o.Order_Department_Id = d.Id join JobTable j on o.Order_Job_Id = j.Id join PlaceTable g on o.Order_Area_Id = g.Id where 1 = 1";

            if (Material_Id != null)
            {
                sql += " and Material_Id like '%" + Material_Id + "%'";
            }
            if (Material_Name != null)
            {
                sql += " and Material_Name like '%" + Material_Name + "%'";
            }
            if (Material_Approval != -1)
            {
                sql += " and Material_Approval = '" + Material_Approval + "'";
            }
            if (Order_Proposer != null)
            {
                sql += " and Order_Proposer like '%" + Order_Proposer + "%'";
            }
            if (Order_SubmissionTime != null)
            {
                sql += " and Order_SubmissionTime = '" + Order_SubmissionTime + "'";
            }
            if (Order_ApproveTime != null)
            {
                sql += " and Order_ApproveTime = '" + Order_ApproveTime + "'";
            }

            List<ApprovalMaterial> list = new List<ApprovalMaterial>();
            list = conn.Query<ApprovalMaterial>(sql).ToList();

            var pagelist = list.Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList();

            PageShowMaterial PageShowData = new PageShowMaterial();
            PageShowData.PageShowMateriallist2 = pagelist;
            PageShowData.DataCount = list.Count();
            PageShowData.PageSize = PageSize;

            return PageShowData;
        }

        /// <summary>
        /// 反填物料
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public List<ShowFill> Fill(int Id)
        {
            using(SqlConnection conn = new SqlConnection("Data Source=192.168.43.93;Initial Catalog=Practial;User ID=sa;pwd=12345"))
            {
                List<ShowFill> list = conn.Query<ShowFill>($"select * from MaterialTypeTable t join MaterialTable m on t.Id = m.Material_TypeId where m.Id = {Id}").ToList();
                return list;
            }
        }

        /// <summary>
        /// 反填物料审批
        /// </summary>
        /// <returns></returns>
        public List<ApprovalMaterial> FillApproval(int Id)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=192.168.43.93;Initial Catalog=Practial;User ID=sa;pwd=12345"))
            {
                return conn.Query<ApprovalMaterial>($"select * from MaterialTable m join OrderTable o on o.Order_MId = m.Id join MaterialTypeTable t on m.Material_TypeId = t.Id join ActivityTable a on m.Material_Activity_Id = a.Id  join UserTable u on o.Order_User_Id = u.Id join ProductTable p on o.Order_Product_Id = p.Id join DepartmentTable d on o.Order_Department_Id = d.Id join JobTable j on o.Order_Job_Id = j.Id  join PlaceTable g on o.Order_Area_Id = g.Id where m.Id = {Id}").ToList();
            }
         }

        /// <summary>
        /// 反填物料订单
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public List<ShowMaterialApprove> ShowMaterialFill(int Id)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=192.168.43.93;Initial Catalog=Practial;User ID=sa;pwd=12345"))
            {
                return conn.Query<ShowMaterialApprove>($"select *  from  MaterialTable m  join OrderTable o on o.Order_MId = m.Id join MaterialTypeTable t on m.Material_TypeId = t.Id join ActivityTable a on m.Material_Activity_Id = a.Id join UserTable u on o.Order_User_Id = u.Id join ProductTable p on o.Order_Product_Id = p.Id join DepartmentTable d on o.Order_Department_Id = d.Id join JobTable j on o.Order_Job_Id = j.Id join PlaceTable g on o.Order_Area_Id = g.Id where o.Id = {Id}").ToList();
            }
        }

        /// <summary>
        /// 修改物料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int UpdMaterial(MaterialTableModel model)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=192.168.43.93;Initial Catalog=Practial;User ID=sa;pwd=12345"))
            {
                return conn.Execute($"update MaterialTable  set Material_TypeId = {model.Material_TypeId},Material_PlaceName='{model.Material_PlaceName}',Material_Id = '{model.Material_Id}',Material_Name = '{model.Material_Name}',Material_Desc = '{model.Material_Desc}',Material_Image = '{model.Material_Image}',Material_Price = {model.Material_Price},Material_Number = {model.Material_Number},Material_State = {model.Material_State} where Id = {model.Id}");
            }
        }

    }
}
 