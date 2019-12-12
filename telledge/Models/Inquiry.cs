using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace telledge.Models
{
	public class Inquiry
	{
		public int id; //問い合わせID
		public String inquiryContent;//問い合わせ内容
		public DateTime inquiryTime;//問い合わせ時間
		public String senderName;//送信者名
		public String senderContent;//送信内容
		public int replierId;//返信者ID
		public String replierContent;//返信内容
		public Boolean isReplied;//問い合わせ返信有無
	}
}
