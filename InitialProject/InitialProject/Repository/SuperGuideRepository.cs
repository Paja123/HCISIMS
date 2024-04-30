using System.Collections.Generic;
using System.Linq;
using InitialProject.Contexts;
using InitialProject.Interface;
using InitialProject.Model;
using Microsoft.EntityFrameworkCore;

namespace InitialProject.Repository;

public class SuperGuideRepository : ISuperGuideRepository
{
    public void Add(SuperGuide superGuide)
    {
        using (var db = new UserContext())
        {

            db.Entry(superGuide).State = EntityState.Added;
            db.SuperGuide.Add(superGuide);
            db.SaveChanges();
        }
    }

    public bool IsActive(User guide, string language)
    {
        using (var db = new UserContext())
        {
            return db.SuperGuide.Any(sg => sg.Guide == guide && sg.Language == language);
        }
    }

    public List<SuperGuide> GetAll(User guide)
    {
        using var db = new UserContext();
        return db.SuperGuide.Where(sg=>sg.Guide.Id==guide.Id).ToList();
    }






}