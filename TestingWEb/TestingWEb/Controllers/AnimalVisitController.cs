using Microsoft.AspNetCore.Mvc;
using TestingWEb.Enums;
using TestingWEb.Models;

namespace TestingWEb.Controllers;

[ApiController]
[Route("/animalVisits")]
public class AnimalVisitController:ControllerBase
{
    private static readonly List<AnimalVisit> _animalVisits = new List<AnimalVisit>()
    {
        new AnimalVisit(
            new Animal(1, "woofwoof", AnimalType.Dog
                , 20.0, HairColor.Black), DateTime.Today, "headache",100.0),
        new AnimalVisit(
            new Animal(2, "meowmeow", AnimalType.Cat
                , 10.0, HairColor.White), DateTime.Now, "brzusioBoli",200.0),
        new AnimalVisit(
            new Animal(3, "Mooooo", AnimalType.Cow
                , 50.0, HairColor.Magenta), DateTime.MinValue, "Smth",300.0)
    };
    
    [HttpGet("AnimalId:int")]
    public IActionResult GetVisitsOfAnAnimal(int id)
    {
        var animalVisits = _animalVisits.FindAll(AnimalVisit => AnimalVisit.Animal.Id==id);
        if (animalVisits == null)
        {
            return NotFound($"no visits of an animal with id={id}");
        }
        return Ok(animalVisits);
    }

    [HttpPost]
    public IActionResult addVisit(AnimalVisit animalVisit)
    {
        _animalVisits.Add(animalVisit);
        return Created();
    }
}