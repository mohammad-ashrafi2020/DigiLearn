/*=========================================================================================
    File Name: app-todo.js
    Description: app-todo
==========================================================================================*/
// Todo App variables
var todoNewTasksidebar = $(".todo-new-task-sidebar"),
	appContentOverlay = $(".app-content-overlay"),
	sideBarLeft = $(".sidebar-left"),
	todoTaskListWrapper = $(".todo-task-list-wrapper"),
	todoItem = $(".todo-item"),
	selectAssignLable = $(".select2-assign-label"),
	selectUsersName = $(".select2-users-name"),
	avatarUserImage = $(".avatar-user-image"),
	updateTodo = $(".update-todo"),
	addTodo = $(".add-todo"),
	markCompleteBtn = $(".mark-complete-btn"),
	newTaskTitle = $(".new-task-title"),
	taskTitle = $(".task-title"),
	noResults = $(".no-results"),
	assignedAvatarContent = $(".assigned .avatar .avatar-content"),
	todoAppMenu = $(".todo-app-menu");

// badge colors object define here for badge color
var badgeColors = {
	"Frontend": "badge-light-primary",
	"Backend": "badge-light-success",
	"Issue": "badge-light-danger",
	"Design": "badge-light-warning",
	"Wireframe": "badge-light-info",
}

