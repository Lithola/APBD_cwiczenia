using System.ComponentModel.DataAnnotations;

namespace cw666.Models.DTO;

public class PatientDTO
{
    [Key] 
    public int IdPatient { get; set; }
    [MaxLength(100)]
    public String FirstName { get; set; }
    public String LastName { get; set; }
    public String Birthdate { get; set; }


}