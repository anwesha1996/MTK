using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Web;
using System.Data;
using buisness_layer;

namespace Stud
{
	class Program
	{
		static void Main(string[] args)
		{
			//SqlConnection cn = new SqlConnection(@"Data Source=G1C2ML15824; Initial catalog = anwesha;  Integrated Security=True");
			//cn.Open();
			//SqlCommand cmd2 = new SqlCommand("count_names_with_id", cn);
			//cmd2.CommandType = System.Data.CommandType.StoredProcedure;
			//cmd2.Parameters.Add(new SqlParameter("@name", System.Data.SqlDbType.VarChar));
			//cmd2.Parameters["@name"].Value = "Anwesha";
			//cmd2.Parameters.Add(new SqlParameter("@out", System.Data.SqlDbType.Int));
			//cmd2.Parameters["@out"].Direction = System.Data.ParameterDirection.Output;
			//cn.Open();
			//cmd2.ExecuteNonQuery();
			//cn.Close();



			//SqlCommand cmd = new SqlCommand("Insert into tblStudent Values(1,'Anwesha',22,41),(2,'Payal',23,45),(3,'Sevanand',22,42),(4,'rishabh',21,45),(5,'atul',22,46)", cn);
			//SqlCommand cmd2 = new SqlCommand("Delete from tblStudent where id=1", cn);
			//cmd2.ExecuteNonQuery();
			//SqlCommand cmd3 = new SqlCommand("Insert into tblStudent Values(6,'Anjali',22,41)",cn);
			//cmd3.ExecuteNonQuery();
			//SqlCommand cmd4 = new SqlCommand("Update tblStudent SET Age = 30, ClassTeacherId=30 WHERE id = 3", cn);
			//cmd4.ExecuteNonQuery();
			//SqlCommand cmd1 = new SqlCommand("SELECT * from tblStudent", cn);
			/*(using (SqlDataReader reader = cmd1.ExecuteReader())
			{
				while (reader.Read())
				{
					Console.WriteLine(String.Format("{0} \t | {1} \t | {2} \t | {3}", reader[0], reader[1], reader[2], reader[3]));
				}
			}
			
			SqlCommand cmd5 = new SqlCommand("Select SUM(Age) From tblStudent", cn);
			 Console.WriteLine("sum ={0}",cmd5.ExecuteScalar());
			cn.Close();
			Console.ReadKey();

		}
	}
}*/

			Class1 obj1 = new Class1();
			obj1.getdetails();
			Console.ReadKey();
		}
	}
}

