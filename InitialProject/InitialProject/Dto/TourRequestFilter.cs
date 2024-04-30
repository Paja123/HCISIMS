using System;
using System.Diagnostics.Metrics;

namespace InitialProject.Dto;

public class TourRequestFilter
{
    public string Country { get; set; }
    public string City { get; set; }
    public string Language { get; set; }
    public int GuestNumber { get; set; }
    public DateTime LowerDateLimit { get; set; }
    public DateTime UpperDateLimit { get;set;}

    public TourRequestFilter(string country, string city, string language, int guestNumber, DateTime lowerDateLimit, DateTime upperDateLimit)
    {
        Country = country;
        City = city;
        Language = language;
        GuestNumber = guestNumber;
        LowerDateLimit = lowerDateLimit;
        UpperDateLimit = upperDateLimit;
    }

    public TourRequestFilter()
    {
        Country = String.Empty;
        City = String.Empty; 
        Language = String.Empty;
        GuestNumber = Int32.MinValue;
        LowerDateLimit = DateTime.MinValue;
        UpperDateLimit = DateTime.MinValue;
    }
}