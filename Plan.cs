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
            for(int i = 0;i<days.Count();i++)
            {
                List<Nurse> possibleCandidates = new List<Nurse>(nurses);
                if(i == 0)
                {
                    foreach(Shift shift in days[i].dailyShifts())
                    {
                        while (shift.fullShift() != true)
                        {
                            Nurse n = possibleCandidates[r.Next(0, possibleCandidates.Count())];

                            if ((shift.getNurses().Contains(n) && shift.fullShift()) != true)
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
                                foreach (Nurse nurse in possibleCandidates)
                                {
                                    shift.Add(nurse);
                                }
                        }
                    }
                }
                else
                {
                    for(int k= 0; k < days[i].dailyShifts().Count();k++)
                    {
                            if (possibleCandidates.Count() == 0)
                                break;

                            Nurse n2 = possibleCandidates[r.Next(0, possibleCandidates.Count())];

                            if ((days[i - 1].dailyShifts()[2].getNurses().Contains(n2) || days[i - 1].dailyShifts()[1].getNurses().Contains(n2)) != true && days[i].dailyShifts()[0].fullShift() != true)
                            {
                                days[i].dailyShifts()[0].Add(n2);
                                possibleCandidates.Remove(n2);
                            }
                            else if (days[i - 1].dailyShifts()[2].getNurses().Contains(n2) != true && days[i].dailyShifts()[1].fullShift() != true)
                            {
                                days[i].dailyShifts()[1].Add(n2);
                                possibleCandidates.Remove(n2);
                            }
                            else if(days[i].dailyShifts()[2].fullShift() != true)
                            {
                                days[i].dailyShifts()[2].Add(n2);
                                possibleCandidates.Remove(n2);
                            }
                            else if(days[i].dailyShifts()[3].fullShift() != true)
                            {
                                days[i].dailyShifts()[3].Add(n2);
                                possibleCandidates.Remove(n2);
                            }
                            if (possibleCandidates.Count() != 0)
                            {
                               if(days[i].dailyShifts()[k] is FreeShift)
                               {
                                   foreach (Nurse nurse in possibleCandidates)
                                       days[i].dailyShifts()[k].Add(nurse);
                               }
                            }
                    }

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
        public void printNurses(List<Nurse> nurses)
        {
            foreach(Nurse nurse in nurses)
            {
                nurse.NurseDetails();
            }
        }
        public void resetNurses(List<Nurse> nurses)
        {
            foreach(Nurse nurse in nurses)
            {
                nurse.resetCounter();
            }
        }

        private int nightViolations = 0;
        private int avrShiftDifference;
        private int freeShiftViolation = 0;

        public void returnScore()
        {
            Console.WriteLine("Fitness of the plan:   Night Shift Violations:  {0}  Free Shift Violations:   {1}", nightViolations, freeShiftViolation);
        }

        public void evaluate()
        {
            for(int i = 0; i < (days.Count() - 1);i++)
            {

                nightViolations +=  days[i].dailyShifts()[2].getNurses().Count(days[i+1].dailyShifts()[2].getNurses().Contains);
                List<Nurse> _tempNurses = new List<Nurse>();
                foreach(Nurse nurse in days[i].dailyShifts()[3].getNurses())
                {
                    if(days[i+1].dailyShifts()[3].getNurses().Contains(nurse))
                    {
                        _tempNurses.Add(nurse);
                    }
                }
                if(i < (days.Count()-2))
                {
                freeShiftViolation += _tempNurses.Count(days[i+2].dailyShifts()[3].getNurses().Contains);
                }


            }
        }
    }
}