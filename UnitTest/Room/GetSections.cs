using Microsoft.VisualStudio.TestTools.UnitTesting;
using telledge.Models;

namespace UnitTest.Rooms
{
	[TestClass]
	public class RoomGetSections
	{
		[TestMethod]
		public void GetSections()
		{
			Room room = new Room();
			room.id = 1;
			Section[] seciton = room.GetSections();
			Assert.IsNotNull(seciton);
		}
		[TestMethod]
		public void GetSectionsFailed()
		{
			Room room = new Room();
			room.id = 3;
			Section[] seciton = room.GetSections();
			Assert.IsNull(seciton);
		}
	}
}
