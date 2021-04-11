using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdessoRideShareAPI.Models
{
    public class TripModel
    {
        public string From { get; set; }
        public string To { get; set; }
        public DateTime Date { get; set; }
        public string Explanation { get; set; }
        public int SeatCount { get; set; }
        public int CreatedBy { get; set; }
    }
}
