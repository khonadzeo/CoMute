using CoMute.Web.Models;
using CoMute.Web.Models.Dto;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;

namespace CoMute.Web.Controllers.API
{
    /// <summary>
    /// Managing of CarPool opportunities
    /// </summary>

    public class CarpoolOpportunitiesController : Controller
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["MyDbConnString"].ConnectionString;

        public ActionResult Index()
        {
            var carpoolOpportunities = new List<CarpoolOpportunity>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM CarpoolOpportunities", connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var carpoolOpportunity = new CarpoolOpportunity
                        {
                            CarpoolOpportunityID = (int)reader["CarpoolOpportunityID"],
                            DepartureTime = (DateTime)reader["DepartureTime"],
                            ArrivalTime = (DateTime)reader["ArrivalTime"],
                            Origin = (string)reader["Origin"],
                            Destination = (string)reader["Destination"],
                            AvailableSeats = (int)reader["AvailableSeats"],
                            OwnerUserID = (int)reader["OwnerUserID"],
                            Notes = (string)reader["Notes"]
                        };

                        carpoolOpportunities.Add(carpoolOpportunity);
                    }
                }
            }

            return View(carpoolOpportunities);
        }

        /// <summary>
        /// Registration of new car pool
        /// </summary>
        /// <param name="carpoolOpportunity"></param>
        /// <returns></returns>
        //[HttpPost]
        // [Route("api/carpoolopportunities")]
        public ActionResult CreateCarpoolOpportunity1(CarpoolOpportunity carpoolOpportunity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var command = new SqlCommand(
                    "INSERT INTO CarpoolOpportunities (DepartureTime, ArrivalTime, Origin, DaysAvailable, Destination, AvailableSeats, OwnerUserID, Notes) " +
                    "VALUES (@DepartureTime, @ArrivalTime, @Origin, @DaysAvailable, @Destination, @AvailableSeats, @OwnerUserID, @Notes)",
                    connection);

                command.Parameters.AddWithValue("@DepartureTime", carpoolOpportunity.DepartureTime);
                command.Parameters.AddWithValue("@ArrivalTime", carpoolOpportunity.ArrivalTime);
                command.Parameters.AddWithValue("@Origin", carpoolOpportunity.Origin);
                command.Parameters.AddWithValue("@DaysAvailable", carpoolOpportunity.DaysAvailable);
                command.Parameters.AddWithValue("@Destination", carpoolOpportunity.Destination);
                command.Parameters.AddWithValue("@AvailableSeats", carpoolOpportunity.AvailableSeats);
                command.Parameters.AddWithValue("@OwnerUserID", carpoolOpportunity.OwnerUserID);
                command.Parameters.AddWithValue("@Notes", carpoolOpportunity.Notes);

                command.ExecuteNonQuery();
            }

            return RedirectToAction("Index", "Home");
        }

    }
}



