namespace PerfomanceRecord1.Model.Classes
{
    public class Course
    {
        public int CourseId { get; private set; }
        public NumberOfCourses NumberOfCourse { get; private set; }
        public Semesters Semester { get; private set; }
        public int YearOfEducation { get; private set; }

        public enum NumberOfCourses
        {
            First = 1,
            Second = 2,
            Third = 3,
            Forth = 4,
        }
        public enum Semesters
        {
            First = 1,
            Second = 2,
        }

        public Course(int courseId, NumberOfCourses numberOfCourse, Semesters semester, int year)
        {
            this.CourseId = courseId;
            this.NumberOfCourse = numberOfCourse;
            this.Semester = semester;
            this.YearOfEducation = year;
        }
    }
}
