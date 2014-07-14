using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorClassHuman
{
    class RefactorHuman
    {
        private enum Sex { Male, Female };

        private class Person
        {
            public Sex Sex { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }

        public void CreateHuman(int age)
        {
            Person person = new Person();
            person.Age = age;
            if (age % 2 == 0)
            {
                person.Name = "Батката";
                person.Sex = Sex.Male;
            }
            else
            {
                person.Name = "Мацето";
                person.Sex = Sex.Female;
            }
        }
    }

    class RefactorClassHuman
    {
        static void Main(string[] args)
        {
        }
    }
}
