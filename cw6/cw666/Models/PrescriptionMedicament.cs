using System.ComponentModel.DataAnnotations.Schema;

namespace cw666.Models;

public class PrescriptionMedicament
{
    public int IdMedicament { get; set; }
    public int IdPrescription { get; set; }
    public int Dose { get; set; }
    
    [Column(TypeName = "nvarchar(100)")]
    public string Details { get; set; } = null!;

    
    // Navigation properties
    public Medicament Medicament { get; set; } = null!;
    public Prescription Prescription { get; set; } = null!;
}