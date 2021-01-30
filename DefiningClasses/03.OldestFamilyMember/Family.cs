using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        private List<string> familyMembers = new List<string>();

        public void AddMember(Person member)
        {
            familyMembers.Add($"{member.Name} {member.Age}");
        }

        public Person GetOldestMember() 
        {
            Person oldestMember = new Person();
            int elder = int.MinValue;

            foreach (var person in familyMembers)
            {
                string[] splited = person.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = splited[0];
                int age = int.Parse(splited[1]);

                if (age > elder)
                {
                    oldestMember.Name = name;
                    oldestMember.Age = age;
                    elder = age;
                }
            }
            return oldestMember;
        }
    }
}
