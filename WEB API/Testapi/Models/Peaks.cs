using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Testapi.Models
{
    public class Peaks
    {
        public List<double> intens;
        public List<double> mass;

        public Peaks()
        {
            intens = new List<double>();
            mass = new List<double>();
        }
    }

}