using System;
using System.Collections.Generic;
using JeuDontOnEstLeHeros.Core.DataLayers;
using JeuDontOnEstLeHeros.Core.Models;
using System.Web.Mvc;
using JeuDontOnEstLeHeros.Web.UI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JeuDontOnEstLeHeros.Tests
{
    [TestClass]
    public class UnitTest1
    { 
        [TestMethod]
        public void TestHomeControllerIndex()
        {
            var controller = new HomeController();
            var result = controller.Index() as ViewResult;  
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void TestParagrapheControllerGet()
        {
            var controller = new ParagrapheController();
            var result = controller.One(1) as ViewResult;
            var para = (Paragraphe)result.ViewData.Model;
            Assert.IsNotNull(para);
        }

    //    [TestMethod]
    //    public void TestSendsParagraphes()
    //    {
    //        ParagrapheDataLayer layer = new ParagrapheDataLayer();
    //        Assert.IsNotNull(layer.GetAll());
    //        // I'd love to check for the type instead, but it doesn't seem to work very well
    //        //Assert.IsInstanceOfType(myList[0], typeof(Paragraphe));
    //    }
    }
}
