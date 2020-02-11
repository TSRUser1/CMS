

(function ($) {
    $(function () {
        $('.ads-wrapper .jcarousel').jcarousel({
            wrap: "circular",
            animation: "slow",
            center: true
        }).jcarouselAutoscroll({
            interval: 3000,
            target: '+=1',
            autostart: true
        });

        $(".ads-wrapper .jcarousel").swiperight(function () {
            $(this).jcarousel('scroll', '-=1');
        });
        $(".ads-wrapper .jcarousel").swipeleft(function () {
            $(this).jcarousel('scroll', '+=1');
        });

        $('.ads-wrapper .jcarousel-control-prev')
	    .on('jcarouselcontrol:active', function () {
	        $(this).removeClass('inactive');
	    })
            .on('jcarouselcontrol:inactive', function () {
                $(this).addClass('inactive');
            })
	    .jcarouselControl({
	        target: '-=1'
	    });

        $('.ads-wrapper .jcarousel-control-next')
	    .on('jcarouselcontrol:active', function () {
	        $(this).removeClass('inactive');
	    })
            .on('jcarouselcontrol:inactive', function () {
                $(this).addClass('inactive');
            })
            .jcarouselControl({
                target: '+=1'
            });
    });
})(jQuery);