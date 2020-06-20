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

        public List<DepartmentTableModel> ShowDepartment()
        {
            return _dal.ShowDepartment();
        }
        public List<UserShowModel> ShowUser()
        {
            return _dal.ShowUser();
        }
    }
}
