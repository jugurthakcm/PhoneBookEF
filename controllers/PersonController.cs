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

    internal static List<Person> GetAllPeople()
    {
        using var db = new PersonContext();

        return db.People.ToList();
    }

    internal static Person GetPersonById(int id)
    {
        using var db = new PersonContext();

        return db.People.SingleOrDefault(p => p.Id == id);
    }

    internal static void DeletePerson(Person person)
    {
        using var db = new PersonContext();

        db.Remove(person);

        db.SaveChanges();
    }
}
