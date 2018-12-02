using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Collections
{
    public class Stack<T>
    {
        public int Length
        {
            get
            {
                return 0;
            }
        }
        public void Push(T item)
        {
        }
        public T Pop()
        {
            throw new InvalidOperationException("The stack is empty!");
        }
        public void Clear()
        {

        }
    }
}
