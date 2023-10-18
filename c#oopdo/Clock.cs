using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_oopdo
{
    internal class Clock
    {
        public int hour { get; private set; }
        public int minute { get; private set; }
        public int second { get; private set; }
        public string timeZone { get; private set; }
        public bool is24HourFormat { get; private set; }
        public sbyte getLocalTimeOffset
        {
            get {
                return (sbyte)TimeZoneInfo.Local.GetUtcOffset(DateTime.UtcNow).Hours;
            }
        }
        private sbyte timeZoneOffset { 
            get {
                
                string[] avoidMinutes = timeZone.Split(':');
                string[] tryPositive = avoidMinutes[0].Split('+');
                if (tryPositive.Length > 1)
                {
                    return Convert.ToSByte(tryPositive[1].Trim());
                }
                string[] tryNegative = avoidMinutes[0].Split('-');
                if (tryNegative.Length > 1)
                {
                    return Convert.ToSByte($"-{tryNegative[1].Trim()}");
                }
                return 0;
            } 
        }

        public Clock(int hour, int minute, int second, string timeZone, bool is24HourFormat) {
            if (hour < 0 || hour > 24 || minute < 0 || minute > 59 || (is24HourFormat && hour > 12) || second < 0 || second > 59 || timeZone.Length < 3)
            {
                throw new FormatException();
            }
            this.hour = hour;
            this.minute = minute;
            this.second = second;
            this.timeZone = timeZone;
            this.is24HourFormat = is24HourFormat;
        }
        public void SetTime(int hour, int minute, int second) {
            this.hour = hour;
            this.minute = minute;
            this.second = second;
        }
        public void DisplayTime() {
            if (is24HourFormat)
            {
                Console.WriteLine($"{hour+(timeZoneOffset-getLocalTimeOffset)}:{minute}:{second}");
            }
            else
            {
                string time = string.Empty;
                int realHour = hour + (timeZoneOffset - getLocalTimeOffset);
                if (realHour > 12)
                {
                    time = $"pm {realHour-12}:{minute}:{second}";
                }
                else
                {
                    time += $"am {realHour}:{minute}:{second}";
                }
                //time += $"
                Console.WriteLine(time);
            }
        }
        public void SetTimeZone(string timeZone)
        {
            this.timeZone = timeZone;
        }
        public void ToggleTimeFormat()
        {
            if (is24HourFormat)
            {
                is24HourFormat = false;
            }
            else
            {
                is24HourFormat = true;
            }
        }





    }
}
