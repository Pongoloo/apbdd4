using TestingWEb.Enums;

namespace TestingWEb.Models;

public class Animal
{
    public int Id { get; set; }
    public string Name { get; set; }
    public AnimalType AnimalType { get; set; }
    public double Weight { get; set; }
    public HairColor HairColor { get; set; }

    public Animal(int id, string name, AnimalType animalType, double weight, HairColor hairColor)
    {
        Id = id;
        Name = name;
        AnimalType = animalType;
        Weight = weight;
        HairColor = hairColor;
    }

    public override string ToString()
    {
        return "Id:" + Id + ", name:" + Name + ", AnimalType:" + AnimalType + ", Weight:"
               + Weight + ", HairColor:" + HairColor;
    }
}