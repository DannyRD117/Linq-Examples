using ClassLibrary;

List<Person> people = new List<Person>()
{
    new Person("Joel", "R", 27, 85, 182, Gender.Male),
    new Person("Fernando", "S", 24, 90, 175, Gender.Male),
    new Person("Daniel", "R", 18, 55, 174, Gender.Male),
    new Person("Nandito", "Wilson", 20, 56, 160, Gender.Male),
    new Person("Tod", "Vachey", 20, 55, 180, Gender.Male),
    new Person("Anna", "Williams", 24, 77, 164, Gender.Female),
    new Person("Maria", "Ann", 55, 16, 160, Gender.Female),
    new Person("John", "117", 130, 49,218, Gender.Male),
    new Person("Anna", "Rodriguez", 26, 69, 174, Gender.Female)
};
int[] numbers = { 5, 6, 3, 2, 1, 5, 7, 234, 54, 14, 653, 3, 4, 5, 6, 7 };


// ** GROUPING BY **

var simpleGrouping = people.GroupBy(p => p.Gender);

foreach (var item in simpleGrouping)
{
    Console.WriteLine($"Gender: {item.Key}");
    foreach (var p in item)
    {
        Console.WriteLine($" {p.FirstName}");
    }
}


// ** ORDER BY **

Console.WriteLine(new String('-', 40));
var alphabeticalGroup = people.OrderBy(p => p.FirstName).GroupBy(p => p.FirstName[0]);

foreach (var item in alphabeticalGroup)
{
    Console.WriteLine($"{item.Key}");
    foreach (var p in item)
    {
        Console.WriteLine(p.FirstName);
    }
}

// ** MULTIPLE KEY **

Console.WriteLine(new String('-', 40));

var multipleKey = people.GroupBy(p => new { p.Gender, p.Age })
                        .OrderBy(p => p.Count());

foreach (var item in multipleKey)
{
    Console.WriteLine($"Gender: {item.Key.Gender}, Age {item.Key.Age}");
    foreach (var p in item)
    {
        Console.WriteLine($"    {p.FirstName}");
    }
}

// ** GROUP BY CUSTOM kEY **

Console.WriteLine(new String('-', 40));

var evenOrOddNumber = numbers.GroupBy(n => (n % 2 == 0) ? "Even" : "Odd")
                             .OrderBy(n => n.Count());

foreach (var item in evenOrOddNumber)
{
    Console.WriteLine(item.Key);
    foreach (var n in item)
    {
        Console.WriteLine($"    {n}");
    }
}

Console.WriteLine(new String('-', 40));

var ageGroup = people.GroupBy( p => p.Age < 20 ? "Young" : 
                                    p.Age >= 20 && p.Age < 40 ? "Adult" : "Senior");

foreach (var item in ageGroup)
{
    Console.WriteLine(item.Key);
    foreach (var p in item)
    {
        Console.WriteLine($"    {p.FirstName}");
    }
}

Console.WriteLine(new String('-', 40));

var howManyEachGroup = people.GroupBy(p => p.Gender)
                             .Select(g => new
                             {
                                 Gender = g.Key,
                                 Count = g.Count()
                             });

foreach (var p in howManyEachGroup)
{
    Console.WriteLine($"{p.Gender}");
    Console.WriteLine($"  {p.Count}");
}