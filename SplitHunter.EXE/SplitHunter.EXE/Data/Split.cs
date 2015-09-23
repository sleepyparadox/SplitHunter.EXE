using System;

namespace SplitHunter.EXE.Data
{
    public class Split
    {
        public string Name { get; set; }
        public TimeSpan? Current { get; set; }
        public TimeSpan? Best { get; set; }
    }
}
