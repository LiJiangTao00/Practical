using System;
using System.Collections.Generic;
using System.Text;

namespace PC.Model.ViewModel
{
    public class GetPage<T>
    {
        public List<T> Model { get; set; }
        public int Total { get; set; }
    }
}
