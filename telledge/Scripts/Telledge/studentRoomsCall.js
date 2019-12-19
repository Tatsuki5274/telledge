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
