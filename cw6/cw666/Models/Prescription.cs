using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cw666.Models;

public class Prescription
{
    [Key] 
    public int IdPrescription { get; set; } 
    public DateTime Date  { get; set; }
    public DateTime DueDate  { get; set; }


    [ForeignKey("Patient")] public Patient _Patient { get; set; }
    [ForeignKey("Patient")] public Doctor _Doctor { get; set; }
    
    
    public virtual ICollection<Prescription> _Prescriptions { get; set; }
}