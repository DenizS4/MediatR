using DemoLibrary.Models;

namespace DemoLibrary.DataAccess;

public class DemoDataAccess : IDataAccess
{
    private List<Person> people = new();

    public DemoDataAccess()
    {
        people.Add(new Person { Id = 1, FirstName = "Deniz", LastName = "Sanli" });
        people.Add(new Person { Id = 2, FirstName = "Mahmut", LastName = "x" });
    }

    public List<Person> GetPeople()
    {
        return people;
    }

    public Person InsertPerson(string firstName, string lastName)
    {
        Person p = new() { FirstName = firstName, LastName = lastName };
        p.Id = people.Max(x => x.Id) + 1;
        people.Add(p);
        return p;
    }
    
}