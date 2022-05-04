using System;
using System.Collections.Generic;

namespace Net6_lib.Models
{
    public partial class Administrator
    {
        public int Id { get; set; }
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Patronomic { get; set; }
    }
}
