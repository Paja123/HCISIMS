﻿using InitialProject.Contexts;
using InitialProject.Controller;
using InitialProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace InitialProject.View
{
    public partial class Guest1 : Window
    {
        private readonly ReservationReschedulingRequestController ReservationReschedulingRequestController = new();
        private readonly AccommodationReservationController AccommodationReservationController = new();
        private readonly UserController UserController = new();

        private User User { get; set; }

        public Guest1(User user)
        {
            InitializeComponent();
            User = user;

            CheckNotifications();
            CheckSuperTitleRequirements();
        }

        private void CheckNotifications()
        {
            List<ReservationReschedulingRequest> reschedulings = ReservationReschedulingRequestController.GetAllByUser(User.Id);
            bool notify = false;

            foreach(ReservationReschedulingRequest r in reschedulings)
            {
                if (r.WasNotified == false && r.State != Enumeration.RequestState.Waiting)
                {
                    notify = true;
                    ReservationReschedulingRequestController.UpdateWasNotifiedBy(r.Id, true);
                }
            }

            if(notify)
            {
                MessageBox.Show("One of your requests for reservation was answered by the owner");
            }
        }

        private void CheckSuperTitleRequirements()
        {
            if (!User.SuperTitle)
            {
                List<AccommodationReservation> reservations = AccommodationReservationController.GetDuringLastYearBy(User);
                if (reservations.Count > 9)
                {
                    UserController.UpdateBy(User.Id, true, 5);
                    MessageBox.Show("You have become a SUEPER GUEST");
                }

                return;
            }
            
            if (User.SuperTitleValidTill < DateTime.Now)
            {
                List<AccommodationReservation> reservations = AccommodationReservationController.GetDuringLastYearBy(User);

                if (reservations.Count > 9)
                {
                    UserController.UpdateBy(User.Id, true, 5, User.SuperTitleValidTill.AddYears(1));
                    MessageBox.Show("You have become a SUEPER GUEST");
                }
                else
                {
                    UserController.UpdateBy(User.Id, false, 0, User.SuperTitleValidTill.AddYears(1));
                    MessageBox.Show("You are no longer super guest");
                }
            }
        }

        private void AccommodationReservate_Click(object sender, RoutedEventArgs e)
        {

            AccommodationReservate accommodationReservate = new(User);
            accommodationReservate.Show();

            Close();
        }

        private void EditReservation_Click(object sender, RoutedEventArgs e)
        {
            EditReservation editReservation = new(User);
            editReservation.Show();

            Close();
        }

        private void RateAccommodation_Click(object sender, RoutedEventArgs e)
        {
            RateAccommodation rateAccommodation = new(User);
            rateAccommodation.Show();

            Close();
        }

    }
}
