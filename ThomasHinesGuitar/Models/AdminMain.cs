using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ThomasHinesGuitar.Models
{
    public class AdminMain
    {
        public int Id { get; set; }

        public string Contact { get; set; }
        public string Location { get; set; }

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=" + Environment.ExpandEnvironmentVariables("%UserProfile%") + @"\Source\Repos\ThomasHinesGuitar\ThomasHinesGuitar\App_Data\aspnet-ThomasHinesGuitar-20180219110451.mdf;Initial Catalog=aspnet-ThomasHinesGuitar-20180219110451;Integrated Security=True");
        SqlCommand cam = new SqlCommand();

        public string InsertContactDetails(AdminMain obj)
        {
            cam.CommandText = "Insert into AdminMains values('" + obj.Contact
                + "','" + obj.Location + "')";
            cam.Connection = conn;
            try
            {
                conn.Open();
                cam.ExecuteNonQuery();
                conn.Close();
                return ("Success");
            }
            catch (Exception es)
            {
                throw es;
            }
        }
        public string PullContactDetails(AdminMain obj)
        {
            cam.CommandText = "SELECT TOP 1  FROM AdminMains Order BY Id DESC";
            return ("something");
        }


    }
}