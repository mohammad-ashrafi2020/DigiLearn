$(".password input").focus(function () {
    $(".password p").animate({
        bottom: "23px",
        right: "6%",
    }, 500)
    $(".password p").css("color", "rgb(14, 126, 160)")
    $(".password p").css("z-index", "5")
});
$(".password input").focusout(function () {
    var pas = $(".password input").val();
    if (pas.length == 0) {
        $(".password p").animate({
            "bottom": "0",
            "right": "6%"
        }, 500);
        $(".password p").css("color", "rgba(51, 51, 51, 0.692)")
        $(".password p").css("z-index", "-1")
    }else{
        $(".password p").animate({
            "bottom": "23px",
            "right": "1%"
        }, 500);
        $(".password p").css("color", "rgba(51, 51, 51, 0.692)")
    }
   
  

});

$(".emailOrUserName input").focus(function () {
    $(".emailOrUserName p").animate({
        "bottom": "23px",
        "right": "6%"
    }, 500);
    $(".emailOrUserName p").css("color", "rgb(14, 126, 160)")
    $(".emailOrUserName p").css("z-index", "5")
});
$(".emailOrUserName input").focusout(function () {
    var pas = $(".emailOrUserName input").val();
    if (pas.length == 0) {
        $(".emailOrUserName p").animate({
            "bottom": "0",
            "right": "6%"
        }, 500);
        $(".emailOrUserName p").css("z-index", "-1")
        $(".emailOrUserName p").css("color", "rgba(51, 51, 51, 0.692)")

    }else{
        $(".emailOrUserName p").animate({
            "bottom": "23px",
            "right": "1%"
        }, 500);
        $(".emailOrUserName p").css("color", "rgba(51, 51, 51, 0.692)")
    }
   
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