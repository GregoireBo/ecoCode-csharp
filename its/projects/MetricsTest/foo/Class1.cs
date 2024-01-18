﻿/**
 * This is a header comment line 1
 * Header comment line 2
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// This is a comment!

namespace CSLib.foo
{
    public class MyClazz
    {
        /// <summary>
        /// Documented public API
        /// </summary>
        public int MyProperty
        {
            get
            {
                return 42;
            }
        }
    }

    class Class1
    {
        public void Main(bool condition)
        {
            MyClazz myClazz = new MyClazz();
            if (condition)
            {
                Console.WriteLine("Hello, world! " + myClazz.MyProperty);
                Console.ReadLine();
            }
        }
    }
}
