using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NunitTestFirstDemo
{
    [TestFixture]
    class TestCaseFirst
    {
        [TestCase]
        public void Add()
        {
            MathDemo demo = new MathDemo();
            Assert.AreEqual(30, demo.Add(10, 20));
        }
    }
}
