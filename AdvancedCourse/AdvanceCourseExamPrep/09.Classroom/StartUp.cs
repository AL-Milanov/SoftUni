namespace ClassroomProject
{
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            Student one = new Student("Vq", "Sa", "Bank");
            Student two = new Student("Vq", "Mv", "Bank");
            Student three = new Student("Ma", "Pa", "Eco");
            Classroom classroom = new Classroom(3);


            Console.WriteLine(classroom.RegisterStudent(one));
            Console.WriteLine(classroom.RegisterStudent(two));
            Console.WriteLine(classroom.RegisterStudent(three));
            Console.WriteLine(classroom.GetStudentsCount());
            Console.WriteLine(classroom.RegisterStudent(three));

            Console.WriteLine(classroom.GetSubjectInfo("Bank"));
            Console.WriteLine(classroom.GetSubjectInfo("Banka"));
            Console.WriteLine(classroom.GetSubjectInfo("Eco"));

            Console.WriteLine(classroom.GetStudentsCount());
            Console.WriteLine(classroom.GetStudent("Vq","Sa"));
            Console.WriteLine(classroom.GetStudent("Vq","Mv"));
            Console.WriteLine(classroom.GetStudent("Vq","Ma"));
        }
    }
}