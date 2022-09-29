// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

object[] mix = { 1, "string", 'd', new List<int>() { 1, 2, 3, 4 }, new List<int>() { 1, 2, 3, 4 }, "dd", 's', "Hello kitty", 1, 2, 3, 4 };

// OFTYPE

var allIntegers = mix.OfType<int>();

Console.WriteLine(string.Join(", ", allIntegers));

//

Console.WriteLine(new String('-', 40));

List<Person> people = new List<Person>()
{
    new Buyer() { Age = 20},
    new Buyer() { Age = 25},
    new Buyer() { Age = 20},
    new Supplier() { Age = 22},
    new Supplier() { Age = 20}
};

//var suppliers = from p in people
//                where p is Buyer
//                let b = p as Buyer
//                where b.Age == 20
//                select p;

var suppliers = people.OfType<Buyer>().Where(b => b.Age == 20);

foreach (var item in suppliers)
{
    Console.WriteLine(item.GetType().ToString());
    Console.WriteLine(item.Age);
}


//CONVERT ALL

var buyersToSuppliers = people.OfType<Buyer>().ToList().ConvertAll(b => new Supplier { Age = b.Age });

var buyersToSuppliers2 = from p in people
                         where p is Buyer
                         let b = p as Buyer
                         select new Supplier
                         {
                             Age = b.Age
                         };

List<int> numbers = new List<int>{ 5, 6, 3, 2, 1, 5, 7, 234, 54, 14, 653, 3, 4, 5, 6, 7 };

var stringNumbers = numbers.ConvertAll(n => n.ToString());
internal class Person
{
    public int Age { get; set; }
}
internal class Buyer : Person
{
   
}
internal class Supplier : Person
{

}
