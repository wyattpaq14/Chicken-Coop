using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ChickenCoop.App_Code;

namespace ChickenCoop
{
    public partial class SaltAndHashGenerator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {


            string salt = "salt";
            string pwHash = "hash";

            salt = App_Code.User.CreateSalt();
            pwHash = App_Code.User.CreatePasswordHash(salt, txtPassword.Text);

            txtHash.Text = pwHash;
            txtSalt.Text = salt;
        }
    }
}