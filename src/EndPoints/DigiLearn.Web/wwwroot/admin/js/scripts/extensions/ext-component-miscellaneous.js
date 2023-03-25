/*=========================================================================================
    File Name: ext-component-miscellaneous.js
    Description:Miscellaneous contain Clipboard, Context Menu, Idle timer and Numeral.Js components
==========================================================================================*/
/*
scrollToBottom plugin, chainable
 */

$(document).ready(function () {

	//      Copy Clipboard Script     //
	// -------------------------------

	var userText = $(".copy-to-clipboard");
	var btnCopy = $(".copy-btn");

	// copy text on click
	btnCopy.on("click", function () {
		userText.select();
		document.execCommand("copy");
	})

	//     ContextMenu Script      //
	// -------------------------------

	// Basic Context Menu
	$.contextMenu({
		selector: ".basic-context-menu",
		callback: function (key, options) {
			var r = "روی «" + key + "» کلیک کردید";
			toastr.success(r);
		},
		items: {
			"گزینه 1": {
				name: "گزینه 1"
			},
			"گزینه 2": {
				name: "گزینه 2"
			},
		}
	})

	// Left Click Trigger
	$.contextMenu({
		selector: '.left-click-context-menu',
		trigger: "left",
		callback: function (key, options) {
			var r = "روی «" + key + "» کلیک کردید";
			toastr.success(r);
		},
		items: {
			"گزینه 1": {
				name: "گزینه 1"
			},
			"گزینه 2": {
				name: "گزینه 2"
			},
		}
	});

	// Hover Trigger
	$.contextMenu({
		selector: '.hover-context-menu',
		trigger: 'hover',
		autoHide: true,
		callback: function (key, options) {
			var r = "روی «" + key + "» کلیک کردید";
			toastr.success(r);
		},
		items: {
			"گزینه 1": {
				name: "گزینه 1"
			},
			"گزینه 2": {
				name: "گزینه 2"
			},
		}
	});

	// Submenu
	$.contextMenu({
		selector: '.submenu-context-menu',
		callback: function (key, options) {
			var r = "روی «" + key + "» کلیک کردید";
			toastr.success(r);
		},
		items: {
			"گزینه 1": {
				name: "گزینه 1"
			},
			"گزینه 2": {
				name: "گزینه 2"
			},
			"زیر منو": {
				"name": "زیر منو",
				"items": {
					"زیر منوی 1": {
						"name": "زیر منوی 1"
					},
					"زیر منوی 2": {
						"name": "زیر منوی 2",
						"items": {
							"لورم": {
								"name": "لورم"
							},
							"ایپسوم": {
								"name": "ایپسوم"
							},
							"متن": {
								"name": "متن"
							}
						}
					}
				}
			}
		}
	});

	//    scroll top for idle timer   //
	// --------------------------------
	$.fn.scrollToBottom = function () {
		this.scrollTop(this[0].scrollHeight);
		return this;
	};
	//     Elements script idle timer     //
	// ------------------------------------
	var elementTimeout = 3000;
	/*
	Handle raised idle/active events
	 */
	$('.elStatus').on("idle.idleTimer", function (event, elem, obj) {
		//If you dont stop propagation it will bubble up to document event handler
		event.stopPropagation();

		$('.elStatus').val(function (i, v) {
			return v + "Idle @ " + moment().format() + " \n";
		}).removeClass("alert-success").addClass("alert-warning").scrollToBottom();

	});
	$('.elStatus').on("active.idleTimer", function (event) {
		//If you dont stop propagation it will bubble up to document event handler
		event.stopPropagation();

		$('.elStatus')
			.val(function (i, v) {
				return v + "Active @ " + moment().format() + " \n";
			}).addClass("alert-success").removeClass("alert-warning").scrollToBottom();
	});

	/*
	Handle button events
	*/
	$(".btReset").click(function () {
		$('.elStatus')
			.idleTimer("reset")
			.val(function (i, v) {
				return v + "Reset @ " + moment().format() + " \n";
			}).scrollToBottom();

		//Apply classes for default state
		if ($(".elStatus").idleTimer("isIdle")) {
			$(".elStatus").removeClass("alert-success").addClass("alert-warning");
		} else {
			$(".elStatus")
				.addClass("alert-success").removeClass("alert-warning");
		}
		$(this).blur();
		return false;
	});
	$(".btRemaining").click(function () {
		$('.elStatus').val(function (i, v) {
			return v + "Remaining: " + $(".elStatus").idleTimer("getRemainingTime") + " \n";
		}).scrollToBottom();
		$(this).blur();
		return false;
	});
	$(".btLastActive").click(function () {
		$('.elStatus')
			.val(function (i, v) {
				return v + "LastActive: " + $(".elStatus").idleTimer("getLastActiveTime") + " \n";
			}).scrollToBottom();
		$(this).blur();
		return false;
	});
	$(".btState").click(function () {
		$('.elStatus').val(function (i, v) {
			return v + "State: " + ($(".elStatus").idleTimer("isIdle") ? "idle" : "active") + " \n";
		}).scrollToBottom();
		$(this).blur();
		return false;
	});

	//Clear value if there was one cached & start time
	$('.elStatus').val('').idleTimer({
		timeout: elementTimeout,
		timerSyncId: "element-timer-demo"
	});

	//For demo purposes, show initial state
	if ($(".elStatus").idleTimer("isIdle")) {
		$(".elStatus").val(function (i, v) {
			return v + "Initial Idle @ " + moment().format() + " \n";
		}).removeClass("alert-success").addClass("alert-warning").scrollToBottom();
	} else {
		$('.elStatus')
			.val(function (i, v) {
				return v + "Initial Active @ " + moment().format() + " \n";
			}).addClass("alert-success").removeClass("alert-warning").scrollToBottom();
	}

	// Display the actual timeout on the page
	$('.elTimeout').text(elementTimeout / 1000);

	//    documents script idle timer   //
	// ---------------------------------
	var docTimeout = 5000;

	/*
	Handle raised idle/active events
	*/
	$(document).on("idle.idleTimer", function (event, elem, obj) {
		$(".docStatus")
			.val(function (i, v) {
				return v + "Idle @ " + moment().format() + " \n";
			}).removeClass("alert-success").addClass("alert-warning").scrollToBottom();
	});
	$(document).on("active.idleTimer", function (event, elem, obj, e) {
		$('.docStatus')
			.val(function (i, v) {
				return v + "Active [" + e.type + "] [" + e.target.nodeName + "] @ " + moment().format() + " \n";
			}).addClass("alert-success").removeClass("alert-warning").scrollToBottom();
	});

	/*
	Handle button events
	*/
	$(".btPause").click(function () {
		$(document).idleTimer("pause");
		$('.docStatus').val(function (i, v) {
			return v + "Paused @ " + moment().format() + " \n";
		}).scrollToBottom();
		$(this).blur();
		return false;
	});
	$(".btResume").click(function () {
		$(document).idleTimer("resume");
		$('.docStatus').val(function (i, v) {
			return v + "Resumed @ " + moment().format() + " \n";
		}).scrollToBottom();
		$(this).blur();
		return false;
	});
	$(".btElapsed").click(function () {
		$('.docStatus').val(function (i, v) {
			return v + "Elapsed (since becoming active): " + $(document).idleTimer("getElapsedTime") + " \n";
		}).scrollToBottom();
		$(this).blur();
		return false;
	});
	$(".btDestroy").click(function () {
		$(document).idleTimer("destroy");
		$('.docStatus').val(function (i, v) {
			return v + "Destroyed: @ " + moment().format() + " \n";
		}).removeClass("alert-success").removeClass("alert-warning").scrollToBottom();
		$(this).blur();
		return false;
	});
	$(".btInit").click(function () {
		// for demo purposes show init with just object
		$(document).idleTimer({
			timeout: docTimeout
		});
		$('.docStatus').val(function (i, v) {
				return v + "Init: @ " + moment().format() + " \n";
			})
			.scrollToBottom();

		//Apply classes for default state
		if ($(document).idleTimer("isIdle")) {
			$('.docStatus').removeClass("alert-success").addClass("alert-warning");
		} else {
			$('.docStatus').addClass("alert-success").removeClass("alert-warning");
		}
		$(this).blur();
		return false;
	});

	//Clear old statuses
	$('.docStatus').val('');

	//Start timeout, passing no options
	$(document).idleTimer({
		timeout: docTimeout,
		timerSyncId: "document-timer-demo"
	});

	//For demo purposes, style based on initial state
	if ($(document).idleTimer("isIdle")) {
		$(".docStatus")
			.val(function (i, v) {
				return v + "Initial Idle State @ " + moment().format() + " \n";
			}).removeClass("alert-success").addClass("alert-warning").scrollToBottom();
	} else {
		$('.docStatus')
			.val(function (i, v) {
				return v + "Initial Active State @ " + moment().format() + " \n";
			}).addClass("alert-success").removeClass("alert-warning").scrollToBottom();
	}

	// display the actual timeout on the page
	$('.docTimeout').text(docTimeout / 1000);

	//     Numeral Js  script     //
	// ----------------------------

	// default Value
	$(".dNum").text(numeral(974).value());
	// formate
	$(".fnum").text(numeral(1230974).format('0.0a'));
	// currency
	$(".fcurrecy").text(numeral(1000.234).format("$0,0.000"));
	// bytes
	$(".fbytes").text(numeral(3467479682787).format('0.000ib'));
	// percentages
	$(".fpercent").text(numeral(0.974878234).format('0.000%'));
	// time
	$(".ftime").text(numeral(63846).format('00:00:00'));
	// exponential
	$(".fexponential").text(numeral(1123456789).format('0,0e+0'));
});