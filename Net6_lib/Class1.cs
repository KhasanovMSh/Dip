using Net6_lib.Models;

namespace Net6_lib
{
    public static class Class1
    {
        public static List<Administrator> LoadAdministrators()
        {
            using (DipContext db = new DipContext())
            {
                return db.Administrators.ToList();
            }
        }
    }
}