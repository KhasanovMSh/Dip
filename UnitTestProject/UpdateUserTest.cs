using DataLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject
{
    [TestClass]
    public class UpdateUserTest
    {
        [TestMethod]
        public void CorrectUpdateAdminTest()
        {
            Administrator tempUser = new Administrator() { Id = 1 , Login = "admin2@mail.ru", Password = "ytrewq!3", Name = "Дмитрий", Surname = "Александров" };
            bool excepted = true;

            bool actual = CRUD.UpdateAdmin(tempUser);

            Assert.AreEqual(excepted, actual);
        }

        [TestMethod]
        public void UncorrectUpdateAdminTest()
        {
            Administrator tempUser = new Administrator() { Id = 1, Login = "admin2@mail.ru", Password = "ytrewq!3", Name = "Дмитрий", Surname = "" };
            bool excepted = false;

            bool actual = CRUD.UpdateAdmin(tempUser);

            Assert.AreEqual(excepted, actual);
        }

        public void CorrectUpdateTeacherTest()
        {
            Administrator tempUser = new Administrator() { Id = 1, Login = "admin2@mail.ru", Password = "ytrewq!3", Name = "Дмитрий", Surname = "Александров" };
            bool excepted = true;

            bool actual = CRUD.UpdateTeacher(tempUser);

            Assert.AreEqual(excepted, actual);
        }

        [TestMethod]
        public void UncorrectUpdateTeachernTest()
        {
            Administrator tempUser = new Administrator() { Id = 1, Login = "admin2@mail.ru", Password = "ytrewq!3", Name = "Дмитрий", Surname = "" };
            bool excepted = false;

            bool actual = CRUD.UpdateTeacher(tempUser);

            Assert.AreEqual(excepted, actual);
        }

        public void CorrectUpdateStudentTest()
        {
            Administrator tempUser = new Administrator() { Id = 1, Login = "admin2@mail.ru", Password = "ytrewq!3", Name = "Дмитрий", Surname = "Александров" };
            bool excepted = true;

            bool actual = CRUD.UpdateAdmin(tempUser);

            Assert.AreEqual(excepted, actual);
        }

        [TestMethod]
        public void UncorrectUpdateStudentTest()
        {
            Administrator tempUser = new Administrator() { Id = 1, Login = "admin2@mail.ru", Password = "ytrewq!3", Name = "Дмитрий", Surname = "" };
            bool excepted = false;

            bool actual = CRUD.UpdateAdmin(tempUser);

            Assert.AreEqual(excepted, actual);
        }
    }
}
