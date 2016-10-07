using System.Collections.Generic;

namespace DTO
{
    public class Peaks
    {
        public List<double> Intens;
        public List<double> Mass;

        public Peaks()
        {
            Intens = new List<double>();
            Mass = new List<double>();
        }
    }

}