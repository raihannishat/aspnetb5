﻿using System;

namespace Question_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var reflect = new ReflectionUtility<MyClass>();
            reflect.GetPrivateAndProtectedMethods();
        }
    }
}
