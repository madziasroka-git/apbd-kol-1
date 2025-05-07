using Microsoft.AspNetCore.Mvc;
using PrzykladoweKolokwium2024.DTOs;
using PrzykladoweKolokwium2024.Services;

namespace PrzykladoweKolokwium2024.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AnimalsController: ControllerBase
{
    private readonly IAnimalService _animalService;

    public AnimalsController(IAnimalService animalService)
    {
        _animalService = animalService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AllAboutAnimalDTO>> GetAnimal(int id)
    {
        var result = await _animalService.GetAllAboutAnimalById(id);
        if (result == null)
        {
            return NotFound("Nie znaleziono");
        }
        return Ok(result);
    }
}