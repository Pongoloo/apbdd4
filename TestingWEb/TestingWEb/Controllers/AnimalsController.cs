using Microsoft.AspNetCore.Mvc;
using TestingWEb.Enums;
using TestingWEb.Models;

namespace TestingWEb.Controllers;
[ApiController]
[Route("/animals")]
public class AnimalsController:ControllerBase
{
    private static readonly List<Animal> _animals = new List<Animal>()
    {
        new Animal(1, "woofwoof", AnimalType.Dog
            , 20.0, HairColor.Black),
        new Animal(2, "meowmeow", AnimalType.Cat
            , 10.0, HairColor.White),
        new Animal(3, "Mooooo", AnimalType.Cow
            , 50.0, HairColor.Magenta),
        new Animal(4, "CowHasHairBtw", AnimalType.Horse
            , 60.0, HairColor.Purple),
        new Animal(5, "GoSpeed", AnimalType.Squirrel
            , 5.0, HairColor.Brown)
    };
    [HttpGet]
    public IActionResult GetAnimals()
    {
        return Ok(_animals);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetAnimal(int id)
    {
        var firstOrDefault = _animals.FirstOrDefault(animal => animal.Id == id);
        if (firstOrDefault == null)
        {
            return NotFound($"Animal with id={id} was not found");
        }
        return Ok(firstOrDefault);
    }

    [HttpPost]
    public IActionResult AddAnimal(Animal animal)
    {
        _animals.Add(animal);
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPut("{id:int}")]
    public IActionResult EditAnimal(int id,Animal animal)
    {
        var animalToRemove = _animals.FirstOrDefault(animal => animal.Id==id);

        _animals.RemoveAt(id);
        _animals.Add(animal);
        return Ok(animal);

    }
    [HttpDelete("{id:int}")]
    public IActionResult DeleteAnimal(int id)
    {
        

        var firstOrDefault = _animals.FirstOrDefault(animal => animal.Id==id);

        if (firstOrDefault == null)
        {
            return NotFound($"animal with id={id} was not found");
        }
        _animals.Remove(firstOrDefault);
        return NoContent();
    }
}