using PerfomanceRecord1.Model.Classes;
using System.Collections.Generic;

namespace PerfomanceRecord1.Controler
{
    public interface IData
    {
        List<Student> Students { get; }
        List<Course> Courses { get; }
        List<Discipline> Disciplines { get; }
        List<DisciplineResult> DisciplineResults { get; }
    }
}
