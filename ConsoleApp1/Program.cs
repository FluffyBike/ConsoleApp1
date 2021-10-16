using ClassLibrary1;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var libraryClass = new LibraryClass();
            libraryClass.MyMethod();                // <- logged

            var consoleClass = new ConsoleClass();
            consoleClass.ConsoleMethod();           // <- not logged

            Console.ReadKey();
        }
    }
}
