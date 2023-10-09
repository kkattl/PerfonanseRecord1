using PerfomanceRecord1.Controler;
using PerfomanceRecord1.View.Command;
using System.Collections.Generic;
using System;

namespace PerfomanceRecord1.View
{
    public class MenuCommand
    {
        private IOutputResultsOnConsole _output;
        private CommandInvoker _invoker = new CommandInvoker();
        private Dictionary<Menu, Action> _commands = new Dictionary<Menu, Action>();

        public MenuCommand(IOutputResultsOnConsole output)
        {
            _output = output;

            InitializeMenuCommands();
        }
        private void InitializeMenuCommands()
        {
            _commands.Add(Menu.ListStudents, () => _output.OutputListStudents());
            _commands.Add(Menu.StudentsWithOddId, () => _output.OutputStudentsWithOddId());
            _commands.Add(Menu.GroupeDisciplineByFormOfControle, () => _output.OutputGetGroupeDisciplineByFormOfControle());
            _commands.Add(Menu.StudentsPIBStartWith, () => _output.OutputGetStudentsPIBStartWith());
            _commands.Add(Menu.StudentResult, () => _output.OutputStudentResult());
            _commands.Add(Menu.StudentsWithMarkBetterThan, () => _output.OutputStudentsWithMarkBetterThan());
            _commands.Add(Menu.HighestMarkOnDiscipline, () => _output.OutputHighestMarkOnDiscipline());
            _commands.Add(Menu.NumberOfDisciplineOnCours, () => _output.OutputNumberOfDisciplineOnCours());
            _commands.Add(Menu.AllStudentsMark, () => _output.OutputAllStudentsMark());
            _commands.Add(Menu.StudentsConcat, () => _output.OutputStudentsConcat());
            _commands.Add(Menu.AverageMarkOnDiscipline, () => _output.OutputAverageMarkOnDiscipline());
            _commands.Add(Menu.BestStudent, () => _output.OutputBestStudent());
            _commands.Add(Menu.CreditModulOnDiscipline, () => _output.OutputCreditModulOnDiscipline());
            _commands.Add(Menu.ConcatDisciplinesStartWith, () => _output.OutputConcatDisciplinesStartWith());
            _commands.Add(Menu.OrderByDisciplines, () => _output.OutputOrderByDisciplines());
            _commands.Add(Menu.StudentMarks, () => _output.OutputStudentMarks());
            _commands.Add(Menu.DisciplineOnCourse, () => _output.OutputDisciplineOnCourse());
            _commands.Add(Menu.StudentsOnCourse, () => _output.OutputStudentsOnCourse());
            _commands.Add(Menu.GroupeCoursesByYears, () => _output.OutputGroupeCoursesByYears());
            _commands.Add(Menu.SearchMarkOnStudentDiscipline, () => _output.OutputSearchMarkOnStudentDiscipline());


        }
        public void Display()
        {
            Console.WriteLine("Menu:\n1: List of students\n2: Students with odd Id\n3: Disciplines grouping by form of controle" +
                "\n4: Students whose PIB start with letter\n5: Students results\n6:  Students with mark better than" +
                "\n7: Highest mark on discipline\n8: Number of disciplines on cours\n9: All students mark\n10: List of first 3 students and skiped 5" +
                "\n11: Average mark on disciplin\n12: Best student\n13: Amount of credit modul\n14: Concat disciplines start with" +
                "\n15: Disciplines order by\n16: Student who don`t regestrated on discipline yet\n17: Disciplines on courses" +
                "\n18: Students on course\n19: Groupe courses by years\n20: search mark by student and discipline ID\n0: Exit");


            Console.Write("Choose number of reqest: ");
            if (int.TryParse(Console.ReadLine(), out int choice) && Enum.IsDefined(typeof(Menu), choice))
            {
                _invoker.AddCommand(new ConcreteCommand(_commands[(Menu)choice]));
            }
            else
            {
                Console.WriteLine("Incorrect option.Try again");
            }
        }

        public void ExecuteCommands()
        {
            _invoker.ExecuteCommands();
        }

       
    }
}
