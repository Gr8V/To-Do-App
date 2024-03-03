using System;
using System.Linq.Expressions;


public class Program{
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
        while(true){
            Console.WriteLine("Enter what you want to do (eg. Add Task/ Remove Task/ Change Task Status/ View Tasks) :--");
            if(true){
                string? rawcommand = Console.ReadLine();
                if(rawcommand != null){
                    string? noSpaceCommand = rawcommand.Replace(" ", "");
                    command = noSpaceCommand.ToLower();
                }
            }
            if(command == "exit"){
                break;
            }
            switch(command)
            {
                case "addtask" or "addtasks" or "add" or "+":
                    Commands.addTask();
                    break;
                case "removetask" or "removetasks" or "remove" or "delete" or "deletetask" or "deletetasks" or "-":
                    Commands.removeTask();
                    break;
                case "change" or "changetaskstatus" or "changestatus":
                    Commands.changeTaskStatus();
                    break;
                case "viewtask" or "viewtasks" or "view" or "showtask" or "showtasks":
                    Commands.viewTasks();
                    break;
            }
            string finalContent = File.ReadAllText("ToDoList.json");
            finalContent = finalContent.Substring(0, finalContent.Length - 1);
            File.WriteAllText("ToDoList.json",finalContent);
            File.AppendAllText("ToDoList.json", "}");
            Console.WriteLine(" ");
        }
        
    }
}