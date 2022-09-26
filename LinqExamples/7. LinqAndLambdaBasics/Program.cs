using ClassLibrary;

int[] numbers = { 5, 6, 3, 2, 1, 5, 7, 234, 54, 14, 653, 3, 4, 5, 6, 7 };
List<Warrior> warriors = new List<Warrior>()
{
    new Warrior() { Height= 100},
    new Warrior() { Height= 80},
    new Warrior() { Height= 100},
    new Warrior() { Height= 77},
};

// ** LINQ with Method Syntax **

//return the odd numbers

var oddNumbers = numbers.Where(n => n % 2 == 1);

Console.WriteLine(string.Join(", ", oddNumbers));

// return the height of warriors that have equal to 100
Console.WriteLine(new String('-', 40));

var shortWarrior = warriors.Where( wh => wh.Height == 100).Select(w => w.Height);

Console.WriteLine(string.Join(", ", shortWarrior));

// ** Foreach with List **

warriors.ForEach(w => Console.Write(w.Height + " "));
Console.WriteLine();
shortWarrior.ToList().ForEach(w => Console.WriteLine(w));
