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
    public partial class AngajatDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ComenziBox.Visible == false)
            {
                ComenziBox.Visible = true;
            }
            else
            {
                ComenziBox.Visible = false;
                return;
            }

            List<string> colete = new List<string>();
            using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
            {
                sqlCon.Open();
                string query = "SELECT w.Denumire, w.Pret*w.Cantitate + 20 AS PretFinal FROM Comanda x " +
                    "INNER JOIN Colet w ON w.ID_Comanda = x.ID_Comanda " +
                    "WHERE x.ID_Angajat=@id AND x.Status_Comanda<>@status";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@id", SiteMaster.Id);
                sqlCmd.Parameters.AddWithValue("@status", "Livrat");
                SqlDataReader reader = sqlCmd.ExecuteReader();
                while (reader.Read())
                {
                    string result = reader.GetString(0) + " " + reader.GetValue(1).ToString() + "\n";
                    colete.Add(result);
                }
            }

            using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
            {
                sqlCon.Open();
                string query = "SELECT x.DataComanda, y.Strada, y.Numar, z.Nume, z.Prenume FROM Comanda x " +
                    "INNER JOIN Adresa y ON y.ID_Adresa = x.ID_Adresa " +
                    "INNER JOIN Client z ON z.ID = x.ID_Client " +
                    "WHERE x.ID_Angajat=@id AND x.Status_Comanda<>@status";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@id", SiteMaster.Id);
                sqlCmd.Parameters.AddWithValue("@status", "Livrat");
                SqlDataReader reader = sqlCmd.ExecuteReader();
                List<string> Results = new List<string>();

                while (reader.Read())
                {
                    string result = "Data: " + reader.GetValue(0).ToString().Remove(9) + "\n" +
                        "Strada: " + reader.GetString(1) + " Numarul: " + reader.GetString(2) + "\n" +
                        "Livrare pentru: " + reader.GetString(3) + " " + reader.GetString(4) + "\n" +
                        "Produs(e): ";

                    Results.Add(result);
                }

                string FinalResult = "";
                foreach (string s in Results)
                {
                    FinalResult += s;
                }

                foreach (string s in colete)
                {
                    FinalResult += s;
                }

                FinalResult += "-------------------------------------------------------------------------\n";

                ComenziBox.Text = FinalResult;
            }
        }
    }
}