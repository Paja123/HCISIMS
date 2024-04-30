using InitialProject.Model;
using System.Collections.Generic;

namespace InitialProject.Dto;

public class LanguageAndToursDto
{

    public string Language { get; set; }
    public List<Tour> Tours { get; set; }

    public LanguageAndToursDto(string language)
    {
        Language = language;
        Tours = new List<Tour>();
    }
}