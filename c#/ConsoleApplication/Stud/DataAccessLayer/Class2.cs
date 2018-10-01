using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Web;
using System.Data;


namespace DataAccessLayer
{
    public class Class2
    {
		public int getDetails()
		{
			int status = 0;
			SqlConnection cn = new SqlConnection(@"Data Source=G1C2ML15824; Initial catalog = anwesha;  Integrated Security=True");
			cn.Open();
			SqlCommand cmd1 = new SqlCommand("SELECT StudentName from tblStudent ", cn);

			SqlDataReader da = cmd1.ExecuteReader();
			if (da.HasRows)
			{
				while (da.Read())
				{
					Console.WriteLine("Name ="+ da.GetSqlString(0));

					status = 1;
				}

			}
			
			return status;
			
		}


			
		
		}
	}

