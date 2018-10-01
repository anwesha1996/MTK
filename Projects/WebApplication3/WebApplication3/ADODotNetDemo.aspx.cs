using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class ADODotNetDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = null;
            try
            {
                // Creating Connection  
                con = new SqlConnection("data source=.; database=StudentDB; integrated security=SSPI");
                // Writing insert query  
                string query = "insert into Students(Student_Name,Email,ContactID)values('" + UsernameId.Text + "','" + EmailId.Text + "','" + ContactId.Text + "')";
                SqlCommand sc = new SqlCommand(query, con);
                // Opening connection  
                con.Open();
                // Executing query  
                int status = sc.ExecuteNonQuery();
                Label1.Text = "Your record has been saved with the following details!";
                // ----------------------- Retrieving Data ------------------ //  
                SqlCommand cm = new SqlCommand("select top 1 * from Students", con);
                // Executing the SQL query  
                SqlDataReader sdr = cm.ExecuteReader();
                sdr.Read();
                Label2.Text = "User Name"; Label5.Text = sdr["Student_name"].ToString();
                Label3.Text = "Email ID"; Label6.Text = sdr["email"].ToString();
                Label4.Text = "Contact"; Label7.Text = sdr["ContactID"].ToString();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("OOPs, something went wrong." + ex);
            }
            // Closing the connection  
            finally
            {
                con.Close();
            }
        }
    }
}
