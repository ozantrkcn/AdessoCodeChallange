using System;
using System.Collections.Generic;
using System.Text;

namespace Adesso.Domain.TripInformation
{
    public class TripInformation
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime Date { get; set; }
        public string Explanation { get; set; }
        public int SeatCount  { get; set; }
        public bool IsPublished { get; set; }
        public int CreatedBy { get; set; }
    }
}
