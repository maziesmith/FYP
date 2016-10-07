using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Testapi.Models
{
    public static class CurrentJobs
    {
        public static List<Job> current;

        public static void Initialize()
        {
            if (current == null)
                current = new List<Job>();
        }

    }
}