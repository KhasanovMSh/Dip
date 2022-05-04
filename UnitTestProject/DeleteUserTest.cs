using DataLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject
{
    [TestClass]
    public class DeleteUserTest
    {
        [TestMethod]
        public void CorrectDeleteAdminTest()
        {
            bool excepted = true;

            bool actual = CRUD.DeleteAdmin(1);

            Assert.AreEqual(excepted, actual);
        }

        [TestMethod]
        public void UncorrectDeleteAdminTest()
        {
            bool excepted = false;

            bool actual = CRUD.DeleteAdmin(4);

            Assert.AreEqual(excepted, actual);
        }

        [TestMethod]
        public void CorrectDeleteTeacherTest()
        {
            bool excepted = true;

            bool actual = CRUD.DeleteTeacher(1);

            Assert.AreEqual(excepted, actual);
        }

        [TestMethod]
        public void UncorrectDeleteTeacherTest()
        {
            bool excepted = false;

            bool actual = CRUD.DeleteTeacher(4);

            Assert.AreEqual(excepted, actual);
        }

        [TestMethod]
        public void CorrectDeleteStudentTest()
        {
            bool excepted = true;

            bool actual = CRUD.DeleteStudent(1);

            Assert.AreEqual(excepted, actual);
        }

        [TestMethod]
        public void UncorrectDeleteStudentTest()
        {
            bool excepted = false;

            bool actual = CRUD.DeleteStudent(4);

            Assert.AreEqual(excepted, actual);
        }
    }
}
