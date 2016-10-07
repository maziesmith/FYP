using System.Collections.Generic;

namespace DTO
{
    public static class CurrentJobs
    {
        public static List<Job> Current;

        public static void Initialize()
        {
            if (Current == null)
                Current = new List<Job>();
        }

    }
}