using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cw666.Models;

public class Prescription
{
    [Key] 
    public int IdPrescription { get; set; } 
    public DateTime Date  { get; set; }
    public DateTime DueDate  { get; set; }


    [ForeignKey("Patient")] public Patient Patient { get; set; }
    [ForeignKey("Doctor")] public Doctor Doctor { get; set; }
    
    
    public virtual ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
}