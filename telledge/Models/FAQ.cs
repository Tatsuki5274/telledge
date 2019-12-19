using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
				catch (SqlException)
				{
					//入力情報が足りないメッセージを吐く
				}
			}
			return check;
		}
		public bool delete()
		{
			bool check = false;
			string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
			using (SqlConnection connection = new SqlConnection(cstr))
			{
				String sql = "delete from faq where id = @id";
				SqlCommand command = new SqlCommand(sql, connection);
				connection.Open();
				command.Parameters.Add("@id", SqlDbType.Int);
				command.Parameters["@id"].Value = id;
				int cnt = command.ExecuteNonQuery();
				connection.Close();
				if (cnt != 0)
				{
					check = true;
				}

			}
			return check;
		}
		public FAQ[] getAll()
		{
			FAQ[] retFaq = null;
			string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
			using (SqlConnection connection = new SqlConnection(cstr))
			{
				String sql = "select * from FAQ";
				SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
				DataSet ds = new DataSet();
				int cnt = adapter.Fill(ds, "FAQ");
				if(cnt != 0)
				{
					retFaq = new FAQ[cnt];
					for (int i = 0; i < cnt; i++)
					{
						DataTable dt = ds.Tables["FAQ"];
						retFaq[i] = new FAQ();
						retFaq[i].id = (int)dt.Rows[i]["id"];
						retFaq[i].question = (String)dt.Rows[i]["question"];
						retFaq[i].answer = (String)dt.Rows[i]["answer"];
					}
				}
			}
			return retFaq;
		}
	}
}