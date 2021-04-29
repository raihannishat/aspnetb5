using System;

namespace DelegatesExample
{
    class Program
    {
        // delegate void MyDelegate();
        // delegate void NameDelegate(string message);
        // delegate void OperatorDelegate(int a, int b);
        // delegate void AnonymousDelegate();
        // delegate int Arithm(int x, int y);
        
        static void Main(string[] args)
        {
            //var myDelegate = new MyDelegate(MyCallback);
            //myDelegate.Invoke();

            //var person = new Person("Raihan", "Nishat");

            //var nameDelegate = new NameDelegate(person.ShowFirstName);
            //nameDelegate.Invoke("Call 1: ");

            //nameDelegate = new NameDelegate(person.ShowLastName);
            //nameDelegate.Invoke("Call 2: ");

            //var mathOperation = new Operator();

            //var operatorDelegate = new OperatorDelegate(mathOperation.Add);
            //operatorDelegate += new OperatorDelegate(mathOperation.Sub);

            //operatorDelegate.Invoke(6, 4);

            //AnonymousDelegate anonymousDelegate = delegate
            //{
            //    Console.WriteLine("Anonymous method");
            //};

            //anonymousDelegate.Invoke();

            //DoOperation(10, 2, Multiply);
            //DoOperation(10, 2, Divide);
        }

        //static int Multiply(int x, int y)
        //{
        //    return x * y;
        //}

        //static int Divide(int x, int y)
        //{
        //    return x / y;
        //}

        //static void DoOperation(int x, int y, Arithm del)
        //{
        //    int z = del.Invoke(x, y);
        //    Console.WriteLine(z);
        //}

        //static void MyCallback()
        //{
        //    Console.WriteLine("Calling callback");
        //}
    }
}
