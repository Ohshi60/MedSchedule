using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedSchedule
{
    class Plan
    {
        private List<Shift> shifts;

        public Plan()
        {
            shifts = new List<Shift>();
        }

        public Plan(params Shift[] shifts) : this()
        {
            Array.ForEach(shifts, x => this.shifts.Add(x));
        }
        public void Add2(List<Nurse> nurses)
        {
            int j = 0;

            foreach (Shift shift in shifts)
            {
                while (shift.getNurses().Count() < shift.fullShift())
                {
                    if (j >= nurses.Count())
                        j = 0;
                    else if(shift.getNurses().Contains(nurses[j]) != true)
                    { 
                        shift.Add(nurses[j]);
                    }
                    j++;
                }
            }
        }
        public Plan(int numberOfDays) : this()
        {
            for (int i = 0; i < numberOfDays; i++)
            {
                this.Add(new DayShift(DateTime.Now.AddDays(i)));
                this.Add(new EveningShift(DateTime.Now.AddDays(i)));
                this.Add(new NightShift(DateTime.Now.AddDays(i)));
            }
        }
        public void Add1(List<Nurse> nurses)
        {
            int i, j =0;
            foreach(Shift shift in shifts)
            {
                while(shift.getNurses().Count() < shift.fullShift())
                {
                    for (i = 0; i < shifts.Count(); i++)
                    {
                        if (j >= nurses.Count())
                            j = 0;
                        if (shifts[i].fullShift() > shifts[i].getNurses().Count() && (shifts[i].getNurses().Contains(nurses[j])) != true)
                        {
                            shifts[i].Add(nurses[j]);
                            nurses[j].incrementShift();
                            j++;
                        }
                        else
                            j++;
                    }
                }
            }

        }
        public void Add(Shift shift)
        {
            shifts.Add(shift);
        }
        public void PrintPlan()
        {
            foreach(Shift shift in shifts)
            {
                shift.PrintShift();
                Console.WriteLine("Shift active roster: {0}/ {1}" , shift.getNurses().Count(), shift.fullShift());
            }
        }
        public void PrintNurseOverview()
        {
            foreach(Shift shift in shifts)
            {
                shift.printNursesOnShift();
            }
        }
        public void Add3(List<Nurse> nurses)
        {
            int i;
            int j = 1;
            int k;
            List<Nurse> possibleCandidates = new List<Nurse>(nurses);
            for(i = 0; i < shifts.Count();i++,j++)
            {
                if(j % 3 == 0 )
                {
                    possibleCandidates = new List<Nurse>(nurses);
                }
                if(shifts[i].getNurses().Count() < shifts[i].fullShift())
                {
                    for (k = 0; k < possibleCandidates.Count(); k++)
                    {
                        if (shifts[i].getNurses().Contains(possibleCandidates[k]) != true)
                        {
                            shifts[i].Add(possibleCandidates[k]);
                            possibleCandidates.Remove(possibleCandidates[k]);
                        }
                    }
                }
            }
        }
        //public bool nursePreviousShift(Nurse nurse)
        //{
        //    int i, k;
        //    for(int k = 1; i < shifts.Count();i++)
        //    {
        //        shifts[k].getNurses().Contains(nurse); 
        //    }
        //}
    }
}