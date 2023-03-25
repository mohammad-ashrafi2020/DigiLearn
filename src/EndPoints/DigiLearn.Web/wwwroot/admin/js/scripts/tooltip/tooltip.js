/*=========================================================================================
    File Name: tooltip.js
    Description: Tooltips are an updated version, which don’t rely on images,
                use CSS3 for animations, and data-attributes for local title storage.
==========================================================================================*/
(function (window, document, $) {
	'use strict';

	/******************/
	// Tooltip events //
	/******************/

	// onShow event
	$('#show-tooltip').tooltip({
		title: 'رویداد Show تولتیپ',
		trigger: 'click',
		placement: 'left'
	}).on('show.bs.tooltip', function () {
		alert('رویداد Show فراخوانی شد.');
	});

	// onShown event
	$('#shown-tooltip').tooltip({
		title: 'رویداد Shown تولتیپ',
		trigger: 'click',
		placement: 'top'
	}).on('shown.bs.tooltip', function () {
		alert('رویداد Shown فراخوانی شد.');
	});

	// onHide event
	$('#hide-tooltip').tooltip({
		title: 'رویداد Hide تولتیپ',
		trigger: 'click',
		placement: 'bottom'
	}).on('hide.bs.tooltip', function () {
		alert('رویداد Hide فراخوانی شد.');
	});

	// onHidden event
	$('#hidden-tooltip').tooltip({
		title: 'رویداد Hidden تولتیپ',
		trigger: 'click',
		placement: 'right'
	}).on('hidden.bs.tooltip', function () {
		alert('رویداد Hidden فراخوانی شد.');
	});


	/*******************/
	// Tooltip methods //
	/*******************/

	// Show method
	$('#show-method').on('click', function () {
		$(this).tooltip('show');
	});
	// Hide method
	$('#hide-method').on('mouseenter', function () {
		$(this).tooltip('show');
	});
	$('#hide-method').on('click', function () {
		$(this).tooltip('hide');
	});
	// Toggle method
	$('#toggle-method').on('click', function () {
		$(this).tooltip('toggle');
	});
	// Dispose method
	$('#dispose').on('click', function () {
		$('#dispose-method').tooltip('dispose');
	});

	/* Trigger*/
	$('.manual').on('click', function () {
		$(this).tooltip('show');
	});
	$('.manual').on('mouseout', function () {
		$(this).tooltip('hide');
	});

	/* Default template */
	$(".template").on('click', function () {
		console.log(
			'<div class="tooltip" role="tooltip">' +
			'<div class="tooltip-arrow"></div>' +
			'<div class="tooltip-inner"></div>' +
			'</div>'
		);
	});

	/*******************/
	// Tooltip Light   //
	/*******************/

	/* Tooltip-Light - Add Custom Class */
	$(".tooltip-light").tooltip({
		customClass: 'tooltip-light'
	});

})(window, document, jQuery);