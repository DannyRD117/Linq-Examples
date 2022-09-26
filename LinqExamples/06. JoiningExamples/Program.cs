
using ClassLibrary;

List<Buyer> buyers = new List<Buyer>()
{
    new Buyer() { Name = "Johny", District = "Fantasy District", Age = 22},
    new Buyer() { Name = "Peter", District = "Scientists District", Age = 40},
    new Buyer() { Name = "Paul", District = "Fantasy District", Age = 30},
    new Buyer() { Name = "Maria", District = "Scientists District", Age = 35},
    new Buyer() { Name = "Joshua", District = "EarthIsFlat District", Age = 40},
    new Buyer() { Name = "Sylvia", District = "Developers District", Age = 22},
    new Buyer() { Name = "Rebecca", District = "Scientists District", Age = 30},
    new Buyer() { Name = "Jaime", District = "Developers District", Age = 35},
    new Buyer() { Name = "Pierce", District = "Fantasy District", Age = 40},
};

List<Supplier> suppliers = new List<Supplier>()
{
    new Supplier() { Name = "Harrison", District = "Fantasy District", Age = 22},
    new Supplier() { Name = "Charles", District = "Developers District", Age = 40},
    new Supplier() { Name = "Hailee", District = "Scientists District", Age = 35},
    new Supplier() { Name = "Taylor", District = "EarthIsFlat District", Age = 30},
};

// INNER JOIN

var innerJoin = from s in suppliers
                orderby s.District
                join b in buyers on s.District equals b.District
                select new
                {
                    SupplierName = s.Name,
                    BuyerName = b.Name,
                    s.District
                };


foreach (var item in innerJoin)
{
    Console.WriteLine($"District: {item.District}, Supplier: {item.SupplierName}, Buyer: {item.BuyerName}");
}

// INNER JOIN WITH MULTIPLY KEYS

Console.WriteLine(new String('-', 40));

var compositeJoin = from s in suppliers
                    join b in buyers on new { s.District, s.Age } equals new { b.District, b.Age }
                    select new
                    {
                        Supplier = s,
                        BuyerName = b.Name,
                    };

foreach (var item in compositeJoin)
{
    Console.WriteLine($"District: {item.Supplier.District}, Age: {item.Supplier.Age}");
    Console.WriteLine($"    Supplier: {item.Supplier.Name}");
    Console.WriteLine($"    Buyer: {item.BuyerName}");

}

// Group Joing

Console.WriteLine(new String('-', 40));

var GroupJoin = from s in suppliers
                join b in buyers on s.District equals b.District into buyersGroup
                select new
                {
                    s.Name,
                    s.District,
                    //Buyers = buyersGroup
                    Buyers = from b in buyersGroup
                             orderby b.Age
                             select b
                };

foreach (var supplier in GroupJoin)
{
    Console.WriteLine($"Supplier: {supplier.Name} District: {supplier.District}");
    foreach (var buyer in supplier.Buyers)
    {
        Console.WriteLine($"    {buyer.Name}, {buyer.Age}");
    }
}


// Left outer join (with existing class)

Console.WriteLine(new String('-', 40));

buyers = new List<Buyer>()
{
    new Buyer() { Name = "Johny", District = "Fantasy District", Age = 22},
    new Buyer() { Name = "Peter", District = "Scientists District", Age = 40},
    new Buyer() { Name = "Paul", District = "Fantasy District", Age = 30},
    new Buyer() { Name = "Maria", District = "Scientists District", Age = 35},
    new Buyer() { Name = "Joshua", District = "Developers District", Age = 40},
    new Buyer() { Name = "Sylvia", District = "Developers District", Age = 22},
    new Buyer() { Name = "Rebecca", District = "Scientists District", Age = 30},
    new Buyer() { Name = "Jaime", District = "Developers District", Age = 35},
    new Buyer() { Name = "Pierce", District = "Fantasy District", Age = 40},
};

var leftOuterJoin = from s in suppliers
                    join b in buyers on s.District equals b.District into buyersGroup
                    select new
                    {
                        s.Name,
                        s.District,
                        Buyers = buyersGroup.DefaultIfEmpty(
                        new Buyer
                        {
                            Name = "No one here",
                            District = "I dont exist"

                        })
                    };

foreach (var item in leftOuterJoin)
{
    Console.WriteLine($"{item.District}, {item.Name}");
    foreach (var buyer in item.Buyers)
    {
        Console.WriteLine($"    {buyer.District}    {buyer.Name}");
    }
}

// Left outer join (with no numerable )

Console.WriteLine(new String('-', 40));

var leftOuterJoin2 = from s in suppliers
                    join b in buyers on s.District equals b.District into buyersGroup
                    from bG in buyersGroup.DefaultIfEmpty()
                    select new
                    {
                        s.Name,
                        s.District,
                        BuyersName = bG?.Name ?? "No one here"
                    };

foreach (var item in leftOuterJoin2)
{
    Console.WriteLine($"{item.District}");
    Console.WriteLine($"    {item.Name}, {item.BuyersName}");
}

