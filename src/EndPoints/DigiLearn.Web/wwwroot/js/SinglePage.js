if (document.getElementById("text_area")) {
    ClassicEditor.create(document.querySelector('#text_area'),
        {
            toolbar: {
                items: [
                    'bold',
                    'italic',
                    'fontSize',
                    'fontColor',
                    'link',
                    'bulletedList',
                    'numberedList',
                    'fontSize',
                    '|',
                    'indent',
                    'outdent',
                    '|',
                    'blockQuote',
                    'undo',
                    'redo',
                    'code'
                ]
            },
            language: 'fa',
            removePlugins:['Title'],
            licenseKey: '',
        }).then(editor => { window.editor = editor; });

}
$(".zmdi-close").click(function () {
    $(".top-banner").slideUp();
});
$("#episode").click(function () {
    $("#description").removeClass("selected");
    $(this).addClass("selected");
    $(".Description").css("display", "none");
    $(".episodes").fadeIn();
});

$("#description").click(function () {
    $(".Description").fadeIn();
    $(".episodes").css("display", "none");
    $("#episode").removeClass("selected");
    $(this).addClass("selected");
});
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

$('.owl-carousel').owlCarousel({
    rtl: true,
    loop: true,
    margin: 10,
    autoplay: true,
    autoplaySpeed: 1500,
    responsive: {
        0: {
            items: 1,
            dots: false
        },
        550: {
            items: 2
        },
        762: {
            items: 2
        },
        1000: {
            items: 4
        }
    }
});