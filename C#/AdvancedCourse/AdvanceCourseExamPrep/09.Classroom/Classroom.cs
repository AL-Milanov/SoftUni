using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;

        public Classroom(int capacity)
        {
            Capacity = capacity;
            this.students = new List<Student>();
        }

        public int Capacity { get; set; }

        public int Count => students.Count;

        public string RegisterStudent(Student student)
        {
            if (this.students.Count < Capacity)
            {
                students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }

            return "No seats in the classroom";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            Student student = students.Where(f => f.FirstName == firstName).Where(l => l.LastName == lastName)
                .FirstOrDefault();

            if (student == null)
            {
                return "Student not found";
            }

            students.Remove(student);
            return $"Dismissed student {firstName} {lastName}";
        }

        public string GetSubjectInfo(string subject)
        {
            string result = string.Empty;
            int counter = 0;
            int matches = students.Where(s => s.Subject == subject).Count();

            foreach (var student in students)
            {
                if (student.Subject == subject)
                {
                    if (counter == 0)
                    {
                        result += $"Subject: {subject}" + Environment.NewLine;
                        result += "Students:" + Environment.NewLine;
                    }

                    counter++;
                    if (counter == matches)
                    {
                        result += $"{student.FirstName} {student.LastName}";
                    }
                    else
                    {
                        result += $"{student.FirstName} {student.LastName}" + Environment.NewLine;

                    }
                }
            }

            if (result == "")
            {
                result += "No students enrolled for the subject";
            }
            return result;
        }

        public int GetStudentsCount()
        {
            return this.Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            Student student = students.Where(f => f.FirstName == firstName).Where(l => l.LastName == lastName)
                .FirstOrDefault();

            return student;
        }
    }
}
