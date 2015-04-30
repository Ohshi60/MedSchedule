using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedSchedule
{
    public class Nurse : Person
    {
        private int workCounter = 0;
        private bool hadNightshift = false;
        //private List<Shift> asssignedShifts;
        public Nurse(string name, long cpr, int phoneNumber, Sex sex, int age) : base(name, cpr, phoneNumber, sex, age)
        {
           // asssignedShifts = new List<Shift>();
        }
        public Nurse() : base()
        {
            
        }
        public void incrementShift()
        {
            workCounter++;
        }
        public void NurseDetails()
        {
            Console.WriteLine("Nurse: {0} #ofShifts: {1}", this.name, this.workCounter);
        }
        
    }
}
