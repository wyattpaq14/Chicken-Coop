using System;
using System.Collections.Generic;
using System.Web;
using System.Collections;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Security.Cryptography;





namespace ChickenCoop.App_Code
{
    public class User
    {


        #region constructors

        //Default constructor
        public User()
        {
            this.UserSalt = CreateSalt();
        }

        //Overloaded constructor

        public User(string email)
        {
            DataTable dt = GetUser(email);
            if (dt.Rows.Count > 0)
            {
                this.UserId = (int)dt.Rows[0]["UserId"];
                this.UserEmail = dt.Rows[0]["UserEmail"].ToString();
                this.UserSalt = dt.Rows[0]["UserSalt"].ToString();
                this.UserHashedPwd = dt.Rows[0]["UserHashedPwd"].ToString();
            }
        }

        #endregion

        #region methods/functions

        public static string CreateSalt()
        {
            // Generate a cryptographic random number using the cryptographic 
            // service provider
            byte[] saltBytes = new byte[16];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(saltBytes);
            // Return a Base64 string representation of the random number
            return Convert.ToBase64String(saltBytes);
        }


        public static string CreatePasswordHash(string salt, string pwd)
        {
            string saltAndPwd = string.Concat(salt, pwd);
            // Create a new instance of the hash crypto service provider.
            HashAlgorithm hashAlg = new SHA256CryptoServiceProvider();
            // Convert the data to hash to an array of Bytes.
            byte[] bytValue = System.Text.Encoding.UTF8.GetBytes(saltAndPwd);
            // Compute the Hash. This returns an array of Bytes.
            byte[] bytHash = hashAlg.ComputeHash(bytValue);
            // Optionally, represent the hash value as a base64-encoded string, 
            // For example, if you need to display the value or transmit it over a network.
            return Convert.ToBase64String(bytHash);
        }


        public static User Login(string email, string freeTxtPwd)
        {
            User au = new User();
            au.UserId = 0;
            au.FirstName = "new";
            au.LastName = "password";
            au.UserHashedPwd = CreatePasswordHash(au.UserSalt, freeTxtPwd);


            return au;




        }

        private static DataTable GetUser(string email)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQL Server"].ConnectionString);
            SqlCommand cmd = new SqlCommand("user_getbyEmail", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter pEmail = new SqlParameter("@user_email", SqlDbType.VarChar);
            pEmail.Value = email;
            cmd.Parameters.Add(pEmail);


            DataTable dt = new DataTable();


            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            catch (Exception e)
            {
                throw new Exception("Error" + e);
            }
            finally
            {
                cn.Close();
            }


            return dt;
        }



        #endregion

        #region properties

        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserSalt { get; set; }

        public string UserHashedPwd { get; set; }

        public string UserEmail { get; set; }

        public bool validLogin { get; set; }

        #endregion
    }
}