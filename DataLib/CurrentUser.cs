using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLib
{
    public static class CurrentUser
    {
        public static Users currentUser { get; set; }
        public static string Login { get; set; }
        public static string Password { get; set; }
        public static string Name { get; set; }
        public static string Surname { get; set; }
        public static string UserType { get; set; }
    }
}
