/*! Sidr - v1.2.1 - 2013-11-06
 * https://github.com/artberri/sidr
 * Copyright (c) 2013 Alberto Varela; Licensed MIT */
(function(e){var t=!1,i=!1,n={isUrl:function(e){var t=RegExp("^(https?:\\/\\/)?((([a-z\\d]([a-z\\d-]*[a-z\\d])*)\\.)+[a-z]{2,}|((\\d{1,3}\\.){3}\\d{1,3}))(\\:\\d+)?(\\/[-a-z\\d%_.~+]*)*(\\?[;&a-z\\d%_.~+=-]*)?(\\#[-a-z\\d_]*)?$","i");return t.test(e)?!0:!1},loadContent:function(e,t){e.html(t)},addPrefix:function(e){var t=e.attr("id"),i=e.attr("class");"string"==typeof t&&""!==t&&e.attr("id",t.replace(/([A-Za-z0-9_.\-]+)/g,"sidr-id-$1")),"string"==typeof i&&""!==i&&"sidr-inner"!==i&&e.attr("class",i.replace(/([A-Za-z0-9_.\-]+)/g,"sidr-class-$1")),e.removeAttr("style")},execute:function(n,s,a){"function"==typeof s?(a=s,s="sidr"):s||(s="sidr");var r,d,l,c=e("#"+s),u=e(c.data("body")),f=e("html"),p=c.outerWidth(!0),g=c.data("speed"),h=c.data("side"),m=c.data("displace"),v=c.data("onOpen"),y=c.data("onClose"),x="sidr"===s?"sidr-open":"sidr-open "+s+"-open";if("open"===n||"toggle"===n&&!c.is(":visible")){if(c.is(":visible")||t)return;if(i!==!1)return o.close(i,function(){o.open(s)}),void 0;t=!0,"left"===h?(r={left:p+"px"},d={left:"0px"}):(r={right:p+"px"},d={right:"0px"}),u.is("body")&&(l=f.scrollTop(),f.css("overflow-x","hidden").scrollTop(l)),m?u.addClass("sidr-animating").css({width:u.width(),position:"absolute"}).animate(r,g,function(){e(this).addClass(x)}):setTimeout(function(){e(this).addClass(x)},g),c.css("display","block").animate(d,g,function(){t=!1,i=s,"function"==typeof a&&a(s),u.removeClass("sidr-animating")}),v()}else{if(!c.is(":visible")||t)return;t=!0,"left"===h?(r={left:0},d={left:"-"+p+"px"}):(r={right:0},d={right:"-"+p+"px"}),u.is("body")&&(l=f.scrollTop(),f.removeAttr("style").scrollTop(l)),u.addClass("sidr-animating").animate(r,g).removeClass(x),c.animate(d,g,function(){c.removeAttr("style").hide(),u.removeAttr("style"),e("html").removeAttr("style"),t=!1,i=!1,"function"==typeof a&&a(s),u.removeClass("sidr-animating")}),y()}}},o={open:function(e,t){n.execute("open",e,t)},close:function(e,t){n.execute("close",e,t)},toggle:function(e,t){n.execute("toggle",e,t)},toogle:function(e,t){n.execute("toggle",e,t)}};e.sidr=function(t){return o[t]?o[t].apply(this,Array.prototype.slice.call(arguments,1)):"function"!=typeof t&&"string"!=typeof t&&t?(e.error("Method "+t+" does not exist on jQuery.sidr"),void 0):o.toggle.apply(this,arguments)},e.fn.sidr=function(t){var i=e.extend({name:"sidr",speed:200,side:"left",source:null,renaming:!0,body:"body",displace:!0,onOpen:function(){},onClose:function(){}},t),s=i.name,a=e("#"+s);if(0===a.length&&(a=e("<div />").attr("id",s).appendTo(e("body"))),a.addClass("sidr").addClass(i.side).data({speed:i.speed,side:i.side,body:i.body,displace:i.displace,onOpen:i.onOpen,onClose:i.onClose}),"function"==typeof i.source){var r=i.source(s);n.loadContent(a,r)}else if("string"==typeof i.source&&n.isUrl(i.source))e.get(i.source,function(e){n.loadContent(a,e)});else if("string"==typeof i.source){var d="",l=i.source.split(",");if(e.each(l,function(t,i){d+='<div class="sidr-inner">'+e(i).html()+"</div>"}),i.renaming){var c=e("<div />").html(d);c.find("*").each(function(t,i){var o=e(i);n.addPrefix(o)}),d=c.html()}n.loadContent(a,d)}else null!==i.source&&e.error("Invalid Sidr Source");return this.each(function(){var t=e(this),i=t.data("sidr");i||(t.data("sidr",s),"ontouchstart"in document.documentElement?(t.bind("touchstart",function(e){e.originalEvent.touches[0],this.touched=e.timeStamp}),t.bind("touchend",function(e){var t=Math.abs(e.timeStamp-this.touched);200>t&&(e.preventDefault(),o.toggle(s))})):t.click(function(e){e.preventDefault(),o.toggle(s)}))})}})(jQuery);;
/********************
 * fucntions.js
 * version 1.0
 * brantwebdesign
*********************/

