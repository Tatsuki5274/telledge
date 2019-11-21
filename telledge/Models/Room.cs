using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

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
        public DateTime endTime { get; set; }

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
                    command.CommandText = "Insert Into Room Values (@teacherId,@roomName,@tag,@description,@worstTime,@extensionTime,@point,@endScheduleTime,@beginTime,@endTime)";
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
                    int cnt = command.ExecuteNonQuery();
                    if (cnt != 0)
                    {
                        check = true;
                    }
                    connection.Close();
                }
                catch (SqlException e)
                {
                    //入力情報が足りないメッセージを吐く
                    return false;
                }
            }
            return check;
        }
    }
}
