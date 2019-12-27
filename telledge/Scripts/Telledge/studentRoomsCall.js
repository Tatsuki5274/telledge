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
	console.log("callbacked!");
});
con.setCallback(Status.Extend, () => {
	$('#timer-count').css('color', 'red');
	$('#timer-status').css('color', 'red');
	$('#timer-status').text("延長時間");
});
con.setState(Status.Essential);	//最低通話として処理
con.setTimer()


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
		console.log(arg);
		if (arg.student_id == studentId) {
			//リジェクトされたのが自分ならば
			console.log("you are rejected...");
		}
		else {
			//リジェクトされたのが他人ならば
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