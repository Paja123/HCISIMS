﻿using InitialProject.Contexts;
using InitialProject.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using InitialProject.Enumeration;
using Microsoft.EntityFrameworkCore;
using InitialProject.Interface;

namespace InitialProject.Repository
{
    public class TourRepository : ITourRepository
    {
        //public TourRepository() { }


    /*public Location getLocationByTourId(int id)
    {
        Location location = new Location();
        using (var db = new UserContext())
        {
            location = db.tours.Where(a => a.Id == id).Select(a => a.Location).First();
            return location;
        }
    }
    */
    
        public Tour Save(Tour tour)
        {
            using var db = new UserContext();
            db.Add(tour);
            db.SaveChanges();
        
            return db.tour.Find(tour.Id);
            //Try creating method in Accommodation repository to return the same thing
        }

        public List<Tour> GetAll()
        {
            List<Tour> Tours = new List<Tour>();

            using (var dbContext = new UserContext())
            {
                Tours = dbContext.tour.Where(t => t.Location != null && t.Guide != null)
                                        .Include(t => t.Location)
                                        .Include(t => t.Guide)
                                        .ToList();

            }
            return Tours;
        }

        public Tour GetById(int id)
        {
            Tour tour = new Tour();

            using (var dbContext = new UserContext())
            {
                tour = (Tour)dbContext.tour
                                .Include(t => t.Location)
                                .Include(t => t.TourKeyPoints)
                                .Include(t=>t.Guide)
                                .Where(t => t.Id == id)
                                .SingleOrDefault();

            }
            return tour;
        }
        
        public List<Tour> GetByLocation(Location location)
        {
            List<Tour> Tours = new List<Tour>();

            using (var dbContext = new UserContext())
            {
                Tours = dbContext.tour
                                 .Include(t => t.Location)   
                                 .Where(t => t.Location == location)
                                 .ToList();
            }
            return Tours;
        }

        public List<Tour> GetByDuration(TimeSpan duration)
        {
            List<Tour> Tours = new List<Tour>();

            using (var dbContext = new UserContext())
            {
                Tours = dbContext.tour
                                 .Include(t => t.Location)
                                 .Where(t => t.Duration == duration)
                                 .ToList();
            }
            return Tours;
        }

        public List<Tour> GetByLanguage(string language)
        {
            List<Tour> Tours = new List<Tour>();

            using (var dbContext = new UserContext())
            {
                Tours = dbContext.tour
                                 .Include(t => t.Location)
                                 .Where(t => t.Language == language)
                                 .ToList();
            }
            return Tours;
        }

        public List<Tour> GetByGuestLimit(int guestLimit)
        {
            List<Tour> Tours = new List<Tour>();

            using (var dbContext = new UserContext())
            {
                Tours = dbContext.tour
                                 .Include(t => t.Location)
                                 .Where(t => t.GuestLimit == guestLimit)
                                 .ToList();
            }
            return Tours;
        }

        public void SetStatus(int id, TourStatus status)
        {
            using (var dbContext= new UserContext())
            {
                var tour = dbContext.tour.Find(id);
                tour.Status = status;
                dbContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var dbContext = new UserContext())
            {
                Tour tour = dbContext.tour.SingleOrDefault(ttt => ttt.Id == id);

                dbContext.tour.Remove(tour);
                dbContext.SaveChangesAsync();
                //dbContext.SaveChanges();
            }
            
        }

        public List<Tour> GetAllByGuide(int id)
        {
            using (var db = new UserContext())
            {
                return db.tour.Where(t => t.Guide.Id == id).ToList();
            }
        }

        public List<DateTime> GetDatesByGuide(int id)
        {
            using (var dbContext = new UserContext())
            {
                return dbContext.tour.Where(t=>t.Guide.Id == id).Select(t=>t.StartDateAndTime.Date).ToList();
            }
        }

        public void UpdateTour(Tour tour)
        {
            using (var dbContext = new UserContext())
            {
                var tourFromDb = dbContext.tour.Find(tour.Id);
              
                dbContext.Attach(tourFromDb);

                dbContext.Entry(tourFromDb).State = EntityState.Modified;

                tourFromDb.Guide = tour.Guide;
                tourFromDb.Location = tour.Location;
                dbContext.Update(tourFromDb);
                dbContext.SaveChanges();
            }
        }
        public List<Tour> GetLastYearToursByGuide(int id)
        {
            using (var dbContext = new UserContext())
            {
                List<Tour> tours = GetAllByGuide(id);
                List<Tour> lastYearTours = new List<Tour>();
                foreach (Tour tour in tours)
                {
                    if (DateTime.Compare(DateTime.Now, tour.StartDateAndTime.AddYears(1)) < 0)
                    {
                        lastYearTours.Add(tour); ;
                    }
                }

                return lastYearTours;
            }

        }

        public void CancelTours(List<Tour> tours)
        {
            using (var db = new UserContext())
            {
                foreach (Tour tour in tours)
                {
                    Tour tourFromDb = db.tour.Find(tour.Id);
                    tourFromDb.Status = TourStatus.Finished;
                    db.SaveChanges();

                }
            }
        }

    }
}
