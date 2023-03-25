/*=========================================================================================
    File Name: page-search.js
    Description: page-search.js
==========================================================================================*/
// video result swiper
var videoResults = new Swiper('.video-result-swiper', {
	slidesPerView: 'auto',
	centeredSlides: false,
	spaceBetween: 20,
	navigation: {
		nextEl: '.swiper-button-next',
		prevEl: '.swiper-button-prev',
	},
});