using System;

namespace PerfomanceRecord1.Model.Classes
{
    public class DisciplineResult
    {
        public int DisciplineId { get; private set; }
        public int StudentId { get; private set; }
        public int CourseId { get; private set; }
        private int _mark;
        public DisciplineResult(int studentId, int disciplineId, int courseId, int mark)
        {
            this.StudentId = studentId;
            this.DisciplineId = disciplineId;
            this.CourseId = courseId;
            this.Mark = mark;
        }
        public int Mark
        {
            get { return _mark; }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    _mark = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("DisciplineResult must be between 0 and 100.");
                }
            }
        }
    }
}

