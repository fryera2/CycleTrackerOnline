using System;
using System.Collections.Generic;

namespace CycleTrackerOnline.Models
{
    public partial class Bikes
    {
        public Bikes()
        {
            Rides = new HashSet<Rides>();
        }

        public int BikeId { get; set; }
        public string BikeName { get; set; }

        public ICollection<Rides> Rides { get; set; }
    }
}
