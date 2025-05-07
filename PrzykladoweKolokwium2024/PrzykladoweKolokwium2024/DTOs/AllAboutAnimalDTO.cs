namespace PrzykladoweKolokwium2024.DTOs;

public class AllAboutAnimalDTO
{
    public int Animal_Id {get; set;}
    public string Name {get; set;}
    public string Type {get; set;}
    public DateTime AdmissionDate {get; set;}
    public OwnerDTO Owner {get; set;}
    public List<ProcedureDTO> Procedures {get; set;}
}

public class OwnerDTO
{
    public int Owner_Id {get; set;}
    public string FirstName {get; set;}
    public string LastName {get; set;}
}

public class ProcedureDTO
{
    public string Name {get; set;}
    public string Description {get; set;}
    public DateTime Date {get; set;}
}
