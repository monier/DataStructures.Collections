using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructures.Collections.Tests
{
    [TestClass]
    public class StackTests
    {
        [TestMethod]
        public void Push_expects_the_stack_to_grow()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Assert.IsTrue(stack.Length == 3);
        }
        [TestMethod]
        public void Push_accepts_duplicated_values()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(1);
            stack.Push(1);
            Assert.IsTrue(stack.Length == 3);
        }
        [TestMethod]
        public void Pop_removes_item_from_stack()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Pop();
            Assert.IsTrue(stack.Length == 1);
            stack.Pop();
            Assert.IsTrue(stack.Length == 0);
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Pop_throws_exception_if_stack_is_empty()
        {
            Stack<int> stack = new Stack<int>();
            stack.Pop();
        }
        [TestMethod]
        public void Pop_removes_item_and_returns_value()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            var value = stack.Pop();
            Assert.IsTrue(value == 1);
        }
        [TestMethod]
        public void Clear_empty_the_stack()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Clear();
            Assert.IsTrue(stack.Length == 0);
        }
    }
}
