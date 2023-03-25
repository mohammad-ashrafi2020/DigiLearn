/*=========================================================================================
    File Name: app-email.js
    Description: app-email Javascripts
==========================================================================================*/

$(function () {
	"use strict";
	// variables
	var appContent = $(".app-content"),
		appContentOverlay = $(".app-content-overlay"),
		sideBarLeft = $(".sidebar-left"),
		email_app_details = $(".email-app-details"),
		email_application = $(".email-application"),
		userNewMailSideBar = $(".compose-new-mail-sidebar"),
		email_user_list = $(".email-user-list"),
		email_app_list = $(".email-app-list"),
		checkbox_con = $(".user-action .checkbox-con"),
		$primary = "#5A8DEE";

	// To add Perfect Scrollbar
	// ---------------------------

	// Email left Sidebar
	if ($('.sidebar-menu-list').length > 0) {
		var sidebar_menu_list = new PerfectScrollbar(".sidebar-menu-list", {
			wheelPropagation: false
		});
	}

	// User list scroll
	if (email_user_list.length > 0) {
		var users_list = new PerfectScrollbar(".email-user-list", {
			wheelPropagation: false
		});
	}

	// Email detail section
	if ($('.email-scroll-area').length > 0) {
		var email_scroll_area = new PerfectScrollbar(".email-scroll-area", {
			wheelPropagation: false
		});
	}

	// new email dialog scroll
	if (userNewMailSideBar.length > 0) {
		var compose_new_mail_sidebar = new PerfectScrollbar(".compose-new-mail-sidebar", {
			wheelPropagation: false
		});
	}

	// --------------------------------------
	// Quill Editor
	//---------------------------------------

	//  Details mail Message reply field
	var detailMailEditor = new Quill('.snow-container .detail-view-editor', {
		modules: {
			toolbar: '.detail-quill-toolbar'
		},
		placeholder: 'چیزی بنویسید ... ',
		theme: 'snow'
	});

	//email new compose message compose field
	var composeMailEditor = new Quill('.snow-container .compose-editor', {
		modules: {
			toolbar: '.compose-quill-toolbar'
		},
		placeholder: 'چیزی بنویسید ... ',
		theme: 'snow'
	});

	// Quill get focus when click on reply
	$('.mail-reply').on('click', function () {
		detailMailEditor.focus();
	});

	//------------------------------------
	// sidebar-left
	// -----------------------------------

	// Main menu toggle should hide app menu
	$('.menu-toggle').on('click', function (e) {
		appContent.find('.sidebar-left').removeClass('show');
		appContentOverlay.removeClass('show');
		userNewMailSideBar.removeClass('show');
	});

	// Sidebar menu close button on click remove show class form both compose mail sidebar and App content overlay
	email_application.find(".sidebar-close-icon").on('click', function () {
		sideBarLeft.removeClass('show');
		appContentOverlay.removeClass('show');
	});

	// Email Sidebar Toggle button to show email sidebar
	$('.sidebar-toggle').on('click', function (e) {
		e.stopPropagation();
		sideBarLeft.toggleClass('show');
		appContentOverlay.addClass('show');
	});

	// On Ovelay Click remove show class form both sidebarleft and App content Overlay
	appContentOverlay.on('click', function () {
		sideBarLeft.removeClass('show');
		appContentOverlay.removeClass('show');
	});

	// Add class active on click of sidebar list folder and label
	email_application.find(".list-group-messages a,.list-group-labels a").on('click', function () {
		var $this = $(this);
		if (email_application.find('.list-group-messages a,.list-group-labels a').hasClass('active')) {
			email_application.find('.list-group-messages a,.list-group-labels a').removeClass('active');
			$this.addClass("active");
			// live icon change when active state
			$(".list-group-messages a").siblings().find(".livicon-evo").updateLiviconEvo({
				strokeColor: '#475f7b'
			});
			$this.find(".livicon-evo").updateLiviconEvo({
				strokeColor: $primary
			});
		}
	});
	// sidebar content's close btn on small screen
	$(".sidebar-close-icon").on('click', function () {
		$('.sidebar-content').removeClass('show');
		appContentOverlay.removeClass('show');
	});

	// -------------------------------
	// Content Right
	// -------------------------------

	// on click show class from Email details
	email_app_list.find('.email-user-list li').on('click', function () {
		email_app_details.toggleClass('show');
	});

	// on click of go button or inbox btn get back to inbox
	$('.go-back, #inbox-menu').on('click', function (e) {
		e.stopPropagation();
		email_app_details.removeClass('show');
		var quill_editor = $(".detail-view-editor .ql-editor"); // quill editor content
		quill_editor[0].innerHTML = "";
	});

	//on star click bookmark email
	email_application.find(".favorite i").on("click", function (e) {
		e.stopPropagation();
		var $this = $(this)
		$this.parent('.favorite').toggleClass("warning");
		if ($this.hasClass("bx-star")) {
			$this.addClass("bxs-star");
			$this.removeClass("bx-star");
		} else {
			$this.addClass("bx-star");
			$this.removeClass("bxs-star");
		}
	});

	// On checkbox click stop propogation
	checkbox_con.on("click", function (e) {
		e.stopPropagation();
	});

	// on checkbox status change add or remove background color class
	checkbox_con.find("input").on('change', function () {
		var $this = $(this);
		if ($this.is(":checked")) {
			$this.closest(".media").addClass("selected-row-bg");
		} else {
			$this.closest(".media").removeClass("selected-row-bg");
		}
	});

	// Select all checkbox
	$(document).on("change", ".email-app-list .selectAll input", function () {
		if ($(this).is(":checked")) {
			checkbox_con.find("input").prop('checked', this.checked).closest(".media").addClass("selected-row-bg");
		} else {
			checkbox_con.find("input").prop('checked', "").closest(".media").removeClass("selected-row-bg");
		}
	});

	// On click of delete btn, delete all emails & show "no result found"
	email_application.find(".mail-delete").on("click", function () {
		checkbox_con.find("input:checked").closest("li").remove();
		email_application.find(".selectAll input").prop('checked', "");

		var tbl_row = $(".email-user-list .users-list-wrapper li:visible").length; //here tbl_test is table name

		//Check if table has row or not
		if (tbl_row == 0) {
			email_user_list.find('.no-results').addClass('show');
		} else {
			if (email_user_list.find('.no-results').hasClass('show')) {
				email_user_list.find('.no-results').removeClass('show');
			}
		}
	});

	// Mark unread mail and remove background color when checkbox unchecked
	email_application.find(".mail-unread").on("click", function () {
		checkbox_con.find("input:checked").closest("li").removeClass("mail-read");
		email_application.find(".user-action .checkbox-con input:checked , .selectAll input").prop('checked', "").closest(".media").removeClass("selected-row-bg");
	});

	// Search Filter
	email_app_list.find("#email-search").on("keyup", function () {
		var value = $(this).val().toLowerCase();
		$('.media').css('animation', 'none')
		if (value != "") {
			email_user_list.find(".users-list-wrapper li").filter(function () {
				$(this).toggle($(this).text().toLowerCase().indexOf(value) > -1);
			});
			var tbl_row = $(".email-user-list .users-list-wrapper li:visible").length; //here tbl_row is table name

			//Check if table has row or not
			if (tbl_row == 0) {
				email_user_list.find('.no-results').addClass('show');
			} else {
				if (email_user_list.find('.no-results').hasClass('show')) {
					email_user_list.find('.no-results').removeClass('show');
				}
			}
		} else {
			// If filter box is empty
			email_user_list.find(".users-list-wrapper li").show();
			if (email_user_list.find('.no-results').hasClass('show')) {
				email_user_list.find('.no-results').removeClass('show');
			}
		}
	});
	// manually hide dropdown menu
	$(".email-detail-head .dropdown-item").on("click", function () {
		$(".dropdown-toggle").dropdown('hide');
	});
	// ------------------------------------------
	// Compose new mail sidebar
	// -------------------------------------------

	// On Click of Close Icon btn, cancel btn and overlay remove show class from compose mail and overlay
	// and reset all form field
	$(".close-icon, .cancel-btn, .app-content-overlay").on('click', function () {
		userNewMailSideBar.removeClass('show');
		appContentOverlay.removeClass('show');
		$('#compose-form').find('input').val(""); // input filed reset when close or cancel
		var file_input = $(".custom-file .custom-file-label"); // file input content
		file_input[0].innerHTML = "ضمیمه کردن فایل";
		var quill_editor = $("#compose-form .ql-editor"); // quill editor content
		quill_editor[0].innerHTML = "";
	});

	// On compose btn clik of compose mail visible and sidebar left hide
	$('.compose-btn').on('click', function () {
		userNewMailSideBar.addClass('show');
		appContentOverlay.addClass('show');
		sideBarLeft.removeClass('show');
	});

	// stop propogation on dropdown
	$(".information .dropdown-menu a").on("click", function (e) {
		e.stopPropagation();
		$(this).parent().removeClass('show');
	});

	// On screen Resize JS
	// -----------------------------------

	// For app sidebar on small screen
	if ($(window).width() > 768) {
		if (appContentOverlay.hasClass('show')) {
			appContentOverlay.removeClass('show');
		}
	}

	$(window).on("resize", function () {
		// remove show classes from sidebar and overlay if size is > 768
		if ($(window).width() > 768) {
			if (appContentOverlay.hasClass('show')) {
				sideBarLeft.removeClass('show');
				appContentOverlay.removeClass('show');
				userNewMailSideBar.removeClass('show');
			}
			$('#compose-form').find('input').val(""); // input filed reset when resize screen
			var file_input = $(".custom-file .custom-file-label"); // file input content
			file_input[0].innerHTML = "ضمیمه کردن فایل";
			var quill_editor = $("#compose-form .ql-editor"); // quill editor content
			quill_editor[0].innerHTML = "";
		}
	});
});