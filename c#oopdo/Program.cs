using c_oopdo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_oop
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            //1
            Clock myClock = new Clock(12, 30, 45, "utc+2:00", true);
            //2
            List<Alarm> alarms = new List<Alarm>();
            alarms.Add(new Alarm(6, 0));
            alarms.Add(new Alarm(8, 0));
            //3
            Timer myTimer = new Timer(10);
            //4
            myClock.DisplayTime();
            //5
            foreach (Alarm oneAlarm in alarms)
            {
                if (oneAlarm.IsAlarmTime(DateTime.Now.Hour,DateTime.Now.Minute))
                {
                    Console.WriteLine("Az ébresztő megszólalt!");
                }
            }
            //6
            myTimer.StartTimer();


            Console.ReadKey();
        }
    }
}
