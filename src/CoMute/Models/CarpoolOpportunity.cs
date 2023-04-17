using System;

namespace CoMute.Web.Models
{
    public class CarpoolOpportunity
    {
        public int CarpoolOpportunityID { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string Origin { get; set; }
        public string DaysAvailable { get; set; }
        public string Destination { get; set; }
        public int AvailableSeats { get; set; }
        public int OwnerUserID { get; set; }
        public string Notes { get; set; }
    }

}