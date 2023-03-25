/*=========================================================================================
    File Name: app-chat.js
    Description: chat application
==========================================================================================*/

var chatSidebarListWrapper = $(".chat-sidebar-list-wrapper"),
	chatOverlay = $(".chat-overlay"),
	chatContainer = $(".chat-container"),
	chatSidebarProfileToggle = $(".chat-sidebar-profile-toggle"),
	chatProfileToggle = $(".chat-profile-toggle"),
	chatSidebarClose = $(".chat-sidebar-close"),
	chatProfile = $(".chat-profile"),
	chatUserProfile = $(".chat-user-profile"),
	chatProfileClose = $(".chat-profile-close"),
	chatSidebar = $(".chat-sidebar"),
	chatArea = $(".chat-area"),
	chatStart = $(".chat-start"),
	chatSidebarToggle = $(".chat-sidebar-toggle"),
	chatMessageSend = $(".chat-message-send");

$(document).ready(function () {
	"use strict";
	// menu user list perfect scrollbar initialization
	if (chatSidebarListWrapper.length > 0) {
		var menu_user_list = new PerfectScrollbar(".chat-sidebar-list-wrapper");
	}
	// user profile sidebar perfect scrollbar initialization
	if ($(".chat-user-profile-scroll").length > 0) {
		var profile_sidebar_scroll = new PerfectScrollbar(".chat-user-profile-scroll");
	}
	// chat area perfect scrollbar initialization
	if (chatContainer.length > 0) {
		var chat_user_user = new PerfectScrollbar(".chat-container");
	}
	if ($(".chat-profile-content").length > 0) {
		var chat_profile_content = new PerfectScrollbar(".chat-profile-content");
	}
	// user profile sidebar toggle
	chatSidebarProfileToggle.on("click", function () {
		chatUserProfile.addClass("show");
		chatOverlay.addClass("show");
	});
	// user profile sidebar toggle
	chatProfileToggle.on("click", function () {
		chatProfile.addClass("show");
		chatOverlay.addClass("show");
	});
	// on profile close icon click
	chatProfileClose.on("click", function () {
		chatUserProfile.removeClass("show");
		chatProfile.removeClass("show");
		if (!chatSidebar.hasClass("show")) {
			chatOverlay.removeClass("show");
		}
	});
	// On chat menu sidebar close icon click
	chatSidebarClose.on("click", function () {
		chatSidebar.removeClass("show");
		chatOverlay.removeClass("show");
	});
	// on overlay click
	chatOverlay.on("click", function () {
		chatSidebar.removeClass("show");
		chatOverlay.removeClass("show");
		chatUserProfile.removeClass("show");
		chatProfile.removeClass("show");
	});
	// Add class active on click of Chat users list
	$(".chat-sidebar-list-wrapper ul li").on("click", function () {
		if ($(".chat-sidebar-list-wrapper ul li").hasClass("active")) {
			$(".chat-sidebar-list-wrapper ul li").removeClass("active");
		}
		$(this).addClass("active");
		if ($(".chat-sidebar-list-wrapper ul li").hasClass("active")) {
			chatStart.addClass("d-none");
			chatArea.removeClass("d-none");
		} else {
			chatStart.removeClass("d-none");
			chatArea.addClass("d-none");
		}
	});
	// app chat favorite star click
	$(".chat-icon-favorite i").on("click", function (e) {
		$(this).parent(".chat-icon-favorite").toggleClass("warning");
		$(this).toggleClass("bxs-star bx-star");
		e.stopPropagation();
	});
	// menu toggle till medium screen
	if ($(window).width() < 992) {
		chatSidebarToggle.on("click", function () {
			chatSidebar.addClass("show");
			chatOverlay.addClass("show");
		});
	}
	// autoscroll to bottom of Chat area
	$(".chat-sidebar-list li").on("click", function () {
		chatContainer.animate({
			scrollTop: chatContainer[0].scrollHeight
		}, 400)
	});

	// click on main menu toggle will remove sidebars & overlays
	$(".menu-toggle").click(function () {
		chatSidebar.removeClass("show");
		chatOverlay.removeClass("show");
		chatUserProfile.removeClass("show");
		chatProfile.removeClass("show");
	});

	// chat search filter
	$("#chat-search").on("keyup", function () {
		var value = $(this).val().toLowerCase();
		if (value != "") {
			$(".chat-sidebar-list-wrapper .chat-sidebar-list li").filter(function () {
				$(this).toggle($(this).text().toLowerCase().indexOf(value) > -1);
			});
		} else {
			// if search filter box is empty
			$(".chat-sidebar-list-wrapper .chat-sidebar-list li").show();
		}
	});
	// window resize
	$(window).on("resize", function () {
		// remove show classes from overlay when resize, if size is > 992
		if ($(window).width() > 992) {
			if (chatOverlay.hasClass("show")) {
				chatOverlay.removeClass("show");
			}
		}
		// menu toggle on resize till medium screen
		if ($(window).width() < 992) {
			chatSidebarToggle.on("click", function () {
				chatSidebar.addClass("show");
				chatOverlay.addClass("show");
			});
		}
		// disable on click overlay when resize from medium to large
		if ($(window).width() > 992) {
			chatSidebarToggle.on("click", function () {
				chatOverlay.removeClass("show");
			});
		}
	});
});
// Add message to chat
function chatMessagesSend(source) {
	var message = chatMessageSend.val();
	if (message != "") {
		var html = '<div class="chat-message"><p>' + message + '</p><div class="chat-time">3:35 ق.ظ</div></div>';
		$(".chat-wrapper .chat:last-child .chat-body").append(html);
		chatMessageSend.val("");
		chatContainer.scrollTop($(".chat-container > .chat-content").height());
	}
}