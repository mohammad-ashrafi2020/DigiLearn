/*=========================================================================================
    File Name: chart-chartjs.js
    Description: Chartjs Examples
==========================================================================================*/

$(window).on("load", function () {

	Chart.defaults.global.defaultFontFamily = '"primary-font", "segoe ui", "tahoma"';

	var $primary = '#5A8DEE',
		$success = '#39DA8A',
		$danger = '#FF5B5C',
		$warning = '#FDAC41',
		$info = '#00CFDD',
		$label_color = '#475F7B',
		grid_line_color = '#dae1e7',
		scatter_grid_color = '#f3f3f3',
		$scatter_point_light = '#E6EAEE',
		$scatter_point_dark = '#5A8DEE',
		$white = '#fff',
		$black = '#000';

	var themeColors = [$primary, $warning, $danger, $success, $info, $label_color];

	// Line Chart
	// ------------------------------------------

	//Get the context of the Chart canvas element we want to select
	var lineChartctx = $("#line-chart");

	// Chart Options
	var linechartOptions = {
		responsive: true,
		maintainAspectRatio: false,
		legend: {
			position: 'top',
		},
		hover: {
			mode: 'label'
		},
		scales: {
			xAxes: [{
				display: true,
				gridLines: {
					color: grid_line_color,
				},
				scaleLabel: {
					display: true,
				}
			}],
			yAxes: [{
				display: true,
				gridLines: {
					color: grid_line_color,
				},
				scaleLabel: {
					display: true,
				}
			}]
		},
		title: {
			display: true,
			text: 'جمعیت جهان بر اساس منطقه (میلیون)'
		}
	};

	// Chart Data
	var linechartData = {
		labels: [1500, 1600, 1700, 1750, 1800, 1850, 1900, 1950, 1999, 2050],
		datasets: [{
			label: "آفریقا",
			data: [86, 114, 106, 106, 107, 111, 133, 221, 783, 2478],
			borderColor: $primary,
			fill: false
		}, {
			data: [282, 350, 411, 502, 635, 809, 947, 1402, 3700, 5267],
			label: "آسیا",
			borderColor: $success,
			fill: false
		}, {
			data: [168, 170, 178, 190, 203, 276, 408, 547, 675, 734],
			label: "اروپا",
			borderColor: $danger,
			fill: false
		}, {
			data: [40, 20, 10, 16, 24, 38, 74, 167, 508, 784],
			label: "آمریکای لاتین",
			borderColor: $warning,
			fill: false
		}, {
			data: [6, 3, 2, 2, 7, 26, 82, 172, 312, 433],
			label: "آمریکای شمالی",
			borderColor: $label_color,
			fill: false
		}]
	};

	var lineChartconfig = {
		type: 'line',

		// Chart Options
		options: linechartOptions,
		data: linechartData
	};
	// Create the chart
	var lineChart = new Chart(lineChartctx, lineChartconfig);

	// Bar Chart
	// ------------------------------------------

	//Get the context of the Chart canvas element we want to select
	var barChartctx = $("#bar-chart");
	// Chart Options
	var barchartOptions = {
		// Elements options apply to all of the options unless overridden in a dataset
		// In this case, we are setting the border of each bar to be 2px wide
		elements: {
			rectangle: {
				borderWidth: 2,
				borderSkipped: 'left'
			}
		},
		responsive: true,
		maintainAspectRatio: false,
		responsiveAnimationDuration: 500,
		legend: {
			display: false
		},
		scales: {
			xAxes: [{
				display: true,
				gridLines: {
					color: grid_line_color,
				},
				scaleLabel: {
					display: true,
				}
			}],
			yAxes: [{
				display: true,
				gridLines: {
					color: grid_line_color,
				},
				scaleLabel: {
					display: true,
				},
				ticks: {
					stepSize: 1000
				},
			}],
		},
		title: {
			display: true,
			text: 'جمعیت پیش بینی شده جهان در سال 2050 (میلیون)'
		},
	};
	// Chart Data
	var barchartData = {
		labels: ["آفریقا", "آسیا", "اروپا", "آمریکای لاتین", "آمریکای شمالی"],
		datasets: [{
			label: "جمعیت (میلیون)",
			data: [2478, 5267, 734, 784, 433],
			backgroundColor: themeColors,
			borderColor: "transparent"
		}]
	};
	var barChartconfig = {
		type: 'bar',

		// Chart Options
		options: barchartOptions,
		data: barchartData
	};
	// Create the chart
	var barChart = new Chart(barChartctx, barChartconfig);

	// Horizontal Chart
	// -------------------------------------

	// Get the context of the Chart canvas element we want to select
	var horizontalChartctx = $("#horizontal-bar");

	var horizontalchartOptions = {
		// Elements options apply to all of the options unless overridden in a dataset
		// In this case, we are setting the border of each horizontal bar to be 2px wide
		elements: {
			rectangle: {
				borderWidth: 2,
				borderSkipped: 'right',
				borderSkipped: 'top',
			}
		},
		responsive: true,
		maintainAspectRatio: false,
		responsiveAnimationDuration: 500,
		legend: {
			display: false,
		},
		scales: {
			xAxes: [{
				display: true,
				gridLines: {
					color: grid_line_color,
				},
				scaleLabel: {
					display: true,
				}
			}],
			yAxes: [{
				display: true,
				gridLines: {
					color: grid_line_color,
				},
				scaleLabel: {
					display: true,
				}
			}]
		},
		title: {
			display: true,
			text: 'جمعیت پیش بینی شده جهان در سال 2050 (میلیون)'
		}
	};

	// Chart Data
	var horizontalchartData = {
		labels: ["آفریقا", "آسیا", "اروپا", "آمریکای لاتین", "آمریکای شمالی"],
		datasets: [{
			label: "جمعیت (میلیون)",
			data: [2478, 5267, 734, 784, 433],
			backgroundColor: themeColors,
			borderColor: "transparent"
		}]
	};

	var horizontalChartconfig = {
		type: 'horizontalBar',

		// Chart Options
		options: horizontalchartOptions,

		data: horizontalchartData
	};

	// Create the chart
	var horizontalChart = new Chart(horizontalChartctx, horizontalChartconfig);

	// Pie Chart
	// --------------------------------
	//Get the context of the Chart canvas element we want to select
	var pieChartctx = $("#simple-pie-chart");

	// Chart Options
	var piechartOptions = {
		responsive: true,
		maintainAspectRatio: false,
		responsiveAnimationDuration: 500,
		title: {
			display: true,
			text: 'جمعیت پیش بینی شده جهان در سال 2050 (میلیون)'
		}
	};

	// Chart Data
	var piechartData = {
		labels: ["آفریقا", "آسیا", "اروپا", "آمریکای لاتین", "آمریکای شمالی"],
		datasets: [{
			label: "سری اطلاعات اول",
			data: [2478, 5267, 734, 784, 433],
			backgroundColor: themeColors,
		}]
	};

	var pieChartconfig = {
		type: 'pie',

		// Chart Options
		options: piechartOptions,

		data: piechartData
	};

	// Create the chart
	var pieSimpleChart = new Chart(pieChartctx, pieChartconfig);

	// Doughnut Chart
	// ---------------------------------------------
	//Get the context of the Chart canvas element we want to select
	var doughnutChartctx = $("#simple-doughnut-chart");

	// Chart Options
	var doughnutchartOptions = {
		responsive: true,
		maintainAspectRatio: false,
		responsiveAnimationDuration: 500,
		title: {
			display: true,
			text: 'جمعیت پیش بینی شده جهان در سال 2050 (میلیون)'
		}
	};

	// Chart Data
	var doughnutchartData = {
		labels: ["آفریقا", "آسیا", "اروپا", "آمریکای لاتین", "آمریکای شمالی"],
		datasets: [{
			label: "سری اطلاعات اول",
			data: [2478, 5267, 734, 784, 433],
			backgroundColor: themeColors,
		}]
	};

	var doughnutChartconfig = {
		type: 'doughnut',

		// Chart Options
		options: doughnutchartOptions,

		data: doughnutchartData
	};

	// Create the chart
	var doughnutSimpleChart = new Chart(doughnutChartctx, doughnutChartconfig);

	// Radar Chart
	// ----------------------------------------
	//Get the context of the Chart canvas element we want to select
	var radarChartctx = $("#radar-chart");

	// Chart Options
	var radarchartOptions = {
		responsive: true,
		maintainAspectRatio: false,
		responsiveAnimationDuration: 500,
		legend: {
			position: 'top',
		},
		tooltips: {
			callbacks: {
				label: function (tooltipItems, data) {
					return data.datasets[tooltipItems.datasetIndex].label + ": " + tooltipItems.yLabel;
				}
			}
		},
		title: {
			display: true,
			text: 'مقدار % جمعیت هر قاره از جمعیت جهان'
		},
		scale: {
			reverse: false,
			ticks: {
				beginAtZero: true,
				stepSize: 10
			}
		}
	};

	// Chart Data
	var radarchartData = {
		labels: ["آفریقا", "آسیا", "اروپا", "آمریکای لاتین", "آمریکای شمالی"],
		datasets: [{
			label: "1950",
			fill: true,
			backgroundColor: "rgba(255,91,92,0.2)",
			borderColor: $danger,
			pointBorderColor: $white,
			pointBackgroundColor: $danger,
			data: [8.77, 55.61, 21.69, 6.62, 6.82],
		}, {
			label: "2050",
			fill: true,
			backgroundColor: "rgba(255,91,92,0.2)",
			borderColor: $danger,
			pointBorderColor: $white,
			pointBackgroundColor: $danger,
			data: [25.48, 54.16, 7.61, 8.06, 4.45],
		}, ]
	};

	var radarChartconfig = {
		type: 'radar',

		// Chart Options
		options: radarchartOptions,

		data: radarchartData
	};

	// Create the chart
	var polarChart = new Chart(radarChartctx, radarChartconfig);

	// Polar Chart
	// -----------------------------------
	//Get the context of the Chart canvas element we want to select
	var polarChartctx = $("#polar-chart");

	// Chart Options
	var polarchartOptions = {
		responsive: true,
		maintainAspectRatio: false,
		responsiveAnimationDuration: 500,
		legend: {
			position: 'top',
		},
		title: {
			display: true,
			text: 'جمعیت پیش بینی شده جهان در سال 2050 (میلیون)'
		},
		scale: {
			ticks: {
				beginAtZero: true,
				stepSize: 2000
			},
			reverse: false
		},
		animation: {
			animateRotate: false
		}
	};

	// Chart Data
	var polarchartData = {
		labels: ["آفریقا", "آسیا", "اروپا", "آمریکای لاتین", "آمریکای شمالی"],
		datasets: [{
			label: "جمعیت (میلیون)",
			backgroundColor: themeColors,
			data: [2478, 5267, 734, 784, 433]
		}],
	};

	var polarChartconfig = {
		type: 'polarArea',

		// Chart Options
		options: polarchartOptions,

		data: polarchartData
	};

	// Create the chart
	var polarChart = new Chart(polarChartctx, polarChartconfig);

	// Bubble Chart
	// ---------------------------------------
	//Get the context of the Chart canvas element we want to select
	var bubbleChartctx = $("#bubble-chart");

	var randomScalingFactor = function () {
		return (Math.random() > 0.5 ? 1.0 : -1.0) * Math.round(Math.random() * 100);
	};

	// Chart Options
	var bubblechartOptions = {
		responsive: true,
		maintainAspectRatio: false,
		scales: {
			xAxes: [{
				display: true,
				gridLines: {
					color: grid_line_color,
				},
				scaleLabel: {
					display: true,
					labelString: "تولید ناخالص ملی"
				}
			}],
			yAxes: [{
				display: true,
				gridLines: {
					color: grid_line_color,
				},
				scaleLabel: {
					display: true,
					labelString: "شادی"
				},
				ticks: {
					stepSize: 0.5
				},
			}]
		},
		title: {
			display: true,
			text: 'جمعیت پیش بینی شده جهان در سال 2050 (میلیون)'
		}
	};

	// Chart Data
	var bubblechartData = {
		animation: {
			duration: 10000
		},
		datasets: [{
			label: ["چین"],
			backgroundColor: "rgb(253, 172, 65,.2)",
			borderColor: $warning,
			data: [{
				x: 21269017,
				y: 5.245,
				r: 15
			}],
		}, {
			label: ["دانمارک"],
			backgroundColor: "rgba(57,218,138,0.2)",
			borderColor: $success,
			data: [{
				x: 258702,
				y: 7.526,
				r: 10
			}]
		}, {
			label: ["آلمان"],
			backgroundColor: "rgba(0,0,0,0.2)",
			borderColor: $black,
			data: [{
				x: 3979083,
				y: 6.994,
				r: 15
			}]
		}, {
			label: ["ژاپن"],
			backgroundColor: "rgba(255,91,92,0.2)",
			borderColor: $danger,
			data: [{
				x: 4931877,
				y: 5.921,
				r: 15
			}]
		}]
	};

	var bubbleChartconfig = {
		type: 'bubble',

		// Chart Options
		options: bubblechartOptions,

		data: bubblechartData
	};

	// Create the chart
	var bubbleChart = new Chart(bubbleChartctx, bubbleChartconfig);

	// Scatter Chart
	// ------------------------------------
	//Get the context of the Chart canvas element we want to select
	var scatterChartctx = $("#scatter-chart");

	// Chart Options
	var scatterchartOptions = {
		responsive: true,
		maintainAspectRatio: false,
		responsiveAnimationDuration: 800,
		title: {
			display: false,
			text: 'نمودار پراکندگی Chart.js'
		},
		scales: {
			xAxes: [{
				position: 'top',
				gridLines: {
					color: scatter_grid_color,
					drawTicks: false,
				},
				scaleLabel: {
					display: true,
					labelString: 'محور x'
				}
			}],
			yAxes: [{
				position: 'right',
				gridLines: {
					color: scatter_grid_color,
					drawTicks: false,
				},
				scaleLabel: {
					display: true,
					labelString: 'محور y'
				}
			}]
		}
	};

	// Chart Data
	var scatterchartData = {
		datasets: [{
			label: "سری اطلاعات اول",
			data: [{
				x: 65,
				y: 28,
			}, {
				x: 59,
				y: 48,
			}, {
				x: 80,
				y: 40,
			}, {
				x: 81,
				y: 19,
			}, {
				x: 56,
				y: 86,
			}, {
				x: 55,
				y: 27,
			}, {
				x: 40,
				y: 89,
			}],
			backgroundColor: "#E6EAEE",
			borderColor: "transparent",
			pointBorderColor: $scatter_point_light,
			pointBackgroundColor: $white,
			pointBorderWidth: 2,
			pointHoverBorderWidth: 2,
			pointRadius: 4,
		}, {
			label: "سری اطلاعات دوم",
			data: [{
				x: 45,
				y: 17,
			}, {
				x: 25,
				y: 62,
			}, {
				x: 16,
				y: 78,
			}, {
				x: 36,
				y: 88,
			}, {
				x: 67,
				y: 26,
			}, {
				x: 18,
				y: 48,
			}, {
				x: 76,
				y: 73,
			}],
			backgroundColor: "rgba(90,141,238,.6)",
			borderColor: "transparent",
			pointBorderColor: $scatter_point_dark,
			pointBackgroundColor: $white,
			pointBorderWidth: 2,
			pointHoverBorderWidth: 2,
			pointRadius: 4,
		}]
	};

	var scatterChartconfig = {
		type: 'scatter',

		// Chart Options
		options: scatterchartOptions,

		data: scatterchartData
	};

	// Create the chart
	var scatterChart = new Chart(scatterChartctx, scatterChartconfig);

});