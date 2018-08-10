using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CycleTrackerOnline.BusinessObjects
{
    public class SingleRide
    {
        public DateTime? RideDate { get; set; }
        public decimal? DistanceInMiles { get; set; }
        public decimal? TimeInHours { get; set; }
        public decimal? AverageSpeed { get; set; }
        public int Ascent { get; set; }
        public string Calories { get; set; }
    }
}
