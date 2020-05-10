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
    public partial class Angajati : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (added)
            {
                ConfirmAddEmployee.Visible = true;
                added = false;
            }
            else
            {
                ConfirmAddEmployee.Visible = false;
            }
        }

        internal static bool added = false;

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/AdminDashboard.aspx");
        }

        protected void ListAngajati_Click(object sender, EventArgs e)
        {
            if (AngajatiBox.Visible == false)
            {
                AngajatiBox.Visible = true;
            }
            else
            {
                AngajatiBox.Visible = false;
                return;
            }

            //creeaza ordinea de listare a rezultatelor
            string orderBy = "";
            switch (int.Parse(ModVizualizare.SelectedValue))
            {
                case 1: orderBy = " ORDER BY x.Nume";
                        break;
                case 2: orderBy = " ORDER BY x.Nume DESC";
                        break;
                case 3: orderBy = " ORDER BY x.Prenume";
                        break;
                case 4: orderBy = " ORDER BY x.Prenume DESC";
                        break;
                case 5: orderBy = " ORDER BY x.DataNasterii";
                        break;
                case 6:
                    orderBy = " ORDER BY x.DataNasterii DESC";
                    break;
                case 7:
                    orderBy = " ORDER BY y.Marca";
                    break;
                case 8:
                    orderBy = " ORDER BY y.Marca DESC";
                    break;
                case 9:
                    orderBy = " ORDER BY z.ID_Sediu";
                    break;
                case 10:
                    orderBy = " ORDER BY x.Username";
                    break;
                default:
                    orderBy = "";
                    break;
            }

            using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
            {
                sqlCon.Open();
                string query = "SELECT * FROM Angajat x " +
                                 "INNER JOIN Masina y ON y.ID_Masina = x.ID_Masina " + 
                                 "INNER JOIN Sediu z ON z.ID_Sediu = x.ID_Sediu " +
                                 "INNER JOIN Angajat a ON a.ID_Angajat = z.Manager" + orderBy;
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                SqlDataReader reader = sqlCmd.ExecuteReader();
                List<string> Results = new List<string>();
                List<string> CarCategories = new List<string>() { "Masina mica", "Masina medie", "Masina mare" };

                while (reader.Read())
                {

                    string result = "Username: " + reader.GetString(11) + "\n" + "Nume: " + reader.GetString(1) + " " + reader.GetString(2) + "\n" + "Email: " + reader.GetString(7) + "\n"
                                + "Numar de telefon: " + reader.GetString(8) + "\n" + "Adresa: " + reader.GetString(4) + "\n" + "CNP: " + reader.GetString(3) + "\n"
                                + "Data Nasterii: " + reader.GetValue(6).ToString().Remove(9) + "\n" 
                                + "Masina de lucru: " + reader.GetString(14) + " " + reader.GetString(15) + "\n" 
                                + "         An fabricatie: " + reader.GetInt32(16).ToString() + " Kilometraj: " + reader.GetInt32(17).ToString() + "\n" 
                                + "         Categorie masina: " + CarCategories[reader.GetInt32(18)-1] + "\n"
                                + "         Alte detalii: " + reader.GetString(19) + "\n"
                                + "Sediul de lucru: " + reader.GetString(23) + "\n"
                                + "     Manager: " + reader.GetString(26) + " " + reader.GetString(27) +"\n-------------------------------------------------------------------------\n";
                    Results.Add(result);
                }

                string FinalResult = "";
                foreach (string s in Results)
                {
                    FinalResult += s;
                }

                AngajatiBox.Text = FinalResult;
            }
        }

        protected void AddEmployees_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddEmployees.aspx");
        }
    }
}