(function ($, Drupal, window, document, undefined) {
  Drupal.behaviors.unity2 = {}
  Drupal.behaviors.unity2.attach = function(context, newsettings){
//    $('#responsive-menu-button').sidr({
//      name: 'sidr-main',
//      source: '#navigation',
//      onOpen: function() {
//        console.log("here");
//        
//      }
//    });

		var id = $(context).attr('id');
    if ($('.webform-client-form', context).length > 0 && context != document){
      if ($('.webform-client-form', context).hasClass('ajax-fail')){
   			window.VWO = window.VWO || [];
				window.VWO.push(['nls.formAnalysis.markSuccess', $('.webform-client-form', context), 0]);
				if(typeof window.VWO.nls !== 'undefined')
   				delete VWO.nls.formAnalysis.forms[VWO.nls.formAnalysis.getFormName($('.webform-client-form', context))];    
  		}       
		}
    
    $('#responsive-menu-button').sidr({
          name: 'sidr-main',
          displace: false,
          source: '#navigation',
          onOpen: function() {
            $("#mobile-header").addClass("sidr_menu");
            $('#CountrySelectorDropdown').hide();
            if ($('#edit-center-autocomplete-google2').hasClass("active")){ 
              $('#edit-center-autocomplete-google2').removeClass("active");
              $('.head_right_sec').removeClass('active');
              $('.logo').show();
              $('#current_country').show(); //since it breakes on mobile screen
              $('.search-btn').show();
            }            
          },
          onClose: function() {
            $("#mobile-header").removeClass("sidr_menu");
          }
        });
    
    
  
  
  // course table fade
  // check table display setting first, if display:block we don't do anything (mobile)
  $('#course-table tr').mouseenter(function(){
    if (($('#course-table').css('display')) === 'table') {
      $(this).find('.detail-hide').fadeIn('400');
      //$(this).find('.detail-hide .course-detail').animate({'line-height': '21px'},150);
      //$(this).find('.detail-hide .course-detail-small').animate({'line-height': '16px'},150);
      //$(this).find('.detail-hide .course-detail-small > span').animate({'line-height': '16px'},150);
    }
  });
  $('#course-table tr').mouseleave(function(){
    if (($('#course-table').css('display')) === 'table') {
      $(this).find('.detail-hide').hide();
      //$(this).find('.detail-hide span').animate({'line-height': 0},100);
    }
  });
  
  
  // Course Slider
  $('.slider_course').each(function() {
    if ($(this).children().length >1)
    $(this).owlCarousel({
      loop: true,
      autoplay: true,
      dots: true,
      dotsEach: true,
      responsive: {
        0: {
          items: 1,
          nav: false
        },
        768: {
          items: 1,
          nav: false
        },
        1025: {
          items: 1
        }
      }
    });
  });
    
  if ($('body').hasClass('front')) {
    $('.newsletter_sec.form-inline').show();
  }
   $('.intl-pop').click(function(e){
     e.preventDefault();
     if(!$('.gl-bg-overlay').is(":visible")){
      $('.gl-bg-overlay').remove();
     $('.region').prepend('<div class="gl-bg-overlay"></div>');
     $('.gl-bg-overlay').show();
     $('.unity_plus_country_locator.unity2 > #CountrySelectorDropdown').slideToggle();
     }
   });
   
  $('.search, #sidr-id-responsive-menu-close-button').click(function(){
    if ($('#sidr-main').is(":visible")) {
      $.sidr('close', 'sidr-main');
    }
  });
    
 }

// Hide Header on on scroll down
var didScroll;
var lastScrollTop = 0;
var delta = 5;
var navbarHeight = $('.navbar').outerHeight();

$(window).scroll(function(event){
    didScroll = true;
});

setInterval(function() {
    if (didScroll) {
        hasScrolled();
        didScroll = false;
    }
}, 250);

function hasScrolled() {
    var st = $(this).scrollTop();
    // Make sure they scroll more than delta
    if(Math.abs(lastScrollTop - st) <= delta)
        return;
    // If they scrolled down and are past the navbar, add class .nav-up.
    // This is necessary so you never see what is "behind" the navbar.
    if (st > lastScrollTop && st > navbarHeight){
        // Scroll Down
        $('.navbar').addClass('nav-up');
        $('.back-to-top').addClass('stick-this');
        // $('#CountrySelectorDropdown').hide();
        // $("#CountrySelectorDropdown").find('.search-form').find('input').is(":focus"))) {
        //   $('#CountrySelectorDropdown').hide();
        // }
    } else {
        // Scroll Up
        if(st + $(window).height() < $(document).height()) {
            $('.navbar').removeClass('nav-up');
            $('.navbar').addClass('nav-down');
            
            if($(this).scrollTop() < 50){
              $('.navbar').removeClass('nav-down');
            }
            
        }
    }
    
    lastScrollTop = st;
    $('.search-btn').show();
    $('.gl-bg-overlay').hide();
    
    if(st < $( window ).height()){
      $('.back-to-top').removeClass('stick-this'); //hide scroll top button when scrolled only device height
    }
}
    
})(jQuery, Drupal, this, this.document);

