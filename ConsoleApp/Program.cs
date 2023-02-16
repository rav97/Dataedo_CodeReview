namespace ConsoleApp
{
    using System;
    using Application.Managers;
    using Application.Managers.Interfaces;

    public class Program
    {
        static void Main(string[] args)
        {
            ICsvManager csvManager = new DatabaseCsvManager(filePath: "data.csv");
            csvManager.ImportAndPrint();

            Console.ReadKey();
        }
    }
}
