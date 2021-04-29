using System;

namespace Event
{
    class Program
    {
        static void Main(string[] args)
        {
            var fEvent = new FEvent();
            fEvent.FiveEvent += new FEvent.OnFiveHandler(Callback);

            var random = new Random();

            for (int i = 0; i < 10; i++)
            {
                int rn = random.Next(6);

                Console.WriteLine(rn);

                if (rn == 5)
                {
                    fEvent.OnFiveEvent();
                }
            }
        }

        static void Callback(object sender, EventArgs e)
        {
            Console.WriteLine("Five Event occurred");
        }
    }
}
