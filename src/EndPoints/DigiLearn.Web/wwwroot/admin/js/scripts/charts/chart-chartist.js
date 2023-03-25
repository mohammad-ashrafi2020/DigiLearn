/*=========================================================================================
    File Name: chart-chartis.js
    Description: chartist examples
==========================================================================================*/

$(window).on("load", function () {

	//      line chart    //
	// --------------------

	// simple line chart
	new Chartist.Line('.simple-line-chart', {
		labels: ['دوشنبه', 'سه شنبه', 'چهارشنبه', 'پنج شنبه', 'جمعه'],
		series: [
			[12, 9, 7, 8, 5],
			[2, 1, 3.5, 7, 3],
			[1, 3, 4, 5, 6]
		]
	}, {
		fullWidth: true,
		chartPadding: {
			right: 40
		}
	});

	//line chart with area
	new Chartist.Line('.line-area-chart', {
		labels: [1, 2, 3, 4, 5, 6, 7, 8],
		series: [
			[5, 9, 7, 8, 5, 3, 5, 4]
		]
	}, {
		low: 0,
		showArea: true
	});

	// Bi polar line chart with area only
	new Chartist.Line('.bi-polar-chart', {
		labels: [1, 2, 3, 4, 5, 6, 7, 8],
		series: [
			[1, 2, 3, 1, -2, 0, 1, 0],
			[-2, -1, -2, -1, -2.5, -1, -2, -1],
			[0, 0, 0, 1, 2, 2.5, 2, 1],
			[2.5, 2, 1, 0.5, 1, 0.5, -1, -2.5]
		]
	}, {
		high: 3,
		low: -3,
		showArea: true,
		showLine: false,
		showPoint: false,
		fullWidth: true,
		axisX: {
			showLabel: false,
			showGrid: false
		}
	});

	// Series overrides line charts
	var chart = new Chartist.Line('.series-overrides-chart', {
		labels: ['1', '2', '3', '4', '5', '6', '7', '8'],
		// Naming the series with the series object array notation
		series: [{
			name: 'سری 1',
			data: [5, 2, -4, 2, 0, -2, 5, -3]
		}, {
			name: 'سری 2',
			data: [4, 3, 5, 3, 1, 3, 6, 4]
		}, {
			name: 'سری 3',
			data: [2, 4, 3, 1, 4, 5, 3, 2]
		}]
	}, {
		fullWidth: true,
		// Within the series options you can use the series names
		// to specify configuration that will only be used for the
		// specific series.
		series: {
			'سری 1': {
				lineSmooth: Chartist.Interpolation.step()
			},
			'سری 2': {
				lineSmooth: Chartist.Interpolation.simple(),
				showArea: true
			},
			'سری 3': {
				showPoint: false
			}
		}
	}, [
		// You can even use responsive configuration overrides to
		// customize your series configuration even further!
		['screen and (max-width: 320px)', {
			series: {
				'سری 1': {
					lineSmooth: Chartist.Interpolation.none()
				},
				'سری 2': {
					lineSmooth: Chartist.Interpolation.none(),
					showArea: false
				},
				'سری 3': {
					lineSmooth: Chartist.Interpolation.none(),
					showPoint: true
				}
			}
		}]
	]);

	//        BAR CHART       //
	// -----------------------

	//BI-Polar Bar Chart

	var data = {
		labels: ['هفته 1', 'هفته 2', 'هفته 3', 'هفته 4', 'هفته 5', 'هفته 6', 'هفته 7', 'هفته 8', 'هفته 9', 'هفته 10'],
		series: [
			[1, 2, 4, 8, 6, -2, -1, -4, -6, -2]
		]
	};

	var options = {
		high: 10,
		low: -10,
		axisX: {
			labelInterpolationFnc: function (value, index) {
				return index % 2 === 0 ? value : null;
			}
		}
	};
	new Chartist.Bar('.bi-polar-bar-chart', data, options);

	//Stacked Bar chart
	new Chartist.Bar('.stacked-bar-chart', {
		labels: ['یک چهارم 1', 'یک چهارم 2', 'یک چهارم 3', 'یک چهارم 4'],
		series: [
			[800000, 1200000, 1400000, 1300000],
			[200000, 400000, 500000, 300000],
			[100000, 200000, 400000, 600000]
		]
	}, {
		stackBars: true,
		axisY: {
			labelInterpolationFnc: function (value) {
				return (value / 1000) + 'k';
			}
		}
	}).on('draw', function (data) {
		if (data.type === 'bar') {
			data.element.attr({
				style: 'stroke-width: 30px'
			});
		}
	});

	//Horizontal Bar chart
	new Chartist.Bar('.horizontal-bar-chart', {
		labels: ['دوشنبه', 'سه شنبه', 'چهارشنبه', 'پنج شنبه', 'جمعه', 'شنبه', 'یک شنبه'],
		series: [
			[5, 4, 3, 7, 5, 10, 3],
			[3, 2, 9, 5, 4, 6, 4]
		]
	}, {
		seriesBarDistance: 10,
		reverseData: true,
		horizontalBars: true,
		axisY: {
			offset: 70
		}
	});

	//Multi-line bar chart
	new Chartist.Bar('.multi-line-chart', {
		labels: ['فروردین', 'اردیبهشت', 'خرداد', 'تیر', 'مرداد', 'شهریور', 'مهر', 'آبان', 'آذر', 'دی', 'بهمن', 'اسفند'],
		series: [
			[5, 4, 3, 7, 5, 10, 3, 4, 8, 10, 6, 8],
			[3, 2, 9, 5, 4, 6, 4, 6, 7, 8, 7, 4],
			[2, 1, 7, 3, 2, 4, 2, 3, 4, 3, 5, 1]
		]
	}, {
		seriesBarDistance: 10,
		axisX: {
			offset: 60
		},
		axisY: {
			offset: 80,
			labelInterpolationFnc: function (value) {
				return value
			},
			scaleMinSpace: 15
		}
	});

	//        Pie Chart       //
	// ------------------------

	// simple pie chart
	var data = {
		series: [5, 3, 4]
	};

	var sum = function (a, b) {
		return a + b
	};

	new Chartist.Pie('.pie-chart', data, {
		labelInterpolationFnc: function (value) {
			return Math.round(value / data.series.reduce(sum) * 100) + '%';
		}
	});

	//Pie chart with custome label
	var data = {
		labels: ['موز', 'سیب', 'انگور'],
		series: [20, 15, 40]
	};

	var options = {
		labelInterpolationFnc: function (value) {
			return value[0]
		}
	};
	// Pie chart label responsive on screen
	var responsiveOptions = [
		['screen and (min-width: 992px)', {
			chartPadding: 50,
			labelOffset: 100,
			labelDirection: 'explode',
			labelInterpolationFnc: function (value) {
				return value;
			}
		}]
	];
	new Chartist.Pie('.pie-custome-label-chart', data, options, responsiveOptions);

	//Animating A Donut With SVG.Animate

	var chart = new Chartist.Pie('.animation-chart', {
		series: [10, 20, 50, 20, 30, 5, 15, 20],
		labels: [1, 2, 3, 4, 5, 6, 7, 8]
	}, {
		donut: true,
		showLabel: true
	});

	chart.on('draw', function (data) {
		if (data.type === 'slice') {
			// Get the total path length in order to use for dash array animation
			var pathLength = data.element._node.getTotalLength();

			// Set a dasharray that matches the path length as prerequisite to animate dashoffset
			data.element.attr({
				'stroke-dasharray': pathLength + 'px ' + pathLength + 'px'
			});

			// Create animation definition while also assigning an ID to the animation for later sync usage
			var animationDefinition = {
				'stroke-dashoffset': {
					id: 'anim' + data.index,
					dur: 1000,
					from: -pathLength + 'px',
					to: '0px',
					easing: Chartist.Svg.Easing.easeOutQuint,
					// We need to use `fill: 'freeze'` otherwise our animation will fall back to initial (not visible)
					fill: 'freeze'
				}
			};

			// If this was not the first slice, we need to time the animation so that it uses the end sync event of the previous animation
			if (data.index !== 0) {
				animationDefinition['stroke-dashoffset'].begin = 'anim' + (data.index - 1) + '.end';
			}

			// We need to set an initial value before the animation starts as we are not in guided mode which would do that for us
			data.element.attr({
				'stroke-dashoffset': -pathLength + 'px'
			});
			data.element.animate(animationDefinition, false);
		}
	});

	// For the sake of the example we update the chart every time it's created with a delay of 8 seconds
	chart.on('created', function () {
		if (window.__anim21278907124) {
			clearTimeout(window.__anim21278907124);
			window.__anim21278907124 = null;
		}
		window.__anim21278907124 = setTimeout(chart.update.bind(chart), 10000);
	});
	// Gauge Chart Using Fill Rather Than Stroke

	new Chartist.Pie('.gauge-chart', {
		series: [20, 10, 30, 40]
	}, {
		donut: true,
		donutWidth: 60,
		donutSolid: true,
		startAngle: 270,
		total: 200,
		showLabel: true
	});
});