using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedSchedule
{
    class SuperPlan
    {
        Plan bestPlan = new Plan();
        
        public SuperPlan(List<Nurse> nurses, int days)
        {
            List<Nurse> finalNurses = new List<Nurse>(nurses);
            bestPlan.FitnessScore = 30000;
            for (int i = 0; i < 5; i++)
            {
                this.resetNurses();
                Plan p = new Plan(days);
                p.Initialize(nurses);
                p.evaluate(finalNurses);
                if (p.FitnessScore < bestPlan.FitnessScore)
                {
                    bestPlan = p;
                    bestPlan.ListofNurses = new List<Nurse>(finalNurses);
                }
            }
        }

        public void resetNurses()
        {
            foreach (Nurse nurse in bestPlan.ListofNurses)
            {
                nurse.resetCounter();
            }
        }
        public void printLortet()
        {
            bestPlan.printPlan();
            bestPlan.returnScore();
            bestPlan.printNurses();
        }

    }
}
