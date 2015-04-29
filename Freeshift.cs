using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedSchedule
{
    class FreeShift : Shift
    {
        public FreeShift() : base()
        {
        }
        public FreeShift(DateTime time) : base(time)
        {
            this.nursesPerShift = 1;
        }
    }
}
