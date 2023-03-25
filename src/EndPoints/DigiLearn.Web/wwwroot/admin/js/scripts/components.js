/*=========================================================================================
  File Name: Components.js
  Description: For Generic Components.
==========================================================================================*/

(function (window, document, $) {

	/***********************/
	// Component Variables //
	/***********************/
	var accordion = $(".accordion"),
		defaultaccordion = $(".accordion .card-header"),
		collapseTitle = $(".collapsible .card-header"),
		collapseHoverTitle = $(".card-hover .card-header"),
		dropdownMenuIcon = $(".dropdown-icon-wrapper .dropdown-item");

	// To open Collapse on hover
	if (accordion.attr("data-toggle-hover", "true")) {
		collapseHoverTitle.closest(".card").on("mouseenter", function () {
			var $this = $(this);
			$this.children(".collapse").collapse("show");
			$this.closest(".card").addClass("open");
		});
		collapseHoverTitle.closest(".card").on("mouseleave", function () {
			var $this = $(this);
			$this.children(".collapse").collapse("hide");
			$this.closest(".card").removeClass("open");
		});
	}
	// When Collapse open on click
	collapseTitle.on("click", function () {
		var $this = $(this);
		$this.next(".collapse").on('show.bs.collapse', function () {
			$this.parent().addClass("open")
		})
		$this.next(".collapse.show").on('hide.bs.collapse', function () {
			$this.parent().removeClass("open")
		})
	});
	// When accordion open on click
	defaultaccordion.on("click", function () {
		var $this = $(this);
		if ($this.parent().next(".show")) {
			$this.closest(".card").toggleClass("open");
			$this.closest(".card").siblings(".open").removeClass("open");
		}
	});

	/************/
	// Dropdown //
	/************/
	// For Dropdown With Icons
	dropdownMenuIcon.on("click", function () {
		$(".dropdown-icon-wrapper .dropdown-toggle i").remove();
		$(this).find("i").clone().appendTo(".dropdown-icon-wrapper .dropdown-toggle");
		$(".dropdown-icon-wrapper .dropdown-toggle .dropdown-item").removeClass("dropdown-item");
	});

	/*********/
	// Chips //
	/*********/
	// To close chips
	$('.chip-closeable').on('click', function () {
		$(this).closest('.chip').remove();
	})

	/***********/
	// Tooltip //
	/***********/
	// Add Custom Class For Light Tooltip

	if (typeof $.fn.tooltip.Constructor === 'undefined') {
		throw new Error('Bootstrap Tooltip must be included first!');
	}

	var Tooltip = $.fn.tooltip.Constructor;

	// add customClass option to Bootstrap Tooltip
	$.extend(Tooltip.Default, {
		customClass: ''
	});

	var _show = Tooltip.prototype.show;

	Tooltip.prototype.show = function () {

		// invoke parent method
		_show.apply(this, Array.prototype.slice.apply(arguments));

		if (this.config.customClass) {
			var tip = this.getTipElement();
			$(tip).addClass(this.config.customClass);
		}

	};

	/***************/
	// widget chat //
	/**************/
	// Widget - chat area perfect scrollbar initialization
	if ($(".widget-chat-demo-scroll").length > 0) {
		var chat_scroll_owner_user = new PerfectScrollbar(".widget-chat-demo-scroll", {
			wheelPropagation: false
		});
	}
	// widget chat hide/show on demo chat button click
	$(".chat-demo-button").click(function () {
		$(".widget-chat-demo").toggleClass("d-block d-none");
	});
	// widget chat hide on close button click
	$(".widget-chat-close").click(function () {
		$(".widget-chat-demo").toggleClass("d-block d-none");
	});
	// widget chat autoscroll to bottom of Chat area on click on demo chat button
	$(".chat-demo-button").on("click", function () {
		$(".widget-chat-demo-scroll").animate({
			scrollTop: $(".widget-chat-demo-scroll")[0].scrollHeight
		}, 800)
	});

})(window, document, jQuery);

// widget chat function to add message to chat demo
function widgetChatMessageDemo(source) {
	var message = $(".chat-message-demo").val();
	if (message != "") {
		var html = '<div class="chat-message">' + "<p>" + message + "</p>" + "<div class=" + "chat-time" + ">5:01 ب.ظ</div></div>";
		$(".widget-chat-demo .chat:last-child .chat-body").append(html);
		$(".chat-message-demo").val("");
		$(".widget-chat-demo-scroll").scrollTop($(".widget-chat-demo-scroll > .chat-content").height());
	}
}