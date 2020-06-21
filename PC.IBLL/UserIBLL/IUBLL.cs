﻿using PC.Model.Models;
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
        List<UserShowModel> ShowUser(int product, int did, int pid, int cid, int dis, int jid, string name);
        List<PlaceTableModel> ShowProvince(int id);
        List<JobTableModel> ShowJob();
        List<UserShowModel> SelectUser(int id);
    }
}
