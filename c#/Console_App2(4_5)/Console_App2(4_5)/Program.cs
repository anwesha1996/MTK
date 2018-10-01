using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Web;
using System.Data;

namespace Console_App2_4_5_
{
	class Program
	{
		static void Main(string[] args)
		{
			SqlConnection cn = new SqlConnection(@"Data Source=G1C2ML15824; Initial catalog = anwesha;  Integrated Security=True");
			cn.Open();
			SqlCommand cmd = new SqlCommand("Insert into Student_table2 Values(7,'John',20,76),(8,'Bill',21,78)", cn);
			cmd.ExecuteNonQuery();
			SqlCommand cmd2 = new SqlCommand("Delete from Student_table2 where id=8 or StudentName='Bill' ", cn);
			cmd2.ExecuteNonQuery();

			SqlCommand cmd1 = new SqlCommand("Select * from Student_table2", cn);
			SqlDataAdapter sd = new SqlDataAdapter(cmd1);

			DataSet ds = new DataSet();
			sd.Fill(ds);
			DataTable dt = ds.Tables[0];
			foreach (DataRow d in dt.Rows)
			{
				Console.WriteLine(String.Format("id {0} StudentName  {1} Age {2} ClassTeacherId {3}", d[0], d[1], d[2], d[3]));
			}
			Console.ReadLine();
		}
	}

}
			
