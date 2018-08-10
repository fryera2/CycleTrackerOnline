using System;
using System.Collections.Generic;

namespace CycleTrackerOnline.Models
{
    public partial class Rides
    {
        public int RideId { get; set; }
        public int? BikeId { get; set; }
        public DateTime? RideDate { get; set; }
        public decimal? TimeInMinutes { get; set; }
        public decimal? TimeInHours { get; set; }
        public decimal? DistanceInMiles { get; set; }
        public decimal? DistanceInKm { get; set; }
        public string Calories { get; set; }
        public decimal? AverageSpeed { get; set; }
        public int Ascent { get; set; }
        public string Comments { get; set; }

        public Bikes Bike { get; set; }
    }
}
