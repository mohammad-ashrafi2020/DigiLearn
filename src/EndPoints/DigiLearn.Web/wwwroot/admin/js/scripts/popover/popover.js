/*=========================================================================================
    File Name: popover.js
    Description: Popovers are an updated version, which don’t rely on images,
                use CSS3 for animations, and data-attributes for local title storage.
==========================================================================================*/
(function (window, document, $) {
	'use strict';
	$('[data-toggle="popover"]').popover();


	/******************/
	// Popover events //
	/******************/

	// onShow event
	$('#show-popover').popover({
		title: 'رویداد Show',
		content: 'لورم ایپسوم متن ساختگی با تولید سادگی نا مفهوم از صنعت چاپ',
		trigger: 'click',
		placement: 'left'
	}).on('show.bs.popover', function () {
		alert('رویداد Show فراخوانی شد.');
	});

	// onShown event
	$('#shown-popover').popover({
		title: 'رویداد Shown',
		content: 'لورم ایپسوم متن ساختگی با تولید سادگی نا مفهوم از صنعت چاپ',
		trigger: 'click',
		placement: 'bottom'
	}).on('shown.bs.popover', function () {
		alert('رویداد Shown فراخوانی شد.');
	});

	// onHide event
	$('#hide-popover').popover({
		title: 'رویداد Hide',
		content: 'لورم ایپسوم متن ساختگی با تولید سادگی نا مفهوم از صنعت چاپ',
		trigger: 'click',
		placement: 'bottom'
	}).on('hide.bs.popover', function () {
		alert('رویداد Hide فراخوانی شد.');
	});

	// onHidden event
	$('#hidden-popover').popover({
		title: 'رویداد Hidden',
		content: 'لورم ایپسوم متن ساختگی با تولید سادگی نا مفهوم از صنعت چاپ',
		trigger: 'click',
		placement: 'right'
	}).on('hidden.bs.popover', function () {
		alert('رویداد Hidden فراخوانی شد.');
	});

	/*******************/
	// Tooltip methods //
	/*******************/

	// Show method
	$('#show-method').on('click', function () {
		$(this).popover('show');
	});
	// Hide method
	$('#hide-method').on('mouseenter', function () {
		$(this).popover('show');
	});
	$('#hide-method').on('click', function () {
		$(this).popover('hide');
	});
	// Toggle method
	$('#toggle-method').on('click', function () {
		$(this).popover('toggle');
	});
	// Dispose method
	$('#dispose').on('click', function () {
		$('#dispose-method').popover('dispose');
	});


	/* Trigger*/
	$('.manual').on('click', function () {
		$(this).popover('show');
	});
	$('.manual').on('mouseout', function () {
		$(this).popover('hide');
	});

})(window, document, jQuery);