using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace ChickenCoop
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.IsAuthenticated)
                {
                    lbLoginState.Text = "Logout";

                }
                else if (!Request.IsAuthenticated)
                {

                    lbLoginState.Text = "Login";
                }
            }

            }

        protected void lbLoginState_Click(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated)
            {
                Response.Redirect("~/Login");
            }
            else
            {
                FormsAuthentication.SignOut();
                Response.Redirect("~/Home");
            }
            
        }
    }
}