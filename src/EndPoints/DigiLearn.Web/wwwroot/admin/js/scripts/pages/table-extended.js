/*=========================================================================================
    File Name: table-extended.js
    Description: table extended js
==========================================================================================*/

(function (window, document, $) {

	var $primary = '#5A8DEE';
	var $danger = '#FF5B5C';
	var $warning = '#FDAC41';
	var $info = '#00CFDD';
	var $gray_light = '#828D99';

	$.extend( true, $.fn.dataTable.defaults, {
		language: {
			"sEmptyTable":     "هیچ داده ای در جدول وجود ندارد",
			"sInfo":           "نمایش _START_ تا _END_ از _TOTAL_ رکورد",
			"sInfoEmpty":      "نمایش 0 تا 0 از 0 رکورد",
			"sInfoFiltered":   "(فیلتر شده از _MAX_ رکورد)",
			"sInfoPostFix":    "",
			"sInfoThousands":  ",",
			"sLengthMenu":     "نمایش _MENU_ رکورد",
			"sLoadingRecords": "در حال بارگزاری...",
			"sProcessing":     "در حال پردازش...",
			"sSearch":         "جستجو: ",
			"sZeroRecords":    "رکوردی با این مشخصات پیدا نشد",
			"oPaginate": {
				"sFirst":    "ابتدا",
				"sLast":     "انتها",
				"sNext":     "بعدی",
				"sPrevious": "قبلی"
			},
			"oAria": {
				"sSortAscending":  ": فعال سازی نمایش به صورت صعودی",
				"sSortDescending": ": فعال سازی نمایش به صورت نزولی"
			}
		}
	} );

	// table extended transactions
	$('#table-extended-transactions').DataTable({
		"responsive": true,
		"searching": false,
		"lengthChange": false,
		"paging": false,
		"bInfo": false,
		"columnDefs": [{
			"orderable": false,
			"targets": 2
		}, ]
	});
	// table extended success
	$('#table-extended-success').DataTable({
		"responsive": true,
		"searching": false,
		"lengthChange": false,
		"paging": false,
		"bInfo": false,
		"columnDefs": [{
			"orderable": false,
			"targets": [1, 2, 3, 4, 5]
		}, ]
	});

	// table extended checkbox
	var tablecheckbox = $('#table-extended-chechbox').DataTable({
		"searching": false,
		"lengthChange": false,
		"paging": false,
		"bInfo": false,
		'columnDefs': [{
				"orderable": false,
				"targets": [0, 3, 4]
			}, //to disable sortying in col 0,3 & 4
			{
				'targets': 0,
				'render': function (data, type, row, meta) {
					if (type === 'display') {
						data = '<div class="checkbox"><input type="checkbox" class="dt-checkboxes"><label></label></div>'; //body checkbox
					}
					return data;
				},
				'checkboxes': {
					'selectRow': true,
					'selectAllRender': '<div class="checkbox"><input type="checkbox" class="dt-checkboxes" checked=""><label></label></div >' //head checkbox
				}
			}
		],
		'select': 'multi',
		'order': [
			[1, 'asc']
		]
	});
	// Single Date Picker
	// -----------------
	$('.single-daterange').datepicker({
		dateFormat: "yy/mm/dd",
		showOtherMonths: true,
		selectOtherMonths: true,
		changeMonth: true,
		changeYear: true,
		showButtonPanel: false
	});

	// Table Donut Chart Statistics-1
	// ------------------------------
	var donustChartStatistics_1 = {
		chart: {
			width: 80,
			height: 130,
			type: 'donut'
		},
		dataLabels: {
			enabled: false
		},
		series: [70, 30, 40],
		labels: ["نصب", "بازدید صفحه", "کاربران فعال"],
		stroke: {
			width: 2
		},
		colors: [$warning, $info, $primary],
		plotOptions: {
			pie: {
				offsetY: 15,
				donut: {
					size: '70%',
				}
			}
		},
		legend: {
			show: false
		}
	}
	var donustChartStatistics_1 = new ApexCharts(
		document.querySelector("#table-donut-chart-1"),
		donustChartStatistics_1
	);
	donustChartStatistics_1.render();

	// Table Donut Chart Statistics-2
	// ------------------------------
	var donustChartStatistics_2 = {
		chart: {
			width: 80,
			height: 130,
			type: 'donut'
		},
		dataLabels: {
			enabled: false
		},
		series: [70, 40, 30],
		labels: ["نصب", "بازدید صفحه", "کاربران فعال"],
		stroke: {
			width: 2
		},
		colors: [$danger, $gray_light, $primary],
		plotOptions: {
			pie: {
				offsetY: 15,
				donut: {
					size: '70%',
				}
			}
		},
		legend: {
			show: false
		}
	}
	var donustChartStatistics_2 = new ApexCharts(
		document.querySelector("#table-donut-chart-2"),
		donustChartStatistics_2
	);
	donustChartStatistics_2.render();
})(window, document, jQuery);
