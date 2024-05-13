using hospitalManagenetSystemAPI.TableDriven;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestDriven
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetUserName()
        {
            string user = "admin1";

            TableDrivenAdmin.Username expected = TableDrivenAdmin.Username.admin1;

            TableDrivenAdmin.Username actual = TableDrivenAdmin.getUsername(user);

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void TestGetUserPassword()
        {
            string user = "admin1";
            string pass = "pass123";

            string actual = string.Empty;
            try
            {
                actual = TableDrivenAdmin.getPassword(user);
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }

            // Assert
            Assert.AreEqual(pass, actual);

        }
    }
}
