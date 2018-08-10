using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CycleTrackerOnline.BusinessObjects
{
    public class RideDetails
    {
        private int _rideYear { get; set; }
        private int _rideMonth { get; set; }
        private bool _hasMonthAndYear { get; set; }
        public IEnumerable<SingleRide> Rides { get; set; }

        public int RideCount
        {
            get
            {
                return Rides.Count();
            }
        }

        public decimal? RideTotalDistance
        {
            get
            {
                return Rides.Sum(r => r.DistanceInMiles);
            }
        }

        public decimal? RideTotalTime
        {
            get
            {
                return Rides.Sum(r => r.TimeInHours);
            }
        }

        public decimal? RideTotalAverageSpeed
        {
            get
            {
                return (RideCount > 0) ? Decimal.Round (Convert.ToDecimal (Rides.Sum(r => r.AverageSpeed) / RideCount), 2) : 0;
            }
        }

        public decimal? RideTotalAscent
        {
            get
            {
                return Rides.Sum(r => r.Ascent);
            }
        }

        public RideDetails (int rideMonth, int rideYear)
        {
            _rideYear = rideYear;
            _rideMonth = rideMonth;
            _hasMonthAndYear = true;
        }

        public RideDetails (int rideYear)
        {
            _rideYear = rideYear;
            _hasMonthAndYear = false;
        }

        public override string ToString()
        {
            string formatStr;
            if (_hasMonthAndYear)
            {
                DateTimeFormatInfo formatInfo = new DateTimeFormatInfo();
                formatStr = string.Format("Rides for {0} {1}", formatInfo.GetMonthName(_rideMonth), _rideYear);
            }
            else
            {
                formatStr = string.Format("Rides for {0}", _rideYear);
            }

            return formatStr;
        }
    }
}
