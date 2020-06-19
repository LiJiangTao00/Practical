using PC.Model.Models;
using PC.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace PC.IBLL.UserIBLL
{
    public interface IUBLL
    {
        int Login(string user_Phone, string user_Pwd);
        int Forget(UserTableModel m);
        string SelectName(string user_Phone);
        List<DepartmentTableModel> ShowDepartment();
        List<UserShowModel> ShowUser();
    }
}
