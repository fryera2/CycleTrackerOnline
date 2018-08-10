using CycleTrackerOnline.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CycleTrackerOnline
{
    public interface IRideViewModel
    {
        RideDetails GetRidesForYear(int year);
        RideDetails GetRidesForMonth(int month, int year);
        List<RideMatrixItem> GetRideMatrix();
    }
}
