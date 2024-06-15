using System.ComponentModel.DataAnnotations;

namespace cw666.Models;

public class Doctor
{
    [Key] 
    public int IdDoctor { get; set; }
    [MaxLength(100)]
    public String FirstName { get; set; }
    [MaxLength(100)]
    public String LastName { get; set; }
    [MaxLength(100)]
    public String Email { get; set; }
    
    
    public virtual ICollection<Prescription> _Prescriptions { get; set; }
    
    
}