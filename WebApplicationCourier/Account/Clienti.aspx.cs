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
    public partial class Clienti : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ConfirmDeleteClient.Visible = false;

            if (!this.IsPostBack)
            {
                using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
                {
                    sqlCon.Open();
                    //cauta toate adresele
                    string query = "SELECT * FROM Client";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    SqlDataReader reader = sqlCmd.ExecuteReader();
                    ListItemCollection items = new ListItemCollection();
                    items.Add(new ListItem("Selecteaza client", "0"));
                    while (reader.Read())
                    {
                        ListItem item = new ListItem("Username: " + reader.GetString(1) + ", " + reader.GetString(2) + " " + reader.GetString(3), reader.GetInt32(0).ToString());
                        items.Add(item);
                    }

                    Client.DataSource = items;
                    Client.DataBind();
                }
            }
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/AdminDashboard.aspx");
        }

        protected void ListClienti_Click(object sender, EventArgs e)
        {
            if (ClientiBox.Visible == false)
            {
                ClientiBox.Visible = true;
            }
            else
            {
                ClientiBox.Visible = false;
                return;
            }

            //creeaza ordinea de listare a rezultatelor
            string orderBy = "";
            switch (int.Parse(ModVizualizare.SelectedValue))
            {
                case 1:
                    orderBy = " ORDER BY x.Nume";
                    break;
                case 2:
                    orderBy = " ORDER BY x.Nume DESC";
                    break;
                case 3:
                    orderBy = " ORDER BY x.Prenume";
                    break;
                case 4:
                    orderBy = " ORDER BY x.Prenume DESC";
                    break;
                case 5:
                    orderBy = " ORDER BY x.DataNasterii";
                    break;
                case 6:
                    orderBy = " ORDER BY x.DataNasterii DESC";
                    break;
                case 7:
                    orderBy = " ORDER BY x.Email";
                    break;
                case 8:
                    orderBy = " ORDER BY y.Descriere DESC";
                    break;
                case 9:
                    orderBy = " ORDER BY x.Username";
                    break;
                default:
                    orderBy = "";
                    break;
            }

            using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
            {
                sqlCon.Open();
                string query = "SELECT x.Nume, x.Prenume, x.DataNasterii, x.Email, x.Username, y.Descriere, x.Sex, x.NrTelefon FROM Client x " +
                                 "INNER JOIN Tip_Client y ON y.ID_Tip_Client = x.ID_Tip_Client" + orderBy;
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                SqlDataReader reader = sqlCmd.ExecuteReader();
                List<string> Results = new List<string>();              

                while (reader.Read())
                {
                    string sex = (reader.GetString(6) == "M") ? "Masculin" : "Feminin";
                    string result = "Username: " + reader.GetString(4) + "\n" + "Nume: " + reader.GetString(0) + " " + reader.GetString(1) + "\n" + "Email: " + reader.GetString(3) + "\n"
                                + "Numar de telefon: " + reader.GetString(7) + "\n" + "Data Nasterii: " + reader.GetValue(2).ToString().Remove(9) + "\n"
                                + "Sex: " + sex + " Tip client: " + reader.GetString(5) + "\n-------------------------------------------------------------------------\n";
                    Results.Add(result);
                }

                string FinalResult = "";
                foreach (string s in Results)
                {
                    FinalResult += s;
                }

                ClientiBox.Text = FinalResult;
            }
        }

        protected void DeleteClient_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
            {
                sqlCon.Open();
                string query = "DELETE FROM Comanda WHERE ID_Client=@id";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@id", Client.SelectedValue);
                sqlCmd.ExecuteNonQuery();

                query = "DELETE FROM Client WHERE ID=@id";
                sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@id", Client.SelectedValue);
                sqlCmd.ExecuteNonQuery();
                ConfirmDeleteClient.Visible = true;
            }
        }
    }
}