using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentalSystem2.Models;

public partial class Client
{
    public int Id { get; set; }

    [Display(Name = "First Name")]
    public string FirstName { get; set; } = null!;

    [Display(Name = "Last Name")]
    public string LastName { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Nip { get; set; } = null!;
}
