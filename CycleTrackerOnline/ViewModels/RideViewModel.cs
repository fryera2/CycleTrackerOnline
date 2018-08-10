using CycleTrackerOnline.BusinessObjects;
using CycleTrackerOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CycleTrackerOnline.ViewModels
{
    public class RideViewModel : IRideViewModel
    {
        private CycleDbContext _context;

        public RideViewModel (CycleDbContext context)
        {
            _context = context;
        }

        public RideDetails GetRidesForMonth(int month, int year)
        {
            RideDetails details = new RideDetails(month, year);
            IEnumerable<SingleRide> rides = from r in _context.Rides
                                            where r.RideDate.Value.Month == month &&
                                                  r.RideDate.Value.Year == year
                                            select new SingleRide
                                            {
                                                RideDate = r.RideDate.Value.ToShortDateString(),
                                                DistanceInMiles = r.DistanceInMiles,
                                                TimeInHours = r.TimeInHours,
                                                AverageSpeed = r.AverageSpeed,
                                                Ascent = r.Ascent,
                                                Calories = r.Calories
                                            };

            details.Rides = rides;

            return details;
        }

        public RideDetails GetRidesForYear(int year)
        {
            RideDetails details = new RideDetails(year);
            IEnumerable<SingleRide> rides = from r in _context.Rides
                                            where r.RideDate.Value.Year == year
                                            select new SingleRide
                                            {
                                                RideDate = r.RideDate.Value.ToShortDateString(),
                                                DistanceInMiles = r.DistanceInMiles,
                                                TimeInHours = r.TimeInHours,
                                                AverageSpeed = r.AverageSpeed,
                                                Ascent = r.Ascent,
                                                Calories = r.Calories
                                            };
            details.Rides = rides;

            return details; ;
        }

        public List<RideMatrixItem> GetRideMatrix()
        {
            List<int> years = _context.RideYears.Select (y => y.YearId).ToList();
            List<RideMatrixItem> rideMatrix = new List<RideMatrixItem>();

            foreach (int year in years)
            {
                rideMatrix.Add(new RideMatrixItem(year));
            }

            return rideMatrix;
        }
    }
}
