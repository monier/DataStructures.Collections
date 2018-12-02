﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Collections
{
    public class Stack<T>
    {
        private T[] _innerItems = null;
        private int _realSize = 0;
        public int Length
        {
            get
            {
                return _realSize;
            }
        }
        public Stack(int initialSize = 0)
        {
            _innerItems = new T[initialSize];
            _realSize = 0;
        }
        public Stack(T[] initialItems)
        {
            if (initialItems != null)
            {
                _innerItems = new T[initialItems.Length];
                initialItems.CopyTo(_innerItems, 0);
                _realSize = initialItems.Length;
            }
            else
            {
                _innerItems = new T[0];
                _realSize = 0;
            }
        }
        public void Push(T item)
        {
            _realSize++;
            if (_innerItems.Length < _realSize)
            {
                //T[] _newItems = new T[_realSize];
                //_innerItems.CopyTo(_newItems, 0);
                //_innerItems = _newItems;

                Array.Resize(ref _innerItems, _realSize);
            }
            _innerItems[_realSize - 1] = item;
        }
        public T Pop()
        {
            if (_realSize > 0)
            {
                _realSize--;
                var value = _innerItems[_realSize];
                Array.Resize(ref _innerItems, _realSize);
                return value;
            }
            throw new InvalidOperationException("The stack is empty!");
        }
        public void Clear()
        {
            if (_realSize > 0)
            {
                _innerItems = new T[0];
            }
            _realSize = 0;
        }
    }
}
