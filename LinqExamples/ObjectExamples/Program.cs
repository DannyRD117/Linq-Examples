
using ClassLibrary;

List<Person> people = new List<Person>()
{
    new Person("Joel", 85, 182, Gender.Male),
    new Person("Fernando", 90, 175, Gender.Male),
    new Person("Daniel", 55, 174, Gender.Male),
    new Person("Nandito", 56, 160, Gender.Male),
    new Person("Tod", 70, 180, Gender.Male),
    new Person("Anna", 77, 164, Gender.Female),
    new Person("Maria", 55, 160, Gender.Female),
    new Person("John", 130, 218, Gender.Male),
    new Person("Anna", 69, 174, Gender.Female)
};

// LINQ WITH OBJECTS

// People with names of 4 letters
var fourCharPeople = from person in people
                     where person.FirstName.Length == 4
                     select person;

foreach (var person in fourCharPeople)
{
    Console.WriteLine(person.FirstName);
}

// People with names equals 4 letters and ordery by weight
var fourCharPeople2 = from person in people
                     where person.FirstName.Length == 4
                     orderby person.Weight
                     select person;

foreach (var person in fourCharPeople2)
{
    Console.WriteLine($"Name: {person.FirstName} Weight: {person.Weight}");
}

// MULTIPLE ORDER BY

// People with names equals 4 letters and order by name in ascending and by height in descending

var fourCharPeople3 = from person in people
                      where person.FirstName.Length == 4
                      orderby person.FirstName, person.Height descending
                      select person;

foreach (var person in fourCharPeople3)
{
    Console.WriteLine($"Name: {person.FirstName} Height: {person.Height}");
}


