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