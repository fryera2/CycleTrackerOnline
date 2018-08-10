using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CycleTrackerOnline.BusinessObjects
{
    public class RideMatrixItem
    {
        public int Year { get; set; }
        public Dictionary<int, string> Months { get; }

        public RideMatrixItem (int year)
        {
            Year = year;
            Months = Enumerable.Range(1, 12).Select(i => new
            {
                k = i,
                v = DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(i)
            }).ToDictionary(key => key.k, value => value.v);
        }
    }
}
