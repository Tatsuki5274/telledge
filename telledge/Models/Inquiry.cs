using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace telledge.Models
{
	public class Inquiry
	{
		//問い合わせID
		public int id;
		//問い合わせ内容
		public String inquiryContent;
		//問い合わせ時間
		public DateTime inquiryTime;
		//送信者名
		public String senderName;
		//送信内容
		public String senderContent;
		//返信者ID
		public int replierId;
		//返信内容
		public String replierContent;
		//問い合わせ返信有無
		public Boolean isReplied;
	}
}
