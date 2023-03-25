/*=========================================================================================
    File Name: picker-date-time.js
    Description: Pick a date/time Picker, Date Range Picker JS
==========================================================================================*/
(function (window, document, $) {
	'use strict';
	  
	// ************************//
  	// * Shamsi Date Picker *//
  	// ************************//

	$('.shamsi-datepicker').datepicker({
		dateFormat: "yy/mm/dd",
		showOtherMonths: true,
		selectOtherMonths: false
	});

	$('.shamsi-datepicker-list').datepicker({
		dateFormat: "yy/mm/dd",
		showOtherMonths: true,
		selectOtherMonths: true,
		changeMonth: true,
		changeYear: true,
		showButtonPanel: true
	});

	$('.shamsi-datepicker-limited').datepicker({
		dateFormat: "yy/mm/dd",
		showOtherMonths: true,
		selectOtherMonths: true,
		minDate: 0,
		maxDate: "+14D"
	});

  	// ************************//
  	// * Pick-a-date Picker *//
  	// ************************//
  	// Basic date
  	$('.pickadate').pickadate();

  	// Format Date Picker
  	$('.format-picker').pickadate({
  		format: 'd mmmm yyyy'
  	});

  	// Date limits
  	$('.pickadate-limits').pickadate({
  		min: [2019, 7, 20],
  		max: [2019, 7, 28]
  	});

  	// Disabled Dates & Weeks

  	$('.pickadate-disable').pickadate({
  		disable: [
  			1,
  			[2019, 6, 6],
  			[2019, 6, 20]
  		]
  	});

  	// Picker Translations
  	$('.pickadate-translations').pickadate({
  		formatSubmit: 'dd/mm/yyyy',
  		monthsFull: ['Janvier', 'Février', 'Mars', 'Avril', 'Mai', 'Juin', 'Juillet', 'Août', 'Septembre', 'Octobre', 'Novembre', 'Décembre'],
  		monthsShort: ['Jan', 'Fev', 'Mar', 'Avr', 'Mai', 'Juin', 'Juil', 'Aou', 'Sep', 'Oct', 'Nov', 'Dec'],
  		weekdaysShort: ['Dim', 'Lun', 'Mar', 'Mer', 'Jeu', 'Ven', 'Sam'],
  		today: 'aujourd\'hui',
  		clear: 'clair',
  		close: 'Fermer'
  	});

  	// Month Select Picker
  	$('.pickadate-months').pickadate({
  		selectYears: false,
  		selectMonths: true
  	});

  	// Month and Year Select Picker
  	$('.pickadate-months-year').pickadate({
  		selectYears: true,
  		selectMonths: true
  	});

  	// Short String Date Picker
  	$('.pickadate-short-string').pickadate({
  		weekdaysShort: ['ی', 'د', 'س', 'چ', 'پ', 'ج', 'ش']
  	});

  	// Change first weekday
  	$('.pickadate-firstday').pickadate({
  		firstDay: 1
  	});

  	// Inline Date Picker
  	$('.inlineDatePicker').pickadate({
  		container: '#inlineDatePicker-container'
  	});

  	// ************************//
  	// * Pick a Time Picker *//
  	// ************************//
  	// Basic time
  	$('.pickatime').pickatime();

  	// Format options
  	$('.pickatime-format').pickatime({
  		// Escape any “rule” characters with an exclamation mark (!).
  		format: 'زمان انتخاب شده: h:i a',
  		formatLabel: 'HH:i a',
  		formatSubmit: 'HH:i',
  		hiddenPrefix: 'prefix__',
  		hiddenSuffix: '__suffix'
  	});


  	// Format options
  	$('.pickatime-formatlabel').pickatime({
  		formatLabel: function (time) {
  			var hours = (time.pick - this.get('now').pick) / 60,
  				label = hours < 0 ? ' ساعت تا الان' : hours > 0 ? ' ساعت از الان' : 'now';
  			return 'h:i a <sm!all cl!ass="d-!inl!ine-block">' + (hours ? Math.abs(hours) : '') + label + '</sm!all>';
  		}
  	});

  	// Min - Max Time to select
  	$('.pickatime-min-max').pickatime({

  		// Using Javascript
  		min: new Date(2015, 3, 20, 7),
  		max: new Date(2015, 7, 14, 18, 30)

  		// Using Array
  		// min: [7,30],
  		// max: [14,0]
  	});

  	// Intervals
  	$('.pickatime-intervals').pickatime({
  		interval: 150
  	});

  	// Disable Time
  	$('.pickatime-disable').pickatime({
  		disable: [
  			// Disable Using Integers
  			3, 5, 7, 13, 17, 21

  			/* Using Array */
  			// [0,30],
  			// [2,0],
  			// [8,30],
  			// [9,0]
  		]
  	});

  	// Close on a user action
  	$('.pickatime-close-action').pickatime({
  		closeOnSelect: false,
  		closeOnClear: false
  	});

  	// ************************//
  	// * Date Range Picker *//
	// ************************//
	  
	var dateRangePickerLocaleFa = {
		"format": "YYYY/MM/DD",
		"separator": " - ",
		"applyLabel": "اعمال",
		"cancelLabel": "انصراف",
		"startLabel": 'تاریخ شروع',
		"endLabel": 'تاریخ پایان',
		"fromLabel": "از",
		"toLabel": "تا",
		"customRangeLabel": "سفارشی",
		"weekLabel": "هفته",
		"daysOfWeek": [
			"ی",
			"د",
			"س",
			"چ",
			"پ",
			"ج",
			"ش"
		],
		"monthNames": [
			"ژانویه",
			"فوریه",
			"مارس",
			"آوریل",
			"مه",
			"ژوئن",
			"جولای",
			"اوت",
			"سپتامبر",
			"اکتبر",
			"نوامبر",
			"دسامبر"
		],
		"firstDay": 6
	};

  	// Basic Date Range Picker
  	$('.daterange').daterangepicker({
		locale: dateRangePickerLocaleFa,
		opens: "left"
	});

  	// Date & Time
  	$('.datetime').daterangepicker({
  		timePicker: true,
  		timePickerIncrement: 30,
		opens: "left",
  		locale: {
			"format": "YYYY/MM/DD H:mm",
			"separator": " - ",
			"applyLabel": "اعمال",
			"cancelLabel": "انصراف",
			"startLabel": 'تاریخ شروع',
			"endLabel": 'تاریخ پایان',
			"fromLabel": "از",
			"toLabel": "تا",
			"customRangeLabel": "سفارشی",
			"weekLabel": "هفته",
			"daysOfWeek": [
				"ی",
				"د",
				"س",
				"چ",
				"پ",
				"ج",
				"ش"
			],
			"monthNames": [
				"ژانویه",
				"فوریه",
				"مارس",
				"آوریل",
				"مه",
				"ژوئن",
				"جولای",
				"اوت",
				"سپتامبر",
				"اکتبر",
				"نوامبر",
				"دسامبر"
			],
			"firstDay": 6
		}
  	});

  	// Single Date Picker
  	$('.single-daterange').daterangepicker({
  		singleDatePicker: true,
  		showDropdowns: true,
		opens: "left",
  		minYear: 1901,
		maxYear: parseInt(moment().format('YYYY'), 10),
		locale: dateRangePickerLocaleFa
  	}, function (start, end, label) {
  		var years = moment().diff(start, 'years');
  		alert("شما " + years + " سال دارید!");
  	});

  	// Date Ranges
  	$('.dateranges').daterangepicker({
  		ranges: {
  			'امروز': [moment(), moment()],
  			'دیروز': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
  			'7 روز اخیر': [moment().subtract(6, 'days'), moment()],
  			'30 روز اخیر': [moment().subtract(29, 'days'), moment()],
  			'این ماه': [moment().startOf('month'), moment().endOf('month')],
  			'آخرین ماه': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')]
		},
		opens: "left",
		locale: dateRangePickerLocaleFa
  	});

  	// Date Ranges Initially Empty
  	$('.initial-empty').daterangepicker({
  		autoUpdateInput: false,
		opens: "left",
  		locale: dateRangePickerLocaleFa
  	});

  	$('.initial-empty').on('apply.daterangepicker', function (ev, picker) {
  		$(this).val(picker.startDate.format('YYYY/MM/DD') + ' - ' + picker.endDate.format('YYYY/MM/DD'));
  	});

  	$('.initial-empty').on('cancel.daterangepicker', function (ev, picker) {
  		$(this).val('');
  	});

  	//Calendars are not linked
  	$('.timeseconds').daterangepicker({
  		timePicker: true,
  		timePickerIncrement: 30,
  		timePicker24Hour: true,
  		timePickerSeconds: true,
		opens: "left",
  		locale: {
			"format": "YYYY/MM/DD H:mm:ss",
			"separator": " - ",
			"applyLabel": "اعمال",
			"cancelLabel": "انصراف",
			"startLabel": 'تاریخ شروع',
			"endLabel": 'تاریخ پایان',
			"fromLabel": "از",
			"toLabel": "تا",
			"customRangeLabel": "سفارشی",
			"weekLabel": "هفته",
			"daysOfWeek": [
				"ی",
				"د",
				"س",
				"چ",
				"پ",
				"ج",
				"ش"
			],
			"monthNames": [
				"ژانویه",
				"فوریه",
				"مارس",
				"آوریل",
				"مه",
				"ژوئن",
				"جولای",
				"اوت",
				"سپتامبر",
				"اکتبر",
				"نوامبر",
				"دسامبر"
			],
			"firstDay": 6
		}
  	});

  	// Auto Apply Date Range
  	$('.autoapply').daterangepicker({
  		autoApply: true,
		opens: "left",
		locale: dateRangePickerLocaleFa
  	});

  	// Date Limit
  	$('.dateLimit').daterangepicker({
  		dateLimit: {
  			days: 7
		},
		opens: "left",
		locale: dateRangePickerLocaleFa
  	});

  	// Show Dropdowns
  	$('.showdropdowns').daterangepicker({
  		showDropdowns: true,
		drops: "up",
		opens: "left",
		locale: dateRangePickerLocaleFa
  	});

  	// Show Week Numbers
  	$('.showweeknumbers').daterangepicker({
		showWeekNumbers: true,
		opens: "left",
		locale: dateRangePickerLocaleFa
  	});

  	// Always Show Calendar on Ranges
  	$('.showCalRanges').daterangepicker({
  		ranges: {
  			'امروز': [moment(), moment()],
  			'دیروز': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
  			'7 روز اخیر': [moment().subtract(6, 'days'), moment()],
  			'30 روز اخیر': [moment().subtract(29, 'days'), moment()],
  			'این ماه': [moment().startOf('month'), moment().endOf('month')],
  			'آخرین ماه': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')]
  		},
		opens: "left",
		alwaysShowCalendars: true,
		locale: dateRangePickerLocaleFa
  	});

  	// Localization
  	$('.localeRange').daterangepicker({
  		ranges: {
  			"Aujourd'hui": [moment(), moment()],
  			'Hier': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
  			'Les 7 derniers jours': [moment().subtract(6, 'days'), moment()],
  			'Les 30 derniers jours': [moment().subtract(29, 'days'), moment()],
  			'Ce mois-ci': [moment().startOf('month'), moment().endOf('month')],
  			'le mois dernier': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')]
  		},
  		locale: {
  			applyLabel: "Vers l'avant",
  			cancelLabel: 'Annulation',
  			startLabel: 'Date initiale',
  			endLabel: 'Date limite',
  			customRangeLabel: 'Sélectionner une date',
  			// daysOfWeek: ['Dimanche', 'Lundi', 'Mardi', 'Mercredi', 'Jeudi', 'Vendredi','Samedi'],
  			daysOfWeek: ['Di', 'Lu', 'Ma', 'Me', 'Je', 'Ve', 'Sa'],
  			monthNames: ['Janvier', 'février', 'Mars', 'Avril', 'Маi', 'Juin', 'Juillet', 'Août', 'Septembre', 'Octobre', 'Novembre', 'Decembre'],
  			firstDay: 1
  		},
		opens: "left"
  	});

  	// Date Range Alignment
  	$('.openRight').daterangepicker({
		opens: "right", // left/right/center
		locale: dateRangePickerLocaleFa
  	});

  	// Date Range Open on Top
  	$('.drops').daterangepicker({
		drops: "up", // up/down
		opens: "left",
		locale: dateRangePickerLocaleFa
  	});

  	// Change Buttons bg-color
  	$('.buttonClass').daterangepicker({
  		drops: "up",
		opens: "left",
  		buttonClasses: "btn",
  		applyClass: "btn-success",
		cancelClass: "btn-danger",
		locale: dateRangePickerLocaleFa
  	});

  	// Inline Date Picker
  	var picker = $('.inlineDateRangePicker').daterangepicker({
		parentEl: "#daterangepicker-container",
		locale: dateRangePickerLocaleFa,
		opens: "left"
  	});

  	// To remain picker opened after date range applied
  	picker.data('daterangepicker').hide = function () {};

  	// show picker on load
  	picker.data('daterangepicker').show();


  })(window, document, jQuery);