
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

//LET KEYWORD

//People that start their name wiht "a"

var peopleWithA = from p in people
                  let firstCharacter = p.FirstName.ToLower()[0]
                  //where p.FirstName.ToLower()[0] == 'a'
                  where firstCharacter == 'a'   //You can use let keyword for create variables in the linq query
                  //select new YoungPerson { FullName = String.Format($"{p.FirstName} {p.LastName}"), Age = p.Age };
                  let fullName = String.Format($"{p.FirstName} {p.LastName}")
                  select new YoungPerson { FullName = fullName, Age = p.Age };

foreach (var p in peopleWithA)
{
    Console.WriteLine($"{p.FullName}");
}

//MULTIPLE FROM

List<List<int>> lists = new List<List<int>>
{
    new List<int>() { 1, 2, 3 },
    new List<int>() { 4, 5, 6 },
    new List<int>() { 7, 8, 9 }
};

//All numbers that contain in the lists
var allNumbers = from l in lists
                 from n in l
                 select n;

Console.WriteLine(string.Join(", ", allNumbers));

//All number multiplied by itself and less than 50

var numbersSquare = from l in lists
                    from n in l
                    let square = n * n
                    where square < 50
                    select square;

Console.WriteLine(string.Join(", ", numbersSquare));
