using System;

class Program{
    public string command = "";
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter what you want to do (eg. Add Task/ Remove Task/ Change Task Status/ View Tasks) :--");
        command = Console.ReadLine();
        
        Console.ReadKey();
    }
}