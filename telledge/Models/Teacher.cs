using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace telledge.Models
{
	public class Teacher
    {
        //講師ID
        public int id { set; get; }
        //講師名
        public String name { set; get; }
        //講師性別
        public int sex { set; get; }
        //講師プロフィール画像
        public String profileImage { set; get; }
        //講師年齢
        public int age { set; get; }
        //講師の会話言語
        public String language { set; get; }
        //講師自己紹介
        public String intoroduction { set; get; }
        //講師のパスワードのダイジェスト
        public byte[] passwordDigest { set; get; }
        //講師メールアドレス
        public String mailaddress { set; get; }
        //講師保有ポイント
        public int point { set; get; }
        //講師住所
        public String address { set; get; }
        //二段階認証の有無
        public Boolean is2FA { set; get; }
        //講師の在住国籍
        public String nationality { set; get; }
        //講師退会日
        public DateTime? inactiveDate { set; get; }

        public static bool logout()
        {
            bool ret;
            if (ret = HttpContext.Current.Session["Teacher"] != null) HttpContext.Current.Session["Teacher"] = null;
            return ret;
        }
        public static Teacher login(String mailaddress, String password)
        {
            Teacher retTeacher = null;
            string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cstr))
            {
                string sql = "select * from Teacher where mailaddress = @mailaddress";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.Parameters.Add("@mailaddress", SqlDbType.VarChar);
                adapter.SelectCommand.Parameters["@mailaddress"].Value = mailaddress;
                DataSet ds = new DataSet();
                int cnt = adapter.Fill(ds, "Teacher");
                if (cnt != 0)
                {
                    DataTable dt = ds.Tables["Teacher"];
                    Byte[] passwordDigest = (Byte[])dt.Rows[0]["passwordDigest"];
                    if (dt.Rows[0]["inactiveDate"] == DBNull.Value)
                    {
                        byte[] input = Encoding.ASCII.GetBytes(password);
                        SHA256 sha = new SHA256CryptoServiceProvider();
                        byte[] hash_sha256 = sha.ComputeHash(input);
                        if (passwordDigest.SequenceEqual(hash_sha256))
                        {
                            retTeacher = new Teacher();
                            retTeacher.id = (int)dt.Rows[0]["id"];
                            retTeacher.name = dt.Rows[0]["name"].ToString();
                            retTeacher.sex = (int)dt.Rows[0]["sex"];
                            retTeacher.profileImage = dt.Rows[0]["profileImage"].ToString();
                            retTeacher.mailaddress = dt.Rows[0]["mailaddress"].ToString();
                            retTeacher.age = (int)dt.Rows[0]["age"];
                            retTeacher.language = dt.Rows[0]["language"].ToString();
                            retTeacher.intoroduction = dt.Rows[0]["introduction"].ToString();
                            retTeacher.passwordDigest = (Byte[])dt.Rows[0]["passwordDigest"];
                            retTeacher.nationality = dt.Rows[0]["nationality"].ToString();
                            retTeacher.is2FA = (bool)dt.Rows[0]["is2FA"];
                            retTeacher.point = (int)dt.Rows[0]["point"];
                            if (dt.Rows[0]["inactiveDate"] != DBNull.Value)
                            {
                                retTeacher.inactiveDate = DateTime.Parse(dt.Rows[0]["inactiveDate"].ToString());
                            }
                            HttpContext.Current.Session["Teacher"] = retTeacher;
                        }
                    }                   
                }               
            }
            return retTeacher;
        }
        public void setPassword(String passwordRow)
        {
            byte[] input = Encoding.ASCII.GetBytes(passwordRow);
            SHA256 sha = new SHA256CryptoServiceProvider();
            passwordDigest = sha.ComputeHash(input);
        }
        public static Teacher currentUser()
        {
            return (Teacher)HttpContext.Current.Session["Teacher"];
        }
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
                    command.CommandText = "Insert Into Teacher Values (@name,@sex,@profileImage,@age,@language,@intoroduction,@passwordDigest,@mailaddress,@point,@address,@is2FA,@nationality,@inactiveDate)";
                    command.Parameters.Add(new SqlParameter("@name", name));
                    command.Parameters.Add(new SqlParameter("@sex", sex));
                    command.Parameters.Add(new SqlParameter("@profileImage", profileImage));
                    command.Parameters.Add(new SqlParameter("@age", age));
                    command.Parameters.Add(new SqlParameter("@language", language));
                    command.Parameters.Add(new SqlParameter("@intoroduction", intoroduction));
                    command.Parameters.Add(new SqlParameter("@passwordDigest", passwordDigest));
                    command.Parameters.Add(new SqlParameter("@mailaddress", mailaddress));
                    command.Parameters.Add(new SqlParameter("@point", point));
                    command.Parameters.Add(new SqlParameter("@address", address));
                    command.Parameters.Add(new SqlParameter("@is2FA", is2FA));
                    command.Parameters.Add(new SqlParameter("@nationality", nationality));
                    command.Parameters.Add(new SqlParameter("@inactiveDate", DBNull.Value));
                    int cnt = command.ExecuteNonQuery();
                    if (cnt != 0)
                    {
                        check = true;
                    }
                    connection.Close();
                }catch(SqlException){
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
				string sql = "select * from teacher where id = @id";
				SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
				adapter.SelectCommand.Parameters.Add("@id", SqlDbType.Int);
				adapter.SelectCommand.Parameters["@id"].Value = id;
				DataSet ds = new DataSet();
				int cnt = adapter.Fill(ds, "teacher");
				if (cnt != 0)
				{
					DataTable dt = ds.Tables["teacher"];
					if (dt.Rows[0]["inactiveDate"] == DBNull.Value)
					{
						this.inactiveDate = DateTime.Now;
						sql = "UPDATE teacher SET inactiveDate = @inactiveDate WHERE  id = @id";
						SqlCommand command = new SqlCommand(sql, connection);
						connection.Open();
						command.Parameters.Add("@id", SqlDbType.Int);
						command.Parameters["@id"].Value = id;
						command.Parameters.Add("@inactiveDate", SqlDbType.DateTime);
						command.Parameters["@inactiveDate"].Value = DateTime.Today;
						cnt = command.ExecuteNonQuery();
						connection.Close();
						if (cnt != 0)
						{
							check = true;
						}
						else
						{
							return check;
						}

					}
				}
			}
			return check;
		}
		public bool isDeleted()
		{
			bool check = false;
			if (this.inactiveDate != null)
			{
				check = true;
			}
			return check;
		}
	}
}