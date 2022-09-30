// See https://aka.ms/new-console-template for more information

/* REPEAT METHOD: create a collection that contain repeated value */

var manyA = Enumerable.Repeat("a", 10);

/* RANGE METHOD: create a collection of a range of numbers */

var numbersRange = Enumerable.Range(1, 10);

var alphabetical = Enumerable.Range(0, 'z' - 'a' +1).Select(x => (char)(x + 'a'));

var oddNumbers = Enumerable.Range(1, 10).Select(n => n % 2 ==1);

var evenNumbers = from n in Enumerable.Range(1, 10)
                  where n % 2 == 0
                  select n;

var squared = Enumerable.Range(1, 10).Select(n => n * n);

var squared2 = from n in Enumerable.Range(1, 10)
               select n * n;

Random random = new Random();

var randoms = Enumerable.Range(1, 10).Select(_ => random.Next(1,100));

/* SEQUENCE */

string[] catNames = { "Milka", "Kuro", "Lucy", "Manchas", "Nigga" };
string[] catNames2 = { "Milka", "Kuro", "Lucy", "Manchas", "Nigga" };
string[] catNames3 = { "Milka", "Kuro", "Lucy", "Manchas"};
string[] catNames4 = { "Milka", "Lucy", "Kuro", "Manchas", "Nigga" };

Console.WriteLine(catNames.SequenceEqual(catNames2));
Console.WriteLine(catNames.SequenceEqual(catNames3));
Console.WriteLine(catNames.SequenceEqual(catNames4));

/*  DISTINT
    INTERSECT
    UNION
    EXCEPT*/

string st1 = "I am a cat";
string st2 = "I am a dog";
List<int> ints = new List<int>(){ 1, 2, 2, 2, 3, 3, 4, 5, 6, 5, 6, 5, 6, 5, 4, 3, 5, 6, 7, 8, 8, 4, 3 };
List<int> ints2 = new List<int>() { 3, 2, 3, 5, 8, 43, 5, 67, 1, 2, 3, 7, 7, 7, 6, 5, 2, 1, 1, 1, 1, 1 };

var distinct = st1.Distinct();
var distinct2 = st2.Distinct();

var intDistinct = ints.Distinct();

var intersect = st1.Intersect(st2);

var intIntersect = ints.Intersect(ints2);

var union = st1.Union(st2);

var intUnion = ints.Union(ints2);

var except = st1.Except(st2);

var except2 = st2.Except(st1);

var intExcept = ints.Except(ints2);

var intExcept2 = ints2.Except(ints);

Console.WriteLine("Hola 7u7");

