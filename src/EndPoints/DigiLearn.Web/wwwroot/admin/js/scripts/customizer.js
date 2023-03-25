/*=========================================================================================
  File Name: customizer.js
  Description: Template customizer js.
==========================================================================================*/

(function (window, document, $) {
	'use strict';
	// main menu active gradient colors object
	var themeColor = {
		"theme-primary": "rgba(90, 141, 238, 0.2)",
		"theme-success": "rgba(57, 218, 138, 0.2)",
		"theme-danger": "rgba(255, 91, 92, 0.2)",
		"theme-info": "rgba(0, 207, 221, 0.2)",
		"theme-warning": "rgba(253, 172, 65, 0.2)",
		"theme-dark": "rgba(57, 76, 98, 0.2)"
	}
	// main menu active box shadow object
	var themeBoxShadow = {
		"theme-primary": "0 0 10px 1px rgba(90, 141, 238, 0.2)",
		"theme-success": "0 0 10px 1px rgba(57, 218, 138, 0.2)",
		"theme-danger": "0 0 10px 1px rgba(255, 91, 92, 0.2)",
		"theme-info": "0 0 10px 1px rgba(0, 207, 221, 0.2)",
		"theme-warning": "0 0 10px 1px rgba(253, 172, 65, 0.2)",
		"theme-dark": "0 0 10px 1px rgba(57, 76, 98, 0.2)"
	}
	// colors for navbar header text of main menu
	var currentColor = {
		"theme-default": "#FFFFFF",
		"theme-primary": "#5A8DEE",
		"theme-success": "#39DA8A",
		"theme-danger": "#FF5B5C",
		"theme-info": "#00CFDD",
		"theme-warning": "#FDAC41",
		"theme-dark": "#394C62"
	}
	// Brand Logo Poisitons
	var LogoPosition = {
		"theme-primary": "-65px -54px",
		"theme-success": "-120px -10px",
		"theme-danger": "-10px -10px",
		"theme-info": "-10px -54px",
		"theme-warning": "-120px -54px",
		"theme-dark": "-65px -10px"
	}

	var body = $("body"),
		appContent = $(".app-content"),
		mainMenu = $(".main-menu"),
		mainMenuContent = $(".menu-content"),
		footer = $(".footer"),
		navbar = $(".header-navbar"),
		mainHeaderNavbar = $(".main-header-navbar"),
		navbarLight = $(".navbar-light"),
		navBarShadow = $(".header-navbar-shadow"),
		toggleIcon = $(".toggle-icon"),
		collapseSidebar = $("#collapse-sidebar-switch"),
		iconAnimation = $("#icon-animation-switch"),
		customizer = $(".customizer"),
		brandLogo = $(".brand-logo");

	// Customizer toggle & close button click events  [Remove customizer code from production]
	$('.customizer-toggle').on('click', function (e) {
		e.preventDefault();
		$(customizer).toggleClass('open');
	});
	$('.customizer-close').on('click', function () {
		$(customizer).removeClass('open');
	});

	// perfect scrollbar for customizer
	if ($('.customizer-content').length > 0) {
		var customizer_content = new PerfectScrollbar('.customizer-content', {
			wheelPropagation: false
		});
	}

	/***** Theme Colors Options *****/
	$(document).on("click", "#customizer-theme-colors .color-box", function () {
		var $this = $(this);
		$this.siblings().removeClass('selected');
		$this.addClass("selected");
		var selectedColor = $(this).data("color"),
			changeColor = themeColor[selectedColor],
			selectedShadow = themeBoxShadow[selectedColor],
			selectedTextColor = currentColor[selectedColor],
			selectedLogo = LogoPosition[selectedColor];

		// Update livicon colors
		function updateLivicon(el) {
			el.updateLiviconEvo({
				strokeColor: selectedTextColor,
				solidColor: selectedTextColor,
				fillColor: selectedTextColor,
				strokeColorAlt: selectedTextColor
			})
		}

		// main-menu
		if (mainMenuContent.find("li.active").length) {
			mainMenuContent.find("li.active a").css({
				"color": selectedTextColor
			});
			mainMenuContent.find("li.active a > i").css({
				"color": selectedTextColor
			});
			mainMenuContent.find("li.active a span.menu-item").css({
				"color": selectedTextColor
			});
			mainMenuContent.find("li.active").css({
				"background": changeColor,
				"border-color": selectedTextColor
			});
			// Update Active Menu item Icon with active color
			if ($('li.sidebar-group-active .menu-livicon').length) {
				updateLivicon($('li.sidebar-group-active .menu-livicon'));
			}
		} else {
			mainMenu.find(".nav-item.active a").css({
				"background": changeColor,
				"color": selectedTextColor
			});
			mainMenu.find(".nav-item.active a .menu-title").css({
				"color": selectedTextColor
			});
			// Update Active Menu item Icon with active color
			if ($('.nav-item.active .menu-livicon').length) {
				updateLivicon($('.nav-item.active .menu-livicon'));
			}
		}
	});

	/***** Theme Layout Options *****/
	$(".layout-name").on("click", function () {
		var $this = $(this);
		var currentLayout = $this.data("layout");
		body.removeClass("dark-layout semi-dark-layout").addClass(currentLayout);
		if (currentLayout === "") {
			mainMenu.removeClass("menu-dark").addClass("menu-light");
			navbar.removeClass("navbar-dark").addClass("navbar-light");
			mainHeaderNavbar.css({
				"background-color": "inherit"
			})
		}
		if (body.hasClass("dark-layout")) {
			mainMenu.removeClass("menu-light").addClass("menu-dark");
			navbar.removeClass("navbar-light").addClass("navbar-dark");
			mainHeaderNavbar.css({
				"background-color": "inherit"
			})
		}
		if (body.hasClass("semi-dark-layout")) {
			mainMenu.removeClass("menu-light").addClass("menu-dark");
			navbar.removeClass("navbar-dark").addClass("navbar-light");
			mainHeaderNavbar.css({
				"background-color": "inherit"
			})
		}
	})

	// checks right radio if layout type matches
	var layout = body.data("layout");
	$(".layout-name[data-layout='" + layout + "']").prop('checked', true);

	/***** icon animation switch *****/
	iconAnimation.on("click", function () {
		if ($(this).is(':checked')) {
			$('#main-menu-navigation .menu-livicon').updateLiviconEvo({
				animated: true
			});
		} else {
			$('#main-menu-navigation .menu-livicon').updateLiviconEvo({
				animated: false
			});
		}
	});

	/***** Collapse menu switch *****/
	collapseSidebar.on("click", function () {
		if ($(body).hasClass("menu-expanded")) {
			body.removeClass("menu-expanded").addClass("menu-collapsed");
			mainMenu.removeClass("expanded");
			mainMenu.find(".sidebar-group-active").removeClass("open").addClass("menu-collapsed-open");
			toggleIcon.removeClass("bx bx-disc").addClass("bx bx-circle");

		} else {
			body.removeClass("menu-collapsed").addClass("menu-expanded");
			mainMenu.find(".sidebar-group-active").addClass("open");
			toggleIcon.removeClass("bx bx-circle").addClass("bx bx-disc");
		}
	})
	// connects toggle icon with collapse sidebar switch
	toggleIcon.on("click", function () {
		collapseSidebar.prop("checked", !collapseSidebar.prop("checked"));
	})

	// checks if main menu is collapsed by default
	if (body.hasClass("menu-collapsed")) {
		collapseSidebar.prop("checked", true);
	} else {
		collapseSidebar.prop("checked", false);
	}

	/***** Navbar Color Options *****/
	if ($(body).hasClass("horizontal-layout")) {
		$("#customizer-navbar-colors .color-box.bg-white").removeClass('selected').hide();
		$("#customizer-navbar-colors .color-box.bg-primary").addClass('selected');
		$('#customizer-theme-colors').hide();
		$('.navbar-type .hidden-ele').hide();
	}
	if ($(body).hasClass("navbar-static")) {
		$("#navbar-static").attr('checked', "true");
	}
	if ($(body).hasClass("boxicon-layout")) {
		$('#menu-icon-animation').hide();
	}
	$("#customizer-navbar-colors .color-box").on("click", function () {
		var $this = $(this);
		$this.siblings().removeClass('selected');
		$this.addClass("selected");
		var navbarColor = $this.data("navbar-color");
		if ($(body).hasClass("vertical-layout")) {
			if ($(window).scrollTop() > 20) {
				// changes navbar colors
				if (navbarColor) {
					$(".vertical-layout")
						.find(navbar)
						.removeClass("bg-primary bg-success bg-danger bg-info bg-warning bg-dark navbar-light")
						.addClass(navbarColor + " navbar-dark");
				} else {
					$(".vertical-layout.navbar-sticky")
						.find(navbar)
						.addClass('navbar-light').removeClass('navbar-dark')
						.removeClass("bg-primary bg-success bg-danger bg-info bg-warning bg-white bg-dark navbar-dark");
				}
				if (body.hasClass("dark-layout")) {
					navbar.addClass("navbar-dark")
				}
			}
		} else {
			if (navbarColor) {
				$(".horizontal-layout")
					.find('.navbar-with-menu')
					.removeClass("bg-primary bg-success bg-danger bg-info bg-warning bg-dark")
					.addClass(navbarColor);
			}
		}
	})

	/***** Navbar Color On Scroll *****/
	$(window).scroll(function () {
		var navbarActiveColor = $("#customizer-navbar-colors .color-box.selected").data("navbar-color");
		if ($(this).scrollTop() < 20) {
			$(".vertical-layout.navbar-sticky")
				.find(mainHeaderNavbar)
				.removeClass("bg-primary bg-success bg-danger bg-info bg-warning bg-white bg-dark navbar-dark")
		} else {
			if (navbarActiveColor) {
				$(".vertical-layout.navbar-sticky")
					.find(mainHeaderNavbar)
					.removeClass("bg-primary bg-success bg-danger bg-info bg-warning bg-white bg-dark navbar-dark")
					.addClass(navbarActiveColor + " navbar-dark");
			}
		}
	});

	/***** Navbar Type *****/
	if ($(body).hasClass("horizontal-layout")) {
		navbar = $('.header-navbar.navbar-with-menu');
		var navbarHorizontal = $('.header-navbar.navbar-horizontal');

		// changes to Static navbar
		$("#navbar-static").on("click", function () {
			navBarShadow.addClass("d-none");
			navbar
				.removeClass("d-none floating-nav fixed-top navbar-fixed")
				.addClass("navbar-static-top");
			body.removeClass("navbar-hidden navbar-floating navbar-sticky").addClass("navbar-static");
			navbarHorizontal.removeClass("d-none floating-nav fixed-top navbar-fixed")
				.addClass("navbar-sticky");
		});
		// changes to Static navbar
		$("#navbar-sticky").on("click", function () {
			navBarShadow.addClass("d-none");
			navbar
				.removeClass("d-none floating-nav navbar-static-top")
				.addClass("fixed-top");
			body.removeClass("navbar-static navbar-floating navbar-hidden").addClass("navbar-sticky");
		});
	} else {
		// Hides Navbar
		$("#navbar-hidden").on("click", function () {
			navbar.addClass("d-none");
			navBarShadow.addClass("d-none");
			body.removeClass("navbar-static navbar-floating navbar-sticky").addClass("navbar-hidden");
		});
		// changes to Static navbar
		$("#navbar-static").on("click", function () {
			navBarShadow.addClass("d-none");
			navbar
				.removeClass("bg-primary bg-success bg-danger bg-info bg-warning bg-white bg-dark navbar-dark")
				.removeClass("d-none floating-nav fixed-top")
				.addClass("navbar-static-top");
			body.removeClass("navbar-hidden navbar-floating navbar-sticky").addClass("navbar-static");
		});
		// changes to Static navbar
		$("#navbar-sticky").on("click", function () {
			navBarShadow.addClass("d-none");
			navbar
				.removeClass("d-none floating-nav navbar-static-top")
				.addClass("fixed-top");
			body.removeClass("navbar-static navbar-floating navbar-hidden").addClass("navbar-sticky");
		});
	}

	/***** Footer Type *****/
	// Hides footer
	$("#footer-hidden").on("click", function () {
		footer.addClass("d-none");
		body.removeClass("footer-static fixed-footer").addClass("footer-hidden");
	});
	// changes to Static footer
	$("#footer-static").on("click", function () {
		body.removeClass("fixed-footer");
		footer.removeClass("d-none").addClass("footer-static");
		body.removeClass("footer-hidden fixed-footer").addClass("footer-static");
	});
	// changes to Sticky footer
	$("#footer-sticky").on("click", function () {
		body.removeClass("footer-static fixed-hidden").addClass("fixed-footer");
		footer.removeClass("d-none footer-static");
	});

	/***** Card Shadow Starts *****/
	$("#card-shadow-switch").on("click", function () {
		body.toggleClass('no-card-shadow');
	});

	/***** Hide Scroll To Top *****/
	$("#hide-scroll-top-switch").on("click", function () {
		var scrollTopBtn = $(".scroll-top")
		if ($(this).prop("checked")) {
			scrollTopBtn.addClass("d-none");
		} else {
			scrollTopBtn.removeClass("d-none");
		}
	});
})(window, document, jQuery);