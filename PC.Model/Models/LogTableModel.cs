using System;
using System.Collections.Generic;
using System.Text;

namespace PC.Model.Models
{
    public class LogTableModel
    {
        public int Id { get; set; }
        public string OperationName { get; set; }
        public string OperationTable { get; set; }
        public string OperationAction { get; set; }
        public DateTime OpertaionTime { get; set; }
    }
}
