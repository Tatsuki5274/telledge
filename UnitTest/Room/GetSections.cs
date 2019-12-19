using Microsoft.VisualStudio.TestTools.UnitTesting;
using telledge.Models;

namespace UnitTest.Rooms
{
	[TestClass]
	public class RoomGetSections
	{
		[TestMethod]
		public void getSections()
		{
			Room room = new Room();
			room.id = 1;
			Section[] seciton = room.getSections();
			Assert.IsNotNull(seciton);
		}
		[TestMethod]
		public void getSectionsFailed()
		{
			Room room = new Room();
			room.id = 3;
			Section[] seciton = room.getSections();
			Assert.IsNull(seciton);
		}
	}
}
