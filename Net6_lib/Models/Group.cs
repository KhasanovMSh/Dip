using System;
using System.Collections.Generic;

namespace Net6_lib.Models
{
    public partial class Group
    {
        public Group()
        {
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Number { get; set; } = null!;

        public virtual ICollection<Student> Students { get; set; }
    }
}
