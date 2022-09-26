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
    new Person("John", "117", 49, 130,218, Gender.Male),
    new Person("Anna", "Rodriguez", 26, 69, 174, Gender.Female)
};

/* GROUP BY*/

// Group by people by gender and order by first name

var genderGrupo = from p in people
                  group p by p.Gender;

foreach (var group in genderGrupo)
{
    Console.WriteLine(group.Key);
    foreach(var person in group)
    {
        Console.WriteLine( $"   {person.FirstName}" );
    }
}

// Group by age that are more than 20

Console.WriteLine(new String('-', 40));

var ageGruop = from p in people
               where p.Age > 20
               group p by p.Age;

foreach (var gruop in ageGruop)
{
    Console.WriteLine( gruop.Key );
    foreach (var person in gruop)
    {
        Console.WriteLine( $"   {person.FirstName} {person.Age}" );
    }
}

// Group by first character of name

Console.WriteLine(new String('-', 40));

var alphebeticalGruop = from p in people
                        orderby p.FirstName
                        group p by p.FirstName[0];

foreach (var key in alphebeticalGruop)
{
    Console.WriteLine(key.Key);
    foreach (var p in key)
    {
        Console.WriteLine($"    {p.FirstName}");
    }
}

// MULTIPLE KEY

// Group by Gender and Age

Console.WriteLine(new string('-', 40));

var multipleKey = from p in people
                  group p by new { p.Gender, p.Age };

foreach (var key in multipleKey)
{
    Console.WriteLine(key.Key);
    foreach (var p in key)
    {
        Console.WriteLine($"    {p.FirstName}");
    }
}


// Group by count of grups using the last exercise

Console.WriteLine(new String('-', 40));

var orderedKeys = from p in multipleKey
                  orderby p.Count()
                  select p;
foreach (var key in orderedKeys)
{
    Console.WriteLine($"Gender: {key.Key.Gender}, Age: {key.Key.Age}");
    foreach (var p in key)
    {
        Console.WriteLine($"    {p.FirstName}");
    }
}

/* INTO KEYWORD */

// Group by age and order by age
Console.WriteLine(new string('-', 40));

var peopleByAge = from p in people
                   group p by p.Age into ageGroup
                   orderby ageGroup.Key
                   select ageGroup;

foreach (var key in peopleByAge)
{
    Console.WriteLine($"Age: {key.Key}");
    foreach (var p in key)
    {
        Console.WriteLine($"    {p.Age}");
    }
}

// Group by Gender and Age and group by the count of the groups using into keyword
Console.WriteLine(new string('-', 40));

var multipleKey2 = from p in people
                  group p by new { p.Gender, p.Age } into multipleKeyGroup
                  orderby multipleKeyGroup.Count()
                  select multipleKeyGroup;

foreach (var key in multipleKey2)
{
    Console.WriteLine($"Gender: {key.Key.Gender}, Age: {key.Key.Age}");
    foreach (var p in key)
    {
        Console.WriteLine($"    {p.FirstName}");
    }
}

// Group by Gender and Age and group by the count of the groups using into keyword
Console.WriteLine(new string('-', 40));

int[] arrayOfNumbers = { 5, 6, 3, 2, 1, 5, 7, 234, 54, 14, 653, 3, 4, 5, 6, 7 };

var evenOrOddNumbers = from n in arrayOfNumbers
                       //let evenOrOdd = (n % 2 == 0)
                       let evenOrOdd = (n % 2 == 0) ? "Even" : "Odd" //Here we change it for a ternari operator to have a better groups's titles
                       group n by evenOrOdd into nums
                       orderby nums.Count()
                       select nums;

foreach (var key in evenOrOddNumbers)
{
    Console.WriteLine($"{key.Key}");
    foreach (var n in key)
    {
        Console.WriteLine($"    {n}");
    }
}

// Group people in three groups: young, adults and seniors
Console.WriteLine(new string('-', 40));

var peopleAgeGroup = from p in people
                     let ageSelection = (p.Age <= 18) ? "Young" :
                                      (p.Age > 18 && p.Age <= 60) ? "Adult" : "Senior"
                     group p by ageSelection;

foreach (var key in peopleAgeGroup)
{
    Console.WriteLine(key.Key);
    foreach (var p in key)
    {
        Console.WriteLine($"    Name: {p.FirstName} Age: {p.Age}");
    }
}

// Count how many people are by gender group
Console.WriteLine(new string('-', 40));

var howManyEachGroup = from p in people
                       group p by p.Gender into g
                       select new { Gender = g.Key, NumOfPeople = g.Count() };

foreach (var g in howManyEachGroup)
{
    Console.WriteLine($"{g.Gender}");
    Console.WriteLine($"    {g.NumOfPeople}");
}
