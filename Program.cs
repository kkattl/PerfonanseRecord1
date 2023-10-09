using PerfomanceRecord1.Controler;
using PerfomanceRecord1.View;
using System;

namespace PerfomanceRecord1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IData data = new Data();
            var request = new Requests(data);
            var outputResults = new OutputResultsOnConsole(request);



            MenuCommand menu = new MenuCommand(outputResults);
            menu.Display();
            menu.ExecuteCommands();
            Console.ReadKey();
        }
    }
}
