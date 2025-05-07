using Microsoft.Data.SqlClient;
using PrzykladoweKolokwium2024.DTOs;

namespace PrzykladoweKolokwium2024.Services;

public class AnimalService: IAnimalService
{
    private readonly IConfiguration _iConfiguration;

    public AnimalService(IConfiguration iConfiguration)
    {
        _iConfiguration = iConfiguration;
    }
    
    public async Task<AllAboutAnimalDTO> GetAllAboutAnimalById(int id)
    {
        var query = @"SELECT a.ID AS Animal_ID ,a.Name, a.Type, a.AdmissionDate, o.ID as Owner_ID, o.FirstName, o.LastName, p.Name, p.Description, pa.Date, p.ID as Procedure_ID
                      FROM Animal a  
                      JOIN Owner o ON o.ID = a.Owner_ID
                      LEFT JOIN Procedure_Animal pa on pa.Animal_ID = a.ID
                      LEFT JOIN [Procedure] p ON p.ID = pa.Procedure_ID
                      WHERE Animal_ID = @ID";      
        
        
        await using SqlConnection connection = new SqlConnection( _iConfiguration.GetConnectionString("DefaultConnection"));
        await using SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = query;
        await connection.OpenAsync();
        
        command.Parameters.AddWithValue("@ID", id);
        
        
        await using SqlDataReader reader = await command.ExecuteReaderAsync();

        AllAboutAnimalDTO animal = null;
        List<ProcedureDTO> procedureList = null;
        
        

        while (await reader.ReadAsync())
        {
            if (animal == null)
            {
                animal = new AllAboutAnimalDTO
                {
                    Animal_Id = (int)reader["Animal_ID"],
                    Name = reader["Name"].ToString(),
                    Type = reader["Type"].ToString(),
                    AdmissionDate = (DateTime)reader["AdmissionDate"],
                    Owner = new OwnerDTO
                    {
                        Owner_Id = (int)reader["Owner_ID"],
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                    },
                    Procedures = new List<ProcedureDTO>()
                    {
                        new ProcedureDTO()
                        {
                            Date = (DateTime)reader["Date"],
                            Name = reader["Name"].ToString(),
                            Description = reader["Description"].ToString(),

                        }
                    }
                    

                };
                
            }
 }
        
        return animal;
    }
}