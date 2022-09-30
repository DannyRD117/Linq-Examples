// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

int[] ints = new int[] { 1, 2, 2, 2, 3, 3, 4, 5, 6, 5, 6, 5, 6, 3, 2, 5, 5, 6, 7, 8, 8, 4, 3 };

string st1 = "I am a cat";
string st2 = "I a a cat";

/* SKIP AND TAKE METHODS */

int[] ints2 = ints.Skip(10).ToArray();

int[] ints3 = ints.Take(10).ToArray();

int[] ints4 = ints.Skip(4).Take(5).ToArray();

int[] top3 = ints.OrderByDescending(n => n).Take(3).ToArray();

/* SKIPWHILE AND TAKEWHILE METHODS*/

int[] intsSkipWhile = ints.SkipWhile(n => n < 5).ToArray();

int[] intsTakeWhile = ints.TakeWhile(n => n < 3).ToArray();

int[] ints5 = ints.SkipWhile(n => n < 4).TakeWhile(n => n !=2).ToArray();

/* ALL, ANY AND CONTAINS METHODS*/

Console.WriteLine($" All integers are greater than zero: {ints.All(n => n > 0)}");

Console.WriteLine($" All integers are greater than four: {ints.All(n => n > 4)}");

Console.WriteLine($" There is at least one integer is greater than five: {ints.Any(n => n > 5)}");

Console.WriteLine($" All characters are less than 'f': {st1.All(c => c < 'f')}");

Console.WriteLine($" All characters are less than 'f': {st2.Any(c => c < 'f')}");

Console.WriteLine($" There is at least one character is less than 'f': {st1.Any(c => c < 'f')}");

Console.WriteLine($" The colletion have elements: {st1.Any()}");

Console.WriteLine($" The collection contains the character 'c': {st2.Contains('c')}");

Console.WriteLine($" The collection contains the number zero: {ints.Contains(0)}");


/* CONCAT METHOD */

int[] ints6 = new int[] { 1, 2, 2, 2, 3, 3, 4, 5, 6, 5 };
int[] ints7 = new int[] { 1, 2, 2, 2, 2, 2, 2 };

int[] concatenated = ints6.Concat(ints7).ToArray();

int[] concatenated2 = ints.Concat(ints6.Concat(ints7)).ToArray();

int[] intsHalfSquared = ints.Take(ints.Length / 2)
                            .Concat(ints.Skip(ints.Length / 2)
                                .Select(n => n * n))
                            .ToArray();

/* AGGREGATE, SUM, MAX, MIN METHODS*/

int intsSum = ints6.Aggregate( (p, n) => p+n);

int intsSum2 = ints6.Sum();

double intAverage = ints6.Average();

Console.WriteLine($"Max: {ints.Max()}");

Console.WriteLine($"Min: {ints.Min()}");

Console.WriteLine("Nos vemos denuevo 7u7");

