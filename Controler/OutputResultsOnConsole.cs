using System;
using System.Linq;

namespace PerfomanceRecord1.Controler
{
    public class OutputResultsOnConsole : IOutputResultsOnConsole
    {
        public IRequests requests;
        public OutputResultsOnConsole(IRequests request)
        {
            this.requests = request;
        }

        //1
        public void OutputListStudents()
        {
            Console.WriteLine("Output list of students");
            var students = requests.GetListStudents();
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }
        //2
        public void OutputStudentsWithOddId()
        {
            Console.WriteLine("Output students with odd Id");
            var students = requests.GetStudentsWithOddId();
            foreach (var student in students)
            {
                Console.WriteLine(student.ToString());
            }
        }
        //3
        public void OutputGetGroupeDisciplineByFormOfControle()
        {
            Console.WriteLine("Output disciplines grouping by form of controle");
            var groupedDisciplines = requests.GetGroupeDisciplineByFormOfControle();
            foreach (var groupe in groupedDisciplines)
            {
                Console.WriteLine($"\nForm of controle {groupe.Key}");
                foreach (var discipline in groupe)
                {
                    Console.WriteLine(discipline.DisciplineName);
                }
            }
        }
        //4
        public void OutputGetStudentsPIBStartWith()
        {
            Console.WriteLine("Enter first letter");
            string letter = Console.ReadLine();
            Console.WriteLine($"Output students whose PIB start with letter ({letter})");
            var students = requests.GetStudentsPIBStartWith(letter);
            if (students.Any())
            {
                foreach (var student in students)
                {
                    Console.WriteLine(student.ToString());
                }
            }
            else
            {
                Console.WriteLine("No students found with names starting with the specified letter.");
            }
        }
        //5
        public void OutputStudentResult()
        {
            Console.WriteLine("Output students results");
            var result = requests.GetStudentResult();
            foreach (dynamic item in result)
            {
                Console.WriteLine($"\n{item.DisciplineName}");

                foreach (var row in item.StudentsResults)
                {
                    Console.WriteLine($"      {row.pib} ({row.mark})");
                }
            }
        }
        //6
        public void OutputStudentsWithMarkBetterThan()
        {
            Console.WriteLine("Input mark");
            if (int.TryParse(Console.ReadLine(), out int mark) && mark >= 0 && mark <= 100)
            {
                Console.WriteLine($"Output students with mark better than ({mark})");
                var studentsMark = requests.GetStudentsWithMarkBetterThan(mark);
                foreach (dynamic item in studentsMark)
                {
                    Console.WriteLine($"{item.pib} ({item.mark})");
                }
            }
            else
            {
                Console.WriteLine("Invalid mark input. Please enter a valid mark between 0 and 100.");
            }
        }
        //7
        public void OutputHighestMarkOnDiscipline()
        {
            Console.WriteLine("Output highest mark on discipline");
            var discipline100 = requests.GetHighestMarkOnDiscipline();
            foreach (dynamic item in discipline100)
            {
                Console.WriteLine($"{item.pib} ({item.mark})");
            }
        }
        //8
        public void OutputNumberOfDisciplineOnCours()
        {
            Console.WriteLine("Output number of disciplines on cours");
            var result = requests.GetNumberOfDisciplineOnCours();
            foreach(dynamic item in result)
            {
                Console.WriteLine($"Course({item.courseNumber}) semestr({item.semestr}):\nAmount of disciplines: {item.disciplines}");
            }
        }
        //9
        public void OutputAllStudentsMark()
        {
            Console.WriteLine("Output all students mark");
            var result = requests.GetAllStudentsMark();
            foreach (dynamic item in result)
            {
                Console.WriteLine($"\n{item.PIB}");

                foreach (var row in item.StudentResults)
                {
                    Console.WriteLine($"      {row.disciplineName} ({row.mark})");
                }
            }
        }
        //10
        public void OutputStudentsConcat()
        {
            Console.WriteLine("Output list of first 3 students and skiped 5");
            var students = requests.GetStudentsConcat();
            foreach(var student in students)
            {
                Console.WriteLine(student.ToString());
            }
        }
        //11
        public void OutputAverageMarkOnDiscipline()
        {
            Console.WriteLine("Output average mark on discipline");
            var result = requests.GetAverageMarkOnDiscipline();
            foreach (dynamic row in result)
            {
                Console.WriteLine($"{row.disciplineName}:\n   Average mark:{row.averageMark}");
            };
        }
        //12
        public void OutputBestStudent()
        {
            Console.WriteLine("Output best student");
            var result = requests.GetBestStudent();
            foreach (dynamic item in result)
            {
                Console.WriteLine($"{item.pib} ({item.mark})");
            }
        }
        //13
        public void OutputCreditModulOnDiscipline()
        {
            Console.WriteLine("Enter amount of credit modul");
            if (int.TryParse(Console.ReadLine(), out int n))
            {
                Console.WriteLine("Output credit modul on discipline");

                var result = requests.GetCreditModulOnDiscipline(n);

                if (result.Any())
                {
                    foreach (var item in result)
                    {
                        Console.WriteLine(item.ToString());
                    }
                }
                else
                {
                    Console.WriteLine($"No discipline found with {n} credit modul(s).");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }
        //14
        public void OutputConcatDisciplinesStartWith()
        {
            Console.WriteLine("Enter first letter");
            string letter1 = Console.ReadLine();
            Console.WriteLine("Enter second letter");
            string letter2 = Console.ReadLine();
            Console.WriteLine($"Output concat disciplines start with {letter1} and {letter2}");
            var disciplines = requests.GetConcatDisciplinesStartWith(letter1, letter2);
            if (disciplines.Any())
            {
                foreach (var discipline in disciplines)
                {
                    Console.WriteLine(discipline.ToString());
                }
            }
            else
            {
                Console.WriteLine("No disciplines found that match the specified criteria.");
            }
        }
        //15
        public void OutputOrderByDisciplines()
        {
            Console.WriteLine("Output disciplines order by");
            var disciplines = requests.GetOrderByDisciplines();
            foreach (var discipline in disciplines)
            {
                Console.WriteLine(discipline.ToString());
            }
        }
        //16
        public void OutputStudentMarks()
        {
            Console.WriteLine("Output student who don`t regestrated on discipline yet");
            var students = requests.GetStudentMarks();
            foreach (dynamic student in students)
            {
                Console.WriteLine($"{student.pib} ({student.mark})");
            }
        }
        //17
        public void OutputDisciplineOnCourse()
        {
            Console.WriteLine("Output disciplines on courses ");
            var result = requests.GetDisciplineOnCourse();
            foreach (dynamic item in result)
            {
                Console.WriteLine($"\nCourse: {item.courseId}, Semestr: {item.semester}\nDisciplines");
                foreach (dynamic discipline in item.disciplines)
                {
                    Console.WriteLine(discipline);
                }
            }
        }
        //18
        public void OutputStudentsOnCourse()
        {
            Console.WriteLine("Output students on course");
            var result = requests.GetStudentsOnCourse();
            foreach(dynamic item in result)
            {
                Console.WriteLine($"\nCourse: {item.course}, Semestr: {item.semestr}\nDisciplines");
                foreach (dynamic student in item.pib)
                {
                    Console.WriteLine(student);
                }
            }
        }
        //19
        public void OutputGroupeCoursesByYears()
        {
            Console.WriteLine("Output course grouping by years");
            var groupedCourses = requests.GetGroupeCoursesByYears();
            foreach (var groupe in groupedCourses)
            {
                Console.WriteLine($"\nCourse Year {groupe.Key}");
                foreach (var course in groupe)
                {
                    Console.WriteLine(course.CourseId);
                }
            }
        }
        //20
        public void OutputSearchMarkOnStudentDiscipline()
        {
            Console.WriteLine("Enter student ID");
            if (int.TryParse(Console.ReadLine(), out int studentId))
            {
                Console.WriteLine($"Enter discipline ID");
                if (int.TryParse(Console.ReadLine(), out int disciplinId))
                { 
                    var studentMark = requests.GetSearchMarkOnStudentDiscipline(studentId, disciplinId);
                    foreach (dynamic item in studentMark)
                    {
                        Console.WriteLine($"Mark: {item.Mark}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid mark input");
                }   
            }
            else
            {
                Console.WriteLine("Invalid mark input");
            }

        }
    }
    
}
