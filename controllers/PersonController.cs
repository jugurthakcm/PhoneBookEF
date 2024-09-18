using phonebookef.models;

namespace phonebookef.controllers;

internal class PersonController
{
    internal static void AddPerson(Person person)
    {
        using var db = new PersonContext();
        db.Add(person);
        db.SaveChanges();
    }
}
