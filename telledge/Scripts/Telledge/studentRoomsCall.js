$(function () {
	$('#raty').raty({
		target: '#review',
		starHalf: '/Assets/raty/star-half.png',
		starOff: '/Assets/raty/star-off.png',
		starOn: '/Assets/raty/star-on.png',
		hints: ['最低', '悪い', '普通', '良い', '最高']
	});
});