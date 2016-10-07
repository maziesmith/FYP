using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Testapi.Models
{
    public class Results
    {
        public string querryID;
        public List<proteins> final_prot;
        public execution_time times;

        public Results(string qID, List<proteins> prt, execution_time t)
        {
            querryID = qID;
             final_prot=prt;
             times = t;
        }
        public Results()
        {
            final_prot = new List<proteins>();
           times=new execution_time();
        }
    }
}