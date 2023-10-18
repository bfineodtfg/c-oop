using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_oopdo
{
    internal class Alarm
    {
        public int alarmHour { get; private set; }
        public int alarmMinute { get; private set; }
        public bool isAlarmOn { get; private set; }

        public Alarm(int hour, int minute)
        {
            if (hour < 0 || hour > 24 || minute < 0 || minute > 59)
            {
                throw new FormatException();
            }
            this.alarmHour = hour;
            this.alarmMinute = minute;
            bool isAlarmOn = true;
        }
        public void SetAlarm(int hour, int minute) {
            this.alarmHour = hour;
            this.alarmMinute = minute;
            bool isAlarmOn = true;
        }
        public void TurnOnAlarm() {
            isAlarmOn = true;
        }
        public void TurnOffAlarm() { 
            isAlarmOn = false;
        }
        public bool IsAlarmTime(int hour, int minute) {
            if (hour >= alarmHour && minute >= alarmMinute )
            {
                return true;
            }
            return false;
        }
    }
}
