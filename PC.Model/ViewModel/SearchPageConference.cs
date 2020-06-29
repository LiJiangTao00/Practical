using System;
using System.Collections.Generic;
using System.Text;

namespace PC.Model.ViewModel
{
    public class SearchPageConference
    {
        public DateTime condate { get; set; }
        public string conplace { get; set; }
        public string constate { get; set; }
        public string conname { get; set; }
        public string conproduct { get; set; }
        public int pageindex { get; set; }
        public int pagesize { get; set; }
    }
}
