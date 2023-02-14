using BestCoffee.Models;

namespace BestCoffee.Options;

public static class CoffeeOption
{
    static List<Coffee> coffees { get; }
    static int nextId = 4;
    static CoffeeOption()
    {
        coffees = new List<Coffee>
        {
            new Coffee { Id = 0, Name = "Juhlamokka", IscaffeineFree = false },
            new Coffee { Id = 1, Name = "Paulig", IscaffeineFree = true },
            new Coffee { Id = 2, Name = "kultakatriina", IscaffeineFree = true }
        };
    }

    public static List<Coffee> GetAll() => coffees;

    public static Coffee? Get(int id) => coffees.FirstOrDefault(p => p.Id == id);

    public static void Add(Coffee coffee)
    {
        coffee.Id = nextId++;
        coffees.Add(coffee);
    }

    public static void Delete(int id)
    {
        var coffee = Get(id);
        if(coffee is null)
            return;

        coffees.Remove(coffee);
    }

    public static void Update(Coffee coffee)
    {
        var index = coffees.FindIndex(p => p.Id == coffee.Id);
        if(index == -1)
            return;

        coffees[index] = coffee;
    }
}