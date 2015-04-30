using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedSchedule
{
    class Day
    {
        private List<Shift> fullDay = new List<Shift>();
        
        public Day()
        {
            fullDay.Add(new DayShift());
            fullDay.Add(new EveningShift());
            fullDay.Add(new NightShift());
            fullDay.Add(new FreeShift());
        }
        public Day(DateTime date)
        {
            fullDay.Add(new DayShift(date));
            fullDay.Add(new EveningShift(date));
            fullDay.Add(new NightShift(date));
            fullDay.Add(new FreeShift(date));
        }
        public List<Shift> dailyShifts()
        {
            return fullDay;
        }
        
    }
}
