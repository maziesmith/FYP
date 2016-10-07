using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Testapi.Models
{
    
    public class Fragment
    {
        public List<double> mw_left_ion = new List<double>();	  //it will conatin mass of left fragments
        public List<double> mw_right_ion = new List<double>();	//it will contain mass of right fragments
    }

}