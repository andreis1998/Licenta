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
    public partial class Masini : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ConfirmAddMasina.Visible = false;
            ConfirmDeleteMasina.Visible = false;

            if (!this.IsPostBack)
            {
                using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
                {
                    sqlCon.Open();
                    //cauta toate sediile
                    string query = "SELECT * FROM Sediu";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    SqlDataReader reader = sqlCmd.ExecuteReader();
                    ListItemCollection items = new ListItemCollection();
                    items.Add(new ListItem("Selecteaza sediul", "0"));
                    while (reader.Read())
                    {
                        ListItem item = new ListItem(reader.GetString(1), reader.GetInt32(0).ToString());
                        items.Add(item);
                    }

                    Sediu.DataSource = items;
                    Sediu.DataBind();

                    //cauta toate masinile
                    query = "SELECT * FROM Masina WHERE Alocat='0'";
                    sqlCmd = new SqlCommand(query, sqlCon);
                    reader.Close();
                    reader = sqlCmd.ExecuteReader();
                    items.Clear();
                    items.Add(new ListItem("Selecteaza masina", "0"));
                    while (reader.Read())
                    {
                        ListItem item = new ListItem(reader.GetString(1) + " " + reader.GetString(2), reader.GetInt32(0).ToString());
                        items.Add(item);
                    }

                    Masina.DataSource = items;
                    Masina.DataBind();
                }
            }
        }

        protected void Sediu_SelectedIndexChanged(object sender, EventArgs e)
        {
            string text = Sediu.SelectedItem.Text;
            string value = Sediu.SelectedValue;
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/AdminDashboard.aspx");
        }

        protected void ListCars_Click(object sender, EventArgs e)
        {
            if (MasiniBox.Visible == false)
            {
                MasiniBox.Visible = true;
            }
            else
            {
                MasiniBox.Visible = false;
                return;
            }

            string orderBy = "";
            switch (int.Parse(ModVizualizare.SelectedValue))
            {
                case 1:
                    orderBy = " ORDER BY a.Marca";
                    break;
                case 2:
                    orderBy = " ORDER BY a.Marca DESC";
                    break;
                case 3:
                    orderBy = " ORDER BY a.An";
                    break;
                case 4:
                    orderBy = " ORDER BY a.An DESC";
                    break;
                case 5:
                    orderBy = " ORDER BY a.Nr_Km";
                    break;
                case 6:
                    orderBy = " ORDER BY a.Nr_Km DESC";
                    break;
                case 7:
                    orderBy = " ORDER BY a.Categorie";
                    break;
                case 8:
                    orderBy = " ORDER BY a.ID_Sediu";
                    break;
                default:
                    orderBy = "";
                    break;
            }

            using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
            {
                sqlCon.Open();
                string query = "SELECT a.Marca, a.Model, a.An, a.Nr_Km, a.Categorie, a.Alte_Detalii, b.Adresa FROM Masina a " +
                               "INNER JOIN Sediu b ON b.ID_Sediu = a.ID_Sediu" + orderBy;
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                SqlDataReader reader = sqlCmd.ExecuteReader();
                List<string> Results = new List<string>();
                List<string> CarCategories = new List<string>() { "Masina mica", "Masina medie", "Masina mare" };

                while (reader.Read())
                {
                    string result = "Marca: " + reader.GetString(0) + " Model: " + reader.GetString(1) + "\n" +
                        "An: " + reader.GetInt32(2).ToString() + " Numar kilometri: " + reader.GetInt32(3).ToString() + "\n" +
                        "Categorie masina: " + CarCategories[reader.GetInt32(4)-1] + "\n" +
                        "Alte detalii: " + reader.GetString(5) + "\n" + 
                        "Sediul de lucru: " + reader.GetString(6) + "\n-------------------------------------------------------------------------\n";

                    Results.Add(result);
                }

                string FinalResult = "";
                foreach (string s in Results)
                {
                    FinalResult += s;
                }

                MasiniBox.Text = FinalResult;
            }
        }

        protected void AddMasina_Click(object sender, EventArgs e)
        {
            if (Marca.Text.Trim().Length == 0 || Model.Text.Trim().Length == 0 || An.Text.Trim().Length == 0 || NrKm.Text.Trim().Length == 0 || Categorie.SelectedValue == "0")
            {
                return;
            }

            using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
            {
                sqlCon.Open();
                string query = "INSERT INTO Masina VALUES (@marca, @model, @an, @km, @categorie, @altedetalii, @idsediu, 0)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@marca", Marca.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@model", Model.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@an", An.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@km", NrKm.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@categorie", Categorie.SelectedValue);
                sqlCmd.Parameters.AddWithValue("@altedetalii", AlteDetalii.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@idsediu", Sediu.SelectedValue);
                sqlCmd.ExecuteNonQuery();
                ConfirmAddMasina.Visible = true;

                //sterge form-urile
                Marca.Text = "";
                Model.Text = "";
                An.Text = "";
                NrKm.Text = "";
                Categorie.SelectedValue = "0";
                AlteDetalii.Text = "";
                Sediu.SelectedValue = "0";
            }
        }

        protected void DeleteMasina_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
            {
                sqlCon.Open();
                string query = "DELETE FROM Masina WHERE ID_Masina=@id_masina";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@id_masina", Masina.SelectedValue);
                sqlCmd.ExecuteNonQuery();
                ConfirmDeleteMasina.Visible = true;
            }
        }
    }
}