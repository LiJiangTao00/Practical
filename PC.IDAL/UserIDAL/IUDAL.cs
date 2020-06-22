using PC.Model.Models;
using PC.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace PC.IDAL.UserIDAL
{
    public interface IUDAL
    {
        int Login(string user_Phone, string user_Pwd);
        int Forget(UserTableModel m);
        string SelectName(string user_Phone);
        List<DepartmentTableModel> ShowDepartment();
        List<UserShowModel> ShowUser(int product, int did, int pid, int cid, int dis, int jid, string name);
        int AddSingleUser(UserTableModel m);
        List<PlaceTableModel> ShowProvince(int id);
        List<JobTableModel> ShowJob();
        List<UserShowModel> SelectUser(int id);
    }
}
