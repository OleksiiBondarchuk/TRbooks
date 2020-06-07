using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TRbooks;
using TRbooks.Controllers;
using System.Web;
using TRbooks.Models;
using TRbooks.ViewModels;
using System.Data.Entity;

namespace TRbooks.tests
{
    /// <summary>
    /// Summary description for CustomersControllerTest
    /// </summary>
    [TestClass]
    public class CustomersControllerTest
    {
        CustomersController controller;
        ViewResult result;

        [TestMethod]
        public void Index()
        {
            // Arrange
            controller = new CustomersController();

            // Act
            result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Details()
        {
            // Arrange
            controller = new CustomersController();

            // Act
            result = controller.Details(13) as ViewResult;

            
            Assert.AreEqual("Details",result.ViewName);
        }

    }
}
