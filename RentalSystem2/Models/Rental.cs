using System.ComponentModel.DataAnnotations;

namespace RentalSystem2.Models;

public partial class Rental
{
    public int Id { get; set; }

    [Display(Name = "Client id")]
    public int ClientId { get; set; }

    [Display(Name = "Employee ID")]
    public int EmployeeId { get; set; }

    [Display(Name = "Equipment ID")]
    public int EquipmentId { get; set; }

    [Display(Name = "Final cost")]
    public int FinalCost { get; set; }

    [Display(Name = "Rental date")]
    public DateTime RentalDate { get; set; }

    [Display(Name = "Return date")]
    public DateTime? ReturnDate { get; set; }
}
