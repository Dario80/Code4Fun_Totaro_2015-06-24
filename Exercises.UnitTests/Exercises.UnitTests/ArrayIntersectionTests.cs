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
        }

        [Test]
        public void NeitherOfTwoArrayHaveNumber()
        {
            _firstArray = new int[0];
            _secondArray = new int[0];
            int[] expected =  new int[0];
            var actual = _arrayIntersection.GetArrayIntersection(_firstArray, _secondArray);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OneArrayWithNumberAndOtherWithoutNumber()
        {
            _firstArray = new int[5] { 1, 2, 3, 4, 5 };
            _secondArray = new int[0];
            int[] expected = new int[0];
            var actual = _arrayIntersection.GetArrayIntersection(_firstArray, _secondArray);
            Assert.AreEqual(expected, actual);
        }
    }
}
