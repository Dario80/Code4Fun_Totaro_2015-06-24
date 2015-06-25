using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayOperations.UnitTests
{
    [TestFixture]
    public class ArrayIntersectionTests
    {
        private IIntersection _arrayIntersection;
        private int[] _firstArray;
        private int[] _secondArray;

        [SetUp]
        public void SetupUnitTests()
        {
            _arrayIntersection = new Intersection();
            _firstArray = new int[0];
            _secondArray = new int[0];

        }
        [Test]
        public void NeitherOfTwoArrayHaveNumber()
        {
            int[] expected =  new int[0];
            var actual = _arrayIntersection.GetArrayIntersection(_firstArray, _secondArray);
            Assert.AreEqual(expected, actual);
        }
    }
}
