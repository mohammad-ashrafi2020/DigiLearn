/*=========================================================================================
    File Name: widgets.js
    Description: widgets page content with different types of cards
==========================================================================================*/

$(document).ready(function () {

	var $primary = '#5A8DEE';
	var $success = '#39DA8A';
	var $danger = '#FF5B5C';
	var $warning = '#FDAC41';
	var $info = '#00CFDD';
	var $label_color = '#304156';
	var $danger_light = '#FFDEDE';
	var $gray_light = '#828D99';
	var $bg_light = "#f2f4f4";

	Apex.chart = {
		fontFamily: 'inherit',
		locales: [{
			"name": "fa",
			"options": {
				"months": ["ژانویه", "فوریه", "مارس", "آوریل", "می", "ژوئن", "جولای", "آگوست", "سپتامبر", "اکتبر", "نوامبر", "دسامبر"],
				"shortMonths": ["ژانویه", "فوریه", "مارس", "آوریل", "می", "ژوئن", "جولای", "آگوست", "سپتامبر", "اکتبر", "نوامبر", "دسامبر"],
				"days": ["یکشنبه", "دوشنبه", "سه‌شنبه", "چهارشنبه", "پنجشنبه", "جمعه", "شنبه"],
				"shortDays": ["ی", "د", "س", "چ", "پ", "ج", "ش"],
				"toolbar": {
					"exportToSVG": "دریافت SVG",
					"exportToPNG": "دریافت PNG",
					"menu": "فهرست",
					"selection": "انتخاب",
					"selectionZoom": "بزرگنمایی قسمت انتخاب شده",
					"zoomIn": "بزرگ نمایی",
					"zoomOut": "کوچک نمایی",
					"pan": "جا به جایی",
					"reset": "بازنشانی بزرگ نمایی"
				}
			}
		}],
		defaultLocale: "fa"
	}
	
	// Radial Followers Chart - Primary
	// --------------------------------
	var radialPrimaryoptions = {
		chart: {
			height: 250,
			type: "radialBar"
		},
		series: [86],
		plotOptions: {
			radialBar: {
				offsetY: -10,
				size: 70,
				hollow: {
					size: "70%"
				},
				dataLabels: {
					showOn: "always",
					name: {
						show: false
					},
					value: {
						colors: [$label_color],
						fontSize: "20px",
						show: true,
						offsetY: 6
					}
				}
			}
		},
		stroke: {
			lineCap: "round",
		}
	};
	var radialPrimaryChart = new ApexCharts(
		document.querySelector("#radial-chart-primary"),
		radialPrimaryoptions
	);

	radialPrimaryChart.render();


	// Radial Users Chart - Success
	// ----------------------------
	var radialSuccessoptions = {
		chart: {
			height: 250,
			type: "radialBar"
		},
		series: [44],
		colors: [$success],
		plotOptions: {
			radialBar: {
				offsetY: -10,
				size: 70,
				hollow: {
					size: "70%"
				},

				dataLabels: {
					showOn: "always",
					name: {
						show: false
					},
					value: {
						colors: [$label_color],
						fontSize: "20px",
						show: true,
						offsetY: 6
					}
				}
			}
		},
		stroke: {
			lineCap: "round",
		}
	};
	var radialSuccessChart = new ApexCharts(
		document.querySelector("#radial-chart-success"),
		radialSuccessoptions
	);

	radialSuccessChart.render();


	// Radial Registrations Chart - Danger
	// -----------------------------------
	var radialDangeroptions = {
		chart: {
			height: 250,
			type: "radialBar"
		},
		series: [63],
		colors: [$danger],
		plotOptions: {
			radialBar: {
				offsetY: -10,
				size: 70,
				hollow: {
					size: "70%"
				},

				dataLabels: {
					showOn: "always",
					name: {
						show: false
					},
					value: {
						colors: [$label_color],
						fontSize: "20px",
						show: true,
						offsetY: 6
					}
				}
			}
		},
		stroke: {
			lineCap: "round",
		}
	};
	var radialDangerChart = new ApexCharts(
		document.querySelector("#radial-chart-danger"),
		radialDangeroptions
	);
	radialDangerChart.render();


	// Multi Radial Statistics
	// -----------------------
	var multiRadialOptions = {
		chart: {
			height: 300,
			type: "radialBar",
		},
		colors: [$primary, $warning, $danger],
		series: [75, 80, 85],
		plotOptions: {
			radialBar: {
				hollow: {
					size: "55%"
				},
				track: {
					margin: 10,
					background: '#fff',
				},
				dataLabels: {
					name: {
						fontSize: '15px',
						color: [$gray_light],
						offsetY: 22,
					},
					value: {
						fontSize: '32px',
						offsetY: -18,
					},
					total: {
						show: true,
						label: 'اینستاگرام',
						color: $gray_light
					}
				}
			}
		},
		stroke: {
			lineCap: "round",
		},
		labels: ['دیدگاه‌ها', 'اشتراک گذاری', 'پاسخ ها']
	};

	var multiradialChart = new ApexCharts(
		document.querySelector("#radial-chart-multi"),
		multiRadialOptions
	);
	multiradialChart.render();

	// Half Radial Chart
	// -----------------
	var radialHalfChartOptions = {
		chart: {
			height: 270,
			type: "radialBar",
		},
		series: [67],
		labels: ["842k"],
		colors: [$warning],
		plotOptions: {
			radialBar: {
				hollow: {
					margin: -5,
					size: '85%',
					image: '/admin/images/cards/face-regular-24.png',
					imageWidth: 32,
					imageHeight: 32,
					imageClipped: false,
				},
				startAngle: -120,
				endAngle: 130,
				track: {
					background: [$bg_light],
					startAngle: -100,
					endAngle: 120,
				},
				dataLabels: {
					name: {
						show: true,
						fontSize: "34px",
						offsetY: 50,
						color: $label_color
					},
					value: {
						fontSize: "28px",
						show: false
					}
				}
			}
		},
		stroke: {
			lineCap: "round"
		}
	};

	var radialHalfChart = new ApexCharts(
		document.querySelector("#radial-chart-half"),
		radialHalfChartOptions
	);
	radialHalfChart.render();


	// Donut Chart Spending
	// ---------------------
	var donustSpendingChart = {
		chart: {
			width: 270,
			type: 'donut',
		},
		dataLabels: {
			enabled: false
		},
		series: [44, 55, 13, 33],
		labels: ["حمل و نقل عمومی", "کافه و رستوران", "پروژه های کسب و کار", "مسافرت و تفریح"],
		stroke: {
			width: 0
		},
		colors: [$primary, $danger, $warning, $success],
		plotOptions: {
			pie: {
				donut: {
					size: '95%',
					labels: {
						show: true,
						name: {
							show: true,
							color: $gray_light,
							offsetY: 21
						},
						value: {
							show: true,
							fontSize: '32px',
							color: undefined,
							offsetY: -29,
							formatter: function (val) {
								return val
							}
						},
						total: {
							show: true,
							label: 'مجموع',
							color: $gray_light,
							formatter: function (w) {
								return w.globals.seriesTotals.reduce(function (a, b) {
									return a + b
								}, 0)
							}
						}
					}
				}
			}
		},
		legend: {
			show: false
		}
	}

	var donustChartSpending = new ApexCharts(
		document.querySelector("#donut-chart-spending"),
		donustSpendingChart
	);

	donustChartSpending.render();


	// Donut Chart Statistics
	// -----------------------

	var donustChartStatistics = {
		chart: {
			width: 280,
			type: 'donut'
		},
		dataLabels: {
			enabled: false
		},
		series: [70, 30, 40],
		labels: ["نصب", "بازدید صفحه", "کاربران فعال"],
		stroke: {
			width: 0
		},
		colors: [$primary, $warning, $danger],
		plotOptions: {
			pie: {
				donut: {
					size: '95%',
					labels: {
						show: true,
						name: {
							show: true,
							fontSize: '22px',
							color: $gray_light,
							offsetY: 20
						},
						value: {
							show: true,
							fontSize: '32px',
							color: undefined,
							offsetY: -30,
							formatter: function (val) {
								return val
							}
						},
						total: {
							show: true,
							label: 'مورد',
							color: $gray_light,
							formatter: function (w) {
								return w.globals.seriesTotals.reduce(function (a, b) {
									return a + b
								}, 0)
							}
						}
					}
				}
			}
		},
		legend: {
			show: false
		}
	}

	var donustChartStatistics = new ApexCharts(
		document.querySelector("#donut-chart-statistics"),
		donustChartStatistics
	);
	donustChartStatistics.render();


	// Bar Chart
	// ---------
	var barchartOptions = {
		chart: {
			height: 310,
			type: 'bar',
			toolbar: {
				show: false
			}
		},
		plotOptions: {
			bar: {
				horizontal: false,
				columnWidth: '20%',
				endingShape: 'rounded'
			},
		},
		legend: {
			horizontalAlign: 'right',
			offsetY: -10,
			markers: {
				radius: 50,
				height: 8,
				width: 8
			}
		},
		dataLabels: {
			enabled: false
		},
		colors: [$danger, $danger_light],
		stroke: {
			show: true,
			width: 0,
			colors: ['transparent']
		},
		series: [{
			name: '1399',
			data: [120, 180, 250, 180, 290, 390, 330, 290, 220, 330, 280, 130]
		}, {
			name: '1398',
			data: [80, 150, 210, 120, 220, 320, 270, 240, 130, 270, 210, 110]
		}],
		xaxis: {
			categories: ['فروردین', 'اردیبهشت', 'خرداد', 'تیر', 'مرداد', 'شهریور', 'مهر', 'آبان', 'آذر', 'دی', 'بهمن', 'اسفند'],
			axisBorder: {
				show: false
			},
			axisTicks: {
				show: false
			},
			labels: {
				style: {
					colors: $gray_light
				}
			}
		},
		yaxis: {
			min: 0,
			max: 400,
			tickAmount: 4,
			labels: {
				style: {
					color: $gray_light
				}
			}
		},
		fill: {
			opacity: 1
		},
		tooltip: {
			y: {
				formatter: function (val) {
					return val + " هزار تومان"
				}
			}
		}
	}

	var barChart = new ApexCharts(
		document.querySelector("#avg-order-chart"),
		barchartOptions
	);

	barChart.render();


	// Line Chart
	// ----------

	var lineChartoptions = {
		chart: {
			height: 300,
			type: 'line',
			zoom: {
				enabled: false
			},
			toolbar: {
				show: false
			},
		},
		dataLabels: {
			enabled: false
		},
		stroke: {
			curve: 'straight',
			width: 3,
		},
		legend: {
			horizontalAlign: 'right',
			position: 'top',
			markers: {
				radius: 50,
				height: 8,
				width: 8
			},
			itemMargin: {
				horizontal: 20,
			}
		},
		colors: [$info, $success],
		series: [{
			name: "بازدید ها ",
			data: [40, 45, 39, 10, 40, 27, 30, 42]
		}, {
			name: "لایک ها ",
			data: [25, 30, 31, 12, 28, 27, 22, 28]
		}],
		tooltip: {
			x: {
				show: false,
			}
		},
		xaxis: {
			categories: ['فروردین', 'اردیبهشت', 'خرداد', 'تیر', 'مرداد', 'شهریور', 'تیر', 'مرداد'],
			axisBorder: {
				show: false,
			},
			axisTicks: {
				show: false,
			},
			labels: {
				style: {
					colors: $gray_light
				}
			}
		},
		yaxis: {
			labels: {
				style: {
					color: $gray_light
				}
			}
		},
		legend: {
			show: false
		}
	}

	var lineChart = new ApexCharts(
		document.querySelector("#statistics-line-chart"),
		lineChartoptions
	);

	lineChart.render();

	// Statistics Multi Radial
	// -----------------------
	var statisticsRadialChartOptions = {
		chart: {
			height: 270,
			type: "radialBar",
		},
		colors: [$primary, $success, $danger],
		series: [85, 90, 95],
		labels: ['دسته', 'خدمات', 'حساب کاربری'],
		plotOptions: {
			radialBar: {
				hollow: {
					offsetY: -50,
					size: "50%"
				},
				track: {
					margin: 10,
					background: '#fff',
				},
				dataLabels: {
					name: {
						fontSize: '15px',
						color: [$gray_light],
						offsetY: 24,
					},
					value: {
						fontSize: '32px',
						offsetY: -16,
					},
					total: {
						show: true,
						label: 'توسعه',
					}
				}
			}
		},
		stroke: {
			lineCap: "round",
		}
	}

	var statisticsRadialChart = new ApexCharts(
		document.querySelector("#statistics-multi-radial-chart"),
		statisticsRadialChartOptions
	);
	statisticsRadialChart.render();


	// Order Activity Line Chart
	// -------------------------
	var orderActivityChartOptions = {
		chart: {
			height: 350,
			type: 'line',
			toolbar: {
				show: false
			}
		},
		colors: [$primary],
		dataLabels: {
			enabled: false,
		},
		series: [{
			name: "سفارشات ",
			data: [40, 60, 120, 100, 140, 80, 180, 180, 280, 190, 210, 190, 290, 290]
		}],
		markers: {
			size: 5,
			hover: {
				size: 7,
				sizeOffset: 7
			},
		},
		xaxis: {
			categories: [10.12, 10.12, 11.12, 11.12, 12.12, 12.12, 13.12, 13.12, 14.12, 14.12, 15.12, 15.12, 16.12, 16.12],
			axisTicks: {
				show: false
			},
			axisBorder: {
				show: false
			},
			labels: {
				style: {
					colors: $gray_light
				},
				offsetX: 3,
			}
		},
		yaxis: {
			min: 0,
			max: 300,
			tickAmount: 3,
			labels: {
				style: {
					color: $gray_light
				}
			}
		},
		grid: {
			padding: {
				left: 15
			}
		}
	}

	var orderActivityChart = new ApexCharts(
		document.querySelector("#order-activity-line-chart"),
		orderActivityChartOptions
	);
	orderActivityChart.render();

	// Followers Line Chart - Danger
	// -----------------------------
	var followerChartDangerOptions = {
		chart: {
			height: 100,
			type: 'line',
			toolbar: {
				show: false
			}
		},
		colors: [$danger],
		dataLabels: {
			enabled: false,
		},
		stroke: {
			width: 3,
		},
		series: [{
			data: [16, 10, 15, 12, 22, 20, 25]
		}],
		markers: {
			size: 0
		},
		xaxis: {
			categories: ['ش', 'ی', 'د', 'س', 'چ', 'پ', 'ج'],
			axisTicks: {
				show: true,
			},
			labels: {
				style: {
					colors: $gray_light,
				}
			},
			axisBorder: {
				height: 0.5,
			}
		},
		yaxis: {
			show: false
		},
		grid: {
			show: false
		}
	}

	var followerChartDanger = new ApexCharts(
		document.querySelector("#follower-danger-chart"),
		followerChartDangerOptions
	);
	followerChartDanger.render();

	// Followers Line Chart - Primary
	// ------------------------------
	var followerChartPrimaryOptions = {
		chart: {
			height: 100,
			type: 'line',
			toolbar: {
				show: false
			}
		},
		colors: [$primary],
		dataLabels: {
			enabled: false,
		},
		stroke: {
			width: 3,
		},
		series: [{
			data: [24, 16, 27, 23, 12, 20, 23]
		}],
		markers: {
			size: 0
		},
		xaxis: {
			categories: ['ش', 'ی', 'د', 'س', 'چ', 'پ', 'ج'],
			axisTicks: {
				show: true,
			},
			labels: {
				style: {
					colors: $gray_light,
				}
			},
			axisBorder: {
				height: 0.5,
			}
		},
		yaxis: {
			show: false
		},
		grid: {
			show: false
		}
	}

	var followerChartPrimary = new ApexCharts(
		document.querySelector("#follower-primary-chart"),
		followerChartPrimaryOptions
	);
	followerChartPrimary.render();

	// Followers Line Chart - Success
	// ------------------------------
	var followerChartSuccessOptions = {
		chart: {
			height: 100,
			type: 'line',
			toolbar: {
				show: false
			}
		},
		colors: [$success],
		dataLabels: {
			enabled: false,
		},
		stroke: {
			width: 3,
		},
		series: [{
			data: [26, 19, 23, 10, 22, 30, 21]
		}],
		markers: {
			size: 0
		},
		xaxis: {
			categories: ['ش', 'ی', 'د', 'س', 'چ', 'پ', 'ج'],
			axisTicks: {
				show: true,
			},
			labels: {
				style: {
					colors: $gray_light,
				}
			},
			axisBorder: {
				height: 0.5,
			}
		},
		yaxis: {
			show: false
		},
		grid: {
			show: false
		}
	}

	var followerChartSuccess = new ApexCharts(
		document.querySelector("#follower-success-chart"),
		followerChartSuccessOptions
	);
	followerChartSuccess.render();

	// Radar Multi Series Chart
	// ------------------------
	var radarMultiChartOptions = {
		chart: {
			height: 390,
			type: 'radar',
			toolbar: {
				show: false
			}
		},
		colors: [$warning, $danger],
		series: [{
			name: 'سری 1',
			data: [15, 25, 30, 20, 15, 15, 12, 10],
		}, {
			name: 'سری 2',
			data: [30, 20, 20, 10, 30, 30, 35, 20],
		}],
		stroke: {
			width: 0,
			curve: ['smooth', 'straight']
		},
		fill: {
			opacity: 0.85
		},
		markers: {
			size: 3,
			colors: [$warning, $danger]
		},
		dataLabels: {
			style: {
				colors: [$label_color]
			}
		},
		labels: ['یک', 'دو', 'سه', 'چهار', 'پنج', 'شش', 'هفت', 'هشت'],
		yaxis: {
			show: false,
		},
		legend: {
			show: false,
		}
	}

	var radarMultiChart = new ApexCharts(
		document.querySelector("#radar-multi-chart"),
		radarMultiChartOptions
	);
	radarMultiChart.render();

	// Gauge Chart
	// -----------
	var gaugeChartOptions = {
		chart: {
			height: 360,
			type: 'radialBar',

		},
		plotOptions: {
			radialBar: {
				hollow: {
					margin: 15,
					size: "60%"
				},
				startAngle: -135,
				endAngle: 135,
				dataLabels: {
					name: {
						fontSize: '22px',
						color: '#304156',
						offsetY: -16
					},
					value: {
						fontSize: '20px',
						color: '#828d99',
						offsetY: 7,
						formatter: function (val) {
							return val + " دقیقه";
						}
					}
				}
			}
		},
		stroke: {
			lineCap: 'round'
		},
		fill: {
			colors: [$warning]
		},
		series: [67],
		labels: ['مدت زمان'],

	}
	var gaugeChart = new ApexCharts(
		document.querySelector("#gauge-chart"),
		gaugeChartOptions
	);
	gaugeChart.render();


	// Daily Sales States - Heat Map Chart
	// -----------------------------------
	function generateData(count, yrange) {
		var i = 0,
			series = [];
		while (i < count) {
			var x = 'w' + (i + 1).toString(),
				y = Math.floor(Math.random() * (yrange.max - yrange.min + 1)) + yrange.min;

			series.push({
				x: x,
				y: y
			});
			i++;
		}
		return series;
	}
	var heatChartOptions = {
		chart: {
			height: 300,
			type: 'heatmap',
			toolbar: {
				show: false
			}
		},
		plotOptions: {
			heatmap: {
				enableShades: false,

				colorScale: {
					ranges: [{
							from: 0,
							to: 10,
							color: '#90B3F3'
						},
						{
							from: 11,
							to: 20,
							color: '#7EA6F1'
						},
						{
							from: 21,
							to: 30,
							color: '#6B9AEF'
						},
						{
							from: 31,
							to: 40,
							color: '#598DEE'
						},
						{
							from: 41,
							to: 50,
							color: '#4680EC'
						},
						{
							from: 51,
							to: 60,
							color: '#3474EA'

						}
					]
				}
			}
		},
		dataLabels: {
			enabled: false
		},
		series: [{
				name: 'یک‌شنبه',
				data: generateData(24, {
					min: 0,
					max: 60
				})
			},
			{
				name: 'دوشنبه',
				data: generateData(24, {
					min: 0,
					max: 60
				})
			},
			{
				name: 'سه‌شنبه',
				data: generateData(24, {
					min: 0,
					max: 60
				})
			},
			{
				name: 'چهارشنبه',
				data: generateData(24, {
					min: 0,
					max: 60
				})
			},
			{
				name: 'پنج‌شنبه',
				data: generateData(24, {
					min: 0,
					max: 60
				})
			},
			{
				name: 'جمعه',
				data: generateData(24, {
					min: 0,
					max: 60
				})
			},
			{
				name: 'شنبه',
				data: generateData(24, {
					min: 0,
					max: 60
				})
			}
		],
		xaxis: {
			labels: {
				show: false
			},
			axisBorder: {
				show: false
			},
			axisTicks: {
				show: false
			}
		},
		yaxis: {
			labels: {
				style: {
					color: $gray_light,
					fontSize: '15px'
				}
			}
		}
	}
	var heatChart = new ApexCharts(
		document.querySelector("#sales-heatmap-chart"),
		heatChartOptions);
	heatChart.render();

	// ================================================

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

	// Single Date Range
	//----------------------
	$('.single-daterange').datepicker({
		dateFormat: "yy/mm/dd",
		showOtherMonths: true,
		selectOtherMonths: true,
		changeMonth: true,
		changeYear: true,
		showButtonPanel: false
	});

	// Basic Date Range
	//---------------------
	$('.daterange').daterangepicker({
		locale: dateRangePickerLocaleFa
	});


	// Widget Notification - List Group
	//--------------------------
	$('.readable-mark-icon').on('click', function () {
		$(this).addClass('mark-as-read').attr('data-original-title', 'Mark as Unread').children('i').removeClass('text-light-primary').addClass('text-light-secondary');
		$('.readable-mark-icon.mark-as-read').siblings('.list-left').find('.list-title').addClass('text-bold-500');
	});
	// Default mark-as-read shown
	$('.readable-mark-icon.mark-as-read').siblings('.list-left').find('.list-title').addClass('text-bold-500');



	// Widget Todo List
	// ------------------
	// Task List Widget - for completed todo item
	$(document).on('click', '.widget-todo-item input', function () {
		$(this).closest('.widget-todo-item').toggleClass("completed");
	});

	// Drag the task
	dragula([document.getElementById("widget-todo-list")], {
		moves: function (el, container, handle) {
			return handle.classList.contains("cursor-move");
		}
	});

	// Earnings Swiper
	// ---------------
	var swiperLength = $(".swiper-slide").length;
	if (swiperLength) {
		swiperLength = Math.floor(swiperLength / 2)
	}

	// Swiper js for this page
	var mySwiper = new Swiper('.widget-earnings-swiper', {
		slidesPerView: 'auto',
		initialSlide: swiperLength,
		centeredSlides: true,
		spaceBetween: 30,
		// active slide on click
		slideToClickedSlide: true,
	});

	activeSlide(swiperLength);

	// Active slide change on swipe
	mySwiper.on('slideChange', function () {
		activeSlide(mySwiper.realIndex);
	});

	//add class active content of active slide
	function activeSlide(index) {
		var slideEl = mySwiper.slides[index]
		var slideId = $(slideEl).attr('id');
		$(".wrapper-content").removeClass("active");
		$("[data-earnings=" + slideId + "]").addClass('active');
		$("[data-earnings=" + slideId + "] .widget-earnings-scroll")[0].dispatchEvent(new Event('scroll'));
	};

	// Perfect Scrollbar
	//------------------
	// Widget - User Details -Perfect Scrollbar X
	if ($('.widget-user-details .table-responsive').length > 0) {
		var user_details = new PerfectScrollbar('.widget-user-details .table-responsive');
	}

	// Widget - Card Overlay - Perfect Scrollbar X - on initial level
	if ($('.widget-overlay-content .table-responsive').length > 0) {
		var card_overlay = new PerfectScrollbar('.widget-overlay-content .tab-pane.active .table-responsive');
	}

	// Widget - Card Overlay - Perfect Scrollbar X - on active tab-pane
	$('.widget-overlay-content a[data-toggle="tab"]').on('shown.bs.tab', function (e) {
		var card_overlay = new PerfectScrollbar('.widget-overlay-content .tab-pane.active .table-responsive');
	})

	// Widget - timeline perfect scrollbar initialization
	if ($(".widget-timeline").length > 0) {
		var widget_chat_scroll = new PerfectScrollbar(".widget-timeline", {
			wheelPropagation: false
		});
	}
	// Widget - chat area perfect scrollbar initialization
	if ($(".widget-chat-scroll").length > 0) {
		var widget_chat_scroll = new PerfectScrollbar(".widget-chat-scroll", {
			wheelPropagation: false
		});
	}
	// Widget - earnings perfect scrollbar initialization
	if ($(".widget-earnings-scroll").length > 0) {
		$(".widget-earnings-scroll").each(function(){
			var widget_earnings = new PerfectScrollbar(this,
			// horizontal scroll with mouse wheel
			{
				suppressScrollY: true,
				useBothWheelAxes: true
			});
		});
	}
	// Widget - chat autoscroll to bottom of Chat area on page initialization
	$(".widget-chat-scroll").animate({
		scrollTop: $(".widget-chat-scroll")[0].scrollHeight
	}, 800);

});

// widget page chat
// ----------------
// Add message to chat
function widgetMessageSend(source) {
	var message = $(".widget-chat-message").val();
	if (message != "") {
		var html = '<div class="chat-message"><p>' + message + '</p><div class="chat-time">3:35 ق.ظ</div></div>';
		$(".widget-chat-messages .chat:last-child .chat-body").append(html);
		$(".widget-chat-message").val("");
		$(".widget-chat-scroll").scrollTop($(".widget-chat-scroll > .chat-content").height());
	}
}
