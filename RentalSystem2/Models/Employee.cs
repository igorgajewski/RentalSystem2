using System.ComponentModel.DataAnnotations;

namespace RentalSystem2.Models;

public partial class Employee
{
    public int Id { get; set; }

    //[Display(Name = "First Name")]
    //public string FirstName { get; set; } = null!;

    //[Display(Name = "Last Name")]
    //public string LastName { get; set; } = null!;
    public string Name { get; set; } = null;

    public string Phone { get; set; } = null!;

    [Display(Name = "Employment Date")]
    public DateTime EmplymentDate { get; set; }

    [Display(Name = "Home Address")]
    public string HomeAddress { get; set; } = null!;

    [Display(Name = "Birth Date")]
    public DateTime BirthDate { get; set; }

    [Display(Name = "Supervisor ID")]
    public int? SupervisorId { get; set; }

    public virtual ICollection<Employee> InverseSupervisor { get; set; } = new List<Employee>();

    public virtual Employee? Supervisor { get; set; }
}
