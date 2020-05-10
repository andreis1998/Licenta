using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationCourier
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Setari_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/Setari_cont.aspx");
        }

        protected void VizualizareCont_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/VizualizareCont.aspx");
        }

        protected void Adrese_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdreseClient.aspx");
        }

        protected void CreeazaComanda_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreeazaComanda.aspx");
        }

        protected void ComenziActive_Click(object sender, EventArgs e)
        {
            Response.Redirect("ComenziActive.aspx");
        }
    }
}