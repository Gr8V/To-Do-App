using System.Security.Cryptography;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class Commands{
    public static void addTask()
    {
        string seprator = "";
        string content = File.ReadAllText("ToDoList.json");
        char lastChar = content[content.Length-1];
        if(lastChar == '}'){
            content = content.Replace("}", "");
            File.WriteAllText("ToDoList.json", content);
            seprator = ",";
        }
        Console.Write("Enter task name: ");
        string? task = Console.ReadLine();
        File.AppendAllText("ToDoList.json", seprator+"\""+task+"\"" +":\"Not-Done\",");
    }
    public static void removeTask()
    {
        string content = File.ReadAllText("ToDoList.json");
        char lastChar = content[content.Length -1];
        if(lastChar != '}'){
            content = content.Substring(0, content.Length - 1);
            File.WriteAllText("ToDoList.json", content+ "}");
        }
        Console.Write("Which task do you want to remove: ");
        string? taskToRemove = Console.ReadLine();
        JObject jsonObject = JObject.Parse(File.ReadAllText("ToDoList.json"));
        if(taskToRemove != null){
            jsonObject.Remove(taskToRemove);
        }
        string updatedJsonString = jsonObject.ToString();
        File.WriteAllText("ToDoList.json", updatedJsonString);
    }
    public static void changeTaskStatus()
    {
        Console.Write("Which task's status do you want to change:- ");
        string? taskToChange = Console.ReadLine();
        if(taskToChange != null){
            JObject jsonObject = JObject.Parse(File.ReadAllText("ToDoList.json"));
            Console.WriteLine("Current Status = " + jsonObject[taskToChange]);
            Console.Write("New Status = ");
            string? newStatus = Console.ReadLine();
            jsonObject[taskToChange] = newStatus;
            File.WriteAllText("ToDoList.json", jsonObject.ToString());
        }
        else if(taskToChange == null){
            Console.WriteLine("");
            Console.WriteLine("No Task Specified");
        }
    }
    public static void viewTasks()
    {

    }
}