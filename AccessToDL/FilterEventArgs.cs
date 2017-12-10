using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class FilterEventArgs : EventArgs
    {
        public int ID { get; set; }

        public FilterEventArgs(int id)
        {
            ID = id;
        }
    }
}
