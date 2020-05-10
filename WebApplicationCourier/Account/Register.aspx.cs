using System;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using WebApplicationCourier.Models;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;
using System.Text;

namespace WebApplicationCourier.Account
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SiteMaster.loggedIn = false;
        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser() { UserName = Email.Text, Email = Email.Text };
            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {
                // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                //string code = manager.GenerateEmailConfirmationToken(user.Id);
                //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

                signInManager.SignIn( user, isPersistent: false, rememberBrowser: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else 
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }

            using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
            {
                sqlCon.Open();
                string query = "INSERT INTO Client VALUES (@username, @nume, @prenume, @email, @nrtelefon, @sex, @idTipClient, @dataNasterii, @parola)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                string hash = HashPassword(Password.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@parola", hash);
                sqlCmd.Parameters.AddWithValue("@username", Username.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@nume", Nume.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@prenume", Prenume.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@email", Email.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@nrtelefon", NrTel.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@sex", Sex.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@idTipClient", TipCont.SelectedValue.Trim());
                string date = AnulNasterii.Text.Trim() + '-' + LunaNasterii.Text.Trim() + '-' + ZiuaNasterii.Text.Trim();
                sqlCmd.Parameters.AddWithValue("@dataNasterii", date);
                if (IncorrectNumber.Visible == false || IncorrectYear.Visible == false || IncorrectMonth.Visible == false || IncorrectDay.Visible == false)
                {
                    sqlCmd.ExecuteNonQuery();
                    Response.Redirect("Confirm.aspx");
                }              
            }
        }

        internal static string HashPassword(string plainPassword)
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

        protected void NrTel_TextChanged(object sender, EventArgs e)
        {
            string nrTelefon = NrTel.Text.Trim();
            if (nrTelefon.Length > 0)
            {
                if (nrTelefon[0] == '0')
                {
                    if (nrTelefon.Length > 1)
                    {
                        if (nrTelefon[1] == '7')
                        {
                            if (nrTelefon.Length == 10)
                            {
                                IncorrectNumber.Visible = false;
                            }
                            else
                            {
                                IncorrectNumber.Visible = true;
                            }
                        }
                        else
                        {
                            IncorrectNumber.Visible = true;
                        }
                    }
                    else
                    {
                        IncorrectNumber.Visible = true;
                    }
                }
                else
                {
                    IncorrectNumber.Visible = true;
                }
            }
        }

        protected void AnulNasterii_TextChanged(object sender, EventArgs e)
        {
            string anulNasterii = AnulNasterii.Text.Trim();
            int lettersCounter = Regex.Matches(anulNasterii, @"[a-zA-Z]").Count;

            if (lettersCounter == 0)
            {
                if (anulNasterii != "")
                {
                    int anul = int.Parse(anulNasterii);
                    if (anul > 2018 || anul < 1900)
                    {
                        IncorrectYear.Visible = true;
                    }
                    else
                    {
                        IncorrectYear.Visible = false;
                    }
                }
                else
                {
                    IncorrectYear.Visible = true;
                }              
            }
            else
            {
                IncorrectYear.Visible = true;
            }
        }

        protected void LunaNasterii_TextChanged(object sender, EventArgs e)
        {
            string lunaNasterii = LunaNasterii.Text.Trim();
            int lettersCounter = Regex.Matches(lunaNasterii, @"[a-zA-Z]").Count;

            if (lettersCounter == 0)
            {
                if (lunaNasterii != "")
                {
                    int luna = int.Parse(lunaNasterii);
                    if (luna > 12 || luna < 1)
                    {
                        IncorrectMonth.Visible = true;
                    }
                    else
                    {
                        IncorrectMonth.Visible = false;
                    }
                }
                else
                {
                    IncorrectMonth.Visible = true;
                }
            }
            else
            {
                IncorrectMonth.Visible = true;
            }
        }

        protected void ZiuaNasterii_TextChanged(object sender, EventArgs e)
        {
            string ziuaNasterii = ZiuaNasterii.Text.Trim();
            int lettersCounter = Regex.Matches(ziuaNasterii, @"[a-zA-Z]").Count;

            if (lettersCounter == 0)
            {
                if (ziuaNasterii != "")
                {
                    int ziua = int.Parse(ziuaNasterii);
                    if (ziua > 31 || ziua < 1)
                    {
                        IncorrectDay.Visible = true;
                    }
                    else
                    {
                        IncorrectDay.Visible = false;
                    }
                }
                else
                {
                    IncorrectDay.Visible = true;
                }
            }
            else
            {
                IncorrectDay.Visible = true;
            }
        }

        protected void Username_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
            {
                sqlCon.Open();
                string query = "SELECT COUNT (Username) FROM Client WHERE Username=@username";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@username", Username.Text.Trim());
                int userFound = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (userFound == 1)
                {
                    DuplicateUser.Visible = true;
                }
                else
                {
                    DuplicateUser.Visible = false;
                }
            }
        }

        protected void Email_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
            {
                sqlCon.Open();
                string query = "SELECT COUNT (Email) FROM Client WHERE Email=@email";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@email", Email.Text.Trim());
                int userFound = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (userFound == 1)
                {
                    DuplicateEmail.Visible = true;
                }
                else
                {
                    DuplicateEmail.Visible = false;
                }
            }
        }

        string descriereTipCont1 = "Cont basic";
        string descriereTipCont2 = "Cont plus";
        string descriereTipCont3 = "Cont cu beneficii premuim";

        protected void TipCont_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tip = int.Parse(TipCont.SelectedValue.Trim());
            switch (tip)
            {
                case 1: Descriere.Text = descriereTipCont1;
                    break;
                case 2: Descriere.Text = descriereTipCont2;
                    break;
                case 4: Descriere.Text = descriereTipCont3;
                    break;
                default: Descriere.Text = "";
                    break;
            }
        }
    }
}