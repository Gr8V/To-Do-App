﻿public class Program{
    static string? command = "";
    public static void Main(string[] args)
    {
        string content = File.ReadAllText("ToDoList.json");
        content = content.Replace("}", "");
        File.WriteAllText("ToDoList.json",content);
        char lastChar = content[content.Length -1];
        if(lastChar != ',' && lastChar != '{'){
            File.AppendAllText("ToDoList.json", ",");
        }
        bool shouldExit = false;
        while(!shouldExit){

            Console.WriteLine("Enter what you want to do (eg. Add Task/ Remove Task/ Change Task Status/ View Tasks) :--");
            if(true){
                string? rawcommand = Console.ReadLine();
                if(rawcommand != null){
                    string? noSpaceCommand = rawcommand.Replace(" ", "");
                    command = noSpaceCommand.ToLower();
                }
            }
            switch(command)
            {
                case "addtask":
                case "addtasks":
                case "add":
                case "+":
                    Commands.addTask();
                    break;
                case "removetask":
                case "removetasks":
                case "remove":
                case "delete":
                case "deletetask":
                case "deletetasks":
                case "-":
                    Commands.removeTask();
                    break;
                case "change":
                case "changetaskstatus":
                case "changestatus":
                    Commands.changeTaskStatus();
                    break;
                case "viewtask":
                case "viewtasks":
                case "view":
                case "showtask":
                case "showtasks":
                    Commands.viewTasks();
                    break;
                case "clear":
                case "cls":
                    Console.Clear();
                    break;
                case "exit":
                    shouldExit = true;
                    break;
                default:
                    Console.WriteLine("Not a valid command.");
                    break;
            }
            string finalContent = File.ReadAllText("ToDoList.json");
            finalContent = finalContent.Substring(0, finalContent.Length - 1);
            File.WriteAllText("ToDoList.json",finalContent);
            File.AppendAllText("ToDoList.json", "}");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" ");
            Console.WriteLine("______________________________________________________");
            Console.ResetColor();
        }
        
    }
}