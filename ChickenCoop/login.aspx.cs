using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using ChickenCoop.App_Code;

namespace ChickenCoop
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            User you = new User(txtEmail.Text);
            string hsh = App_Code.User.CreatePasswordHash(you.Salt, txtPwd.Text);

            //check password
            if (hsh == you.HashedPwd)
            {
                you.validLogin = true;
            }



            //check username is valid by checking if exception is thrown

            try
            {
                int emailLength = you.email.Length;
            }
            catch (NullReferenceException)
            {
                you.validLogin = false;
            }


            //use validLogin to create auth ticket

            if (you.validLogin)
            {
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, you.UserId.ToString(), DateTime.Now, DateTime.Now.AddMinutes(480), false, "Admin");


                //encrypt cookies
                string encryptedTicket = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

                //add cookies 
                Response.Cookies.Add(cookie);

                //create session variable
                Session["FullName"] = you.email;

                //final redirect, well redirect to admin pages
                Response.Redirect("~/door.aspx");

            }


        }
    }
}