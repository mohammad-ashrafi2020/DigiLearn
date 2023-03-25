/*=========================================================================================
    File Name: dashboard-analytics.js
    Description: dashboard analytics page content with Apexchart Examples
==========================================================================================*/

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

$(window).on("load", function () {

	var $primary = '#5A8DEE';
	var $success = '#39DA8A';
	var $danger = '#FF5B5C';
	var $warning = '#FDAC41';
	var $info = '#00CFDD';
	var $label_color = '#475f7b';
	var $primary_light = '#E2ECFF';
	var $danger_light = '#ffeed9';
	var $gray_light = '#828D99';
	var $sub_label_color = "#596778";
	var $radial_bg = "#e7edf3";


	// Radial-Success-chart
	// --------------------------------
	var radialSuccessoptions = {
		chart: {
			height: 40,
			width: 40,
			type: "radialBar"
		},
		grid: {
			show: false,
			padding: {
				left: -30,
				right: -30,
				top: 0,
			}
		},
		series: [30],
		colors: [$success],
		plotOptions: {
			radialBar: {
				hollow: {
					size: "30%"
				},
				dataLabels: {
					showOn: "always",
					name: {
						show: false
					},
					value: {
						show: false,
					}
				}
			}
		},
		fill: {
			type: 'gradient',
			gradient: {
				shade: 'light',
				type: "horizontal",
				gradientToColors: [$success],
				opacityFrom: 1,
				opacityTo: 0.8,
				stops: [0, 70, 100]
			}
		},
		stroke: {
			lineCap: "round",
		}
	};
	var radialSuccessChart = new ApexCharts(
		document.querySelector("#radial-success-chart"),
		radialSuccessoptions
	);

	radialSuccessChart.render();

	// Radial-Warning-chart
	// --------------------------------
	var radialWarningoptions = {
		chart: {
			height: 40,
			width: 40,
			type: "radialBar"
		},
		grid: {
			show: false,
			padding: {
				left: -30,
				right: -30,
				top: 0,
			}
		},
		series: [80],
		colors: [$warning],
		plotOptions: {
			radialBar: {
				hollow: {
					size: "30%"
				},
				dataLabels: {
					showOn: "always",
					name: {
						show: false
					},
					value: {
						show: false,
					}
				}
			}
		},
		fill: {
			type: 'gradient',
			gradient: {
				shade: 'light',
				type: "horizontal",
				gradientToColors: [$warning],
				opacityFrom: 1,
				opacityTo: 0.8,
				stops: [0, 70, 100]
			}
		},
		stroke: {
			lineCap: "round",
		}
	};
	var radialWarningChart = new ApexCharts(
		document.querySelector("#radial-warning-chart"),
		radialWarningoptions
	);

	radialWarningChart.render();

	// Radial-Danger-chart
	// --------------------------------
	var radialDangeroptions = {
		chart: {
			height: 40,
			width: 40,
			type: "radialBar",
		},
		grid: {
			show: false,
			padding: {
				left: -30,
				right: -30,
				top: 0,
			}
		},
		series: [50],
		colors: [$danger],
		plotOptions: {
			radialBar: {
				hollow: {
					size: "30%"
				},
				dataLabels: {
					showOn: "always",
					name: {
						show: false
					},
					value: {
						show: false,
					}
				}
			}
		},
		fill: {
			type: 'gradient',
			gradient: {
				shade: 'light',
				type: "horizontal",
				gradientToColors: [$danger],
				opacityFrom: 1,
				opacityTo: 0.8,
				stops: [0, 70, 100]
			}
		},
		stroke: {
			lineCap: "round",
		}
	};
	var radialDangerChart = new ApexCharts(
		document.querySelector("#radial-danger-chart"),
		radialDangeroptions
	);

	radialDangerChart.render();

	// Bar Chart
	// ---------
	var analyticsBarChartOptions = {
		chart: {
			height: 260,
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
		colors: [$primary, $primary_light],
		fill: {
			type: 'gradient',
			gradient: {
				shade: 'light',
				type: "vertical",
				inverseColors: true,
				opacityFrom: 1,
				opacityTo: 1,
				stops: [0, 70, 100]
			},
		},
		series: [{
			name: '1399',
			data: [80, 95, 150, 210, 140, 230, 300, 280, 130]
		}, {
			name: '1398',
			data: [50, 70, 130, 180, 90, 180, 270, 220, 110]
		}],
		xaxis: {
			categories: ['فروردین', 'اردیبهشت', 'خرداد', 'تیر', 'مرداد', 'شهریور', 'مهر', 'آبان', 'آذر'],
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
			max: 300,
			tickAmount: 3,
			labels: {
				style: {
					color: $gray_light
				}
			}
		},
		legend: {
			show: false
		},
		tooltip: {
			y: {
				formatter: function (val) {
					return val + " هزار تومان"
				}
			}
		}
	}

	var analyticsBarChart = new ApexCharts(
		document.querySelector("#analytics-bar-chart"),
		analyticsBarChartOptions
	);

	analyticsBarChart.render();

	// Success Line Chart
	// -----------------------------
	var successLineChartOption = {
		chart: {
			height: 100,
			type: 'line',
			toolbar: {
				show: false
			}
		},
		grid: {
			show: false,
			padding: {
				bottom: -20,
			}
		},
		colors: [$success],
		dataLabels: {
			enabled: false,
		},
		stroke: {
			width: 3,
			curve: 'smooth'
		},
		series: [{
			name: 'سری 1',
			data: [50, 0, 50, 40, 90, 0, 40, 25, 80, 40, 45]
		}],
		xaxis: {
			show: false,
			labels: {
				show: false
			},
			axisBorder: {
				show: false
			}
		},
		yaxis: {
			show: false
		},
	}

	var successLineChart = new ApexCharts(
		document.querySelector("#success-line-chart"),
		successLineChartOption
	);
	successLineChart.render();

	// Donut Chart
	// ---------------------
	var donutChartOption = {
		chart: {
			width: 200,
			type: 'donut',
		},
		dataLabels: {
			enabled: false
		},
		series: [80, 30, 60],
		labels: ["اجتماعی", "ایمیل", "جستجو"],
		stroke: {
			width: 0,
			lineCap: 'round',
		},
		colors: [$primary, $info, $warning],
		plotOptions: {
			pie: {
				donut: {
					size: '90%',
					labels: {
						show: true,
						name: {
							show: true,
							fontSize: '15px',
							colors: $sub_label_color,
							offsetY: 15,
						},
						value: {
							show: true,
							fontSize: '26px',
							color: $label_color,
							offsetY: -25,
							formatter: function (val) {
								return val
							}
						},
						total: {
							show: true,
							label: 'بازدید',
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

	var donutChart = new ApexCharts(
		document.querySelector("#donut-chart"),
		donutChartOption
	);

	donutChart.render();

	// Stacked Bar Nagetive Chart
	// ----------------------------------
	var barNegativeChartoptions = {
		chart: {
			height: 110,
			stacked: true,
			type: 'bar',
			toolbar: {
				show: false
			},
			sparkline: {
				enabled: true,
			},
		},
		plotOptions: {
			bar: {
				columnWidth: '20%',
				endingShape: 'rounded',
			},
			distributed: true,
		},
		colors: [$primary, $warning],
		series: [{
			name: 'مشتریان جدید',
			data: [75, 150, 225, 200, 35, 50, 150, 180, 50, 150, 240, 140, 75, 35, 60, 120]
		}, {
			name: 'مشتریان ثابت',
			data: [-100, -55, -40, -120, -70, -40, -60, -50, -70, -30, -60, -40, -50, -70, -40, -50],
		}],
		grid: {
			show: false,
		},
		legend: {
			show: false,
		},
		dataLabels: {
			enabled: false
		},
		tooltip: {
			x: {
				show: false
			}
		},
	}

	var barNegativeChart = new ApexCharts(
		document.querySelector("#bar-negative-chart"),
		barNegativeChartoptions
	);

	barNegativeChart.render();

	// Primary Line Chart
	// -----------------------------
	var primaryLineChartOption = {
		chart: {
			height: 40,
			// width: 180,
			type: 'line',
			toolbar: {
				show: false
			},
			sparkline: {
				enabled: true,
			},
		},
		grid: {
			show: false,
			padding: {
				bottom: 5,
				top: 5,
				left: 10,
				right: 0
			}
		},
		colors: [$primary],
		dataLabels: {
			enabled: false,
		},
		stroke: {
			width: 3,
			curve: 'smooth'
		},
		series: [{
			name: 'سری 1',
			data: [50, 100, 0, 60, 20, 30]
		}],
		fill: {
			type: 'gradient',
			gradient: {
				shade: 'dark',
				type: "horizontal",
				gradientToColors: [$primary],
				opacityFrom: 0,
				opacityTo: 0.9,
				stops: [0, 30, 70, 100]
			}
		},
		xaxis: {
			show: false,
			labels: {
				show: false
			},
			axisBorder: {
				show: false
			}
		},
		yaxis: {
			show: false
		},
	}

	var primaryLineChart = new ApexCharts(
		document.querySelector("#primary-line-chart"),
		primaryLineChartOption
	);
	primaryLineChart.render();

	// Warning Line Chart
	// -----------------------------
	var warningLineChartOption = {
		chart: {
			height: 40,
			// width: 90,
			type: 'line',
			toolbar: {
				show: false
			},
			sparkline: {
				enabled: true,
			},
		},
		grid: {
			show: false,
			padding: {
				bottom: 5,
				top: 5,
				left: 10,
				right: 0
			}
		},
		colors: [$warning],
		dataLabels: {
			enabled: false,
		},
		stroke: {
			width: 3,
			curve: 'smooth'
		},
		series: [{
			name: 'سری 1',
			data: [30, 60, 30, 80, 20, 70]
		}],
		fill: {
			type: 'gradient',
			gradient: {
				shade: 'dark',
				type: "horizontal",
				gradientToColors: [$warning],
				opacityFrom: 0,
				opacityTo: 0.9,
				stops: [0, 30, 70, 100]
			}
		},
		xaxis: {
			show: false,
			labels: {
				show: false
			},
			axisBorder: {
				show: false
			}
		},
		yaxis: {
			show: false
		},
	}

	var warningLineChart = new ApexCharts(
		document.querySelector("#warning-line-chart"),
		warningLineChartOption
	);
	warningLineChart.render();

	// Profit Primary Chart
	// --------------------------------
	var profitPrimaryOptions = {
		chart: {
			height: 40,
			width: 40,
			type: "radialBar",
			sparkline: {
				show: true
			}
		},
		grid: {
			show: false,
			padding: {
				left: -30,
				right: -30,
				top: 0,
				bottom: -70
			}
		},
		series: [50],
		colors: [$primary],
		plotOptions: {
			radialBar: {
				hollow: {
					size: "30%"
				},
				dataLabels: {
					showOn: "always",
					name: {
						show: false
					},
					value: {
						show: false,
					}
				}
			}
		},
		stroke: {
			lineCap: "round",
		}
	};
	var profitPrimaryChart = new ApexCharts(
		document.querySelector("#profit-primary-chart"),
		profitPrimaryOptions
	);

	profitPrimaryChart.render();


	// Profit Info Chart
	// --------------------------------
	var profitInfoOptions = {
		chart: {
			height: 40,
			width: 40,
			type: "radialBar",
			sparkline: {
				show: true
			}
		},
		grid: {
			show: false,
			padding: {
				left: -30,
				right: -30,
				top: 0,
				bottom: -70
			}
		},
		series: [70],
		colors: [$info],
		plotOptions: {
			radialBar: {
				hollow: {
					size: "30%"
				},
				dataLabels: {
					showOn: "always",
					name: {
						show: false
					},
					value: {
						show: false,
					}
				}
			}
		},
		stroke: {
			lineCap: "round",
		}
	};
	var profitInfoChart = new ApexCharts(
		document.querySelector("#profit-info-chart"),
		profitInfoOptions
	);

	profitInfoChart.render();

	// Registration Chart
	// -------------------
	var registrationChartoptions = {
		chart: {
			type: 'bar',
			height: 60,
			width: 120,
			sparkline: {
				enabled: true
			},
			toolbar: {
				show: false
			},
		},
		states: {
			hover: {
				filter: 'none'
			}
		},
		colors: [$danger_light, $danger_light, $danger_light, $danger_light, $warning, $danger_light],
		series: [{
			name: 'جلسات',
			data: [3, 7, 5, 15, 9, 8, 12]
		}],
		grid: {
			show: false,
			padding: {
				left: 0,
				right: 0
			}
		},

		plotOptions: {
			bar: {
				columnWidth: '80%',
				distributed: true,
			}
		},
		tooltip: {
			x: {
				show: false
			}
		},
		xaxis: {
			type: 'numeric',
		}
	}

	var registrationChart = new ApexCharts(
		document.querySelector("#registration-chart"),
		registrationChartoptions
	);

	registrationChart.render();

	// Sales Chart
	// ---------------------
	var salesChartOptions = {
		chart: {
			height: 100,
			type: 'bar',
			stacked: true,
			toolbar: {
				show: false
			}
		},
		grid: {
			show: false,
			padding: {
				left: 0,
				right: 0,
				top: -20,
				bottom: -15
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
			show: false
		},
		dataLabels: {
			enabled: false
		},
		colors: [$primary, $primary_light],
		series: [{
			name: '1399',
			data: [80, 40, 30, 90, 20, 50, 95]
		}, {
			name: '1398',
			data: [20, 60, 70, 10, 80, 50, 5]
		}],
		xaxis: {
			categories: ['ی', 'د', 'س', 'چ', 'پ', 'ج', 'ش'],
			axisBorder: {
				show: false
			},
			axisTicks: {
				show: false
			},
			labels: {
				style: {
					colors: $gray_light
				},
				offsetY: -5
			}
		},
		yaxis: {
			show: false,
			floating: true,
		},
		tooltip: {
			x: {
				show: false,
			},
		}
	}

	var salesChart = new ApexCharts(
		document.querySelector("#sales-chart"),
		salesChartOptions
	);

	salesChart.render();

	// Growth Radial Chart
	// --------------------
	var growthChartOptions = {
		chart: {
			height: 200,
			type: 'radialBar',
			sparkline: {
				show: true
			}
		},
		grid: {
			show: false,
		},
		plotOptions: {
			radialBar: {
				size: 100,
				startAngle: -135,
				endAngle: 135,
				offsetY: 40,
				hollow: {
					size: '60%',
				},
				track: {
					strokeWidth: '90%',
					background: '#fff'
				},
				dataLabels: {
					value: {
						offsetY: -20,
						color: '#475f7b',
						fontSize: '26px'
					},
					name: {
						fontSize: '15px',
						color: "#596778",
						offsetY: 22
					},
				}
			},
		},
		colors: [$danger],
		fill: {
			type: 'gradient',
			gradient: {
				shade: 'dark',
				type: 'horizontal',
				shadeIntensity: 0.5,
				gradientToColors: [$primary],
				inverseColors: true,
				opacityFrom: 1,
				opacityTo: 1,
				stops: [0, 100]
			},
		},
		stroke: {
			dashArray: 3
		},
		series: [78],
		labels: ['رشد'],
	}

	var growthChart = new ApexCharts(
		document.querySelector("#growth-Chart"),
		growthChartOptions
	);

	growthChart.render();


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

});