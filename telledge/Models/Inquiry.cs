using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace telledge.Models
{
	public class Inquiry
	{
		//問い合わせID
		public int id { get; set; }
		//問い合わせ内容
		public String inquiryContent { get; set; }
		//問い合わせ時間
		public DateTime inquiryTime { get; set; }
		//送信者名
		public String senderName { get; set; }
		//送信内容
		public String senderContent { get; set; }
		//返信者ID
		public int replierId { get; set; }
		//返信内容
		public String replierContent { get; set; }
		//問い合わせ返信有無
		public Boolean isReplied { get; set; }
	}
}
