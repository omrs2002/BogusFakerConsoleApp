// See https://aka.ms/new-console-template for more information
using Bogus;
using BogusFakerConsoleApp;
using System.Text.Json;

Console.WriteLine("Hello, World!");

int ids = 0;
Randomizer.Seed = new Random(86753);

Console.WriteLine("{");
while (ids < 100)
{
    ids++;
    var ff = new Faker<InvestorPerson>()
          .RuleFor(o => o.Id, f => ids)
          .RuleFor(o => o.Name, f => f.Name.FullName())
          .RuleFor(o => o.Email, f => f.Person.Email)
          .RuleFor(o => o.Mobile, f => f.Person.Phone)
          .RuleFor(o => o.Website, f => f.Person.Company.Name)
          .RuleFor(o => o.Phone, f => f.Person.Phone);

    var ss = JsonSerializer.Serialize(ff.Generate());

    Console.WriteLine(ss+",");
}
Console.WriteLine("}");
Console.ReadLine();

