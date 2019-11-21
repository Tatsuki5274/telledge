using System;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

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
        public DateTime? inactivedate { set; get; }

        public bool logout()
        {
            bool ret;
            if (ret = HttpContext.Current.Session["Teacher"] != null) HttpContext.Current.Session["Teacher"] = null;
            return ret;
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
                }catch(SqlException e){
                    //入力情報が足りないメッセージを吐く
                    return false;
                }
            }
            return check;
        }
    }
}