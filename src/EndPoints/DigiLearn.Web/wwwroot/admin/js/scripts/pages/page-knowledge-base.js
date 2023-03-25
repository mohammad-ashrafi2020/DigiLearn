/*=========================================================================================
    File Name: page-knowledge-base.js
    Description: Knowledge Base Page Content js
==========================================================================================*/
$(document).ready(function () {
	// knowledge-base search
	$(function () {
		"use strict";
		// Filter
		$("#searchbar").on("keyup", function () {
			var value = $(this).val().toLowerCase();
			if (value != "") {
				$(".kb-search-content-info .kb-search-content").filter(function () {
					$(this).toggle($(this).text().toLowerCase().indexOf(value) > -1);
				});
				var search_row = $(".kb-search-content-info .kb-search-content:visible").length;
				//Check if search-content has row or not
				if (search_row == 0) {
					$('.kb-search-content-info .no-result').removeClass('no-items');
				} else {
					if (!$('.kb-search-content-info .no-result').hasClass('no-items')) {
						$('.kb-search-content-info .no-result').addClass('no-items');
					}
				}
			} else {
				// If filter box is empty
				$(".kb-search-content-info .kb-search-content").show();
				if ($('.kb-search-content-info .no-results').hasClass('no-items')) {
					$('.kb-search-content-info .no-results').removeClass('no-items');
				}
			}
		});
	});
	// knowledge-base-categories & knowledge-base-question sidebar
	if ($('button').hasClass('kb-menu')) {
		// on click button
		$('.kb-menu').on('click', function () {
			$(".kb-sidebar").toggleClass('show');
			$(".kb-overlay").toggleClass('show');
		});
		// on click close-icon or overlay
		$('.kb-close-icon, .kb-overlay').on('click', function () {
			$(".kb-sidebar").removeClass('show');
			$(".kb-overlay").removeClass('show');
		});
	}
});