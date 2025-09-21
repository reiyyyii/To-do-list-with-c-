// See https://aka.ms/new-console-template for more information
using System.Runtime.InteropServices.Marshalling;
using System.Linq;

using System.Globalization;
using System.Diagnostics;
using System.ComponentModel.DataAnnotations;
List<String> tasks = new List<string>();

Console.WriteLine("Hello!");

bool shallexit = false;
while (!shallexit)
{
    Console.WriteLine();
    Console.WriteLine("What do you want to do?");
    Console.WriteLine("[A]dd your task\n[S]ee all TODOs\n[R]emove a TODO\n[E]xit");
    var choice = Console.ReadLine();

    switch (choice)
    {
        case "E":
        case "e":
            shallexit = true;
            Console.WriteLine("Exit");
            break;
        case "A":
        case "a":
            Addvoid();
            break;

        case "S":
        case "s":
            SeeAllTodos();
            break;
        case "R":
        case "r":
            RemoveTask();
            break;
        default:
            Console.WriteLine("Invalid choice");
            break;
    }
}

Console.ReadKey();

void Addvoid()
{
    string description;
    do
    {
        Console.Write("Write your new task: ");
        description = Console.ReadLine();
    } while (!IsDescriptionValid(description));

    tasks.Add(description);
}

bool IsDescriptionValid(string description)
{
    if (description == "")
    {
        Console.WriteLine("The task cannnot be empty");
        return false;
    }
    else if (tasks.Contains(description))
    {
        Console.WriteLine("please try make unique task");
        return false;
    }
    return true;
}

void SeeAllTodos()
{
    if (tasks.Count == 0)
    {
        ShowNoTodosMessage();
        return;
    }
    for (int i = 0; i < tasks.Count; ++i)
    {
        Console.WriteLine($"{i + 1}: {tasks[i]}");
    }
    
}
void RemoveTask()
{
    if (tasks.Count == 0)
    {
        ShowNoTodosMessage();
        return;
    }
    TryReadIndex();
}

void TryReadIndex()
{
    bool isVlidIndex = false;
    while (!isVlidIndex)
    {
        NewMethod();
        SeeAllTodos();
        Console.WriteLine();

        if (int.TryParse(Console.ReadLine(), out int indexRemove))
        {
            indexRemove -= 1;
            if (indexRemove > 0 && indexRemove <= tasks.Count)
            {
                tasks.Remove(tasks[indexRemove]);
                Console.WriteLine();
                SeeAllTodos();
                isVlidIndex = true;
            }
            else
            {
                Console.WriteLine("your choice is invalid.");
            }
        }
    }
}






static void NewMethod()
{
    Console.WriteLine("Please select index of task you want remove");
}

static void ShowNoTodosMessage()
{
    Console.WriteLine("There is no task left.");
}

