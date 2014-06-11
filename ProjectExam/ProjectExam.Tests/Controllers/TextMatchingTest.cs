using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Schema;
using ProjectExam.Controllers;
using System.Web.Mvc;

namespace ProjectExam.Tests.Controllers
{
    [TestClass]
    public class TextMatchingTest
    {
        
        [TestMethod]
        public void TestInputNullOrEmpty()
        {
            var input = string.Empty;
            var expectedResult = "No input found.";

            var controller = new HomeController();
            var result = controller.GetTextMatch(input) as JsonResult;
            Assert.AreEqual(expectedResult, result.Data);
        }

        [TestMethod]
        public void TestInputNotNull()
        {
            var input = "POLLY";
            var controller = new HomeController();
            var result = controller.GetTextMatch(input) as JsonResult;
            Assert.IsNotNull(result.Data);
        }


        [TestMethod]
        public void TestInputSame()
        {
            var expectedOutput = "3, 28, 53, 78, 82";
            var input = "ll";

            var controller = new HomeController();
            var result = controller.GetTextMatch(input) as JsonResult;
            Assert.AreEqual(result.Data, expectedOutput);
        }

        [TestMethod]
        public void TestInputHasMatch()
        {
            var input = "Polly";

            var controller = new HomeController();
            var result = controller.GetTextMatch(input) as JsonResult;
            Assert.IsNotNull(result.Data);
        }

        [TestMethod]
        public void TestInputNoMatches()
        {
            var expectedOutput = "<no matches>";

            var controller = new HomeController();
            var result = controller.GetTextMatch("X") as JsonResult;
            Assert.AreEqual(result.Data, expectedOutput);

        }

    }
}
