using Masala1.Context;
using Masala1.Entities;

KarraDbContext context = new KarraDbContext();

int number = int.Parse(Console.ReadLine()!);

var jadval = context.Karra.Where(k=>k.Son == number).ToList();

if (jadval.Count != 0)
{
    foreach (var result in jadval)
    {
        Console.WriteLine(result.Natija);
    }
}
else
{
    for (int i = 1; i < 10; i++)
    {
        var karra = new Karra()
        {
            Natija = $"{i}*{number} = {i * number}",
            Son = number
        };

        Console.WriteLine($"{i}*{number} = {i * number}");

        context.Karra.Add(karra);
        context.SaveChanges();
    }
}