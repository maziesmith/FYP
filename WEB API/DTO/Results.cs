using System.Collections.Generic;

namespace DTO
{
    public class Results
    {
        public string QuerryId;
        public List<Proteins> FinalProt;
        public ExecutionTime Times;

        public Results(string qId, List<Proteins> prt, ExecutionTime t)
        {
            QuerryId = qId;
             FinalProt=prt;
             Times = t;
        }
        public Results()
        {
            FinalProt = new List<Proteins>();
           Times=new ExecutionTime();
        }
    }
}