$(function () {
	"use strict";

	// Single Date Picker
	$('.pickadate').datepicker({
		dateFormat: "yy/mm/dd",
		showOtherMonths: true,
		selectOtherMonths: true,
		changeMonth: true,
		changeYear: true,
		showButtonPanel: false
	});

	// dragable list
	dragula([document.getElementById("todo-task-list-drag")], {
		moves: function (el, container, handle) {
			return handle.classList.contains("handle");
		}
	});


	// select assigner
	selectUsersName.select2({
		placeholder: "اختصاص داده نشده",
		dropdownAutoWidth: true,
		width: '100%'
	});

	// select label
	selectAssignLable.select2({
		dropdownAutoWidth: true,
		width: '100%'
	});

	// Sidebar scrollbar
	if ($('.todo-application .sidebar-menu-list').length > 0) {
		var sidebarMenuList = new PerfectScrollbar('.sidebar-menu-list', {
			theme: "dark",
			wheelPropagation: false
		});
	}

	//  New task scrollbar
	if (todoNewTasksidebar.length > 0) {
		var todo_new_task_sidebar = new PerfectScrollbar('.todo-new-task-sidebar', {
			theme: "dark",
			wheelPropagation: false
		});
	}

	// Task list scrollbar
	if ($('.todo-application .todo-task-list').length > 0) {
		var sidebar_todo = new PerfectScrollbar('.todo-task-list', {
			theme: "dark",
			wheelPropagation: false
		});
	}

	// New compose message compose field
	var composeEditor = new Quill('.snow-container .compose-editor', {
		modules: {
			toolbar: '.compose-quill-toolbar'
		},
		placeholder: 'افزودن توضیح ... ',
		theme: 'snow'
	});

	//Assigner Comment Quill editor
	var commentEditor = new Quill('.snow-container .comment-editor', {
		modules: {
			toolbar: '.comment-quill-toolbar'
		},
		placeholder: 'یک دیدگاه بنویسید ...',
		theme: 'snow'
	});

	// **************Sidebar Left**************//
	// -----------------------------------------

	// Main menu toggle should hide app menu
	$('.menu-toggle').on('click', function () {
		sideBarLeft.removeClass('show');
		appContentOverlay.removeClass('show');
		todoNewTasksidebar.removeClass('show');
	});

	//on click of app overlay removeclass show from sidebar left and overlay
	appContentOverlay.on('click', function () {
		sideBarLeft.removeClass('show');
		appContentOverlay.removeClass('show');
	});

	// Add class active on click of sidebar menu's filters
	todoAppMenu.find(".list-group a").on('click', function () {
		var $this = $(this);
		todoAppMenu.find(".active").removeClass('active');
		$this.addClass("active")
		// if active class available icon color primary blue else gray
		if ($this.hasClass('active')) {
			$this.find(".livicon-evo").updateLiviconEvo({
				strokeColor: '#5A8DEE'
			});
			todoAppMenu.find(".list-group a").not(".active").find(".livicon-evo").updateLiviconEvo({
				strokeColor: '#475f7b'
			});
		}
	});

	//On compose btn click of compose mail visible and sidebar left hide
	$('.add-task-btn').on('click', function () {
		//show class add on new task sidebar,overlay
		todoNewTasksidebar.addClass('show');
		appContentOverlay.addClass('show');
		sideBarLeft.removeClass('show');
		taskTitle.focus();
		//d-none add on avatar and remove from avatar-content
		avatarUserImage.addClass("d-none");
		assignedAvatarContent.removeClass("d-none");
		//select2 value null assign
		selectUsersName.val(null).trigger('change');
		selectAssignLable.val(null).trigger('change');
		//update button has add class d-none remove from add TODO
		updateTodo.addClass("d-none");
		addTodo.removeClass("d-none");
		//mark complete btn should hide & new task title will visible
		markCompleteBtn.addClass("d-none");
		newTaskTitle.removeClass("d-none");
		//Input field Value empty
		taskTitle.val("");
		var compose_editor = $(".compose-editor .ql-editor");
		compose_editor[0].innerHTML = "";
		var comment_editor = $(".comment-editor .ql-editor");
		comment_editor[0].innerHTML = "";
		selectAssignLable.attr("disabled", "true");
	});

	// On sidebar close click hide sidebarleft and overlay
	$(".todo-application .sidebar-close-icon").on('click', function () {
		sideBarLeft.removeClass('show');
		appContentOverlay.removeClass('show');
	});

	// **************New Task sidebar**************//
	// ---------------------------------------------

	// add new task
	addTodo.on("click", function () {
		// check task assigned or not
		function renderAvatar(src) {
			if (src !== undefined) {
				return '<img src="' + src + '"alt="avatar" height="30" width="30" >'
			} else {
				return '<div class="avatar-content"><i class="bx bx-user font-medium-4"></i></div>'
			}
		};
		// if add task field are fiill and create a new task
		if (taskTitle.val().length > 0) {
			var titleTask = taskTitle.val(),
				selectAssign = $(".select2-users-name option:selected").val(),
				$randomID = Math.floor((Math.random() * 100) + Date.now()), //generate random id
				selectedVal = $(".select2-assign-label option:selected"),
				selectedTags = [];
			selectedVal.each(function () {
				selectedTags.push($(this).text());
			})
			var newTags = selectedTags.map(function (tag) {
				// map through every tag and create badges accordingly.
				return '<span class="badge ' + badgeColors[tag] + ' badge-pill ml-25"> ' + tag + ' </span>' //badge created here
			})

			var avatarSRC = todoTaskListWrapper.find("[data-name='" + selectAssign + "']").find(".avatar img").attr("src"); //Img src find if data name matches with list
			todoTaskListWrapper.append(
				// append a new task in task list
				'<li class="todo-item no-animation" data-name="' + selectAssign + '">' +
				'<div class="todo-title-wrapper d-flex justify-content-between align-items-center">' +
				'<div class="todo-title-area d-flex align-items-center">' +
				'<i class="bx bx-grid-vertical handle"></i>' +
				'<div class="checkbox">' +
				'<input type="checkbox" class="checkbox-input" id="' + $randomID + '">' +
				'<label for="' + $randomID + '"></label>' + '</div>' +
				'<p class="todo-title mx-50 m-0 truncate">' + titleTask + '</p>' +
				'</div>' +
				'<div class="todo-item-action d-flex align-items-center">' + newTags.join("") +
				'<div class="avatar ml-1">' + renderAvatar(avatarSRC) +
				'</div>' +
				'<a class="todo-item-favorite ml-50">' +
				'<i class="bx bx-star"></i>' + '</a>' +
				'<a class="todo-item-delete ml-50">' + '<i class="bx bx-trash"></i>' + '</a>' +
				'</div></div></li>');
			// new task sidebar, overlay hide
			todoNewTasksidebar.removeClass('show');
			appContentOverlay.removeClass('show');
			selectAssignLable.attr("disabled", "true");
		} else {
			// new task sidebar, overlay hide
			todoNewTasksidebar.removeClass('show');
			appContentOverlay.removeClass('show');
			selectAssignLable.attr("disabled", "true");
		}
	});

	// On Click of Close Icon btn, cancel btn and overlay remove show class from new task sidebar and overlay
	// and reset all form fields
	$(".close-icon, .cancel-btn, .app-content-overlay, .mark-complete-btn").on('click', function () {
		todoNewTasksidebar.removeClass('show');
		appContentOverlay.removeClass('show');
		setTimeout(function () {
			todoNewTasksidebar.find('textarea').val("");
			var compose_editor = $(".compose-editor .ql-editor");
			compose_editor[0].innerHTML = "";
			var comment_editor = $(".comment-editor .ql-editor");
			comment_editor[0].innerHTML = "";
			selectAssignLable.attr("disabled", "true");
		}, 100)
	});

	// on click of add label icon select 2 display
	$(".add-tags").on("click", function () {
		if (selectAssignLable.is('[disabled]')) {
			selectAssignLable.removeAttr("disabled");
		} else {
			selectAssignLable.attr("disabled", "true");
		}
	});

	// Update Task
	updateTodo.on("click", function () {
		todoNewTasksidebar.removeClass('show');
		appContentOverlay.removeClass('show');
		selectAssignLable.attr("disabled", "true");
	});

	// ************Rightside content************//
	// -----------------------------------------

	// Search filter for task list
	$(document).on("keyup", ".todo-search", function () {
		todoItem = $(".todo-item");
		$('.todo-item').css('animation', 'none')
		var value = $(this).val().toLowerCase();
		if (value != "") {
			todoItem.filter(function () {
				$(this).toggle($(this).text().toLowerCase().includes(value));
			});
			var tbl_row = $(".todo-item:visible").length; //here tbl_test is table name

			//Check if table has row or not
			if (tbl_row == 0) {
				if (!noResults.hasClass('show')) {
					noResults.addClass('show');
				}
			} else {
				noResults.removeClass('show');
			}
		} else {
			// If filter box is empty
			todoItem.show();
			if (noResults.hasClass('show')) {
				noResults.removeClass('show');
			}
		}
	});
	// on Todo Item click show data in sidebar
	var globalThis = ""; // Global variable use in multiple function
	todoTaskListWrapper.on('click', '.todo-item', function (e) {
		var $this = $(this);
		globalThis = $this;

		todoNewTasksidebar.addClass('show');
		appContentOverlay.addClass('show');

		var todoTitle = $this.find(".todo-title").text();
		taskTitle.val(todoTitle);
		var compose_editor = $(".compose-editor .ql-editor");
		compose_editor[0].innerHTML = todoTitle;

		// if avatar is available
		if ($this.find(".avatar img").length) {
			avatarUserImage.removeClass("d-none");
			assignedAvatarContent.addClass("d-none");
		} else {
			avatarUserImage.addClass("d-none");
			assignedAvatarContent.removeClass("d-none");
		}
		//current task's image source assign to variable
		var avatarSrc = $this.find(".avatar img").attr('src');

		avatarUserImage.attr("src", avatarSrc);
		var assignName = $this.attr('data-name');

		$(".select2-users-name").val(assignName).trigger('change');

		// badge selected value check
		if ($(this).find('.badge').length) {
			//if badge available in current task
			var badgevalAll = [];
			var selected = $(this).find('.badge');

			selected.each(function () {
				var badgeVal = $(this).text();
				badgevalAll.push(badgeVal);
				selectAssignLable.val(badgevalAll).trigger("change");
			});
		} else {
			selectAssignLable.val(null).trigger("change");
		}
		// update button has remove class d-none & add class d-none in add todo button
		updateTodo.removeClass("d-none");
		addTodo.addClass("d-none");
		markCompleteBtn.removeClass("d-none");
		newTaskTitle.addClass("d-none");

	}).on('click', '.todo-item-favorite', function (e) {
		e.stopPropagation();
		$(this).toggleClass("warning");
		$(this).find("i").toggleClass("bxs-star");
	}).on('click', '.todo-item-delete', function (e) {
		e.stopPropagation();
		$(this).closest('.todo-item').remove();
	}).on('click', '.checkbox', function (e) {
		e.stopPropagation();
	});

	// Complete task strike through
	todoTaskListWrapper.on('click', ".todo-item .checkbox-input", function (e) {
		$(this).closest('.todo-item').toggleClass("completed");
	});

	// Complete button click action
	markCompleteBtn.on("click", function () {
		globalThis.addClass("completed");
		globalThis.find(".checkbox-input").prop("checked", true);
		selectAssignLable.attr("disabled", "true");
	});

	// Todo sidebar toggle
	$('.sidebar-toggle').on('click', function (e) {
		e.stopPropagation();
		sideBarLeft.toggleClass('show');
		appContentOverlay.addClass('show');
	});

	// sorting task list item
	$(".ascending").on("click", function () {
		todoItem = $(".todo-item");
		$('.todo-item').css('animation', 'none')
		todoItem.sort(sort_li).appendTo(todoTaskListWrapper);

		function sort_li(a, b) {
			return ($(b).find('.todo-title').text().toLowerCase()) < ($(a).find('.todo-title').text().toLowerCase()) ? 1 : -1;
		}
	});

	// descending sorting
	$(".descending").on("click", function () {
		todoItem = $(".todo-item");
		$('.todo-item').css('animation', 'none')
		todoItem.sort(sort_li).appendTo(todoTaskListWrapper);

		function sort_li(a, b) {
			return ($(b).find('.todo-title').text().toLowerCase()) > ($(a).find('.todo-title').text().toLowerCase()) ? 1 : -1;
		}
	});
});

$(window).on("resize", function () {
	// remove show classes from sidebar and overlay if size is > 992
	if ($(window).width() > 992) {
		if (appContentOverlay.hasClass('show')) {
			sideBarLeft.removeClass('show');
			appContentOverlay.removeClass('show');
			todoNewTasksidebar.removeClass("show");
		}
	}
});