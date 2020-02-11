$(function () {
    var hideString = "Hide";
    var showString = "Show";
    $(".controller").bind("click touchstart", function (e) {
        e.preventDefault();
        var panelId = $(this).attr("data-panel-id");
        var hideString = $("span", this).attr("data-hide-string");
        var showString = $("span", this).attr("data-show-string");
        var hideImage = $("img", this).attr("data-hide-image");
        var showImage = $("img", this).attr("data-show-image");
        if ($(this).hasClass("show")) {
            $("span", this).html(showString);
            $("img", this).attr("src", showImage);
            $(this).removeClass("show");
            $("#" + panelId).animate({ height: ["toggle", "swing"] }, 500);
        } else {
            $("span", this).html(hideString);
            $("img", this).attr("src", hideImage);
            $(this).addClass("show");
            $("#" + panelId).animate({ height: ["toggle", "swing"] }, 500);
        }
    });

    var gototop = $("#goToTop");
    // Hide the toTop button when the page loads.
    gototop.css("display", "none");
 
    // This function runs every time the user scrolls the page.
    $(window).scroll(function () {
        if ($(this).width() > 992) {
            // Check weather the user has scrolled down (if "scrollTop()"" is more than 0)
            if ($(window).scrollTop() > 0) {
                // If it's more than or equal to 0, show the toTop button.
                gototop.fadeIn("slow");
            }
            else {
                // If it's less than 0 (at the top), hide the toTop button.
                gototop.fadeOut("slow");
            }
        }
    });
 
    // When the user clicks the toTop button, we want the page to scroll to the top.
    gototop.bind("click touchstart", function(e){
        // Disable the default behaviour when a user clicks an empty anchor link.
        // (The page jumps to the top instead of // animating)
        e.preventDefault();
        // Animate the scrolling motion.
        $("html, body").animate({
            scrollTop:0
        }, "slow");
    });


    var gototopMobile = $("#goToTop-mobile");

    // This function runs every time the user scrolls the page.
    $(window).scroll(function () {
        // Check weather the user has scrolled down (if "scrollTop()"" is more than 0)
        if ($(window).scrollTop() > 0) {
            // If it's more than or equal to 0, show the toTop button.
            gototopMobile.fadeIn("slow");
        }
        else {
            // If it's less than 0 (at the top), hide the toTop button.
            gototopMobile.fadeOut("slow");
        }
    });

    // When the user clicks the toTop button, we want the page to scroll to the top.
    gototopMobile.bind("click touchstart", function (e) {
        // Disable the default behaviour when a user clicks an empty anchor link.
        // (The page jumps to the top instead of // animating)
        e.preventDefault();
        // Animate the scrolling motion.
        $("html, body").animate({
            scrollTop: 0
        }, "slow");
    });
});