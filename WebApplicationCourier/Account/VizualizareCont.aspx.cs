using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplicationCourier.Account
{
    public partial class VizualizareCont : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
            {
                sqlCon.Open();
                string query = "SELECT Username, Nume, Prenume, Email, NrTelefon, DataNasterii, ID_Tip_Client FROM Client WHERE Username=(SELECT Username FROM Client WHERE ID=@Id)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@Id", SiteMaster.Id);
                SqlDataReader reader = sqlCmd.ExecuteReader();
                if (reader.Read())
                {
                    UsernameValue.Text = reader.GetString(0);
                    NumeValue.Text = reader.GetString(1);
                    PrenumeValue.Text = reader.GetString(2);
                    EmailValue.Text = reader.GetString(3);
                    NumarDeTelefonValue.Text = reader.GetString(4);
                    DataNasteriiValue.Text = reader.GetValue(5).ToString().Remove(9);
                    TipContValue.Text = reader.GetValue(6).ToString();
                }
            }
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/Dashboard.aspx");
        }
    }
}