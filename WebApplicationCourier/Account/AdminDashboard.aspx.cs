using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationCourier.Account
{
    public partial class AdminDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Angajati_Click(object sender, EventArgs e)
        {
            Response.Redirect("Angajati.aspx");
        }

        protected void Clienti_Click(object sender, EventArgs e)
        {
            Response.Redirect("Clienti.aspx");
        }

        protected void Comenzi_Click(object sender, EventArgs e)
        {

        }

        protected void Sedii_Click(object sender, EventArgs e)
        {
            Response.Redirect("Sedii.aspx");
        }

        protected void Masini_Click(object sender, EventArgs e)
        {
            Response.Redirect("Masini.aspx");
        }

        protected void Adrese_Click(object sender, EventArgs e)
        {
            Response.Redirect("Adrese.aspx");
        }
    }
}