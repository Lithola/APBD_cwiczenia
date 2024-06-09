using Microsoft.AspNetCore.Mvc;
using cw666.Context;
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

    /*[HttpPost]
    public async Task<IActionResult> CreatePrescription([FromBody] CreatePrescriptionRequest request)
    {
        if (request.Medicaments.Count > 10)
            return BadRequest("A prescription cannot contain more than 10 medicaments.");

        if (request.DueDate < request.Date)
            return BadRequest("DueDate must be greater than or equal to Date.");

        var patient = await _context.Patients.FindAsync(request.PatientId);
        if (patient == null)
        {
            patient = new Patient
            {
                IdPatient = request.PatientId,
                FirstName = request.PatientFirstName,
                LastName = request.PatientLastName,
                Birthdate = request.PatientBirthdate
            };
            _context.Patients.Add(patient);
        }

        var doctor = await _context.Doctors.FindAsync(request.DoctorId);
        if (doctor == null)
            return BadRequest("Doctor does not exist.");

        foreach (var medicament in request.Medicaments)
        {
            if (!await _context.Medicaments.AnyAsync(m => m.IdMedicament == medicament.Id))
                return BadRequest($"Medicament with ID {medicament.IdMedicament} does not exist.");
        }

        var prescription = new Prescription
        {
            Date = request.Date,
            DueDate = request.DueDate,
            Patient = patient,
            IdDoctor = request.DoctorId
        };

        _context.Prescriptions.Add(prescription);
        await _context.SaveChangesAsync();

        foreach (var medicament in request.Medicaments)
        {
            _context.PrescriptionMedicament.Add(new PrescriptionMedicament
            {
                IdPrescription = prescription.IdPrescription,
                IdMedicament = medicament.Id,
                Dose = medicament.Dose,
                Details = medicament.Description
            });
        }

        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPrescriptionById), new { id = prescription.IdPrescription }, prescription);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPrescriptionById(int id)
    {
        var prescription = await _context.Prescriptions
            .Include(p => p.Patient)
            .Include(p => p.Doctor)
            .Include(p => p.PrescriptionMedicaments)
            .ThenInclude(pm => pm.Medicament)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (prescription == null)
            return NotFound();

        return Ok(prescription);
    }

}*/
}