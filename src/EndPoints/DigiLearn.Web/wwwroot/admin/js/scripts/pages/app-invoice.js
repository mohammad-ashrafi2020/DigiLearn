/*=========================================================================================
    File Name: app-invoice.js
    Description: app-invoice Javascripts
==========================================================================================*/
$(document).ready(function () {
	/********Invoice View ********/
	// ---------------------------
	// init date picker
	if ($(".pickadate").length) {
		$(".pickadate").datepicker({
			dateFormat: "yy/mm/dd",
			showOtherMonths: true,
			selectOtherMonths: false
		});
	}

	/********Invoice List ********/
	// ---------------------------

	// init data table
	if ($(".invoice-data-table").length) {
		var dataListView = $(".invoice-data-table").DataTable({
			columnDefs: [{
					targets: 0,
					className: "control"
				},
				{
					orderable: true,
					targets: 1,
					checkboxes: {
						selectRow: true
					}
				},
				{
					targets: [0, 1],
					orderable: false
				},
			],
			order: [2, 'asc'],
			dom: '<"top d-flex flex-wrap"<"action-filters flex-grow-1"f><"actions action-btns d-flex align-items-center">><"clear">rt<"bottom"p>',
			language: {
				"sEmptyTable":     "هیچ داده‌ای در جدول وجود ندارد",
				"sInfo":           "نمایش _START_ تا _END_ از _TOTAL_ ردیف",
				"sInfoEmpty":      "نمایش 0 تا 0 از 0 ردیف",
				"sInfoFiltered":   "(فیلتر شده از _MAX_ ردیف)",
				"sInfoPostFix":    "",
				"sInfoThousands":  ",",
				"sLengthMenu":     "نمایش _MENU_ ردیف",
				"sLoadingRecords": "در حال بارگزاری...",
				"sProcessing":     "در حال پردازش...",
				"sZeroRecords":    "رکوردی با این مشخصات پیدا نشد",
				"oPaginate": {
					"sFirst":    "برگه‌ی نخست",
					"sLast":     "برگه‌ی آخر",
					"sNext":     "بعدی",
					"sPrevious": "قبلی"
				},
				"oAria": {
					"sSortAscending":  ": فعال سازی نمایش به صورت صعودی",
					"sSortDescending": ": فعال سازی نمایش به صورت نزولی"
				},
				"sSearch": "",
				"sSearchPlaceholder": "جستجوی صورتحساب"
			},
			select: {
				style: "multi",
				selector: "td:first-child",
				items: "row"
			},
			responsive: {
				details: {
					type: "column",
					target: 0
				}
			}
		});
	}

	// To append actions dropdown inside action-btn div
	var invoiceFilterAction = $(".invoice-filter-action");
	var invoiceOptions = $(".invoice-options");
	$(".action-btns").append(invoiceFilterAction, invoiceOptions);

	// add class in row if checkbox checked
	$(".dt-checkboxes-cell")
		.find("input")
		.on("change", function () {
			var $this = $(this);
			if ($this.is(":checked")) {
				$this.closest("tr").addClass("selected-row-bg");
			} else {
				$this.closest("tr").removeClass("selected-row-bg");
			}
		});
	// Select all checkbox
	$(document).on("change", ".dt-checkboxes-select-all input", function () {
		if ($(this).is(":checked")) {
			$(".dt-checkboxes-cell")
				.find("input")
				.prop("checked", this.checked)
				.closest("tr")
				.addClass("selected-row-bg");
		} else {
			$(".dt-checkboxes-cell")
				.find("input")
				.prop("checked", "")
				.closest("tr")
				.removeClass("selected-row-bg");
		}
	});

	// ********Invoice Edit***********//
	// --------------------------------
	// form repeater jquery
	if ($(".invoice-item-repeater").length) {
		$(".invoice-item-repeater").repeater({
			show: function () {
				$(this).slideDown();
			},
			hide: function (deleteElement) {
				$(this).slideUp(deleteElement);
			}
		});
	}
	// dropdown form's prevent parent action
	$(document).on("click", ".invoice-tax", function (e) {
		e.stopPropagation();
	});
	$(document).on("click", ".invoice-apply-btn", function () {
		var $this = $(this);
		var discount = $this
			.closest(".dropdown-menu")
			.find("#discount")
			.val();
		var tax1 = $this
			.closest(".dropdown-menu")
			.find("#Tax1 option:selected")
			.text();
		var tax2 = $this
			.closest(".dropdown-menu")
			.find("#Tax2 option:selected")
			.text();
		$this
			.parents()
			.eq(4)
			.find(".discount-value")
			.html(discount + "%");
		$this
			.parents()
			.eq(4)
			.find(".tax1")
			.html(tax1);
		$this
			.parents()
			.eq(4)
			.find(".tax2")
			.html(tax2);
	});
	// // on product change also change product description
	$(document).on("change", ".invoice-item-select", function (e) {
		var selectOption = this.options[e.target.selectedIndex].text;
		// switch case for product select change also change product description
		switch (selectOption) {
			case "Frest Admin Template":
				$(e.target)
					.closest(".invoice-item-filed")
					.find(".invoice-item-desc")
					.val("The most developer friendly & highly customisable HTML5 Admin");
				break;
			case "Stack Admin Template":
				$(e.target)
					.closest(".invoice-item-filed")
					.find(".invoice-item-desc")
					.val("Ultimate Bootstrap 4 Admin Template for Next Generation Applications.");
				break;
			case "Robust Admin Template":
				$(e.target)
					.closest(".invoice-item-filed")
					.find(".invoice-item-desc")
					.val(
						"Robust admin is super flexible, powerful, clean & modern responsive bootstrap admin template with unlimited possibilities"
					);
				break;
			case "Apex Admin Template":
				$(e.target)
					.closest(".invoice-item-filed")
					.find(".invoice-item-desc")
					.val("Developer friendly and highly customizable Angular 7+ jQuery Free Bootstrap 4 gradient ui admin template. ");
				break;
			case "Modern Admin Template":
				$(e.target)
					.closest(".invoice-item-filed")
					.find(".invoice-item-desc")
					.val("The most complete & feature packed bootstrap 4 admin template of 2019!");
				break;
		}
	});
	// print button
	if ($(".invoice-print").length > 0) {
		$(".invoice-print").on("click", function () {
			window.print();
		})
	}
});