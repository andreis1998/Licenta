using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Drawing;
using System.Text.RegularExpressions;

namespace WebApplicationCourier.Account
{
    public partial class Setari_cont : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/Dashboard.aspx");
        }

        protected void ChangeEmail_Click(object sender, EventArgs e)
        {
            string oldEmailString = oldEmail.Text.Trim();
            string newEmailString = newEmail.Text.Trim();
            bool exitFunction = false;

            if (oldEmailString.Length == 0)
            {
                oldEmailLbl.Visible = true;
                oldEmailLbl.Text = "Email neintrodus.";
                exitFunction = true;
            }

            if (newEmailString.Length == 0)
            {
                newEmailLbl.Visible = true;
                newEmailLbl.Text = "Email neintrodus.";
                exitFunction = true;
            }

            if (exitFunction) return;
            oldEmailLbl.Visible = false;
            newEmailLbl.Visible = false;
            changeEmail.Visible = false;

            using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
            {
                sqlCon.Open();
                string query = "SELECT COUNT(Email) FROM Client WHERE Email=@email";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@email", oldEmailString);
                int emailFound = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (emailFound == 0)
                {
                    oldEmailLbl.Visible = true;
                    oldEmailLbl.Text = "Email-ul actual este gresit.";
                    return;
                }

                query = "UPDATE Client SET Email=@newEmail WHERE Email=@oldEmail";
                sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@newEmail", newEmailString);
                sqlCmd.Parameters.AddWithValue("@oldEmail", oldEmailString);

                if (sqlCmd.ExecuteNonQuery() == 0)
                {
                    changeEmail.Visible = true;
                    changeEmail.Text = "S-a produs o eroare.";
                    changeEmail.CssClass = "text-danger";
                }
                else
                {
                    changeEmail.Visible = true;
                    changeEmail.Text = "Schimbare efectuata.";
                    changeEmail.ForeColor = ColorTranslator.FromHtml("#99CC00");                
                }
            }
        }

        protected void ChangePhone_Click(object sender, EventArgs e)
        {
            string phoneNumber = newPhone.Text.Trim();

            if (!Regex.IsMatch(phoneNumber, @"[a-zA-Z]"))
            {
                if (phoneNumber.Length != 10)
                {
                    newPhoneLbl.Visible = true;
                    return;
                }
            }
            else
            {
                newPhoneLbl.Visible = true;
                return;
            }
            newPhoneLbl.Visible = false;
            changePhone.Visible = false;

            using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
            {
                sqlCon.Open();
                string query = "UPDATE Client SET NrTelefon=@number WHERE Username=(SELECT Username FROM Client WHERE ID=@Id)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@number", phoneNumber);
                sqlCmd.Parameters.AddWithValue("@Id", SiteMaster.Id);
                if (sqlCmd.ExecuteNonQuery() == 0)
                {
                    changePhone.Visible = true;
                    changePhone.CssClass = "text-danger";
                    changePhone.Text = "S-a produs o eroare.";
                }
                else
                {
                    changePhone.Visible = true;
                    changePhone.Text = "Schimbare efectuata.";
                    changePhone.ForeColor = ColorTranslator.FromHtml("#99CC00");
                }
            }
        }

        protected void ChangePassword_Click(object sender, EventArgs e)
        {
            oldPasswordLbl.Visible = false;
            newPasswordLbl.Visible = false;
            confirmPasswordLbl.Visible = false;
            changePassword.Visible = false;

            if (newPassword.Text.Trim().Length == 0)
            {
                newPasswordLbl.Visible = true;
                return;
            }

            string oldPasswordHash = Register.HashPassword(oldPassword.Text.Trim());
            string newPasswordHash = Register.HashPassword(newPassword.Text.Trim());
            string newPasswordConfirmHash = Register.HashPassword(newPasswordConfirm.Text.Trim());

            using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
            {
                sqlCon.Open();
                string query = "SELECT COUNT(Parola) FROM Client WHERE Parola=@password AND Username=(SELECT Username FROM Client WHERE ID=@Id)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@password", oldPasswordHash);
                sqlCmd.Parameters.AddWithValue("@Id", SiteMaster.Id);
                int passwordFound = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (passwordFound == 0)
                {
                    oldPasswordLbl.Visible = true;
                    return;
                }
                
                if (!string.Equals(newPasswordHash, newPasswordConfirmHash))
                {
                    confirmPasswordLbl.Visible = true;
                    return;
                }
                
                query = "UPDATE Client SET Parola=@newPassword WHERE Parola=@oldPassword AND Username=(SELECT Username FROM Client WHERE ID=@Id)";
                sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@newPassword", newPasswordHash);
                sqlCmd.Parameters.AddWithValue("@oldPassword", oldPasswordHash);
                sqlCmd.Parameters.AddWithValue("@Id", SiteMaster.Id);
                if (sqlCmd.ExecuteNonQuery() == 0)
                {
                    changePassword.Visible = true;
                    changePassword.CssClass = "text-danger";
                    changePassword.Text = "S-a produs o eraore.";
                }
                else
                {
                    changePassword.Visible = true;
                    changePassword.Text = "Schimbare efectuata.";
                    changePassword.ForeColor = ColorTranslator.FromHtml("#99CC00");
                }
            }
        }

        protected void ChangeTipCont_Click(object sender, EventArgs e)
        {
            string tipCont = TipCont.SelectedValue.Trim();
            changeTipCont.Visible = false;

            using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
            {
                sqlCon.Open();
                string query = "UPDATE Client SET ID_Tip_Client=@tipClient WHERE Username=(SELECT Username FROM Client WHERE ID=@Id)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@tipClient", tipCont);
                sqlCmd.Parameters.AddWithValue("@Id", SiteMaster.Id);
                if (sqlCmd.ExecuteNonQuery() == 0)
                {
                    changeTipCont.Visible = true;
                    changeTipCont.CssClass = "text-danger";
                    changeTipCont.Text = "S-a produs o eroare.";
                }
                else
                {
                    changeTipCont.Visible = true;
                    changeTipCont.Text = "Schimbare efectuata.";
                    changeTipCont.ForeColor = ColorTranslator.FromHtml("#99CC00");
                }
            }
        }
    }
}