/*
 * 構造例
 * <タグ id="parent_selector引数">
 *	<タグ id="timer-status"></タグ>
 *	<タグ id="timer-count"></タグ>
 * </タグ>
 */

const CounterStatus = {
	Undefined: 0,
	NotStarted: 1,
	Stop: 2,
	Restart: 3,
	AllDone: 4
};

class Counter{
	constructor() {
		this.time = 0;
		this.status = CounterStatus.NotStarted;
		this.callback = {};
	}

	setState(statusCode) {
		this.status = statusCode;
		if (this.status == CounterStatus.NotStarted) {
			//開始前の処理
		}
		if (this.status == CounterStatus.Stop) {

		}
		else if (this.status == CounterStatus.Restart) {

		}
		else if (this.status == CounterStatus.AllDone) {
			//すべての処理が完了したときの処理
		}
		else {
			this.status = CounterStatus.Undefined;
		}
		const callback = this.callback[this.status.toString(10)];
		if (typeof (callback) == "function") {
			callback();
		}
		else {
			console.log("[information] Callback function is not defined at " + CounterStatus[this.status] + " from Timer.js");
		}
	}

	setCallback(keyState, object) {
		//this.callback[keyState.toString(10)] = object;
	}
	getState() {
		return this.status;
	}
	showTime() {
		//secを適切な形に変換して表示する
		const min = this.time / 60;
		const sec = this.time % 60;
		$('#timer-counter').text(('00' + parseInt(min)).slice(-2) + ":" + ('00' + parseInt(sec)).slice(-2));
	}

	startTimer() {
		//secを増やす
		this.interval = setInterval(() => {
			this.showTime();
			this.time++;
		}, 1000);
	}

	stopTimer() {
		clearInterval(this.interval);
		this.status = CounterStatus.Stop;
		this.setState(this.status);
	}

	restartTimer() {
		this.status = CounterStatus.Restart;
		//secを増やす
		this.interval = setInterval(() => {
			this.showTime();
			this.time++;
		}, 1000);
	}
}