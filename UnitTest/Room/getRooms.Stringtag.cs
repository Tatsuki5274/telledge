using Microsoft.VisualStudio.TestTools.UnitTesting;
using telledge.Models;


namespace UnitTest.Rooms
{
	[TestClass]
	public class getRooms_String_tag_
	{
		[TestMethod]
		public void succsess()
		{
			Room[] rooms = Room.getRooms("tag");
			Assert.IsNotNull(rooms);
		}
	}
}