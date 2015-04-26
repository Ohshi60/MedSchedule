using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedSchedule
{
    public enum Sex { Male, Female}
    public abstract class Person
    {
        protected readonly string name;
        protected readonly long cpr;
        protected readonly int phoneNumber;
        protected readonly Sex sex;
        protected readonly int age;

        public Person(string name, long cpr, int phoneNumber, Sex sex, int age)
        {
            this.name = name;
            this.cpr = cpr;
            this.phoneNumber = phoneNumber;
            this.sex = sex;
            this.age = age;
        }
        public Person()
        {
            this.name = "Jane Doe";
            this.cpr = 00000000;
            this.phoneNumber = 00000000;
            this.sex = Sex.Female;
            this.age = 0;
        }
        public string ID()
        {
            return this.name;
        }
    }
}
