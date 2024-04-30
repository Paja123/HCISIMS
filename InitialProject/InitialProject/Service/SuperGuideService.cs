using InitialProject.Interface;
using InitialProject.Model;
using System.Collections.Generic;
using System.IO.Enumeration;

namespace InitialProject.Service;

public class SuperGuideService
{
    private readonly ISuperGuideRepository _ISuperGuideRepository;

    public SuperGuideService(ISuperGuideRepository isuperGuideRepository)
    {
        this._ISuperGuideRepository = isuperGuideRepository;
    }


    public void Add(User guide, string language)
    {
        if (!IsActive(guide, language))
        {
            SuperGuide superGuide = new SuperGuide(language, guide);
            _ISuperGuideRepository.Add(superGuide);

        }
    }

    private bool IsActive(User guide, string language)
    {
        return _ISuperGuideRepository.IsActive(guide, language);

    }

    public void AddRange(User guide, List<string> goodLanguages)
    {
        foreach (string language in goodLanguages)
        {
            Add(guide, language);
        }
    }
    //
    // public void Save(SuperGuide superGuide)
    // {
    //     _ISuperGuideRepository.Save(superGuide);
    // }
    //
    // public void UpdateGuide(User guide, string language)
    // {
    //     _ISuperGuideRepository.UpdateGuide(guide, language);
    // }
    public List<SuperGuide> GetAll(User guide)
    {
     return   _ISuperGuideRepository.GetAll(guide);
    }
}