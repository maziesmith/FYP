using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class insilico_obj
    {
        public List<double> insilico_mass_left;
        public List<double> insilico_mass_right;
        public List<double> peaklist_mass_left;
        public List<double> peaklist_mass_right;

        public insilico_obj()
        {
            insilico_mass_right = new List<double>();
            insilico_mass_left = new List<double>();
            peaklist_mass_left = new List<double>();
            peaklist_mass_right = new List<double>();

        }
    }
}