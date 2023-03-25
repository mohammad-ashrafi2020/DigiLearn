/*=========================================================================================
    File Name: form-select2.js
    Description: Select2 is a jQuery-based replacement for select boxes.
    It supports searching, remote data sets, and pagination of results.
==========================================================================================*/

// Select2 Farsi Translation
(function () {
	if (jQuery && jQuery.fn && jQuery.fn.select2 && jQuery.fn.select2.amd) var e = jQuery.fn.select2.amd;
	return e.define("select2/i18n/fa", [], function () {
		return {
			errorLoading: function () {
				return "امکان بارگذاری نتایج وجود ندارد."
			},
			inputTooLong: function (e) {
				var t = e.input.length - e.maximum,
					n = "لطفاً " + t + " کاراکتر را حذف نمایید";
				return n
			},
			inputTooShort: function (e) {
				var t = e.minimum - e.input.length,
					n = "لطفاً تعداد " + t + " کاراکتر یا بیشتر وارد نمایید";
				return n
			},
			loadingMore: function () {
				return "در حال بارگذاری نتایج بیشتر..."
			},
			maximumSelected: function (e) {
				var t = "شما تنها می‌توانید " + e.maximum + " آیتم را انتخاب نمایید";
				return t
			},
			noResults: function () {
				return "هیچ نتیجه‌ای یافت نشد"
			},
			searching: function () {
				return "در حال جستجو ..."
			},
			removeAllItems: function () {
				return "همه موارد را حذف کنید"
			}
		}
	}), {
		define: e.define,
		require: e.require
	}
})();

(function (window, document, $) {
	'use strict';

	// Basic Select2 select
	$(".select2").select2({
		// the following code is used to disable x-scrollbar when click in select input and
		// take 100% width in responsive also
		dropdownAutoWidth: true,
		width: '100%',
		language: "fa"
	});

	// Select With Icon
	$(".select2-icons").select2({
		dropdownAutoWidth: true,
		width: '100%',
		language: "fa",
		minimumResultsForSearch: Infinity,
		templateResult: iconFormat,
		templateSelection: iconFormat,
		escapeMarkup: function (es) {
			return es;
		}
	});

	// Format icon
	function iconFormat(icon) {
		var originalOption = icon.element;
		if (!icon.id) {
			return icon.text;
		}
		var $icon = "<i class='" + $(icon.element).data('icon') + "'></i>" + icon.text;

		return $icon;
	}


	// Limiting the number of selections
	$(".max-length").select2({
		dropdownAutoWidth: true,
		width: '100%',
		language: "fa",
		maximumSelectionLength: 2,
		placeholder: "حداکثر 2 گزینه انتخاب کنید"
	});


	// Programmatic access
	var $select = $(".js-example-programmatic").select2({
		dropdownAutoWidth: true,
		width: '100%',
		language: "fa"
	});
	var $selectMulti = $(".js-example-programmatic-multi").select2();
	$selectMulti.select2({
		dropdownAutoWidth: true,
		width: '100%',
		language: "fa",
		placeholder: "رویداد های Programmatic"
	});
	$(".js-programmatic-set-val").on("click", function () {
		$select.val("CA").trigger("change");
	});

	$(".js-programmatic-open").on("click", function () {
		$select.select2("open");
	});
	$(".js-programmatic-close").on("click", function () {
		$select.select2("close");
	});

	$(".js-programmatic-init").on("click", function () {
		$select.select2();
	});
	$(".js-programmatic-destroy").on("click", function () {
		$select.select2("destroy");
	});

	$(".js-programmatic-multi-set-val").on("click", function () {
		$selectMulti.val(["CA", "AL"]).trigger("change");
	});
	$(".js-programmatic-multi-clear").on("click", function () {
		$selectMulti.val(null).trigger("change");
	});

	// Loading array data
	var data = [{
			id: 0,
			text: 'بهینه سازی'
		},
		{
			id: 1,
			text: 'باگ'
		},
		{
			id: 2,
			text: 'کپی کردن'
		},
		{
			id: 3,
			text: 'نامعتبر'
		},
		{
			id: 4,
			text: 'قابل اصلاح'
		}
	];

	$(".select2-data-array").select2({
		dropdownAutoWidth: true,
		width: '100%',
		language: "fa",
		data: data
	});

	// Loading remote data
	$(".select2-data-ajax").select2({
		dropdownAutoWidth: true,
		width: '100%',
		language: "fa",
		ajax: {
			url: "https://api.github.com/search/repositories",
			dataType: 'json',
			delay: 250,
			data: function (params) {
				return {
					q: params.term, // search term
					page: params.page
				};
			},
			processResults: function (data, params) {
				// parse the results into the format expected by Select2
				// since we are using custom formatting functions we do not need to
				// alter the remote JSON data, except to indicate that infinite
				// scrolling can be used
				params.page = params.page || 1;

				return {
					results: data.items,
					pagination: {
						more: (params.page * 30) < data.total_count
					}
				};
			},
			cache: true
		},
		placeholder: 'برای یک repository جستجو کنید',
		escapeMarkup: function (markup) {
			return markup;
		}, // let our custom formatter work
		minimumInputLength: 1,
		templateResult: formatRepo,
		templateSelection: formatRepoSelection
	});

	function formatRepo(repo) {
		if (repo.loading) return repo.text;

		var markup = "<div class='select2-result-repository clearfix'>" +
			"<div class='select2-result-repository__avatar'><img src='" + repo.owner.avatar_url + "' /></div>" +
			"<div class='select2-result-repository__meta'>" +
			"<div class='select2-result-repository__title'>" + repo.full_name + "</div>";

		if (repo.description) {
			markup += "<div class='select2-result-repository__description'>" + repo.description + "</div>";
		}

		markup += "<div class='select2-result-repository__statistics'>" +
			"<div class='select2-result-repository__forks'><i class='icon-code-fork mr-0'></i> " + repo.forks_count + " Forks</div>" +
			"<div class='select2-result-repository__stargazers'><i class='icon-star5 mr-0'></i> " + repo.stargazers_count + " Stars</div>" +
			"<div class='select2-result-repository__watchers'><i class='icon-eye mr-0'></i> " + repo.watchers_count + " Watchers</div>" +
			"</div>" +
			"</div></div>";

		return markup;
	}

	function formatRepoSelection(repo) {
		return repo.full_name || repo.text;
	}


	// Customizing how results are matched
	function matchStart(term, text) {
		if (text.toUpperCase().indexOf(term.toUpperCase()) === 0) {
			return true;
		}

		return false;
	}

	$.fn.select2.amd.require(['select2/compat/matcher'], function (oldMatcher) {
		$(".select2-customize-result").select2({
			dropdownAutoWidth: true,
			width: '100%',
			language: "fa",
			placeholder: "جستجو را با 'ب' شروع کنید",
			matcher: oldMatcher(matchStart)
		});
	});

	// Theme support
	$(".select2-theme").select2({
		dropdownAutoWidth: true,
		width: '100%',
		language: "fa",
		placeholder: "قالب کلاسیک",
		theme: "classic"
	});

	/******************/
	// Sizing options //
	/*****************/

	// Large
	$('.select2-size-lg').select2({
		dropdownAutoWidth: true,
		width: '100%',
		language: "fa",
		containerCssClass: 'select-lg'
	});

	// Small
	$('.select2-size-sm').select2({
		dropdownAutoWidth: true,
		width: '100%',
		language: "fa",
		containerCssClass: 'select-sm'
	});

})(window, document, jQuery);