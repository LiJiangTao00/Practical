using PC.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PC.Model.ViewModel
{
    public class ListPermission
    {
        public int Id { get; set; }
        public string Permission_Name { get; set; }
        public int Permission_Pid { get; set; }
        public List<PermissionTableModel> ModelList { get; set; }
    }
}
