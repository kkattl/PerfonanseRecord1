using PerfomanceRecord1.Model.Classes;
using System.Collections.Generic;
using System.Linq;

namespace PerfomanceRecord1.Controler
{
    public interface IRequests
    {
        IEnumerable<Student> GetListStudents();
        IEnumerable<Student> GetStudentsWithOddId();
        IEnumerable<IGrouping<Discipline.FormOfControl, Discipline>> GetGroupeDisciplineByFormOfControle();
        IEnumerable<Student> GetStudentsPIBStartWith(string fistLetter);
        IEnumerable<object> GetStudentResult();
        IEnumerable<object> GetStudentsWithMarkBetterThan(int mark);
        IEnumerable<object> GetHighestMarkOnDiscipline();
        IEnumerable<object> GetNumberOfDisciplineOnCours();
        IEnumerable<object> GetAllStudentsMark();
        IEnumerable<Student> GetStudentsConcat();
        IEnumerable<object> GetAverageMarkOnDiscipline();
        IEnumerable<object> GetBestStudent();
        IEnumerable<Discipline> GetCreditModulOnDiscipline(int n);
        IEnumerable<Discipline> GetConcatDisciplinesStartWith(string letter1, string letter2);
        IEnumerable<Discipline> GetOrderByDisciplines();
        IEnumerable<object> GetStudentMarks();
        IEnumerable<object> GetDisciplineOnCourse();
        IEnumerable<object> GetStudentsOnCourse();
        IEnumerable<IGrouping<int, Course>> GetGroupeCoursesByYears();
        IEnumerable<DisciplineResult> GetSearchMarkOnStudentDiscipline(int studentId, int disciplineId);
    }
}
