using System.ComponentModel.DataAnnotations;

namespace RentalSystem2.Models;

public partial class Client
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Nip { get; set; } = null!;
}
