using Microsoft.AspNetCore.Mvc;
using cw666.Context;
using cw666.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace cw666.Controllers;
using cw666.Models;

public class Med_Centre_Controller : ControllerBase
{
    private readonly MyDBContext _context;

    public Med_Centre_Controller(MyDBContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PrescriptionDTO prescriptionData)
    {
        Prescription prescription = new();
        bool bShouldCreatePatient = false;
        Patient? patient = await _context.Patients
            .Where(p => p.IdPatient == prescriptionData.Patient.IdPatient).FirstOrDefaultAsync();
        
            if (patient is null)
        {
            DateTime birthDate;
            patient = new Patient
            {
                FirstName = prescriptionData.Patient.FirstName,
                LastName = prescriptionData.Patient.LastName,
                Prescriptions = new List<Prescription>()
            };
           
            if (!DateTime.TryParse(prescriptionData.Patient.Birthdate, out birthDate))
            {
                return BadRequest("Cannot parse Patient.Data!");
            }

            patient.Birthdate = birthDate;
            bShouldCreatePatient = true;
        }
        prescription.Patient = patient;
        
        foreach (MedicamentDTO med in prescriptionData.Medicaments)
        {
            Medicament? newMedicament = _context.Medicaments.FirstOrDefault(m => m.IdMedicament == med.IdMedicament);
            
            if (newMedicament is null)
            {
                return BadRequest($"There is no medicament with id {med.IdMedicament}!");
            }

            PrescriptionMedicament pm = new()
            {
                Medicament = newMedicament,
                Dose = med.Dose,
                Details = newMedicament.Description
            };
            
            prescription.PrescriptionMedicaments.Add(pm);
        }   
            
            
            
        if(prescriptionData.Medicaments.Count()>10)
        {
            return BadRequest("Prescription cannot have over 10 medicaments!");
        }
        
        DateTime date;
        if (!DateTime.TryParse(prescriptionData.Date, out date))
        {
            return BadRequest("Cannot parse Date!");
        }

        prescription.Date = date;

        
            DateTime dueDate;
            if (!DateTime.TryParse(prescriptionData.DueDate, out dueDate))
            {
                return BadRequest("Cannot parse DueDate!");
            }
        prescription.DueDate = dueDate;
        if (prescription.DueDate < prescription.Date)
        {
            return BadRequest("DueDate cannot be earlier than Date!");
        }
        
        Doctor? doctor = await _context.Doctors
            .Where(d => d.IdDoctor == prescriptionData.IdDoctor).FirstOrDefaultAsync();
        if (doctor is null)
        {
            return BadRequest("Doctor ID is not valid!");
        }

        prescription.Doctor = doctor;
        
        await _context.Prescriptions.AddAsync(prescription);
        await _context.SaveChangesAsync();
        return Ok();
    }
}