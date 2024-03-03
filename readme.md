<style>h1,h2,h3,h4 { border-bottom: 0; } </style>
# To-Do App Documentation
<hr color="yellow">

### **Content**
1. [**Packages Used**](#packages-used)
2. [**Program.cs**](#programcs)
3. [**commands.cs**](#commandscs)
    1. [**addTask()**](#addtask)
    2. [**removeTask()**](#removetask)
    3. [**changeTaskStatus()**](#changetaskstatus)
    4. [**viewTasks()**](#vie)
4. [**ToDoList.json**](#todolistjson)
<br>
<br>
<hr color="yellow">

## **Packages used**
- Newtonsoft--> This c# package is used to interact with .json files using c#
    - *`dotnet add package Newtonsoft.json`*
    - Add *`using Newtonsoft.json;`* at the top of your file
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

This codeblock takes the input from the user and converts it into a string with no spaces and no caps.
-   ```csharp
    Console.WriteLine("Enter what you want to do (eg. Add Task/ Remove Task/ Change Task Status/ View Tasks) :--");
    string? rawcommand = Console.ReadLine();
    if(rawcommand != null){
            tring? noSpaceCommand = rawcommand.Replace(" ", "");
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

> For information about the code inside `#region json` go to [**ToDoList.json**](#todolistjson).

<br>
<br>
<hr color="yellow">

## **commands.cs**
> This file contains methods that contain logic which is executed in response to a command

### **`addTask()`**
> This method adds a task to the [ToDoList.json](#todolistjson) file.

<br>
<br>

### **`removeTask()`**
> This method removes a task from the [ToDoList.json](#todolistjson) file.

<br>
<br>

### **`changeTaskStatus()`**
> This method is used to change the status of a task from the [ToDoList.json](#todolistjson) file.

<br>
<br>

### **`viewTasks()`**
> This method is used to view all the tasks in [ToDoList.json](#todolistjson) file in the console window.

<br>
<br>
<hr color="yellow">

## **ToDoList.json**

>This file contains the list of tasks and their status in the form of a .json file