$(function () {
    var selectedMenu = $("header .menu-wrapper .dropdown.selected");
    $("ul.dropdown-menu [data-toggle=dropdown]").on("click", function (event) {
        // Avoid following the href location when clicking
        event.preventDefault();
        // Avoid having the menu to close when clicking
        event.stopPropagation();

        if ($(this).parent().hasClass("open")) {
            $("ul.dropdown-menu [data-toggle=dropdown]").parent().removeClass("open");
        } else {
            $("ul.dropdown-menu [data-toggle=dropdown]").parent().removeClass("open");
            $(this).parent().addClass("open");
        }
    });
    $(".main-navbar > .dropdown > a").on("click", function (e) {
        //e.stopPropagation()
        selectedMenu.removeClass("selected");
    });
    $(document).on("click", function (e) {
        selectedMenu.addClass("selected");
    });
});