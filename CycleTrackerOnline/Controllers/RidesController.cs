using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CycleTrackerOnline.BusinessObjects;
using Microsoft.AspNetCore.Mvc;

namespace CycleTrackerOnline.Controllers
{
    public class RidesController : Controller
    {

        IRideViewModel _viewModel;

        public RidesController(IRideViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public IActionResult Index()
        {
            List<RideMatrixItem> rideMatrix = _viewModel.GetRideMatrix();
            return View(rideMatrix);
        }

        public IActionResult YearRides(int year)
        {
            RideDetails rides = _viewModel.GetRidesForYear(year);

            return View("Rides", rides);
        }

        public IActionResult MonthRides(int year, int month)
        {
            RideDetails rides = _viewModel.GetRidesForMonth(month, year);
            return View("Rides", rides);
        }

        public IActionResult Add()
        {
            return View();
        }
    }
}