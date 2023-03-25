/*=========================================================================================
    File Name: page-coming-soon.js
    Description: Coming Soon
==========================================================================================*/

/*******************************
 *       js of Countdown        *
 ********************************/

$(document).ready(function () {

	// Set countdown target to 5 days after today for demo purposes
	var targetDate = new Date();
	targetDate.setDate(targetDate.getDate()+5);

	var dd = targetDate.getDate();
	var mm = targetDate.getMonth() + 1;
	var yy = targetDate.getFullYear();
	
	targetDate = yy + "/" + mm + "/" + dd;

	$('#clockFlat').countdown(targetDate).on('update.countdown', function (event) {
		$(this).html(event.strftime('' +
		'<div class="clockCard px-50 px-sm-1"> <span>%D</span> <br> <p class="bg-amber clockFormat lead px-50 px-sm-1 black"> روز </p> </div>' +
		'<div class="clockCard px-50 px-sm-1"> <span>%H</span> <br> <p class="bg-amber clockFormat lead px-50 px-sm-1 black"> ساعت </p> </div>' +
		'<div class="clockCard px-50 px-sm-1"> <span>%M</span> <br> <p class="bg-amber clockFormat lead px-50 px-sm-1 black"> دقیقه </p> </div>' +
		'<div class="clockCard px-50 px-sm-1"> <span>%S</span> <br> <p class="bg-amber clockFormat lead px-50 px-sm-1 black"> ثانیه </p> </div>'));
	});

});