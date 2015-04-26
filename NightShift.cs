using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedSchedule
{
    public class NightShift : Shift
    {
         public NightShift() : base()
        {
        }
        public NightShift(DateTime date) : base(date)
        {
            this.nursesPerShift = 4;

        }
    }
}
