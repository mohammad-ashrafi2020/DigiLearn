/*=========================================================================================
	File Name: ext-component-tour.js
	Description: extra component tour for webpage guide
==========================================================================================*/

$(document).ready(function () {
	// tour initialize
	displayTour();
	$(window).resize(displayTour)
	var tour = new Shepherd.Tour({
		classes: 'shadow-md bg-purple-dark',
		scrollTo: true
	})

	// tour step 1
	tour.addStep('step-1', {
		text: 'این عنوان صفحه است.',
		attachTo: '.breadcrumbs-top .content-header-title bottom',
		buttons: [

			{
				text: "رد شدن",
				action: tour.complete
			},
			{
				text: 'بعدی',
				action: tour.next
			},
		]
	});
	// tour step 2
	tour.addStep('step-2', {
		text: 'اعلان های خود را اینجا مشاهده کنید.',
		attachTo: '.dropdown-notification .bx-bell bottom',
		buttons: [

			{
				text: "رد شدن",
				action: tour.complete
			},

			{
				text: "قبلی",
				action: tour.back
			},
			{
				text: 'بعدی',
				action: tour.next
			},
		]
	});
	// tour step 3
	tour.addStep('step-3', {
		text: 'برای اختیارات کاربری اینجا کلیک کنید.',
		attachTo: '.dropdown-user-link img bottom',
		buttons: [

			{
				text: "رد شدن",
				action: tour.complete
			},

			{
				text: "قبلی",
				action: tour.back
			},
			{
				text: 'بعدی',
				action: tour.next
			},
		]
	});
	// tour step 4
	tour.addStep('step-4', {
		text: 'با ما در ارتباط باشید!',
		attachTo: '.buy-now bottom',
		buttons: [

			{
				text: "قبلی",
				action: tour.back
			},

			{
				text: "پایان",
				action: tour.complete
			},
		]
	});

	// function to remove tour on small screen
	function displayTour() {
		window.resizeEvt;
		if ($(window).width() > 576) {
			$('#tour').on("click", function () {
				clearTimeout(window.resizeEvt);
				tour.start();
			})
		} else {
			$('#tour').on("click", function () {
				clearTimeout(window.resizeEvt);
				tour.cancel()
				window.resizeEvt = setTimeout(function () {
					alert("تور تنها در صفحات نمایش بزرگ کار می کند!");
				}, 250);;
			})
		}
	}
});