jQuery('document').ready(function($) {
  
 $('.back-to-top').click(function(e) {
   e.preventDefault();
//   $(document).scrollTo('0%', 1500 );
   $("html, body").animate({ scrollTop: 0 }, 1500);
 });
  // mobile menu
//  $('#responsive-menu-button').sidr({
//    name: 'sidr-main',
//    source: '#navigation'
//  });
  
  
  // course table fade
  // check table display setting first, if display:block we don't do anything (mobile)
  $('#course-table tr').mouseenter(function(){
    if (($('#course-table').css('display')) === 'table') {
      $(this).find('.detail-hide').fadeIn('400');
      //$(this).find('.detail-hide .course-detail').animate({'line-height': 21},150);
      //$(this).find('.detail-hide .course-detail-small').animate({'line-height': 16},150);
      //$(this).find('.detail-hide .course-detail-small > span').animate({'line-height': 16},150);
    }
  });
  
  $('.same-height:not(.height-fixed)').each(function() {
    var parent_selector = $(this).data('common-parent'),
        parent = $(this).closest(parent_selector),
        max_height = 0;
    $(parent).find('.same-height').each(function() {
      max_height = Math.max($(this).height(), max_height);
    });
    $(parent).find('.same-height').height(max_height).addClass('height-fixed');
  });
  
  $('#course-table tr').mouseleave(function(){
    if (($('#course-table').css('display')) === 'table') {
      $(this).find('.detail-hide').hide();
      //$(this).find('.detail-hide span').animate({'line-height': 0},100);
    }
  });
 // header drop doun county selector scrips TODO move this into some other @unity2 specific file if needed
  $(".search-btn").on('click', function() {
  if(window.innerWidth < 768){
    //$('.continent-select').show();
    $('#CountrySelectorDropdown  .DropdownMenu  h2').click(function(){
      $('#continent-select').val($(this).text());
      $('.country-select').show();
      $(this).next().toggle();
      $('.DropdownDivColumn2 > h2').toggle();
      $('.DropdownDivColumn2 > .global-image').toggle();
  });
  //$('.region-content').toggleClass('gl-bg-overlay');// adds lightbox effect background to global locator for mobile #removed by chinmay
   }
		countryAutoComplete();

  });
  $("#current_country").on('click', function(e) {
  	if(window.innerWidth < 768){
  		countryAutoComplete();
  	}
  });
  
      $('.continent-select').click(function(){
      $('.DropdownDivColumn2 > ul').hide();
      $('.country-select').hide();
      $('.DropdownDivColumn2 > h2').toggle();
      $('.DropdownDivColumn2 > .global-image').toggle();
  });
  
  // trigger hide show depending on  country locator click
  jQuery('.change-country-website').click(function(){
    jQuery(this).parent().parent().parent().hide();
    $('.switch-bar').hide();
    jQuery('.change-country-website-selector').show();
  });
  
  jQuery('.International-retreat-center').click(function(){
    jQuery(this).parent().parent().parent().hide();
    $('.switch-bar').hide();
    jQuery('.International-retreat-center-selector').show();
  });
  jQuery('.country-city-chapters').click(function(){
    jQuery(this).parent().hide();
    jQuery('.change-country-chapter-website-selector').show();
  });
  jQuery('.international-options').click(function(){
    jQuery(this).parent().hide();
    jQuery('.international-options-selector').show();
  });
   jQuery('.find-a-course-gl').click(function(){
     jQuery(this).parent().hide();
     jQuery('nav.navbar').addClass('gl-search-course-mobile');
     jQuery('#edit-center-autocomplete-google2').addClass("active");
     jQuery('.country-selector-gl').show();
   });
   $('.search-website-gl').click(function(){
     $(this).parent().hide();
     $('.search-webiste-gl-p2').show();
   });
  
  //general functions
  jQuery('.hide-selector').click(function(){
    jQuery(this).parent().parent().hide();
    jQuery('.mobile-country-locator-2').show();
    $('#edit-center-autocomplete-google2').removeClass("active");
  });
  jQuery('.inner-hide-selector').click(function(){
    jQuery(this).parent().parent().hide();
    $('.switch-bar').show();
    jQuery('.international-options-selector').show();
    $('#edit-center-autocomplete-google2').removeClass("active");
  });
  
  $('.close-selector').click(function(){
    $('.country-locator-phase2').hide();
    $('.mobile-country-locator-2').show();
    $('#CountrySelectorDropdown').hide();
    $('#edit-center-autocomplete-google2').removeClass("active");
    $('.gl-bg-overlay').hide();
    $('.search-btn').show();
    //$('#mobile-header').css('float','right');
    $('.logo').removeClass('hidden-xs');
  });
  
  $('.close-selector-top').click(function(){
    $('.gl-bg-overlay').hide();
    $('.search-btn').show();
    $('#CountrySelectorDropdown').hide();
    //$('#mobile-header').css('float','right');
    $('.logo').removeClass('hidden-xs');
  });
  var close_sidr = function () {
    if ($('#sidr-main').is(":visible")) {
      $.sidr('close', 'sidr-main');
    }
  }
  
  $(window).resize(function() {
    if($(window).width() > 1023){
      close_sidr();
    }
  });
  
  $('.search, #sidr-id-responsive-menu-close-button').click(function(){
    close_sidr();
  });
  
	function countryAutoComplete(){
		var list = {
			countries: []
		};
	  jQuery('#mobile-country-list').find('a').each(function(i,mobileCountry) {
	    list.countries.push({
	    "label" : jQuery(this).text(),
	    "value" : jQuery(this).attr('href'),
	   }) // */
	             
		});
		masterList = list.countries.sort(function (a, b) {
	    return a.label.localeCompare( b.label );
	  });
		var termTemplate = "<span class='ui-autocomplete-term'>%s</span>";
	   $("#mobile-country-finder").autocomplete({
	    source: list.countries,
	    open: function(e,ui) {
	    var
	        acData = $(this).data('uiAutocomplete'),
	        styledTerm = termTemplate.replace('%s', acData.term);
	
	    acData
	        .menu
	        .element
	        .find('a')
	        .each(function() {
	            var me = $(this);
	            me.html( me.text().replace(acData.term, styledTerm) );
	        });
	    },
	    select: function( event, ui ) { 
	        window.location.href = ui.item.value;
	    }
		}).focus(function () {
			$(this).autocomplete("search", " ");
		});
	      
	  var chapterList = {
	      countryChapters: []
	  };
	  jQuery('.country-chapters').find('li').each(function(j,countryChapterHolder) {
	    jQuery(countryChapterHolder).find('a').each(function(k,country) {
		      chapterList.countryChapters.push({
		      "label" : jQuery(this).text(),
		      "value" : jQuery(this).attr('href'),
				}) // */
	    });    
	  });
	  
	  jQuery("#mobile-country-chapter-finder").autocomplete({
	    source: chapterList.countryChapters,
	    select: function( event, ui ) { 
	        window.location.href = ui.item.value;
	    },
	  });
	}
  
});
;
