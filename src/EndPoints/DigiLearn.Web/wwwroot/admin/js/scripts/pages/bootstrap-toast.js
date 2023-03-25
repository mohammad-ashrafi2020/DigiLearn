/*- =========================================================================
File Name: bootstrap-toast.js
Description: This Page contains Icon toast and Progress bars.
==========================================================================*/
// toast initialize
$('.toast-toggler').on('click', function () {
	$(this).next('.toast').prependTo('.toast-bs-container .toast-position').toast('show')
});
// for toast placement
$('.placement').on('click', function () {
	$('.toast-placement .toast').toast('show');
});