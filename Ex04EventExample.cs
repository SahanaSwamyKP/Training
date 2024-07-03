using System;
using System.Threading;

namespace ConsoleApp1
{
    class AlaramClock
    {
        public event Action OnAlaramTime;
        private readonly DateTime alaramtime;
        public AlaramClock(DateTime alaramtime)
        {
            this.alaramtime = alaramtime;
        }
        public void DisplayClock()
        {
            if (DateTime.Now.Minute == alaramtime.Minute)
            {
                if (OnAlaramTime != null)
                    OnAlaramTime();
                else
                    Console.WriteLine("Event handler is not set");

            }
            Console.WriteLine(DateTime.Now.ToLongTimeString());
        }
    }

    class EventExample
    {
        static void testFunc()
        {
            Console.WriteLine("Test Func");
        }
        static void Main(string[] args)
        {
            // ActionExample();
            ClockExample();
        }

        private static void ClockExample()
        {
            AlaramClock clock = new AlaramClock(DateTime.Now.AddMinutes(1));
            clock.OnAlaramTime += Clock_OnAlaramTime;
            do
            {
                clock.DisplayClock();
                Thread.Sleep(1000);
                Console.Clear();
            } while (true);

        }


        private static void ActionExample()
        {
            Action Example = () => Console.WriteLine("Using Anonymous Method");
            Example();
        }

		private static void Clock_OnAlaramTime()
		{
            Console.WriteLine("Time for Break!!");
        }

    }
	}