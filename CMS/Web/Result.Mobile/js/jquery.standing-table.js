$(function () {
    var controls = $(".standing-table-control");
    var wrapperContainer = $(".standing-table-container");
    var container = $(".standing-table-container table");
    var wrapperWidth = wrapperContainer.width();
    var containerWidth = $(container).width();
    var maxLeft = containerWidth > wrapperWidth ? containerWidth - wrapperWidth : 0;
    var left = 0;
    var scrolling = false;

    $(".standing-table-previous, .standing-table-next").bind("click", function (event) {
        event.preventDefault();
    });

    $(".standing-table-previous", controls).bind("touchstart mousedown", function () {
        scrolling = true;
        startScrolling(wrapperContainer, "-=100px");
    });

    $(".standing-table-next", controls).bind("touchstart mousedown", function () {
        scrolling = true;
        startScrolling(wrapperContainer, "+=100px");
    });

    $(".standing-table-previous, .standing-table-next", controls).bind("touchend mouseup", function () {
        scrolling = false;
    });

    $(window).resize(function () {
        wrapperWidth = wrapperContainer.width();
        maxLeft = containerWidth > wrapperWidth ? containerWidth - wrapperWidth : 0;
    });

    function startScrolling(obj, param) {
        obj.animate({ scrollLeft: param }, "fast", function () {
            if (scrolling) {
                startScrolling(obj, param);
            }
        });
    }
});