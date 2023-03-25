/*=========================================================================================
	File Name: toastr.js
	Description: Toastr notifications
==========================================================================================*/
$(document).ready(function () {

	// Success Type
	$('#type-success').on('click', function () {
		toastr.success('لورم ایپسوم متن ساختگی با تولید', 'عنوان توست', {
			rtl: true,
			positionClass: 'toast-top-left'
		});
	});

	// Info Type
	$('#type-info').on('click', function () {
		toastr.info('لورم ایپسوم متن ساختگی با تولید سادگی', 'عنوان توست', {
			rtl: true,
			positionClass: 'toast-top-left'
		});
	});

	// Warning Type
	$('#type-warning').on('click', function () {
		toastr.warning('لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ و با', '', {
			rtl: true,
			positionClass: 'toast-top-left'
		});
	});

	// Error Type
	$('#type-error').on('click', function () {
		toastr.error('لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت', 'عنوان توست', {
			rtl: true,
			positionClass: 'toast-top-left'
		});
	});

	// Position Top Left
	$('#position-top-left').on('click', function () {
		toastr.info('لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت', 'بالا چپ!', {
			rtl: true,
			positionClass: 'toast-top-left',
			containerId: 'toast-top-left'
		});
	});

	// Position Top Center
	$('#position-top-center').on('click', function () {
		toastr.info('لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت', 'بالا وسط!', {
			rtl: true,
			positionClass: 'toast-top-center',
			containerId: 'toast-top-center'
		});
	});

	// Position Top Right
	$('#position-top-right').on('click', function () {
		toastr.info('لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت', 'بالا راست!', {
			rtl: true,
			positionClass: 'toast-top-right',
			containerId: 'toast-top-right'
		});
	});

	// Position Top Full Width
	$('#position-top-full').on('click', function () {
		toastr.info('لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت', 'بالا تمام عرض!', {
			rtl: true,
			positionClass: 'toast-top-full-width',
		});
	});

	// Position Bottom Left
	$('#position-bottom-left').on('click', function () {
		toastr.info('لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت', 'پایین چپ!', {
			rtl: true,
			positionClass: 'toast-bottom-left',
			containerId: 'toast-bottom-left'
		});
	});

	// Position Bottom Center
	$('#position-bottom-center').on('click', function () {
		toastr.info('لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت', 'پایین وسط!', {
			rtl: true,
			positionClass: 'toast-bottom-center',
			containerId: 'toast-bottom-center'
		});
	});

	// Position Bottom Right
	$('#position-bottom-right').on('click', function () {
		toastr.info('لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت', 'پایین راست!', {
			rtl: true,
			positionClass: 'toast-bottom-right',
			containerId: 'toast-bottom-right'
		});
	});

	// Position Bottom Full Width
	$('#position-bottom-full').on('click', function () {
		toastr.info('لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت', 'پایین تمام عرض!', {
			rtl: true,
			positionClass: 'toast-bottom-full-width'
		});
	});

	// Text Notification
	$('#text-notification').on('click', function () {
		toastr.info('لورم ایپسوم متن ساختگی با تولید', 'عنوان توست', {
			rtl: true,
			positionClass: 'toast-top-left'
		});
	});

	// Close Button
	$('#close-button').on('click', function () {
		toastr.success('لورم ایپسوم متن ساختگی با تولید', 'با دکمه بستن', {
			rtl: true,
			closeButton: true,
			positionClass: 'toast-top-left'
		});
	});

	// Progress Bar
	$('#progress-bar').on('click', function () {
		toastr.warning('لورم ایپسوم متن ساختگی با تولید', 'نوار پیشرفت', {
			rtl: true,
			progressBar: true,
			positionClass: 'toast-top-left'
		});
	});

	// Clear Toast Button
	$('#clear-toast-btn').on('click', function () {
		toastr.error('پاکسازی شود؟<br /><br /><button type="button" class="btn btn-primary clear">بله</button>', 'دکمه پاکسازی توست', {
			rtl: true,
			positionClass: 'toast-top-left'
		});
	});


	// Immediately remove current toasts without using animation
	$('#show-remove-toast').on('click', function () {
		toastr.info('لورم ایپسوم متن ساختگی با تولید', 'عنوان توست', {
			rtl: true,
			positionClass: 'toast-top-left'
		});
	});

	$('#remove-toast').on('click', function () {
		toastr.remove();
	});

	// Remove current toasts using animation
	$('#show-clear-toast').on('click', function () {
		toastr.info('لورم ایپسوم متن ساختگی با تولید', 'عنوان توست', {
			rtl: true,
			positionClass: 'toast-top-left'
		});
	});

	$('#clear-toast').on('click', function () {
		toastr.clear();
	});


	// Fast Duration
	$('#fast-duration').on('click', function () {
		toastr.success('لورم ایپسوم متن ساختگی با تولید', 'نمایش سریع', {
			rtl: true,
			showDuration: 500,
			positionClass: 'toast-top-left'
		});
	});

	// Slow Duration
	$('#slow-duration').on('click', function () {
		toastr.warning('لورم ایپسوم متن ساختگی با تولید', 'پنهان سازی آهسته', {
			rtl: true,
			hideDuration: 3000,
			positionClass: 'toast-top-left'
		});
	});

	// Timeout
	$('#timeout').on('click', function () {
		toastr.error('لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت', 'وقفه!', {
			rtl: true,
			timeOut: 5000,
			positionClass: 'toast-top-left'
		});
	});

	// Sticky
	$('#sticky').on('click', function () {
		toastr.info('لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت', 'چسبان!', {
			rtl: true,
			timeOut: 0,
			positionClass: 'toast-top-left'
		});
	});

	// Slide Down / Slide Up
	$('#slide-toast').on('click', function () {
		toastr.success('لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت', 'Slide Down / Slide Up!', {
			rtl: true,
			showMethod: "slideDown",
			hideMethod: "slideUp",
			timeOut: 2000,
			positionClass: 'toast-top-left'
		});
	});

	// Fade In / Fade Out
	$('#fade-toast').on('click', function () {
		toastr.success('لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت', 'Fade In / Fade Out!', {
			rtl: true,
			showMethod: "fadeIn",
			hideMethod: "fadeOut",
			timeOut: 2000,
			positionClass: 'toast-top-left'
		});
	});
});