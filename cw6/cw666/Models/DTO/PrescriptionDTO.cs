namespace cw666.Models.DTO;

public class PrescriptionDTO
{
    public PatientDTO Patient { get; set; }
    public IEnumerable<MedicamentDTO> Medicaments { get; set; } = null!;
    public string Date { get; set; }
    public string DueDate { get; set; }
    
    public int IdDoctor { get; set; }

}