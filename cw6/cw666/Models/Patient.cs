using System.ComponentModel.DataAnnotations;

namespace cw666.Models;

public class Patient
{
    [Key] 
    public int IdPatient { get; set; }
    [MaxLength(100)]
    public String FirstName { get; set; }
    [MaxLength(100)]
    public String LastName { get; set; }
    public DateTime Birthdate { get; set; }
    
    
    public virtual ICollection<Prescription> Prescriptions { get; set; }
}