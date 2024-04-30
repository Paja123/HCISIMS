using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Intrinsics.X86;

namespace InitialProject.Model;

[Table("SuperGuide")]
public class SuperGuide
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Language { get; set; }

    [ForeignKey("guideID")]
    public User Guide { get; set; }
    public bool IsActive { get; set; }
    public int TotalTours { get; set; }
    public double AverageGrade { get; set; }
    public DateTime ExpirationDate { get; set; }

    public SuperGuide() {}

    public SuperGuide(string language, User guide)
    {
        this.Language = language;
        this.Guide = guide;
        this.ExpirationDate = DateTime.Now.AddYears(1);
        this.IsActive = true;
    }

    public SuperGuide(string language, User guide, double avg)
    {
        Language = language;
        Guide = guide;
        AverageGrade = avg;
    }

    public SuperGuide(string language, int counter, double average)
    {
        Language = language;
        TotalTours = counter;
        AverageGrade = average;

    }
}