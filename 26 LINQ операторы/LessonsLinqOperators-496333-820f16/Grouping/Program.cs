//Group
using Grouping;

List<int> numbers = [35, 44, 200, 84, 3987, 4, 199, 329, 446, 208];



IEnumerable<IGrouping<int, int>> query = (from number in numbers
                                         group number by number % 2);

IEnumerable<IGrouping<int, int>> query2 = numbers
    .GroupBy(number => number % 2).ToList();

foreach (IGrouping<int, int> item in query)
{
    Console.WriteLine(item.Key);
    Console.WriteLine("--------------");
    foreach (int a in item/*IEnumerable<int>*/)
    {
        Console.WriteLine(a);
    }
}

//ToLookup
List<Package> packages = new List<Package> { new Package { Company = "Coho Vineyard", Weight = 25.2, TrackingNumber = 89453312L },
                                                 new Package { Company = "Lucerne Publishing", Weight = 18.7, TrackingNumber = 89112755L },
                                                 new Package { Company = "Wingtip Toys", Weight = 6.0, TrackingNumber = 299456122L },
                                                 new Package { Company = "Contoso Pharmaceuticals", Weight = 9.3, TrackingNumber = 670053128L },
                                                 new Package { Company = "Wide World Importers", Weight = 33.8, TrackingNumber = 4665518773L } }; ;

Lookup<char, string> lookup = (Lookup<char, string>)packages.ToLookup(p => p.Company[0],
                                                    p => p.Company + " " + p.TrackingNumber);
;