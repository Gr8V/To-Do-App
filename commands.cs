using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class Commands{
    public static void addTask()
    {
        Console.Write("Enter task name: ");
        string? task = Console.ReadLine();
        File.AppendAllText("ToDoList.json", "\""+task+"\"" +":\"False\",");
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

    }
    public static void viewTasks()
    {

    }
}