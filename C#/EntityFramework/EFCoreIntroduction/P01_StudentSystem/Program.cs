using P01_StudentSystem.Data.Models;
using System;

namespace P01_StudentSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentSystemContext context = new StudentSystemContext();

            context.Database.EnsureCreated();
        }
    }
}
