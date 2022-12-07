$(".showMenu a").click(function () {
    $(".profile-menu ul").slideToggle();
    var currentClass = $(".showMenu i").hasClass("fa-chevron-down");
    if (currentClass) {
        $(".showMenu i").removeClass("fa-chevron-down");
        $(".showMenu i").addClass("fa-chevron-up");
        $(this).html("بستن منو");
    } else {
        $(".showMenu i").addClass("fa-chevron-down");
        $(".showMenu i").removeClass("fa-chevron-up");
        $(this).html("نمایش منو");
    }
});
$(document).ready(function () {
    $('.ticket-Body').animate({
        scrollTop: $('.ticket-Body .chat:last-child').position().top
    }, 'slow');
});