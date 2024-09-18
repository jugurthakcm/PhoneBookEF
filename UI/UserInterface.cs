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
}
