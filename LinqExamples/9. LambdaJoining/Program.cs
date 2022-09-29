using ClassLibrary;

List<Buyer> buyers = new List<Buyer>()
{
    new Buyer() { Name = "Johny", District = "Fantasy District", Age = 22},
    new Buyer() { Name = "Peter", District = "Scientists District", Age = 40},
    new Buyer() { Name = "Paul", District = "Fantasy District", Age = 30},
    new Buyer() { Name = "Maria", District = "Scientists District", Age = 35},
    new Buyer() { Name = "Joshua", District = "Scientists District", Age = 40},
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

// ** JOING **

var innerJoin = suppliers.Join(buyers, s => s.District, b => b.District,
                              (s, b) => new {
                                  SupplierName = s.Name,
                                  BuyerName = b.Name,
                                  District = b.District
                              });

foreach (var item in innerJoin)
{
    Console.WriteLine($"District: {item.District}, Supplier: {item.SupplierName}, Buyer: {item.BuyerName}");
}

Console.WriteLine(new String('-', 40));

var compositeJoin = suppliers.Join(buyers,
    s => new { s.District, s.Age },
    b => new { b.District, b.Age },
    (s, b) => new
    {
        SupplierName = s.Name,
        BuyerName = b.Name,
        District = s.District,
        Age = s.Age
    });

foreach (var item in compositeJoin)
{
    Console.WriteLine($"District: {item.District}, Age: {item.Age}");
    Console.WriteLine($"    Supplier: {item.SupplierName}");
    Console.WriteLine($"    Buyer: {item.BuyerName}");
}

// ** GROUP JOIN **
Console.WriteLine(new String('-', 40));

var groupJoin = suppliers.GroupJoin(buyers, s => s.District, b => b.District, 
    (s, buyersGroup) => new {
        SuplierName = s.Name,
        District = s.District,
        Buyers = buyersGroup
    });

foreach (var supplier in groupJoin)
{
    Console.WriteLine($"Supplier: {supplier.SuplierName}, District: {supplier.District}");

    foreach (var buyer in supplier.Buyers)
    {
        Console.WriteLine($"    {buyer.Name}");
    }
}

// ** LEFT OUTER JOIN **
Console.WriteLine(new String('-', 40));

var leftOuterJoingAnon = suppliers.GroupJoin(buyers, s => s.District, b => b.District,
    (s, buyersGroup) => new {
        SuplierName = s.Name,
        District = s.District,
        Buyers = buyersGroup
    }).SelectMany(s => s.Buyers.DefaultIfEmpty(),
        (s,b) => new
        {
            s.SuplierName,
            s.District,
            BuyerName = b?.Name ?? "No name",
            BuyersDistict = b?.District ?? "No place"
        });

foreach (var item in leftOuterJoingAnon)
{
    Console.WriteLine($"District: {item.District}");
    Console.WriteLine($"    Suplier: {item.SuplierName} - Buyer: {item.BuyerName}");
}


Console.WriteLine(new String('-', 40));

var leftOuterJoingType = suppliers.GroupJoin(buyers, s => s.District, b => b.District,
    (s, buyersGroup) => new
    {
        SuplierName = s.Name,
        District = s.District,
        Buyers = buyersGroup.DefaultIfEmpty(new Buyer()
        {
            Name = "No one",
            District = "No place"
        })
    });

foreach (var supplier in leftOuterJoingType)
{
    Console.WriteLine($"Supplier: {supplier.SuplierName}, District: {supplier.District}");

    foreach (var buyer in supplier.Buyers)
    {
        Console.WriteLine($"    {buyer.Name}");
    }
}