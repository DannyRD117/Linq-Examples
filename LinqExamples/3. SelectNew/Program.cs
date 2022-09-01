
using ClassLibrary;

List<Person> people = new List<Person>()
{
    new Person("Joel", "R", 27, 85, 182, Gender.Male),
    new Person("Fernando", "S", 24, 90, 175, Gender.Male),
    new Person("Daniel", "R", 18, 55, 174, Gender.Male),
    new Person("Nandito", "Wilson", 34, 56, 160, Gender.Male),
    new Person("Tod", "Vachey", 20, 55, 180, Gender.Male),
    new Person("Anna", "Williams", 24, 77, 164, Gender.Female),
    new Person("Maria", "Ann", 55, 16, 160, Gender.Female),
    new Person("John", "117", 130, 49,218, Gender.Male),
    new Person("Anna", "Rodriguez", 26, 69, 174, Gender.Female)
};

//SELECT NEW WITH ANONYMOUS OBJECT

// people that are young
var youngPeople = from p in people
                  where p.Age < 25
                  //select new { Name = p.FirstName, Age = p.Age }; 
                  select new { p.FirstName, p.Age }; // You can ommit reemane the new propety if it is the same as old one

foreach (var p in youngPeople)
{
    Console.WriteLine($"{p.FirstName} my age is {p.Age}");
}

// SELECT NEW WITH TYPES

var youngPeople2 = from p in people
                   where p.Age < 25
                   select new YoungPerson { FullName = String.Format($"{p.FirstName} {p.LastName}"), 
                                            Age = p.Age};

foreach (var p in youngPeople2)
{
    Console.WriteLine($"Hi I'm {p.FullName} my age is {p.Age}");
}