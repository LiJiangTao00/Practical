using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using PC.IBLL.UserIBLL;
using PC.IDAL.UserIDAL;
using PC.Model.Models;
using PC.Model.ViewModel;

namespace PC.BLL.UserBLL
{
    public class UBLL : IUBLL
    {
        private IUDAL _dal;
        public UBLL(IUDAL dal)
        {
            _dal = dal;
        }

        public int AddSingleUser(UserTableModel m)
        {
            return _dal.AddSingleUser(m);
        }

        public int Forget(UserTableModel m)
        {
            return _dal.Forget(m);
        }

        public int Login(string user_Phone, string user_Pwd)
        {
            return _dal.Login(user_Phone, user_Pwd);
        }

        public string SelectName(string user_Phone)
        {
            return _dal.SelectName(user_Phone);
        }

        public List<UserShowModel> SelectUser(int id)
        {
            return _dal.SelectUser(id);
        }

        public List<DepartmentTableModel> ShowDepartment()
        {
            return _dal.ShowDepartment();
        }

        public List<JobTableModel> ShowJob()
        {
            return _dal.ShowJob();
        }

        public List<PlaceTableModel> ShowProvince(int id)
        {
            return _dal.ShowProvince(id);
        }

        public List<UserShowModel> ShowUser(int product, int did, int pid, int cid, int dis, int jid, string name)
        {
            return _dal.ShowUser(product,did, pid, cid, dis, jid, name);
        }
        public int DelSingleUser(int id)
        {
            return _dal.DelSingleUser(id);
        }
        public DataTable ShowUser()
        {
            return _dal.ShowUser();
        }

        public List<UserShowModel> ShowSome(string ids)
        {
            return _dal.ShowSome(ids);
        }

        public int UpdateSome(string gid, int sid, string action)
        {
            return _dal.UpdateSome(gid, sid, action);
        }

        public int UpdateSingleUser(UserTableModel m)
        {
            return _dal.UpdateSingleUser(m);
        }
        public int UpdateJobState(int id)
        {
            return _dal.UpdateJobState(id);
        }

        public int DelJob(int v)
        {
            return _dal.DelJob(v);
        }
        public int PutJob(JobTableModel m)
        {
            return _dal.PutJob(m);
        }
        public JobTableModel ShowJob(int id)
        {
            return _dal.ShowJob(id);
        }
        public List<ListPermission> ShowPermission()
        {
            return _dal.ShowPermission();

        }
        public List<PermissionRelationTableModel> ShowSinglePermission(int id)
        {
            return _dal.ShowSinglePermission(id);

        }
        public List<PermissionRelationTableModel> ChkPid(int id)
        {
            return _dal.ChkPid(id);
        }
        public UserShowModel SelectUserPhone(string phone)
        {
            return _dal.SelectUserPhone(phone);
        }
        public int PutPwd(string phone, string oldpwd, string newPwd)
        {
            return _dal.PutPwd(phone, oldpwd, newPwd);
        }
        public int AddJob(JobTableModel m)
        {
            return _dal.AddJob(m);
        }
        public BoothView GetLog(string time, string table)
        {
            return _dal.GetLog(time, table);
        }
        public List<PieModel> GetCon(string time)
        {
            return _dal.GetCon(time);
        }
    }
}
