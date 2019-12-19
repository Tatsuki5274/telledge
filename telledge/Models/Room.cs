using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace telledge.Models
{
    public class Room
    {
        //ルームID
        public int id { set; get; }
        //講師ID
        public int teacherId { set; get;}
        //ルーム名
        public String roomName { set; get; }
        //特徴を示すタグ
        public String tag { get; set; }
        //ルームに対する説明
        public String description { get; set; }
        //最低保障時間
        public int worstTime { get; set; }
        //最大延長時間
        public int extensionTime { get; set; }
        //通話に必要なポイント
        public int point { get; set; }
        //通話終了予定時刻
        public DateTime endScheduleTime { get; set; }
        //通話開始時刻
        public DateTime beginTime { get; set; }
        //通話終了時刻
        public DateTime ?endTime { get; set; }
        public bool isClosed()
        {
            if (endTime == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void close()
        {
            DateTime dt = DateTime.Now;
            endTime = dt;
        }
        public int create()
        {
			int cnt = 0;
            string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            using (var connection = new SqlConnection(cstr))
            using (var command = connection.CreateCommand())
            {
                try
                {
                    connection.Open();
                    command.CommandText = "Insert Into Room Values (@teacherId,@roomName,@tag,@description,@worstTime,@extensionTime,@point,@endScheduleTime,@beginTime,@endTime); " +
											" SELECT @@IDENTITY;";
                    command.Parameters.Add(new SqlParameter("@teacherId", teacherId));
                    command.Parameters.Add(new SqlParameter("@roomName", roomName));
                    command.Parameters.Add(new SqlParameter("@tag", tag));
                    command.Parameters.Add(new SqlParameter("@description", description));
                    command.Parameters.Add(new SqlParameter("@worstTime", worstTime));
                    command.Parameters.Add(new SqlParameter("@extensionTime", extensionTime));
                    command.Parameters.Add(new SqlParameter("@point", point));
                    command.Parameters.Add(new SqlParameter("@endScheduleTime", endScheduleTime));
                    command.Parameters.Add(new SqlParameter("@beginTime", beginTime));
                    command.Parameters.Add(new SqlParameter("@endTime",DBNull.Value));
                    cnt = int.Parse(command.ExecuteScalar().ToString());
                    connection.Close();
                }
                catch (SqlException)
                {
                    //入力情報が足りないメッセージを吐く
                }
            }
            return cnt;
        }

        public static Room[] getRooms()
        {
            Room[] retRooms = null; //配列オブジェクトの参照先をnullとする
            string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cstr))
            {
                string sql = "select * from Room";
                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                int cnt = adapter.Fill(ds, "Room");
                DataTable dt = ds.Tables["Room"];
                if(cnt != 0) { 
                    retRooms = new Room[cnt];   //配列オブジェクトとして一件以上の要素を返すことが確定したためRoomインスタンスへの参照を保存する領域を生成する
                    for (int i = 0; i < cnt; i++)
                    {
                        retRooms[i] = new Room();   //引数なしコンストラクタで初期化し、戻したい値を格納する領域を生成する
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
                return retRooms;
            }
        }

        private Teacher cachedGetTeacher = null;
        public Teacher getTeacher()
        {
            if (this.cachedGetTeacher != null) return this.cachedGetTeacher;
            Teacher retTeacher = null;
            string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cstr))
            {
                string sql = "select * from Teacher where id = @id";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.Parameters.Add("@id", SqlDbType.VarChar);
                adapter.SelectCommand.Parameters["@id"].Value = this.teacherId;
                DataSet ds = new DataSet();
                int cnt = adapter.Fill(ds, "Teacher");
                if (cnt != 0)
                {
                    DataTable dt = ds.Tables["Teacher"];
                    retTeacher = new Teacher();
                    retTeacher.address = dt.Rows[0]["address"].ToString();
                    retTeacher.age = (int)dt.Rows[0]["age"];
                    retTeacher.id = (int)dt.Rows[0]["id"];
                    if (dt.Rows[0]["inactiveDate"] != DBNull.Value)
                    {
                        retTeacher.inactiveDate = DateTime.Parse(dt.Rows[0]["inactiveDate"].ToString());
                    }
                    retTeacher.intoroduction = dt.Rows[0]["introduction"].ToString();
                    retTeacher.is2FA = (bool)dt.Rows[0]["is2FA"];
                    retTeacher.language = dt.Rows[0]["language"].ToString();
                    retTeacher.mailaddress = dt.Rows[0]["mailaddress"].ToString();
                    retTeacher.name = dt.Rows[0]["name"].ToString();
                    retTeacher.nationality = dt.Rows[0]["nationality"].ToString();
                    retTeacher.sex = (int)dt.Rows[0]["sex"];
                    retTeacher.passwordDigest = (byte[])dt.Rows[0]["passwordDigest"];
                    retTeacher.point = (int)dt.Rows[0]["point"];
                    retTeacher.profileImage = dt.Rows[0]["profileImage"].ToString();
                    this.cachedGetTeacher = retTeacher; //次回のリクエストに高速で返答するために値をキャッシュしておく
                }
            }
            return retTeacher;
        }

        public static Room find(int id)
        {
            Room retRoom = null;
            string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cstr))
            {
                string sql = "select * from Room where id = @id";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.Parameters.Add("@id", SqlDbType.VarChar);
                adapter.SelectCommand.Parameters["@id"].Value = id;
                DataSet ds = new DataSet();
                int cnt = adapter.Fill(ds, "Room");
                if (cnt != 0)
                {
                    DataTable dt = ds.Tables["Room"];
                    retRoom = new Room();
                    retRoom.id = (int)dt.Rows[0]["id"];
                    retRoom.teacherId = (int)dt.Rows[0]["teacherId"];
                    retRoom.roomName = (String)dt.Rows[0]["roomName"];
                    retRoom.tag = (String)dt.Rows[0]["tag"];
                    retRoom.description = (String)dt.Rows[0]["description"];
                    retRoom.worstTime = (int)dt.Rows[0]["worstTime"];
                    retRoom.extensionTime = (int)dt.Rows[0]["extensionTime"];
                    retRoom.point = (int)dt.Rows[0]["point"];
                    retRoom.beginTime = DateTime.Parse(dt.Rows[0]["beginTime"].ToString());
                    if (dt.Rows[0]["endTime"] != DBNull.Value)
                    {
                        retRoom.endTime = DateTime.Parse(dt.Rows[0]["endTime"].ToString());
                    }
                    retRoom.endScheduleTime = DateTime.Parse(dt.Rows[0]["endScheduleTime"].ToString());

                }
            }
            return retRoom;
        }

        public int getWaitCount()
        {
			int cnt = 0;
			string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
			using (SqlConnection connection = new SqlConnection(cstr))
			{
				string sql = "SELECT COUNT(studentId) as count From Section WHERE roomId = @Id";
				SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
				adapter.SelectCommand.Parameters.Add("@id", SqlDbType.Int);
				adapter.SelectCommand.Parameters["@id"].Value = this.id;
				DataSet ds = new DataSet();
				adapter.Fill(ds, "Room");
				DataTable dt = ds.Tables["Room"];
				cnt = Int32.Parse(dt.Rows[0]["count"].ToString());
			}
			return cnt;
		}

		public int getWaitTime()
		{
			int cnt = 0;
			string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
			using (SqlConnection connection = new SqlConnection(cstr))
			{
				string sql = "SELECT(worstTime + extensionTime) / 2 * (SELECT COUNT(studentId) From Section WHERE roomId = @id) as time FROM Room WHERE Id = @id";
				SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
				adapter.SelectCommand.Parameters.Add("@id", SqlDbType.Int);
				adapter.SelectCommand.Parameters["@id"].Value = this.id;
				DataSet ds = new DataSet();
				adapter.Fill(ds, "Room");
				DataTable dt = ds.Tables["Room"];
				cnt = Int32.Parse(dt.Rows[0]["time"].ToString());
			}
			return cnt;
		}
		public Section getSection()
		{
			Section section = null;
			string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
			using (SqlConnection connection = new SqlConnection(cstr))
			{
				string sql = "SELECT * FROM Section WHERE roomId = @id And talkTime IS NULL order by [order] asc";
				SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
				adapter.SelectCommand.Parameters.Add("@id", SqlDbType.Int);
				adapter.SelectCommand.Parameters["@id"].Value = id;
				DataSet ds = new DataSet();
				int cnt = adapter.Fill(ds, "Room");
				if(cnt != 0)
				{
					DataTable dt = ds.Tables["Room"];
					section = new Section();
					section.order = (int)dt.Rows[0]["order"];
					section.request = dt.Rows[0]["request"].ToString();
					section.roomId = (int)dt.Rows[0]["roomId"];
					section.studentId = (int)dt.Rows[0]["studentId"];
					if (dt.Rows[0]["talkTime"] != DBNull.Value)
					{
						section.talkTime = (int)dt.Rows[0]["talkTime"];
					}
					if (dt.Rows[0]["valuation"] != DBNull.Value)
					{
						section.valuation = (int)dt.Rows[0]["valuation"];
					}
					if (dt.Rows[0]["beginTime"] != DBNull.Value)
					{
						section.beginTime = DateTime.Parse(dt.Rows[0]["beginTime"].ToString());
					}
				}
			}
				return section;
		}
      
		public Section[] GetSections()
		{
			Section[] retSections = null;
			string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
			using (SqlConnection connection = new SqlConnection(cstr))
			{
				string sql = "SELECT * FROM Section WHERE roomId = @id And talkTime IS NULL order by [order] asc";
				SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
				adapter.SelectCommand.Parameters.Add("@id", SqlDbType.Int);
				adapter.SelectCommand.Parameters["@id"].Value = id;
				DataSet ds = new DataSet();
				int cnt = adapter.Fill(ds, "Room");
				if (cnt != 0)
				{
					retSections = new Section[cnt];
					for (int i = 0; i < cnt; i++)
					{
						retSections[i] = new Section();
						DataTable dt = ds.Tables["Room"];
						retSections[i].order = (int)dt.Rows[i]["order"];
						retSections[i].request = dt.Rows[i]["request"].ToString();
						retSections[i].roomId = (int)dt.Rows[i]["roomId"];
						retSections[i].studentId = (int)dt.Rows[i]["studentId"];
						if (dt.Rows[i]["talkTime"] != DBNull.Value)
						{
							retSections[i].talkTime = (int)dt.Rows[i]["talkTime"];
						}
						if (dt.Rows[i]["valuation"] != DBNull.Value)
						{
							retSections[i].valuation = (int)dt.Rows[i]["valuation"];
						}
						if (dt.Rows[i]["beginTime"] != DBNull.Value)
						{
							retSections[i].beginTime = DateTime.Parse(dt.Rows[i]["beginTime"].ToString());
						}
					}
				}
			}
			return retSections;
		}
      
		public static Room[] getRooms(String tag)
		{
			Room[] retRooms = null;
			string cstr = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
			using (SqlConnection connection = new SqlConnection(cstr))
			{
				string sql = "SELECT * FROM Room WHERE tag LIKE '%'+ @tag + '%'";
				SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
				adapter.SelectCommand.Parameters.Add("@tag", SqlDbType.NVarChar);
				adapter.SelectCommand.Parameters["@tag"].Value = tag;
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
				return retRooms;
			}
		}
	}
}
