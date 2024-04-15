namespace TestingWEb.Models;

public class AnimalVisit
{
    public Animal Animal { get; set; }
    public DateTime Time { get; set; }
    public string Reason { get; set; }
    public double Price { get; set; }

    public AnimalVisit(Animal animal, DateTime time, string reason, double price)
    {
        Animal = animal;
        Time = time;
        Reason = reason;
        Price = price;
    }
}