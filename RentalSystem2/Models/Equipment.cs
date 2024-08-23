using System.ComponentModel.DataAnnotations;

namespace RentalSystem2.Models;

public partial class Equipment
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    [Display(Name = "Activity Type")]
    public ActivityType ActivityType { get; set; }

    public string Manufacturer { get; set; } = null!;

    [Display(Name = "Daily Rental Rate")]
    public int DailyRentalRate { get; set; }

    [Display(Name = "Skill Level")]
    public SkillLevel SkillLevel { get; set; }

    [Display(Name = "Amateur Discount")]
    public int? AmateurDiscount { get; set; }

    public string? Description { get; set; }

    public Season? Season { get; set; }

    public Qualifications? Qualifications { get; set; }
    public int Quantity { get; set; }
}
public enum SkillLevel
{
    Amatorski,
    Profesjonalny
}
public enum Season
{
    Wiosna,
    Lato,
    Jesień,
    Zima
}
public enum Qualifications
{
    Niewymagane,
    Patent
}
public enum ActivityType
{
    Górski,
    Wodny,
    Sportowy,
    Outdoor
}