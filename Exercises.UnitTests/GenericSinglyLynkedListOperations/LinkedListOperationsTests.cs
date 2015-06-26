using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListUtilities.UnitTests
{
    [TestFixture]
    public class LinkedListOperationsTests
    {
        private ILinkedListOperations<int> _linkedListOperationsInt;
        private ILinkedListOperations<string> _linkedListOperationsString;
        private int _index;
        private SinglyLinkedList<int> _singlyLinkedListInt;
        private SinglyLinkedList<string> _singlyLinkedListString;

        [SetUp]
        public void SetupUnitTests()
        {
            _linkedListOperationsInt = new LinkedListOperations<int>();
            _singlyLinkedListInt = new SinglyLinkedList<int>();

            _linkedListOperationsString = new LinkedListOperations<string>();
            _singlyLinkedListString = new SinglyLinkedList<string>();
        }


        [Test]
        public void SinglyLinkedListIntIsEmpty()
        {
            _index = 5;
            int expected = 0;
            var actual = _linkedListOperationsInt.GetNthElementFromLast(_singlyLinkedListInt, _index);
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void SinglyLinkedListStringIsEmpty()
        {
            _index = 5;
            string expected = null;
            var actual = _linkedListOperationsString.GetNthElementFromLast(_singlyLinkedListString, _index);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SinglyLinkedListIntIsNull()
        {
            _singlyLinkedListInt = null;
            _index = 5;
            int expected = 0;
            var actual = _linkedListOperationsInt.GetNthElementFromLast(_singlyLinkedListInt, _index);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SinglyLinkedListStringIsNull()
        {
            _singlyLinkedListString = null;
            _index = 5;
            string expected = null;
            var actual = _linkedListOperationsString.GetNthElementFromLast(_singlyLinkedListString, _index);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SinglyLinkedListIntCountEqualsToN()
        {
            _singlyLinkedListInt.Add(1);
            _singlyLinkedListInt.Add(2);
            _singlyLinkedListInt.Add(3);
            _singlyLinkedListInt.Add(4);
            _singlyLinkedListInt.Add(5);
            _index = 4;
            int expected = 2;
            var actual = _linkedListOperationsInt.GetNthElementFromLast(_singlyLinkedListInt, _index);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SinglyLinkedListStringCountEqualsToN()
        {
            _singlyLinkedListString.Add("1");
            _singlyLinkedListString.Add("2");
            _singlyLinkedListString.Add("3");
            _singlyLinkedListString.Add("4");
            _singlyLinkedListString.Add("5");
            _index = 4;
            string expected = "2";
            var actual = _linkedListOperationsString.GetNthElementFromLast(_singlyLinkedListString, _index);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SinglyLinkedListIntCountGreaterThanN()
        {
            _singlyLinkedListInt.Add(82);
            _singlyLinkedListInt.Add(55);
            _singlyLinkedListInt.Add(78);
            _singlyLinkedListInt.Add(92);
            _singlyLinkedListInt.Add(12);
            _singlyLinkedListInt.Add(44);
            _singlyLinkedListInt.Add(51);
            _index = 5;
            int expected = 78;
            var actual = _linkedListOperationsInt.GetNthElementFromLast(_singlyLinkedListInt, _index);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SinglyLinkedListStringCountGreaterThanN()
        {
            _singlyLinkedListString.Add("82");
            _singlyLinkedListString.Add("55");
            _singlyLinkedListString.Add("78");
            _singlyLinkedListString.Add("92");
            _singlyLinkedListString.Add("12");
            _singlyLinkedListString.Add("44");
            _singlyLinkedListString.Add("51");
            _index = 5;
            string expected = "78";
            var actual = _linkedListOperationsString.GetNthElementFromLast(_singlyLinkedListString, _index);
            Assert.AreEqual(expected, actual);
        }
    }
}
