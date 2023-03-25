/*=========================================================================================
	File Name: sweet-alerts.js
	Description: A beautiful replacement for javascript alerts
==========================================================================================*/
$(document).ready(function () {

	// Basic

	$('#basic-alert').on('click', function () {
		Swal.fire({
			title: 'کامپیوتر وسیله خوبیه',
			confirmButtonClass: 'btn btn-primary',
			confirmButtonText: 'باشه',
			buttonsStyling: false,
		});
	});

	$('#with-title').on('click', function () {
		Swal.fire({
			title: 'اینترنت؟',
			text: "هنوز وجود داره؟",
			confirmButtonClass: 'btn btn-primary',
			confirmButtonText: 'باشه',
			buttonsStyling: false,
		});
	});

	$('#footer-alert').on('click', function () {
		Swal.fire({
			type: 'error',
			title: 'اوپس ...',
			text: 'یه مشکلی پیش اومد!',
			footer: '<a href="#">من چرا این مشکلو دارم؟</a>',
			confirmButtonClass: 'btn btn-primary',
			confirmButtonText: 'باشه',
			buttonsStyling: false,
		});
	});

	$('#html-alert').on('click', function () {
		Swal.fire({
			title: '<strong><u>مثال</u> HTML</strong>',
			type: 'info',
			html: 'میتونید از <b>متن ضخیم</b> ، ' +
				'<a href="#" target="_blank">لینک</a> ' +
				'و سایر تگ های HTML استفاده کنین',
			showCloseButton: true,
			showCancelButton: true,
			focusConfirm: false,
			confirmButtonText: '<i class="bx bx-like"></i> عالیه!',
			confirmButtonAriaLabel: 'عالیه',
			cancelButtonText: '<i class="bx bx-dislike"></i>',
			cancelButtonAriaLabel: 'خوب نیست',
			confirmButtonClass: 'btn btn-primary',
			buttonsStyling: false,
			cancelButtonClass: 'btn btn-danger ml-1',
		});
	});

	// Position

	$('#position-top-start').on('click', function () {
		Swal.fire({
			position: 'top-start',
			type: 'success',
			title: 'کار شما ذخیره شد',
			showConfirmButton: false,
			timer: 1500,
			confirmButtonClass: 'btn btn-primary',
			buttonsStyling: false,
		});
	});

	$('#position-top-end').on('click', function () {
		Swal.fire({
			position: 'top-end',
			type: 'success',
			title: 'کار شما ذخیره شد',
			showConfirmButton: false,
			timer: 1500,
			confirmButtonClass: 'btn btn-primary',
			buttonsStyling: false,
		});
	});

	$('#position-bottom-start').on('click', function () {
		Swal.fire({
			position: 'bottom-start',
			type: 'success',
			title: 'کار شما ذخیره شد',
			showConfirmButton: false,
			timer: 1500,
			confirmButtonClass: 'btn btn-primary',
			buttonsStyling: false,
		});
	});

	$('#position-bottom-end').on('click', function () {
		Swal.fire({
			position: 'bottom-end',
			type: 'success',
			title: 'کار شما ذخیره شد',
			showConfirmButton: false,
			timer: 1500,
			confirmButtonClass: 'btn btn-primary',
			buttonsStyling: false,
		});
	});

	// Animations

	$("#bounce-in-animation").on('click', function () {
		Swal.fire({
			title: 'انیمیشن Bounce In',
			animation: false,
			customClass: 'animated bounceIn',
			confirmButtonClass: 'btn btn-primary',
			confirmButtonText: 'باشه',
			buttonsStyling: false,
		});
	});

	$("#fade-in-animation").on('click', function () {
		Swal.fire({
			title: 'انیمیشن Fade In',
			animation: false,
			customClass: 'animated fadeIn',
			confirmButtonClass: 'btn btn-primary',
			confirmButtonText: 'باشه',
			buttonsStyling: false,
		});
	});

	$("#flip-x-animation").on('click', function () {
		Swal.fire({
			title: 'انیمیشن Flip In',
			animation: false,
			customClass: 'animated flipInX',
			confirmButtonClass: 'btn btn-primary',
			confirmButtonText: 'باشه',
			buttonsStyling: false,
		});
	});

	$("#tada-animation").on('click', function () {
		Swal.fire({
			title: 'انیمیشن Tada',
			animation: false,
			customClass: 'animated tada',
			confirmButtonClass: 'btn btn-primary',
			confirmButtonText: 'باشه',
			buttonsStyling: false,
		});
	});

	$("#shake-animation").on('click', function () {
		Swal.fire({
			title: 'انیمیشن Shake',
			animation: false,
			customClass: 'animated shake',
			confirmButtonClass: 'btn btn-primary',
			confirmButtonText: 'باشه',
			buttonsStyling: false,
		});
	});

	// type

	$('#type-success').on('click', function () {
		Swal.fire({
			title: "کارت درسته!",
			text: "شما روی دکمه کلیک کردید!",
			type: "success",
			confirmButtonClass: 'btn btn-primary',
			confirmButtonText: 'باشه',
			buttonsStyling: false,
		});
	});

	$('#type-info').on('click', function () {
		Swal.fire({
			title: "اطلاعات!",
			text: "شما روی دکمه کلیک کردید!",
			type: "info",
			confirmButtonClass: 'btn btn-primary',
			confirmButtonText: 'باشه',
			buttonsStyling: false,
		});
	});

	$('#type-warning').on('click', function () {
		Swal.fire({
			title: "هشدار!",
			text: "شما روی دکمه کلیک کردید!",
			type: "warning",
			confirmButtonClass: 'btn btn-primary',
			confirmButtonText: 'باشه',
			buttonsStyling: false,
		});
	});

	$('#type-error').on('click', function () {
		Swal.fire({
			title: "خطا!",
			text: "شما روی دکمه کلیک کردید!",
			type: "error",
			confirmButtonClass: 'btn btn-primary',
			confirmButtonText: 'باشه',
			buttonsStyling: false,
		});
	});

	// options

	$('#custom-icon').on('click', function () {
		Swal.fire({
			title: 'عالیه!',
			text: 'مودال با تصویر سفارشی.',
			imageUrl: '/admin/images/slider/04.jpg',
			imageWidth: 400,
			imageHeight: 200,
			imageAlt: 'تصویر سفارشی',
			animation: false,
			confirmButtonClass: 'btn btn-primary',
			confirmButtonText: 'باشه',
			buttonsStyling: false,
		});
	});

	$('#auto-close').on('click', function () {
		var timerInterval
		Swal.fire({
			title: 'هشدار خود بسته شونده!',
			html: 'من تا <strong></strong> میلی ثانیه بسته میشم.',
			timer: 2000,
			confirmButtonClass: 'btn btn-primary',
			confirmButtonText: 'باشه',
			buttonsStyling: false,
			onBeforeOpen: function () {
				Swal.showLoading();
				timerInterval = setInterval(function () {
					Swal.getContent().querySelector('strong').textContent = Swal.getTimerLeft();
				}, 100);
			},
			onClose: function () {
				clearInterval(timerInterval);
			}
		}).then(function (result) {
			if (
				// Read more about handling dismissals
				result.dismiss === Swal.DismissReason.timer
			) {
				console.log('I was closed by the timer');
			}
		});
	});

	$('#outside-click').on('click', function () {
		Swal.fire({
			title: 'در خارج از کادر کلیک کنید!',
			text: 'این یه پیام عالیه!',
			allowOutsideClick: true,
			confirmButtonClass: 'btn btn-primary',
			confirmButtonText: 'باشه',
			buttonsStyling: false,
		});
	});

	$('#prompt-function').on('click', function () {
		Swal.mixin({
			input: 'text',
			showCancelButton: true,
			progressSteps: ['1', '2', '3'],
			confirmButtonClass: 'btn btn-primary',
			confirmButtonText: 'بعدی &larr;',
			buttonsStyling: false,
			cancelButtonClass: "btn btn-danger ml-1",
			cancelButtonText: 'انصراف'
		}).queue([
			{
				title: 'سوال 1',
				text: 'کار با مودال ها خیلی راحته'
			},
			'سوال 2',
			'سوال 3'
		]).then(function (result) {
			if (result.value) {
				Swal.fire({
					title: 'انجام شد!',
					html: 'جواب های شما: <pre><code>' +
						JSON.stringify(result.value) +
						'</code></pre>',
					confirmButtonClass: 'btn btn-primary',
					confirmButtonText: 'عالیه!'
				});
			}
		});
	});

	$('#ajax-request').on('click', function () {
		Swal.fire({
			title: 'یک کاربر جستجو کنید',
			input: 'text',
			confirmButtonClass: 'btn btn-primary',
			buttonsStyling: false,
			inputAttributes: {
				autocapitalize: 'off'
			},
			showCancelButton: true,
			confirmButtonText: 'جستجو',
			showLoaderOnConfirm: true,
			cancelButtonClass: "btn btn-danger ml-1",
			cancelButtonText: 'انصراف',
			preConfirm: function (login) {
				return fetch("https://api.github.com/users/" + login)
					.then(function (response) {
						if (!response.ok) {
							console.log(response);
							throw new Error(response.statusText);
						}
						return response.json();
					})
					.catch(function (error) {
						Swal.showValidationMessage(
							"درخواست ناموفق:  " + error
						);
					});
			},
			allowOutsideClick: function () {
				return !Swal.isLoading();
			}
		}).then(function (result) {
			if (result.value) {
				Swal.fire({
					title: "آواتار " + result.value.login,
					imageUrl: result.value.avatar_url
				});
			}
		});
	});

	// confirm options

	$('#confirm-text').on('click', function () {
		Swal.fire({
			title: 'آیا مطمئنید؟',
			text: "این عمل قابل بازگشت نخواهد بود!",
			type: 'warning',
			showCancelButton: true,
			confirmButtonText: 'تایید',
			confirmButtonClass: 'btn btn-primary',
			cancelButtonClass: 'btn btn-danger ml-1',
			cancelButtonText: 'انصراف',
			buttonsStyling: false,
		}).then(function (result) {
			if (result.value) {
				Swal.fire({
					type: "success",
					title: 'حذف شد!',
					text: 'فایل شما حذف شد.',
					confirmButtonClass: 'btn btn-success',
					confirmButtonText: 'باشه',
				});
			}
		});
	});

	$('#confirm-color').on('click', function () {
		Swal.fire({
			title: 'آیا مطمئنید؟',
			text: "این عمل قابل بازگشت نخواهد بود!",
			type: 'warning',
			showCancelButton: true,
			confirmButtonText: 'بله ، حذف کن!',
			confirmButtonClass: 'btn btn-warning',
			cancelButtonClass: 'btn btn-danger ml-1',
			cancelButtonText: 'انصراف',
			buttonsStyling: false,
		}).then(function (result) {
			if (result.value) {
				Swal.fire({
					type: "success",
					title: 'حذف شد!',
					text: 'فایل شما حذف شد.',
					confirmButtonClass: 'btn btn-success',
					confirmButtonText: 'باشه',
				});
			} else if (result.dismiss === Swal.DismissReason.cancel) {
				Swal.fire({
					title: 'لغو شد',
					text: 'فایل فرضی شما در امان است :)',
					type: 'error',
					confirmButtonClass: 'btn btn-success',
					confirmButtonText: 'باشه',
				});
			}
		});
	});

});