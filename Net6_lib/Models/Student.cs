using System;
using System.Collections.Generic;

namespace Net6_lib.Models
{
    public partial class Student
    {
        public Student()
        {
            TestResults = new HashSet<TestResult>();
        }

        public int Id { get; set; }
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int IdGroup { get; set; }

        public virtual Group IdGroupNavigation { get; set; } = null!;
        public virtual ICollection<TestResult> TestResults { get; set; }
    }
}
