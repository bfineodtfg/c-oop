using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace c_oopdo
{
    
    internal class Timer
    {
        private int elapsedSeconds { get; set; } 
        private int remainingSeconds { get; set; }
        private System.Timers.Timer timer = new System.Timers.Timer();
        public Timer(int seconds) { 
            remainingSeconds = seconds;
        }
        public void SetTime(int seconds) { 
            remainingSeconds = seconds;
        }
        
        public void StartTimer()
        {
            
            timer.Interval = 100;
            timer.Elapsed += new ElapsedEventHandler(timePasses);

            timer.Start();
        }
        private void timePasses(object sender, EventArgs e)
        {
            if (remainingSeconds == 0)
            {
                timer.Stop();
                return;
            }
            elapsedSeconds++;
            remainingSeconds--;
            int cursorPosLeft = Console.CursorLeft;
            int cursorPosTop = Console.CursorTop;
            if ((elapsedSeconds / 60) < 1)
            {
                Console.WriteLine($"Eltelt idő: {elapsedSeconds} másodperc");

            }
            else if ((elapsedSeconds / 3600) < 1)
            {
                Console.WriteLine($"Eltelt idő: {elapsedSeconds / 60} perc {elapsedSeconds % 60} másodperc");

            }
            else if ((elapsedSeconds / 86400) < 1)
            {
                Console.WriteLine($"Eltelt idő: {elapsedSeconds / 3600} óra {(elapsedSeconds % 3600) / 60} perc {elapsedSeconds % 60} másodperc");
            }

        }
    
    
    }
}
