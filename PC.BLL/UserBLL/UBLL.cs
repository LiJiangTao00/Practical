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
    }
}
