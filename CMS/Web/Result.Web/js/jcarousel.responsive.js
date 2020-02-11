(function ($) {
    $(function () {
        var scheduleCarousel = $('.schedule-list .jcarousel').jcarousel();
        $(".schedule-list .jcarousel").swiperight(function() {  
            $(this).jcarousel('scroll', '-=1');
        });  
        $(".schedule-list .jcarousel").swipeleft(function () {
            $(this).jcarousel('scroll', '+=1');
        });

        $(".schedule-list .jcarousel").jcarousel('scroll', $('.schedule-list .jcarousel ul li.highlight'));

        $('.schedule-list .jcarousel-control-prev')
	    .on('jcarouselcontrol:active', function () {
	        $(this).removeClass('inactive');
	    })
            .on('jcarouselcontrol:inactive', function () {
                $(this).addClass('inactive');
            })
	    .jcarouselControl({
	        target: '-=1'
	    });

        $('.schedule-list .jcarousel-control-next')
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