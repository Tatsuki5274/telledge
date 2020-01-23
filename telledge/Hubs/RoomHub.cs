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
			//実行されない処理？
			//呼び出しがStudent/RoomsControllerのjoinメソッドにあり。

			Room room = Room.find(roomId);  //ルーム番号のルームインスタンスを取得する
			Section section = Section.find(roomId, studentId);
			/*
			Clients.Group("teacher_room_" + roomId).append(new {
				student_id = section.studentId,
				student_name = section.getStudent().name,
				request = section.request
			});
			*/
			Clients.Group("teacher_room_" + roomId).append(section.getStudent(), section);
			Clients.Group("student_room_" + roomId).updateWaitInfo(room, room.getSections());
		}

		//通話を開始する信号を受け取ったときの処理
		public void startCall(int roomId, int studentId)
		{
			Section section = Section.find(roomId, studentId);
			section.beginTime = DateTime.Now;
			section.update();
			Clients.Group("student_room_" + roomId).updateCallStudent(studentId);
		}

		//通話を終了する信号を受け取ったときに実行する処理（呼び出し元は問わない）
		public void endCall(int roomId, int studentId)
		{
			Section section = Section.find(roomId, studentId);
			TimeSpan? talkSpan = (DateTime.Now - section.beginTime);
			section.talkTime = talkSpan.Value.Minutes + talkSpan.Value.Hours * 60;
			if (section.update())
			{
				//各ユーザに通話の終了を伝達する
				Room room = Room.find(roomId);
				Section room_section = room == null ? null : room.getSection();
				Student room_section_student = room_section == null ? null : room_section.getStudent();
				Clients.Group("teacher_room_" + roomId).endCall(room_section, room_section_student);
				Clients.Group("student_room_" + roomId).endCall(roomId, studentId);
				Clients.Group("student_room_" + roomId).updateWaitInfo(room, room.getSections());    //生徒の待ち情報を更新する
			}
		}
		// 生徒がルームから退出した時の処理
		public void leaveRoom(int roomId, int studentId)
		{
			Section section = new Section();
			Room room = Room.find(roomId);
			section.roomId = roomId;
			section.studentId = studentId;
			section.delete();
			Clients.Group("teacher_room_" + roomId).removeStudent(studentId);   //講師のリストから削除する
			Clients.Group("student_room_" + roomId).updateWaitInfo(room, room.getSections());	//生徒の待ち情報を更新する
		}

		//講師が生徒を対応拒否した場合の処理
		public void rejectRoom(int roomId, int studentId)
		{
			Section section = new Section();
			section.roomId = roomId;
			section.studentId = studentId;
			section.delete();
			Room room = Room.find(roomId);
			// 生徒全体へリジェクト情報を送信する
			Clients.Group("student_room_" + roomId).reject(new {
				student_id = studentId
				//待ち人数と待ち時間を更新して同時に返す処理をここに実装予定
			});
			Clients.Group("student_room_" + roomId).updateWaitInfo(room, room.getSections());    //生徒の待ち情報を更新する
		}
		public void Hello()
		{
			Clients.All.hello();
		}
	}
}