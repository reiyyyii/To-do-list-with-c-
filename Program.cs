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
            Console.WriteLine("Invalid choicd");
            break;
    }
}

void Addvoid()
{
    bool isValdDescription = false;
    while (!isValdDescription)
    {
        Console.Write("Write your new task: ");
        string newTask = Console.ReadLine();
        if (newTask == "")
        {
            Console.WriteLine("The task cannnot be empty");
        }
        else if (tasks.Contains(newTask))
        {
            Console.WriteLine("please try make unique task");
        }
        else
        {
            isValdDescription = true;
            tasks.Add(newTask);
        }
    }
}
void SeeAllTodos()
{
    if (tasks.Count == 0)
    {
        Console.WriteLine("There are no task.");
    }
    else
    {
        for (int i = 0; i < tasks.Count; ++i)
        {
            Console.WriteLine($"{i + 1}: {tasks[i]}");
        }
    }
}
void RemoveTask()
{
    if (tasks.Count == 0)
    {
        Console.WriteLine("There is no task left.");
        return;
    }
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




Console.ReadKey();

static void NewMethod()
{
    Console.WriteLine("Please select index of task you want remove");
}

