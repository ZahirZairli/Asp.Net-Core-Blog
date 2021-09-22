//   all ------------------
function initZonar() {
    "use strict";
    firstLoad();
    function firstLoad() {
        var counter = 0;
        var count = 0;
        var i = setInterval(function () {
            $(".loader_count").html(count);
            counter++;
            count++;
            if (counter == 100) {
                clearInterval(i);
            }
        }, 13);
        TweenMax.to($(".loading-text-container"), 1.0, {
            force3D: true,
            y: "-150px",
            opacity: 0,
            ease: Expo.easeInOut,
            delay: 1.2,
            onComplete: function () {
                TweenMax.to($(".loader-anim"), 0.8, {
                    force3D: true,
                    bottom: "100%",
                    ease: Expo.easeInOut,

                });
                TweenMax.to($(".loader-anim2"), 0.8, {
                    force3D: true,
                    bottom: "100%",
                    delay: 0.2,
                    ease: Expo.easeInOut,
                    onComplete: function () {
                        $(".loader").fadeOut(1);
                    }
                });
            }
        });
        var chdpt = $(".content").data("pagetitle");
        $(".page-subtitle span").text(chdpt);
    }
    //   Background image ------------------
    var a = $(".bg");
    a.each(function (a) {
        if ($(this).attr("data-bg")) $(this).css("background-image", "url(" + $(this).data("bg") + ")");
    });
    //   Isotope------------------
    function n() {
        if ($(".gallery-items").length) {
            var $grid = $(".gallery-items").isotope({
                singleMode: true,
                columnWidth: ".grid-sizer, .grid-sizer-second, .grid-sizer-three",
                itemSelector: ".gallery-item, .gallery-item-second, .gallery-item-three",
                transformsEnabled: true,
                transitionDuration: "700ms",
            });
            $grid.imagesLoaded(function () {
                $grid.isotope("layout");
            });
            $(".gallery-filters").on("click", "a.gallery-filter", function (b) {
                b.preventDefault();
                var c = $(this).attr("data-filter");
                setTimeout(function () {
                    $grid.isotope({
                        filter: c
                    });
                }, 200);

                $(".gallery-filters a").removeClass("gallery-filter-active");
                $(this).addClass("gallery-filter-active");
                TweenLite.to(window, 0.2, {
                    scrollTo: {
                        y: $("#port-scroll"),
                        offsetY: 70,
                        autoKill: false,

                    }
                });
            });
            var gat = $(".gallery-filter-active").text();
        }
        $(".gallery-items").isotope("on", "layoutComplete", function (a, b) {
            var b = a.length;
            $(".num-album span").html(b);
        });
        var b = $(".gallery-item").length;
        $(".all-album , .num-album span").html(b);
    }
    n();
    //   Isotope------------------
    function inithorizontalPortfolio() {
        if ($("#portfolio_horizontal_container").length) {
            var d = $("#portfolio_horizontal_container");
            d.imagesLoaded(function (a, b, e) {
                var f = {
                    itemSelector: ".portfolio_item",
                    layoutMode: "packery",
                    packery: {
                        isHorizontal: true,
                        gutter: 0
                    },
                    resizable: true,
                    transformsEnabled: true,
                    transitionDuration: "700ms"
                };
                var g = {
                    itemSelector: ".portfolio_item",
                    layoutMode: "packery",
                    packery: {
                        isHorizontal: false,
                        gutter: 0
                    },
                    resizable: true,
                    transformsEnabled: true,
                    transitionDuration: "700ms"
                };
                if ($(window).width() < 764) {
                    d.isotope(g);
                    d.isotope("layout");
                    d.removeAttr('style');
                    $(".horizontal-grid-wrap").getNiceScroll().remove();
                } else {
                    d.isotope(f);
                    d.isotope("layout");
                    $(".horizontal-grid-wrap").niceScroll({
                        cursorwidth: "2px",
                        cursorborder: "none",
                        cursorborderradius: "0px",
                        touchbehavior: true,
                        autohidemode: false,
                        cursorcolor: "#F57500",
                        bouncescroll: false,
                        scrollspeed: 120,
                        mousescrollstep: 90,
                        grabcursorenabled: true,
                        horizrailenabled: true,
                        preservenativescrolling: true,
                        cursordragontouch: false,
                        railpadding: {
                            top: -70,
                            right: 0,
                            left: 0,
                            bottom: -4
                        }
                    });
                }
                $(".horizontal-grid-wrap").scroll(function () {
                    var winScroll = $("#portfolio_horizontal_container").width() - $(".horizontal-grid-wrap").width();
                    var width = $(".horizontal-grid-wrap").scrollLeft();
                    var scrolled = ((width / winScroll) * 100);
                    $(".js-progress-bar").css("stroke-dashoffset", 100 - (scrolled));
                });
                $(".gallery-filters").on("click", "a", function (a) {
                    a.preventDefault();
                    $(".horizontal-grid-wrap").animate({
                        scrollLeft: 0
                    }, 500);					
                    var b = $(this).attr("data-filter");
                    setTimeout(function () {
                        d.isotope({
                            filter: b
                        });
                    }, 600);
                    $(".gallery-filters a").removeClass("gallery-filter-active");
                    $(this).addClass("gallery-filter-active");
                    if ($(window).width() < 778) {
                        setTimeout(function () {
                            TweenLite.to($(window), 0.7, {
                                scrollTo: {
                                    y: $("#portfolio_horizontal_container"),
                                    offsetY: 70,
                                    autoKill: false,
                                }
                            });
                        }, 1200);
                    }
                });
                d.isotope("on", "layoutComplete", function (a, b) {
                    var b = a.length,
                        numalb = $(".num-album");
                    numalb.html(b);
                });
                var j = $(".portfolio_item").length;
                $(".all-album , .num-album").html(j);
            });
        }
    }
    inithorizontalPortfolio();
    //  swiper ------------------
    if ($(".home-half-slider").length > 0) {
        var j = new Swiper(".fs-gallery-wrap .swiper-container", {
            preloadImages: false,
            loop: true,
            grabCursor: true,
            centeredSlides: false,
            resistance: true,
            resistanceRatio: 0.6,
            speed: 2400,
            spaceBetween: 0,
            parallax: false,
            effect: "slide",
            mousewheel: true,
			init:false,
            pagination: {
                el: '.hero-slider-wrap_pagination',
                clickable: true,
            },
            navigation: {
                nextEl: '.hsc-next',
                prevEl: '.hsc-prev',
            },
            autoplay: {
                delay: 2500,
                disableOnInteraction: false
            },
        });

        j.on('slideChange', function () {
            var csli = j.realIndex + 1,
                curnum = $('.current'),
                curnumanm = $('.hs_counter .current');
            TweenMax.to(curnumanm, 0.2, {
                force3D: true,
                y: -10,
                opacity: 0,
                ease: Power2.easeOut,
                onComplete: function () {
                    TweenMax.to(curnumanm, 0.1, {
                        force3D: true,
                        y: 10
                    });
                    curnum.html('0' + csli);
                }
            });
            TweenMax.to(curnumanm, 0.2, {
                force3D: true,
                y: 0,
                delay: 0.3,
                opacity: 1,
                ease: Power2.easeOut
            });
        });
        j.on("slideChangeTransitionStart", function () {
            $(".hc_dec").addClass("start_anim");
            $(".slider-progress-bar").removeClass("act-slider");
        });
        j.on("slideChangeTransitionEnd", function () {
            $(".hc_dec").removeClass("start_anim");
            $(".slider-progress-bar").addClass("act-slider");
        });
        var imageSwiper = new Swiper(".hero-slider-img .swiper-container", {
            preloadImages: false,
            loop: true,
            resistance: true,
            parallax: true,
            effect: "slide",
        });
        j.controller.control = imageSwiper;
        imageSwiper.controller.control = j;
        var autobtn = $(".play-pause_slider");
        function autoEnd() {
            autobtn.removeClass("auto_actslider");
            j.autoplay.stop();
        }
        function autoStart() {
            autobtn.addClass("auto_actslider");
            j.autoplay.start();
        }
        autobtn.on("click", function () {
            if (autobtn.hasClass("auto_actslider")) autoEnd();
            else autoStart();
            return false;
        });
        setTimeout(function () {
            j.init();
            var totalSlides = j.slides.length - 2;
            $('.total').html('0' + totalSlides);
        }, 2000);
    }
    if ($(".testimonilas-carousel").length > 0) {
        var j2 = new Swiper(".testimonilas-carousel .swiper-container", {
            preloadImages: false,
            slidesPerView: 2,
            spaceBetween: 10,
            loop: true,
            grabCursor: true,
            mousewheel: false,
            centeredSlides: true,
            pagination: {
                el: '.tc-pagination',
                clickable: true,
            },
            navigation: {
                nextEl: '.tc-button-next',
                prevEl: '.tc-button-prev',
            },
            breakpoints: {

                800: {
                    slidesPerView: 1,
                },
            }
        });
    }
    //   sliders ------------------
    function setUpCarouselSlider() {
        $('.fw-carousel .swiper-wrapper').addClass('no-horizontal-slider');
        if ($(".fw-carousel").length > 0) {
            if ($(window).width() >= 764 && j2 == undefined) {
                var totalSlides2 = $(".fw-carousel .swiper-slide").length - 1;
                var mouseContr = $(".fw-carousel").data("mousecontrol");
                var j2 = new Swiper(".fw-carousel .swiper-container", {
                    preloadImages: false,
                    loop: false,
                    freeMode: false,
                    slidesPerView: 'auto',
                    spaceBetween: 10,
                    grabCursor: true,
                    mousewheel: mouseContr,
                    speed: 1400,
                    direction: "horizontal",
                    scrollbar: {
                        el: '.hs_init',
                        draggable: true,
                    },
                    effect: "slide",
                    pagination: {
                        el: '.fw-carousel-counter',
                        type: 'fraction',
                        renderFraction: function (currentClass) {
                            return '<span class="' + currentClass + '"></span>' + '' + '<span class="j2total">' + totalSlides2 + '</span>';
                        }
                    },
                    navigation: {
                        nextEl: '.fw-carousel-button-next',
                        prevEl: '.fw-carousel-button-prev',
                    },
                    on: {
                        resize: function () {
                            if ($(window).width() < 640) {
                                j2.update();
                            }
                        },
                    }
                });
                $(".fw-carousel.thumb-contr .swiper-slide img").each(function () {
                    var ccasdc = $(this).attr("src");
                    $("<div class='thumb-img'><img src='" + ccasdc + "'></div>").appendTo(".thumbnail-wrap");
                });
                $(".thumb-img").on('click', function () {
                    j2.slideTo($(this).index(), 500);
                    hideThumbnails();
                });
            }
            if ($(window).width() < 640 && j2 !== undefined) {
                j2.destroy();
                j2 = undefined;
                $('.fw-carousel .swiper-wrapper').removeAttr('style').addClass('no-horizontal-slider');
                $('.swiper-slide').removeAttr('style');
            }
        }
    }
    setUpCarouselSlider();
    if ($(".fs-slider").length > 0) {
        $(".fs-slider.thumb-contr .swiper-slide .bg").each(function () {
            var ccasdc3 = $(this).attr("data-bg");
            $("<div class='thumb-img'><img src='" + ccasdc3 + "'></div>").appendTo(".thumbnail-wrap");
        });
        $(".thumb-img").on('click', function () {
            j3.slideTo($(this).index() + 1, 1);
            hideThumbnails();
        });
        var totalSlides4 = $(".fs-slider .swiper-slide").length;
        $('.hsc_total').html('0' + totalSlides4);
        var mouseContr2 = $(".fs-slider").data("mousecontrol2");
        var j3 = new Swiper(".fs-slider .swiper-container", {
            preloadImages: true,
            loop: true,
            grabCursor: true,
            speed: 1400,
            spaceBetween: 0,
            effect: "slide",
				init:false,
            mousewheel: mouseContr2,
            pagination: {
                el: '.fs-slider-wrap_pagination',
                clickable: true,
            },
            navigation: {
                nextEl: '.fsc-next',
                prevEl: '.fsc-prev',
            },
            autoplay: {
                delay: 3500,
                disableOnInteraction: false
            },
        });
        $('.hsc_counter span').html('01');
        j3.on('slideChange', function () {
            var csli3 = j3.realIndex + 1,
                curnum3 = $('.hsc_counter span');
            curnum3.html('0' + csli3);
        });
        j3.on("slideChangeTransitionStart", function () {
            $(".slider-progress-bar").removeClass("act-slider");
        });
        j3.on("slideChangeTransitionEnd", function () {
            $(".slider-progress-bar").addClass("act-slider");
        });
        var autobtn2 = $(".play-pause_slider2");
        function autoEnd2() {
            autobtn2.removeClass("auto_actslider2");
            j3.autoplay.stop();
        }
        function autoStart2() {
            autobtn2.addClass("auto_actslider2");
            j3.autoplay.start();
        }
        autobtn2.on("click", function () {
            if (autobtn2.hasClass("auto_actslider2")) autoEnd2();
            else autoStart2();
            return false;
        });
        setTimeout(function () {
            j3.init();
        }, 2000);
    }
    if ($(".center-carousel").length > 0) {
        var j2 = new Swiper(".center-carousel .swiper-container", {
            preloadImages: true,
            slidesPerView: 'auto',
            spaceBetween: 10,
            loop: true,
            grabCursor: true,
            mousewheel: false,
            centeredSlides: true,
            autoHeight: false,
            pagination: {
                el: '.ss-slider-pagination',
                clickable: true,
            },
            navigation: {
                nextEl: '.ccsw-next',
                prevEl: '.ccsw-prev',
            },
        });
    }
    if ($(".single-slider").length > 0) {
        var j2 = new Swiper(".single-slider .swiper-container", {
            preloadImages: false,
            slidesPerView: 1,
            spaceBetween: 0,
            loop: true,
            autoHeight: true,
            grabCursor: true,
            mousewheel: false,
            pagination: {
                el: '.ss-slider-pagination',
                clickable: true,
            },
            navigation: {
                nextEl: '.ss-slider-cont-next',
                prevEl: '.ss-slider-cont-prev',
            },
        });
    }
    if ($(".slideshow-container_wrap").length > 0) {
        var ms1 = new Swiper(".slideshow-container_wrap .swiper-container", {
            preloadImages: false,
            loop: true,
            speed: 1400,
            spaceBetween: 0,
            effect: "fade",
			init:false,
            autoplay: {
                delay: 2500,
                disableOnInteraction: false
            },
            pagination: {
                el: '.fcwc-pagination',
                clickable: true,
            },
        });
        setTimeout(function () {
            ms1.init();
        }, 2000);
    }
    if ($(".hero-carousel ").length > 0) {
        var totalSlides3 = $(".hero-carousel .swiper-slide").length;
        var heroCarusel = new Swiper(".hero-carousel .swiper-container", {
            preloadImages: false,
            loop: true,
            centeredSlides: true,
            freeMode: false,
            slidesPerView: 3,
            spaceBetween: 6,
            grabCursor: true,
            mousewheel: true,
            parallax: true,
            speed: 1400,
            effect: "slide",
			init:false,
            autoplay: {
                delay: 2500,
                disableOnInteraction: false
            },
            pagination: {
                el: '.fs-slider-wrap_pagination',
                clickable: true,
            },
            navigation: {
                nextEl: '.ss-slider-cont-next',
                prevEl: '.ss-slider-cont-prev',
            },
            breakpoints: {
                768: {
                    slidesPerView: 2
                },
                640: {
                    slidesPerView: 1,
                    centeredSlides: false,
                },
            }
        });
        $('.hsc_counter span').html('01');
		$('.hsc_total').html('0' + totalSlides3);
        heroCarusel.on('slideChange', function () {
            var csli2 = heroCarusel.realIndex + 1,
                curnum2 = $('.hsc_counter span');
            curnum2.html('0' + csli2);
        });

        heroCarusel.on("slideChangeTransitionStart", function () {
            $(".slider-progress-bar").removeClass("act-slider");
        });
        heroCarusel.on("slideChangeTransitionEnd", function () {
            $(".slider-progress-bar").addClass("act-slider");
        });
        setTimeout(function () {
            heroCarusel.init();
        }, 2000);
    }
    if ($(".grid-carousel ").length > 0) {
        var totalSlides2 = $(".grid-carousel .swiper-slide").length;
        var gridCarusel = new Swiper(".grid-carousel .swiper-container", {
            preloadImages: true,
            loop: true,
            centeredSlides: false,
            freeMode: false,
            slidesPerView: 2,
            spaceBetween: 4,
            grabCursor: true,
            mousewheel: false,
            parallax: false,
            speed: 1400,
            navigation: {
                nextEl: '.gc-slider-cont-next',
                prevEl: '.gc-slider-cont-prev',
            },
            breakpoints: {
                768: {
                    slidesPerView: 2,
                },
                640: {
                    slidesPerView: 1,
                },
            }
        });
    }
    //   lightGallery------------------
    function lightGalleryInit() {
        $(".image-popup").lightGallery({
            selector: "this",
            cssEasing: "cubic-bezier(0.25, 0, 0.25, 1)",
            download: false,
            counter: false
        });
        var o = $(".lightgallery"),
            p = o.data("looped");
        o.lightGallery({
            selector: ".lightgallery a.popup-image",
            cssEasing: "cubic-bezier(0.25, 0, 0.25, 1)",
            download: false,
            loop: false,
            counter: false
        });
        $('#html5-videos').lightGallery({
            selector: 'this'
        });
        $(".dynamic-gal").on('click', function () {
            var dynamicgal = eval($(this).attr("data-dynamicPath"));
            $(this).lightGallery({
                dynamic: true,
                dynamicEl: dynamicgal,
                download: false,
                loop: false,
                counter: false
            });

        });
    }
    lightGalleryInit();
    //   appear------------------
    $(".stats").appear(function () {
        $(".num").countTo();
    });
    $(".skillbar-box").appear(function () {
        $(this).find("div.skillbar-bg").each(function () {
            $(this).find(".custom-skillbar").delay(600).animate({
                width: $(this).attr("data-percent")
            }, 1500);
        });
    });
    $(".piechart-holder").appear(function () {
        $(this).find(".chart").each(function () {
            var cbc = $(".piechart-holder").attr("data-skcolor");
            $(".chart").easyPieChart({
                barColor: cbc,
                trackColor: "#eee",
                scaleColor: "#eee",
                size: "70",
                lineWidth: "12",
                lineCap: "butt",
                animate: 3500,
                easing: "easeInBounce",
                onStep: function (a, b, c) {
                    $(this.el).find(".percent").text(Math.round(c));
                }
            });
        });
    });
    var ssl_total = $("section.scroll_sec").length;
    $(".sc_total").text("0" + ssl_total);
    // scroll nav ------------------
    $(".page-scroll-nav_wrap ").singlePageNav({
        filter: ":not(.external)",
        updateHash: false,
        offset: 70,
        threshold: 120,
        speed: 1200,
        currentClass: "act-sec"
    });
    //   scroll to------------------
    $(".custom-scroll-link").on("click", function () {
        var a = 80;
        if (location.pathname.replace(/^\//, "") === this.pathname.replace(/^\//, "") || location.hostname === this.hostname) {
            var b = $(this.hash);
            b = b.length ? b : $("[name=" + this.hash.slice(1) + "]");
            if (b.length) {
                TweenLite.to($("html,body"), 1, {
                    scrollTo: {
                        y: b.offset().top,
                        offsetY: 80,
                        autoKill: false
                    }
                });
                return false;

            }
        }
    });
    $(".to-top").on("click", function () {
        TweenLite.to(window, 2, {
            scrollTo: {
                y: 0,
                offsetY: 0,
                autoKill: false
            }
        });
    });
    // progressBar ------------------
    var progressBar = $(".js-progress-bar");
    var $window = $(window);
    $window.on("scroll", function (a) {
        var a = $(document).height();
        var b = $(window).height();
        var c = $(window).scrollTop();
        var d = c / (a - b) * 100;
        progressBar.css("stroke-dashoffset", 100 - (d));
    });
    $('.hero-decor-let').rotaterator({
        fadeSpeed: 500,
        pauseSpeed: 1200
    });
    var $window = $(window);
    // Styles ------------------
    function csselem() {
        $(".half-slider-item").css({
            height: $(".half-slider-wrap").outerHeight(true)
        });
        $(".half-slider-img-item").css({
            height: $(".half-slider-img").outerHeight(true)
        });
        $(".fs-slider-item").css({
            height: $(".fs-slider-wrap").outerHeight(true) - 6 + "px"
        });
        $(".ms-item_fs").css({
            height: $(".slideshow-container_wrap").outerHeight(true)
        });
        $(".horizontal-grid-wrap").css({
            height: $(".hor-content_padd").outerHeight(true) - 75 + "px"
        });
        $(".fw-carousel .swiper-container").css({
            height: $(".fw-carousel").outerHeight(true)
        });
    }
    csselem();
    $window.resize(function () {
        csselem();
        inithorizontalPortfolio();
    });
    //   accordion ------------------
    $(".accordion a.toggle").on("click", function (a) {
        a.preventDefault();
        $(".accordion a.toggle").removeClass("act-accordion");
        $(this).addClass("act-accordion");
        if ($(this).next('div.accordion-inner').is(':visible')) {
            $(this).next('div.accordion-inner').slideUp();
        } else {
            $(".accordion a.toggle").next('div.accordion-inner').slideUp();
            $(this).next('div.accordion-inner').slideToggle();
        }
    });
    var coninw = $(".contact-info-wrap"),
        coninbtn = $(".contact-info-btn");
    function showConInfo() {
        coninw.addClass("vis-coninfwrap");
        coninbtn.removeClass("isconin-btn_vis");
    }
    function hideConInfo() {
        coninw.removeClass("vis-coninfwrap");
        coninbtn.addClass("isconin-btn_vis");
    }
    coninbtn.on("click", function () {
        if ($(this).hasClass("isconin-btn_vis")) showConInfo();
        else hideConInfo();
    });
    $(".close_ciw").on("click", function (e) {
        e.preventDefault();
        hideConInfo();
    });
    //   nicescroll ------------------
    $(".proces-details-content-wrap").niceScroll({
        cursorwidth: "2px",
        cursorborder: "none",
        cursorborderradius: "0px",
        cursorcolor: "#F57500",
        zindex: "10",
        background: "rgba(255,255,255,0.1)",
        autohidemode: false,
    });
    $(".hidden-contact_form-wrap_inner").niceScroll({
        cursorwidth: "0",
        cursorborder: "none",
        cursorborderradius: "0px",
    });
    $(".initscroll").niceScroll({
        cursorwidth: "2px",
        cursorborder: "none",
        cursorborderradius: "0px",
        cursorcolor: "#F57500",
        zindex: "2",
        background: "#eee",
        autohidemode: false,
    });
    $(".show-phdc").on("click", function () {
        var pdch = $(this).parent(".process-details").find(".proces-details-content");
        TweenMax.to(pdch, 1.2, {
            force3D: true,
            bottom: 0,
            ease: Expo.easeInOut
        });
    });
    $(".close-hidden_pdc").on("click", function () {
        var pdch = $(this).parents(".process-details").find(".proces-details-content");
        TweenMax.to(pdch, 0.6, {
            force3D: true,

            bottom: "-100%",
            ease: Expo.easeInOut
        });
    });
    var thumbcont = $(".thumbnail-container"),
        thumbItrm = $(".thumb-img"),
        stbtn = $(".show_thumbnails");
    function showThumbnails() {
        TweenMax.to(thumbcont, 1.0, {
            force3D: true,
            top: 0,
            ease: Expo.easeInOut,
            onComplete: function () {
                thumbItrm.addClass("visthumbnails");
                setTimeout(function () {
                    thumbcont.addClass("visthumbnails");
                }, 200);

            }
        });
        stbtn.removeClass("unvisthum");
    }
    function hideThumbnails() {
        thumbcont.removeClass("visthumbnails");
        thumbItrm.removeClass("visthumbnails");
        TweenMax.to(thumbcont, 1.0, {
            force3D: true,
            delay: 0.2,
            top: "100%",
            ease: Expo.easeInOut,
            onComplete: function () {
                TweenMax.to(thumbcont, 0.1, {
                    force3D: true,
                    left: 0,
                    top: "100%",
                    ease: Expo.easeInOut
                });
            }
        });
        stbtn.addClass("unvisthum");
    }
    stbtn.on("click", function () {
        if ($(this).hasClass("unvisthum")) showThumbnails();
        else hideThumbnails();
    });
    function showDetails() {
        $(".det-overlay").fadeIn(400);
        TweenMax.to($(".hid-det-anim"), 0.8, {
            force3D: true,
            left: "0",
            ease: Expo.easeInOut,
            onComplete: function () {
                TweenMax.to($(".fix-pr-det-dec2"), 0.5, {
                    force3D: true,
                    width: 0,
                    ease: Expo.easeInOut
                });
                TweenMax.to($(".fix-pr-det-dec"), 0.8, {
                    force3D: true,
                    delay: 0.2,
                    left: "100%",
                    ease: Expo.easeInOut
                });

            }

        });
        $(".shibtn").removeClass("unvisthum2");
        hideThumbnails();
        $(".fw-carousel-wrap").addClass("viscale");
    }
    function hideDetails() {
        $(".det-overlay").fadeOut(400);
        TweenMax.to($(".hid-det-anim"), 0.8, {
            force3D: true,
            left: "-900px",
            ease: Expo.easeInOut,
            onComplete: function () {
                TweenMax.to($(".fix-pr-det-dec2"), 0.1, {
                    force3D: true,
                    width: "150px",
                    ease: Expo.easeInOut
                });
                TweenMax.to($(".fix-pr-det-dec"), 0.1, {
                    force3D: true,

                    left: "0",
                    ease: Expo.easeInOut
                });
            }
        });
        $(".shibtn").addClass("unvisthum2");
        $(".fw-carousel-wrap").removeClass("viscale");
    }
    $(".shibtn").on("click", function () {
        if ($(this).hasClass("unvisthum2")) showDetails();
        else hideDetails();
    });
    $(".act-closedet").on("click", function () {
        hideDetails();
    });
    function hoverdirInit() {
        $(".horizontal-grid-wrap .portfolio_item  , .gallery-items .gallery-item").each(function () {
            $(this).hoverdir();
        });
    }
    hoverdirInit();
    //   cursor ------------------
    $(".pr-det-container , .column-wrap").on({
        mouseenter: function () {
            $(".element-item").addClass("white_blur");
        },
        mouseleave: function () {
            $(".element-item").removeClass("white_blur");
        }
    });
    $(".column-wrap.dark-bg").on({
        mouseenter: function () {
            $(".element-item").removeClass("white_blur");
        },
        mouseleave: function () {
            $(".element-item").removeClass("white_blur");
        }
    });
    $("a , .btn ,   textarea,   input  , .leaflet-control-zoom , .aside-show_cf , .close-contact_form , .closedet_style ").on({
        mouseenter: function () {
            $(".element-item").addClass("elem_hover");
        },
        mouseleave: function () {
            $(".element-item").removeClass("elem_hover");
        }
    });
    $("  .swiper-slide ,  #portfolio_horizontal_container").on({
        mouseenter: function () {
            $(".element-item").addClass("slider_hover");
        },
        mouseleave: function () {
            $(".element-item").removeClass("slider_hover");
        }
    });
    $(".swiper-slide a , .next-project-swiper-link , #portfolio_horizontal_container a").on({
        mouseenter: function () {
            $(".element-item").removeClass("slider_hover");
        },
        mouseleave: function () {
            $(".element-item").addClass("slider_hover");
        }
    });

    $(".next-project-swiper-link").on({
        mouseenter: function () {
            $(".element-item").addClass("slider_linknext");
        },
        mouseleave: function () {
            $(".element-item").removeClass("slider_linknext");
        }
    });
    $(".nav-overlay , .det-overlay").on({
        mouseenter: function () {
            $(".element-item").addClass("close-icon");
        },
        mouseleave: function () {
            $(".element-item").removeClass("close-icon");
        }
    });
    //   Contact form------------------
    $("#contactform").submit(function () {
        var a = $(this).attr("action");
        $("#message").slideUp(750, function () {
            $("#message").hide();
            $("#submit").attr("disabled", "disabled");
            $.post(a, {
                name: $("#name").val(),
                email: $("#email").val(),
                phone: $("#phone").val(),
                subject: $('#subject').val(),
                comments: $("#comments").val(),
                verify: $('#verify').val()

            }, function (a) {
                document.getElementById("message").innerHTML = a;
                $("#message").slideDown("slow");
                $("#submit").removeAttr("disabled");
                if (null != a.match("success")) $("#contactform").slideDown("slow");
            });
        });
        return false;
    });
    $("#contactform input, #contactform textarea").keyup(function () {
        $("#message").slideUp(1500);
    });
	//  Map------------------
	if ($("#map-single").length > 0) {
		var latlog = $('#map-single').data('latlog'),
			popupTextit = $('#map-single').data('popuptext'),
			map = L.map('map-single').setView(latlog, 15);
		L.tileLayer('https://{s}.basemaps.cartocdn.com/dark_all/{z}/{x}/{y}{r}.png').addTo(map);
		if ($(window).width() > 1024) {
			var offset = map.getSize().x * 0.15;
			map.panBy(new L.Point(-offset, 0), {
				animate: false
			});
		} else {
			var offset = map.getSize().x * 0;
			map.panBy(new L.Point(-offset, 0), {
				animate: false
			});
		}
		var greenIcon = L.icon({
            iconUrl: 'https://cdn.turkishairlines.com/m/6e0a2c5853c8b1e7/original/Travel-Guide-of-Baku-via-Turkish-Airlines.jpg',
			iconSize: [40, 40],
			popupAnchor: [0, -26]
		});
		L.marker(latlog, {
			icon: greenIcon
		}).addTo(map).bindPopup(popupTextit);
	}
    $(".show_contact-form").on("click", function (e) {
        e.preventDefault();
        $(".content-inner").addClass("vis-con-form");
    });
    $(".close-contact_form").on("click", function () {
        $(".content-inner").removeClass("vis-con-form");
        $("#message").slideUp(500);
        $(".custom-form").find("input[type=text], textarea").val("");
    });
    if ($(".video-holder-wrap").length > 0) {
    function videoint() {
        //   Video------------------
        var v = $(".background-youtube-wrapper").data("vid");
        var f = $(".background-youtube-wrapper").data("mv");
        $(".background-youtube-wrapper").YTPlayer({
            fitToBackground: true,
            videoId: v,
            pauseOnScroll: true,
            mute: f,
            callback: function () {
                var a = $(".background-youtube-wrapper").data("ytPlayer").player;
            }
        });
        var w = $(".background-vimeo").data("vim"),
            bvc = $(".background-vimeo"),
            bvmc = $(".media-container"),
            bvfc = $(".background-vimeo iframe "),
            vch = $(".video-container");
        bvc.append('<iframe src="//player.vimeo.com/video/' + w + '?background=1"  frameborder="0" webkitallowfullscreen mozallowfullscreen allowfullscreen ></iframe>');
        $(".video-holder").height(bvmc.height());
        if ($(window).width() > 1024) {
            if ($(".video-holder").length > 0)
                if (bvmc.height() / 9 * 16 > bvmc.width()) {
                    bvfc.height(bvmc.height()).width(bvmc.height() / 9 * 16);
                    bvfc.css({
                        "margin-left": -1 * $("iframe").width() / 2 + "px",
                        top: "-75px",
                        "margin-top": "0px"
                    });
                } else {
                    bvfc.width($(window).width()).height($(window).width() / 16 * 9);
                    bvfc.css({
                        "margin-left": -1 * $("iframe").width() / 2 + "px",
                        "margin-top": -1 * $("iframe").height() / 2 + "px",
                        top: "50%"
                    });
                }
        } else if ($(window).width() < 760) {
            $(".video-holder").height(bvmc.height());
            bvfc.height(bvmc.height());
        } else {
            $(".video-holder").height(bvmc.height());
            bvfc.height(bvmc.height());
        }
        vch.css("width", $(window).width() + "px");
        vch.css("height", Number(720 / 1280 * $(window).width()) + "px");
        if (vch.height() < $(window).height()) {
            vch.css("height", $(window).height() + "px");
            vch.css("width", Number(1280 / 720 * $(window).height()) + "px");
        }
    }
    videoint();
    }
    //   Blog filter ------------------
    $(".blog-btn").on("click", function () {
        $(this).parent(".blog-btn-filter").find("ul").slideToggle(500);
        return false;
    });
    //   mobile filter ------------------
    $(".act-filter").on("click", function () {
        $(".init_hidden_filter").slideToggle(300);
        return false;
    });
    $(".page-scroll-nav_wrap ul li a  , .gallery-filters a").on("click", function () {
        if ($(window).width() < 565) {
            $(".init_hidden_filter").delay(600).slideUp(300);
        }
    });
    //  menu------------------
    $("#menu").menu();
    $(".sliding-menu li a.nav").parent("li").addClass("submen-dec");
    var nbw = $(".nav-button"),
        nh = $(".nav-holder"),
        nhw = $(".nav-holder-wrap"),
        nho = $(".nav-overlay"),
        nhl = $(".nav-holder-wrap_line"),
        nnvw = $("nav.nav-inner"),
        nfw = $(".nav-footer"),
        nhwd = $(".nav-holder-wrap_dec");
    function showMenu() {
        nh.addClass("nh_vis");
        nho.fadeIn(500);
        TweenMax.to(nhwd, 0.6, {
            force3D: true,
            left: 0,
            ease: Expo.easeInOut
        });
        TweenMax.to(nfw, 0.6, {
            force3D: true,
            delay: 0.3,

            bottom: 0,
            ease: Expo.easeInOut
        });
        TweenMax.to(nhl, 1.2, {
            force3D: true,
            delay: 0.3,
            top: 0,
            ease: Expo.easeInOut
        });
        TweenMax.to(nnvw, 0.8, {
            force3D: true,
            opacity: "1",
            x: 0,
            delay: 0.6,
            ease: Expo.easeInOut
        });
        nhw.removeClass("but-hol");
        nbw.addClass("cmenu");
    }
    function hideMenu() {
        TweenMax.to(nhl, 0.3, {
            force3D: true,
            top: "100%",
            ease: Expo.easeInOut,
            onComplete: function () {
                TweenMax.to(nfw, 0.2, {
                    force3D: true,
                    bottom: "-70px",
                    ease: Expo.easeInOut
                });
                TweenMax.to(nnvw, 0.4, {
                    force3D: true,
                    opacity: "0",
                    x: "50px",
                    ease: Expo.easeInOut,
                    onComplete: function () {
                        TweenMax.to(nhwd, 0.4, {
                            force3D: true,
                            left: "100%",
                            ease: Expo.easeInOut
                        });
                        TweenMax.to($(".nhw-col"), 0.4, {
                            force3D: true,
                            opacity: "0",
                            transform: "  rotateX(80deg)",
                            ease: Expo.easeInOut
                        });
                        nh.removeClass("nh_vis");
                        nho.fadeOut(500);
                    }
                });
            }
        });
        nhw.addClass("but-hol");
        nbw.removeClass("cmenu");
    }
    nbw.on("click", function () {
        if (nhw.hasClass("but-hol")) showMenu();
        else hideMenu();
    });
    nho.on("click", function () {
        hideMenu();
    });
    // Share   ------------------
    $(".share-container").share({
        networks: ['facebook', 'pinterest', 'twitter', 'linkedin', 'tumblr']
    });
    var shrcn = $(".share-container"),
        swra = $(".share-wrapper"),
        clsh = $(".close-share-btn"),
        shic = $(".share-icon"),
        ssbtn = $(".showshare");
    function showShare() {
        ssbtn.addClass("uncl-share");
        shrcn.removeClass("isShare");
        TweenMax.to(swra, 0.6, {
            force3D: false,
            width: "225px",
            ease: Expo.easeInOut,
            onComplete: function () {
                TweenMax.to(clsh, 0.4, {
                    force3D: true,
                    right: "0",

                });
                shic.each(function (a) {
                    var boi = $(this);
                    setTimeout(function () {
                        TweenMax.to(boi, 1.0, {
                            force3D: false,
                            opacity: "1"
                        });
                    }, 130 * a);
                });
            }
        });
    }
    function hideShare() {
        ssbtn.removeClass("uncl-share");
        shrcn.addClass("isShare");
        TweenMax.to($(".share-icon"), 1.0, {
            force3D: false,
            opacity: "0"
        });
        TweenMax.to(clsh, 0.4, {
            force3D: true,
            right: "-75px",
            onComplete: function () {
                TweenMax.to(swra, 0.6, {
                    force3D: false,
                    delay: 0.2,
                    width: "0",
                    ease: Expo.easeInOut
                });
            }
        });
    }
    clsh.on("click", function () {
        hideShare();
    });
    ssbtn.on("click", function () {
        if ($(".share-container").hasClass("isShare")) showShare();
        else hideShare();
    });
}
//   load animation------------------
$("<div class='page-load'><span class='pl-spinner'></span></div>").appendTo("#main");
$.fn.duplicate = function (a, b) {
    var c = [];
    for (var d = 0; d < a; d++) $.merge(c, this.clone(b).get());
    return this.pushStack(c);
};
$("<div class='pl-row'><span class='pl-row-anim'></span><span class='pl-row-anim2'></span></div>").duplicate(4).appendTo(".page-load");
function contentAnimShow() {
    $(".lg-backdrop , .lg-outer").remove();
    $(".nav-button").removeClass("cmenu");
    $(".showshare").removeClass("uncl-share");
    $(".page-load").fadeIn(1);
    $(".pl-row-anim2").each(function (index, element) {
        var tl = new TimelineLite();
        tl.to(element, 0.6, {
            force3D: true,

            right: "0",
            ease: Expo.easeInOut
        }, index * 0.1)
    });
    $(".pl-row-anim").each(function (index, element) {
        var tl = new TimelineLite();
        tl.to(element, 0.8, {
            force3D: true,

            right: "0",
            ease: Expo.easeInOut
        }, index * 0.1)
    });
    TweenMax.to($(".page-subtitle span"), 0.9, {
        force3D: true,
        y: -50,
        opacity: 0,
        delay: 0.7,
        ease: Power2.easeOut,
        onComplete: function () {
            TweenMax.to($(".page-subtitle span"), 0.1, {
                force3D: true,
                y: 50
            });
        }
    });
    setTimeout(function () {
        $("html, body").animate({
            scrollTop: 0
        }, {
            queue: true,
            duration: 10,
        });
    }, 1000);
}
function contentAnimHide() {
    var chdpt = $(".content").data("pagetitle");
    $(".page-subtitle span").text(chdpt);
    TweenMax.to($(".page-subtitle span"), 0.9, {
        force3D: true,
        y: 0,
        opacity: 1,
        delay: 0.8,
        ease: Power2.easeOut
    });
    $(".page-load").addClass("act_pl");
    $(".pl-spinner").addClass("act-loader");
    setTimeout(function () {
        $(".pl-spinner").removeClass("act-loader");
        $(".page-load").removeClass("act_pl");
        $(".pl-row-anim").each(function (index, element) {
            var tl = new TimelineLite();
            tl.to(element, 0.6, {
                force3D: true,
                left: "100%",
                ease: Expo.easeInOut
            }, index * 0.1)
        });
        $(".pl-row-anim2").each(function (index, element) {
            var tl = new TimelineLite();
            tl.to(element, 0.8, {
                force3D: true,
                left: "100%",
                ease: Expo.easeInOut
            }, index * 0.1)
        });
        setTimeout(function () {
            $(".page-load").fadeOut(1);
            TweenMax.to($(".pl-row-anim , .pl-row-anim2"), 0.0, {
                force3D: true,
                left: "0",
                right: "100%"
            });

        }, 1200);
    }, 1500);
}
//   Video ------------------
function initvideo() {
    var a = {
        Android: function () {
            return navigator.userAgent.match(/Android/i);
        },
        BlackBerry: function () {
            return navigator.userAgent.match(/BlackBerry/i);
        },
        iOS: function () {
            return navigator.userAgent.match(/iPhone|iPad|iPod/i);
        },
        Opera: function () {
            return navigator.userAgent.match(/Opera Mini/i);
        },
        Windows: function () {
            return navigator.userAgent.match(/IEMobile/i);
        },
        any: function () {
            return a.Android() || a.BlackBerry() || a.iOS() || a.Opera() || a.Windows();
        }
    };
    trueMobile = a.any();
    if (trueMobile) $("  .background-vimeo , .background-youtube-wrapper ").remove();
}
if ($(".element-item").length > 0) {
    var mouse = {
        x: 0,
        y: 0
    };
    var pos = {
        x: 0,
        y: 0
    };
    var ratio = 0.15;
    var active = false;
    var ball = document.querySelector('.element-item');
    TweenLite.set(ball, {
        xPercent: -50,
        yPercent: -50
    });
    document.addEventListener("mousemove", mouseMove);
    function mouseMove(e) {
        var scrollTop = window.pageYOffset || document.documentElement.scrollTop;
        mouse.x = e.pageX;
        mouse.y = e.pageY - scrollTop;
    }
    TweenMax.ticker.addEventListener("tick", updatePosition);
    function updatePosition() {
        if (!active) {
            pos.x += (mouse.x - pos.x) * ratio;
            pos.y += (mouse.y - pos.y) * ratio;
            TweenMax.set(ball, {
                x: pos.x,
                y: pos.y
            });
        }
    }
}
//   Init Ajax------------------
$(function () {
    $.coretemp({
        reloadbox: "#wrapper",
        outDuration: 700,
        inDuration: 200
    });
    readyFunctions();
    $(document).on({
        ksctbCallback: function () {
            readyFunctions();
        }
    });
});
//   Init All Functions------------------
function readyFunctions() {
    initvideo();
    initZonar();
}