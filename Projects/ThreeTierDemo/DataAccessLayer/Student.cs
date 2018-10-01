using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student.Entity;

namespace DataAccessLayer
{
    public class Student
    {
        SqlConnection con = new SqlConnection("data source=.; database=StudentDB; integrated security=SSPI");
        /// <summary>
        /// returns the number of rows affected by inserting student details
        /// </summary>
        /// <param name="stuDetail"></param>
        /// <returns></returns>
        public int InsertDetails(StudentDetails stuDetail)
        {
            int status = 0;
#region Insert Student Details

            try
            {
                // Creating Connection  
                // Writing insert query  
                string query = "insert into Students(Student_Name,Email,ContactID)values('" + stuDetail.StudentName + "','" + stuDetail.EmailId + "','" + stuDetail.ContactID + "')";
                SqlCommand sc = new SqlCommand(query, con);
                // Opening connection  
                con.Open();
                // Executing query  
                status = sc.ExecuteNonQuery();
                
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

            return status;
        }
#endregion
        #region Retrieve Student details 
        public List<string> GetStudentDetail()
        {
            List<string> studentDetails = new List<string>();

            try
            {
                con.Open();
                
                SqlCommand cm = new SqlCommand("select top 1*  from Students", con);
                // Executing the SQL query  
                SqlDataReader sdr = cm.ExecuteReader();
                sdr.Read();
                studentDetails.Add(sdr["Student_name"].ToString());
                studentDetails.Add(sdr["email"].ToString());
                studentDetails.Add(sdr["ContactID"].ToString());
            }

            catch (Exception ex)
            {
                Console.WriteLine("OOPs, something went wrong." + ex);
            }

            finally
            {
                con.Close();
            }
            return studentDetails;
        }

    }
}
#endregion