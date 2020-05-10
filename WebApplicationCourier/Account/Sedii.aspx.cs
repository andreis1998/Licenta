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
    public partial class Sedii : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ConfirmAddSediu.Visible = false;
            //ConfirmDeleteSediu.Visible = false;

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

                    //Sediu.DataSource = items;
                    //Sediu.DataBind();
                }
            }
        }

        protected void Sediu_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string text = Sediu.SelectedItem.Text;
            //string value = Sediu.SelectedValue;
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/AdminDashboard.aspx");
        }

        protected void ListSedii_Click(object sender, EventArgs e)
        {
            if (SediiBox.Visible == false)
            {
                SediiBox.Visible = true;
            }
            else
            {
                SediiBox.Visible = false;
                return;
            }

            string orderBy = "";
            switch (int.Parse(ModVizualizare.SelectedValue))
            {
                case 1:
                    orderBy = " ORDER BY a.Adresa";
                    break;
                case 2:
                    orderBy = " ORDER BY a.Adresa DESC";
                    break;
                case 3:
                    orderBy = " ORDER BY b.Nume";
                    break;
                case 4:
                    orderBy = " ORDER BY b.Nume DESC";
                    break;
                default:
                    orderBy = "";
                    break;
            }

            using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
            {
                sqlCon.Open();
                string query = "SELECT a.Adresa, b.Nume, b.Prenume FROM Sediu a " +
                               "INNER JOIN Angajat b ON b.ID_Angajat = a.Manager" + orderBy;
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                SqlDataReader reader = sqlCmd.ExecuteReader();
                List<string> Results = new List<string>();

                while (reader.Read())
                {
                    string result = "Sediul de lucru: " + reader.GetString(0) + "\n"  + "     Manager: " + 
                        reader.GetString(1) + " " + reader.GetString(2) + "\n-------------------------------------------------------------------------\n";

                    Results.Add(result);
                }

                string FinalResult = "";
                foreach (string s in Results)
                {
                    FinalResult += s;
                }

                SediiBox.Text = FinalResult;
            }
        }

        //protected void AddSediu_Click(object sender, EventArgs e)
        //{
        //    if (AdresaSediu.Text.Trim().Length == 0 || ManagerSediu.Text.Trim().Length == 0)
        //    {
        //        return;
        //    }

        //    using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
        //    {
        //        sqlCon.Open();
        //        string query = "INSERT INTO Sediu VALUES (@adresa, (SELECT ID_Angajat FROM Angajat WHERE Nume=@nume AND Prenume=@prenume))";
        //        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
        //        sqlCmd.Parameters.AddWithValue("@adresa", AdresaSediu.Text.Trim());
        //        string[] manager = ManagerSediu.Text.Split(' ');
        //        sqlCmd.Parameters.AddWithValue("@nume", manager[0]);
        //        sqlCmd.Parameters.AddWithValue("@prenume", manager[1]);
        //        sqlCmd.ExecuteNonQuery();
        //        ConfirmAddSediu.Visible = true;

        //        AdresaSediu.Text = "";
        //        ManagerSediu.Text = "";
        //    }
        //}

        //protected void DeleteSediu_Click(object sender, EventArgs e)
        //{
        //    using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
        //    {
        //        sqlCon.Open();
        //        string query = "DELETE FROM Sediu WHERE ID_Sediu=@id_sediu";
        //        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
        //        sqlCmd.Parameters.AddWithValue("@id_sediu", Sediu.SelectedValue);
        //        sqlCmd.ExecuteNonQuery();
        //        ConfirmDeleteSediu.Visible = true;
        //    }
        //}
    }
}