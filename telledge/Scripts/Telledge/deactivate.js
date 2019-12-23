$(() => {
	//チェックボックスを選択したときに実行する
	$('.agreement-checkbox').click(() => {
		isChecked = true;
		$('.agreement-checkbox').each((i, element) => {
			console.log(element);
			if (!($(element).prop('checked'))) {
				isChecked = false;	//未チェックのボックスを発見した場合、falseを評価する
			}
		});
		if (isChecked == true) {	//未チェックのボタンが存在しなかった場合、ボタンを有効にする
			$('#inactivedate-button').removeAttr('disabled');
		} else {
			$('#inactivedate-button').attr({ disabled: 'disabled' });
		};
	});
});
