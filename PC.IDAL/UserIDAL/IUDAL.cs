using PC.Model.Models;
using PC.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
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
        int DelSingleUser(int id);
        DataTable ShowUser(); 
        List<UserShowModel> ShowSome(string ids);
        int UpdateSome(string gid, int sid, string action);
        int UpdateSingleUser(UserTableModel m);
        int UpdateJobState(int id);
        int DelJob(int v);
        int PutJob(JobTableModel m);
        JobTableModel ShowJob(int id);
        List<ListPermission> ShowPermission();
        List<PermissionRelationTableModel> ShowSinglePermission(int id);
        List<PermissionRelationTableModel> ChkPid(int id);
        UserShowModel SelectUserPhone(string phone);
        int PutPwd(string phone, string oldpwd, string newPwd);
        int AddJob(JobTableModel m);
        BoothView GetLog(string time, string table);
        List<PieModel> GetCon(string time);
    }
}
