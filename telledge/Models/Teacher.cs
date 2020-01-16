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
							retTeacher.address = dt.Rows[0]["address"].ToString();
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
		public double getValuation()
		{
			double valuation = -1;
			string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
			using (SqlConnection connection = new SqlConnection(cstr))
			{
				string sql = "SELECT AVG(cast(valuation as float)) as avgVal FROM teacher T " +
								"INNER JOIN Room R ON T.id = R.teacherId " +
								"INNER JOIN Section S ON R.id = S.roomId " +
								"WHERE T.id = @id AND valuation IS NOT NULL ";
				SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
				adapter.SelectCommand.Parameters.Add("@id", SqlDbType.Int);
				adapter.SelectCommand.Parameters["@id"].Value = id;
				DataSet ds = new DataSet();
				int cnt = adapter.Fill(ds, "teacher");
				if (cnt != 0)
				{
					DataTable dt = ds.Tables["teacher"];
					if (dt.Rows[0]["avgVal"] != DBNull.Value)
					{
						valuation = Convert.ToDouble(dt.Rows[0]["avgVal"]);
					}
				}
			}
			return valuation;
		}
		public bool Update()
		{
			bool check = false;
			string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
			using (var connection = new SqlConnection(cstr))
			using (var command = connection.CreateCommand())
			{
				try
				{
					connection.Open();
					command.CommandText = "Update Teacher Set name = @name,sex = @sex ,profileImage = @profileImage,age = @age,language = @language, " +
											"introduction = @introduction,passwordDigest = @passwordDigest,mailaddress = @mailaddress, " +
											 "point = @point,address = @address,is2FA = @is2FA,nationality = @nationality,inactiveDate = @inactiveDate where id = @id";
					command.Parameters.Add(new SqlParameter("@id", id));
					if (name != null) command.Parameters.Add(new SqlParameter("@name", name));
					else command.Parameters.Add(new SqlParameter("@name", DBNull.Value));
					command.Parameters.Add(new SqlParameter("@sex", sex));
					if (profileImage != null) command.Parameters.Add(new SqlParameter("@profileImage", profileImage));
					else command.Parameters.Add(new SqlParameter("@profileImage", DBNull.Value));
					command.Parameters.Add(new SqlParameter("@age", age));
					command.Parameters.Add(new SqlParameter("@language", language));
					command.Parameters.Add(new SqlParameter("@introduction", intoroduction));
					command.Parameters.Add(new SqlParameter("@passwordDigest", passwordDigest));
					command.Parameters.Add(new SqlParameter("@mailaddress", mailaddress));
					command.Parameters.Add(new SqlParameter("@point", point));
					command.Parameters.Add(new SqlParameter("@address", address));
					command.Parameters.Add(new SqlParameter("@is2FA", is2FA));
					command.Parameters.Add(new SqlParameter("@nationality", nationality));
					if (inactiveDate != null) command.Parameters.Add(new SqlParameter("@inactiveDate", inactiveDate));
					else command.Parameters.Add(new SqlParameter("@inactiveDate", DBNull.Value));
					int cnt = command.ExecuteNonQuery();
					if (cnt != 0)
					{
						check = true;
					}
					connection.Close();
				}
				catch (SqlException)
				{
					//エラー
					connection.Close();
					return check;
				}
			}
			return check;
		}
		public bool changePassword(String oldPasswordRaw, String newPasswordRaw)
		{
			bool check = false;
			SHA256 sha = new SHA256CryptoServiceProvider();
			byte[] input = Encoding.ASCII.GetBytes(oldPasswordRaw);
			byte[] CheckPasswordDigest = sha.ComputeHash(input);
			if (passwordDigest.SequenceEqual(CheckPasswordDigest))
			{
				input = Encoding.ASCII.GetBytes(newPasswordRaw);
				passwordDigest = sha.ComputeHash(input);
				check = true;
			}
			return check;
		}
		public static Teacher[] getAll()
		{
			Teacher[] retTeachers = null; //配列オブジェクトの参照先をnullとする
			string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
			using (SqlConnection connection = new SqlConnection(cstr))
			{
				string sql = "select * from Teacher";
				DataSet ds = new DataSet();
				SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
				int cnt = adapter.Fill(ds, "Teacher");
				DataTable dt = ds.Tables["Teacher"];
				if (cnt != 0)
				{
					retTeachers = new Teacher[cnt];   //配列オブジェクトとして一件以上の要素を返すことが確定したためRoomインスタンスへの参照を保存する領域を生成する
					for (int i = 0; i < cnt; i++)
					{
						retTeachers[i] = new Teacher();   //引数なしコンストラクタで初期化し、戻したい値を格納する領域を生成する
						retTeachers[i].id = (int)dt.Rows[i]["id"];
						retTeachers[i].name = (String)dt.Rows[i]["name"];
						retTeachers[i].sex = (int)dt.Rows[i]["sex"];
						if (dt.Rows[i]["profileImage"] == DBNull.Value) retTeachers[i].profileImage = null;
						retTeachers[i].profileImage = (String)dt.Rows[i]["profileImage"];
						retTeachers[i].age = (int)dt.Rows[i]["age"];
						retTeachers[i].language = (String)dt.Rows[i]["language"];
						retTeachers[i].intoroduction = (String)dt.Rows[i]["introduction"];
						retTeachers[i].passwordDigest = (Byte[])dt.Rows[i]["passwordDigest"];
						retTeachers[i].mailaddress = (String)(dt.Rows[i]["mailaddress"].ToString());
						retTeachers[i].point = (int)dt.Rows[i]["point"];
						retTeachers[i].address = (String)dt.Rows[i]["address"];
						retTeachers[i].is2FA = (bool)dt.Rows[i]["is2FA"];
						retTeachers[i].nationality = (String)dt.Rows[i]["nationality"];
						if (dt.Rows[i]["inactiveDate"] == DBNull.Value) retTeachers[i].inactiveDate = null;
						else retTeachers[i].inactiveDate = DateTime.Parse(dt.Rows[i]["inactiveDate"].ToString());
					}
				}
				return retTeachers;
			}
		}
		public static Teacher find(int id)
		{
			Teacher retTeacher = null;
			string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
			using (SqlConnection connection = new SqlConnection(cstr))
			{
				string sql = "select * from Teacher where id = @id";
				SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
				adapter.SelectCommand.Parameters.Add("@id", SqlDbType.VarChar);
				adapter.SelectCommand.Parameters["@id"].Value = id;
				DataSet ds = new DataSet();
				int cnt = adapter.Fill(ds, "Teacher");
				if (cnt != 0)
				{
					retTeacher = new Teacher();
					DataTable dt = ds.Tables["Teacher"];
					retTeacher.id = (int)dt.Rows[0]["id"];
					retTeacher.name = (String)dt.Rows[0]["name"];
					retTeacher.sex = (int)dt.Rows[0]["sex"];
					if (dt.Rows[0]["profileImage"] == DBNull.Value) retTeacher.profileImage = null;
					retTeacher.profileImage = (String)dt.Rows[0]["profileImage"];
					retTeacher.age = (int)dt.Rows[0]["age"];
					retTeacher.language = (String)dt.Rows[0]["language"];
					retTeacher.intoroduction = (String)dt.Rows[0]["introduction"];
					retTeacher.passwordDigest = (Byte[])dt.Rows[0]["passwordDigest"];
					retTeacher.mailaddress = (String)(dt.Rows[0]["mailaddress"].ToString());
					retTeacher.point = (int)dt.Rows[0]["point"];
					retTeacher.address = (String)dt.Rows[0]["address"];
					retTeacher.is2FA = (bool)dt.Rows[0]["is2FA"];
					retTeacher.nationality = (String)dt.Rows[0]["nationality"];
					if (dt.Rows[0]["inactiveDate"] == DBNull.Value) retTeacher.inactiveDate = null;
					else retTeacher.inactiveDate = DateTime.Parse(dt.Rows[0]["inactiveDate"].ToString());

				}
			}
			return retTeacher;
		}
		public Room[] getRooms()
		{
			Room[] retRooms = null;
			string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
			using (SqlConnection connection = new SqlConnection(cstr))
			{
				string sql = "select * from Room where teacherId = @teacherId";
				SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
				adapter.SelectCommand.Parameters.Add("@teacherId", SqlDbType.VarChar);
				adapter.SelectCommand.Parameters["@teacherId"].Value = id;
				DataSet ds = new DataSet();
				int cnt = adapter.Fill(ds, "Room");
				DataTable dt = ds.Tables["Room"];
				if (cnt != 0)
				{
					retRooms = new Room[cnt];
					for (int i = 0; i < cnt; i++)
					{
						retRooms[i] = new Room();
						retRooms[i].id = (int)dt.Rows[i]["id"];
						retRooms[i].teacherId = (int)dt.Rows[i]["teacherId"];
						retRooms[i].roomName = (String)dt.Rows[i]["roomName"];
						retRooms[i].tag = (String)dt.Rows[i]["tag"];
						retRooms[i].description = (String)dt.Rows[i]["description"];
						retRooms[i].worstTime = (int)dt.Rows[i]["worstTime"];
						retRooms[i].extensionTime = (int)dt.Rows[i]["extensionTime"];
						retRooms[i].point = (int)dt.Rows[i]["point"];
						retRooms[i].beginTime = DateTime.Parse(dt.Rows[i]["beginTime"].ToString());
						if (dt.Rows[i]["endTime"] != DBNull.Value)
						{
							retRooms[i].endTime = DateTime.Parse(dt.Rows[i]["endTime"].ToString());
						}
						retRooms[i].endScheduleTime = DateTime.Parse(dt.Rows[i]["endScheduleTime"].ToString());
					}
				}
			}
			return retRooms;
		}
	}
}