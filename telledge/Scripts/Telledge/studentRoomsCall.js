$(function () {
	$('#raty').raty({
		target: '#review',
		starHalf: '/Assets/raty/star-half.png',
		starOff: '/Assets/raty/star-off.png',
		starOn: '/Assets/raty/star-on.png',
		hints: ['最低', '悪い', '普通', '良い', '最高']
	});
});

$(document).ready(function () {
	$("#readOnlyTags").tagit({
		readOnly: true
	}).ready(function () {
		$(this).find('.tagit-new').css('display', 'none')
	});
});

let con = new Timer(mintime, overtime);
con.setCallback(Status.Essential, function () {
	$('#endCall-button').attr('disabled', 'disabled');
});
con.setCallback(Status.Extend, () => {
	$('#endCall-button').removeAttr('disabled');

	$('#timer-count').css('color', 'red');
	$('#timer-status').css('color', 'red');
	$('#timer-status').text("延長時間");
});



// WebSocketの処理
$(function () {
	// 1. サーバとの接続オブジェクト作成
	var connection = $.hubConnection();

	// 2. Hubのプロキシ・オブジェクトを作成
	var echo = connection.createHubProxy("Room");

	// 3. サーバから呼び出される関数を登録
	echo.on("Receive", function (text) {
		alert(text);
	});

	// RoomHubクラスのrejectRoomメソッドから呼び出す処理
	echo.on("reject", (arg) => {
		if (arg.student_id == studentId) {
			//リジェクトされたのが自分ならば

			//モーダルウィンドウの外側をクリックすることでモーダルウィンドウを閉じれないようにする
			$("#reject-modal").modal({
				backdrop: "static"
			});
			// モーダルウィンドウを開く
			$("#reject-modal").modal('show');
		}
		else {
			//リジェクトされたのが他人ならば
		}
	});

	//通話終了ボタンの入力を検知したときの処理
	$("#endCall-button").click(function () {
		echo.invoke("endCall", roomId, studentId);	//ルームの終了を知らせる信号を送信する
	});

	// 通話終了の信号を受信したときの処理
	echo.on("endCall", (room_id, student_id) => {
		if (student_id == studentId) {
			//終了対象が自分なら
			$("#review-modal").modal({
				backdrop: "static"
			});
			// モーダルウィンドウを開く
			$("#review-modal").modal('show');
			echo.invoke("LeaveStudent", roomId);	//信号の受信を終了する
		}
	});

	echo.on("endRoom", () => {
		$("#end-room-modal").modal({
			backdrop: "static"
		});
		// モーダルウィンドウを開く
		$("#end-room-modal").modal('show');
	});

	//通話する人を更新する処理
	// updateCallStudent(新たに通話する生徒番号)
	echo.on("updateCallStudent", (student_id) => {
		if (student_id == studentId) {
			//通話が自分の番なら　＝　自分は通話側
			$('#waiting').addClass('hidden');
			$('#calling').removeClass('hidden');
			$('#endCall-button').attr('disabled', 'disabled');
			con.setState(Status.Essential);	//最低通話として処理
			con.setTimer();	//タイマー開始
		}
		else {
			//通話が他人なら ＝　自分は待機側
			$('#waiting').removeClass('hidden');
			$('#calling').addClass('hidden');
		}
	});

	//情報を更新するメソッド
	//updateWaitInfo(sectionの配列オブジェクト)
	echo.on("updateWaitInfo", (room, sections) => {
		if (room != null && sections != null) {
			// 自分のorderを求める
			const order = sections.find(section => section.studentId > studentId).order;

			// 自分より前に並んでいる情報を抽出する
			const selected_sections = sections.filter((section) => {
				return section.order < order;
			});

			const waitTime = selected_sections.length * (room.worstTime + room.extensionTime) / 2;
			const waitCount = selected_sections.length;

			$('#waitTime').text(waitTime);
			$('#waitCount').text(waitCount);
		}
	});

	//Sectionテーブルから情報を削除する処理を実行する
	$("#leave-button").click(function () {
		echo.invoke("leaveRoom", roomId, studentId);	//RoomHubに定義されているサーバーのleaveRoomメソッドを実行する
		location.href = '/student/rooms/index';			//該当のリンクにリダイレクトする
	});

	// 4. 接続を開始
	connection.start(function () {
		// 生徒としてHubに登録する
		echo.invoke("JoinStudent", roomId);
	});
})