using phonebookef.services;
using Spectre.Console;

bool isAppRunning = true;

while (isAppRunning)
{
    var option = AnsiConsole.Prompt(
        new SelectionPrompt<menuOptions>()
            .Title("What would you like to do")
            .AddChoices(
                menuOptions.AddContact,
                menuOptions.UpdateContact,
                menuOptions.DeleteContact,
                menuOptions.ViewContact,
                menuOptions.ViewAllContacts
            )
    );

    switch (option)
    {
        case menuOptions.AddContact:
            PersonServices.AddPerson();
            break;
        case menuOptions.UpdateContact:
            break;
        case menuOptions.DeleteContact:
            break;
        case menuOptions.ViewContact:
            break;
        case menuOptions.ViewAllContacts:
            break;
    }
}

enum menuOptions
{
    AddContact,
    UpdateContact,
    DeleteContact,
    ViewContact,
    ViewAllContacts
}
