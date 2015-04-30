using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedSchedule
{
    class Plan
    {
        //private List<Shift> shifts;
        private List<Day> days;
        public Plan()
        {
            days= new List<Day>();
        }
        public Plan(int numberofDays) : this()
        {
            for (int i = 0; i < numberofDays;i++)
                days.Add(new Day(DateTime.Now.AddDays(i)));
        }
        public void Initialize(List<Nurse> nurses)
        {
            // Part 1 of the method
            Random r = new Random();

            foreach (Day day in days)
            {
                List<Nurse> possibleCandidates = new List<Nurse>(nurses);
                foreach (Shift shift in day.dailyShifts())
                {
                    while(shift.getNurses().Count() < shift.fullShift())
                    { 
                    Nurse n = possibleCandidates[r.Next(0, possibleCandidates.Count())];

                    if (shift.getNurses().Contains(n) != true && shift.getNurses().Count() < shift.fullShift())
                    {
                        shift.Add(n);
                        possibleCandidates.Remove(n);
                    }
                    else
                        break;
                    }
                    if (possibleCandidates.Count() != 0)
                    {
                        if (shift is FreeShift)
                            foreach(Nurse nurse in possibleCandidates)
                            {
                                shift.Add(nurse);
                            }
                    }


                    //foreach (Nurse nurse in nurses)
                    //{
                    //    if (shift.getNurses().Contains(nurse) && shift.getNurses().Count() >= shift.fullShift())
                    //    {
                    //        break;
                    //    }
                    //    else if (shift.getNurses().Contains(nurse) != true && shift.getNurses().Count() < shift.fullShift())
                    //        shift.Add(nurse);
                    //    else
                    //        break;
                    //}
                }
            }
        }
        public void printPlan()
        {
            foreach(Day day in days)
            {
               List<Shift> templist = new List<Shift>(day.dailyShifts());
                foreach(Shift shift in templist)
                {
                    shift.PrintShift();
                }
                      
            }
        }
    }
}