const timer = new Timer(mintime, overtime);
timer.setCallback(Status.NotStarted, () => {
	$('#call-end').addClass('hidden');
	$('#room-end').addClass('hidden');
	$('#call-start').removeClass('hidden');

	$('#timer-title').text('通話なし');
	$('#timer-count').css('display', 'none');
	$('#timer-title').css('color', 'black');

});
timer.setCallback(Status.Essential, () => {
	$('#call-end').removeClass('hidden');
	$('#room-end').addClass('hidden');
	$('#call-start').addClass('hidden');
	$('#call-end').attr('disabled', 'disabled');

	$('#timer-title').text('残り時間');
	$('#timer-count').css('display', 'inline');
	$('#timer-count').css('color', 'black');
	$('#timer-title').css('color', 'black');
});
timer.setCallback(Status.Extend, () => {
	$('#call-end').removeAttr('disabled');
	$('#room-end').addClass('hidden');

	$('#timer-count').css('color', 'red');
	$('#timer-title').css('color', 'red');
	$('#timer-title').text("延長時間");
	$('#timer-count').css('display', 'inline');
});
timer.setCallback(Status.AllDone, () => {
	$('#call-end').addClass('hidden');
	$('#room-end').removeClass('hidden');

	$('#timer-title').text("通話時間終了");
	$('#timer-title').css('color', 'red');
	$('#timer-count').css('display', 'none');
});

let counter = new Counter();
counter.setState(Status.Restart);


let students = [];

// WebSocketの処理
$(function () {
	// 1. サーバとの接続オブジェクト作成
	var connection = $.hubConnection();

	// 2. Hubのプロキシ・オブジェクトを作成
	var echo = connection.createHubProxy("Room");

	// サーバから呼び出して要素を削除するメソッドを登録
	echo.on("removeStudent", function (studentId) {
		$('#student-' + studentId).remove();
		students = students.filter((student) => {
			return student.student.id != studentId;
		});
	});

	// 生徒一覧への追記処理
	echo.on("append", (student, section) => {
		current_student_id = student.id;
		const id = "id=\"student-" + student.id + "\"";
		const value = "value=\"" + student.id + "\"";
		$("#student-list").append("<tr " + id + " " + value + "></tr>");
		$("#student-" + student.id)
			.append(
				"<td>" + student.name + "</td>",
				"<td>" + section.request + "</td>",
				"<td><button class=\"btn btn-danger\">キャンセル</button></td>"
		);
		if (students.length == 0) {
			//一人目の入室者ならば
			const $start = $('#call-start');
			$start.removeClass('hidden');
			$start.removeAttr('disabled');
			$('#call-end').addClass('hidden');
		}
		students.push({ student: student, section: section });	//入室した生徒を管理対象へ追加する
		students.sort(function (a, b) {		//生徒の順番をorder順に並び替える
			return a.section.order - b.section.order;
		});
	});

	$(".startCall-button").click(function () {
		echo.invoke("startCall", roomId, students[0].student.id);	//ルームの開始を知らせる信号を送信する
		timer.setState(Status.Essential);	//最低通話として処理
		timer.setTimer();
		counter.startTimer();
		const call_student = students[0];	//生徒情報を取得する
		$('#student-' + call_student.student.id + " button").attr('disabled', 'disable');
		$("#student-name").text(call_student.student.name);
		$("#student-request").text(call_student.section.request);
		$("#student-skype-id").text(call_student.student.skypeId);
		$("#call-start").addClass("hidden");
	});

	$('#room-end').click(() => {
		echo.invoke("endRoom", roomId);
	});

	//通話終了ボタンの入力を検知したときの処理
	$("#call-end").click(function () {
		echo.invoke("endCall", roomId, current_student_id);	//ルームの終了を知らせる信号を送信する
	});

	// 通話終了の信号を受信したときの処理
	echo.on("endCall", (section, student) => {
		if (section != null) {
			//次に待っている生徒がいる場合
			$('.student-name').text(student.name);
			$('.student-request').text(section.request);
			current_student_id = section.studentId;

			$("#break-modal").modal({
				backdrop: "static"
			});
			// モーダルウィンドウを開く
			$("#break-modal").modal('show');
		} else {
			//次の生徒がいない場合の処理
			$('.student-name').text("");
			$('.student-request').text("");
			$('#student-skype-id').text("");
			current_student_id = -1;

			$("#break-last-modal").modal({
				backdrop: "static"
			});
			// モーダルウィンドウを開く
			$("#break-last-modal").modal('show');
		}
		timer.deleteTimer();	//タイマーを削除する
		$("#student-" + students[0].student.id).remove();	//先頭の生徒を削除する
		students.shift();
	});

	//生徒リストのリジェクトボタンを押したときの処理
	$(document).on("click", "#student-list button", function () {
		const $tr = $(this).closest("tr");		//押されたボタンから一番近いtr要素を取得する
		const studentId = $tr.attr("value");	//生徒番号をdomから取得
		students = students.filter((filter_student) => {
			return filter_student.student.id != studentId
		});
		echo.invoke("rejectRoom", roomId, studentId);	//RoomHubクラスのrejectRoomメソッドを呼び出す（引数は順番にルーム番号、生徒番号）
		$tr.remove();	//対象の要素を削除
	});

	// 接続を開始
	connection.start(function () {
		//サーバーのJoinTeacherメソッドを実行し、講師として登録する
		echo.invoke("JoinTeacher", roomId);
	});

	//タイマーの始動
	/*counter.setState(Status.Restart);
	 counter.startTimer();

	//タイマーの一時停止処理
	var flag = 0;
	$("#Timertext").click(function () {
		if (flag == 0) {
			$("#Timertext").text("再開");
			counter.setState(Status.Stop);
			counter.stopTimer();
			flag = 1;
		} else {
			$("#Timertext").text("一時停止");
			counter.setState(Status.Restart);
			counter.startTimer();
			flag = 0;
		}
	})*/
});