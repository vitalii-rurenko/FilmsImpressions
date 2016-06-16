using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL.Entities;
using System.Linq;

namespace UTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            FilmContext db = new FilmContext();
            db.TestMethod();
        }
    }
}
