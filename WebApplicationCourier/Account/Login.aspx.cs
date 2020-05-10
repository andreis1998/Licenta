using System;
using System.Configuration;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using WebApplicationCourier.Models;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace WebApplicationCourier.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            // Enable this once you have account confirmation enabled for password reset functionality
            //ForgotPasswordHyperLink.NavigateUrl = "Forgot";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }

            lblIncorrect.Visible = false;
            SiteMaster.loggedIn = false;
        }

        protected void LogIn(object sender, EventArgs e)
        {
            /*if (IsValid)
            {
                // Validate the user password
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

                // This doen't count login failures towards account lockout
                // To enable password failures to trigger lockout, change to shouldLockout: true
                var result = signinManager.PasswordSignIn(Email.Text, Password.Text, RememberMe.Checked, shouldLockout: false);

                switch (result)
                {
                    case SignInStatus.Success:
                        IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                        break;
                    case SignInStatus.LockedOut:
                        Response.Redirect("/Account/Lockout");
                        break;
                    case SignInStatus.RequiresVerification:
                        Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}", 
                                                        Request.QueryString["ReturnUrl"],
                                                        RememberMe.Checked),
                                          true);
                        break;
                    case SignInStatus.Failure:
                    default:
                        FailureText.Text = "Invalid login attempt";
                        ErrorMessage.Visible = true;
                        break;
                }
            }
            */
            //using (SqlConnection sqlCon = new SqlConnection(@"SERVER=93.118.47.218;DATABASE=FirmaCurieratBD;UID=andreis1998;PASSWORD=student"))
            using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
            {
                sqlCon.Open();
                string query;
                bool admin = false;
                //stabileste tipul de user (client sau administrator/angajat)
                if (Username.Text.Trim() != "admin" && !Username.Text.Trim().Contains("angajat"))
                {
                    query = "SELECT COUNT(1) FROM Client WHERE Username=@username AND Parola=@password";
                }
                else
                {
                    query = "SELECT COUNT(1) FROM Angajat WHERE Username=@username AND Parola=@password";
                    admin = true;
                }

                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                string hash = Register.HashPassword(Password.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@username", Username.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@password", hash);
                int countIds = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (countIds == 1)
                {
                    Session["username"] = Username.Text.Trim();
                    SiteMaster.loggedIn = true;
                    if (!admin)
                    {
                        query = "SELECT * FROM Client WHERE Username=@username";
                        sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@username", Username.Text.Trim());
                        SqlDataReader reader = sqlCmd.ExecuteReader();
                        if (reader.Read())
                        {
                            SiteMaster.nameUser = reader.GetString(3);
                            SiteMaster.Id = Convert.ToInt32(reader.GetValue(0));
                        }
                        Response.Redirect("Dashboard.aspx");
                    }
                    else
                    {
                        SiteMaster.admin = true;
                        query = "SELECT ID_Angajat, Prenume FROM Angajat WHERE Username=@username";
                        sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@username", Username.Text.Trim());
                        SqlDataReader reader = sqlCmd.ExecuteReader();
                        if (reader.Read())
                        {
                            SiteMaster.nameUser = reader.GetString(1);
                            SiteMaster.Id = Convert.ToInt32(reader.GetValue(0));
                        }
                        if (Username.Text.Trim() == "admin")
                            Response.Redirect("AdminDashboard.aspx");
                        else
                            Response.Redirect("AngajatDashboard.aspx");
                    }
                }
                else
                {
                    lblIncorrect.Visible = true;
                }
            }
        }

        /*
        private static string HashPassword(string plainPassword)
        {
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new StringBuilder(64);
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(plainPassword));

            foreach (byte Byte in crypto)
            {
                hash.Append(Byte.ToString("x2"));
            }

            return hash.ToString();
        }
        */
    }
}