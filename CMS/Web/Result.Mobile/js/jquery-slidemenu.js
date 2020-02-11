$(function () {
    $("#slide-menu-toggle").bind("click", function () {
        if ($("body").hasClass("sidemenu-expand")) {
            $(".mobile-shelf").animate({ left: "-240px" }, 400);
            $(".content-wrapper").animate({ left: "0" }, 400, function () { $("body").removeClass("sidemenu-expand"); });
            $(".top-wrapper .social-media").stop().fadeIn();
        } else {
            $(".mobile-shelf").animate({ left: "0" }, 400);
            $(".content-wrapper").animate({ left: "240px" }, 400);
            $(".top-wrapper .social-media").stop().fadeOut();
            $("body").addClass("sidemenu-expand");
        }
    });
    $('html').bind("click", function () {
        $(".mobile-shelf").animate({ left: "-240px" }, 400);
        $(".content-wrapper").animate({ left: "0" }, 400, function () { $("body").removeClass("sidemenu-expand"); });
        $(".top-wrapper .social-media").stop().fadeIn();
    });

    $(".mobile-shelf, .navbar-toggle").bind("click touchstart", function (event) {
        event.stopPropagation();
    });
});