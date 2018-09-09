﻿using System;
using System.Text;

namespace QuakeConsole.Tests.Utilities
{
    public class FakeConsoleInput : IConsoleInput
    {
        private readonly StringBuilder _stringBuffer = new StringBuilder();

        public string LastAutocompleteEntry { get; set; }
        public int CaretIndex { get; set; }

        public int Length => _stringBuffer.Length;

        public void Append(string value)
        {
            _stringBuffer.Append(value);
            CaretIndex = Math.Min(CaretIndex + value.Length, _stringBuffer.Length);            
        }

        public void Remove(int startIndex, int length)
        {
            _stringBuffer.Remove(startIndex, length);
        }

        public string Value
        {
            get { return _stringBuffer.ToString(); }
            set
            {
                _stringBuffer.Clear();
                _stringBuffer.Append(value);
            }
        }

        public string Substring(int startIndex, int length)
        {
            return _stringBuffer.ToString().Substring(startIndex, length);
        }

        public string Substring(int startIndex)
        {
            return _stringBuffer.ToString().Substring(startIndex);
        }

        public void Clear()
        {
            _stringBuffer.Clear();
        }

        public char this[int i]
        {
            get { return _stringBuffer[i]; }
            set { _stringBuffer[i] = value; }
        }
    }
}
