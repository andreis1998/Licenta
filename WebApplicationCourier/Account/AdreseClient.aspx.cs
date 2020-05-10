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
    public partial class AdreseClient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ConfirmAddAdresa.Visible = false;
            ConfirmDeleteAdresa.Visible = false;
            AdresaDuplicata.Visible = false;

            if (!this.IsPostBack)
            {
                using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
                {
                    sqlCon.Open();
                    //cauta toate adresele
                    string query = "SELECT * FROM Adresa WHERE ID_Adresa IN (SELECT ID_Adresa FROM Client_Adresa WHERE ID_Client=@id)";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@id", SiteMaster.Id);
                    SqlDataReader reader = sqlCmd.ExecuteReader();
                    ListItemCollection items = new ListItemCollection();
                    items.Add(new ListItem("Selecteaza adresa", "0"));
                    while (reader.Read())
                    {
                        ListItem item = new ListItem("Strada " + reader.GetString(1) + ", Numarul " + reader.GetString(2) + ", Bloc " + reader.GetString(3)
                            + ", Scara" + reader.GetString(4) + ", Etaj" + reader.GetInt32(5).ToString() + ", Aparatament " + reader.GetInt32(6).ToString(), reader.GetInt32(0).ToString());
                        items.Add(item);
                    }

                    Adresa.DataSource = items;
                    Adresa.DataBind();

                    query = "SELECT * FROM Adresa WHERE ID_Adresa NOT IN (SELECT ID_Adresa FROM Client_Adresa WHERE ID_Client=@id)";
                    sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@id", SiteMaster.Id);
                    reader.Close();
                    reader = sqlCmd.ExecuteReader();
                    items.Clear();
                    items.Add(new ListItem("Selecteaza adresa", "0"));
                    while (reader.Read())
                    {
                        ListItem item = new ListItem("Strada " + reader.GetString(1) + ", Numarul " + reader.GetString(2) + ", Bloc " + reader.GetString(3)
                            + ", Scara" + reader.GetString(4) + ", Etaj" + reader.GetInt32(5).ToString() + ", Aparatament " + reader.GetInt32(6).ToString(), reader.GetInt32(0).ToString());
                        items.Add(item);
                    }

                    AdresaAdauga.DataSource = items;
                    AdresaAdauga.DataBind();
                }
            }
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/Dashboard.aspx");
        }

        protected void ListAdrese_Click(object sender, EventArgs e)
        {
            if (AdreseBox.Visible == false)
            {
                AdreseBox.Visible = true;
            }
            else
            {
                AdreseBox.Visible = false;
                return;
            }

            string orderBy = "";
            switch (int.Parse(ModVizualizare.SelectedValue))
            {
                case 1:
                    orderBy = " ORDER BY Strada";
                    break;
                case 2:
                    orderBy = " ORDER BY Strada DESC";
                    break;
                default:
                    orderBy = "";
                    break;
            }

            using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
            {
                sqlCon.Open();
                string query = "SELECT * FROM Adresa WHERE ID_Adresa IN (SELECT ID_Adresa FROM Client_Adresa WHERE ID_Client=@id)" + orderBy;
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@id", SiteMaster.Id);
                SqlDataReader reader = sqlCmd.ExecuteReader();
                List<string> Results = new List<string>();

                while (reader.Read())
                {
                    string result = "Strada: " + reader.GetString(1) + " Numarul: " + reader.GetString(2) + "\n" +
                        "Bloc: " + reader.GetString(3) + " Scara: " + reader.GetString(4) + "\n" +
                        "Etaj: " + reader.GetInt32(5).ToString() + " Aparatament: " + reader.GetInt32(6).ToString() + "\n" +
                        "Alte detalii: " + reader.GetString(7) + "\n" +
                       "\n-------------------------------------------------------------------------\n";

                    Results.Add(result);
                }

                string FinalResult = "";
                foreach (string s in Results)
                {
                    FinalResult += s;
                }

                AdreseBox.Text = FinalResult;
            }
        }

        protected void AddAdresa_Click(object sender, EventArgs e)
        {
            if ((Strada.Text.Trim().Length == 0 || Numar.Text.Trim().Length == 0) && AdresaAdauga.SelectedValue == "0")
            {
                return;
            }

            using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
            {
                sqlCon.Open();
                if (AdresaAdauga.SelectedValue == "0")
                {
                    string query = "SELECT Count(ID_Adresa) FROM Adresa WHERE EXISTS (SELECT ID_Adresa FROM Adresa WHERE " +
                        "Strada=@strada AND Numar=@numar AND Bloc=@bloc AND Scara=@scara AND Etaj=@etaj AND Apartament=@apartament)";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@strada", Strada.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@numar", Numar.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@bloc", Bloc.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@scara", Scara.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@etaj", Etaj.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@apartament", Apartament.Text.Trim());
                    int countIds = Convert.ToInt32(sqlCmd.ExecuteScalar());
                    if (countIds == 0)
                    {
                        query = "INSERT INTO Adresa VALUES (@strada, @numar, @bloc, @scara, @etaj, @apartament, @altedetalii)";
                        sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@strada", Strada.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@numar", Numar.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@bloc", Bloc.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@scara", Scara.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@etaj", Etaj.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@apartament", Apartament.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@altedetalii", AlteDetalii.Text.Trim());
                        sqlCmd.ExecuteNonQuery();

                        //adauga in Client_Adresa
                        query = "INSERT INTO Client_Adresa VALUES (@id_client, (SELECT TOP 1 ID_Adresa FROM Adresa ORDER BY ID_Adresa DESC))";
                        sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@id_client", SiteMaster.Id);
                        sqlCmd.ExecuteNonQuery();
                        ConfirmAddAdresa.Visible = true;
                    }
                    else
                    {
                        AdresaDuplicata.Visible = true;
                    }

                    
                }
                else
                {
                    string query = "INSERT INTO Client_Adresa VALUES (@id_client, @id_adresa)";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@id_client", SiteMaster.Id);
                    sqlCmd.Parameters.AddWithValue("@id_adresa", AdresaAdauga.SelectedValue);
                    sqlCmd.ExecuteNonQuery();
                    ConfirmAddAdresa.Visible = true;
                }
                

                Strada.Text = "";
                Numar.Text = "";
                Bloc.Text = "";
                Scara.Text = "";
                Etaj.Text = "";
                Apartament.Text = "";
                AlteDetalii.Text = "";
            }
        }

        protected void DeleteAdresa_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
            {
                sqlCon.Open();
                string query = "DELETE FROM Client_Adresa WHERE ID_Adresa=@id_adresa AND ID_Client=@id_client";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@id_adresa", Adresa.SelectedValue);
                sqlCmd.Parameters.AddWithValue("@id_client", SiteMaster.Id);
                sqlCmd.ExecuteNonQuery();
                ConfirmDeleteAdresa.Visible = true;
            }
        }
    }
}