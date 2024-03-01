using System;

public class Program{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter what you want to do (eg. Add Task/ Remove Task/ Change Task Status/ View Tasks) :--");
        string Rawcommand = Console.ReadLine();
        string NoSpaceCommand = Rawcommand.Replace(" ", "");
        string command = NoSpaceCommand.ToLower();
        Console.ReadKey();
    }
}