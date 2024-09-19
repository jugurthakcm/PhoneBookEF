using phonebookef.controllers;
using phonebookef.models;
using phonebookef.ui;
using phonebookef.validation;
using Spectre.Console;

namespace phonebookef.services;

internal class PersonServices
{
    internal static void AddPerson()
    {
        var name = AnsiConsole.Prompt(new TextPrompt<string>("What's the person's name?"));
        var phone = AnsiConsole.Prompt(new TextPrompt<string>("What's the person's phone number?"));
        var email = AnsiConsole.Prompt(new TextPrompt<string>("What's the person's email?"));

        while (!Validation.ValidateEmail(email))
        {
            AnsiConsole.MarkupLine("[red]Wrong email format[/]");
            email = AnsiConsole.Prompt(new TextPrompt<string>("What's the person's email?"));
        }

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

    internal static void GetAllPeople()
    {
        var people = PersonController.GetAllPeople();
        UserInterface.ShowAllContacts(people);

        Console.WriteLine("Press any key to continue...");
        Console.ReadLine();

        Console.Clear();
    }

    internal static void GetPersonById()
    {
        var person = GetPersonOptionInput();

        if (person == null)
            return;

        UserInterface.ViewPerson(person);
    }

    internal static void DeletePerson()
    {
        var person = GetPersonOptionInput();

        if (person == null)
            return;

        PersonController.DeletePerson(person);

        Console.Clear();
    }

    internal static void UpdatePerson()
    {
        var person = GetPersonOptionInput();

        if (person == null)
            return;

        person.Name = AnsiConsole.Confirm("Update name?")
            ? AnsiConsole.Ask<string>("Person's new name:")
            : person.Name;

        person.Phone = AnsiConsole.Confirm("Update phone number?")
            ? AnsiConsole.Ask<string>("Person's new phone number:")
            : person.Phone;

        person.Email = AnsiConsole.Confirm("Update email?")
            ? AnsiConsole.Ask<string>("Person's new email:")
            : person.Email;

        while (!Validation.ValidateEmail(person.Email))
        {
            AnsiConsole.MarkupLine("[red]Wrong email format[/]");
            person.Email = AnsiConsole.Prompt(new TextPrompt<string>("What's the person's email?"));
        }

        PersonController.UpdatePerson(person);
    }

    internal static Person GetPersonOptionInput()
    {
        var people = PersonController.GetAllPeople();

        if (people.Count == 0)
        {
            Console.WriteLine("No contacts to display.\n\n");
            return null;
        }

        var peopleNames = people.Select(p => p.Name).ToArray();

        var option = AnsiConsole.Prompt(
            new SelectionPrompt<string>().Title("Choose a person:").AddChoices(peopleNames)
        );

        var personId = people.Single(p => p.Name == option).Id;

        var person = PersonController.GetPersonById(personId);

        return person;
    }
}
