using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ChickenCoop.App_Code
{
    public class Setting
    {


        public Setting()
        {
            DataTable dt = GetDoorStatus();
            if (dt.Rows.Count > 0)
            {
                this.IsOpen = (Boolean)dt.Rows[0]["IsOpen"];
            }
        }

        public int ID { get; private set; }

        public bool IsOpen { get; private set; }

        private DataTable GetDoorStatus()
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQL Server"].ConnectionString);
            SqlCommand cmd = new SqlCommand("door_getIsOpenState", cn);
            cmd.CommandType = CommandType.StoredProcedure;


            DataTable dt = new DataTable();


            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cn.Close();
            }


            return dt;
        }


        public void UpdateDoorStatus(Boolean isOpen)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQL Server"].ConnectionString);
            SqlCommand cmd = new SqlCommand("door_updateIsOpenState", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@IsOpen", SqlDbType.Bit).Value = isOpen;


            // Open the database connection and execute the command
            try
            {
                //opens connection to database, most failures happen here
                //check connection string for proper settings
                cn.Open();

                //data adapter object is trasport link between data source and 
                //execute the non-query stored procedure
                cmd.ExecuteNonQuery();
                //id = Convert.ToInt32(cmd.Parameters["@BattleID"].Value);

            }
            catch (Exception e)
            {
                //just put here to make debugging easier, can look at error directly
            }
            finally
            {
                //must always close connections
                cn.Close();
            }
        }
    }




    
}