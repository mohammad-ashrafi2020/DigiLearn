/*=========================================================================================
  File Name: form-validation.js
  Description: jquery bootsreap validation js
==========================================================================================*/

(function (window, document, $) {
	'use strict';

	// Input, Select, Textarea validations except submit button
	$("input,select,textarea").not("[type=submit]").jqBootstrapValidation();

})(window, document, jQuery);