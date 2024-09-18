using phonebookef.controllers;
using phonebookef.models;
using Spectre.Console;

namespace phonebookef.ui;

internal class UserInterface
{
    internal static void ShowAllContacts(List<Person> people)
    {
        var table = new Table();

        table.AddColumn("Id");
        table.AddColumn("Name");
        table.AddColumn("Phone");
        table.AddColumn("Email");

        foreach (var p in people)
        {
            table.AddRow(p.Id.ToString(), p.Name, p.Phone, p.Name);
        }

        AnsiConsole.Write(table);
    }

    internal static void ViewPerson(Person person)
    {
        var panel = new Panel(
            $@"Id: {person.Id}
Name: {person.Name}
Phone: {person.Phone}
Email: {person.Email}"
        );

        panel.Header = new PanelHeader("Person Info");
        panel.Padding = new Padding(2, 2, 2, 2);

        AnsiConsole.Write(panel);

        Console.WriteLine("Press any key to continue...");
        Console.ReadLine();

        Console.Clear();
    }
}
