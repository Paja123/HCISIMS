using System.Collections.Generic;
using InitialProject.Model;
using InitialProject.Repository;
using InitialProject.Service;

namespace InitialProject.Controller;

public class SuperGuideController
{
    private readonly SuperGuideService superGuideService = new SuperGuideService(new SuperGuideRepository());

    public List<SuperGuide> GetAll(User guide)
    {
        return superGuideService.GetAll(guide);
    }
}