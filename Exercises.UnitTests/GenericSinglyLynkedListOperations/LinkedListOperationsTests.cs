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
        private ILinkedListOperations<int> _linkedListOperations;
        private int _index;
        private SinglyLinkedList<int> _singlyLinkedList;

        [SetUp]
        public void SetupUnitTests()
        {
            _linkedListOperations = new LinkedListOperations<int>();
            _singlyLinkedList = new SinglyLinkedList<int>();
        }


        [Test]
        public void GenericSinglyLinkedListIsEmpty()
        {
            _index = 5;
            int expected = 0;
            var actual = _linkedListOperations.GetNthElementFromLast(_singlyLinkedList, _index);
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void GenericSinglyLinkedListIsNull()
        {
            _singlyLinkedList = null;
            _index = 5;
            int expected = 0;
            var actual = _linkedListOperations.GetNthElementFromLast(_singlyLinkedList, _index);
            Assert.AreEqual(expected, actual);
        }


    }
}
