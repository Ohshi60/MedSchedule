using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedSchedule
{
    public class DayShift: Shift 
    {
        
        public DayShift() : base()
        {
            
        }
        public DayShift(DateTime date) : base(date)
        {
            this.nursesPerShift = 1;
        }
    }
}
