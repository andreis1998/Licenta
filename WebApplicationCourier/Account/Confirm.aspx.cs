using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using WebApplicationCourier.Models;

namespace WebApplicationCourier.Account
{
    public partial class Confirm : Page
    {
        protected string StatusMessage
        {
            get;
            private set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            successPanel.Visible = true;
        }
    }
}