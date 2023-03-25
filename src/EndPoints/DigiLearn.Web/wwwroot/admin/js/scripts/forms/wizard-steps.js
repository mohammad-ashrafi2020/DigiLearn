/*=========================================================================================
    File Name: wizard-steps.js
    Description: wizard steps page specific js
==========================================================================================*/
//    Wizard tabs with icons setup
// ------------------------------
$(".wizard-horizontal").steps({
	headerTag: "h6",
	bodyTag: "fieldset",
	transitionEffect: "fade",
	titleTemplate: '<span class="step">#index#</span> #title#',
	labels: {
        cancel: "انصراف",
        current: "قدم کنونی:",
        pagination: "صفحه بندی",
        finish: "ثبت",
        next: "بعدی",
        previous: "قبلی",
        loading: "در حال بارگذاری ..."
    },
	onFinished: function (event, currentIndex) {
		alert("فرم ثبت شد.");
	}
});
//        vertical Wizard       //
// ------------------------------
$(".wizard-vertical").steps({
	headerTag: "h3",
	bodyTag: "fieldset",
	transitionEffect: "fade",
	enableAllSteps: true,
	stepsOrientation: "vertical",
	labels: {
        cancel: "انصراف",
        current: "قدم کنونی:",
        pagination: "صفحه بندی",
        finish: "ثبت",
        next: "بعدی",
        previous: "قبلی",
        loading: "در حال بارگذاری ..."
    },
	onFinished: function (event, currentIndex) {
		alert("فرم ثبت شد.");
	}
});


//       Validate steps wizard //
// -----------------------------
// Show form
var stepsValidation = $(".wizard-validation");
var form = stepsValidation.show();

stepsValidation.steps({
	headerTag: "h6",
	bodyTag: "fieldset",
	transitionEffect: "fade",
	titleTemplate: '<span class="step">#index#</span> #title#',
	labels: {
        cancel: "انصراف",
        current: "قدم کنونی:",
        pagination: "صفحه بندی",
        finish: "ثبت",
        next: "بعدی",
        previous: "قبلی",
        loading: "در حال بارگذاری ..."
    },
	onStepChanging: function (event, currentIndex, newIndex) {
		// Allways allow previous action even if the current form is not valid!
		if (currentIndex > newIndex) {
			return true;
		}
		form.validate().settings.ignore = ":disabled,:hidden";
		return form.valid();
	},
	onFinishing: function (event, currentIndex) {
		form.validate().settings.ignore = ":disabled";
		return form.valid();
	},
	onFinished: function (event, currentIndex) {
		alert("ثبت شد!");
	}
});

// Initialize validation

jQuery.extend(jQuery.validator.messages, {
    required: "وارد کردن این فیلد الزامی است.",
    remote: "لطفا این فیلد را اصلاح کنید.",
    email: "لطفا یک آدرس ایمیل معتبر وارد کنید.",
    url: "لطفا یک URL معتبر وارد کنید.",
    date: "لطفا یک تاریخ معتبر وارد کنید.",
    dateISO: "لطفا یک تاریخ معتبر وارد کنید (ISO).",
    number: "لطفا یک شماره معتبر وارد کنید.",
    digits: "لطفا فقط عدد وارد کنید.",
    creditcard: "لطفا یک شماره کارت معتبر وارد کنید.",
    equalTo: "لطفا همان مقدار را دوباره وارد کنید.",
    accept: "لطفا یک مقدار با پسوند معتبر وارد کنید.",
    maxlength: jQuery.validator.format("لطفا بیشتر از {0} حرف وارد نکنید."),
    minlength: jQuery.validator.format("لطفا حداقل {0} حرف وارد کنید."),
    rangelength: jQuery.validator.format("لطفا مقداری به طول بین {0} و {1} وارد کنید."),
    range: jQuery.validator.format("لطفا مقداری بین {0} و {1} وارد کنید."),
    max: jQuery.validator.format("لطفا مقداری کمتر یا مساوی {0} وارد کنید."),
    min: jQuery.validator.format("لطفا مقداری بیشتر یا مساوی {0} وارد کنید.")
});

stepsValidation.validate({
	ignore: 'input[type=hidden]', // ignore hidden fields
	errorClass: 'danger line-height-2',
	successClass: 'success line-height-2',
	highlight: function (element, errorClass) {
		$(element).removeClass(errorClass);
	},
	unhighlight: function (element, errorClass) {
		$(element).removeClass(errorClass);
	},
	errorPlacement: function (error, element) {
		error.insertAfter(element);
	},
	rules: {
		emailAddress: {
			required: true,
			email: true
		}
	},
	messages: {
		emailAddress: {
			required: "وارد کردن ایمیل الزامی است.",
			email: "لطفا یک ایمیل معتبر وارد نمایید."
		}
	}
});

// live Icon color change on state change
$(document).ready(function () {
	$(".current").find(".step-icon").addClass("bx bx-time-five");
	$(".current").find(".fonticon-wrap .livicon-evo").updateLiviconEvo({
		strokeColor: '#5A8DEE'
	});
});

// Icon change on state

// if click on next button icon change
$(".actions [href='#next']").click(function () {
	$(".done").find(".step-icon").removeClass("bx bx-time-five").addClass("bx bx-check-circle");
	$(".current").find(".step-icon").removeClass("bx bx-check-circle").addClass("bx bx-time-five");
	// live icon color change on next button's on click
	$(".current").find(".fonticon-wrap .livicon-evo").updateLiviconEvo({
		strokeColor: '#5A8DEE'
	});
	$(".current").prev("li").find(".fonticon-wrap .livicon-evo").updateLiviconEvo({
		strokeColor: '#39DA8A'
	});
});

$(".actions [href='#previous']").click(function () {
	// live icon color change on next button's on click
	$(".current").find(".fonticon-wrap .livicon-evo").updateLiviconEvo({
		strokeColor: '#5A8DEE'
	});
	$(".current").next("li").find(".fonticon-wrap .livicon-evo").updateLiviconEvo({
		strokeColor: '#adb5bd'
	});
});

// if click on  submit   button icon change
$(".actions [href='#finish']").click(function () {
	$(".done").find(".step-icon").removeClass("bx-time-five").addClass("bx bx-check-circle");
	$(".last.current.done").find(".fonticon-wrap .livicon-evo").updateLiviconEvo({
		strokeColor: '#39DA8A'
	});
});

// add primary btn class
$('.actions a[role="menuitem"]').addClass("btn btn-primary");
$('.icon-tab [role="menuitem"]').addClass("glow ");
$('.wizard-vertical [role="menuitem"]').removeClass("btn-primary").addClass("btn-light-primary");
