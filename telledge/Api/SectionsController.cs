using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using telledge.Models;

namespace telledge.Api
{
	public class SectionsController : ApiController
	{
		// GET api/<controller>

		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/<controller>/5
		public Section Get(int student_id, int room_id, string api_key=null)
		{
			return Section.find(room_id, student_id);
		}

		// POST api/<controller>
		public void Post([FromBody]string value)
		{
		}

		// PUT api/<controller>/5
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE api/<controller>/5
		public String[] Delete(int room_id, int student_id)
		{
			//ルームから退出する処理
			//if (Student.currentUser() == null) return RedirectToAction("create", "sessions");
			String[] message;
			
			Section section = new Section(); 
			section.studentId = student_id;
			section.roomId = room_id;
			if (section.delete() == true)
			{
				message = new[] { "Delete was successed!"};
			}
			else
			{
				message = new[]
				{
					"Delete was failed...",
					"These parameters are given.",
					"room_id: " + room_id,
					"student_id: " + student_id
				};
			}

			return message;
		}
	}
}