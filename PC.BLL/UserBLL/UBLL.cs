using System;
using System.Collections.Generic;
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

        public List<UserShowModel> ShowUser(int did, int pid, int cid, int dis, int jid, string name)
        {
            return _dal.ShowUser(did, pid, cid, dis, jid, name);
        }
    }
}
