using PerfomanceRecord1.Model.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PerfomanceRecord1.Controler
{
    public class Requests : IRequests
    {
        public IData d;
        public Requests(IData data)
        {
            this.d = data;
        }
        //1
        public IEnumerable<Student> GetListStudents()
        {
            var result = from s in d.Students
                         select s;
            return result.ToList();
        }
        //2
        public IEnumerable<Student> GetStudentsWithOddId()
        {
            return d.Students.Where(s => s.StudentId % 2 != 0).ToList();
        }
        //3 
        public IEnumerable<IGrouping<Discipline.FormOfControl, Discipline>> GetGroupeDisciplineByFormOfControle()
        {
            return d.Disciplines.GroupBy(ds => ds.ConcreteFormOfControl) ;
        }
        //4
        public IEnumerable<Student> GetStudentsPIBStartWith(string fistLetter)
        {
            return d.Students.Where(s => s.PIB.StartsWith(fistLetter, StringComparison.OrdinalIgnoreCase));
        }
        //5
        public IEnumerable<object> GetStudentResult()
        {
            var result = from dr in d.DisciplineResults
                         join s in d.Students on dr.StudentId equals s.StudentId
                         join ds in d.Disciplines on dr.DisciplineId equals ds.DisciplineId
                         group new { dr, s, ds } by ds.DisciplineName into g
                         select new 
                         {
                             DisciplineName = g.Key,
                             StudentsResults = from x in g
                                               select new
                                               {
                                                   pib = x.s.PIB,
                                                   mark = x.dr.Mark
                                               }
                         };
            return result;
        }
        //6
        public IEnumerable<object> GetStudentsWithMarkBetterThan(int mark)
        {
            var result = d.DisciplineResults.Where(dr => dr.Mark >= mark)
                .Join(d.Students,
                      dr => dr.StudentId,
                      s => s.StudentId,
                      (dr, s) => new
                      {
                          pib = s.PIB,
                          mark = dr.Mark
                      });
            return result;
        }
        //7
        public IEnumerable<object> GetHighestMarkOnDiscipline()
        {
            var result = d.Disciplines.GroupJoin(d.DisciplineResults,
                                                 ds => ds.DisciplineId,
                                                 dr => dr.DisciplineId,
                                                 (ds, drGroup) => new
                                                 {
                                                     disciplineName = ds.DisciplineName,
                                                     mark = drGroup.Max(dr => dr.Mark)
                                                 });
            return result;
        }
        //8
        public IEnumerable<object> GetNumberOfDisciplineOnCours()
        {
            var result = d.Courses.GroupJoin(d.DisciplineResults,
                                                c => c.CourseId,
                                                dr => dr.DisciplineId,
                                                (c, drGroup) => new
                                                {
                                                    courseNumber = c.NumberOfCourse,
                                                    semestr = c.Semester,
                                                    disciplines = drGroup.Count()
                                                });
            return result;

        }
        //9
        public IEnumerable<object> GetAllStudentsMark()
        {
            var result = from dr in d.DisciplineResults
                         join s in d.Students on dr.StudentId equals s.StudentId
                         join ds in d.Disciplines on dr.DisciplineId equals ds.DisciplineId
                         group new { dr, s, ds } by s.PIB into g
                         select new
                         {
                             PIB = g.Key,
                             StudentResults = from x in g
                                              select new
                                              {
                                                  disciplineName = x.ds.DisciplineName,
                                                  mark = x.dr.Mark
                                              }
                         };
            return result;
        }
        //10
        public IEnumerable<Student> GetStudentsConcat()
        {
            var result = d.Students.Take(3).Concat(d.Students.Skip(5));
            return result;
        }
        //11
        public IEnumerable<object> GetAverageMarkOnDiscipline()
        {
            var result = d.Disciplines.GroupJoin(d.DisciplineResults,
                                                 s => s.DisciplineId,
                                                 dr => dr.StudentId,
                                                 (s, drGroup) => new
                                                 {
                                                    disciplineName = s.DisciplineName,
                                                    averageMark = drGroup.Average(dr => dr.Mark)
                                                 });
            return result;
        }
        //12
        public IEnumerable<object> GetBestStudent()
        {
            var maxMark = d.DisciplineResults.Max(dr => dr.Mark);
            var result = from dr in d.DisciplineResults
                         where dr.Mark == maxMark
                         join s in d.Students on dr.StudentId equals s.StudentId
                         select new
                         {
                             pib = s.PIB,
                             mark = dr.Mark
                         };
            return result;
        }
        //13
        public IEnumerable<Discipline> GetCreditModulOnDiscipline(int n)
        {
            var result = from ds in d.Disciplines
                         where ds.NumberOfCreditModul == n.ToString()
                         select ds;
            return result;
        }
        //14
        public IEnumerable<Discipline> GetConcatDisciplinesStartWith(string letter1, string letter2)
        {
            var result1 = d.Disciplines.Where(ds => ds.DisciplineName.ToString().StartsWith(letter1, StringComparison.OrdinalIgnoreCase));
            var result2 = d.Disciplines.Where(ds => ds.DisciplineName.ToString().StartsWith(letter2, StringComparison.OrdinalIgnoreCase));
            var result = result1.Concat(result2).ToList();
            return result;
        }
        //15
        public IEnumerable<Discipline> GetOrderByDisciplines()
        {
            var result = d.Disciplines.OrderBy(ds => ds.DisciplineName.ToString()).ToList();
            return result;
        }
        //16
        public IEnumerable<object> GetStudentMarks()
        {
            var result = from s in d.Students
                         join dr in d.DisciplineResults on s.StudentId equals dr.StudentId into sGroup
                         from dr in sGroup.DefaultIfEmpty()
                         select new
                         {
                             pib = s.PIB,
                             mark = dr?.Mark
                         };
            return result;
        }
        //17
        public IEnumerable<object> GetDisciplineOnCourse()
        {
            var result = from course in d.Courses
                         join disciplineResult in d.DisciplineResults on course.CourseId equals disciplineResult.CourseId
                         join discipline in d.Disciplines on disciplineResult.DisciplineId equals discipline.DisciplineId
                         group discipline by new { course.NumberOfCourse, course.Semester } into courseGroup
                         select new
                         {
                             courseId = courseGroup.Key.NumberOfCourse,
                             semester = courseGroup.Key.Semester,
                             disciplines = courseGroup.Select(ds => ds.DisciplineName).ToList()
                         };
            return result;

        }
        //18
        public IEnumerable<object> GetStudentsOnCourse()
        {
            var result = d.Courses
                .Join(d.DisciplineResults,
                      c => c.CourseId,
                      dr => dr.CourseId,
                      (c, dr) => new { c, dr })
                .Join(d.Students, 
                      temp => temp.dr.StudentId,
                      s => s.StudentId,
                      (temp, s) => new { temp.c, s})
                .GroupBy(temp => new {temp.c.NumberOfCourse, temp.c.Semester},
                       temp => temp.s.PIB)
                .Select(cGroup => new
                {
                    course = cGroup.Key.NumberOfCourse,
                    semestr = cGroup.Key.Semester,
                    pib = cGroup.ToList()
                }); 
            return result;
                

        }
        //19
        public IEnumerable<IGrouping<int, Course >> GetGroupeCoursesByYears()
        {
            return d.Courses.GroupBy(c => c.YearOfEducation); 
        }
        
        //20
        public IEnumerable<DisciplineResult> GetSearchMarkOnStudentDiscipline(int studentId, int disciplineId)
        {
            var result = d.DisciplineResults.Where(dr => dr.StudentId == studentId && dr.DisciplineId == disciplineId);
            return result;
        }

    }
}
