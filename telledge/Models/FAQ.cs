using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace telledge.Models
{
	public class FAQ
	{
		//FAQID
		public int id { get; set; }
		//FAQ質問
		public String question { get; set; }
		//FAQ回答
		public String answer { get; set; }

		public bool create()
		{
			bool check = false;
			string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
			using (var connection = new SqlConnection(cstr))
			using (var command = connection.CreateCommand())
			{
				try
				{
					connection.Open();
					command.CommandText = "Insert Into FAQ Values (@question,@answer) ";
					command.Parameters.Add(new SqlParameter("@question", question));
					command.Parameters.Add(new SqlParameter("@answer", answer));
					int cnt = command.ExecuteNonQuery();
					connection.Close();
					if(cnt != 0)
					{
						check = true;
					} 
				}
				catch (SqlException e)
				{
					//入力情報が足りないメッセージを吐く
					return check;
				}
			}
			return check;
		}
	}
}