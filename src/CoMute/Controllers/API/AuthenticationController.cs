using CoMute.Web.Models.Dto;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CoMute.Web.Controllers.API
{
  //  using CoMute.Web.Models.Dto;
    using global::CoMute.Web.Models;
    using System.Configuration;
    using System;
    using System.Data.SqlClient;
    using static System.Net.WebRequestMethods;
    using System.Web.Helpers;
    using System.Web.Http.Services;
    using System.Web.Mvc;
    using System.Web.Services.Description;
    using System.Web.UI.WebControls;
    using System.Web;

    namespace CoMute.Web.Controllers
    {
        public class LoginController : Controller
        {
            private readonly string _connectionString = ConfigurationManager.ConnectionStrings["MyDbConnString"].ConnectionString;

            [HttpPost]
            public ActionResult Authenticate(LoginRequest loginRequest)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(_connectionString))
                    {
                        conn.Open();

                        SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Email=@Email AND Password=@Password", conn);
                        cmd.Parameters.AddWithValue("@Email", loginRequest.Email);
                        cmd.Parameters.AddWithValue("@Password", loginRequest.Password);

                        int userCount = (int)cmd.ExecuteScalar();

                        if (userCount == 1)
                        {
                            // Successful login, redirect to dashboard or other authenticated pages
                            return RedirectToAction("Dashboard", "Home");
                        }
                        else
                        {
                            // Invalid credentials, show error message
                            ViewBag.ErrorMessage = "Invalid email or password.";
                            return View("Index");
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log error and show error message
                    ViewBag.ErrorMessage = "An error occurred while processing your request.";
                    return View("Index");
                }
            }
        }
    }

    





}
