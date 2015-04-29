using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedSchedule
{
    class EveningShift : Shift 
    {
        public EveningShift() : base()
        {
        }
        public EveningShift(DateTime date) : base(date)
        {
            this.nursesPerShift = 1;
        }
    }
}
