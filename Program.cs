using System;

namespace StudentManagementSystem
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Math { get; set; }
        public double Science { get; set; }
        public double English { get; set; }

        public double Average
        {
            get { return (Math + Science + English) / 3.0; }
        }

        public string Grade
        {
            get
            {
                if (Average >= 90) return "A";
                if (Average >= 85) return "B+";
                if (Average >= 80) return "B";
                if (Average >= 75) return "C";
                return "F";
            }
        }
    }
}



namespace StudentManagementSystem
{
    class Program
    {
        static List<Student> students = new List<Student>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();

                PrintHeader();
                PrintMenu();

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddStudent();
                        break;

                    case "2":
                        ViewAllStudents();
                        break;

                    case "3":
                        SearchStudent();
                        break;

                    case "4":
                        UpdateStudent();
                        break;

                    case "5":
                        DeleteStudent();
                        break;

                    case "6":
                        ViewClassSummary();
                        break;

                    case "7":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        Pause();
                        break;
                }
            }
        }

        static void PrintHeader()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("=======================================");
            Console.WriteLine("       STUDENT MANAGEMENT SYSTEM");
            Console.WriteLine("=======================================");

            Console.ResetColor();
            Console.WriteLine();
        }

        static void PrintMenu()
        {
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. View All Students");
            Console.WriteLine("3. Search Student");
            Console.WriteLine("4. Update Student");
            Console.WriteLine("5. Delete Student");
            Console.WriteLine("6. View Class Summary");
            Console.WriteLine("7. Exit");
            Console.WriteLine();
        }

        static void AddStudent()
        {
            Student student = new Student();

            Console.Write("Enter ID: ");
            student.Id = int.Parse(Console.ReadLine());

            Console.Write("Enter Name: ");
            student.Name = Console.ReadLine();

            Console.Write("Enter Math Grade: ");
            student.Math = double.Parse(Console.ReadLine());

            Console.Write("Enter Science Grade: ");
            student.Science = double.Parse(Console.ReadLine());

            Console.Write("Enter English Grade: ");
            student.English = double.Parse(Console.ReadLine());

            students.Add(student);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Student added successfully!");
            Console.ResetColor();

            Pause();
        }

        static void ViewAllStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No students found.");
                Pause();
                return;
            }

            Console.WriteLine();
            Console.WriteLine("ID\tName\t\tMath\tScience\tEnglish\tAverage\tGrade");

            foreach (var student in students)
            {
                Console.WriteLine(
                    $"{student.Id}\t{student.Name}\t{student.Math}\t{student.Science}\t{student.English}\t{student.Average:F2}\t{student.Grade}");
            }

            Console.WriteLine($"\nTotal Students: {students.Count}");

            Pause();
        }

        static void SearchStudent()
        {
            Console.Write("Enter Student ID: ");
            int id = int.Parse(Console.ReadLine());

            Student student = students.Find(s => s.Id == id);

            if (student == null)
            {
                Console.WriteLine("Student not found.");
            }
            else
            {
                Console.WriteLine("\nStudent Found");
                Console.WriteLine($"ID: {student.Id}");
                Console.WriteLine($"Name: {student.Name}");
                Console.WriteLine($"Math: {student.Math}");
                Console.WriteLine($"Science: {student.Science}");
                Console.WriteLine($"English: {student.English}");
                Console.WriteLine($"Average: {student.Average:F2}");
            }

            Pause();
        }

        static void UpdateStudent()
        {
            Console.Write("Enter Student ID to Update: ");
            int id = int.Parse(Console.ReadLine());

            Student student = students.Find(s => s.Id == id);

            if (student == null)
            {
                Console.WriteLine("Student not found.");
            }
            else
            {
                Console.Write("New Name: ");
                student.Name = Console.ReadLine();

                Console.Write("New Math Grade: ");
                student.Math = double.Parse(Console.ReadLine());

                Console.Write("New Science Grade: ");
                student.Science = double.Parse(Console.ReadLine());

                Console.Write("New English Grade: ");
                student.English = double.Parse(Console.ReadLine());

                Console.WriteLine("Student updated successfully.");
            }

            Pause();
        }

        static void DeleteStudent()
        {
            Console.Write("Enter Student ID to Delete: ");
            int id = int.Parse(Console.ReadLine());

            Student student = students.Find(s => s.Id == id);

            if (student == null)
            {
                Console.WriteLine("Student not found.");
            }
            else
            {
                students.Remove(student);
                Console.WriteLine("Student deleted successfully.");
            }

            Pause();
        }

        static void ViewClassSummary()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No students available.");
                Pause();
                return;
            }

            double classAverage = students.Average(s => s.Average);
            Student topStudent = students.OrderByDescending(s => s.Average).First();

            Console.WriteLine("\nCLASS SUMMARY");
            Console.WriteLine("------------------------------------");
            Console.WriteLine($"Total Students : {students.Count}");
            Console.WriteLine($"Class Average  : {classAverage:F2}");
            Console.WriteLine($"Highest Average: {topStudent.Average:F2}");
            Console.WriteLine($"Top Student    : {topStudent.Name} ({topStudent.Average:F2})");

            Pause();
        }

        static void Pause()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}