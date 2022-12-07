$(".zmdi-close").click(function () {
    $(".top-banner").slideUp();
});

$(document).ready(function () {
    var search = new handlerSearch(["آموزش برنامه نویسی", "آموزش سی شارپ پیشرفته"]);
    $('[data-toggle="tooltip"]').tooltip();
    $(".header-content form input").keyup(function () {
        search.highlightResult();
    });
    $(".header-content form input").focus(function () {
        search.highlightResult();
    });
});
function setSearchResult(value){
    $(".header-content form input").val(value);
    $(".header-content .search-result").fadeOut(200);
}
$(".category-item").mouseenter(function () {
    var elements = $(".active");
    var groupSelector = $(".group-active");

    var groupIndex = groupSelector.attr("data-index");
    var elementIndex = elements.attr("data-index");

    var index = $(this).attr("data-index");
    var selector = `.main-group[data-index='${index}']`;


    $(selector).addClass("group-active");
    $(this).addClass("active");



    if (groupIndex != index) {
        $(groupSelector).removeClass("group-active");
    }
    if (elementIndex != index) {
        $(elements).removeClass("active");
    }
});
$(".auth-link").click(function () {
    $(".sub").slideToggle();
})

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

$(".main-menu li  .zmdi-plus[data-item]").click(function () {
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

$(".main-menu li  .zmdi-plus[data-sub]").click(function () {
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
class handlerSearch {
    constructor(data) {
        this.data = data;
    }

    

    highlightResult() {
        $(".search-result").html("");
        if ($(".header-content form input").val()) {
            $(".search-result").fadeIn(200);

            var value = $(".header-content form input").val();
            var res = this.data.filter(d => d.includes(value));
            if (res.length == 0) {
                $(".search-result").html("متاسفانه دوره ای با این مشخصات یافت نشد!");

            } else {
                for (var i = 0; i < res.length; i++) {
                    var ss = res[i].split(value);
                    var html = `<p>${ss[0]}<strong>${value}</strong>${ss[1]}</p>`;
                    $(".search-result").append(`<div onClick="setSearchResult('${res[i]}')" class="item"> ${html} </div>`);
                }
            }

        } else {
            $(".search-result").fadeOut(200);
        }
    }


}