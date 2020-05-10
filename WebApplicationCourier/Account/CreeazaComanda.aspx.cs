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
    public partial class CreeazaComanda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
                }
            }
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/Dashboard.aspx");
        }

        private static List<string> denumire = new List<string>();
        private static List<decimal> pret = new List<decimal>();
        private static List<decimal> greutate = new List<decimal>();
        private static List<string> dimensiune = new List<string>();
        private static List<int> cantitate = new List<int>();

        protected void AddColet_Click(object sender, EventArgs e)
        {
            denumire.Add(Denumire.Text.Trim());
            pret.Add(decimal.Parse(Pret.Text.Trim()));
            greutate.Add(decimal.Parse(Greutate.Text.Trim()));
            dimensiune.Add(Dimensiuni.Text.Trim());
            cantitate.Add(int.Parse(Cantitate.Text.Trim()));

            Denumire.Text = "";
            Pret.Text = "";
            Greutate.Text = "";
            Dimensiuni.Text = "";
            Cantitate.Text = "";
        }

        protected void AddComanda_Click(object sender, EventArgs e)
        {
            if (Adresa.SelectedValue == "0")
            {
                return;
            }

            using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
            {
                sqlCon.Open();      
                string query = "INSERT INTO Comanda VALUES (@date, @id_client, @id_adresa, @id_angajat, @status, @obs)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@date", DateTime.Now);
                sqlCmd.Parameters.AddWithValue("@id_client", SiteMaster.Id);
                sqlCmd.Parameters.AddWithValue("@id_adresa", Adresa.SelectedValue);
                sqlCmd.Parameters.AddWithValue("@id_angajat", FindAngajat());
                sqlCmd.Parameters.AddWithValue("@status", "New");
                sqlCmd.Parameters.AddWithValue("@obs", AlteDetalii.Text.Trim()); //observatii
                sqlCmd.ExecuteNonQuery();

                for (int i = 0; i < denumire.Count; i++)
                {
                    query = "INSERT INTO Colet VALUES (@denumire, @pret, @greutate, @dimensiune, @cantitate, (SELECT MAX(ID_Comanda) FROM Comanda))";
                    sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@denumire", denumire[i]);
                    sqlCmd.Parameters.AddWithValue("@pret", pret[i]);
                    sqlCmd.Parameters.AddWithValue("@greutate", greutate[i]);
                    sqlCmd.Parameters.AddWithValue("@dimensiune", dimensiune[i]);
                    sqlCmd.Parameters.AddWithValue("@cantitate", cantitate[i]);
                    sqlCmd.ExecuteNonQuery();
                }

                ConfirmComanda.Visible = true;
            }
        }

        private static int FindAngajat()
        {
            decimal greutateTotala = 0;
            for (int i = 0; i < greutate.Count; i++)
            {
                greutateTotala += greutate[i]*cantitate[i];
            }

            int categorie;
            if (greutateTotala < 20)
            {
                categorie = 1;
            }
            else
            {
                if (greutateTotala < 50)
                {
                    categorie = 2;
                }
                else
                {
                    categorie = 3;
                }
            }

            using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
            {
                sqlCon.Open();
                string query = "SELECT x.ID_Angajat FROM Angajat x" +
                    " WHERE x.ID_Masina IN (SELECT ID_Masina FROM Masina WHERE Categorie=@categorie)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@categorie", categorie);
                SqlDataReader reader = sqlCmd.ExecuteReader();
                List<int> angajati = new List<int>();
                while (reader.Read())
                {
                    angajati.Add(reader.GetInt32(0));
                }

                Random rnd = new Random();
                return angajati[rnd.Next(angajati.Count)];
            }
        }
    }
}