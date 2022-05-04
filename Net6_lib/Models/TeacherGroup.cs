using System;
using System.Collections.Generic;

namespace Net6_lib.Models
{
    public partial class TeacherGroup
    {
        public int IdTeacher { get; set; }
        public int IdGroup { get; set; }

        public virtual Group IdGroupNavigation { get; set; } = null!;
        public virtual Teacher IdTeacherNavigation { get; set; } = null!;
    }
}
