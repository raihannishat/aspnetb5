using System;

namespace EventAndDelegate
{
    class Program
    {
        // delegate void Perform(string text);

        public delegate void Notify(string address, string message);
        public event Notify Notification;

        static void Main(string[] args)
        {
            //var printer = new Printer();
            //Action<string> action = null;
            //action += printer.PrintFormate1;
            //action += printer.PrintFormate2;

            //var text = "Hello World";
            //ProcessText(text, action);

            var instance = new Program();
            instance.Notification += EmailNotification;
            instance.Notification += SMSNotification;

            instance.Notification.Invoke("info@raihan.net", "Hello World");

            instance.Notification -= SMSNotification;

            instance.Notification.Invoke("raihan.swe@mail.com", "ASP.NET batch 5");
        }

        static void EmailNotification(string address, string message)
        {
            Console.WriteLine($"Email : {address} and {message}");
        }

        static void SMSNotification(string address, string message)
        {
            Console.WriteLine($"SMS : {address} and {message}");
        }

        //static void ProcessText(string text, Action<string> action)
        //{
        //    action.Invoke(text);   
        //}
    }
}
