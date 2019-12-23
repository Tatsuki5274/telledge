using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using telledge.Models;

namespace telledge.Hubs
{
	[HubName("Room")]
	public class RoomHub : Hub
	{
		// 指定されたグループへ参加する
		public void JoinStudent(int roomId)
		{
			Groups.Add(Context.ConnectionId, "student_room_" + roomId);
		}

		// 指定されたグループから離脱する
		public void LeaveStudent(int roomId)
		{
			Groups.Remove(Context.ConnectionId, "student_room_" + roomId);
		}

		public void JoinTeacher(int roomId)
		{
			Groups.Add(Context.ConnectionId, "teacher_room_" + roomId);
		}

		// 指定されたグループから離脱する
		public void LeaveTeacher(int roomId)
		{
			Groups.Remove(Context.ConnectionId, "teacher_room_" + roomId);
		}


		// 生徒がルームに参加した時の処理
		public void joinRoom(int roomId, int studentId)
		{
			Room room = Room.find(roomId);	//ルーム番号のルームインスタンスを取得する
			//Student student = Student.
			Clients.Group("room_" + roomId).append();
		}
		// 生徒がルームから退出した時の処理
		public void leaveRoom(int roomId, int studentId)
		{
			Section section = new Section();
			section.roomId = roomId;
			section.studentId = studentId;
			section.delete();
			Clients.Group("teacher_room_" + roomId).removeStudent(studentId);
		}
		public void Hello()
		{
			Clients.All.hello();
		}
	}
}