using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedSchedule
{
    class Program
    {
        static void Main(string[] args)
        {
            Nurse n1 = new Nurse("Michael Søby", 2811862617, 60669237, Sex.Male, 28);
            Nurse n2 = new Nurse();
            Nurse n3 = new Nurse("Bente", 1234567800, 60669237, Sex.Female, 38);
            Nurse n4 = new Nurse("Jette", 1515251200, 60669237, Sex.Female, 21);
            Nurse n5 = new Nurse("Jytte", 4444888800, 60669237, Sex.Female, 58);
            Nurse n6 = new Nurse("SiroLife", 666999666, 2131241251, Sex.Male, 22);
            Nurse n7 = new Nurse("Priyanka", 666666666, 80808060, Sex.Female, 18);

            List<Nurse> nurses = new List<Nurse>();
            nurses.Add(n1);
            nurses.Add(n2);
            nurses.Add(n3);
            nurses.Add(n4);
            nurses.Add(n5);
            nurses.Add(n6);
            nurses.Add(n7);
                  List<Nurse> nurses2 = new List<Nurse>();
            nurses2.Add(n1);
         //   nurses2.Add(n2);
         //   nurses2.Add(n3);
         //   nurses2.Add(n4);
         //   nurses2.Add(n5);
         //   Plan p1 = new Plan(2);
         ////   Plan p2 = new Plan(6);
         //   p1.Add3(nurses);
         //   p1.PrintPlan();
         //   p1.PrintNurseOverview();
          //  p2.Add2(nurses);
            //p2.PrintPlan();
            //p2.PrintNurseOverview(nurses);
            Plan p2 = new Plan(10);
            p2.Initialize(nurses);
            p2.printPlan();
            Console.ReadKey();
            
        }
    }
}
