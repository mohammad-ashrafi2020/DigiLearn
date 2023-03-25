/*=========================================================================================
    File Name: faq.js
    Description: frequently asked questions
==========================================================================================*/
$(document).ready(function () {
	//initialize swiper when document ready
	var swiperLength = $(".swiper-slide").length;
	if (swiperLength) {
		swiperLength = Math.floor(swiperLength / 2)
	}

	// Swiper js for this page
	var mySwiper = new Swiper('.swiper-centered-slides', {
		slidesPerView: 'auto',
		initialSlide: swiperLength,
		centeredSlides: true,
		spaceBetween: 30,
		navigation: {
			nextEl: '.swiper-button-next',
			prevEl: '.swiper-button-prev',
		},
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
		$("[data-faq=" + slideId + "]").addClass('active')
	};
});

// search
$(function () {
	"use strict";
	// Filter
	$("#searchbar").on("keyup", function () {
		var value = $(this).val().toLowerCase();
		if (value != "") {
			$(".search-content-info .search-content").filter(function () {
				$(this).toggle($(this).text().toLowerCase().indexOf(value) > -1);
			});
			var search_row = $(".search-content-info .search-content:visible").length;
			//Check if search-content has row or not
			if (search_row == 0) {
				$('.search-content-info .no-result').removeClass('no-items');
			} else {
				if (!$('.search-content-info .no-result').hasClass('no-items')) {
					$('.search-content-info .no-result').addClass('no-items');
				}
			}
		} else {
			// If filter box is empty
			$(".search-content-info .search-content").show();
			if ($('.search-content-info .no-results').hasClass('no-items')) {
				$('.search-content-info .no-results').removeClass('no-items');
			}
		}
	});
});

$(window).on('load', function(){
	window.dispatchEvent(new Event('resize'));
});
