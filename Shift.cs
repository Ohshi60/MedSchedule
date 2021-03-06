﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedSchedule
{
    public abstract class Shift
    {
        protected int nursesPerShift = 0;
        protected List<Nurse> assignedNurses;
        protected DateTime date;

        public Shift()
        {
            date = new DateTime();
            assignedNurses = new List<Nurse>();
        }
        public Shift(DateTime startTime) : this()
        {
            date = startTime;
            
        }
        public void Add(Nurse nurse)
        {
            assignedNurses.Add(nurse);
            if(!(this is FreeShift))
            {
                nurse.incrementShift();    
            }
            
        }
        public void Remove(Nurse nurse)
        {
            assignedNurses.Remove(nurse);
        }
        public void PrintShift()
        {
            Console.WriteLine("Shift: {0}  {1} ", this.date.DayOfWeek, this.GetType());
            foreach(Nurse nurse in assignedNurses)
            {
                Console.WriteLine("Nurse: {0}", nurse.ID());
            }
        }
        public List<Nurse> getNurses()
        {
            return assignedNurses;
        }
        public bool fullShift()
        {
            return (this.nursesPerShift == assignedNurses.Count());
        }
        public void printNursesOnShift()
        {
            foreach(Nurse nurse in assignedNurses)
            {
                nurse.NurseDetails();
            }
        }
    }
}
