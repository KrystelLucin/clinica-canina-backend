using Microsoft.EntityFrameworkCore;
using ClinicaCanina.API.Models;

namespace ClinicaCanina.API.Data
{
    public class ClinicaContext : DbContext
    {
        public ClinicaContext(DbContextOptions<ClinicaContext> options) : base(options) { }
        
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Dueno> Duenos { get; set; }
        public DbSet<Mascota> Mascotas { get; set; }
        public DbSet<Profesional> Profesionales { get; set; }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<DetalleServicio> DetalleServicios { get; set; }
        public DbSet<Especie> Especie { get; set; }
        public DbSet<Servicio> Servicio { get; set; }
        public DbSet<Sexo> Sexo { get; set; }
        public DbSet<Raza> Raza { get; set; }
        public DbSet<TipoMedicamento> TipoMedicamento { get; set; }

    }
}
