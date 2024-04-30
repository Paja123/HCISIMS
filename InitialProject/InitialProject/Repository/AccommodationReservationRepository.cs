﻿using InitialProject.Contexts;
using InitialProject.Interface;
using InitialProject.Model;
using InitialProject.View;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace InitialProject.Repository
{
    public class AccommodationReservationRepository : IAccommodationReservationRepository
    {
        public List<AccommodationReservation> GetAllExpiredBy(int day, int month, int year, User owner)
        {
            List<AccommodationReservation> expiredReservations = new List<AccommodationReservation>();

            using (var dbContext = new UserContext())
            {
                expiredReservations = dbContext.accommodationReservation
                                 .Where(ar => ((ar.EndingDate.Day >= (day - 5)) && (ar.EndingDate.Day <= day))
                                            && (ar.EndingDate.Month == month)
                                            && (ar.EndingDate.Year == year)
                                 )
                                 .Include(r=>r.Accommodation)
                                    .ThenInclude(r=>r.Owner).Where(t => t.Accommodation.Owner.Equals(owner))
                                 .Include(r=>r.Guest)
                                 .ToList();
            }

            return expiredReservations;
        }

        public AccommodationReservation GetBy(int id)
        {

            AccommodationReservation reservation = new AccommodationReservation();

            using (var dbContext = new UserContext())
            {
                reservation = (AccommodationReservation)dbContext.accommodationReservation
                                 .Where(a => a.Id == id).First();
            }
            return reservation;
        }

        // Stajic
        public void Save(AccommodationReservation accommodationReservation)
        {
            using UserContext db = new();

            db.ChangeTracker.TrackGraph(accommodationReservation, node =>
            node.Entry.State = !node.Entry.IsKeySet ? EntityState.Added : EntityState.Unchanged);

            db.SaveChanges();
        }

        public List<AccommodationReservation> GetByAccommodation(int id)
        {
            List<AccommodationReservation> reservations = new();

            using (UserContext db = new())
            {
                reservations = db.accommodationReservation.Where(t => t.Accommodation.Id == id).ToList();
            }

            return reservations;
        }

        public List<AccommodationReservation> GetBy(User user)
        {
            List<AccommodationReservation> reservations = new();

            using (UserContext db = new())
            {
                reservations = db.accommodationReservation.Include(t => t.Accommodation)
                                                          .ThenInclude(l => l.Location)
                                                          .Where(t => t.Guest.Id == user.Id).ToList();
            }

            return reservations;

        }

        public AccommodationReservation GetByIdWithInclude(int id)
        {
            AccommodationReservation reservation = null;

            using(UserContext db = new())
            {
                reservation = db.accommodationReservation.Where(t => t.Id == id)
                                                         .Include(t => t.Accommodation)
                                                         .ThenInclude(l => l.Location)
                                                         .Include(t => t.Guest)
                                                         .First();
            }

            return reservation;
        }

        public void Delete(AccommodationReservation accommodationReservation)
        {
            using var db = new UserContext();

            db.accommodationReservation.Remove(accommodationReservation);
            db.SaveChanges();
        }

        public void LogicalyDelete(AccommodationReservation accommodationReservation)
        {
            using var db = new UserContext();

            AccommodationReservation accommodationToDelete = GetBy(accommodationReservation.Id);

            var entityToUpdate = db.accommodationReservation.Find(accommodationReservation.Id);

            if (entityToUpdate != null)
            {
                entityToUpdate.Cancelled = true;
                db.SaveChanges();
            }
        }

        public List<AccommodationReservation> GetDuringLastYearBy(User user)
        {
            List<AccommodationReservation> reservations = new();

            using (UserContext db = new())
            {
                reservations = db.accommodationReservation.Where(t => t.Guest.Id == user.Id && t.BegginingDate > DateTime.Now.AddYears(-1))
                                                          .ToList();
            }

            return reservations;
        }



        //Aleksandra
        public List<AccommodationReservation> GetAllBetween(DateTime startingDate, DateTime endingDate, User owner) {

            List<AccommodationReservation> accommodationReservations = new List<AccommodationReservation>();

            using (var dbContext = new UserContext())
            {
                accommodationReservations = dbContext.accommodationReservation
                                            .Where(ar => ((startingDate >= ar.BegginingDate && startingDate <= ar.EndingDate) || (endingDate >= ar.BegginingDate && endingDate <= ar.EndingDate)) ||
                                                         (ar.BegginingDate >= startingDate && ar.BegginingDate <= endingDate) || (ar.EndingDate >= startingDate && (ar.EndingDate <= endingDate))
                                                   )
                                           .Include(r => r.Accommodation)
                                                .ThenInclude(r => r.Owner).Where(t => t.Accommodation.Owner.Equals(owner))
                                           .Include(r => r.Guest)
                                           .ToList();
            }
            return accommodationReservations;
        }

        public void UpdateScheduledDatesBy(int id, DateTime newBegginingDate, DateTime newEndingDate) {

            AccommodationReservation accommodationReservation = new();

            var db = new UserContext();
            accommodationReservation = db.accommodationReservation.Find(id);

            accommodationReservation.BegginingDate = newBegginingDate;
            accommodationReservation.EndingDate = newEndingDate;
            db.SaveChanges();
        }

        public List<AccommodationReservation> GetAllCancelled(User owner) {

            List<AccommodationReservation> cancelledReservations = new List<AccommodationReservation>();

            using (var dbContext = new UserContext())
            {
                cancelledReservations = dbContext.accommodationReservation
                                            .Where(ar => ar.Cancelled == true)
                                           .Include(r => r.Accommodation)
                                                .ThenInclude(r => r.Owner).Where(t => t.Accommodation.Owner.Equals(owner))
                                           .Include(r => r.Guest)
                                           .ToList();
            }
            return cancelledReservations;

        }

    }
}
