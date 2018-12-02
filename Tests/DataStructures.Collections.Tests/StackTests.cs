using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DataStructures.Collections.Tests
{
    [TestClass]
    public class StackTests
    {
        public TestContext TestContext { get; set; }
        [TestMethod]
        public void Constructor_initializes_stack_with_array_in_parameter()
        {
            int[] initialArray = new int[] { 1, 2, 3 };
            Stack<int> stack = new Stack<int>(initialArray);
            Assert.IsTrue(stack.Length == initialArray.Length);
            for (int i = initialArray.Length - 1; i >= 0; i--)
            {
                var value = stack.Pop();
                Assert.IsTrue(value == initialArray[i]);
            }
        }
        [TestMethod]
        public void Constructor_initialSize_parameter_doesn_t_affect_stack_length()
        {
            Stack<int> stack = new Stack<int>(14);
            Assert.IsTrue(stack.Length == 0);
        }
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
        [TestMethod]
        public void Compare_massive_add_items_with_system_implementation()
        {   
            int size = Int16.MaxValue;
            var items = Enumerable.Range(0, size);

            var myStackAddItemsLength = AddItemsIntoMyStack(items);

            // we ensure that the previous operations won't affect the performance of the following operations
            GC.Collect();
            Task.Delay(5 * 1000).Wait();
            
            var sysStackAddItemsLength = AddItemsIntoSystemStack(items);

            TestContext.WriteLine($"MyStack.AddItemsLenght: {myStackAddItemsLength}ms\nSysStack.AddItemsLenght: {sysStackAddItemsLength}ms");
        }

        private long AddItemsIntoSystemStack(System.Collections.Generic.IEnumerable<int> items)
        {
            Stopwatch stopwatch = new Stopwatch();
            System.Collections.Generic.Stack<int> sysStack = new System.Collections.Generic.Stack<int>();
            stopwatch.Start();
            foreach (var item in items)
            {
                sysStack.Push(item);
            }
            stopwatch.Stop();
            var sysStackAddItemsLength = stopwatch.ElapsedMilliseconds;
            return stopwatch.ElapsedMilliseconds;
        }

        private long AddItemsIntoMyStack(System.Collections.Generic.IEnumerable<int> items)
        {
            Stopwatch stopwatch = new Stopwatch();
            Stack<int> myStack = new Stack<int>();
            stopwatch.Start();
            foreach (var item in items)
            {
                myStack.Push(item);
            }
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
    }
}
