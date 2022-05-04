using DataLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject
{
    [TestClass]
    public class AddUsersTest
    {
        [TestMethod]
        public void AddAdminCorrect()
        {
            bool excepted = true;

            bool actual = CRUD.AddAdministrator("admin2@mail.ru", "ytrewq!3", "Александров", "Дмитрий");

            Assert.AreEqual(excepted, actual);
        }

        [TestMethod]
        public void AddAdminUncorrect()
        {
            bool excepted = false;

            bool actual = CRUD.AddAdministrator("Admin1", "ytrewq!3", "Александров", "Дмитрий", "Петрович");

            Assert.AreEqual(excepted, actual);
        }

        [TestMethod]
        public void AddTeacherCorrect()
        {
            bool excepted = true;

            bool actual = CRUD.AddTeacher("teacher23", "ytrewq!3", "Александров", "Дмитрий", "Петрович");

            Assert.AreEqual(excepted, actual);
        }

        [TestMethod]
        public void AddTeacherUncorrect()
        {
            bool excepted = false;

            bool actual = CRUD.AddTeacher("ivanov@teacher", "ytrewq!3", "Дмитрий", "Александров");

            Assert.AreEqual(excepted, actual);
        }

        [TestMethod]
        public void AddStudentCorrect()
        {
            bool excepted = true;

            bool actual = CRUD.AddStudent("student3", "ytrewq!3", "Александров", "Дмитрий");

            Assert.AreEqual(excepted, actual);
        }

        [TestMethod]
        public void AddStudentUncorrect()
        {
            bool excepted = false;

            bool actual = CRUD.AddStudent("petrov", "ytrewq!3", "Дмитрий", "Александров");

            Assert.AreEqual(excepted, actual);
        }

    }
}
