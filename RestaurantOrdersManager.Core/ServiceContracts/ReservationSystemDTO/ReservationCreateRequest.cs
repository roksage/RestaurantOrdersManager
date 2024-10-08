﻿using RestaurantOrdersManager.Core.Entities.ReservationSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrdersManager.Core.ServiceContracts.ReservationSystemDTO
{
    public class ReservationCreateRequest
    {
        [Required]
        public string ReservationInfo { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }

        [Required]
        public int PeopleCount { get; set; }
        [Required]
        [EmailAddress]
        public string Email {  get; set; }
        public Reservation ToReservation()
        {
            return new Reservation()
            {
                ReservationInfo = ReservationInfo,
                StartTime = StartTime,
                EndTime = EndTime,
                PeopleCount = PeopleCount,
                Email = Email
            };
        }
    }
}
