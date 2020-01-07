let timer = new Timer(mintime, overtime);
timer.setCallback(Status.NotStarted, () => {
	$('#call-end').css('display', 'none');
	$('#disabled-call-end').css('display', 'none');
	$('#room-end').css('display', 'inline');

	$('#timer-title').text('通話なし');
	$('#timer-count').css('display', 'none');
	$('#timer-title').css('color', 'black');

});
timer.setCallback(Status.Essential, () => {
	$('#timer-title').text('残り時間');
	$('#timer-count').css('display', 'inline');
	$('#timer-count').css('color', 'black');
	$('#timer-title').css('color', 'black');

	$('#call-end').css('display', 'none');
	$('#disabled-call-end').css('display', 'inline');
	$('#room-end').css('display', 'none');
});
timer.setCallback(Status.Extend, () => {
	$('#timer-count').css('color', 'red');
	$('#timer-title').css('color', 'red');
	$('#timer-title').text("延長時間");
	$('#timer-count').css('display', 'inline');


	$('#call-end').css('display', 'inline');
	$('#disabled-call-end').css('display', 'none');
	$('#room-end').css('display', 'none');
});
timer.setCallback(Status.AllDone, () => {
	$('#timer-title').text("通話時間終了");
	$('#timer-title').css('color', 'red');
	$('#timer-count').css('display', 'none');

	$('#call-end').css('display', 'none');
	$('#disabled-call-end').css('display', 'none');
	$('#room-end').css('display', 'inline');

});

timer.setTimer()

// WebSocketの処理
$(function () {
	// 1. サーバとの接続オブジェクト作成
	var connection = $.hubConnection();

	// 2. Hubのプロキシ・オブジェクトを作成
	var echo = connection.createHubProxy("Room");

	// サーバから呼び出して要素を削除するメソッドを登録
	echo.on("removeStudent", function (studentId) {
		$('#student-' + studentId).remove();
	});

	// 生徒一覧への追記処理
	echo.on("append", (student_json) => {
		const id = "id=\"student-" + student_json.student_id + "\"";
		const value = "value=\"" + student_json.student_id + "\"";
		$("#student-list").append("<tr " + id + " " + value + "></tr>");
		$("#student-" + student_json.student_id)
			.append(
				"<td>" + student_json.student_name + "</td>",
				"<td>" + student_json.request + "</td>",
				"<td><button class=\"btn btn-danger\">キャンセル</button></td>"
			);
	});

	//通話終了ボタンの入力を検知したときの処理
	$("#room-end").click(function () {
		echo.invoke("endCall", roomId, studentId);	//ルームの終了を知らせる信号を送信する
	});

	// 通話終了の信号を受信したときの処理
	echo.on("endCall", (section, student) => {
		if (section != null) {
			//次に待っている生徒がいる場合
			$('.student-name').text(student.name);
			$('.student-request').text(section.request);
		} else {
			$('.student-name').text("");
			$('.student-request').text("");
		}
		$('#student-' + student.id).remove();
		$("#break-modal").modal({
			backdrop: "static"
		});
		// モーダルウィンドウを開く
		$("#break-modal").modal('show');
		
	});

	//生徒リストのリジェクトボタンを押したときの処理
	$(document).on("click", "#student-list button", function () {
		const $tr = $(this).closest("tr");		//押されたボタンから一番近いtr要素を取得する
		const studentId = $tr.attr("value");	//生徒番号をdomから取得
		echo.invoke("rejectRoom", roomId, studentId);	//RoomHubクラスのrejectRoomメソッドを呼び出す（引数は順番にルーム番号、生徒番号）
		$tr.remove();	//対象の要素を削除
	});

	// 接続を開始
	connection.start(function () {
		//サーバーのJoinTeacherメソッドを実行し、講師として登録する
		echo.invoke("JoinTeacher", roomId);
	});
});