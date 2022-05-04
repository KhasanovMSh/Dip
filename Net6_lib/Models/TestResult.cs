using System;
using System.Collections.Generic;

namespace Net6_lib.Models
{
    public partial class TestResult
    {
        public int Id { get; set; }
        public int IdStudent { get; set; }
        public int IdTest { get; set; }
        public int Score { get; set; }

        public virtual Student IdStudentNavigation { get; set; } = null!;
        public virtual Test IdTestNavigation { get; set; } = null!;
    }
}
