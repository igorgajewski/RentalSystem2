using Microsoft.EntityFrameworkCore;

namespace RentalSystem2.Models;

public partial class RentalSystemContext : DbContext
{
    public RentalSystemContext()
    {
    }

    public RentalSystemContext(DbContextOptions<RentalSystemContext> options)
        : base(options)
    {
    }


    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Equipment> Equipment { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySQL("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("clients");

            entity.HasIndex(e => e.Nip, "nip").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Nip)
                .HasMaxLength(10)
                .HasColumnName("nip");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("employees");

            entity.HasIndex(e => e.SupervisorId, "fk_supervisor");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BirthDate)
                .HasColumnType("date")
                .HasColumnName("birth_date");
            entity.Property(e => e.EmplymentDate)
                .HasColumnType("date")
                .HasColumnName("emplyment_date");
            //entity.Property(e => e.FirstName)
            //    .HasMaxLength(255)
            //    .HasColumnName("first_name");
            entity.Property(e => e.HomeAddress)
                .HasMaxLength(255)
                .HasColumnName("home_address");
            //entity.Property(e => e.LastName)
            //    .HasMaxLength(255)
            //    .HasColumnName("last_name");
            entity.Property(e => e.Name)
            .HasMaxLength(255)
            .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.SupervisorId).HasColumnName("supervisor_id");

            entity.HasOne(d => d.Supervisor).WithMany(p => p.InverseSupervisor)
                .HasForeignKey(d => d.SupervisorId)
                .HasConstraintName("fk_supervisor");
        });

        modelBuilder.Entity<Equipment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("equipment");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActivityType)
                .HasConversion(
                    v => v.ToString(),
                    v => (ActivityType)Enum.Parse(typeof(ActivityType), v))
                .HasColumnName("activity_type");
            entity.Property(e => e.AmateurDiscount)
                .HasPrecision(5)
                .HasColumnName("amateur_discount");
            entity.Property(e => e.DailyRentalRate)
                .HasPrecision(10)
                .HasColumnName("daily_rental_rate");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Manufacturer)
                .HasMaxLength(100)
                .HasColumnName("manufacturer");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Qualifications)
                .HasMaxLength(100)
                .HasColumnName("qualifications");
            entity.Property(e => e.Season)
                .HasConversion(
                    v => v.ToString(),
                    v => (Season)Enum.Parse(typeof(Season), v))
                .HasColumnName("season");
            entity.Property(e => e.SkillLevel)
                .HasConversion(
                    v => v.ToString(),
                    v => (SkillLevel)Enum.Parse(typeof(SkillLevel), v))
                .HasColumnName("skill_level");
        });

        modelBuilder.Entity<Rental>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("rentals");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClientId)
                .HasColumnName("client_id");
            entity.Property(e => e.EmployeeId)
                .HasColumnName("employee_id");
            entity.Property(e => e.EquipmentId)
                .HasColumnName("equipment_id");
            entity.Property(e => e.FinalCost)
                .HasColumnName("final_cost");
            entity.Property(e => e.RentalDate)
                .HasColumnName("rental_date");
            entity.Property(e => e.ReturnDate)
                .HasColumnName("return_date");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public DbSet<Rental> Rental { get; set; } = default!;
}
