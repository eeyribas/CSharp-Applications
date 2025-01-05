using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCase
{
    class Test
    {
        [TestCase]
        public void TestSum()
        {
            double value1 = 2;
            double value2 = 1;

            Assert.AreEqual(3, MathFunctions.Sum(value1, value2));
        }
    }
}
