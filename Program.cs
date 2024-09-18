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
}

enum menuOptions
{
    AddContact,
    UpdateContact,
    DeleteContact,
    ViewContact,
    ViewAllContacts
}
