$(document).ready(function () {
    $('[data-toggle="tooltip"]').tooltip();
});

$(".show-menu").click(function () {
    $("body").css("height", "100vh");
    $(".overlay").fadeIn();
    $(".mobile-menu").animate({ right: "0px" }, 500)
});
$(".overlay").click(function () {
    $(".mobile-menu").animate({ right: "-310px" }, 500)
    $(".overlay").fadeOut();
    $("body").removeAttr("style");
});
$(".mobile-menu .zmdi-close").click(function () {
    $(".mobile-menu").animate({ right: "-310px" }, 500)
    $(".overlay").fadeOut();
    $("body").removeAttr("style");
});

$(".main-menu li a .zmdi-plus[data-item]").click(function () {
    var data = $(this).attr("data-item");
    var selector = "ul[data-item=" + data + "]";
    $(selector).slideToggle();
    var isOpen = $(this).hasClass("zmdi-plus");
    if (isOpen) {
        $(this).removeClass("zmdi-plus");
        $(this).addClass("zmdi-minus");
        $(this).css("cursor", "pointer")
    } else {
        $(this).addClass("zmdi-plus")
        $(this).removeClass("zmdi-minus")
        $(this).removeAttr("style");
    }
});

$(".main-menu li a .zmdi-plus[data-sub]").click(function () {
    var data = $(this).attr("data-sub");
    var selector = "ul[data-sub=" + data + "]";
    $(selector).slideToggle();
    var isOpen = $(this).hasClass("zmdi-plus");
    if (isOpen) {
        $(this).removeClass("zmdi-plus");
        $(this).addClass("zmdi-minus");
        $(this).css("cursor", "pointer")
    } else {
        $(this).addClass("zmdi-plus")
        $(this).removeClass("zmdi-minus")
        $(this).removeAttr("style");
    }
});
$(".auth-link").click(function () {
    $(".sub").slideToggle();
})
$("[for]").click(function () {
    var value = $(this).attr("for");
    var id = "#" + value;
    $(id).prop("checked", true);
    $(this).addClass("active")

    var otherSelector = "[for!=" + value + "]";
    $(otherSelector).removeClass("active")
});
$("[checkfor]").click(function () {
    var isSelected = $(this).hasClass("selected");
    if (isSelected) {
        var value = $(this).attr("checkfor");
        var id = "#" + value;
        $(id).prop("checked", false);
        $(this).removeClass("selected")
    } else {
        var value = $(this).attr("checkfor");
        var id = "#" + value;
        $(id).prop("checked", true);
        $(this).addClass("selected")
    }
});