# To-Do App Documentation
<hr color="yellow">

### **Content**
1. [**Packages Used**](#packages-used)
2. [**Program.cs**](#programcs)
3. [**commands.cs**](#commandscs)
    1. [**addTask()**](#addtask)
    2. [**removeTask()**](#removetask)
    3. [**changeTaskStatus()**](#changetaskstatus)
    4. [**viewTasks()**](#viewtasks)
<br>
<br>
<hr color="yellow">

## **Packages used**
- Newtonsoft--> This c# package is used to interact with .json files using c#
    - *`dotnet add package Newtonsoft.json`*
    - Add *`using Newtonsoft.json.linq;`* at the top of your file for this program
<br>
<br>
<hr color="yellow">

## **Program.cs**
> Only contains the `Main()` method.

<br>
<br>

The string **command** is declared outside of the **Main()** function because its value is assigned inside a if statement so it could not be used in other places.
-   ```csharp
    static string? command = "";
    ```
<br>
<br>

This Codeblock Opens the .json file at the beginning of the program so that new tasks can be added to the file if needed.
<br>

then the if block adds a comma to the end if there is not a comma already and the file is not empty.
-   ```csharp
    string content = File.ReadAllText("ToDoList.json");
    content = content.Replace("}", "");
    File.WriteAllText("ToDoList.json",content);
    char lastChar = content[content.Length -1];
    if(lastChar != ',' && lastChar != '{'){
        File.AppendAllText("ToDoList.json", ",");
    }
    ```
<br>
<br>

This codeblock takes the input from the user and converts it into a string with no spaces and no caps.
-   ```csharp
    Console.WriteLine("Enter what you want to do (eg. Add Task/ Remove Task/ Change Task Status/ View Tasks) :--");
    string? rawcommand = Console.ReadLine();
    if(rawcommand != null){
        string? noSpaceCommand = rawcommand.Replace(" ", "");
        command = noSpaceCommand.ToLower();
    }
    ```
<br>
<br>

This codeblock redirects to other methods in [**commands.cs**](#commandscs) file such as `addTask()`, `removeTask()`, `changeTaskStatus()`, `viewTask()`.
<br>

The **exit** command breaks out of the `while()` loop that surrounds the procecssing of user input.
-   ```csharp
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
        case "exit":
            shouldExit = true;
            break;
    }
    ```
<br>
<br>

This block of code removes the comma at the end a task and adds a curly brace to close the file, it then prints a red line for sepration
-   ```csharp
    string finalContent = File.ReadAllText("ToDoList.json");
    finalContent = finalContent.Substring(0, finalContent.Length - 1);
    File.WriteAllText("ToDoList.json",finalContent);
    File.AppendAllText("ToDoList.json", "}");
    Console.BackgroundColor = ConsoleColor.Red;
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(" ");
    Console.WriteLine("______________________________________________________");
    Console.ResetColor();
    ```

<br>
<br>
<hr color="yellow">

## **commands.cs**
> This file contains methods that contain logic which is executed in response to a command.

<br>

### **`addTask()`**
> This method adds a task to the [ToDoList.json](#todolistjson) file.

<br>
<br>

The *seprator* variable adds comma at the end of a task if the curly braces are not closed.
<br>

The user input for new task is taken and stored in the *task* variable.
- ```csharp
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
    File.AppendAllText("ToDoList.json", seprator+"\""+task+"\"" +":\"False\",");
    ```

<br>
<br>

### **`removeTask()`**
> This method removes a task from the [ToDoList.json](#todolistjson) file.

<br>
<br>

This codeblock checks if the json file is closed before removing a element so that any error doesn't show up, it closes the file if the file is not already closed.
-   ```csharp
    string content = File.ReadAllText("ToDoList.json");
    char lastChar = content[content.Length -1];
    if(lastChar != '}'){
        content = content.Substring(0, content.Length - 1);
        File.WriteAllText("ToDoList.json", content+ "}");
    }
    ```
<br>

This codeblock takes the user input for the task to be removed, it then converts the .json file into a jsonObject and then removes the desired task if it isn't empty, then it converts the jsonObject to a string and writes it onto the .json file.
-   ```csharp
    Console.Write("Which task do you want to remove: ");
    string? taskToRemove = Console.ReadLine();
    JObject jsonObject = JObject.Parse(File.ReadAllText("ToDoList.json"));
    if(taskToRemove != null){
        jsonObject.Remove(taskToRemove);
    }
    string updatedJsonString = jsonObject.ToString();
    File.WriteAllText("ToDoList.json", updatedJsonString);
    ```
<br>
<br>

### **`changeTaskStatus()`**
> This method is used to change the status of a task from the [ToDoList.json](#todolistjson) file.

<br>
<br>

Take The User input for the task they want to change.
-   ```csharp
    Console.Write("Which task's status do you want to change:- ");
        string? taskToChange = Console.ReadLine();
    ```
<br>

Checks if the specified task exists or not. If it exits the code in the if statement gets executed.
<br>

The code inside the if statement converts the .json file into a jsonObject and asks the user for the new status. It then changes the task's status and writes the jsonObject onto the .json file
-   ```csharp
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
    ```
<br>
<br>

### **`viewTasks()`**
> This method is used to view all the tasks in [ToDoList.json](#todolistjson) file in the console window.

<br>
<br>

Converts .json file into Readable format and then displays it on the console in yellow colour.
-   ```csharp
    JObject jsonObject = JObject.Parse(File.ReadAllText("ToDoList.json"));
    jsonObject.Remove("");
    string jsonContent = jsonObject.ToString();
    jsonContent = jsonContent.Replace("{", "");
    jsonContent = jsonContent.Replace("}", "");
    jsonContent = jsonContent.Replace(",", "");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine(jsonContent);
    Console.ResetColor();
    ```
