using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayUtilities.UnitTests
{
    [TestFixture]
    public class ArrayOperationsTests
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

        [Test]
        public void OneArrayIsNullAndOtherWithNumber()
        {
            _firstArray = new int[5] { 1, 2, 3, 4, 5 };
            _secondArray = null;
            int[] expected = new int[0];
            var actual = _arrayIntersection.GetArrayIntersection(_firstArray, _secondArray);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void BothArraysHaveNumbers()
        {
            _firstArray = new int[5] { 1, 7, 14, 20, 33 };
            _secondArray = new int[5] { 1, 7, 32, 51, 99 };
            int[] expected = new int[2] {1, 7};
            var actual = _arrayIntersection.GetArrayIntersection(_firstArray, _secondArray);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ArrayWithADifferentNumbers()
        {
            _firstArray = new int[5] { 1, 7, 14, 20, 33 };
            _secondArray = new int[5] { 5 ,32, 51, 66, 99 };
            int[] expected = new int[0];
            var actual = _arrayIntersection.GetArrayIntersection(_firstArray, _secondArray);
            Assert.AreEqual(expected, actual);
        }
    }
}
