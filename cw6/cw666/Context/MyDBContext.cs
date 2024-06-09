using cw666.Models;
using Microsoft.EntityFrameworkCore;

namespace cw666.Context;

public class MyDBContext: DbContext
{
    public DbSet<Medicament> Medicaments {get; set;}
    public DbSet<Doctor> Doctors {get; set;}
    public DbSet<Patient> Patients {get; set;}
    public DbSet<Prescription>  Prescriptions{get; set;}
    public DbSet<PrescriptionMedicament> PrescriptionMedicaments  {get; set;}
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PrescriptionMedicament>().HasKey(pm=> new {pm.IdMedicament, pm.IdPrescription});
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=localhost;Database=apbd;User Id=sa;Password=*;TrustServerCertificate=True");
    } 
}