// See https://aka.ms/new-console-template for more information

string sentence = "I love cats";
string[] catNames = { "Milka", "Lucy", "Bella", "Luna", "Oreo", "Silba", "Toby", "Loki", "Oscar" };
int[] numbers = { 5, 6, 3, 2, 1, 5, 6, 7, 12, 245, 2, 435, 6, 67, 23, 12, 1, 14, 1 };


// WHERE

//Numbers that are less than 6
var numbersLess6 =  from number in numbers
                    where number <6
                    select number;

Console.WriteLine(string.Join(", ", numbersLess6));

//Cat names that contain the letter a
var catWithA = from cat in catNames
               where cat.Contains('a')
               select cat;

Console.WriteLine(string.Join(", ", catWithA));

//MULTPLE CONDITION

//Cat names that contain the letter a
var catWithA2 = from cat in catNames
               where cat.Contains('a') && cat.Length == 5
               select cat;

Console.WriteLine(string.Join(", ", catWithA2));

//ORDER BY

//Numbers between 3 and 10 also they are order in ascending
var numbersBetween3and10 = from number in numbers
                           where number > 3 && number < 10
                           orderby  number
                           select number;



