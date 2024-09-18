using phonebookef.controllers;
using phonebookef.models;
using Spectre.Console;

namespace phonebookef.services;

internal class PersonServices
{
    internal static void AddPerson()
    {
        var name = AnsiConsole.Prompt(new TextPrompt<string>("What's the person's name?"));
        var phone = AnsiConsole.Prompt(new TextPrompt<string>("What's the person's phone number?"));
        var email = AnsiConsole.Prompt(new TextPrompt<string>("What's the person's email?"));

        Person person =
            new()
            {
                Name = name,
                Phone = phone,
                Email = email
            };

        PersonController.AddPerson(person);

        Console.WriteLine("Press any key to continue...");
        Console.ReadLine();

        Console.Clear();
    }
}
