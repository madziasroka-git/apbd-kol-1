using PrzykladoweKolokwium2024.DTOs;

namespace PrzykladoweKolokwium2024.Services;

public interface IAnimalService
{
    public Task<AllAboutAnimalDTO> GetAllAboutAnimalById(int id);
}