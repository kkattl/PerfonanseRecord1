using PerfomanceRecord1.Model.Classes;
using System.Collections.Generic;

namespace PerfomanceRecord1.Controler
{
    public class Data : IData
    {
        public List<Student> Students { get; } = new List<Student>()
        {
            new Student(1, "John Smith"),
            new Student(2, "Mary Johnson"),
            new Student(3, "David Williams"),
            new Student(4, "Linda Jones"),
            new Student(5, "Michael Brown"),
            new Student(6, "Sarah Davis"),
            new Student(7, "James Miller"),
            new Student(8, "Karen Wilson"),
            new Student(9, "Robert Moore"),
            new Student(10, "Jennifer Taylor"),
            new Student(11, "Marisa Vert"),
            new Student(12, "Martin Drew")
        };

        public List<Discipline> Disciplines { get; } = new List<Discipline>()
        {
            new Discipline(1, "Math", Discipline.FormOfControl.Test, "1"),
            new Discipline(2, "Physics", Discipline.FormOfControl.Exam, "1"),
            new Discipline(3, "Programming", Discipline.FormOfControl.Test, "2"),
            new Discipline(4, "DB", Discipline.FormOfControl.Exam, "2"),
            new Discipline(5, "Philosophy", Discipline.FormOfControl.Test, "1"),
            new Discipline(6, "TheoryOfAlgorithms", Discipline.FormOfControl.Exam, "2"),
            new Discipline(7, "JS", Discipline.FormOfControl.Test, "4"),
            new Discipline(8, "C", Discipline.FormOfControl.Exam, "4"),
            new Discipline(9, "Java", Discipline.FormOfControl.Test, "4"),
        };

        public List<Course> Courses { get; } = new List<Course>()
        {
            new Course(1, Course.NumberOfCourses.First, Course.Semesters.First, 2022),
            new Course(2, Course.NumberOfCourses.First, Course.Semesters.Second, 2023),
            new Course(3, Course.NumberOfCourses.Second, Course.Semesters.First, 2022),
            new Course(4, Course.NumberOfCourses.Second, Course.Semesters.Second, 2022),
            new Course(5, Course.NumberOfCourses.Third, Course.Semesters.First, 2023),
            new Course(6, Course.NumberOfCourses.Third, Course.Semesters.Second, 2023),
        };

        public List<DisciplineResult> DisciplineResults { get; } = new List<DisciplineResult>()
        {
            new DisciplineResult(1, 1, 1,  85),
            new DisciplineResult(1, 2, 1, 92),
            new DisciplineResult(2, 1, 1, 78),
            new DisciplineResult(2, 2, 2, 88),
            new DisciplineResult(3, 3, 2, 75),
            new DisciplineResult(3, 4, 3, 90),
            new DisciplineResult(4, 1, 3, 95),
            new DisciplineResult(4, 2, 4, 80),
            new DisciplineResult(5, 3, 4, 18),
            new DisciplineResult(5, 4, 5, 85),
            new DisciplineResult(6, 5, 5, 65),
            new DisciplineResult(6, 6, 6, 95),
            new DisciplineResult(7, 7, 6, 100),
            new DisciplineResult(7, 8, 1, 83),
            new DisciplineResult(8, 7, 2, 90),
            new DisciplineResult(8, 8, 3, 78),
            new DisciplineResult(9, 7, 4, 40),
            new DisciplineResult(9, 8, 5, 92),
            new DisciplineResult(10, 9, 6, 100)

        };
    }
}
