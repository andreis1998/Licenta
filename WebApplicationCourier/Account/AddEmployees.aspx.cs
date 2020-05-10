using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace WebApplicationCourier.Account
{
    public partial class AddEmployees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
                    query = "SELECT * FROM Masina WHERE Alocat<>1";
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

            Angajati.added = false;
        }

        protected void Username_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
            {
                sqlCon.Open();
                string query = "SELECT COUNT (Username) FROM Angajat WHERE Username=@username";
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
                string query = "SELECT COUNT (Email) FROM Angajat WHERE Email=@email";
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

        protected void Sediu_SelectedIndexChanged(object sender, EventArgs e)
        {
            string text = Sediu.SelectedItem.Text;
            string value = Sediu.SelectedValue;         
        }

        protected void AddEmployee_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["AzureConnection"].ConnectionString))
            {
                sqlCon.Open();
                string query = "INSERT INTO Angajat VALUES (@nume, @prenume, @cnp, @adresa, @sex, @dataNasterii, @email, @nrtelefon, @masina, @sediu, @username, @parola)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                string hash = Register.HashPassword(Password.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@parola", hash);
                sqlCmd.Parameters.AddWithValue("@username", Username.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@nume", Nume.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@prenume", Prenume.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@email", Email.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@nrtelefon", NrTel.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@sex", Sex.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@sediu", Sediu.SelectedValue.Trim());
                sqlCmd.Parameters.AddWithValue("@masina", Masina.SelectedValue.Trim());
                sqlCmd.Parameters.AddWithValue("@cnp", CNP.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@adresa", Adresa.Text.Trim());
                string date = AnulNasterii.Text.Trim() + '-' + LunaNasterii.Text.Trim() + '-' + ZiuaNasterii.Text.Trim();
                sqlCmd.Parameters.AddWithValue("@dataNasterii", date);

                string query2 = "UPDATE Masina SET Alocat='1' WHERE ID_Masina=@id";
                SqlCommand sqlCmd2 = new SqlCommand(query2, sqlCon);
                sqlCmd2.Parameters.AddWithValue("@id", Masina.SelectedValue.Trim());
                if (IncorrectNumber.Visible == false || IncorrectYear.Visible == false || IncorrectMonth.Visible == false || IncorrectDay.Visible == false)
                {
                    sqlCmd.ExecuteNonQuery();
                    sqlCmd2.ExecuteNonQuery();
                    Angajati.added = true;
                    Response.Redirect("~/Account/Angajati.aspx");
                }
            }
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/Angajati.aspx");
        }
    }
}