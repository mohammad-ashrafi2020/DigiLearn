/*=========================================================================================
    File Name: Form-Repeater.js
    Description: form repeater page specific js
==========================================================================================*/

$(document).ready(function () {
	// form repeater jquery
	$('.file-repeater, .contact-repeater, .repeater-default').repeater({
		show: function () {
			$(this).slideDown();
		},
		hide: function (deleteElement) {
			if (confirm('آیا از حذف این آیتم مطمئن هستید؟')) {
				$(this).slideUp(deleteElement);
			}
		}
	});

});