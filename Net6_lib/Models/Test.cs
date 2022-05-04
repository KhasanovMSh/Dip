using System;
using System.Collections.Generic;

namespace Net6_lib.Models
{
    public partial class Test
    {
        public Test()
        {
            TestResults = new HashSet<TestResult>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? TestData { get; set; }

        public virtual ICollection<TestResult> TestResults { get; set; }
    }
}
