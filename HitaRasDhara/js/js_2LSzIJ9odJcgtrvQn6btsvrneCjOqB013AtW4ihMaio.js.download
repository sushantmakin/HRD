(function ($, Drupal, window, document, undefined) {
  var ajaxBandaiFormId = 0;
  $(function() {

    var unityUxFormRefresh = function($form, checkboxesChanged, pagination) {
      //$form = $(".home-page-course-search");
      //add country prefix
      var basePath = Drupal.settings.basePath;
      var path = "course-search/ajax", pathRedirect = 'search/course';
      
      if($.trim($('#custom_search_page_nid').val()) != ''){
        var nid = $.trim($('#custom_search_page_nid').val());
        path = "/" +path;
        pathRedirect = nid;  //  "/node/" +nid;  //edited for course list component to redirect to country page
      }else if (Drupal.settings.pathPrefix) {
        path = "/" + Drupal.settings.pathPrefix +path;
        pathRedirect =  "/" + Drupal.settings.pathPrefix +pathRedirect;
      }else {
        path = "/" +path;
        pathRedirect = "/" +pathRedirect;
      }
      //path = Drupal.settings.aol.course_path;
      //$('.course-list').css('visibility', 'hidden');
      //$form.find('.loading-data').show();



      var serialized = $form.serialize();
      serialized = serialized.replace('lat2', 'lat');
      serialized = serialized.replace('lng2', 'lng');
      serialized = serialized.replace('obj2', 'obj');
      serialized = serialized.replace('google2', 'google');
      
      $.post(
          path,
          serialized,
          function(response, status){
            var adress = response.url;
            path = path.replace("/ajax", "")
            window.location.href = pathRedirect+adress;
            //alert(response);
            //console.log(basePath);
            //console.log(path, response);
          }
      );

      
    }
    
      $('#edit-center-autocomplete-google2').click(function() {
      if (typeof google == 'undefined') {
        $.holdReady(true);
        $.getScript("https://maps.googleapis.com/maps/api/js?v=3.exp&sensor=false&libraries=places", function() {
             $.holdReady(false);
             if ($('input[name="center_autocomplete_google2"]').length)
             	 var autocomplete = geoHelper.initializeMap('input[name="center_autocomplete_google2"]', unityUxFormRefresh);
        });
      }
    })
    
    
    if (!$('body').hasClass('page-search-course') 
         && !$('body').hasClass('node-type-course-menu')
         && !$('body').hasClass('page-search')
         && $('#course-followups-wrapper').length <= 0) {
      geoHelper.initializeMap('input[name="center_autocomplete_google"]', unityUxFormRefresh);
    }
    if ($('input[name="center_autocomplete_google2"]').length)
    	var autocomplete = geoHelper.initializeMap('input[name="center_autocomplete_google2"]', unityUxFormRefresh);
    
    $('.search-btn').click(function(){
      if (window.innerWidth < 768) {
        //$('#CountrySelectorDropdown').show();
        //$('#edit-center-autocomplete-google2').addClass("active");
        //$('.head_right_sec').addClass('active');
        //$('.logo').addClass('hidden-xs');
        //('#current_country').addClass('hidden-xs'); //since it breakes on mobile screen  update by chinmay
        //$('#mobile-header').css('float','left'); // removed by chinmay since it is not in new requirement
        //$(this).hide();        
      	if($('.unity_plus_country_locator.unity2 .center-changer').css('display') == 'block')
        	$('.unity_plus_country_locator.unity2 .center-changer').slideToggle();
      }
      else {
        google.maps.event.trigger(autocomplete, 'place_changed');
      }
    });
    
    
   
   $(window).scroll(function(){
        if ($('.sticky-header').css("visibility") != "hidden"){
          if($('.sticky-enabled  .bandai-select-inner').is(":visible")){
            $('.sticky-enabled  .bandai-select-inner').hide();
            $('.sticky-header  .bandai-select-inner').show();
          }
        }
        if ($('.sticky-header').css("visibility") == "hidden"){
          if($('.sticky-header  .bandai-select-inner').is(":visible")){
            $('.sticky-header  .bandai-select-inner').hide();
            $('.sticky-enabled  .bandai-select-inner').show();
          }
        }
       
    })
    
    $('.home-page-course-search2').submit(function(event){
       return false;
    });       
  })
})(jQuery, Drupal, this, this.document);  ;
/*! jQuery JSON plugin 2.4.0 | code.google.com/p/jquery-json */
(function($){'use strict';var escape=/["\\\x00-\x1f\x7f-\x9f]/g,meta={'\b':'\\b','\t':'\\t','\n':'\\n','\f':'\\f','\r':'\\r','"':'\\"','\\':'\\\\'},hasOwn=Object.prototype.hasOwnProperty;$.toJSON=typeof JSON==='object'&&JSON.stringify?JSON.stringify:function(o){if(o===null){return'null';}
var pairs,k,name,val,type=$.type(o);if(type==='undefined'){return undefined;}
if(type==='number'||type==='boolean'){return String(o);}
if(type==='string'){return $.quoteString(o);}
if(typeof o.toJSON==='function'){return $.toJSON(o.toJSON());}
if(type==='date'){var month=o.getUTCMonth()+1,day=o.getUTCDate(),year=o.getUTCFullYear(),hours=o.getUTCHours(),minutes=o.getUTCMinutes(),seconds=o.getUTCSeconds(),milli=o.getUTCMilliseconds();if(month<10){month='0'+month;}
if(day<10){day='0'+day;}
if(hours<10){hours='0'+hours;}
if(minutes<10){minutes='0'+minutes;}
if(seconds<10){seconds='0'+seconds;}
if(milli<100){milli='0'+milli;}
if(milli<10){milli='0'+milli;}
return'"'+year+'-'+month+'-'+day+'T'+
hours+':'+minutes+':'+seconds+'.'+milli+'Z"';}
pairs=[];if($.isArray(o)){for(k=0;k<o.length;k++){pairs.push($.toJSON(o[k])||'null');}
return'['+pairs.join(',')+']';}
if(typeof o==='object'){for(k in o){if(hasOwn.call(o,k)){type=typeof k;if(type==='number'){name='"'+k+'"';}else if(type==='string'){name=$.quoteString(k);}else{continue;}
type=typeof o[k];if(type!=='function'&&type!=='undefined'){val=$.toJSON(o[k]);pairs.push(name+':'+val);}}}
return'{'+pairs.join(',')+'}';}};$.evalJSON=typeof JSON==='object'&&JSON.parse?JSON.parse:function(str){return eval('('+str+')');};$.secureEvalJSON=typeof JSON==='object'&&JSON.parse?JSON.parse:function(str){var filtered=str.replace(/\\["\\\/bfnrtu]/g,'@').replace(/"[^"\\\n\r]*"|true|false|null|-?\d+(?:\.\d*)?(?:[eE][+\-]?\d+)?/g,']').replace(/(?:^|:|,)(?:\s*\[)+/g,'');if(/^[\],:{}\s]*$/.test(filtered)){return eval('('+str+')');}
throw new SyntaxError('Error parsing JSON, source is not valid.');};$.quoteString=function(str){if(str.match(escape)){return'"'+str.replace(escape,function(a){var c=meta[a];if(typeof c==='string'){return c;}
c=a.charCodeAt();return'\\u00'+Math.floor(c/16).toString(16)+(c%16).toString(16);})+'"';}
return'"'+str+'"';};}(jQuery));;
/*! fluidvids.js v2.4.1 | (c) 2014 @toddmotto | https://github.com/toddmotto/fluidvids */
(function (root, factory) {
  if (typeof define === 'function' && define.amd) {
    define(factory);
  } else if (typeof exports === 'object') {
    module.exports = factory;
  } else {
    root.fluidvids = factory();
  }
})(this, function () {

  'use strict';

  var fluidvids = {
    selector: ['iframe', 'object'],
    players: ['www.youtube.com', 'player.vimeo.com']
  };

  var css = [
    '.fluidvids-wraper { margin: 0 auto; }',
    '.fluidvids { width: 100%; max-width: 100%; position: relative; }',
    '.fluidvids-item { position: absolute; top: 0px; left: 0px; width: 100%; height: 100%; }' // max-width: 100%;
  ].join('');

  var head = document.head || document.getElementsByTagName('head')[0];

  function matches (src) {
    return new RegExp('^(https?:)?\/\/(?:' + fluidvids.players.join('|') + ').*$', 'i').test(src);
  }

  function getRatio (height, width) {
    return ((parseInt(height, 10) / parseInt(width, 10)) * 100) + '%';
  }

  function fluid (elem) {
    if (!matches(elem.src) && !matches(elem.data) || !!elem.getAttribute('data-fluidvids')) return;
    var wrap = document.createElement('div');
    elem.parentNode.insertBefore(wrap, elem);
    elem.className += (elem.className ? ' ' : '') + 'fluidvids-item';
    elem.setAttribute('data-fluidvids', 'loaded');
    wrap.className += 'fluidvids';
    if(!elem.height.indexOf('%') == -1) {
      wrap.style.paddingTop = getRatio(elem.height, elem.width);
    } else {
      wrap.style.paddingTop = "50%";
    }
    wrap.appendChild(elem);
    /// @Zydrunas: below added for wrapper with max-width: support
    //@Mantas changing max-width to width
    var wrap_2 = document.createElement('div');
    wrap.parentNode.insertBefore(wrap_2, wrap);
    wrap_2.className = 'fluidvids-wraper';
    wrap_2.style.maxWidth = elem.width + "px";
    wrap_2.appendChild(wrap);
  }

  function addStyles () {
    var div = document.createElement('div');
    div.innerHTML = '<p>x</p><style>' + css + '</style>';
    head.appendChild(div.childNodes[1]);
  }

  fluidvids.render = function () {
    var nodes = document.querySelectorAll(fluidvids.selector.join());
    var i = nodes.length;
    while (i--) {
      fluid(nodes[i]);
    }
  };

  fluidvids.init = function (obj) {
    for (var key in obj) {
      fluidvids[key] = obj[key];
    }
    fluidvids.render();
    addStyles();
  };

  return fluidvids;

});
;
(function(e){function t(t){var n=e(this),r=null,i=[],s=null,o=null,u=e.extend({rowSelector:"> li",submenuSelector:"*",submenuDirection:"right",tolerance:75,enter:e.noop,exit:e.noop,activate:e.noop,deactivate:e.noop,exitMenu:e.noop,width:"auto"},t);var a=3,f=250;var l=function(e){i.push({x:e.pageX,y:e.pageY});if(i.length>a){i.shift()}};var c=function(){if(o){clearTimeout(o)}if(u.exitMenu(this)){if(r){u.deactivate(r)}r=null}};var h=function(){u.enter(this);m(this)},p=function(){if(o){clearTimeout(o)}u.exit(this)};var d=function(){v(this)};var v=function(e){if(e==r){return}if(r){u.deactivate(r)}u.activate(e);r=e};var m=function(e){var t=g();if(t){o=setTimeout(function(){m(e)},t)}else{v(e)}};var g=function(){function g(e,t){return(t.y-e.y)/(t.x-e.x)}if(!r||!e(r).is(u.submenuSelector)){return 0}var t=n.offset(),o="auto"==u.width?n.outerWidth():u.width,a={x:t.left,y:t.top-u.tolerance},l={x:t.left+o,y:a.y},c={x:t.left+n.outerWidth(),y:a.y},h={x:t.left,y:t.top+n.outerHeight()+u.tolerance},p={x:t.left+o,y:h.y},d={x:t.left+n.outerWidth(),y:h.y},v=i[i.length-1],m=i[0];if(!v){return 0}if(!m){m=v}if(m.x<t.left||m.x>d.x||m.y<t.top||m.y>d.y){return 0}if(s&&v.x==s.x&&v.y==s.y){return 0}var y=l,b=p;if(u.submenuDirection=="left"){y=h;b=a}else if(u.submenuDirection=="below"){y=p;b=h}else if(u.submenuDirection=="above"){y=a;b=l}var w=g(v,y),E=g(v,b),S=g(m,y),x=g(m,b);if(w<S&&E>x){s=v;return f}s=null;return 0};n.mouseleave(c).find(u.rowSelector).mouseenter(h).mouseleave(p).click(d);e(document).mousemove(l)}e.fn.menuAim=function(e){this.each(function(){t.call(this,e)});return this};})(jQuery);
(function ($) {

$(document).ready(function() {
    $("#current_country").on('click', function(e) {
      selectContinent(1);
      $("#CountrySelectorDropdown ").menuAim({
           activate: function(row) {
             $(row).parent().find('.DropdownDivColumn').removeClass('active');
             $(row).addClass("active"); 
           },
           rowSelector: ".DropdownDivColumn",
           tolerance: 20,
           width: 165,
      });
      $('.unity_plus_country_locator.unity > #CountrySelectorDropdown').slideToggle();
      if($('.unity_plus_country_locator.unity2 > #CountrySelectorDropdown').css('display') == 'block')
      	$('.unity_plus_country_locator.unity2 > #CountrySelectorDropdown').slideToggle();
      $('.unity_plus_country_locator.unity2 > .current-country-holder > .center-changer').slideToggle();
    });
    $('#bt-close').on('click', function(e) {
      e.preventDefault();      
      $(this).parent().slideToggle();
      $('.gl-bg-overlay').hide();
    });
    $('.search-btn').click(function(){
       if (window.innerWidth < 768) {
         $('.region').prepend('<div class="gl-bg-overlay"></div>');
         $('.gl-bg-overlay').show();
         selectContinent(1);
         $('#CountrySelectorDropdown').slideToggle();
      }
    });
    jQuery( "body" ).click(function( event ) {
      if(event.target.className == 'gl-bg-overlay'){
        $('#CountrySelectorDropdown').hide();
        $('.gl-bg-overlay').hide();
      }
    });
    $('.LanguageSelection li').not('.Selected').hide();
    $('.LanguageSelection li.Selected a.active').unbind('click').bind('click', function(e) {
      e.preventDefault();
      if ($('.language-popup').length > 0) {
        $('.language-popup').remove();
      }
      else {
        //$('.LanguageSelection').toggleClass('language-popup');
        //$('#block-country-locator-3 .LanguageSelection li').not('.Selected').toggle();
        //var html = $('.LanguageSelection').clone();
        //$(html).addClass('language-popup').find('li').show();
        //$('.LanguageSelection').parent().append(html);
    	$('.unity_plus_country_locator.unity2 > .current-country-holder > .center-changer').hide();
    	$('#CountrySelectorDropdown').hide();
    	var html = $('.LanguageSelection').html();
        $('.LanguageSelection').parent().append('<div class="LanguageSelection1 LanguageDiv language-popup">'+html+'</div>');
        $('.language-popup').find('li').show();
      }
    });

 });
$(document).bind('click', function(e){
    var $target = $(e.target);
    if(!$target.closest('.LanguageSelection').length){
      $('.LanguageSelection1.language-popup').remove();
    }
    
  });


// COUNTRY SELECTOR --------------------------------------------------------------------------

var COUNTRIES_PER_COLUMN = 29;
var COUNTRY_COLUMNS = 5;

var selectedContinent = 1;
var currentCountriesPage = 0;


function showHideCountrySelector() {
    elm = document.getElementById("CountrySelectorDropdown");
    // Show & hide
    if (elm.className == "CountrySelectorShow") {
        elm.className = "CountrySelectorHidden";
    } else {
        elm.className = "CountrySelectorShow";
        showContinent(selectedContinent, 0);
    }
}


/**
* Selects a continent
* @param continentId
**/
function selectContinent(continentId) {
    // Sve last selected continent
    lastContinent = selectedContinent;
    // Select Continent
    selectedContinent = continentId;
    // Hide last one
    hideContinent(lastContinent);
    // Shows a continent
    showContinent(continentId, 0);
    currentCountriesPage = 0;
}

var was = false;

function showContinent(continentId, page) {
  var result = {};
  result.continents = continentCountries;
//  console.log(result);
  var html = _.template(countries_rows_template, result);
  var mobileHtml = _.template(mbl_countries_rows_template, result);
  
  $("#CountrySelectorDropdown").find('.DropdownMenu').html(html);
  $("#CountrySelectorDropdown").find('#mobile-country-list').html(mobileHtml);
  return ;
}

function hideContinent(continentId, page) {
    showContinent(selectedContinent, currentCountriesPage);
}



})(jQuery);;
/*!
 * jQuery ClassyBox
 * vox.SPACE
 *
 * Written by Marius Stanciu - Sergiu <marius@vox.space>
 * Licensed under the MIT license https://vox.SPACE/LICENSE-MIT
 * Version 1.3.3
 *
 */(function(d){function z(a){d("body").append('<div id="classybox"></div><div class="classybox-loader"></div><section class="classybox-wrap"><h2 class="hide">ClassyBox Media Browser</h2><div class="content"><div class="close"><a href="#">close</a></div><div class="panel"></div><div class="next"><a href="#">next</a></div><div class="prev"><a href="#">previous</a></div></div></section>');k=d("#classybox");l=d(".classybox-loader");f=d(".classybox-wrap");c=d(".classybox-wrap").find(".content");A=d(".classybox-wrap").find(".close"); Panel=d(".classybox-wrap").find(".panel");n=d(".classybox-wrap").find(".next");p=d(".classybox-wrap").find(".prev");f.contents().hide();f.hide();a.navigation&&(u(a),p.unbind().bind("click",function(){E(a);return!1}),n.unbind().bind("click",function(){F(a);return!1}));k.fadeIn(a.speed/1.5);v=0==d(document).scrollTop()?h[0]-a.height/2:d(document).scrollTop()+h[0]-a.height/2;f.css({top:v+h[0]/1.6,left:h[1]});l.css({top:v+h[0]/2+l.height()/1.5,left:h[1]}).hide();f.fadeIn(500,function(){q(a,a.height,a.width, 0);w(a)});d(window).resize(function(){q(a,r,s,0,1)});A.click(function(){B(a);return!1});a.closeAnywhere&&k.click(function(){B(a)})}function w(a){var b=a.arrayEl[a.arrayActEl][0];if(0<b.indexOf("jpg",".")||0<b.indexOf("png",".")||0<b.indexOf("gif",".")){c.append('<div class="image"><img /></div>');l.fadeIn(200);f.find(".image img").hide();var g=new Image;g.onload=function(){f.find(".image img").attr("src",g.src);r=g.height;s=g.width;q(a,g.height,g.width);g.onload=function(){};l.fadeOut(400)};g.src= b;var e=a.arrayEl[a.arrayActEl][2],m=a.arrayEl[a.arrayActEl][1];m&&(f.find(".image").append("<div class='text'><h1>"+m+"</h1></div>"),f.hover(function(){d(this).find(".text").stop(!0,!0).delay(200).slideDown(200)},function(){d(this).find(".text").stop(!0,!0).delay(200).slideUp(180)}));e&&f.find(".text").append("<div class='description'>"+e+"</div>")}else c.fadeIn(a.speed/1.5),r=a.height,s=a.width;if(0<b.indexOf("mp3",".")||0<b.indexOf("vmw",".")||0<b.indexOf("avi",".")||0<b.indexOf("mp4","."))c.append("<div class='object'><div id='classybox-player'></div></div>"), jwplayer("classybox-player").setup({file:b,width:a.width,height:a.height});0<b.indexOf("youtube",".")&&(c.append("<div class='object'></div>"),hrefY="http://www.youtube.com/embed/"+b.substring(31,42),f.find(".object").append("<iframe class='' type='text/html' width='"+a.width+"' height='"+a.height+"' src='"+hrefY+"' frameborder='0'></iframe>"));0<b.indexOf("vimeo",".")&&(c.append("<div class='object'></div>"),hrefV=b.substr(-9).replace('/', ''),f.find(".object").append("<iframe src='http://player.vimeo.com/video/"+ hrefV+"?title=0&amp;byline=0&amp;portrait=0' width='"+a.width+"' height='"+a.height+"' frameborder='0' webkitAllowFullScreen mozallowfullscreen allowFullScreen></iframe>"));a.iframe&&c.append("<iframe src='"+b+"' scrolling='auto' height='"+a.height+"' width='"+a.width+"' frameborder='0'></iframe>");a.inline&&c.append(d(b).html());(!1!==a.ajax||0<b.indexOf("txt",".")||0<b.indexOf("js","."))&&d.ajax({type:a.ajaxType?a.ajaxType:"GET",url:b,data:a.ajaxData,success:a.ajaxSuccess?a.ajaxSuccess:function(a){c.append(a)}}); 0<b.indexOf("dailymotion",".")&&(e=b.substring(33,39),c.append("<iframe frameborder='0' width='"+a.width+"' height='"+a.height+"' src='http://www.dailymotion.com/embed/video/"+e+"'></iframe>"));0<b.indexOf("5min",".")&&(e=b.substr(-9),c.append("<object width='"+a.width+"' height='"+a.height+"' id='FiveminPlayer' classid='clsid:d27cdb6e-ae6d-11cf-96b8-444553540000'><param name='allowfullscreen' value='true'/><param name='allowScriptAccess' value='always'/><param name='movie' value='http://embed.5min.com/"+ e+"/'/><param name='wmode' value='opaque' /><embed name='FiveminPlayer' src='http://embed.5min.com/"+e+"/' type='application/x-shockwave-flash' width='"+a.width+"' height='"+a.height+"' allowfullscreen='true' allowScriptAccess='always' wmode='opaque'></embed></object>"));0<b.indexOf("metacafe",".")&&(e=b.substr(30).slice(0,-1),c.append("<embed flashVars='playerVars=autoPlay=no' src='http://www.metacafe.com/fplayer/"+e+".swf' width='"+a.width+"' height='"+a.height+"' wmode='transparent' allowFullScreen='true' allowScriptAccess='always' name='Metacafe_"+ e.substring(0,7)+"' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash'></embed>"));0<b.indexOf("ustream",".")&&(e=b.substring(31,39),c.append("<iframe frameborder='0' width='"+a.width+"' height='"+a.height+"' src='http://www.ustream.tv/embed/recorded/"+e+"' style='border: 0px none transparent;'></iframe>"));0<b.indexOf("hell",".")&&(e=b.substring(28,33),c.append("<iframe width='"+a.width+"' height='"+a.height+"' src='http://www.hell.tv/embed/video/"+e+"' frameborder='0' scrolling='no' allowfullscreen></iframe>")); 0<b.indexOf("vevo",".")&&(e=b.substr(-12),c.append("<object width='"+a.width+"' height='"+a.height+"'><param name='movie' value='http://videoplayer.vevo.com/embed/Embedded?videoId="+e+"&playlist=false&autoplay=0&playerId=62FF0A5C-0D9E-4AC1-AF04-1D9E97EE3961&playerType=embedded&env=0&cultureName=en-US&cultureIsRTL=False'></param><param name='wmode' value='transparent'></param><param name='bgcolor' value='#000000'></param><param name='allowFullScreen' value='true'></param><param name='allowScriptAccess' value='always'></param><embed src='http://videoplayer.vevo.com/embed/Embedded?videoId="+ e+"&playlist=false&autoplay=0&playerId=62FF0A5C-0D9E-4AC1-AF04-1D9E97EE3961 &playerType=embedded&env=0&cultureName=en-US&cultureIsRTL=False' type='application/x-shockwave-flash' allowfullscreen='true' allowscriptaccess='always' width='"+a.width+"' height='"+a.height+"' bgcolor='#000000' wmode='transparent'></embed></object>"));0<b.indexOf("myspace",".")&&(e=b.substr(-9),c.append("<object width='"+a.width+"' height='"+a.height+"'><param name='allowFullScreen' value='true'/><param name='wmode' value='transparent'/><param name='movie' value='http://mediaservices.myspace.com/services/media/embed.aspx/m="+ e+",t=1,mt=video'/><embed src='http://mediaservices.myspace.com/services/media/embed.aspx/m="+e+",t=1,mt=video' width='"+a.width+"' height='"+a.height+" allowFullScreen='true' type='application/x-shockwave-flash' wmode='transparent'></embed></object>"));a.social&&Panel.append("<div class='fb'><a href='"+("http://www.facebook.com/share.php?u="+window.location+"?cbox="+b)+"' target='_blank'>Facebook</a></div><div class='tw'><a href='"+("https://twitter.com/share?url="+window.location+"?cbox="+b)+"' target='_blank'>Twitter</a></div><div class='gp'><a href='"+ ("https://plus.google.com/share?url="+window.location+"?cbox="+b)+"' target='_blank'>Google plus</a></div>")}function u(a){0!=a.arrayActEl?p.css("top",a.height/2).show():p.hide();a.arrayActEl!=a.arrayEl.length-1?n.css("top",a.height/2).show():n.hide();x(a)}function E(a){0!=a.arrayActEl&&(a.arrayActEl-=1,f.animate({left:"+="+a.width/1.5,opacity:0},a.speed/1.4,function(){c.contents().not(".next, .prev, .close, .panel").remove();Panel.contents().remove();f.animate({left:"-="+2.5*a.width,opacity:0},1).animate({opacity:1}, a.speed/1.5);c.find(".image").length||f.animate({left:h[1]-a.width/2},a.speed/1.5);x(a);w(a);u(a)}))}function F(a){a.arrayActEl!=a.arrayEl.length-1&&(a.arrayActEl+=1,f.animate({left:"-="+a.width/1.5,opacity:0},a.speed/1.4,function(){c.contents().not(".next, .prev, .close, .panel").remove();Panel.contents().remove();f.animate({left:"+="+2.5*a.width,opacity:0},1).animate({opacity:1},a.speed/1.5);c.find(".image").length||f.animate({left:h[1]-a.width/2},a.speed/1.5);x(a);w(a);u(a)}))}function x(a){a.numberEl&& (d(".classybox-wrap .content .number").remove(),0!=a.arrayEl.length&&c.append('<div class="number">'+(a.arrayActEl+1)+" / "+a.arrayEl.length+"</div>"))}function q(a,b,g,e,m){h=y(a);var t=1.6*h[0],k=1.6*h[1],l=0;if(t>b||k>g)a.height=b,a.width=g;else if(a.resize&&(c.find(".resize").remove(),Panel.prepend('<div class="resize"><a href="#">Resize</a></div>'),C=c.find(".resize"),C.find("a").click(function(){q(a,r,s,1);return!1})),a.img&&!e||!e)b>t&&(l=t/b,a.height=b=t,a.width=g*=l),g>k&&(a.height=b*=k/ g,a.width=g=k);f.animate({top:d(document).scrollTop()+h[0]-b/2,left:h[1]-g/2,width:g,height:b},m?0:a.speed/1.5,function(){c.find(".image img, iframe, object").height(b).width(g);d(this).find(".image").contents().fadeIn(a.speed,function(){c.fadeIn(a.speed/1.7)})});n.animate({top:b/2},m?0:50);p.animate({top:b/2},m?0:50)}function B(a){arrPageSize=y();a.arrayEl.length=0;a.arrayActEl=0;c.fadeOut(a.speed/1.6,function(){f.animate({left:arrPageSize[1],top:arrPageSize[0],height:20,width:20},a.speed/1.3,function(){f.fadeOut(a.speed/ 1.2,function(){f.contents().remove();f.remove();k.fadeOut(a.speed/1.5,function(){k.remove()})})})})}function y(){var a=[];a[0]=document.documentElement.clientHeight/2;a[1]=document.documentElement.clientWidth/2;return a}function D(a){var b=window.document.URL.toString();if(0<b.indexOf("?")){for(var b=b.split("?")[1].split("&"),g=Array(b.length),e=Array(b.length),d=0,d=0;d<b.length;d++){var c=b[d].split("=");g[d]=c[0];e[d]=""!==c[1]?unescape(c[1]):"No Value"}for(d=0;d<b.length;d++)if(g[d]==a)return e[d]; return!1}}d.fn.ClassyBox=function(a){a=d.extend({speed:400,height:450,width:650,arrayEl:[],arrayActEl:0,autoDetect:!0,img:1,iframe:!1,inline:!1,ajax:!1,ajaxType:0,ajaxData:0,ajaxSuccess:0,title:!0,navigation:!0,numberEl:1,resize:!0,social:!0,closeAnywhere:!0},a);var b=d(this);if(a.autoDetect&&D("cbox")){var c=D("cbox"),c=d('a[href*="'+unescape(c)+'"]');a.arrayEl.push([c.attr("href"),c.attr("title"),c.children("img").attr("alt")]);z(a)}return this.unbind("click").click(function(){if(d(this).is("a")){a.arrayEl.length= 0;a.arrayActEl=0;if(1!=b.length||a.autoDetect)for(var c=0;c<b.length;c++)a.arrayEl.push([b[c].getAttribute("href"),b[c].getAttribute("title"),d(b[c]).children("img").attr("alt")]);else a.arrayEl.push([this.getAttribute("href"),this.getAttribute("title"),d(this).children("img").attr("alt")]);for(;a.arrayEl[a.arrayActEl][0]!=this.getAttribute("href");)a.arrayActEl++;z(a);return!1}})};var k,f,c,A,n,p,l,C,r,s,h=y(),v})(jQuery);;
/*!
 * jQuery UI Touch Punch 0.2.3
 *
 * Copyright 2011–2014, Dave Furfero
 * Dual licensed under the MIT or GPL Version 2 licenses.
 *
 * Depends:
 *  jquery.ui.widget.js
 *  jquery.ui.mouse.js
 */
!function(a){function f(a,b){if(!(a.originalEvent.touches.length>1)){a.preventDefault();var c=a.originalEvent.changedTouches[0],d=document.createEvent("MouseEvents");d.initMouseEvent(b,!0,!0,window,1,c.screenX,c.screenY,c.clientX,c.clientY,!1,!1,!1,!1,0,null),a.target.dispatchEvent(d)}}if(a.support.touch="ontouchend"in document,a.support.touch){var e,b=a.ui.mouse.prototype,c=b._mouseInit,d=b._mouseDestroy;b._touchStart=function(a){var b=this;!e&&b._mouseCapture(a.originalEvent.changedTouches[0])&&(e=!0,b._touchMoved=!1,f(a,"mouseover"),f(a,"mousemove"),f(a,"mousedown"))},b._touchMove=function(a){e&&(this._touchMoved=!0,f(a,"mousemove"))},b._touchEnd=function(a){e&&(f(a,"mouseup"),f(a,"mouseout"),this._touchMoved||f(a,"click"),e=!1)},b._mouseInit=function(){var b=this;b.element.bind({touchstart:a.proxy(b,"_touchStart"),touchmove:a.proxy(b,"_touchMove"),touchend:a.proxy(b,"_touchEnd")}),c.call(b)},b._mouseDestroy=function(){var b=this;b.element.unbind({touchstart:a.proxy(b,"_touchStart"),touchmove:a.proxy(b,"_touchMove"),touchend:a.proxy(b,"_touchEnd")}),d.call(b)}}}(jQuery);;
/*!
* jQuery Cycle2; version: 2.1.6 build: 20141007
* http://jquery.malsup.com/cycle2/
* Copyright (c) 2014 M. Alsup; Dual licensed: MIT/GPL
*/
!function(a){"use strict";function b(a){return(a||"").toLowerCase()}var c="2.1.6";a.fn.cycle=function(c){var d;return 0!==this.length||a.isReady?this.each(function(){var d,e,f,g,h=a(this),i=a.fn.cycle.log;if(!h.data("cycle.opts")){(h.data("cycle-log")===!1||c&&c.log===!1||e&&e.log===!1)&&(i=a.noop),i("--c2 init--"),d=h.data();for(var j in d)d.hasOwnProperty(j)&&/^cycle[A-Z]+/.test(j)&&(g=d[j],f=j.match(/^cycle(.*)/)[1].replace(/^[A-Z]/,b),i(f+":",g,"("+typeof g+")"),d[f]=g);e=a.extend({},a.fn.cycle.defaults,d,c||{}),e.timeoutId=0,e.paused=e.paused||!1,e.container=h,e._maxZ=e.maxZ,e.API=a.extend({_container:h},a.fn.cycle.API),e.API.log=i,e.API.trigger=function(a,b){return e.container.trigger(a,b),e.API},h.data("cycle.opts",e),h.data("cycle.API",e.API),e.API.trigger("cycle-bootstrap",[e,e.API]),e.API.addInitialSlides(),e.API.preInitSlideshow(),e.slides.length&&e.API.initSlideshow()}}):(d={s:this.selector,c:this.context},a.fn.cycle.log("requeuing slideshow (dom not ready)"),a(function(){a(d.s,d.c).cycle(c)}),this)},a.fn.cycle.API={opts:function(){return this._container.data("cycle.opts")},addInitialSlides:function(){var b=this.opts(),c=b.slides;b.slideCount=0,b.slides=a(),c=c.jquery?c:b.container.find(c),b.random&&c.sort(function(){return Math.random()-.5}),b.API.add(c)},preInitSlideshow:function(){var b=this.opts();b.API.trigger("cycle-pre-initialize",[b]);var c=a.fn.cycle.transitions[b.fx];c&&a.isFunction(c.preInit)&&c.preInit(b),b._preInitialized=!0},postInitSlideshow:function(){var b=this.opts();b.API.trigger("cycle-post-initialize",[b]);var c=a.fn.cycle.transitions[b.fx];c&&a.isFunction(c.postInit)&&c.postInit(b)},initSlideshow:function(){var b,c=this.opts(),d=c.container;c.API.calcFirstSlide(),"static"==c.container.css("position")&&c.container.css("position","relative"),a(c.slides[c.currSlide]).css({opacity:1,display:"block",visibility:"visible"}),c.API.stackSlides(c.slides[c.currSlide],c.slides[c.nextSlide],!c.reverse),c.pauseOnHover&&(c.pauseOnHover!==!0&&(d=a(c.pauseOnHover)),d.hover(function(){c.API.pause(!0)},function(){c.API.resume(!0)})),c.timeout&&(b=c.API.getSlideOpts(c.currSlide),c.API.queueTransition(b,b.timeout+c.delay)),c._initialized=!0,c.API.updateView(!0),c.API.trigger("cycle-initialized",[c]),c.API.postInitSlideshow()},pause:function(b){var c=this.opts(),d=c.API.getSlideOpts(),e=c.hoverPaused||c.paused;b?c.hoverPaused=!0:c.paused=!0,e||(c.container.addClass("cycle-paused"),c.API.trigger("cycle-paused",[c]).log("cycle-paused"),d.timeout&&(clearTimeout(c.timeoutId),c.timeoutId=0,c._remainingTimeout-=a.now()-c._lastQueue,(c._remainingTimeout<0||isNaN(c._remainingTimeout))&&(c._remainingTimeout=void 0)))},resume:function(a){var b=this.opts(),c=!b.hoverPaused&&!b.paused;a?b.hoverPaused=!1:b.paused=!1,c||(b.container.removeClass("cycle-paused"),0===b.slides.filter(":animated").length&&b.API.queueTransition(b.API.getSlideOpts(),b._remainingTimeout),b.API.trigger("cycle-resumed",[b,b._remainingTimeout]).log("cycle-resumed"))},add:function(b,c){var d,e=this.opts(),f=e.slideCount,g=!1;"string"==a.type(b)&&(b=a.trim(b)),a(b).each(function(){var b,d=a(this);c?e.container.prepend(d):e.container.append(d),e.slideCount++,b=e.API.buildSlideOpts(d),e.slides=c?a(d).add(e.slides):e.slides.add(d),e.API.initSlide(b,d,--e._maxZ),d.data("cycle.opts",b),e.API.trigger("cycle-slide-added",[e,b,d])}),e.API.updateView(!0),g=e._preInitialized&&2>f&&e.slideCount>=1,g&&(e._initialized?e.timeout&&(d=e.slides.length,e.nextSlide=e.reverse?d-1:1,e.timeoutId||e.API.queueTransition(e)):e.API.initSlideshow())},calcFirstSlide:function(){var a,b=this.opts();a=parseInt(b.startingSlide||0,10),(a>=b.slides.length||0>a)&&(a=0),b.currSlide=a,b.reverse?(b.nextSlide=a-1,b.nextSlide<0&&(b.nextSlide=b.slides.length-1)):(b.nextSlide=a+1,b.nextSlide==b.slides.length&&(b.nextSlide=0))},calcNextSlide:function(){var a,b=this.opts();b.reverse?(a=b.nextSlide-1<0,b.nextSlide=a?b.slideCount-1:b.nextSlide-1,b.currSlide=a?0:b.nextSlide+1):(a=b.nextSlide+1==b.slides.length,b.nextSlide=a?0:b.nextSlide+1,b.currSlide=a?b.slides.length-1:b.nextSlide-1)},calcTx:function(b,c){var d,e=b;return e._tempFx?d=a.fn.cycle.transitions[e._tempFx]:c&&e.manualFx&&(d=a.fn.cycle.transitions[e.manualFx]),d||(d=a.fn.cycle.transitions[e.fx]),e._tempFx=null,this.opts()._tempFx=null,d||(d=a.fn.cycle.transitions.fade,e.API.log('Transition "'+e.fx+'" not found.  Using fade.')),d},prepareTx:function(a,b){var c,d,e,f,g,h=this.opts();return h.slideCount<2?void(h.timeoutId=0):(!a||h.busy&&!h.manualTrump||(h.API.stopTransition(),h.busy=!1,clearTimeout(h.timeoutId),h.timeoutId=0),void(h.busy||(0!==h.timeoutId||a)&&(d=h.slides[h.currSlide],e=h.slides[h.nextSlide],f=h.API.getSlideOpts(h.nextSlide),g=h.API.calcTx(f,a),h._tx=g,a&&void 0!==f.manualSpeed&&(f.speed=f.manualSpeed),h.nextSlide!=h.currSlide&&(a||!h.paused&&!h.hoverPaused&&h.timeout)?(h.API.trigger("cycle-before",[f,d,e,b]),g.before&&g.before(f,d,e,b),c=function(){h.busy=!1,h.container.data("cycle.opts")&&(g.after&&g.after(f,d,e,b),h.API.trigger("cycle-after",[f,d,e,b]),h.API.queueTransition(f),h.API.updateView(!0))},h.busy=!0,g.transition?g.transition(f,d,e,b,c):h.API.doTransition(f,d,e,b,c),h.API.calcNextSlide(),h.API.updateView()):h.API.queueTransition(f))))},doTransition:function(b,c,d,e,f){var g=b,h=a(c),i=a(d),j=function(){i.animate(g.animIn||{opacity:1},g.speed,g.easeIn||g.easing,f)};i.css(g.cssBefore||{}),h.animate(g.animOut||{},g.speed,g.easeOut||g.easing,function(){h.css(g.cssAfter||{}),g.sync||j()}),g.sync&&j()},queueTransition:function(b,c){var d=this.opts(),e=void 0!==c?c:b.timeout;return 0===d.nextSlide&&0===--d.loop?(d.API.log("terminating; loop=0"),d.timeout=0,e?setTimeout(function(){d.API.trigger("cycle-finished",[d])},e):d.API.trigger("cycle-finished",[d]),void(d.nextSlide=d.currSlide)):void 0!==d.continueAuto&&(d.continueAuto===!1||a.isFunction(d.continueAuto)&&d.continueAuto()===!1)?(d.API.log("terminating automatic transitions"),d.timeout=0,void(d.timeoutId&&clearTimeout(d.timeoutId))):void(e&&(d._lastQueue=a.now(),void 0===c&&(d._remainingTimeout=b.timeout),d.paused||d.hoverPaused||(d.timeoutId=setTimeout(function(){d.API.prepareTx(!1,!d.reverse)},e))))},stopTransition:function(){var a=this.opts();a.slides.filter(":animated").length&&(a.slides.stop(!1,!0),a.API.trigger("cycle-transition-stopped",[a])),a._tx&&a._tx.stopTransition&&a._tx.stopTransition(a)},advanceSlide:function(a){var b=this.opts();return clearTimeout(b.timeoutId),b.timeoutId=0,b.nextSlide=b.currSlide+a,b.nextSlide<0?b.nextSlide=b.slides.length-1:b.nextSlide>=b.slides.length&&(b.nextSlide=0),b.API.prepareTx(!0,a>=0),!1},buildSlideOpts:function(c){var d,e,f=this.opts(),g=c.data()||{};for(var h in g)g.hasOwnProperty(h)&&/^cycle[A-Z]+/.test(h)&&(d=g[h],e=h.match(/^cycle(.*)/)[1].replace(/^[A-Z]/,b),f.API.log("["+(f.slideCount-1)+"]",e+":",d,"("+typeof d+")"),g[e]=d);g=a.extend({},a.fn.cycle.defaults,f,g),g.slideNum=f.slideCount;try{delete g.API,delete g.slideCount,delete g.currSlide,delete g.nextSlide,delete g.slides}catch(i){}return g},getSlideOpts:function(b){var c=this.opts();void 0===b&&(b=c.currSlide);var d=c.slides[b],e=a(d).data("cycle.opts");return a.extend({},c,e)},initSlide:function(b,c,d){var e=this.opts();c.css(b.slideCss||{}),d>0&&c.css("zIndex",d),isNaN(b.speed)&&(b.speed=a.fx.speeds[b.speed]||a.fx.speeds._default),b.sync||(b.speed=b.speed/2),c.addClass(e.slideClass)},updateView:function(a,b){var c=this.opts();if(c._initialized){var d=c.API.getSlideOpts(),e=c.slides[c.currSlide];!a&&b!==!0&&(c.API.trigger("cycle-update-view-before",[c,d,e]),c.updateView<0)||(c.slideActiveClass&&c.slides.removeClass(c.slideActiveClass).eq(c.currSlide).addClass(c.slideActiveClass),a&&c.hideNonActive&&c.slides.filter(":not(."+c.slideActiveClass+")").css("visibility","hidden"),0===c.updateView&&setTimeout(function(){c.API.trigger("cycle-update-view",[c,d,e,a])},d.speed/(c.sync?2:1)),0!==c.updateView&&c.API.trigger("cycle-update-view",[c,d,e,a]),a&&c.API.trigger("cycle-update-view-after",[c,d,e]))}},getComponent:function(b){var c=this.opts(),d=c[b];return"string"==typeof d?/^\s*[\>|\+|~]/.test(d)?c.container.find(d):a(d):d.jquery?d:a(d)},stackSlides:function(b,c,d){var e=this.opts();b||(b=e.slides[e.currSlide],c=e.slides[e.nextSlide],d=!e.reverse),a(b).css("zIndex",e.maxZ);var f,g=e.maxZ-2,h=e.slideCount;if(d){for(f=e.currSlide+1;h>f;f++)a(e.slides[f]).css("zIndex",g--);for(f=0;f<e.currSlide;f++)a(e.slides[f]).css("zIndex",g--)}else{for(f=e.currSlide-1;f>=0;f--)a(e.slides[f]).css("zIndex",g--);for(f=h-1;f>e.currSlide;f--)a(e.slides[f]).css("zIndex",g--)}a(c).css("zIndex",e.maxZ-1)},getSlideIndex:function(a){return this.opts().slides.index(a)}},a.fn.cycle.log=function(){window.console&&console.log&&console.log("[cycle2] "+Array.prototype.join.call(arguments," "))},a.fn.cycle.version=function(){return"Cycle2: "+c},a.fn.cycle.transitions={custom:{},none:{before:function(a,b,c,d){a.API.stackSlides(c,b,d),a.cssBefore={opacity:1,visibility:"visible",display:"block"}}},fade:{before:function(b,c,d,e){var f=b.API.getSlideOpts(b.nextSlide).slideCss||{};b.API.stackSlides(c,d,e),b.cssBefore=a.extend(f,{opacity:0,visibility:"visible",display:"block"}),b.animIn={opacity:1},b.animOut={opacity:0}}},fadeout:{before:function(b,c,d,e){var f=b.API.getSlideOpts(b.nextSlide).slideCss||{};b.API.stackSlides(c,d,e),b.cssBefore=a.extend(f,{opacity:1,visibility:"visible",display:"block"}),b.animOut={opacity:0}}},scrollHorz:{before:function(a,b,c,d){a.API.stackSlides(b,c,d);var e=a.container.css("overflow","hidden").width();a.cssBefore={left:d?e:-e,top:0,opacity:1,visibility:"visible",display:"block"},a.cssAfter={zIndex:a._maxZ-2,left:0},a.animIn={left:0},a.animOut={left:d?-e:e}}}},a.fn.cycle.defaults={allowWrap:!0,autoSelector:".cycle-slideshow[data-cycle-auto-init!=false]",delay:0,easing:null,fx:"fade",hideNonActive:!0,loop:0,manualFx:void 0,manualSpeed:void 0,manualTrump:!0,maxZ:100,pauseOnHover:!1,reverse:!1,slideActiveClass:"cycle-slide-active",slideClass:"cycle-slide",slideCss:{position:"absolute",top:0,left:0},slides:"> img",speed:500,startingSlide:0,sync:!0,timeout:4e3,updateView:0},a(document).ready(function(){a(a.fn.cycle.defaults.autoSelector).cycle()})}(jQuery),/*! Cycle2 autoheight plugin; Copyright (c) M.Alsup, 2012; version: 20130913 */
function(a){"use strict";function b(b,d){var e,f,g,h=d.autoHeight;if("container"==h)f=a(d.slides[d.currSlide]).outerHeight(),d.container.height(f);else if(d._autoHeightRatio)d.container.height(d.container.width()/d._autoHeightRatio);else if("calc"===h||"number"==a.type(h)&&h>=0){if(g="calc"===h?c(b,d):h>=d.slides.length?0:h,g==d._sentinelIndex)return;d._sentinelIndex=g,d._sentinel&&d._sentinel.remove(),e=a(d.slides[g].cloneNode(!0)),e.removeAttr("id name rel").find("[id],[name],[rel]").removeAttr("id name rel"),e.css({position:"static",visibility:"hidden",display:"block"}).prependTo(d.container).addClass("cycle-sentinel cycle-slide").removeClass("cycle-slide-active"),e.find("*").css("visibility","hidden"),d._sentinel=e}}function c(b,c){var d=0,e=-1;return c.slides.each(function(b){var c=a(this).height();c>e&&(e=c,d=b)}),d}function d(b,c,d,e){var f=a(e).outerHeight();c.container.animate({height:f},c.autoHeightSpeed,c.autoHeightEasing)}function e(c,f){f._autoHeightOnResize&&(a(window).off("resize orientationchange",f._autoHeightOnResize),f._autoHeightOnResize=null),f.container.off("cycle-slide-added cycle-slide-removed",b),f.container.off("cycle-destroyed",e),f.container.off("cycle-before",d),f._sentinel&&(f._sentinel.remove(),f._sentinel=null)}a.extend(a.fn.cycle.defaults,{autoHeight:0,autoHeightSpeed:250,autoHeightEasing:null}),a(document).on("cycle-initialized",function(c,f){function g(){b(c,f)}var h,i=f.autoHeight,j=a.type(i),k=null;("string"===j||"number"===j)&&(f.container.on("cycle-slide-added cycle-slide-removed",b),f.container.on("cycle-destroyed",e),"container"==i?f.container.on("cycle-before",d):"string"===j&&/\d+\:\d+/.test(i)&&(h=i.match(/(\d+)\:(\d+)/),h=h[1]/h[2],f._autoHeightRatio=h),"number"!==j&&(f._autoHeightOnResize=function(){clearTimeout(k),k=setTimeout(g,50)},a(window).on("resize orientationchange",f._autoHeightOnResize)),setTimeout(g,30))})}(jQuery),/*! caption plugin for Cycle2;  version: 20130306 */
function(a){"use strict";a.extend(a.fn.cycle.defaults,{caption:"> .cycle-caption",captionTemplate:"{{slideNum}} / {{slideCount}}",overlay:"> .cycle-overlay",overlayTemplate:"<div>{{title}}</div><div>{{desc}}</div>",captionModule:"caption"}),a(document).on("cycle-update-view",function(b,c,d,e){if("caption"===c.captionModule){a.each(["caption","overlay"],function(){var a=this,b=d[a+"Template"],f=c.API.getComponent(a);f.length&&b?(f.html(c.API.tmpl(b,d,c,e)),f.show()):f.hide()})}}),a(document).on("cycle-destroyed",function(b,c){var d;a.each(["caption","overlay"],function(){var a=this,b=c[a+"Template"];c[a]&&b&&(d=c.API.getComponent("caption"),d.empty())})})}(jQuery),/*! command plugin for Cycle2;  version: 20140415 */
function(a){"use strict";var b=a.fn.cycle;a.fn.cycle=function(c){var d,e,f,g=a.makeArray(arguments);return"number"==a.type(c)?this.cycle("goto",c):"string"==a.type(c)?this.each(function(){var h;return d=c,f=a(this).data("cycle.opts"),void 0===f?void b.log('slideshow must be initialized before sending commands; "'+d+'" ignored'):(d="goto"==d?"jump":d,e=f.API[d],a.isFunction(e)?(h=a.makeArray(g),h.shift(),e.apply(f.API,h)):void b.log("unknown command: ",d))}):b.apply(this,arguments)},a.extend(a.fn.cycle,b),a.extend(b.API,{next:function(){var a=this.opts();if(!a.busy||a.manualTrump){var b=a.reverse?-1:1;a.allowWrap===!1&&a.currSlide+b>=a.slideCount||(a.API.advanceSlide(b),a.API.trigger("cycle-next",[a]).log("cycle-next"))}},prev:function(){var a=this.opts();if(!a.busy||a.manualTrump){var b=a.reverse?1:-1;a.allowWrap===!1&&a.currSlide+b<0||(a.API.advanceSlide(b),a.API.trigger("cycle-prev",[a]).log("cycle-prev"))}},destroy:function(){this.stop();var b=this.opts(),c=a.isFunction(a._data)?a._data:a.noop;clearTimeout(b.timeoutId),b.timeoutId=0,b.API.stop(),b.API.trigger("cycle-destroyed",[b]).log("cycle-destroyed"),b.container.removeData(),c(b.container[0],"parsedAttrs",!1),b.retainStylesOnDestroy||(b.container.removeAttr("style"),b.slides.removeAttr("style"),b.slides.removeClass(b.slideActiveClass)),b.slides.each(function(){var d=a(this);d.removeData(),d.removeClass(b.slideClass),c(this,"parsedAttrs",!1)})},jump:function(a,b){var c,d=this.opts();if(!d.busy||d.manualTrump){var e=parseInt(a,10);if(isNaN(e)||0>e||e>=d.slides.length)return void d.API.log("goto: invalid slide index: "+e);if(e==d.currSlide)return void d.API.log("goto: skipping, already on slide",e);d.nextSlide=e,clearTimeout(d.timeoutId),d.timeoutId=0,d.API.log("goto: ",e," (zero-index)"),c=d.currSlide<d.nextSlide,d._tempFx=b,d.API.prepareTx(!0,c)}},stop:function(){var b=this.opts(),c=b.container;clearTimeout(b.timeoutId),b.timeoutId=0,b.API.stopTransition(),b.pauseOnHover&&(b.pauseOnHover!==!0&&(c=a(b.pauseOnHover)),c.off("mouseenter mouseleave")),b.API.trigger("cycle-stopped",[b]).log("cycle-stopped")},reinit:function(){var a=this.opts();a.API.destroy(),a.container.cycle()},remove:function(b){for(var c,d,e=this.opts(),f=[],g=1,h=0;h<e.slides.length;h++)c=e.slides[h],h==b?d=c:(f.push(c),a(c).data("cycle.opts").slideNum=g,g++);d&&(e.slides=a(f),e.slideCount--,a(d).remove(),b==e.currSlide?e.API.advanceSlide(1):b<e.currSlide?e.currSlide--:e.currSlide++,e.API.trigger("cycle-slide-removed",[e,b,d]).log("cycle-slide-removed"),e.API.updateView())}}),a(document).on("click.cycle","[data-cycle-cmd]",function(b){b.preventDefault();var c=a(this),d=c.data("cycle-cmd"),e=c.data("cycle-context")||".cycle-slideshow";a(e).cycle(d,c.data("cycle-arg"))})}(jQuery),/*! hash plugin for Cycle2;  version: 20130905 */
function(a){"use strict";function b(b,c){var d;return b._hashFence?void(b._hashFence=!1):(d=window.location.hash.substring(1),void b.slides.each(function(e){if(a(this).data("cycle-hash")==d){if(c===!0)b.startingSlide=e;else{var f=b.currSlide<e;b.nextSlide=e,b.API.prepareTx(!0,f)}return!1}}))}a(document).on("cycle-pre-initialize",function(c,d){b(d,!0),d._onHashChange=function(){b(d,!1)},a(window).on("hashchange",d._onHashChange)}),a(document).on("cycle-update-view",function(a,b,c){c.hash&&"#"+c.hash!=window.location.hash&&(b._hashFence=!0,window.location.hash=c.hash)}),a(document).on("cycle-destroyed",function(b,c){c._onHashChange&&a(window).off("hashchange",c._onHashChange)})}(jQuery),/*! loader plugin for Cycle2;  version: 20131121 */
function(a){"use strict";a.extend(a.fn.cycle.defaults,{loader:!1}),a(document).on("cycle-bootstrap",function(b,c){function d(b,d){function f(b){var f;"wait"==c.loader?(h.push(b),0===j&&(h.sort(g),e.apply(c.API,[h,d]),c.container.removeClass("cycle-loading"))):(f=a(c.slides[c.currSlide]),e.apply(c.API,[b,d]),f.show(),c.container.removeClass("cycle-loading"))}function g(a,b){return a.data("index")-b.data("index")}var h=[];if("string"==a.type(b))b=a.trim(b);else if("array"===a.type(b))for(var i=0;i<b.length;i++)b[i]=a(b[i])[0];b=a(b);var j=b.length;j&&(b.css("visibility","hidden").appendTo("body").each(function(b){function g(){0===--i&&(--j,f(k))}var i=0,k=a(this),l=k.is("img")?k:k.find("img");return k.data("index",b),l=l.filter(":not(.cycle-loader-ignore)").filter(':not([src=""])'),l.length?(i=l.length,void l.each(function(){this.complete?g():a(this).load(function(){g()}).on("error",function(){0===--i&&(c.API.log("slide skipped; img not loaded:",this.src),0===--j&&"wait"==c.loader&&e.apply(c.API,[h,d]))})})):(--j,void h.push(k))}),j&&c.container.addClass("cycle-loading"))}var e;c.loader&&(e=c.API.add,c.API.add=d)})}(jQuery),/*! pager plugin for Cycle2;  version: 20140415 */
function(a){"use strict";function b(b,c,d){var e,f=b.API.getComponent("pager");f.each(function(){var f=a(this);if(c.pagerTemplate){var g=b.API.tmpl(c.pagerTemplate,c,b,d[0]);e=a(g).appendTo(f)}else e=f.children().eq(b.slideCount-1);e.on(b.pagerEvent,function(a){b.pagerEventBubble||a.preventDefault(),b.API.page(f,a.currentTarget)})})}function c(a,b){var c=this.opts();if(!c.busy||c.manualTrump){var d=a.children().index(b),e=d,f=c.currSlide<e;c.currSlide!=e&&(c.nextSlide=e,c._tempFx=c.pagerFx,c.API.prepareTx(!0,f),c.API.trigger("cycle-pager-activated",[c,a,b]))}}a.extend(a.fn.cycle.defaults,{pager:"> .cycle-pager",pagerActiveClass:"cycle-pager-active",pagerEvent:"click.cycle",pagerEventBubble:void 0,pagerTemplate:"<span>&bull;</span>"}),a(document).on("cycle-bootstrap",function(a,c,d){d.buildPagerLink=b}),a(document).on("cycle-slide-added",function(a,b,d,e){b.pager&&(b.API.buildPagerLink(b,d,e),b.API.page=c)}),a(document).on("cycle-slide-removed",function(b,c,d){if(c.pager){var e=c.API.getComponent("pager");e.each(function(){var b=a(this);a(b.children()[d]).remove()})}}),a(document).on("cycle-update-view",function(b,c){var d;c.pager&&(d=c.API.getComponent("pager"),d.each(function(){a(this).children().removeClass(c.pagerActiveClass).eq(c.currSlide).addClass(c.pagerActiveClass)}))}),a(document).on("cycle-destroyed",function(a,b){var c=b.API.getComponent("pager");c&&(c.children().off(b.pagerEvent),b.pagerTemplate&&c.empty())})}(jQuery),/*! prevnext plugin for Cycle2;  version: 20140408 */
function(a){"use strict";a.extend(a.fn.cycle.defaults,{next:"> .cycle-next",nextEvent:"click.cycle",disabledClass:"disabled",prev:"> .cycle-prev",prevEvent:"click.cycle",swipe:!1}),a(document).on("cycle-initialized",function(a,b){if(b.API.getComponent("next").on(b.nextEvent,function(a){a.preventDefault(),b.API.next()}),b.API.getComponent("prev").on(b.prevEvent,function(a){a.preventDefault(),b.API.prev()}),b.swipe){var c=b.swipeVert?"swipeUp.cycle":"swipeLeft.cycle swipeleft.cycle",d=b.swipeVert?"swipeDown.cycle":"swipeRight.cycle swiperight.cycle";b.container.on(c,function(){b._tempFx=b.swipeFx,b.API.next()}),b.container.on(d,function(){b._tempFx=b.swipeFx,b.API.prev()})}}),a(document).on("cycle-update-view",function(a,b){if(!b.allowWrap){var c=b.disabledClass,d=b.API.getComponent("next"),e=b.API.getComponent("prev"),f=b._prevBoundry||0,g=void 0!==b._nextBoundry?b._nextBoundry:b.slideCount-1;b.currSlide==g?d.addClass(c).prop("disabled",!0):d.removeClass(c).prop("disabled",!1),b.currSlide===f?e.addClass(c).prop("disabled",!0):e.removeClass(c).prop("disabled",!1)}}),a(document).on("cycle-destroyed",function(a,b){b.API.getComponent("prev").off(b.nextEvent),b.API.getComponent("next").off(b.prevEvent),b.container.off("swipeleft.cycle swiperight.cycle swipeLeft.cycle swipeRight.cycle swipeUp.cycle swipeDown.cycle")})}(jQuery),/*! progressive loader plugin for Cycle2;  version: 20130315 */
function(a){"use strict";a.extend(a.fn.cycle.defaults,{progressive:!1}),a(document).on("cycle-pre-initialize",function(b,c){if(c.progressive){var d,e,f=c.API,g=f.next,h=f.prev,i=f.prepareTx,j=a.type(c.progressive);if("array"==j)d=c.progressive;else if(a.isFunction(c.progressive))d=c.progressive(c);else if("string"==j){if(e=a(c.progressive),d=a.trim(e.html()),!d)return;if(/^(\[)/.test(d))try{d=a.parseJSON(d)}catch(k){return void f.log("error parsing progressive slides",k)}else d=d.split(new RegExp(e.data("cycle-split")||"\n")),d[d.length-1]||d.pop()}i&&(f.prepareTx=function(a,b){var e,f;return a||0===d.length?void i.apply(c.API,[a,b]):void(b&&c.currSlide==c.slideCount-1?(f=d[0],d=d.slice(1),c.container.one("cycle-slide-added",function(a,b){setTimeout(function(){b.API.advanceSlide(1)},50)}),c.API.add(f)):b||0!==c.currSlide?i.apply(c.API,[a,b]):(e=d.length-1,f=d[e],d=d.slice(0,e),c.container.one("cycle-slide-added",function(a,b){setTimeout(function(){b.currSlide=1,b.API.advanceSlide(-1)},50)}),c.API.add(f,!0)))}),g&&(f.next=function(){var a=this.opts();if(d.length&&a.currSlide==a.slideCount-1){var b=d[0];d=d.slice(1),a.container.one("cycle-slide-added",function(a,b){g.apply(b.API),b.container.removeClass("cycle-loading")}),a.container.addClass("cycle-loading"),a.API.add(b)}else g.apply(a.API)}),h&&(f.prev=function(){var a=this.opts();if(d.length&&0===a.currSlide){var b=d.length-1,c=d[b];d=d.slice(0,b),a.container.one("cycle-slide-added",function(a,b){b.currSlide=1,b.API.advanceSlide(-1),b.container.removeClass("cycle-loading")}),a.container.addClass("cycle-loading"),a.API.add(c,!0)}else h.apply(a.API)})}})}(jQuery),/*! tmpl plugin for Cycle2;  version: 20121227 */
function(a){"use strict";a.extend(a.fn.cycle.defaults,{tmplRegex:"{{((.)?.*?)}}"}),a.extend(a.fn.cycle.API,{tmpl:function(b,c){var d=new RegExp(c.tmplRegex||a.fn.cycle.defaults.tmplRegex,"g"),e=a.makeArray(arguments);return e.shift(),b.replace(d,function(b,c){var d,f,g,h,i=c.split(".");for(d=0;d<e.length;d++)if(g=e[d]){if(i.length>1)for(h=g,f=0;f<i.length;f++)g=h,h=h[i[f]]||c;else h=g[c];if(a.isFunction(h))return h.apply(g,e);if(void 0!==h&&null!==h&&h!=c)return h}return c})}})}(jQuery);
//# sourceMappingURL=jquery.cycle2.js.map;
/* Plugin for Cycle2; Copyright (c) 2012 M. Alsup; v20141007 */
!function(a){"use strict";a.extend(a.fn.cycle.defaults,{centerHorz:!1,centerVert:!1}),a(document).on("cycle-pre-initialize",function(b,c){function d(){clearTimeout(i),i=setTimeout(g,50)}function e(){clearTimeout(i),clearTimeout(j),a(window).off("resize orientationchange",d)}function f(){c.slides.each(h)}function g(){h.apply(c.container.find("."+c.slideActiveClass)),clearTimeout(j),j=setTimeout(f,50)}function h(){var b=a(this),d=c.container.width(),e=c.container.height(),f=b.outerWidth(),g=b.outerHeight();f&&(c.centerHorz&&d>=f&&b.css("marginLeft",(d-f)/2),c.centerVert&&e>=g&&b.css("marginTop",(e-g)/2))}if(c.centerHorz||c.centerVert){var i,j;a(window).on("resize orientationchange load",d),c.container.on("cycle-destroyed",e),c.container.on("cycle-initialized cycle-slide-added cycle-slide-removed",function(){d()}),g()}})}(jQuery);;
/* Plugin for Cycle2; Copyright (c) 2012 M. Alsup; v20140128 */
(function(e){"use strict";e.event.special.swipe=e.event.special.swipe||{scrollSupressionThreshold:10,durationThreshold:1e3,horizontalDistanceThreshold:30,verticalDistanceThreshold:75,setup:function(){var i=e(this);i.bind("touchstart",function(t){function n(i){if(r){var t=i.originalEvent.touches?i.originalEvent.touches[0]:i;s={time:(new Date).getTime(),coords:[t.pageX,t.pageY]},Math.abs(r.coords[0]-s.coords[0])>e.event.special.swipe.scrollSupressionThreshold&&i.preventDefault()}}var s,o=t.originalEvent.touches?t.originalEvent.touches[0]:t,r={time:(new Date).getTime(),coords:[o.pageX,o.pageY],origin:e(t.target)};i.bind("touchmove",n).one("touchend",function(){i.unbind("touchmove",n),r&&s&&s.time-r.time<e.event.special.swipe.durationThreshold&&Math.abs(r.coords[0]-s.coords[0])>e.event.special.swipe.horizontalDistanceThreshold&&Math.abs(r.coords[1]-s.coords[1])<e.event.special.swipe.verticalDistanceThreshold&&r.origin.trigger("swipe").trigger(r.coords[0]>s.coords[0]?"swipeleft":"swiperight"),r=s=void 0})})}},e.event.special.swipeleft=e.event.special.swipeleft||{setup:function(){e(this).bind("swipe",e.noop)}},e.event.special.swiperight=e.event.special.swiperight||e.event.special.swipeleft})(jQuery);;
(function($) {
  Drupal.behaviors.field_slideshow = {
    attach: function(context) {

      for (i in Drupal.settings.field_slideshow) {
        var settings = Drupal.settings.field_slideshow[i],
          slideshow = $('div.' + i),
          num_slides = slideshow.children().length,
          $this = false;

        if (!slideshow.hasClass('field-slideshow-processed') && slideshow.is(':visible')) {
          slideshow.addClass('field-slideshow-processed');

          // Add padding if needed
          var max_outerWidth = 0;
          var max_outerHeight = 0;
          $('.field-slideshow-slide img', slideshow).each(function() {
            $this = $(this);
            max_outerWidth = Math.max(max_outerWidth, $this.outerWidth(true));
            max_outerHeight = Math.max(max_outerHeight, $this.outerHeight(true));
          });
          $('.field-slideshow-slide a', slideshow).each(function() {
            $this = $(this);
            max_outerWidth = Math.max(max_outerWidth, $this.outerWidth(true));
            max_outerHeight = Math.max(max_outerHeight, $this.outerHeight(true));
          });
          $('.field-slideshow-slide', slideshow).each(function() {
            $this = $(this);
            max_outerWidth = Math.max(max_outerWidth, $this.outerWidth(true));
            max_outerHeight = Math.max(max_outerHeight, $this.outerHeight(true));
          });
          slideshow.css({
            //'padding-right': (max_outerWidth - parseInt(slideshow.css('width'))) + 'px',
            //'padding-bottom': (max_outerHeight - parseInt(slideshow.css('height'))) + 'px'
          });

          // Add options
          var options = {
            resizing: 0,
            fx: settings.fx,
            speed: settings.speed,
            timeout: parseInt(settings.timeout),
            index: i,
            settings: settings
          }
          if($('.full_carousel_pager').length > 0)
          	options.pager = '.full_carousel_pager';

          if (settings.speed == "0" && settings.timeout == "0") options.fastOnEvent = true;
          if (settings.controls) {
            options.prev = "#" + i + "-controls .prev";
            options.next = "#" + i + "-controls .next";
          }
          if (settings.pause) options.pause = true;

          if (settings.pager != '') {
            if (settings.pager == 'number' || settings.pager == 'image') options.pager = "#" + i + "-pager";
            if ((settings.pager == 'image' || settings.pager == 'carousel') && num_slides > 1) {
              options.pagerAnchorBuilder = function(idx, slide) {
                return '#' + i + '-pager li:eq(' + idx + ') a';
              };
              if (settings.pager == 'carousel') {
                var carouselops = {
                  visible: parseInt(settings.carousel_visible),
                  scroll: parseInt(settings.carousel_scroll),
                  animation: parseInt(settings.carousel_speed),
                  vertical: settings.carousel_vertical,
                  initCallback: function(carousel) {
                    $(".jcarousel-prev").addClass('carousel-prev');
                    $(".jcarousel-next").addClass('carousel-next');
                    if (carousel.options.visible && num_slides <= carousel.options.visible) {
                      // hide the carousel next and prev if all slide thumbs are displayed
                      $(".carousel-prev, .carousel-next", carousel.container.parent()).addClass("hidden");
                      return false;
                    }
                    $(".carousel-next", carousel.container.parent()).bind('click', function() {
                      carousel.next();
                      return false;
                    });
                    $(".carousel-prev", carousel.container.parent()).bind('click', function() {
                      carousel.prev();
                      return false;
                    });
                  }
                };
                if (!settings.carousel_skin) {
                  carouselops.buttonNextHTML = null;
                  carouselops.buttonPrevHTML = null;
                }
                if (parseInt(settings.carousel_circular)) carouselops.wrap = 'circular';

                $("#" + i + "-carousel").jcarousel(carouselops);
                // the pager is the direct item's parent element
                options.pager = "#" + i + "-carousel .field-slideshow-pager";
              }
            }
          }

          // Configure the cycle.before callback, it's called each time the slide change
          options.before = function(currSlideElement, nextSlideElement, options, forwardFlag) {
            // In this function we access the settins with options.settings
            // since the settings variable will be equal to the last slideshow settings
            // Acessing directly settings may cause issues if there are more than 1 slideshow

            // The options.nextSlide sometimes starts with 1 instead of 0, this is safer
            var nextIndex = $(nextSlideElement).index();

            // Add activeSlide manually for image pager
            if (options.settings.pager == 'image') {
              $('li', options.pager).removeClass("activeSlide");
              $('li:eq(' + nextIndex + ')', options.pager).addClass("activeSlide");
            }

            // If we are using the carousel make it follow the activeSlide
            // This will not work correctly with circular carousel until the version 0.3 of jcarousel
            // is released so we disble this until then
            if (options.settings.pager == 'carousel' && parseInt(options.settings.carousel_follow) && parseInt(options.settings.carousel_circular) == 0) {
              var carousel = $("#" + options.index + "-carousel").data("jcarousel");
              carousel.scroll(nextIndex, true);
            }
          }

          if (num_slides > 1) {

//        	console.log(options);
        	if (options.settings.pagerEvent == 'mouseover' ) {
        		options.pagerEvent = "mouseover";
        	}
        	
        	slideshow.on( 'cycle-post-initialize', function( event, opts ) {
            $(this).addClass("cycle-init");
            console.log("doine");
        	});
        	
        	options.width = 'fit';
        	var initCycle = function () {
        	  if (!slideshow.find("img").first()[0].complete) {
        	    setTimeout(function() {
                initCycle();
              }, 1000 );
              return ;
        	  }

        	  $("." + i).data("slideshow", slideshow);
        	  $("." + i).hover(function(e) {
        		  var is_focused = $('.field-slideshow-lp-gallery').find('.form-item').find('input').is(':focus');
        		  if(is_focused){
        			  e.preventDefault();
        			  var target_slideshow = $(this).data("slideshow");
        	          target_slideshow.cycle("pause");
        		  }/*else{
        			  e.preventDefault();
        	    	  var target_slideshow = $(this).data("slideshow");
        	    	  target_slideshow.cycle("resume");
        		  }*/
        	  });  
        	  
            if (settings.start_on_hover) {
                //If start_on_hover is set, stop cycling onload, and only activate
                //on hover
                slideshow.cycle(options).cycle("pause").hover(function() {
                  $(this).cycle('resume');
                },function(){
                  $(this).cycle('pause');
                });
              }
              else {
                // Cycle!
                slideshow.cycle(options);
              }
  
              // After the numeric pager has been built by Cycle, add some classes for theming
              if (settings.pager == 'number') {
                $('.field-slideshow-pager a').each(function(){
                  $this = $(this);
                  $this.addClass('slide-' + $this.html());
                });
              }
              // Keep a reference to the slideshow in the buttons since the slideshow variable
              // becomes invalid if there are multiple slideshows (equal to the last slideshow)
              $("#" + i + "-controls .play, #" + i + "-controls .pause").data("slideshow", slideshow);
              // if the play/pause button is enabled link the events
              $("#" + i + "-controls .play").click(function(e) {
                e.preventDefault();
                var target_slideshow = $(this).data("slideshow");
                target_slideshow.cycle("resume", true);
                $(this).hide();
                $(this).parent().find(".pause").show();
              });
              $("#" + i + "-controls .pause").click(function(e) {
                e.preventDefault();
                var target_slideshow = $(this).data("slideshow");
                target_slideshow.cycle("pause");
                $(this).hide();
                $(this).parent().find(".play").show();
              });
              
              
            }//end function initCycle
        	  
        	initCycle();
        	
          }

        }

      }

      // Recalculate height for responsive layouts
      var rebuild_max_height = function(context) {
        return ;
        var max_height = 0;
        var heights = $('.field-slideshow-slide',context).map(function ()
        {
          return $(this).height();
        }).get(),
        max_height = Math.max.apply(Math, heights);
        if (max_height > 0) {
          context.css("height", max_height);
          context.find('.field-slideshow-processed').css("height", max_height);
        }
      };

      if (jQuery.isFunction($.fn.imagesLoaded)) {
        $('.field-slideshow').each(function() {
          $('img',this).imagesLoaded(function($images) {
            rebuild_max_height($images.parents('.field-slideshow'));
          });
        });
      }
      else {
        $(window).load(function(){
          $('.field-slideshow').each(function(){
            rebuild_max_height($(this))
          })
        });

      }
      $('.field-slideshow-processed, .field-slideshow, .testimonial-items').on('cycle-before', function(event, optionHash, outgoingSlideEl, incomingSlideEl, forwardFlag) {
          $("[data-echo]", $(incomingSlideEl).parent()).each(function() {
          var elem = this;
          if (elem.src !== (src = elem.getAttribute('data-echo'))) {
            elem.src = src;
            $(elem).parent().find('.lazyloader-icon').remove();
          }
        });
      });
      $(window).resize(function(){
        $('.field-slideshow').each(function(){
          rebuild_max_height($(this))
        })
      });

    }
  }
})(jQuery);
;
(function(g){g.Zebra_Tooltips=function(k,p){var q={animation_speed:250,animation_offset:20,background_color:"#000",close_on_click:!0,color:"#FFF",content:!1,hide_delay:100,keep_visible:!0,max_width:250,opacity:"1",position:"center",prerender:!1,show_delay:100,vertical_offset:0,onBeforeHide:null,onHide:null,onBeforeShow:null,onShow:null},b=this,l,h,t;b.settings={};b.hide=function(c,a){var b=c.data("Zebra_Tooltip");b&&(b.sticky=!1,a&&(b.destroy=!0),c.data("Zebra_Tooltip",b),m(c))};b.show=function(b, a){var d=b.data("Zebra_Tooltip");d&&(d.sticky=!0,d.muted=!1,a&&(d.destroy=!0),b.data("Zebra_Tooltip",d),r(b))};var n=function(c){var a=c.data("Zebra_Tooltip");if(!a.tooltip){var d=jQuery("<div>",{"class":"Zebra_Tooltip",css:{opacity:0,display:"block"}}),f=jQuery("<div>",{"class":"Zebra_Tooltip_Message",css:{"max-width":b.settings.max_width,"background-color":b.settings.background_color,color:b.settings.color}}).html(b.settings.content?b.settings.content:a.content).appendTo(d),a=jQuery("<div>",{"class":"Zebra_Tooltip_Arrow"}).appendTo(d), s=jQuery("<div>").appendTo(a);b.settings.keep_visible&&(d.bind("mouseleave"+(b.settings.close_on_click?" click":""),function(){m(c)}),d.bind("mouseenter",function(){r(c)}));d.appendTo("body");var k=d.outerWidth(),n=d.outerHeight(),p=s.outerWidth(),u=s.outerHeight(),e=f.outerWidth(),q=f.outerHeight(),a={tooltip:d,tooltip_width:k,tooltip_height:n+u/2,message:f,arrow_container:a,arrow_width:p,arrow_height:u,arrow:s};d.css({width:a.tooltip_width,height:a.tooltip_height});a.tooltip_width+=f.outerWidth()- e;a.tooltip_height+=f.outerHeight()-q;d.css({width:a.tooltip_width,height:a.tooltip_height,display:"none"});a=g.extend(c.data("Zebra_Tooltip"),a);c.data("Zebra_Tooltip",a)}a.sticky&&!a.close&&(jQuery("<a>",{"class":"Zebra_Tooltip_Close",href:"javascript:void(0)"}).html("x").bind("click",function(a){a.preventDefault();a=c.data("Zebra_Tooltip");a.sticky=!1;c.data("Zebra_Tooltip",a);m(c)}).appendTo(a.message),a.close=!0,a=g.extend(c.data("Zebra_Tooltip"),a),c.data("Zebra_Tooltip",a));if(a.window_resized|| a.window_scrolled)d=g(window),a.window_resized&&(l=d.width(),d.height(),f=c.offset(),g.extend(a,{element_left:f.left,element_top:f.top,element_width:c.outerWidth(),element_height:c.outerHeight()})),t=d.scrollTop(),h=d.scrollLeft(),d="left"==b.settings.position?a.element_left-a.tooltip_width+a.arrow_width:"right"==b.settings.position?a.element_left+a.element_width-a.arrow_width:a.element_left+(a.element_width-a.tooltip_width)/2,f=a.element_top-a.tooltip_height,e="left"==b.settings.position?a.tooltip_width- a.arrow_width-a.arrow_width/2:"right"==b.settings.position?a.arrow_width/2:(a.tooltip_width-a.arrow_width)/2,d+a.tooltip_width>l+h&&(e-=l+h-(d+a.tooltip_width)-6,d=l+h-a.tooltip_width-6,e+a.arrow_width>a.tooltip_width-6&&(e=a.tooltip_width-6-a.arrow_width),d+e+a.arrow_width/2<a.element_left&&(e=-1E4)),d<h&&(e-=h-d,d=h+2,0>e&&(e=a.arrow_width/2),d+e+a.arrow_width/2>a.element_left+a.element_width&&(e=-1E4)),a.arrow_container.removeClass("Zebra_Tooltip_Arrow_Top"),a.arrow_container.addClass("Zebra_Tooltip_Arrow_Bottom"), a.message.css("margin-top",""),a.arrow.css("borderColor",b.settings.background_color+" transparent transparent"),f<t?(f=a.element_top+a.element_height-b.settings.vertical_offset,a.animation_offset=Math.abs(a.animation_offset),a.message.css("margin-top",a.arrow_height/2),a.arrow_container.removeClass("Zebra_Tooltip_Arrow_Bottom"),a.arrow_container.addClass("Zebra_Tooltip_Arrow_Top"),a.arrow.css("borderColor","transparent transparent "+b.settings.background_color)):(a.animation_offset=-Math.abs(a.animation_offset), f+=b.settings.vertical_offset),a.arrow_container.css("left",e),a.tooltip.css({left:d,top:f}),g.extend(a,{tooltip_left:d,tooltip_top:f,arrow_left:e}),a.window_resized=!1,a.window_scrolled=!1,a=g.extend(c.data("Zebra_Tooltip"),a),c.data("Zebra_Tooltip",a);return a},m=function(c){var a=c.data("Zebra_Tooltip");clearTimeout(a.hide_timeout);a.sticky||(clearTimeout(a.show_timeout),a.hide_timeout=setTimeout(function(){if(a.tooltip){if(b.settings.onBeforeHide&&"function"==typeof b.settings.onBeforeHide)b.settings.onBeforeHide(c); a.close=!1;a.destroy&&(a.muted=!0);c.data("Zebra_Tooltip",a);g("a.Zebra_Tooltip_Close",a.tooltip).remove();a.tooltip.stop();a.tooltip.animate({opacity:0,top:a.tooltip_top+a.animation_offset},b.settings.animation_speed,function(){g(this).css("display","none");if(b.settings.onHide&&"function"==typeof b.settings.onHide)b.settings.onHide(c)})}},b.settings.hide_delay))},r=function(c){var a=c.data("Zebra_Tooltip");clearTimeout(a.show_timeout);a.muted||(clearTimeout(a.hide_timeout),a.show_timeout=setTimeout(function(){a= n(c);if(b.settings.onBeforeShow&&"function"==typeof b.settings.onBeforeShow)b.settings.onBeforeShow(c);"block"!=a.tooltip.css("display")&&a.tooltip.css({top:a.tooltip_top+a.animation_offset});a.tooltip.css("display","block");a.tooltip.stop();a.tooltip.animate({top:a.tooltip_top,opacity:b.settings.opacity},b.settings.animation_speed,function(){if(b.settings.onShow&&"function"==typeof b.settings.onShow)b.settings.onShow(c)})},b.settings.show_delay))};(function(){b.settings=g.extend({},q,p);k.each(function(){var c= g(this);c.bind({mouseenter:function(){r(c)},mouseleave:function(){m(c)}});c.data("Zebra_Tooltip",{tooltip:null,content:c.attr("title")||"",window_resized:!0,window_scrolled:!0,show_timeout:null,hide_timeout:null,animation_offset:b.settings.animation_offset,sticky:!1,destroy:!1,muted:!1});c.attr("title","");b.settings.prerender&&n(c)});g(window).bind("scroll resize",function(b){k.each(function(){var a=g(this).data("Zebra_Tooltip");"scroll"==b.type?a.window_scrolled=!0:a.window_resized=!0;g(this).data("Zebra_Tooltip", a)})})})()}})(jQuery);;
//     Underscore.js 1.5.1
//     http://underscorejs.org
//     (c) 2009-2013 Jeremy Ashkenas, DocumentCloud and Investigative Reporters & Editors
//     Underscore may be freely distributed under the MIT license.
!function(){var n=this,t=n._,r={},e=Array.prototype,u=Object.prototype,i=Function.prototype,a=e.push,o=e.slice,c=e.concat,l=u.toString,f=u.hasOwnProperty,s=e.forEach,p=e.map,v=e.reduce,h=e.reduceRight,d=e.filter,g=e.every,m=e.some,y=e.indexOf,b=e.lastIndexOf,x=Array.isArray,_=Object.keys,w=i.bind,j=function(n){return n instanceof j?n:this instanceof j?(this._wrapped=n,void 0):new j(n)};"undefined"!=typeof exports?("undefined"!=typeof module&&module.exports&&(exports=module.exports=j),exports._=j):n._=j,j.VERSION="1.5.1";var A=j.each=j.forEach=function(n,t,e){if(null!=n)if(s&&n.forEach===s)n.forEach(t,e);else if(n.length===+n.length){for(var u=0,i=n.length;i>u;u++)if(t.call(e,n[u],u,n)===r)return}else for(var a in n)if(j.has(n,a)&&t.call(e,n[a],a,n)===r)return};j.map=j.collect=function(n,t,r){var e=[];return null==n?e:p&&n.map===p?n.map(t,r):(A(n,function(n,u,i){e.push(t.call(r,n,u,i))}),e)};var E="Reduce of empty array with no initial value";j.reduce=j.foldl=j.inject=function(n,t,r,e){var u=arguments.length>2;if(null==n&&(n=[]),v&&n.reduce===v)return e&&(t=j.bind(t,e)),u?n.reduce(t,r):n.reduce(t);if(A(n,function(n,i,a){u?r=t.call(e,r,n,i,a):(r=n,u=!0)}),!u)throw new TypeError(E);return r},j.reduceRight=j.foldr=function(n,t,r,e){var u=arguments.length>2;if(null==n&&(n=[]),h&&n.reduceRight===h)return e&&(t=j.bind(t,e)),u?n.reduceRight(t,r):n.reduceRight(t);var i=n.length;if(i!==+i){var a=j.keys(n);i=a.length}if(A(n,function(o,c,l){c=a?a[--i]:--i,u?r=t.call(e,r,n[c],c,l):(r=n[c],u=!0)}),!u)throw new TypeError(E);return r},j.find=j.detect=function(n,t,r){var e;return O(n,function(n,u,i){return t.call(r,n,u,i)?(e=n,!0):void 0}),e},j.filter=j.select=function(n,t,r){var e=[];return null==n?e:d&&n.filter===d?n.filter(t,r):(A(n,function(n,u,i){t.call(r,n,u,i)&&e.push(n)}),e)},j.reject=function(n,t,r){return j.filter(n,function(n,e,u){return!t.call(r,n,e,u)},r)},j.every=j.all=function(n,t,e){t||(t=j.identity);var u=!0;return null==n?u:g&&n.every===g?n.every(t,e):(A(n,function(n,i,a){return(u=u&&t.call(e,n,i,a))?void 0:r}),!!u)};var O=j.some=j.any=function(n,t,e){t||(t=j.identity);var u=!1;return null==n?u:m&&n.some===m?n.some(t,e):(A(n,function(n,i,a){return u||(u=t.call(e,n,i,a))?r:void 0}),!!u)};j.contains=j.include=function(n,t){return null==n?!1:y&&n.indexOf===y?n.indexOf(t)!=-1:O(n,function(n){return n===t})},j.invoke=function(n,t){var r=o.call(arguments,2),e=j.isFunction(t);return j.map(n,function(n){return(e?t:n[t]).apply(n,r)})},j.pluck=function(n,t){return j.map(n,function(n){return n[t]})},j.where=function(n,t,r){return j.isEmpty(t)?r?void 0:[]:j[r?"find":"filter"](n,function(n){for(var r in t)if(t[r]!==n[r])return!1;return!0})},j.findWhere=function(n,t){return j.where(n,t,!0)},j.max=function(n,t,r){if(!t&&j.isArray(n)&&n[0]===+n[0]&&n.length<65535)return Math.max.apply(Math,n);if(!t&&j.isEmpty(n))return-1/0;var e={computed:-1/0,value:-1/0};return A(n,function(n,u,i){var a=t?t.call(r,n,u,i):n;a>e.computed&&(e={value:n,computed:a})}),e.value},j.min=function(n,t,r){if(!t&&j.isArray(n)&&n[0]===+n[0]&&n.length<65535)return Math.min.apply(Math,n);if(!t&&j.isEmpty(n))return 1/0;var e={computed:1/0,value:1/0};return A(n,function(n,u,i){var a=t?t.call(r,n,u,i):n;a<e.computed&&(e={value:n,computed:a})}),e.value},j.shuffle=function(n){var t,r=0,e=[];return A(n,function(n){t=j.random(r++),e[r-1]=e[t],e[t]=n}),e};var F=function(n){return j.isFunction(n)?n:function(t){return t[n]}};j.sortBy=function(n,t,r){var e=F(t);return j.pluck(j.map(n,function(n,t,u){return{value:n,index:t,criteria:e.call(r,n,t,u)}}).sort(function(n,t){var r=n.criteria,e=t.criteria;if(r!==e){if(r>e||r===void 0)return 1;if(e>r||e===void 0)return-1}return n.index<t.index?-1:1}),"value")};var k=function(n,t,r,e){var u={},i=F(null==t?j.identity:t);return A(n,function(t,a){var o=i.call(r,t,a,n);e(u,o,t)}),u};j.groupBy=function(n,t,r){return k(n,t,r,function(n,t,r){(j.has(n,t)?n[t]:n[t]=[]).push(r)})},j.countBy=function(n,t,r){return k(n,t,r,function(n,t){j.has(n,t)||(n[t]=0),n[t]++})},j.sortedIndex=function(n,t,r,e){r=null==r?j.identity:F(r);for(var u=r.call(e,t),i=0,a=n.length;a>i;){var o=i+a>>>1;r.call(e,n[o])<u?i=o+1:a=o}return i},j.toArray=function(n){return n?j.isArray(n)?o.call(n):n.length===+n.length?j.map(n,j.identity):j.values(n):[]},j.size=function(n){return null==n?0:n.length===+n.length?n.length:j.keys(n).length},j.first=j.head=j.take=function(n,t,r){return null==n?void 0:null==t||r?n[0]:o.call(n,0,t)},j.initial=function(n,t,r){return o.call(n,0,n.length-(null==t||r?1:t))},j.last=function(n,t,r){return null==n?void 0:null==t||r?n[n.length-1]:o.call(n,Math.max(n.length-t,0))},j.rest=j.tail=j.drop=function(n,t,r){return o.call(n,null==t||r?1:t)},j.compact=function(n){return j.filter(n,j.identity)};var R=function(n,t,r){return t&&j.every(n,j.isArray)?c.apply(r,n):(A(n,function(n){j.isArray(n)||j.isArguments(n)?t?a.apply(r,n):R(n,t,r):r.push(n)}),r)};j.flatten=function(n,t){return R(n,t,[])},j.without=function(n){return j.difference(n,o.call(arguments,1))},j.uniq=j.unique=function(n,t,r,e){j.isFunction(t)&&(e=r,r=t,t=!1);var u=r?j.map(n,r,e):n,i=[],a=[];return A(u,function(r,e){(t?e&&a[a.length-1]===r:j.contains(a,r))||(a.push(r),i.push(n[e]))}),i},j.union=function(){return j.uniq(j.flatten(arguments,!0))},j.intersection=function(n){var t=o.call(arguments,1);return j.filter(j.uniq(n),function(n){return j.every(t,function(t){return j.indexOf(t,n)>=0})})},j.difference=function(n){var t=c.apply(e,o.call(arguments,1));return j.filter(n,function(n){return!j.contains(t,n)})},j.zip=function(){for(var n=j.max(j.pluck(arguments,"length").concat(0)),t=new Array(n),r=0;n>r;r++)t[r]=j.pluck(arguments,""+r);return t},j.object=function(n,t){if(null==n)return{};for(var r={},e=0,u=n.length;u>e;e++)t?r[n[e]]=t[e]:r[n[e][0]]=n[e][1];return r},j.indexOf=function(n,t,r){if(null==n)return-1;var e=0,u=n.length;if(r){if("number"!=typeof r)return e=j.sortedIndex(n,t),n[e]===t?e:-1;e=0>r?Math.max(0,u+r):r}if(y&&n.indexOf===y)return n.indexOf(t,r);for(;u>e;e++)if(n[e]===t)return e;return-1},j.lastIndexOf=function(n,t,r){if(null==n)return-1;var e=null!=r;if(b&&n.lastIndexOf===b)return e?n.lastIndexOf(t,r):n.lastIndexOf(t);for(var u=e?r:n.length;u--;)if(n[u]===t)return u;return-1},j.range=function(n,t,r){arguments.length<=1&&(t=n||0,n=0),r=arguments[2]||1;for(var e=Math.max(Math.ceil((t-n)/r),0),u=0,i=new Array(e);e>u;)i[u++]=n,n+=r;return i};var M=function(){};j.bind=function(n,t){var r,e;if(w&&n.bind===w)return w.apply(n,o.call(arguments,1));if(!j.isFunction(n))throw new TypeError;return r=o.call(arguments,2),e=function(){if(!(this instanceof e))return n.apply(t,r.concat(o.call(arguments)));M.prototype=n.prototype;var u=new M;M.prototype=null;var i=n.apply(u,r.concat(o.call(arguments)));return Object(i)===i?i:u}},j.partial=function(n){var t=o.call(arguments,1);return function(){return n.apply(this,t.concat(o.call(arguments)))}},j.bindAll=function(n){var t=o.call(arguments,1);if(0===t.length)throw new Error("bindAll must be passed function names");return A(t,function(t){n[t]=j.bind(n[t],n)}),n},j.memoize=function(n,t){var r={};return t||(t=j.identity),function(){var e=t.apply(this,arguments);return j.has(r,e)?r[e]:r[e]=n.apply(this,arguments)}},j.delay=function(n,t){var r=o.call(arguments,2);return setTimeout(function(){return n.apply(null,r)},t)},j.defer=function(n){return j.delay.apply(j,[n,1].concat(o.call(arguments,1)))},j.throttle=function(n,t,r){var e,u,i,a=null,o=0;r||(r={});var c=function(){o=r.leading===!1?0:new Date,a=null,i=n.apply(e,u)};return function(){var l=new Date;o||r.leading!==!1||(o=l);var f=t-(l-o);return e=this,u=arguments,0>=f?(clearTimeout(a),a=null,o=l,i=n.apply(e,u)):a||r.trailing===!1||(a=setTimeout(c,f)),i}},j.debounce=function(n,t,r){var e,u=null;return function(){var i=this,a=arguments,o=function(){u=null,r||(e=n.apply(i,a))},c=r&&!u;return clearTimeout(u),u=setTimeout(o,t),c&&(e=n.apply(i,a)),e}},j.once=function(n){var t,r=!1;return function(){return r?t:(r=!0,t=n.apply(this,arguments),n=null,t)}},j.wrap=function(n,t){return function(){var r=[n];return a.apply(r,arguments),t.apply(this,r)}},j.compose=function(){var n=arguments;return function(){for(var t=arguments,r=n.length-1;r>=0;r--)t=[n[r].apply(this,t)];return t[0]}},j.after=function(n,t){return function(){return--n<1?t.apply(this,arguments):void 0}},j.keys=_||function(n){if(n!==Object(n))throw new TypeError("Invalid object");var t=[];for(var r in n)j.has(n,r)&&t.push(r);return t},j.values=function(n){var t=[];for(var r in n)j.has(n,r)&&t.push(n[r]);return t},j.pairs=function(n){var t=[];for(var r in n)j.has(n,r)&&t.push([r,n[r]]);return t},j.invert=function(n){var t={};for(var r in n)j.has(n,r)&&(t[n[r]]=r);return t},j.functions=j.methods=function(n){var t=[];for(var r in n)j.isFunction(n[r])&&t.push(r);return t.sort()},j.extend=function(n){return A(o.call(arguments,1),function(t){if(t)for(var r in t)n[r]=t[r]}),n},j.pick=function(n){var t={},r=c.apply(e,o.call(arguments,1));return A(r,function(r){r in n&&(t[r]=n[r])}),t},j.omit=function(n){var t={},r=c.apply(e,o.call(arguments,1));for(var u in n)j.contains(r,u)||(t[u]=n[u]);return t},j.defaults=function(n){return A(o.call(arguments,1),function(t){if(t)for(var r in t)n[r]===void 0&&(n[r]=t[r])}),n},j.clone=function(n){return j.isObject(n)?j.isArray(n)?n.slice():j.extend({},n):n},j.tap=function(n,t){return t(n),n};var S=function(n,t,r,e){if(n===t)return 0!==n||1/n==1/t;if(null==n||null==t)return n===t;n instanceof j&&(n=n._wrapped),t instanceof j&&(t=t._wrapped);var u=l.call(n);if(u!=l.call(t))return!1;switch(u){case"[object String]":return n==String(t);case"[object Number]":return n!=+n?t!=+t:0==n?1/n==1/t:n==+t;case"[object Date]":case"[object Boolean]":return+n==+t;case"[object RegExp]":return n.source==t.source&&n.global==t.global&&n.multiline==t.multiline&&n.ignoreCase==t.ignoreCase}if("object"!=typeof n||"object"!=typeof t)return!1;for(var i=r.length;i--;)if(r[i]==n)return e[i]==t;var a=n.constructor,o=t.constructor;if(a!==o&&!(j.isFunction(a)&&a instanceof a&&j.isFunction(o)&&o instanceof o))return!1;r.push(n),e.push(t);var c=0,f=!0;if("[object Array]"==u){if(c=n.length,f=c==t.length)for(;c--&&(f=S(n[c],t[c],r,e)););}else{for(var s in n)if(j.has(n,s)&&(c++,!(f=j.has(t,s)&&S(n[s],t[s],r,e))))break;if(f){for(s in t)if(j.has(t,s)&&!c--)break;f=!c}}return r.pop(),e.pop(),f};j.isEqual=function(n,t){return S(n,t,[],[])},j.isEmpty=function(n){if(null==n)return!0;if(j.isArray(n)||j.isString(n))return 0===n.length;for(var t in n)if(j.has(n,t))return!1;return!0},j.isElement=function(n){return!(!n||1!==n.nodeType)},j.isArray=x||function(n){return"[object Array]"==l.call(n)},j.isObject=function(n){return n===Object(n)},A(["Arguments","Function","String","Number","Date","RegExp"],function(n){j["is"+n]=function(t){return l.call(t)=="[object "+n+"]"}}),j.isArguments(arguments)||(j.isArguments=function(n){return!(!n||!j.has(n,"callee"))}),"function"!=typeof/./&&(j.isFunction=function(n){return"function"==typeof n}),j.isFinite=function(n){return isFinite(n)&&!isNaN(parseFloat(n))},j.isNaN=function(n){return j.isNumber(n)&&n!=+n},j.isBoolean=function(n){return n===!0||n===!1||"[object Boolean]"==l.call(n)},j.isNull=function(n){return null===n},j.isUndefined=function(n){return n===void 0},j.has=function(n,t){return f.call(n,t)},j.noConflict=function(){return n._=t,this},j.identity=function(n){return n},j.times=function(n,t,r){for(var e=Array(Math.max(0,n)),u=0;n>u;u++)e[u]=t.call(r,u);return e},j.random=function(n,t){return null==t&&(t=n,n=0),n+Math.floor(Math.random()*(t-n+1))};var I={escape:{"&":"&amp;","<":"&lt;",">":"&gt;",'"':"&quot;","'":"&#x27;","/":"&#x2F;"}};I.unescape=j.invert(I.escape);var T={escape:new RegExp("["+j.keys(I.escape).join("")+"]","g"),unescape:new RegExp("("+j.keys(I.unescape).join("|")+")","g")};j.each(["escape","unescape"],function(n){j[n]=function(t){return null==t?"":(""+t).replace(T[n],function(t){return I[n][t]})}}),j.result=function(n,t){if(null==n)return void 0;var r=n[t];return j.isFunction(r)?r.call(n):r},j.mixin=function(n){A(j.functions(n),function(t){var r=j[t]=n[t];j.prototype[t]=function(){var n=[this._wrapped];return a.apply(n,arguments),z.call(this,r.apply(j,n))}})};var N=0;j.uniqueId=function(n){var t=++N+"";return n?n+t:t},j.templateSettings={evaluate:/<%([\s\S]+?)%>/g,interpolate:/<%=([\s\S]+?)%>/g,escape:/<%-([\s\S]+?)%>/g};var q=/(.)^/,B={"'":"'","\\":"\\","\r":"r","\n":"n","	":"t","\u2028":"u2028","\u2029":"u2029"},D=/\\|'|\r|\n|\t|\u2028|\u2029/g;j.template=function(n,t,r){var e;r=j.defaults({},r,j.templateSettings);var u=new RegExp([(r.escape||q).source,(r.interpolate||q).source,(r.evaluate||q).source].join("|")+"|$","g"),i=0,a="__p+='";n.replace(u,function(t,r,e,u,o){return a+=n.slice(i,o).replace(D,function(n){return"\\"+B[n]}),r&&(a+="'+\n((__t=("+r+"))==null?'':_.escape(__t))+\n'"),e&&(a+="'+\n((__t=("+e+"))==null?'':__t)+\n'"),u&&(a+="';\n"+u+"\n__p+='"),i=o+t.length,t}),a+="';\n",r.variable||(a="with(obj||{}){\n"+a+"}\n"),a="var __t,__p='',__j=Array.prototype.join,"+"print=function(){__p+=__j.call(arguments,'');};\n"+a+"return __p;\n";try{e=new Function(r.variable||"obj","_",a)}catch(o){throw o.source=a,o}if(t)return e(t,j);var c=function(n){return e.call(this,n,j)};return c.source="function("+(r.variable||"obj")+"){\n"+a+"}",c},j.chain=function(n){return j(n).chain()};var z=function(n){return this._chain?j(n).chain():n};j.mixin(j),A(["pop","push","reverse","shift","sort","splice","unshift"],function(n){var t=e[n];j.prototype[n]=function(){var r=this._wrapped;return t.apply(r,arguments),"shift"!=n&&"splice"!=n||0!==r.length||delete r[0],z.call(this,r)}}),A(["concat","join","slice"],function(n){var t=e[n];j.prototype[n]=function(){return z.call(this,t.apply(this._wrapped,arguments))}}),j.extend(j.prototype,{chain:function(){return this._chain=!0,this},value:function(){return this._wrapped}})}.call(this);
//# sourceMappingURL=underscore-min.map;
/**
 * Copyright (c) 2007-2012 Ariel Flesler - aflesler(at)gmail(dot)com | http://flesler.blogspot.com
 * Dual licensed under MIT and GPL.
 * @author Ariel Flesler
 * @version 1.4.3.1
 */
;(function($){var h=$.scrollTo=function(a,b,c){$(window).scrollTo(a,b,c)};h.defaults={axis:'xy',duration:parseFloat($.fn.jquery)>=1.3?0:1,limit:true};h.window=function(a){return $(window)._scrollable()};$.fn._scrollable=function(){return this.map(function(){var a=this,isWin=!a.nodeName||$.inArray(a.nodeName.toLowerCase(),['iframe','#document','html','body'])!=-1;if(!isWin)return a;var b=(a.contentWindow||a).document||a.ownerDocument||a;return/webkit/i.test(navigator.userAgent)||b.compatMode=='BackCompat'?b.body:b.documentElement})};$.fn.scrollTo=function(e,f,g){if(typeof f=='object'){g=f;f=0}if(typeof g=='function')g={onAfter:g};if(e=='max')e=9e9;g=$.extend({},h.defaults,g);f=f||g.duration;g.queue=g.queue&&g.axis.length>1;if(g.queue)f/=2;g.offset=both(g.offset);g.over=both(g.over);return this._scrollable().each(function(){if(e==null)return;var d=this,$elem=$(d),targ=e,toff,attr={},win=$elem.is('html,body');switch(typeof targ){case'number':case'string':if(/^([+-]=)?\d+(\.\d+)?(px|%)?$/.test(targ)){targ=both(targ);break}targ=$(targ,this);if(!targ.length)return;case'object':if(targ.is||targ.style)toff=(targ=$(targ)).offset()}$.each(g.axis.split(''),function(i,a){var b=a=='x'?'Left':'Top',pos=b.toLowerCase(),key='scroll'+b,old=d[key],max=h.max(d,a);if(toff){attr[key]=toff[pos]+(win?0:old-$elem.offset()[pos]);if(g.margin){attr[key]-=parseInt(targ.css('margin'+b))||0;attr[key]-=parseInt(targ.css('border'+b+'Width'))||0}attr[key]+=g.offset[pos]||0;if(g.over[pos])attr[key]+=targ[a=='x'?'width':'height']()*g.over[pos]}else{var c=targ[pos];attr[key]=c.slice&&c.slice(-1)=='%'?parseFloat(c)/100*max:c}if(g.limit&&/^\d+$/.test(attr[key]))attr[key]=attr[key]<=0?0:Math.min(attr[key],max);if(!i&&g.queue){if(old!=attr[key])animate(g.onAfterFirst);delete attr[key]}});animate(g.onAfter);function animate(a){$elem.animate(attr,f,g.easing,a&&function(){a.call(this,e,g)})}}).end()};h.max=function(a,b){var c=b=='x'?'Width':'Height',scroll='scroll'+c;if(!$(a).is('html,body'))return a[scroll]-$(a)[c.toLowerCase()]();var d='client'+c,html=a.ownerDocument.documentElement,body=a.ownerDocument.body;return Math.max(html[scroll],body[scroll])-Math.min(html[d],body[d])};function both(a){return typeof a=='object'?a:{top:a,left:a}}})(jQuery);;
/*
 * nyroModal v2.0.0
 * Core
 *
 * Commit b7ae3accf7634cc79a24dc3c6024cbb1f614b462 (10/17/2014) * 
 * 
 * Included parts:
 * - anims.fade
 * - filters.title
 * - filters.gallery
 * - filters.link
 * - filters.dom
 * - filters.data
 * - filters.image
 * - filters.swf
 * - filters.form
 * - filters.formFile
 * - filters.iframe
 * - filters.iframeForm
 * - filters.embedly
 * - filters.youtube
 */
 jQuery(function($,undefined){var uaMatch=function(ua){ua=ua.toLowerCase();var match= /(chrome)[ \/]([\w.]+)/.exec(ua)||
			/(webkit)[ \/]([\w.]+)/.exec(ua)||
			/(opera)(?:.*version|)[ \/]([\w.]+)/.exec(ua)||
			/(msie) ([\w.]+)/.exec(ua)||ua.indexOf("compatible")<0&& /(mozilla)(?:.*? rv:([\w.]+)|)/.exec(ua)||[];return{browser:match[ 1 ]||"",version:match[ 2 ]||"0"};},matched=uaMatch(navigator.userAgent),browser={};if(matched.browser){browser[matched.browser]=true;browser.version=matched.version;}if(browser.chrome){browser.webkit=true;}else if(browser.webkit){browser.safari=true;}var $w=$(window),$d=$(document),$b=$('body'),baseHref=$('base').attr('href'),_nmObj={filters:[],callbacks:{},anims:{},loadFilter:undefined,enabled:true,modal:false,closeOnEscape:true,closeOnClick:true,useKeyHandler:false,showCloseButton:true,closeButton:'<a href="#" class="nyroModalClose nyroModalCloseButton nmReposition" title="close">Close</a>',stack:false,nonStackable:'form',header:undefined,footer:undefined,galleryLoop:true,galleryCounts:true,ltr:true,domCopy:false,ajax:{},imageRegex:'[^\.]\.(jpg|jpeg|png|tiff|gif|bmp)\\s*$',selIndicator:'nyroModalSel',swfObjectId:undefined,swf:{allowFullScreen:'true',allowscriptaccess:'always',wmode:'transparent'},store:{},errorMsg:'An error occured',elts:{all:undefined,bg:undefined,load:undefined,cont:undefined,hidden:undefined},sizes:{initW:undefined,initH:undefined,w:undefined,h:undefined,minW:undefined,minH:undefined,maxW:undefined,maxH:undefined,wMargin:undefined,hMargin:undefined},anim:{def:undefined,showBg:undefined,hideBg:undefined,showLoad:undefined,hideLoad:undefined,showCont:undefined,hideCont:undefined,showTrans:undefined,hideTrans:undefined,resize:undefined},_open:false,_bgReady:false,_opened:false,_loading:false,_animated:false,_transition:false,_needClose:false,_nmOpener:undefined,_nbContentLoading:0,_scripts:'',_scriptsShown:'',saveObj:function(){this.opener.data('nmObj',this);},open:function(){if(!this.enabled)return false;if(this._nmOpener)this._nmOpener._close();this.getInternal()._pushStack(this.opener);this._opened=false;this._bgReady=false;this._open=true;this._initElts();this._load();this._nbContentLoading=0;this._callAnim('showBg',$.proxy(function(){this._bgReady=true;if(this._nmOpener){this._nmOpener._bgReady=false;this._nmOpener._loading=false;this._nmOpener._animated=false;this._nmOpener._opened=false;this._nmOpener._open=false;this._nmOpener.elts.cont=this._nmOpener.elts.hidden=this._nmOpener.elts.load=this._nmOpener.elts.bg=this._nmOpener.elts.all=undefined;this._nmOpener.saveObj();this._nmOpener=undefined;}this._contentLoading();},this));},resize:function(recalc){if(recalc){this.elts.hidden.append(this.elts.cont.children().first().clone());this.sizes.initW=this.sizes.w=this.elts.hidden.width();this.sizes.initH=this.sizes.h=this.elts.hidden.height();this.elts.hidden.empty();}else{this.sizes.w=this.sizes.initW;this.sizes.h=this.sizes.initH;}this._unreposition();this.size();this._callAnim('resize',$.proxy(function(){this._reposition();},this));},size:function(){var maxHeight=this.getInternal().fullSize.viewH-this.sizes.hMargin,maxWidth=this.getInternal().fullSize.viewW-this.sizes.wMargin;if(typeof this.sizes.maxH!=='undefined'&&this.sizes.maxH<maxHeight)maxHeight=this.sizes.maxH;if(typeof this.sizes.maxW!=='undefined'&&this.sizes.maxW<maxWidth)maxWidth=this.sizes.maxW;if(this.sizes.minW&&this.sizes.minW>this.sizes.w)this.sizes.w=this.sizes.minW;if(this.sizes.minH&&this.sizes.minH>this.sizes.h)this.sizes.h=this.sizes.minH;if(this.sizes.h>maxHeight||this.sizes.w>maxWidth){this.sizes.h=Math.min(this.sizes.h,maxHeight);this.sizes.w=Math.min(this.sizes.w,maxWidth);}this._callFilters('size');},getForNewLinks:function(elt){var ret;if(this.stack&&(!elt||this.isStackable(elt))){ret=$.extend(true,{},this);ret._nmOpener=undefined;ret.elts.all=undefined;}else{ret=$.extend({},this);ret._nmOpener=this;}ret.filters=[];ret.opener=undefined;ret._open=false;return ret;},isStackable:function(elt){return!elt.is(this.nonStackable);},keyHandle:function(e){this.keyEvent=e;this._callFilters('keyHandle');this.keyEvent=undefined;delete(this.keyEvent);},getInternal:function(){return _internal;},_close:function(){var ret=true;if(!this._animated){$.each(this._callFilters('close'),function(k,v){if(v===false)ret=false;});if(ret){this.getInternal()._removeStack(this.opener);this._opened=false;this._open=false;}}else{this._needClose=true;ret=false;}return ret;},close:function(){if(this._close()){this._needClose=false;this._callFilters('beforeClose');var self=this;this._unreposition();self._callAnim('hideCont',function(){self._callAnim('hideLoad',function(){self._callAnim('hideBg',function(){self._callFilters('afterClose');self.elts.cont.remove();self.elts.hidden.remove();self.elts.load.remove();self.elts.bg.remove();self.elts.all.remove();self.elts.cont=self.elts.hidden=self.elts.load=self.elts.bg=self.elts.all=undefined;});});});}},destroy:function(){if(this._open)return false;this._callFilters('destroy');if(this.elts.all)this.elts.all.remove();return true;},_initElts:function(){if(!this.stack&&this.getInternal().stack.length>1)this.elts=this.getInternal().stack[this.getInternal().stack.length-2]['nmObj'].elts;if(!this.elts.all||this.elts.all.closest('body').length==0)this.elts.all=this.elts.bg=this.elts.cont=this.elts.hidden=this.elts.load=undefined;if(!this.elts.all)this.elts.all=$('<div />').appendTo(this.getInternal()._container);if(!this.elts.bg)this.elts.bg=$('<div />').hide().appendTo(this.elts.all);if(!this.elts.cont)this.elts.cont=$('<div />').hide().appendTo(this.elts.all);if(!this.elts.hidden)this.elts.hidden=$('<div />').hide().appendTo(this.elts.all);this.elts.hidden.empty();if(!this.elts.load)this.elts.load=$('<div />').hide().appendTo(this.elts.all);this._callFilters('initElts');},_error:function(jqXHR){this._callFilters('error',jqXHR);},_setCont:function(html,selector){if(selector){var tmp=[],i=0;html=html .replace(/\r\n/gi,'nyroModalLN').replace(/<script(.|\s)*?\/script>/gi,function(x){tmp[i]=x;return '<pre class=nyroModalScript rel="'+(i++)+'"></pre>';});var cur=$('<div>'+html+'</div>').find(selector);if(cur.length){html=cur.html().replace(/<pre class="?nyroModalScript"? rel="?([0-9]*)"?><\/pre>/gi,function(x,y,z){return tmp[y];}).replace(/nyroModalLN/gi,"\r\n");}else{this._error();return;}}this.elts.hidden .append(this._filterScripts(html)).prepend(this.header).append(this.footer).wrapInner($('<div />',{'class':'nyroModal'+$.ucfirst(this.loadFilter)}));this.sizes.initW=this.sizes.w=this.elts.hidden.width();this.sizes.initH=this.sizes.h=this.elts.hidden.height();var outer=this.getInternal()._getOuter(this.elts.cont);this.sizes.hMargin=outer.h.total;this.sizes.wMargin=outer.w.total;this.size();this.loading=false;this._callFilters('filledContent');this._contentLoading();},_filterScripts:function(data){if(typeof data!='string')return data;this._scripts=[];this._scriptsShown=[];var start=0,stStart='<script',stEnd='</script>',endLn=stEnd.length,pos,pos2,tmp;while((pos=data.indexOf(stStart,start))>-1){pos2=data.indexOf(stEnd)+endLn;tmp=$(data.substring(pos,pos2));if(!tmp.attr('src')||tmp.attr('rel')=='forceLoad'){if(tmp.attr('rev')=='shown')this._scriptsShown.push(tmp.get(0));else this._scripts.push(tmp.get(0));}data=data.substring(0,pos)+data.substr(pos2);start=pos;}return data;},_hasFilter:function(filter){var ret=false;$.each(this.filters,function(i,f){ret=ret||f==filter;});return ret;},_delFilter:function(filter){this.filters=$.map(this.filters,function(v){if(v!=filter)return v;});},_callFilters:function(fct,prm){this.getInternal()._debug(fct,prm);if(this.opener&&this.opener.length){this.opener.trigger(fct+'.nyroModal',[this,prm]);}else{$b.trigger(fct+'.nyroModal',[this,prm]);}var ret=[],self=this;$.each(this.filters,function(i,f){ret[f]=self._callFilter(f,fct,prm);});if(this.callbacks[fct]&&$.isFunction(this.callbacks[fct]))ret['callbacks']=this.callbacks[fct](this,prm);return ret;},_callFilter:function(f,fct,prm){if(_filters[f]&&_filters[f][fct]&&$.isFunction(_filters[f][fct]))return _filters[f][fct](this,prm);return undefined;},_callAnim:function(fct,clb){this.getInternal()._debug(fct,clb);this._callFilters('before'+$.ucfirst(fct));if(!this._animated){this._animated=true;if(!$.isFunction(clb))clb=$.noop;if(this.anims[fct]&&$.isFunction(this.anims[fct])){curFct=this.anims[fct];}else{var set=this.anim[fct]||this.anim.def||'basic';if(!_animations[set]||!_animations[set][fct]||!$.isFunction(_animations[set][fct]))set='basic';curFct=_animations[set][fct];}curFct(this,$.proxy(function(){this._animated=false;this._callFilters('after'+$.ucfirst(fct));clb();if(this._needClose)setTimeout($.proxy(function(){this.close();},this),50);},this));}},_load:function(){this.getInternal()._debug('_load');if(!this.loading&&this.loadFilter){this.loading=true;this._callFilter(this.loadFilter,'load');}},_contentLoading:function(){if(!this._animated&&this._bgReady){if(!this._transition&&this.elts.cont.html().length>0)this._transition=true;this._nbContentLoading++;if(!this.loading){if(!this._opened){this._opened=true;if(this._transition){var fct=$.proxy(function(){this._writeContent();this._callFilters('beforeShowCont');this._callAnim('hideTrans',$.proxy(function(){this._transition=false;this._callFilters('afterShowCont');this.elts.cont.append(this._scriptsShown);this._reposition();this.elts.cont.scrollTop(0);},this));},this);if(this._nbContentLoading==1){this._unreposition();this._callAnim('showTrans',fct);}else{fct();}}else{this._callAnim('hideLoad',$.proxy(function(){this._writeContent();this._callAnim('showCont',$.proxy(function(){this.elts.cont.append(this._scriptsShown);this._reposition();this.elts.cont.scrollTop(0);},this));},this));}}}else if(this._nbContentLoading==1){var outer=this.getInternal()._getOuter(this.elts.load);this.elts.load .css({position:'fixed',top:(this.getInternal().fullSize.viewH-this.elts.load.height()-outer.h.margin)/2,left:(this.getInternal().fullSize.viewW-this.elts.load.width()-outer.w.margin)/2});if(this._transition){this._unreposition();this._callAnim('showTrans',$.proxy(function(){this._contentLoading();},this));}else{this._callAnim('showLoad',$.proxy(function(){this._contentLoading();},this));}}}},_writeContent:function(){this.elts.cont .empty().append(this.elts.hidden.contents()).append(this._scripts).append(this.showCloseButton?this.closeButton:'').css({position:'fixed',width:this.sizes.w,height:this.sizes.h,top:(this.getInternal().fullSize.viewH-this.sizes.h-this.sizes.hMargin)/2,left:(this.getInternal().fullSize.viewW-this.sizes.w-this.sizes.wMargin)/2});},_reposition:function(){var elts=this.elts.cont.find('.nmReposition');if(elts.length){var space=this.getInternal()._getSpaceReposition();elts.each(function(){var me=$(this),offset=me.offset();me.css({position:'fixed',top:offset.top-space.top,left:offset.left-space.left});});this.elts.cont.after(elts);}this.elts.cont.css('overflow','auto');this._callFilters('afterReposition');},_unreposition:function(){this.elts.cont.css('overflow','');var elts=this.elts.all.find('.nmReposition');if(elts.length)this.elts.cont.append(elts.removeAttr('style'));this._callFilters('afterUnreposition');}},_internal={firstInit:true,debug:false,stack:[],fullSize:{w:0,h:0,wW:0,wH:0,viewW:0,viewH:0},nyroModal:function(opts,fullObj){if(_internal.firstInit){_internal._container=$('<div />').appendTo($b);$w.smartresize($.proxy(_internal._resize,_internal));$d.on('keydown.nyroModal',$.proxy(_internal._keyHandler,_internal));_internal._calculateFullSize();_internal.firstInit=false;}return this.nmInit(opts,fullObj).each(function(){_internal._init($(this).data('nmObj'));});},nmInit:function(opts,fullObj){return this.each(function(){var me=$(this);if(fullObj)me.data('nmObj',$.extend(true,{opener:me},opts));else me.data('nmObj',me.data('nmObj')?$.extend(true,me.data('nmObj'),opts):$.extend(true,{opener:me},_nmObj,opts));});},nmDestroy:function(){return this.each(function(){var me=$(this);if(me.data('nmObj')){if(me.data('nmObj').destroy())me.removeData('nmObj');}});},nmCall:function(){return this.trigger('nyroModal');},nmManual:function(url,opts){$('<a />',{href:url}).nyroModal(opts).trigger('nyroModal');},nmData:function(data,opts){this.nmManual('#',$.extend({data:data},opts));},nmObj:function(opts){$.extend(true,_nmObj,opts);},nmInternal:function(opts){$.extend(true,_internal,opts);},nmAnims:function(opts){$.extend(true,_animations,opts);},nmFilters:function(opts){$.extend(true,_filters,opts);},nmTop:function(){if(_internal.stack.length)return _internal.stack[_internal.stack.length-1]['nmObj'];return undefined;},_debug:function(){if(this.debug&&window.console&&window.console.log)window.console.log.apply(window.console,arguments);},_container:undefined,_init:function(nm){nm.filters=[];$.each(_filters,function(f,obj){if(obj.is&&$.isFunction(obj.is)&&obj.is(nm)){nm.filters.push(f);}});nm._callFilters('initFilters');nm._callFilters('init');nm.opener .off('nyroModal.nyroModal nmDisable.nyroModal nmEnable.nyroModal nmClose.nyroModal nmResize.nyroModal').on({'nyroModal.nyroModal':function(){nm.open();return false;},'nmDisable.nyroModal':function(){nm.enabled=false;return false;},'nmEnable.nyroModal':function(){nm.enabled=true;return false;},'nmClose.nyroModal':function(){nm.close();return false;},'nmResize.nyroModal':function(){nm.resize();return false;}});},_selNyroModal:function(obj){return $(obj).data('nmObj')?true:false;},_selNyroModalOpen:function(obj){var me=$(obj);return me.data('nmObj')?me.data('nmObj')._open:false;},_keyHandler:function(e){var nmTop=$.nmTop();if(nmTop&&nmTop.useKeyHandler){return nmTop.keyHandle(e);}},_pushStack:function(obj){this.stack=$.map(this.stack,function(elA){if(elA['nmOpener']!=obj.get(0))return elA;});this.stack.push({nmOpener:obj.get(0),nmObj:$(obj).data('nmObj')});},_removeStack:function(obj){this.stack=$.map(this.stack,function(elA){if(elA['nmOpener']!=obj.get(0))return elA;});},_resize:function(){$.each(this.stack,function(k,v){v.nmObj._unreposition();});this._calculateFullSize();$.each(this.stack,function(k,v){v.nmObj.resize();});},_calculateFullSize:function(){this.fullSize={w:$d.width(),h:$d.height(),wW:$w.width(),wH:$w.height()};this.fullSize.viewW=Math.min(this.fullSize.w,this.fullSize.wW);this.fullSize.viewH=Math.min(this.fullSize.h,this.fullSize.wH);},_getCurCSS:function(elm,name){var ret=parseInt($.css(elm,name,true));return isNaN(ret)?0:ret;},_getOuter:function(elm){elm=elm.get(0);var ret={h:{margin:this._getCurCSS(elm,'marginTop')+this._getCurCSS(elm,'marginBottom'),border:this._getCurCSS(elm,'borderTopWidth')+this._getCurCSS(elm,'borderBottomWidth'),padding:this._getCurCSS(elm,'paddingTop')+this._getCurCSS(elm,'paddingBottom')},w:{margin:this._getCurCSS(elm,'marginLeft')+this._getCurCSS(elm,'marginRight'),border:this._getCurCSS(elm,'borderLeftWidth')+this._getCurCSS(elm,'borderRightWidth'),padding:this._getCurCSS(elm,'paddingLeft')+this._getCurCSS(elm,'paddingRight')}};ret.h.outer=ret.h.margin+ret.h.border;ret.w.outer=ret.w.margin+ret.w.border;ret.h.inner=ret.h.padding+ret.h.border;ret.w.inner=ret.w.padding+ret.w.border;ret.h.total=ret.h.outer+ret.h.padding;ret.w.total=ret.w.outer+ret.w.padding;return ret;},_getSpaceReposition:function(){var outer=this._getOuter($b),ie7=browser.msie&&browser.version<8&&!(screen.height<=$w.height()+23);return{top:$w.scrollTop()-(!ie7?outer.h.border/2:0),left:$w.scrollLeft()-(!ie7?outer.w.border/2:0)};},_getHash:function(url){if(typeof url=='string'){var hashPos=url.indexOf('#');if(hashPos>-1)return url.substring(hashPos);}return '';},_extractUrl:function(url){var ret={url:undefined,sel:undefined};if(url){var hash=this._getHash(url),hashLoc=this._getHash(window.location.href),curLoc=window.location.href.substring(0,window.location.href.length-hashLoc.length),req=url.substring(0,url.length-hash.length);ret.sel=hash;if(req!=curLoc&&req!=baseHref)ret.url=req;}return ret;}},_animations={basic:{showBg:function(nm,clb){nm.elts.bg.css({opacity:0.7}).show();clb();},hideBg:function(nm,clb){nm.elts.bg.hide();clb();},showLoad:function(nm,clb){nm.elts.load.show();clb();},hideLoad:function(nm,clb){nm.elts.load.hide();clb();},showCont:function(nm,clb){nm.elts.cont.show();clb();},hideCont:function(nm,clb){nm.elts.cont.hide();clb();},showTrans:function(nm,clb){nm.elts.cont.hide();nm.elts.load.show();clb();},hideTrans:function(nm,clb){nm.elts.cont.show();nm.elts.load.hide();clb();},resize:function(nm,clb){nm.elts.cont.css({width:nm.sizes.w,height:nm.sizes.h,top:(nm.getInternal().fullSize.viewH-nm.sizes.h-nm.sizes.hMargin)/2,left:(nm.getInternal().fullSize.viewW-nm.sizes.w-nm.sizes.wMargin)/2});clb();}}},_filters={basic:{is:function(nm){return true;},init:function(nm){if(nm.opener.attr('rev')=='modal')nm.modal=true;if(nm.modal)nm.closeOnEscape=nm.closeOnClick=nm.showCloseButton=false;if(nm.closeOnEscape)nm.useKeyHandler=true;},initElts:function(nm){nm.elts.bg.addClass('nyroModalBg');nm.elts.cont.addClass('nyroModalCont');nm.elts.hidden.addClass('nyroModalCont nyroModalHidden');nm.elts.load.addClass('nyroModalCont nyroModalLoad');},error:function(nm){nm.elts.hidden.addClass('nyroModalError');nm.elts.cont.addClass('nyroModalError');nm._setCont(nm.errorMsg);},beforeShowCont:function(nm){nm.elts.cont .find('.nyroModal').each(function(){var cur=$(this);cur.nyroModal(nm.getForNewLinks(cur),true);}).end().find('.nyroModalClose').on('click.nyroModal',function(e){e.preventDefault();nm.close();});},afterShowCont:function(nm){if(nm.closeOnClick)nm.elts.bg.off('click.nyroModal').on('click.nyroModal',function(e){e.preventDefault();nm.close();});},keyHandle:function(nm){if(nm.keyEvent.keyCode==27&&nm.closeOnEscape){nm.keyEvent.preventDefault();nm.close();}}},custom:{is:function(nm){return true;}}};$.fn.extend({nm:_internal.nyroModal,nyroModal:_internal.nyroModal,nmInit:_internal.nmInit,nmDestroy:_internal.nmDestroy,nmCall:_internal.nmCall});$.extend({nmManual:_internal.nmManual,nmData:_internal.nmData,nmObj:_internal.nmObj,nmInternal:_internal.nmInternal,nmAnims:_internal.nmAnims,nmFilters:_internal.nmFilters,nmTop:_internal.nmTop});$.expr[':'].nyroModal=$.expr[':'].nm=_internal._selNyroModal;$.expr[':'].nmOpen=_internal._selNyroModalOpen;});(function($,sr){var debounce=function(func,threshold,execAsap){var timeout;return function debounced(){var obj=this,args=arguments;function delayed(){if(!execAsap)func.apply(obj,args);timeout=null;};if(timeout)clearTimeout(timeout);else if(execAsap)func.apply(obj,args);timeout=setTimeout(delayed,threshold||100);};};jQuery.fn[sr]=function(fn){return fn?this.on('resize',debounce(fn)):this.trigger(sr);};})(jQuery,'smartresize');(function($){$.ucfirst=function(str){str+='';var f=str.charAt(0).toUpperCase();return f+str.substr(1);};})(jQuery);;
 jQuery(function($,undefined){$.nmAnims({fade:{showBg:function(nm,clb){nm.elts.bg.fadeTo(250,0.7,clb);},hideBg:function(nm,clb){nm.elts.bg.fadeOut(clb);},showLoad:function(nm,clb){nm.elts.load.fadeIn(clb);},hideLoad:function(nm,clb){nm.elts.load.fadeOut(clb);},showCont:function(nm,clb){nm.elts.cont.fadeIn(clb);},hideCont:function(nm,clb){nm.elts.cont.css('overflow','hidden').fadeOut(clb);},showTrans:function(nm,clb){nm.elts.load .css({position:nm.elts.cont.css('position'),top:nm.elts.cont.css('top'),left:nm.elts.cont.css('left'),width:nm.elts.cont.css('width'),height:nm.elts.cont.css('height'),marginTop:nm.elts.cont.css('marginTop'),marginLeft:nm.elts.cont.css('marginLeft')}).fadeIn(function(){nm.elts.cont.hide();clb();});},hideTrans:function(nm,clb){nm.elts.cont.css('visibility','hidden').show();nm.elts.load .css('position',nm.elts.cont.css('position')).animate({top:nm.elts.cont.css('top'),left:nm.elts.cont.css('left'),width:nm.elts.cont.css('width'),height:nm.elts.cont.css('height'),marginTop:nm.elts.cont.css('marginTop'),marginLeft:nm.elts.cont.css('marginLeft')},function(){nm.elts.cont.css('visibility','');nm.elts.load.fadeOut(clb);});},resize:function(nm,clb){nm.elts.cont.animate({width:nm.sizes.w,height:nm.sizes.h,top:(nm.getInternal().fullSize.viewH-nm.sizes.h-nm.sizes.hMargin)/2,left:(nm.getInternal().fullSize.viewW-nm.sizes.w-nm.sizes.wMargin)/2},clb);}}});$.nmObj({anim:{def:'fade'}});});;
 jQuery(function($,undefined){$.nmFilters({title:{is:function(nm){return nm.opener.is('[title]');},beforeShowCont:function(nm){var offset=nm.elts.cont.offset();nm.store.title=$('<h1 />',{text:nm.opener.attr('title')}).addClass('nyroModalTitle nmReposition');nm.elts.cont.prepend(nm.store.title);},close:function(nm){if(nm.store.title){nm.store.title.remove();nm.store.title=undefined;delete(nm.store.title);}}}});});;
 jQuery(function($,undefined){$.nmFilters({gallery:{is:function(nm){var ret=nm.opener.is('[rel]:not([rel=external], [rel=nofollow])');if(ret){var rel=nm.opener.attr('rel'),indexSpace=rel.indexOf(' '),gal=indexSpace>0?rel.substr(0,indexSpace):rel,links=$('[href][rel="'+gal+'"], [href][rel^="'+gal+' "]');if(links.length<2)ret=false;if(ret&&nm.galleryCounts&&!nm._hasFilter('title'))nm.filters.push('title');}return ret;},init:function(nm){nm.useKeyHandler=true;},keyHandle:function(nm){if(!nm._animated&&nm._opened){if(nm.keyEvent.keyCode==39||nm.keyEvent.keyCode==40){nm.keyEvent.preventDefault();nm._callFilters('galleryNext');}else if(nm.keyEvent.keyCode==37||nm.keyEvent.keyCode==38){nm.keyEvent.preventDefault();nm._callFilters('galleryPrev');}}},initElts:function(nm){var rel=nm.opener.attr('rel'),indexSpace=rel.indexOf(' ');nm.store.gallery=indexSpace>0?rel.substr(0,indexSpace):rel;nm.store.galleryLinks=$('[href][rel="'+nm.store.gallery+'"], [href][rel^="'+nm.store.gallery+' "]');nm.store.galleryIndex=nm.store.galleryLinks.index(nm.opener);},beforeShowCont:function(nm){if(nm.galleryCounts&&nm.store.title&&nm.store.galleryLinks&&nm.store.galleryLinks.length>1){var curTitle=nm.store.title.html();nm.store.title.html((curTitle.length?curTitle+' - ':'')+(nm.store.galleryIndex+1)+'/'+nm.store.galleryLinks.length);}},filledContent:function(nm){var link=this._getGalleryLink(nm,-1),append=nm.elts.hidden.find(' > div');if(link){$('<a />',{text:'previous',href:'#'}).addClass('nyroModalPrev').on('click',function(e){e.preventDefault();nm._callFilters('galleryPrev');}).appendTo(append);}link=this._getGalleryLink(nm,1);if(link){$('<a />',{text:'next',href:'#'}).addClass('nyroModalNext').on('click',function(e){e.preventDefault();nm._callFilters('galleryNext');}).appendTo(append);}},close:function(nm){nm.store.gallery=undefined;nm.store.galleryLinks=undefined;nm.store.galleryIndex=undefined;delete(nm.store.gallery);delete(nm.store.galleryLinks);delete(nm.store.galleryIndex);if(nm.elts.cont)nm.elts.cont.find('.nyroModalNext, .nyroModalPrev').remove();},galleryNext:function(nm){this._getGalleryLink(nm,1).nyroModal(nm.getForNewLinks(),true).click();},galleryPrev:function(nm){this._getGalleryLink(nm,-1).nyroModal(nm.getForNewLinks(),true).click();},_getGalleryLink:function(nm,dir){if(nm.store.gallery){if(!nm.ltr)dir *=-1;var index=nm.store.galleryIndex+dir;if(nm.store.galleryLinks&&index>=0&&index<nm.store.galleryLinks.length)return nm.store.galleryLinks.eq(index);else if(nm.galleryLoop&&nm.store.galleryLinks)return nm.store.galleryLinks.eq(index<0?nm.store.galleryLinks.length-1:0);}return undefined;}}});});;
 jQuery(function($,undefined){$.nmFilters({link:{is:function(nm){var ret=nm.opener.is('[href]');if(ret)nm.store.link=nm.getInternal()._extractUrl(nm.opener.attr('href'));return ret;},init:function(nm){nm.loadFilter='link';nm.opener.off('click.nyroModal').on('click.nyroModal',function(e){e.preventDefault();nm.opener.trigger('nyroModal');});},load:function(nm){$.ajax($.extend(true,{},nm.ajax||{},{url:nm.store.link.url,data:nm.store.link.sel?[{name:nm.selIndicator,value:nm.store.link.sel.substring(1)}]:undefined,success:function(data){nm._setCont(data,nm.store.link.sel);},error:function(jqXHR){nm._error(jqXHR);}}));},destroy:function(nm){nm.opener.off('click.nyroModal');}}});});;
 jQuery(function($,undefined){$.nmFilters({dom:{is:function(nm){return nm._hasFilter('link')&&!nm.store.link.url&&nm.store.link.sel;},init:function(nm){nm.loadFilter='dom';},load:function(nm){nm.store.domEl=$(nm.store.link.sel);if(nm.store.domEl.length)nm._setCont(nm.domCopy?nm.store.domEl.html():nm.store.domEl.contents());else nm._error();},close:function(nm){if(!nm.domCopy&&nm.store.domEl&&nm.elts.cont)nm.store.domEl.append(nm.elts.cont.find('.nyroModalDom').contents());}}});});;
 jQuery(function($,undefined){$.nmFilters({data:{is:function(nm){var ret=nm.data?true:false;if(ret)nm._delFilter('dom');return ret;},init:function(nm){nm.loadFilter='data';},load:function(nm){nm._setCont(nm.data);}}});});;
 jQuery(function($,undefined){$.nmFilters({image:{is:function(nm){return(new RegExp(nm.imageRegex,'i')).test(nm.opener.attr('href'));},init:function(nm){nm.loadFilter='image';},load:function(nm){var url=nm.opener.attr('href');$('<img />').load(function(){nm.elts.cont.addClass('nyroModalImg');nm.elts.hidden.addClass('nyroModalImg');nm._setCont(this);}).error(function(){nm._error();}).attr('src',url);},size:function(nm){if(nm.sizes.w!=nm.sizes.initW||nm.sizes.h!=nm.sizes.initH){var ratio=Math.min(nm.sizes.w/nm.sizes.initW,nm.sizes.h/nm.sizes.initH);nm.sizes.w=nm.sizes.initW * ratio;nm.sizes.h=nm.sizes.initH * ratio;}var img=nm.loading?nm.elts.hidden.find('img'):nm.elts.cont.find('img');img.attr({width:nm.sizes.w,height:nm.sizes.h});},close:function(nm){if(nm.elts.cont){nm.elts.cont.removeClass('nyroModalImg');nm.elts.hidden.removeClass('nyroModalImg');}}}});});;
 jQuery(function($,undefined){$.nmFilters({swf:{idCounter:1,is:function(nm){return nm._hasFilter('link')&&nm.opener.is('[href$=".swf"]');},init:function(nm){nm.loadFilter='swf';},load:function(nm){if(!nm.swfObjectId)nm.swfObjectId='nyroModalSwf-'+(this.idCounter++);var url=nm.store.link.url,cont='<div><object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" id="'+nm.swfObjectId+'" width="'+nm.sizes.w+'" height="'+nm.sizes.h+'"><param name="movie" value="'+url+'"></param>',tmp='';$.each(nm.swf,function(name,val){cont+='<param name="'+name+'" value="'+val+'"></param>';tmp+=' '+name+'="'+val+'"';});cont+='<embed src="'+url+'" type="application/x-shockwave-flash" width="'+nm.sizes.w+'" height="'+nm.sizes.h+'"'+tmp+'></embed></object></div>';nm._setCont(cont);}}});});;
 jQuery(function($,undefined){$.nmFilters({form:{is:function(nm){var ret=nm.opener.is('form');if(ret)nm.store.form=nm.getInternal()._extractUrl(nm.opener.attr('action'));return ret;},init:function(nm){nm.loadFilter='form';nm.opener.off('submit.nyroModal').on('submit.nyroModal',function(e){e.preventDefault();nm.opener.trigger('nyroModal');});},load:function(nm){var data=nm.opener.serializeArray();if(nm.store.form.sel)data.push({name:nm.selIndicator,value:nm.store.form.sel.substring(1)});$.ajax($.extend(true,{type:'get',dataType:'text'},nm.ajax||{},{url:nm.store.form.url,data:data,type:nm.opener.attr('method')?nm.opener.attr('method'):undefined,success:function(data){nm._setCont(data,nm.store.form.sel);},error:function(jqXHR){nm._error(jqXHR);}}));},destroy:function(nm){nm.opener.off('submit.nyroModal');}}});});;
 jQuery(function($,undefined){$.nmFilters({formFile:{is:function(nm){var ret=nm.opener.is('form[enctype="multipart/form-data"]');if(ret){nm._delFilter('form');if(!nm.store.form)nm.store.form=nm.getInternal()._extractUrl(nm.opener.attr('action'));}return ret;},init:function(nm){nm.loadFilter='formFile';nm.store.formFileLoading=false;nm.opener.off('submit.nyroModal').on('submit.nyroModal',function(e){if(!nm.store.formFileIframe){e.preventDefault();nm.opener.trigger('nyroModal');}else{nm.store.formFileLoading=true;}});},initElts:function(nm){var inputSel;if(nm.store.form.sel)inputSel=$('<input type="hidden" />',{name:nm.selIndicator,value:nm.store.form.sel.substring(1)}).appendTo(nm.opener);function rmFormFileElts(){if(inputSel){inputSel.remove();inputSel=undefined;delete(inputSel);}nm.store.formFileIframe.attr('src','about:blank').remove();nm.store.formFileIframe=undefined;delete(nm.store.formFileIframe);}nm.store.formFileIframe=$('<iframe />').attr({name:'nyroModalFormFile',src:'javascript:\'\';',id:'nyromodal-iframe-'+(new Date().getTime()),frameborder:'0'}).hide().load(function(){if(nm.store.formFileLoading){nm.store.formFileLoading=false;var content=nm.store.formFileIframe .off('load error').contents().find('body').not('script[src]');if(content&&content.html()&&content.html().length){rmFormFileElts();nm._setCont(content.html(),nm.store.form.sel);}else{var nbTry=0,fct=function(){nbTry++;var content=nm.store.formFileIframe .off('load error').contents().find('body').not('script[src]');if(content&&content.html()&&content.html().length){nm._setCont(content.html(),nm.store.form.sel);rmFormFileElts();}else if(nbTry<5){setTimeout(fct,25);}else{rmFormFileElts();nm._error();}};setTimeout(fct,25);}}}).on('error',function(){rmFormFileElts();nm._error();});nm.elts.all.append(nm.store.formFileIframe);nm.opener .attr('target','nyroModalFormFile').submit();},close:function(nm){nm.store.formFileLoading=false;if(nm.store.formFileIframe){nm.store.formFileIframe.remove();nm.store.formFileIframe=undefined;delete(nm.store.formFileIframe);}},destroy:function(nm){nm.opener.off('submit.nyroModal')}}});});;
 jQuery(function($,undefined){$.nmFilters({iframe:{is:function(nm){var target=nm.opener.attr('target')||'',rel=nm.opener.attr('rel')||'',opener=nm.opener.get(0);return!nm._hasFilter('image')&&(target.toLowerCase()=='_blank'||rel.toLowerCase().indexOf('external')>-1||(opener.hostname&&opener.hostname.replace(/:\d*$/,'')!=window.location.hostname.replace(/:\d*$/,'')));},init:function(nm){nm.loadFilter='iframe';},load:function(nm){nm.store.iframe=$('<iframe />').attr({src:'javascript:\'\';',id:'nyromodal-iframe-'+(new Date().getTime()),frameborder:'0'});nm._setCont(nm.store.iframe);},afterShowCont:function(nm){nm.store.iframe.attr('src',nm.opener.attr('href'));},close:function(nm){if(nm.store.iframe){nm.store.iframe.remove();nm.store.iframe=undefined;delete(nm.store.iframe);}}}});});;
 jQuery(function($,undefined){$.nmFilters({iframeForm:{is:function(nm){var ret=nm._hasFilter('iframe')&&nm.opener.is('form');if(ret){nm._delFilter('iframe');nm._delFilter('form');}return ret;},init:function(nm){nm.loadFilter='iframeForm';nm.store.iframeFormLoading=false;nm.store.iframeFormOrgTarget=nm.opener.attr('target');nm.opener.off('submit.nyroModal').on('submit.nyroModal',function(e){if(!nm.store.iframeFormIframe){e.preventDefault();nm.opener.trigger('nyroModal');}else{nm.store.iframeFormLoading=true;}});},load:function(nm){nm.store.iframeFormIframe=$('<iframe />').attr({name:'nyroModalIframeForm',src:'javascript:\'\';',id:'nyromodal-iframe-'+(new Date().getTime()),frameborder:'0'});nm._setCont(nm.store.iframeFormIframe);},afterShowCont:function(nm){nm.opener .attr('target','nyroModalIframeForm').submit();},close:function(nm){nm.store.iframeFormOrgTarget?nm.opener.attr('target',nm.store.iframeFormOrgTarget):nm.opener.removeAttr('target');delete(nm.store.formFileLoading);delete(nm.store.iframeFormOrgTarget);if(nm.store.iframeFormIframe){nm.store.iframeFormIframe.remove();nm.store.iframeFormIframe=undefined;delete(nm.store.iframeFormIframe);}},destroy:function(nm){nm.opener.off('submit.nyroModal')}}});});;
 jQuery(function($,undefined){$.nmObj({embedlyUrl:'http://api.embed.ly/1/oembed',embedly:{key:undefined,wmode:'transparent',allowscripts:true,format:'json'}});var cache=[];$.nmFilters({embedly:{is:function(nm){if(nm._hasFilter('link')&&nm._hasFilter('iframe')&&nm.opener.attr('href')&&nm.embedly.key){if(cache[nm.opener.attr('href')]){nm.store.embedly=cache[nm.opener.attr('href')];nm._delFilter('iframe');return true;}nm.store.embedly=false;var data=nm.embedly;data.url=nm.opener.attr('href');$.ajax({url:nm.embedlyUrl,dataType:'jsonp',data:data,success:function(data){if(data.type!='error'&&data.html){nm.store.embedly=data;cache[nm.opener.attr('href')]=data;nm._delFilter('iframe');nm.filters.push('embedly');nm._callFilters('initFilters');nm._callFilters('init');}}});}return false;},init:function(nm){nm.loadFilter='embedly';},load:function(nm){if(nm.store.embedly.type=='photo'){nm.filters.push('image');$('<img />').load(function(){nm.elts.cont.addClass('nyroModalImg');nm.elts.hidden.addClass('nyroModalImg');nm._setCont(this);}).on('error',function(){nm._error();}).attr('src',nm.store.embedly.url);}else{nm._setCont('<div>'+nm.store.embedly.html+'</div>');}},size:function(nm){if(nm.store.embedly.width&&!nm.sizes.height){nm.sizes.w=nm.store.embedly.width;nm.sizes.h=nm.store.embedly.height;}}}});});;
 jQuery(function($,undefined){$.nmFilters({youtube:{is:function(nm){if(nm._hasFilter('link')&&nm._hasFilter('iframe')&&nm.opener.attr('href').indexOf('www.youtube.com/watch?v=')>-1){nm._delFilter('iframe');return true;}return false;},init:function(nm){nm.loadFilter='youtube';},load:function(nm){nm.store.youtubeIframe=$('<iframe />').attr({src:'javascript:\'\';',id:'nyromodal-iframe-'+(new Date().getTime()),frameborder:'0'});nm._setCont(nm.store.youtubeIframe);},afterShowCont:function(nm){nm.store.youtubeIframe.attr('src',nm.opener.attr('href').replace(/watch\?v=/i,'embed/'));},close:function(nm){if(nm.store.youtubeIframe){nm.store.youtubeIframe.remove();nm.store.youtubeIframe=undefined;delete(nm.store.youtubeIframe);}}}});});;
;
(function( $ ){

  $.fn.aol_custom_tabs = function( options ) {

    //Setting is coming soon
    var settings = $.extend( {
      'tab'     : '.aol-tabs-tab li',
      'console' : '.aol-tabs-content #tabs-content > li',
      'action'  : 'mouseover',
      'callback': function() {}
    }, options);

//    console.log(options);
    return this.each(function() {
      $this = $(this);
      var $tabs = $this.find(options.tab);
      $tab_console = $this.find(options.console);
      $action = (options.action == '' || typeof(options.action)  === "undefined") ? 'mouseover' : options.action;


      $tab_console.hide();
      $tab_console.eq(0).show();
      $tabs.eq(0).addClass('active');

      $(document).on($action,options.tab, function(e){
        e.preventDefault();
        var idx = $(this).index();
        $(options.console).hide();
        $(options.console).eq(idx).show().css('visibility', 'visible');;
        $(options.tab).removeClass('active');
        $(this).addClass('active');
        if(typeof options.callback != "undefined") {
          //console.log(e.target, $tabs, $(e.target).closest($tabs));
          options.callback.call($(e.target).closest(options.tab)[0]);
        }
      });
    });
  };

})( jQuery );;
/**
 * @file
 * A JavaScript file for the theme.
 *
 * In order for this JavaScript to be loaded on pages, see the instructions in
 * the README.txt next to this file.
 */

// JavaScript should be made compatible with libraries other than jQuery by
// wrapping it with an "anonymous closure". See:
// - http://drupal.org/node/1446420
// - http://www.adequatelygood.com/2010/3/JavaScript-Module-Pattern-In-Depth

Drupal.aol_zen = {};

function debug() {
  if (window.console && console.log)
    console.log('[aol] ' + Array.prototype.join.call(arguments,' '));
}   

var add_to_any_loaded = nyro_loaded = false;
var windowWidth = window.innerWidth;
var mobile = false;
var mobile_tablet = false;
if  (windowWidth < 620) {
   mobile = true;
}
if  (windowWidth <= 768) {
   mobile_tablet = true;
}

function load_add_to_any() {
  return ;
  if (true == add_to_any_loaded) {
    return;
  }
  add_to_any_loaded = true;
    //Load AddToAny script asynchronously
  var a = document.createElement('script');
  a.type = 'text/javascript';
  a.async = true;
  a.src = 'http://static.addtoany.com/menu/page.js';
  var s = document.getElementsByTagName('script')[0];
  s.parentNode.insertBefore(a, s);
}

function load_nyro() {
  //if (true == nyro_loaded) {
    return;
  //}
  nyro_loaded = true;
    //Load AddToAny script asynchronously
  var a = document.createElement('script');
  a.type = 'text/javascript';
  a.async = true;
  a.src = '/sites/all/libraries/jquery.nyroModal/js/jquery.nyroModal.custom.min.js';
  var s = document.getElementsByTagName('script')[0];
  s.parentNode.insertBefore(a, s);
  
  var fileref=document.createElement("link")
  fileref.setAttribute("rel", "stylesheet")
  fileref.setAttribute("type", "text/css")
  fileref.setAttribute("href", '/sites/all/libraries/jquery.nyroModal/styles/nyroModal.css')
  document.getElementsByTagName("head")[0].appendChild(fileref);
  
}

var a2a_config = a2a_config || {};
 a2a_config.no_3p = 1;

 function a2a_add(row) {
   return ;   
   
   if (false == add_to_any_loaded) {
     load_add_to_any();
   }
  
  if ('undefined' != typeof a2a) {
     a2a_config.target = '#adthis-share-email';
    a2a_config.linkurl = 'http://www.artofliving.org' + row.link;
    a2a_config.menu_type = "mail";
    jQuery('#adthis-share-email').attr({href: 'http://www.addtoany.com/share_save'});
    a2a.init('page');
  
  
    a2a_config.menu_type = a2a_config.target = undefined;
    a2a_config.templates = {
        twitter: "${title} at ${link} via @artoflivingnow"
    };
    
    a2a_config.linkname = row.title;
    jQuery('#course-details #adthis-share').attr({href: 'http://www.addtoany.com/share_save'});
    a2a_config.linkurl = 'http://www.artofliving.org' + row.link;
    a2a.init('page');
    jQuery('#course-details #adthis-share').attr({href: jQuery('#course-details #adthis-share').attr('href')});
  }
  else {
    setTimeout(a2a_add, 2000, row);
  }
 }
 
 var loaded = false;
(function ($, Drupal, window, document, undefined) {
  Drupal.aol_zen.promotion_popup = function() {
    if ($('.promotion-popups .promotion-popup-item').length > 0){
      if ($('.promotion-popups-inner li').length > 1) {
      $('.promotion-popups-inner').cycle({
            fx:     'fade',
            speed:  'fast',
            pagerEvent: 'mouseover',
            timeout: 0, 
            pager:  '#promo-popup-nav'
          });
      }
      $(document).scroll(function () {
        if ($.cookie('pp-closed') == 1) {
          $('.promotion-popups').addClass('promotion-popup-closed')
        }
        var y = $(this).scrollTop();
        if (y > 200) {
            $('.promotion-popups').fadeIn();
            $('.social-closed').fadeIn();
        } 
        else{
            $('.promotion-popups').fadeOut();
            $('.social-closed').fadeOut();
        }
      });
      
      $('.close-popup').click(function() {
        $('.promotion-popups').fadeOut();
        $.cookie('pp-closed', 1);
      });
      $('.open-popup').click(function() {
        $('.promotion-popups').removeClass('promotion-popup-closed').fadeIn();
        $.cookie('pp-closed', 0);
      });
    }
    
    if ($('.social-closed').length > 0){
      $(document).scroll(function () {
        var y = $(this).scrollTop();
        if (y > 200) {
            $('.social-closed').fadeIn();
        } 
        else{
            $('.social-closed').fadeOut();
        }
      });
    }
  }
 
Drupal.behaviors.form_component = {
      element: '',
      intro: '',
      items: []
      
  };
 

  $(document).ready(function(){
    if($('.track_call').length){      
      var get_contact = $('.track_call').html();
      if (typeof _googWcmGet !== 'undefined' && $.isFunction(_googWcmGet)) {
        _googWcmGet(track_callback_aol, get_contact);
      }
    }
     //load_nyro();
     var quotes_bg = ['quote-bg-1.jpg', 'quote-bg-2.jpg', 'quote-bg-3.jpg', 'quote-bg-4.jpg', 'quote-bg-5.jpg'];
 //        Drupal.behaviors.form_component.initNyro();
     Drupal.aol_zen.promotion_popup();
     
     
      if (false == mobile) {
        $('#find-center-link a, #center-close').click(function(){ 
          $('#center-search-form').toggle();
        });
      }
      $('.section-carousel-body .QAHidden').append('<p class="read-more"><a href="#" >'+Drupal.t('Read More') + '</a></p>')
      
      jQuery(".nyro-form").nyroModal();
      
      if($('.quote_gallery').length){
        $('.quote_gallery a').nyroModal({
          autoSizable: false,
          resizable: false,
          windowResize: false,
    opacity:0.9,
          width: 640,
          height: 480,
          callbacks: {
            beforeShowCont: function(nm) {
        var url = nm.opener.attr('href');
        var title = nm.opener.attr('title');
        $('.nyroModalImg').append("<ul class='nyro-share-buttons'><li><a id='ref_fb' target='_blank' href='http://www.facebook.com/sharer.php?s=100&amp;p[url]="+url+"&amp;p[images][0]="+url+"' onclick='javascript:window.open(this.href, '', 'menubar=no,toolbar=no,resizable=no,scrollbars=no,height=400,width=600'); return false;'><img src='sites/all/themes/aol-zen/images/social-icons/facebook.svg' alt=''/></a></li><li><a id='ref_tw' target='_blank' href='https://twitter.com/intent/tweet?url="+url+"&amp;text="+title+"&amp;image="+url+"&amp;via=SriSri'  onclick='javascript:window.open(this.href, '', 'menubar=no,toolbar=no,resizable=no,scrollbars=no,height=400,width=600');return false;'><img src='sites/all/themes/aol-zen/images/social-icons/twitter.svg' alt=''/></a></li><li><a id='ref_gp' target='_blank' href='https://plus.google.com/share?url="+url+"' onclick='javascript:window.open(this.href, '', 'menubar=no,toolbar=no,resizable=no,scrollbars=no,height=400,width=600');return false'><img src='sites/all/themes/aol-zen/images/social-icons/google.svg' alt=''/></a></li></ul>");
  
  /*var FB_url = "http://www.facebook.com/sharer.php?s=100&p[title]="+(title)+"&p[url]="+encodeURIComponent(url)+"&p[images][0]="+(url);
  $("#ref_fb").attr('href',FB_url);
  
  var TW_url = "http://twitter.com/home?status="+escape(title)+"+"+encodeURIComponent(url);
  $("#ref_tw").attr('href',TW_url);*/
            }
          }
        });
      }

      $(".subscribe_webform").click(function(){
        //$("#quotes_webform").show();
        $("#quotes_webform").nyroModal();
      });
      
      var $el, $ps, $up, totalHeight;

      $(".QAHidden .read-more a").click(function() {
            
        totalHeight = 0
      
        $el = $(this);
        $p  = $el.parent();
        $up = $p.parent();
        $ps = $up.find("> *:not(.read-more)");
        
        
        // measure how tall inside should be by adding together heights of all inside paragraphs (except read-more paragraph)
        $ps.each(function() {
          totalHeight += $(this).outerHeight(true);
        });
        totalHeight = totalHeight ;      
        $up
          .css({
            // Set height to prevent instant jumpdown when max height is removed
            "height": $up.height(),
            "max-height": 9999
          })
          .animate({
            "height": totalHeight
          });
        
        // fade out read-more
        $p.fadeOut();

        // prevent jump-down
        return false;
          
      });
      
      $(".triangle").click(function(){
        $("#question-description").slideToggle("slow");
        $("#expand-button").toggleClass('expand');
      });
      
      $("#main_cats").change(function() {
        window.location = $(this).val();
      });

      $('.wisdom-quotes-categories').mouseover(function(){
    $('.share-buttons').css('visibility', 'hidden');
        $(this).find('.share-buttons').css('visibility', 'visible');  
      }).mouseout(function(){
    $('.share-buttons').css('visibility', 'hidden');
      });
      
      $(".wisdom-quotes-categories").on( {
      'mouseenter':function() { 
      $(this).css({'background-image': 'url(sites/all/themes/aol-zen/images/quotes_bg/' + quotes_bg[Math.floor(Math.random() * quotes_bg.length)] + ')'}); 
    },
      'mouseleave':function() {
      $('.wisdom-quotes-categories').css('background-image', 'none'); 
    }
    });
    
    //responsive table stack style addition
    
    if($('table').hasClass('responsive-table')){  
       $('.responsive-table').stacktable(); 
     }
    if($('table').hasClass('stacktable')){
      processTableToggle();
     }
     
   
  });
   
   Drupal.behaviors.AllPages = {
    attach: function (context) {
      load_add_to_any();
      
      
      if (!$("#landing-pages-content").hasClass('template-u2')) {
        if(typeof fluidvids !== 'undefined') {
         fluidvids.init({
           selector: ['iframe', 'object'], // runs querySelectorAll()
           players: ['www.youtube.com', 'player.vimeo.com'] // players to support
         });
       }
      }
      
      
      /*
      if (false == mobile_tablet) {
        $(window).scroll(function() {
          if ($(this).scrollTop() > 1){  
            $('#header, #navigation').addClass("sticky");
          }
          else{
            $('#header, #navigation').removeClass("sticky");
          }
       });
      }*/
      
      if (mobile_tablet && false == loaded) {
        loaded = true;
         var height = $(window).height() * 0.8;
         $('#course-details, #upcoming-course-mixed-rows').css({"max-height": height});
         $("#course-details").hide();
    //       $(".mobile .show-map-toggle").html("");
         $(document).on('click', '.course-upcoming-row', function(event) {
           var height = $(window).height() * 0.8;
           event.preventDefault();
          // $('#course-details, #upcoming-course-mixed-rows').css({"position":"absolute"})
           $('#course-details, #upcoming-course-mixed-rows').css({"max-height": height});
           $('#course-details, #upcoming-course-mixed-rows').toggle();
           $("#course-details").prepend('<a id="hide-details" href="#">X</a>');
           //mapChange.call($('.aol-tabs-tab li.active'));
          // $(".mobile .show-map-toggle").show();
         });
           $(document).on('click', '#course-details #hide-details', function(event) {
             event.preventDefault();
             $('#course-details, #upcoming-course-mixed-rows').toggle();
           });
        $("#search-block-form").submit(function(e) {
          if (!$("#search-block-form .form-text").is(":visible") || '' == $("#search-block-form .form-text").val()) {
            $("#search-block-form .form-text").show();
            $("#search-block-form").width(185);
            e.preventDefault();
          }
          
        });
        
        //mobile menu
        $(document).on('click', "#Menu > li", function() {
          if(!$(this).parents('.local_center_menus').length)
            $(this).parent().hide();
          var ul;
          if ($(this).find(" > ul > li:first .DropdownDivColumn ").length > 1) {
            ul = $(this).find(" > ul").clone();
          }
          else {
            ul = $(this).find(" > ul ul").clone();
          }
          ul.attr({'id': "menu-1"});
          ul.prepend("<li class='back-menu' data-hide='menu-1' data-show='Menu'> </li>");
          $(this).parent().parent().append(ul);
        });
        
        $(document).on('click', '#menu-1 .DropdownDivColumn', function() {
          $("#menu-1").hide();
          var ul = $(this).find(" > ul").clone();
          ul.attr({'id': "menu-2"});
          ul.prepend("<li class='back-menu' data-hide='menu-2' data-show='menu-1'> </li>");
          $('#mobile-menu').append(ul);
        });
        
        $(document).on('click', '.back-menu', function() {
          $('#' + $(this).attr('data-show')).show();
          $('#' + $(this).attr('data-hide')).remove();
          $(this).remove();
          $('.back-menu').show();
        });
        
        $("#mobile-menu").append("<span id='menu-search'>"+ Drupal.t('Search') + "</span>")
        $("#mobile-menu").append('<ul id="menu-search-block" style="display:none"><li id="main-seach-li"></li></ul>');
        $("#menu-search-block li#main-seach-li").append($("#block-country-locator-5"));
        
        //search menu click
        $(document).on('click', "#menu-search",  function(e) {
          e.preventDefault();
          $('#menu-search-block').toggle();
          $('#mobile-menu input#button').removeAttr('checked');
          $('#mobile-menu ul:not(#menu-search-block)').each(function() {
            if ($(this).is(":visible")) {
              $(this).removeAttr('style');
            }
          });
        });
        
        //menu show/hide
        $(document).on('change', '#button',  function() {
          if (!$('this').attr('checked')) {
            $('#menu-search-block').hide();
          }
          $('#mobile-menu ul').each(function() {
              if ($(this).is(":visible")) {
                $(this).removeAttr('style');
              }
          });
          if ($('#menu-local').length > 1) {
            $('#menu-local').hide();
          }
        });
        
        $(document).on("click", '#find-center-link a', function(){ 
          $("#main-seach-li").hide();

          var ul = $("#centerLocatorSubMenu ul").clone();
          ul.attr({'id': "menu-local"});
          ul.prepend("<li class='back-menu' data-hide='sub-search-li' data-show='main-seach-li'> </li>");
          $("#menu-search-block").append('<li id="sub-search-li"></li>');
          $("#sub-search-li").append(ul).show();
        });
        
        
        
        
      }
      
      $('.tiptip').each(function() {
        var content = false,//default content false, then it will be taken from title
        $content_div = $('#' + $(this).attr('id') + '-tooltip');
        
        if ( $content_div.length> 0) {
          content = $content_div.html();
        }
      
        new $.Zebra_Tooltips($(this), {
          'max_width':    300,
          'close_on_click' : false,
          'content' : content
        });
      });
      
      $('.action-from-anchor').click(function(e) {
        e.preventDefault();
          $(this).next().slideToggle();
      });
      
   
    $(document).bind('click', function(e){
      var $target = $(e.target);
  
      if(!$target.closest('#find-center-link').length){
        $('#center-search-form').hide();
      }
      
      if(!($target.closest('.unity_plus_country_locator').length || $target.closest('.block-country-locator').length || $target.closest('.navbar').find('.mobile-country-locator-2').length )){
       $('#CountrySelectorDropdown').hide();
      }
      
     /* if(!$target.closest('.block-country-locator').length){
        $('#CountrySelectorDropdown').hide(); //removed and combined in above because country locator not working in search course page 
      }*/
      
      if(!$target.closest('#block-country-locator-3').length){
        $('.LanguageSelection.language-popup').remove();
      }
      
    });

    /*
    jQuery(".box-row .pink-images").each(function() {
      var box_height = 0;
      $(this).find('.shadow-box .inner').each(function() {
          box_height = Math.max(box_height, $(this).height());
      });
      $(this).find('.shadow-box .inner').height(box_height);
    });
    
    jQuery(".box-row .grey-images").each(function() {   
      var gey_box_height = 0;
      $(this).find('.gray-box .inner').each(function() {
        gey_box_height = Math.max(gey_box_height, $(this).height());
      });
      $(this).find('.gray-box .inner').height(gey_box_height);
    });
    */
    
    
    $(document).on('mouseenter', '.course-upcoming-row2', function() {
      var i = $('.course-upcoming-row').index(this);
      var html = _.template(upcoming_course_details_template, Drupal.settings.geo_search.all_courses.rows[i]);
      $('#course-details').html(html);
      $('.course-upcoming-row').removeClass('active-course');
      $(this).addClass('active-course');
      
      //a2a_add(Drupal.settings.geo_search.all_courses.rows[i]);
     });
    $(document).on('mouseenter', '#course-details-node .refer-a-friend', function() {
        var $mail_link = $('#mail-link').text();
        var $mail_title = $('#page-title').text();
        var data = {link: $mail_link,title: $mail_title}
        //a2a_add(data);        
     });
    
//     $('#current_country a:not(.binded)').unbind('click').bind('click', function(e) {
//        e.preventDefault();
//        $(this).parent().next().slideToggle();
//      });
//     $('#current_country a').addClass('binded');
     
     $(document).ready(function(){
       $("form").on("invalid-form.validate", function (event, validator) {
           $this = $(this);
           setTimeout(function(){
             console.log($this.parent());
             $this.parent().find(".messages").fadeOut(5000, "linear", function () {
             });
           }, 0);  
       });
       
       setTimeout(function(){
          $(".get_in_touch_form div .messages").fadeOut(10000, "linear", function () {
          });
     
       }, 0);  
       $('.question-answer-view').find('.answer-box:first').show();   
       $('.question-answer-view').find('.question-box:first').find('span:first').addClass('expand');
       
     });
     
  
      $('#block-country-locator-3 .LanguageSelection li').not('.Selected').hide();
      $('#block-country-locator-3 .LanguageSelection li.Selected a.active').unbind('click').bind('click', function(e) {
        e.preventDefault();
        if ($('#block-country-locator-3 .language-popup').length > 0) {
          $('#block-country-locator-3 .language-popup').remove();
        }
        else {
          //$('.LanguageSelection').toggleClass('language-popup');
          //$('#block-country-locator-3 .LanguageSelection li').not('.Selected').toggle();
          var html = $('.LanguageSelection').clone();
          $(html).addClass('language-popup').find('li').show();
          $('.LanguageSelection').parent().append(html);
        }
      });
      
      

      if ($('.testimonials ul.testimonial-items').size() > 0) {
        $(function() {
          $('.testimonials ul.testimonial-items').cycle({
            fx:     'fade',
            speed:  'fast',
            pagerEvent: 'mouseover',
            timeout: 0, 
            pager:  '#testimonial-nav'
          });
        });
      }

      if ($('.spotlights ul.spotlight-items').size() > 0) {
        $(function() {
          $('.spotlights ul.spotlight-items').cycle({
            fx:     'fade',
            speed:  'fast',
            timeout: 0, 
            pagerEvent: 'mouseover',
            pager:  '#spotlights-nav'
          });
        });
      }
      

      $('.notify-form').hide();
      $('.notify-text a').click(function(e) {
        e.preventDefault();
        $(this).parent().next('.notify-form').slideToggle();
      });
      
      $('.share-your-experience-form-anchor a > span').once(function(){
      $('.share-your-experience-form-anchor a').click(function(e) {
      e.preventDefault();
      
        $('.share-your-experience-form-anchor a > span').toggleClass('expand');
          $(this).parent().next().slideToggle();
      
      })
      });
            
      $('.wisdom-search-facetapi h2').click(function(e) {
        e.preventDefault();        
        $('.wisdom-search-facetapi h2 > span').toggleClass('expand');            
        $(this).parent().find('.item-list').find('ul').slideToggle(function () { 
      if($('.wisdom-search-facetapi .item-list ul.facetapi-tagcloud-widget').css('display')=='block'){
        $('.wisdom-search-facetapi .item-list').css('border-bottom', '1px solid #ccc');
      }else{
        $('.wisdom-search-facetapi .item-list').css('border-bottom', '0');
      }
    });
        
       }) 
            
      /*$('.wisdom_tagcloud h2').mouseover(function(e) {
            e.preventDefault();        
            $('.wisdom_tagcloud h2 > span').toggleClass('expand');            
            $(this).parent().find('.item-list').find('ul').slideToggle();
        
       });*/
      
/*      var back_to_top = '<a href="#" class="back-to-top">' + Drupal.t("Back to top") +'</a>';
      if ($('.node-recur-event').length >0 || $('.node-type-landing-pages-node').length > 0) { }
      else if ($('.about-aol-section').length > 0) {
        $('.about-aol-section').before(back_to_top);
      } else if ($('.other-galleries').length > 0) {
        $('.other-galleries').after(back_to_top);
      }
      else if ($('article').size() == 1 && $('article').length > 0) {        
        if($('article .back-to-top').size() < 1){
          $('article').append(back_to_top);
        }
      }
      
      $('.back-to-top').click(function() {
        $(document).scrollTo('0%', 1500 );
      });    
  */    
      $(document).ready(function() {
       $('.section-handbook-header a').trigger('click');
       var url = window.location.href;
       if($('.wisdom-search-facetapi ul li a').hasClass('facetapi-active') || url.indexOf('wisdom-search') != -1){
         $('.wisdom-search-facetapi').find('.item-list').find('ul').slideToggle();        
       }
       
      });
      
      $('.section-handbook-header a').click(function(e) {       
        e.preventDefault();
        var path = "/random-meditation-question/js";
        if (Drupal.settings.pathPrefix) {
          path = "/" + Drupal.settings.pathPrefix + path;
        }
        var params = {'nid': Drupal.settings.cur_nid, 'lang': Drupal.settings.cur_lang };
        $.post(path, params,
          function(response, status){
          $('.section-handbook-header').next().find('.section-handbook-q').html(response.question);
          $('.section-handbook-header').next().find('.section-handbook-a').html(response.answer);
          }
        );
      });
      
      //File field Handling
      if ($('form.webform-client-form .form-managed-file').size() > 0) {
        $('form.webform-client-form .form-managed-file input[type=file]').hide();
        $("<a class='file-placeholder yellow-button' href='#'>" + Drupal.t("Browse") + "</div>").insertBefore("form.webform-client-form .form-managed-file .form-submit.ajax-processed");
        $('form.webform-client-form .form-managed-file .file-placeholder').bind( "click", function(e){
          e.preventDefault();
          $('form.webform-client-form .form-managed-file input[type=file]').one().trigger('click');
        });
        $("<div class='file-selected'></div>").insertBefore("form.webform-client-form .form-managed-file .file-placeholder");
        $('form.webform-client-form .form-managed-file input[type=file]').change(function(){
          var filespath = $(this).val().replace(/.+[\\\/]/, "");
          $('form.webform-client-form .form-managed-file .file-selected').html('Selecetd: ' + filespath);
        });
      }
      
      $("form.webform-client-form .form-managed-file").bind("DOMSubtreeModified",function(){
      if ($('form.webform-client-form .form-managed-file span.file').size() > 0 ) {
      $("form.webform-client-form .form-managed-file .file-placeholder").remove();
      $('form.webform-client-form .form-managed-file .file-selected').remove();
      }
      else {
      if ($("form.webform-client-form .form-managed-file .file-placeholder").size() > 1) {
        $("form.webform-client-form .form-managed-file .file-placeholder").eq(0).remove();
      }
      if ($("form.webform-client-form .form-managed-file .file-selected").size() > 1) {
        $("form.webform-client-form .form-managed-file .file-selected").eq(0).remove();
      }
      }
    });      
      
      $('.experiences .experiance-image').mouseover(function() {
      $('.experiences .experiance-desc').hide();
      $(this).next().show();
    })
    .mouseout(function() {
      $('.experiences .experiance-desc').hide();
    });
    var getHiddenElementHeight = function(element){
      var tempId = 'tmp-'+Math.floor(Math.random()*99999);//generating unique id just in case
      $(element).clone()
      .css('position','absolute')
      .css('height','auto').css('width','800px')
      //inject right into parent element so all the css applies (yes, i know, except the :first-child and other pseudo stuff..
      .appendTo($(element).parent().parent().parent())
      .css('left','-10000em')
      .addClass(tempId).show()
      h = $('.'+tempId).height()
      $('.'+tempId).remove()
      return h;
    }
      
     $(document).ready(function() {
      if (false == mobile) {
        $(".mega-menu-holder .mega-menu").each(function (index, domOb) {
          if ($(domOb).find('.menu-quote').size() > 0) {
            var top_margin = getHiddenElementHeight($(domOb).find('.menu-quote'));
            $(domOb).find('.menu-quote').parent().find('.DropdownDivColumn > ul').css('top', top_margin);
          }
          $(domOb).find('.without-image .mega-menu-content').each(function (i, ob){
            if ($(ob).find('h3.DropdownMenuLink a').size() < 1) {
              $(ob).addClass('without-bottom-border');
            }
          });
        });
      }
      if ($('.testimonials ul.testimonial-items').size() > 0) {
          if($('.testimonials #testimonial-nav span').size() < 2) {
            $('.testimonials #testimonial-nav').hide();
          }
      }
      if($('.unity_menu').length){
        var unity_footer_menu = $('.unity_menu').clone();
        unity_footer_menu = unity_footer_menu.html();
        //$(unity_footer_menu).appendTo(".unity_footer_menu");
        $(".unity_footer_menu").html(unity_footer_menu);

        var unity_mobile_footer = $('.unity_menu').find('li.mobile_footer');
        if(unity_mobile_footer != '' && unity_mobile_footer.hasClass('menu_active')){
          var mobile_footer_content = '';
          var mobile_footer_head = unity_mobile_footer.find('a:first').text();
          var mobile_footer = unity_mobile_footer.find('.sub-menu-inner').clone();
          mobile_footer = mobile_footer.html();
          mobile_footer_content += "<li class='first'><span>"+mobile_footer_head+"</span></li>";
          mobile_footer_content += mobile_footer;
          //$(mobile_footer_content).appendTo(".unity_mobile_footer");
          $(".unity_mobile_footer").html(mobile_footer_content);
        }else{
          $(".unity_mobile_footer_main").addClass('no_footer_menu');
        }
      }
      
      if($('#footer-search-form').length){
        $('#footer-search-form').submit(function(){
          var url = $(this).attr('action');
          url = url + '/' + $(this).find('.form-text').val();
          $(location).attr('href', url);
          return false;
        });
      }
     if($('#site-search-form-mobile').length){
        $('#site-search-form-mobile').bind('submit', function(){
          var url = $(this).attr('action');
          url = url + '/' + $(this).find('.form-text').val();
          $(location).attr('href', url);
          return false;
        });
      }
      if($('#blog-search-form').length){
        $('#blog-search-form').submit(function(){
          var url = $(this).attr('action');
          url = url + '/' + $(this).find('.form-text').val();
          $(location).attr('href', url);
          return false;
        });
      }
      $('.unity_menu li').mouseenter(function(){
        $(this).addClass('active');
      }).mouseleave(function(){
        $(this).removeClass('active');
      });
   });
     var qa_count = -1;
     if ($('.QAQuestionClosed, .QAQuestionOpen').length > 1) {
       $('.QAQuestionClosed, .QAQuestionOpen').each(function() {
         if ($(this).next().hasClass("QAHidden") || $(this).next().hasClass("QAShow")) {
           qa_count++;
           var html = _.template(question_and_answer_template, {"question": $(this).html(), "answer":$(this).next().html(), "id":qa_count});
           
           $(this).next().after(html);
           $(this).next().remove();
           $(this).remove();
         }
       });
       if ($(".QABottom").length > 0) {
          $(".QABottom").remove();
       }
     }
     
       $('.question-box, .QAQuestionClosed, .QAQuestionOpened').click(function(e) {
          e.preventDefault();
          if (e.target.href) {
            window.open(e.target.href);
          }
          $(".accordian-container").each(function(){
            //$(this).css({'min-height': $(this).height()});
          });
          $('.question-answer-container .currentAccordian').removeClass('currentAccordian');
          if($(this).parent().find('.answer-box').css('display') == 'none') {
//            $('.question-answer-container .question-box').find('span').removeClass('expand');
            $('.QAQuestionOpen').removeClass('QAQuestionOpen').addClass('QAQuestionClosed');
            
            $('.answer-box').delay(100).slideUp( 800 ).css( 'zoom', '1' ); 
            //$(this).find('.up-down-arrow span:first').addClass( 'expand' );
            $(this).addClass('QAQuestionOpen');
            $(this).find('.up-down-arrow span:first').addClass( 'currentAccordian' );
            var target = this;
            setTimeout(function() {
                if (!isElementInViewport($('.question-answer-container .currentAccordian').parent().parent()[0])) {
                  $(document).scrollTo($('.question-answer-container .currentAccordian').parent().parent().offset().top-40, 1500 );
                }
            }, 900);
          }else{
            $(this).next('.answer-box').show(); 
            $(this).find('.up-down-arrow span:first').removeClass('expand'); 
          }       
          $(this).parent().find('.answer-box').delay(105).slideToggle(700); 
          $('.expand-all-q-a a.expand-all').css('display','inline-block');
          $('.expand-all-q-a a.collapse-all').css('display','none');
         
          setTimeout(function() {
            $(".accordian-container").each(function(){
//                $(this).animate({'min-height': $(this).find('.accordian-container-inner').height()+50}, 500);
            });
          }, 950);
          
        });
       if (qa_count > -1) {
         $("#qa-0 .question-box").trigger("click");
       }
        
      
    }
  };
   
  Drupal.aol_zen.renderCourseFollowUp = function (data, stat ) {
        
        var viewHelpers = {
           checkForDayNames : function(course){
             return geoHelper.checkDayNames(course);
           }
        }
        _.extend(data, viewHelpers);
        
        var viewHelpers2 = {
           checkDateDays : function(start, start_date, end , requestFor, type) {
             return geoHelper.getCourseDateDays(start, start_date, end , requestFor, type);
           }
        }
        _.extend(data, viewHelpers2);
        
        var viewHelpers3 = {
           getMonthNames : function(format_date, recur_event) {
             return geoHelper.getMonthName(format_date, recur_event);
           }
        }
        _.extend(data, viewHelpers3);
        
        var viewHelpers4 = {
           getCourseDay : function(start_date, end_date) {
             return geoHelper.getCourseDay(start_date, end_date);
           }
        }
        _.extend(data, viewHelpers4);
        
        var viewHelpers5 = {
           checkManyDay : function(start_date, end_date) {
             return geoHelper.checkManyDay(start_date, end_date);
           }
        }
        _.extend(data, viewHelpers5);
        
        var all_course_html = _.template(upcoming_course_template, data);
        if (typeof Drupal.settings.geo_search == 'undefined') {
          Drupal.settings.geo_search = {};
        }

        if(stat == 1) {
          Drupal.settings.geo_search.all_courses = data;
          
          var viewHelpers6 = {
           checkForDayNames : function(course){
             return geoHelper.checkDayNames(course);
           }
	        }
	        _.extend(Drupal.settings.geo_search.all_courses.rows[0], viewHelpers6);
	        
	        var viewHelpers7 = {
	           checkDateDays : function(start, start_date, end , requestFor, type) {
	             return geoHelper.getCourseDateDays(start, start_date, end , requestFor, type);
	           }
	        }
	        _.extend(Drupal.settings.geo_search.all_courses.rows[0], viewHelpers7);
	        
	        var viewHelpers8 = {
	           getMonthNames : function(format_date, recur_event) {
	             return geoHelper.getMonthName(format_date, recur_event);
	           }
	        }
	        _.extend(Drupal.settings.geo_search.all_courses.rows[0], viewHelpers8);
	        
	        var viewHelpers9 = {
	           getCourseDay : function(start_date, end_date) {
	             return geoHelper.getCourseDay(start_date, end_date);
	           }
	        }
	        _.extend(Drupal.settings.geo_search.all_courses.rows[0], viewHelpers9);
	        
	        var viewHelpers10 = {
	           checkManyDay : function(start_date, end_date) {
	             return geoHelper.checkManyDay(start_date, end_date);
	           }
	        }
	        _.extend(Drupal.settings.geo_search.all_courses.rows[0], viewHelpers10);
          
          $('#local-center-upcoming-courses').html(all_course_html);
          var course_html = _.template(upcoming_course_details_template, Drupal.settings.geo_search.all_courses.rows[0]);
        }
        else if(stat == 2){
          Drupal.settings.geo_search.all_followups = data;
          
          var viewHelpers11 = {
           checkForDayNames : function(course){
             return geoHelper.checkDayNames(course);
           }
	        }
	        _.extend(Drupal.settings.geo_search.all_followups.rows[0], viewHelpers11);
	        
	        var viewHelpers12 = {
	           checkDateDays : function(start, start_date, end , requestFor, type) {
	             return geoHelper.getCourseDateDays(start, start_date, end , requestFor, type);
	           }
	        }
	        _.extend(Drupal.settings.geo_search.all_followups.rows[0], viewHelpers12);
	        
	        var viewHelpers13 = {
	           getMonthNames : function(format_date, recur_event) {
	             return geoHelper.getMonthName(format_date, recur_event);
	           }
	        }
	        _.extend(Drupal.settings.geo_search.all_followups.rows[0], viewHelpers13);
	        
	        var viewHelpers14 = {
	           getCourseDay : function(start_date, end_date) {
	             return geoHelper.getCourseDay(start_date, end_date);
	           }
	        }
	        _.extend(Drupal.settings.geo_search.all_followups.rows[0], viewHelpers14);
	        
	        var viewHelpers15 = {
	           checkManyDay : function(start_date, end_date) {
	             return geoHelper.checkManyDay(start_date, end_date);
	           }
	        }
	        _.extend(Drupal.settings.geo_search.all_followups.rows[0], viewHelpers15);
          
          $('#local-center-follow-ups').html(all_course_html);
          var course_html = _.template(upcoming_course_details_template, Drupal.settings.geo_search.all_followups.rows[0]);
        }
        
        $('#course-details').html(course_html);
        $('.course-upcoming-row').removeClass('active-course');
        $('.course-upcoming-row:first-child').addClass('active-course');
//        a2a_add(data.rows[0]);  
        var acivateDetails = function() {
          idx = $(this).index();
          $('.course-follow-ups-lists .course-follow-ups').eq(idx).find('.course-upcoming-row:first-child').trigger('mouseenter');
        }
        $('.course-follow-ups').aol_custom_tabs({
          'tab'      : '.aol-tabs-tab ul li',
          'console'  : '.course-follow-ups-lists > div',
          'action'   : 'click',
          'callback' : acivateDetails,
        });
      }


  //Place your code here.
  Drupal.behaviors.Tabs = {
    attach: function () {
      $('.aol-bottom-tabs').aol_custom_tabs({
        'tab'     : '.aol-tabs-tab li',
        'console' : '.aol-tabs-content #tabs-content > li'
      });
      
      $('.articles-tab-wrapper').aol_custom_tabs({
        'tab'     : '.articles-tab li',
        'console' : '.articles-tab-content > li',
        'action'  : 'click'
      });
      
      $('.videos-tab-wrapper').aol_custom_tabs({
        'tab'     : '.videos-tab li',
        'console' : '.videos-tab-contnet > .box-show',
        'action'  : 'click'
      });
    }
  };

  /**
  * Attach handler.
  */
  Drupal.behaviors.ArtOfLiving = {
    attach: function (context, settings) {
      $(".megamenu.nojs").removeClass('nojs');
      $(".DropdownDivColumn:first-child").addClass("active");
      if(jQuery().menuAim) {
        $(".mega-menu").menuAim({
             activate: function(row) {
               $(row).parent().find('.DropdownDivColumn').removeClass('active');
               $(row).addClass("active");
               if ('undefined' != typeof echo) {
                 echo.render();
               } 
             },
             rowSelector: ".DropdownDivColumn",
             tolerance: 20,
             width: 165
        });
      }
      
      $('.mega-menu-holder',context).mouseenter(function() {
        if ('undefined' != typeof echo) {
          echo.render();
        }
      });

      $(document).on('mouseenter', "#CountrySelectorDropdown .DropdownDivColumn",
        function () {
//          $(this).parent().find('.DropdownDivColumn').removeClass('active');
//          $(this).addClass('active');
        }
      );
      // Run functions on screen resize
      resizeFunctions();
      $(window).resize(resizeFunctions);
      
      
      $('.question-box').each(function(){
      if ($(this).find('.up-down-arrow').length < 1) {
        $(this).append('<div class="up-down-arrow"><span class=""><span class="triangle"></span></span></div>');
      }
    });
    }
  };
  
  var mobileAdded = false;

  function mobileAdd() {
    
    if (Drupal.settings.pathPrefix && Drupal.settings.pathPrefix.indexOf("en") > 1) {
      path = "/" + Drupal.settings.pathPrefix + "apps";
    
      $('#header').prepend('<a href="' + path + '" id="apps"><div class="mobile-apps">' + Drupal.t('Our Mobile Apps') + '</div></a>');
    }
  }
  
  function mobileRemove() {
    $('#header #apps').remove();
  }
  
  
  /**
   * Run functions on screen resize
   *
   * @param {event} e
   *   The resize event.
   */
  function resizeFunctions(e) {
    // Gather the content zones.
    if (document.documentElement.clientWidth < 768 && false == mobileAdded) {
      mobileAdd();
      mobileAdded = true;
    }
    else if(document.documentElement.clientWidth >= 768 && true == mobileAdded) {
      mobileRemove();
      mobileAdded = false;
    }
    processTableToggle();
  }
  
  
  
   function processTableToggle(){
     if($('table').hasClass('stacktable')){
       $('.stacktable.large-only').each(function(){
       stkTable = $('.large-only').width();
       stkContainer = $(this).closest('#content').width();
       //console.clear();
       //console.log('table: '+stkTable+"stkContainer :"+stkContainer);
       if(stkTable < stkContainer ){
         $('.stacktable.large-only').show();
         $('.stacktable.small-only').hide();
       }
       if(stkTable > stkContainer ){
         $('.stacktable.large-only').hide();
         $('.stacktable.small-only').show();
       }
       });
     }//console.log('stakable table resize triggered');
   }
  /**
   * Apply changes to the main menu based on the width of the document.
   */
  function mainMenuProcess() {
//    $(".Menu-outer").hide();
  }
  
  function track_callback_aol(formatted_number, mobile_number){
    // formatted_number: number to display, in the same format as
    // the number passed to _googWcmGet().
    // (in this case, '1-800-123-4567')
    // mobile_number: number formatted for use in a clickable link
    // with tel:-URI (in this case, '+18001234567')
    var get_phone = '';
    if($('.track_call').length){      
      get_phone = '';
      $('.track_call').each(function() {
        get_phone = $(this);
        get_phone.href = "tel:" + mobile_number;
        get_phone.empty();
        get_phone.append(formatted_number);
      });
    }
    if($('.sidr-class-track_call').length){      
      get_phone = '';
      $('.sidr-class-track_call').each(function() {
        get_phone = $(this);
        get_phone.href = "tel:" + mobile_number;
        get_phone.empty();
        get_phone.append(formatted_number);
      });
    }
  };
  
})(jQuery, Drupal, this, this.document);
;
function isElementInViewport(el) {
    var rect = el.getBoundingClientRect();

    return rect.bottom > 0 &&
        rect.right > 0 &&
        rect.left < (window.innerWidth || document. documentElement.clientWidth) /*or $(window).width() */ &&
        rect.top < (window.innerHeight || document. documentElement.clientHeight) /*or $(window).height() */;
}

(function ($, Drupal, window, document, undefined) {
  
  Drupal.behaviors.WisdomPages = {
      attach: function () {
        $('.expand-all-q-a a.expand-all').click(function(e) {
          e.preventDefault();       
          $('.answer-box').hide();
          $('.answer-box').slideToggle(300);
          $(this).css('display','none');
          $('.expand-all-q-a a.collapse-all').css('display','inline-block');
          $('.question-answer-view').find('.question-box').find('span:first').addClass('expand');   
        });
        
        $('.expand-all-q-a a.collapse-all').click(function(e) {
          e.preventDefault();       
          $('.answer-box').show();
          $('.answer-box').slideToggle(300);  
          $(this).css('display','none');
          $('.expand-all-q-a a.expand-all').css('display','inline-block');
          $('.question-answer-view').find('.question-box').find('span:first').removeClass('expand');  
        });
        
      
        if ($('.what-sri-sri-said ul').size() > 0) {
          $(function() {
            $('.what-sri-sri-said ul').cycle({
              fx:     'fade',
              speed:  'fast',
              timeout: 0, 
              pager:  '#what-sri-sri-said-nav'
            });
          });
        }
        
      //fixing what-sri-sri-said-slider section height
        var height = 0;
        var height2 = 0;        
        jQuery(".what-sri-sri-said-slider .post-data-inner").each(function() {
         height = Math.max(height, jQuery(this).height());        
        });
              
      
        jQuery(".post-data-inner").each(function() {
           jQuery(this).height(height);
           jQuery('.arrow-left').height(height/2 + 30);
           jQuery('.arrow-right').height(height/2 + 30);
           jQuery('.arrow-left').css('padding-top',height/2);
           jQuery('.arrow-right').css('padding-top',height/2);
        });
        jQuery('.arrow-left').hide();
        jQuery('.nextControl').click(function() {
          if(jQuery('li:nth-last-child(2)').hasClass('cycle-slide-active')){
              jQuery('.arrow-right').hide();    
           }else{
             jQuery('.arrow-left').show();
           }
        });
        jQuery('.prevControl').click(function() {
          if(jQuery('li:nth-child(3)').hasClass('cycle-slide-active')){
            jQuery('.arrow-left').hide();    
         }else{
           jQuery('.arrow-right').show();
         }
        });
        
      }
  }
})(jQuery, Drupal, this, this.document);;
// Source: https://github.com/JasonSanford/GeoJSON-to-Google-Maps
var existingLatlng = [];
var GeoJSON = function( geojson, options ){
  var _geometryToGoogleMaps = function( geojsonGeometry, opts, geojsonProperties ){
    
    var googleObj;

    switch ( geojsonGeometry.type ){
      case "Point":
      	if(geojsonGeometry.coordinates != null){
      		var latlng_str = geojsonGeometry.coordinates[1]+' '+geojsonGeometry.coordinates[0];
      		// checking coordinates already present or not
      		if(existingLatlng.indexOf(latlng_str) > -1){
      			//update the position of the coincident marker by applying a small multipler to its coordinates
      			var newLat = geojsonGeometry.coordinates[1] + (Math.random() -.5) / 1500;// * (Math.random() * (max - min) + min);
      			var newLng = geojsonGeometry.coordinates[0] + (Math.random() -.5) / 1500;// * (Math.random() * (max - min) + min);
      		}else{
      			var newLat = geojsonGeometry.coordinates[1];
      			var newLng = geojsonGeometry.coordinates[0];
      		}
      		existingLatlng.push(latlng_str);
        	opts.position = new google.maps.LatLng(newLat, newLng);
	        var bounds = new google.maps.LatLngBounds();
	        bounds.extend(opts.position);
	        googleObj = new google.maps.Marker(opts);
	        googleObj.set('bounds', bounds);
	        if (geojsonProperties) {
	          googleObj.set("geojsonProperties", geojsonProperties);
	        }
	      }
        break;
        
      case "MultiPoint":
        googleObj = [];
        var bounds = new google.maps.LatLngBounds();
        for (var i = 0; i < geojsonGeometry.coordinates.length; i++){
          opts.position = new google.maps.LatLng(geojsonGeometry.coordinates[i][1], geojsonGeometry.coordinates[i][0]);
          bounds.extend(opts.position);
          googleObj.push(new google.maps.Marker(opts));
        }
        if (geojsonProperties) {
          for (var k = 0; k < googleObj.length; k++){
            googleObj[k].set("geojsonProperties", geojsonProperties);
          }
        }
        for (var k = 0; k < googleObj.length; k++) {
          googleObj[k].set('bounds', bounds);
        }
        break;
        
      case "LineString":
        var path = [];
        var bounds = new google.maps.LatLngBounds();
        for (var i = 0; i < geojsonGeometry.coordinates.length; i++){
          var coord = geojsonGeometry.coordinates[i];
          var ll = new google.maps.LatLng(coord[1], coord[0]);
          bounds.extend(ll);
          path.push(ll);
        }
        opts.path = path;
        googleObj = new google.maps.Polyline(opts);
        googleObj.set('bounds', bounds);
        if (geojsonProperties) {
          googleObj.set("geojsonProperties", geojsonProperties);
        }
        break;
        
      case "MultiLineString":
        googleObj = [];
        var bounds = new google.maps.LatLngBounds();
        for (var i = 0; i < geojsonGeometry.coordinates.length; i++){
          var path = [];
          for (var j = 0; j < geojsonGeometry.coordinates[i].length; j++){
            var coord = geojsonGeometry.coordinates[i][j];
            var ll = new google.maps.LatLng(coord[1], coord[0]);
            bounds.extend(ll);
            path.push(ll);
          }
          opts.path = path;
          googleObj.push(new google.maps.Polyline(opts));
        }
        if (geojsonProperties) {
          for (var k = 0; k < googleObj.length; k++){
            googleObj[k].set("geojsonProperties", geojsonProperties);
          }
        }
        for (var k = 0; k < googleObj.length; k++) {
          googleObj[k].set('bounds', bounds);
        }
        break;
        
      case "Polygon":
        var paths = [];
        var bounds = new google.maps.LatLngBounds();
        for (var i = 0; i < geojsonGeometry.coordinates.length; i++){
          var path = [];
          for (var j = 0; j < geojsonGeometry.coordinates[i].length; j++){
            var ll = new google.maps.LatLng(geojsonGeometry.coordinates[i][j][1], geojsonGeometry.coordinates[i][j][0]);
            bounds.extend(ll);
            path.push(ll)
          }
          paths.push(path);
        }
        opts.paths = paths;
        googleObj = new google.maps.Polygon(opts);
        googleObj.set('bounds', bounds);
        if (geojsonProperties) {
          googleObj.set("geojsonProperties", geojsonProperties);
        }
        break;
        
      case "MultiPolygon":
        googleObj = [];
        var bounds = new google.maps.LatLngBounds();
        for (var i = 0; i < geojsonGeometry.coordinates.length; i++){
          var paths = [];
          for (var j = 0; j < geojsonGeometry.coordinates[i].length; j++){
            var path = [];
            for (var k = 0; k < geojsonGeometry.coordinates[i][j].length; k++){
              var ll = new google.maps.LatLng(geojsonGeometry.coordinates[i][j][k][1], geojsonGeometry.coordinates[i][j][k][0]);
              bounds.extend(ll);
              path.push(ll);
            }
            paths.push(path);
          }
          opts.paths = paths;
          googleObj.push(new google.maps.Polygon(opts));
        }
        if (geojsonProperties) {
          for (var k = 0; k < googleObj.length; k++){
            googleObj[k].set("geojsonProperties", geojsonProperties);
          }
        }
        for (var k = 0; k < googleObj.length; k++) {
          googleObj[k].set('bounds', bounds);
        }
        break;
        
      case "GeometryCollection":
        googleObj = [];
        if (!geojsonGeometry.geometries){
          googleObj = _error("Invalid GeoJSON object: GeometryCollection object missing \"geometries\" member.");
        }else{
          for (var i = 0; i < geojsonGeometry.geometries.length; i++){
            googleObj.push(_geometryToGoogleMaps(geojsonGeometry.geometries[i], opts, geojsonProperties || null));
          }
        }
        break;
        
      default:
        googleObj = _error("Invalid GeoJSON object: Geometry object must be one of \"Point\", \"LineString\", \"Polygon\" or \"MultiPolygon\".");
    }
    
    return googleObj;
    
  };
  
  var _error = function( message ){
  
    return {
      type: "Error",
      message: message
    };
  
  };
    
  var obj;
  
  var opts = options || {};
  
  switch ( geojson.type ){
  
    case "FeatureCollection":
      if (!geojson.features){
        obj = _error("Invalid GeoJSON object: FeatureCollection object missing \"features\" member.");
      }else{
        obj = [];
        for (var i = 0; i < geojson.features.length; i++){
          obj.push(_geometryToGoogleMaps(geojson.features[i].geometry, opts, geojson.features[i].properties));
        }
      }
      break;
    
    case "GeometryCollection":
      if (!geojson.geometries){
        obj = _error("Invalid GeoJSON object: GeometryCollection object missing \"geometries\" member.");
      }else{
        obj = [];
        for (var i = 0; i < geojson.geometries.length; i++){
          obj.push(_geometryToGoogleMaps(geojson.geometries[i], opts, geojson.geometries[i].properties));
        }
      }
      break;
    
    case "Feature":
      if (!( geojson.properties && geojson.geometry )){
        obj = _error("Invalid GeoJSON object: Feature object missing \"properties\" or \"geometry\" member.");
      }else{
        obj = _geometryToGoogleMaps(geojson.geometry, opts, geojson.properties);
      }
      break;
    
    case "Point": case "MultiPoint": case "LineString": case "MultiLineString": case "Polygon": case "MultiPolygon":
      obj = geojson.coordinates
        ? obj = _geometryToGoogleMaps(geojson, opts, geojson.properties)
        : _error("Invalid GeoJSON object: Geometry object missing \"coordinates\" member.");
      break;
    
    default:
      obj = _error("Invalid GeoJSON object: GeoJSON object must be one of \"Point\", \"LineString\", \"Polygon\", \"MultiPolygon\", \"Feature\", \"FeatureCollection\" or \"GeometryCollection\".");
  
  }
  
  return obj;
};
;
(function ($) {
  Drupal.behaviors.geofieldMap = {
    attach: function(context, settings) {
      if  (geoHelper.isMobile()) {
       var height = $(window).height() * 0.8;
       $('.geofieldMap').height(height);
       for(var index in Drupal.settings.geofieldMap) { 
         if (Drupal.settings.geofieldMap.hasOwnProperty(index)) {
           Drupal.settings.geofieldMap[index].map_settings.height = height;
         }
       }
      }

      $('.geofieldMap', context).once('geofield-processed', function(index, element) {
        var data = undefined;
        var map_settings = [];
        var pointCount = 0;
        var resetZoom = true;
        var elemID = $(element).attr('id');

        if(settings.geofieldMap[elemID]) {
            data = settings.geofieldMap[elemID].data;
            map_settings = settings.geofieldMap[elemID].map_settings;
        }

        // Checking to see if google variable exists. We need this b/c views breaks this sometimes. Probably
        // an AJAX/external javascript bug in core or something.
        if (typeof google != 'undefined' && typeof google.maps.ZoomControlStyle != 'undefined' && data != undefined) {
          if ('undefined' != typeof data.geometries) {
            for (var i = 0, l = data.geometries.length; i < l; i++) {
              data.geometries[i].type = "Point"; 
            }
          }
          var features = GeoJSON(data);
          // controltype
          var controltype = map_settings.controltype;
          if (controltype == 'default') { controltype = google.maps.ZoomControlStyle.DEFAULT; }
          else if (controltype == 'small') { controltype = google.maps.ZoomControlStyle.SMALL; }
          else if (controltype == 'large') { controltype = google.maps.ZoomControlStyle.LARGE; }
          else { controltype = false }

          // map type
          var maptype = map_settings.maptype;
          if (maptype) {
            if (maptype == 'map' && map_settings.baselayers_map) { maptype = google.maps.MapTypeId.ROADMAP; }
            if (maptype == 'satellite' && map_settings.baselayers_satellite) { maptype = google.maps.MapTypeId.SATELLITE; }
            if (maptype == 'hybrid' && map_settings.baselayers_hybrid) { maptype = google.maps.MapTypeId.HYBRID; }
            if (maptype == 'physical' && map_settings.baselayers_physical) { maptype = google.maps.MapTypeId.TERRAIN; }
          }
          else { maptype = google.maps.MapTypeId.ROADMAP; }

          // menu type
          var mtc = map_settings.mtc;
          if (mtc == 'standard') { mtc = google.maps.MapTypeControlStyle.HORIZONTAL_BAR; }
          else if (mtc == 'menu' ) { mtc = google.maps.MapTypeControlStyle.DROPDOWN_MENU; }
          else { mtc = false; }

          var myOptions = {
            zoom: parseInt(map_settings.zoom),
            mapTypeId: maptype,
            mapTypeControl: (mtc ? true : false),
            mapTypeControlOptions: {style: mtc},
            zoomControl: ((controltype !== false) ? true : false),
            zoomControlOptions: {style: controltype},
            panControl: (map_settings.pancontrol ? true : false),
            scrollwheel: (map_settings.scrollwheel ? true : false),
            draggable: (map_settings.draggable ? true : false),
            overviewMapControl: (map_settings.overview ? true : false),
            overviewMapControlOptions: {opened: (map_settings.overview_opened ? true : false)},
            streetViewControl: (map_settings.streetview_show ? true : false),
            scaleControl: (map_settings.scale ? true : false),
            scaleControlOptions: {style: google.maps.ScaleControlStyle.DEFAULT}
          };

          var map = new google.maps.Map($(element).get(0), myOptions);
          settings.geofieldMap[elemID].map = map;
          var range = new google.maps.LatLngBounds();

          var infowindow = new google.maps.InfoWindow({
            content: ''
          });

          if (features.setMap) {
            placeFeature(features, map, range, settings.geofieldMap[elemID]);
            // Don't move the default zoom if we're only displaying one point.
            if (features.getPosition) {
              resetZoom = false;
            }
          } else {
            for (var i in features) {
            	if (typeof features[i] != 'undefined') {
	              if (features[i].setMap) {
	                placeFeature(features[i], map, range, settings.geofieldMap[elemID]);
	              } else {
	                for (var j in features[i]) {
	                  if (features[i][j].setMap) {
	                    placeFeature(features[i][j], map, range, settings.geofieldMap[elemID]);
	                  }
	                }
	              }
	              }
            }
          }
          settings.geofieldMap[elemID].features = features;
          settings.geofieldMap[elemID].range = range;

          if (resetZoom) {
            map.fitBounds(range);
          } else {
            map.setCenter(range.getCenter());
          }
        }

        function placeFeature(feature, map, range, settings) {
          var properties = feature.get('geojsonProperties');
          if (feature.setTitle && properties && properties.title) {
            feature.setTitle(properties.title);
          }
          feature.setMap(map);
          if (feature.getPosition) {
            range.extend(feature.getPosition());
          } else {
            var path = feature.getPath();
            path.forEach(function(element) {
              range.extend(element);
            });
          }
          if (properties && properties.description) {            
            var bounds = feature.get('bounds');
            google.maps.event.addListener(feature, 'click', function() {
              settings.activeMarker = feature;
              infowindow.setPosition(bounds.getCenter());
              infowindow.setContent(properties.description);
              infowindow.open(map); 
              var p = $('.gm-style-iw ').prev().find('> div:last-child').addClass('info-window'); 
              var q = $('.info-window').prev().find('> div:first-child').addClass('info-window-arrow1');
              var r = $('.info-window').prev().find('> div:last-child').addClass('info-window-arrow2'); 
              var s = $('.info-window-arrow1').find('> div:first-child').addClass('info-window-arrow1-inner'); 
              var t = $('.info-window-arrow2').find('> div:first-child').addClass('info-window-arrow2-inner'); 
              a2a_add2();
            });
          }
        }
      });
    }
  }
})(jQuery);

;
var geoHelper = (function ($) {
  
  /*used for mobile*/
  var map_visible = false;
  var active_tab = 0;
  
  function mapVisible(visible) {
    if ('undefined' != typeof visible) {
      map_visible = visible;
    }
    
    return map_visible;
  }
  
  function tabIsActive(active) {
    if ('undefined' != typeof active) {
      active_tab = active;
    }
    
    return active_tab;
  }
  
  function activateTab(id, ajaxBandaiForm, form) {
    $('.coldata').hide();
    $('.not-found').hide();
      //if we have emtpy menu it will be removed and message will be moved
      //to main part
      var move_to_main = false;
      if (
            $('[name=only_center]').length > 0 && $('[name=only_center]').val() == 1 ||
            $('#coldata-' + id).length > 0
          ) {
        if ($('.unity-ux').length ==0) {
          $('#coldata-' + id).show();
        }
        $('#edit-address-wrap').show();
        if ('undefined' != typeof form) {
          $("#geo-search-results").show();
        }
      }
      else {
        $('#edit-address-wrap').hide();
        move_to_main = true;
        $("#geo-search-results").hide();
      }
      tabIsActive(!move_to_main);
      
      $('.extra-content').hide();
      $('.extra-content-' + id).show();
      $('.ulh .active').removeClass('active');
      $('#colheader-' + id).addClass('active');
      $('.b-show-level').val(0);
      $('input[name="coldata['+ id +']"]').val(1);
      if (false == move_to_main && (
          $("#edit-center-autocomplete-google").val() 
          || $('input[name="center_autocomplete_google_lat"]').val()
          || $('input[name="center_id"]').length > 0
          || 'undefined' != typeof Drupal.settings.pathPrefix && Drupal.settings.pathPrefix)) {
        if ('undefined' != typeof form) {
          ajaxBandaiForm(form);
        }
      }
      else {
        currentUrl = document.location.href.split("#");
        document.location.href = currentUrl[0] + "#acol=" +id;
      }
  
      $('.empty-message').hide();
      $('.views-message').hide();
  
      if ($('#empty-message-' + id).size() > 0) {
        if (move_to_main) {
          $('#empty-message-' + id).insertAfter('#edit-address-wrap');
        }
        $('#empty-message-' + id).show();
      }
      else {
        //$('#empty-message-0').show();
      }
  
      if ($('#views-message-' + id).size() > 0) {
        if (move_to_main) {
          $('#views-message-' + id).insertAfter('#edit-address-wrap');
        }
        $('#views-message-' + id).show();
      }
  
      $('.course-desc').hide();
      if ($('#description-' + id).size() > 0) {
        $('#description-' + id).show();
      }
    
  }
  
  /**
   * 
   */
  function mobileShowHideMap(mapChange, toggle) {
    if ('undefined' == typeof toggle) {
      toggle = false;
    }
    var visible;
    Drupal.settings.aol.no_map_saved = mapVisible();
    if (true == toggle) {
      visible = mapVisible(!mapVisible());
    }
    else {
      visible = mapVisible();
    }
    
    Drupal.settings.aol.no_map = visible;
    
    if (!isMobile()) {
      return;
    }
    if ($('.aol-tabs-tab li.active').hasClass('direction')) {
      if (true === visible) {
        $('#directions-panel, #show-map').hide();
        $('#gs-map,#hide-map').show();
        $('#tabs-content').show();
        mapChange.call($('.aol-tabs-tab li.active'));
      }
      else {
        $('#directions-panel, #show-map').show();
        $('#tabs-content').show();
        $('#gs-map,#hide-map').hide();
      }
      $('#mobile-map-toggle').insertBefore('#directions-panel');
    }
    else {
      if (true === visible) {
        $('#tabs-content, #show-map').hide();
        $('#gs-map,#hide-map').show();
        mapChange.call($('.aol-tabs-tab li.active'));
      }
      else {
        $('#tabs-content, #show-map').show();
        $('#gs-map,#hide-map').hide();
      }
      $('#mobile-map-toggle').prependTo('.aol-tabs-content');
    }
  }
  
/**
 * init address autocomplete
 *
 */
  function initializeMap(inputPath, refreshFunction, triggerElement) {

    var country = Drupal.settings.aol.country;
  if(country != 'global') {
    var autoOptions = {
      componentRestrictions: {country: country}
    };
  } else {
    var autoOptions = {
//        componentRestrictions: {country: 'us'}
    };
  }
    //limit autocomplete to specific country.
    //if (Drupal.settings.aol.country) {
    //  autoOptions.componentRestrictions = {country: Drupal.settings.aol.country};
    //}
    
    if (typeof google == 'undefined') {
      return ;
    }

    var input = $(inputPath).get(0);
    if ('undefined' != typeof input) {
    	if ($(inputPath).length > 0)
    		var autocomplete = new google.maps.places.Autocomplete(input, autoOptions);
    //autocomplete.bindTo('bounds', map);
//    if ('undefined' != typeof triggerElement && $(triggerElement).length> 0) {
//      $(triggerElement).click(function() {
//        autocomplete
//      });
//    }

    //add listiner when location is changed
    google.maps.event.addListener(autocomplete, 'place_changed', function() {
      $('input[name="address_changed"]').val(0);
      input.className = '';
      var place = autocomplete.getPlace();
      if ('undefined' == typeof place || !place.geometry) {
        
         var firstResult = $(".pac-container .pac-item:first").text();

            var geocoder = new google.maps.Geocoder();
            geocoder.geocode({"address":firstResult }, function(results, status) {
                if (status == google.maps.GeocoderStatus.OK) {
                    place = results[0];
                    $('input[name="center_autocomplete_google"]').val(results[0].address_components[0].long_name);
                    $('input[name="center_autocomplete_google2"]').val(results[0].address_components[0].long_name);
                    
                    refreshPlace(place, inputPath, refreshFunction);
                }
                else {
                  if ($('input[name="center_autocomplete_google"]').val() == '') {
                    $('input[name="center_autocomplete_google-lat"]').val('');
                    $('input[name="center_autocomplete_google-lng"]').val('');
                    $('input[name="center_autocomplete_google-obj"]').val('');
                    $('input[name="center_autocomplete_google-state"]').val('');
                    refreshFunction($(input).closest("form"));
                  } else {
                    // Inform the user that the place was not found and return.
                    input.className = 'notfound';
                    if ($("#l-notfound").length < 1) {
                      $(input).after('<div id="l-notfound">' + Drupal.t("Please select location from the list") +"</div>");
                    }
                  }
                    return;
                }
            });
        
      }
      else {
        refreshPlace(place, inputPath, refreshFunction);
      }
      
      return false;
    });
    
    return autocomplete;
    }
    return null;
  }
  
  function getDistanceFromLatLonInKm(lat1,lon1,lat2,lon2) {
    var R = 6371; // Radius of the earth in km
    var dLat = deg2rad(lat2-lat1);  // deg2rad below
    var dLon = deg2rad(lon2-lon1); 
    var a = 
      Math.sin(dLat/2) * Math.sin(dLat/2) +
      Math.cos(deg2rad(lat1)) * Math.cos(deg2rad(lat2)) * 
      Math.sin(dLon/2) * Math.sin(dLon/2)
      ; 
    var c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1-a)); 
    var d = R * c; // Distance in km
    return d;
  }

  function deg2rad(deg) {
    return deg * (Math.PI/180)
  }
  
  function refreshPlace(place, inputPath, refreshFunction) {
    $("#l-notfound").remove();
    var input = $(inputPath).get(0);
      var address_components = [];
      for (var i=0,len=place.address_components.length; i<len; i++) {
        address_components[i] = $.param(place.address_components[i]);
      }
      
      try {
        var northEast = place.geometry.viewport.getNorthEast(),
        southWest = place.geometry.viewport.getSouthWest(),
        distance = Math.round(getDistanceFromLatLonInKm(northEast.lat(), northEast.lng(), southWest.lat(), southWest.lng())/2);
        if(distance < default_distance_search)
        	distance = default_distance_search;
        $('#edit-center-autocomplete-distance').val(distance);
      } catch (e) {
        
      }
      
      var encoded = $.toJSON( place );
      $('input[name="center_autocomplete_google_obj"]').val(encoded);
      $('input[name="center_autocomplete_google_lat"]').val(place.geometry.location.lat());
      $('input[name="center_autocomplete_google_lng"]').val(place.geometry.location.lng());

      $('input[name="center_autocomplete_google_obj2"]').val(encoded);
      $('input[name="center_autocomplete_google_lat2"]').val(place.geometry.location.lat());
      $('input[name="center_autocomplete_google_lng2"]').val(place.geometry.location.lng());
      
      var country = '';
      if (place.address_components) {
        country = place.address_components[place.address_components.length-1].short_name;
      }
      
      var address = '';
      if (place.address_components) {
        address = [
          (place.address_components[0] && place.address_components[0].short_name || ''),
          (place.address_components[1] && place.address_components[1].short_name || ''),
          (place.address_components[2] && place.address_components[2].short_name || '')
        ].join(' ');
      }
      //$('input[name="center_autocomplete_google').val(address);
      refreshFunction($(input).closest("form"));
  }

  function getFormParamsFromUrl(customUrl) {
      eventsOff = true;
      var wasParams = false;
      var dynamicUrl = '';
      if(typeof course_search_filter == 'undefined')
      	course_search_filter = 'ctype';
      if ('undefined' == typeof customUrl) {
        url = document.location.href;
      }
      else {
        url = customUrl;
      }

      arr = url.split('#');
     
     var cookieObj = {};
      if (arr[1]) { 
        wasParams = true;
        dynamicUrlPart = arr[1].split("&");
        for (var i=0;i<dynamicUrlPart.length;i++) {
          var tmp = dynamicUrlPart[i].split('=');
          if (tmp[0] != 'paddr') {
            if (dynamicUrl) {
              dynamicUrl += '&';
            }
            dynamicUrl +=dynamicUrlPart[i];
            switch (tmp[0]) {
            case 'ctype':
              var ctype = tmp[1].split(',');
              for (var a=0;a<ctype.length;a++) {
                if (ctype[a] != '') {
                  $('[value='+ctype[a]+']').attr('checked','checked').trigger('change');
                }
              }
							
							if(course_search_filter == 'ctype'){
	              $('.form-checkbox').each(function(){
	              	checkbox_value = $(this).val();
	              	if(tmp[1].indexOf(checkbox_value) >= 0 && $("input[value='"+checkbox_value+"']:checked").length == 0){
	              		$("input[value='"+checkbox_value+"']").attr('checked','checked').trigger('change');
	              	}
	              });
	            }
              
              break;
            case 'lat':
              $('input[name="center_autocomplete_google_lat"]').val(tmp[1]);
              cookieObj.lat = tmp[1];
              break;
            case 'lng':
              $('input[name="center_autocomplete_google_lng"]').val(tmp[1]);
              cookieObj.lng = tmp[1];
              break;
            case 'st':
              $('input[name="center_autocomplete_google_state"]').val(tmp[1]);
              break;
            case 'c':
              $('input[name="center_autocomplete_google_country"]').val(tmp[1]);
              
              break;
            case 'cshort':
              $('input[name="center_autocomplete_google_country_short"]').val(tmp[1]);
              break;
            case 'd1':
              $('input[name="courese_date_start[date]"]').val(tmp[1]);
              break;
            case 'd2':
              $('input[name="courese_date_end[date]"]').val(tmp[1]);
              break;  
            case 'd':
            case 'distance':
              $('#edit-center-autocomplete-distance').val(tmp[1]);
              break;
            case 'local':
              $('input[name="center_autocomplete_local"]').val(tmp[1]);
              
              break;
            case 'search':
            case 'sSearch':
              $('#edit-center-autocomplete-google').val(decodeURIComponent(tmp[1]));
              $('#sSearch-location').text(decodeURIComponent(tmp[1]));
              var caret = $("<i class='fa fa-caret-down'></i>");
              $('.search-box').text(decodeURIComponent(tmp[1])+ '  ').append(caret);
              cookieObj.location = tmp[1];
              break;
	    			case 'mctype':
              $('input[name="mctype"]').val(tmp[1]);
              
							if(course_search_filter == 'mctype'){
	              $('.form-checkbox').each(function(){
	              	checkbox_value = $(this).val();
	              	if(tmp[1].indexOf(checkbox_value) >= 0 && $("input[value='"+checkbox_value+"']:checked").length == 0){
	              		$("input[value='"+checkbox_value+"']").attr('checked','checked').trigger('change');
	              	}
	              });
	            }
              break;

            case 'acol':
              activateTab(tmp[1]);
              $('input[name="coldata['+ tmp[1] +']"]').val(1);
              /*
              $('.ulh .active').removeClass('active');
              $('.coldata').hide();
              $('#coldata-'+tmp[1]).show('');
              $('#coldata-'+tmp[1]).css('display', 'block');
              $('#colheader-'+tmp[1]).addClass('active');
              $('.b-show-level').val(0);
              $('input[name="coldata['+ tmp[1] +']"]').val(1);
              $('.course-desc').hide();
              $('#description-' + tmp[1]).show();*/
            }
          }
          else {
            showPopup = true;
          }
        }
        //prepare for cookie call and cakk save cookie
        cookieObj.permenent = false;
        cookieObj.country = Drupal.settings.aol.real_country;
        //console.log(cookieObj);
        save_location_cookie(cookieObj.lat,cookieObj.lng,cookieObj.location, cookieObj.permenent, cookieObj.country);
      }

      eventsOff = false;
      
      return wasParams;
    };

  function initDefaultLocation(ajaxBandaiForm, wasParams) {
    var cookie_name = 'latlngloc' + Drupal.settings.aol.real_country;
    
    var savedCookie = get_location_cookie(Drupal.settings.aol.real_country);
    
    if (/*Drupal.settings.aol.show_courses_on_first == false ||*/ true == wasParams) {
      var lat = $('input[name="center_autocomplete_google_lat"]').val();
      var lng = $('input[name="center_autocomplete_google_lng"]').val();
      var location = $('input[name="center_autocomplete_google"]').val();
      //save location cookie
      save_location_cookie(lat,lng,location, false, Drupal.settings.aol.real_country);
      ajaxBandaiForm($('#bandaid-center-course-locator-course-form'),true);

    }else if(savedCookie){
      
        lat = savedCookie.lat;
        var lng = savedCookie.lng;
        var location = savedCookie.location;
        var country = savedCookie.country; 
        $('input[name="center_autocomplete_google_lat"]').val(lat);
        $('input[name="center_autocomplete_google_lng"]').val(lng);
        $('#edit-center-autocomplete-google').val(location);
       
      $('input[name="from_cookie"]').val(1);
      ajaxBandaiForm($('#bandaid-center-course-locator-course-form'), true);
      $('input[name="from_cookie"]').val(0);
    } else {
      ajaxBandaiForm($('#bandaid-center-course-locator-course-form'), true);

      if(navigator.geolocation) {
          navigator.geolocation.getCurrentPosition(function(position) {
          var lat = position.coords.latitude;
          var lng = position.coords.longitude;
          codeLatLng(lat, lng, ajaxBandaiForm);
        });
      }
    }
  }
  
  function codeLatLng(lat, lng, ajaxBandaiForm) {
    var data;
    var geocoder = new google.maps.Geocoder();
    var latlng = new google.maps.LatLng(lat, lng);
    geocoder.geocode({'latLng': latlng}, function(results, status) {
      if (status == google.maps.GeocoderStatus.OK) {
        if (results[0]) {
         var country = '';
         for (var i = 0; i < results[0].address_components.length 
                          && country == ''; i++) {
           if (results[0].address_components[i].types[0] == 'country') {
             country = results[0].address_components[i].short_name;
           }               
         }
         //formatted address
         data = results[0].formatted_address;
         //save location cookie
         save_location_cookie(lat,lng,data, true, country);
         if (country == Drupal.settings.aol.real_country) {
           $('input[name="center_autocomplete_google_lat"]').val(lat);
           $('input[name="center_autocomplete_google_lng"]').val(lng);
           $('#edit-center-autocomplete-google').val(data);
         }
         ajaxBandaiForm($('#bandaid-center-course-locator-course-form'), true);

        }else {
        }
      } else {
      }
    });
  }

  function isMobile() {
    if($('#geo-search-results').hasClass('unity-2-ui') && $('#aol-search-tabs').hasClass('course')){
    return false;
    }
    var windowWidth = window.innerWidth;
    if  (windowWidth < 601) {
      return true;
    }
    else {
      return false;
    }
  }
  
  function getCourseDateDays(start, start_date, end, requestFor, type){
  	/* check is it a recur event or many day event */
		var englishdays = ['SUN','MON','TUE','WED','THU','FRI','SAT'];
     //var days = Drupal.t('!day-abbreviation SUN|MON|TUE|WED|THU|FRI|SAT', {'!day-abbreviation' :''}).split('|');
     if(current_lang_days !== ""){
	     var days = jQuery.parseJSON(current_lang_days);
	     days = days.current_lang_days;
	   }else{
	   	 var days = ['SUN','MON','TUE','WED','THU','FRI','SAT'];
	   }
     var weekends_value = jQuery.parseJSON(get_weekends); 

      if (type != "manyday"){
        /**
         * get the anounced day text using type parameter and check of the days in it by iterationg in to it and store founded days dividing it into catagory
         */
         weekDays = [];
         weekendDays = [];
         //var days = ['SUN','MON','TUE','WED','THU','FRI','SAT'];
         for(i=0; i<7; i++){
           if(type.toUpperCase().indexOf(days[i]) != -1){
             //if(i == 6 || i == 0){
             if(jQuery.inArray(i, weekends_value) > -1 && typeof days[i] !== "undefined"){
               //weekendDays.push(Drupal.t('!day-abbreviation '+days[i]+', {"!day-abbreviation" :""}' ));
               weekendDays.push(days[i]);
               if(!startDay){ var startDay = i;}
             }else{
               //weekDays.push(Drupal.t('!day-abbreviation '+days[i]+', {"!day-abbreviation" :""}' ));
               if(typeof days[i] !== "undefined")
               	 weekDays.push(days[i]);
               if(!startDay){ var startDay = i;}
             }
             
           }
         }
         /**
          * check the request for weekday or weekend and check is there couce announced for more than 2 days if yes return weekday or else return specific days
          */
         if(requestFor == "weekday"){    
          if(weekDays.length > 2){
            return "Weekdays";
          }
          else {
	        	if(weekDays.length > 1 && $.isArray(weekDays))
	        		weekDays = weekDays.join(', ');
            return weekDays;
          }
        }
        if(requestFor == "weekend"){
        	if(weekendDays.length > 1 && $.isArray(weekendDays))
        		weekendDays = weekendDays.join(', ');
        	return weekendDays;
        }
        if(requestFor == "startday"){ return startDay;} 
       }else{
         /**
          * in this many day event first split the days so that can be converted into date object and iterate from starting date to end date and add the day name to belonging array to display it on list
          */
        if(start != ""){
	        var combinedDates = start.split(" ");
	        if(typeof combinedDates[1] !== 'undefined'){
	          var dates = combinedDates[1].split("-");
	        }else{
	          var dates = combinedDates[0].split("-");
	        }
	        var enddate = end.split(" ");
	        
	        var startDateFormatted = dates[0]+"/"+enddate[0]+"/"+enddate[2];
	        
	        var startDateObject = new Date(startDateFormatted);
	    	}
      }
        var endDateObject = new Date(end);
        if(start_date !== '')
        	startDateObject = new Date(start_date);
        var startDate = startDateObject;
        var oneDay = 24*60*60*1000;
        var diffDays = Math.round(Math.abs((startDateObject.getTime() - endDateObject.getTime())/(oneDay)));
        //var days = ['SUN','MON','TUE','WED','THU','FRI','SAT'];
        weekDays = [];
        weekendDays = [];
        
        if(startDate.getDay() < endDateObject.getDay()){
	        while( startDate.getDay() < endDateObject.getDay()){
	         //if(startDate.getDay() ==6 || startDate.getDay() ==0){
	         if(jQuery.inArray(startDate.getDay(), weekends_value) > -1){ 
						 if(jQuery.inArray(days[startDate.getDay()], weekendDays) == -1 && typeof days[startDate.getDay()] !== "undefined")
	           	 weekendDays.push(days[startDate.getDay()]);
	           if(!startDay){ var startDay = startDate.getDay();}
	         }else{ 
	         	 if(jQuery.inArray(days[startDate.getDay()], weekDays) == -1 && typeof days[startDate.getDay()] !== "undefined")
		         	 weekDays.push(days[startDate.getDay()]);
		         if(!startDay){ var startDay = startDate.getDay();} 
	         }
	         var newDate = startDate.setDate(startDate.getDate() + 1);
	         startDate = new Date(newDate);
	        }
				}else{
					if(!startDay){ var startDay = startDate.getDay();}
					for(i=startDate.getDay(); i<=7; i++){
	        	if(jQuery.inArray(i, weekends_value) > -1){ 
							if(jQuery.inArray(days[i], weekendDays) == -1 && typeof days[i] != 'undefined')
	           		weekendDays.push(days[i]);
	        	}else{
							if(jQuery.inArray(days[i], weekDays) == -1 && typeof days[i] != 'undefined')
	         			weekDays.push(days[i]);
	         	}
					}
					for(i=1; i<=endDateObject.getDay(); i++){
	        	if(jQuery.inArray(i, weekends_value) > -1){ 
							if(jQuery.inArray(days[i], weekendDays) == -1 && typeof days[i] != 'undefined')
	           		weekendDays.push(days[i]);
	        	}else{
							if(jQuery.inArray(days[i], weekDays) == -1 && typeof days[i] != 'undefined')
	         			weekDays.push(days[i]);
	         	}
					}
					
					if(diffDays > 0 && diffDays < 7){
						if(jQuery.inArray(0, weekends_value) > -1){
            	if(jQuery.inArray(days[0], weekendDays) == -1 && typeof days[0] != 'undefined')
              	weekendDays.push(days[0]);
          	}else{
            	if(jQuery.inArray(days[0], weekDays) == -1 && typeof days[0] != 'undefined')
              	weekDays.push(days[0]);
      			}
					}
				}
        
         //if(endDateObject.getDay() ==6 || endDateObject.getDay() ==0){
         if(jQuery.inArray(endDateObject.getDay(), weekends_value) > -1){
         	 if(jQuery.inArray(days[endDateObject.getDay()], weekendDays) == -1 && typeof days[endDateObject.getDay()] !== "undefined")
           	 weekendDays.push(days[endDateObject.getDay()]); 
         }else{
         	 if(jQuery.inArray(days[endDateObject.getDay()], weekDays) == -1 && typeof days[endDateObject.getDay()] !== "undefined")
           	weekDays.push(days[endDateObject.getDay()]); 
         }
  
        if(requestFor == "weekday"){ 
          if(weekDays.length > 2){
            return Drupal.t("Weekdays");
          }
          else {
	        	if(weekDays.length > 1 && $.isArray(weekDays))
	        		weekDays = weekDays.join(', ');
            return weekDays;
          }
        }
        if(requestFor == "weekend"){
        	if(weekendDays.length > 1 && $.isArray(weekendDays))
        		weekendDays = weekendDays.join(', ');
        	return weekendDays;
        }
        if(requestFor == "startday"){ return startDay;} 
        
  }
  
  function checkManyDay(start_date, end_date){
  	var many_day = 0;
  	if(start_date !== '' && end_date !== ''){
    	var startDateObject = new Date(start_date);
  		var endDateObject = new Date(end_date);
	    var oneDay = 24*60*60*1000;
	    var diffDays = Math.round(Math.abs((startDateObject.getTime() - endDateObject.getTime())/(oneDay)));
	    //if(diffDays > 0 && diffDays < 7){
	    if(diffDays > 0){
	    	many_day = 1;
	    }
	    return many_day;
		}
  }
  
  function getCourseDay(start_date, end_date){
  	course_date = "";
  	var eng_days = ['Sunday','Monday','Tuesday','Wednesday','Thursday','Friday','Saturday'];
  	if(current_lang_months !== "")
  		var months = jQuery.parseJSON(current_lang_months);
    if(start_date !== '' && end_date !== ''){
    	//var startDateObject = new Date(start_date);
  //		var endDateObject = new Date(end_date);
      var t = start_date.split(/[- :]/);
      // Apply each element to the Date function
     
      if (t.length < 5 ) {
    	  var startDateObject = new Date(start_date);
      } else {
    	  var d = new Date(t[0], t[1]-1, t[2], t[3], t[4], t[5]);
          var startDateObject = new Date(d);
      }
      
      
      t = end_date.split(/[- :]/);
      // Apply each element to the Date function
      if (t.length < 5 ) {
    	  var endDateObject = new Date(end_date);
      } else {
    	  var d = new Date(t[0], t[1]-1, t[2], t[3], t[4], t[5]);
          var endDateObject = new Date(d);
      }
    	  
        var oneDay = 24*60*60*1000;
	    var diffDays = Math.round(Math.abs((startDateObject.getTime() - endDateObject.getTime())/(oneDay)));
	    course_date_format = Drupal.settings.aol.course_date_format;
	    course_date_format = course_date_format.trim();
	    if(typeof course_date_format == 'undefined')
		    course_date_format = 'j M';
	    if(diffDays === 0){
	    	course_date = $.format.date(startDateObject, course_date_format);
	    }else{
	    	start_date_day = $.format.date(start_date, "j");
	    	end_date_day = $.format.date(end_date, "j");
	    	start_date_month = $.format.date(start_date, "M");
	    	end_date_month = $.format.date(end_date, "M");
	    	if(start_date_month == end_date_month){
	    		if(start_date_day == end_date_day){
	    			course_date = $.format.date(startDateObject, course_date_format);
	    		}else{
	    			if(course_date_format == 'j M')
	    				course_date = $.format.date(start_date, "j") +"-"+$.format.date(end_date, "j") + " " +start_date_month;
	    			else
	    				course_date = start_date_month + " " +$.format.date(start_date, "j") +"-"+$.format.date(end_date, "j");
	    		}
	    	}else{
	    		//course_date = $.format.date(start_date, course_date_format) +" - "+$.format.date(end_date, course_date_format);
	    		course_date = $.format.date(startDateObject, course_date_format) +" - "+$.format.date(endDateObject, course_date_format);
	    	}
	    }
	    course_date = getMonthName(course_date);
	    course_date = Drupal.t(course_date);
	    if(course_date.indexOf('Every') != -1)
	    	course_date = Drupal.t('!repeats_every_interval Every !day_of_week', {'!repeats_every_interval ': '', '!day_of_week': course_date});
	  	current_language_days = Drupal.t('!day-name Sunday|Monday|Tuesday|Wednesday|Thursday|Friday|Saturday', {'!day-name' :''}).trim().split('|');
	  	for(i=0; i<7; i++){
	    	if(course_date.indexOf(eng_days[i]) != -1){
	     		course_date = course_date.replace(eng_days[i], current_language_days[i]);
	     	}
	    }
	    if(current_lang_months !== ""){
		    $.each(months,function( index, value ){
	      	if(course_date.indexOf(index) != -1){
	        	course_date = course_date.replace(index, value);
	     		}
	      });
	  	}
  	}
  	return course_date;
	}
  
	function getRecurDates(course, show_course_date){
		var recur_date = '';
		if(course.recur_event_display != '' && typeof course.recur_event_display != 'undefined'){
			recur_value = course.recur_event_display;
			recur_value = recur_value.replace('T000000','');
			recur_value = recur_value.replace('RRULE:','');
			var recur_freq = recur_value;
			recur_value = RRule.fromString(recur_value);
			recur_dates = recur_value.all();
			
			if(show_course_date == 'show_exact_date' && recur_dates != ''){
				recur_freq = recur_freq.split(';');
				var day_check = 1;
				$.each(recur_freq, function( index, value ){
					value = value.split('=');
		  		if(value[0] == 'FREQ'){
		  			if(value[1] == "WEEKLY")
		  				day_check = 7;	  
		  			else if(value[1] == "MONTHLY")  	
		  				day_check = 30;	  
		  			else if(value[1] == "YEARLY")  
		  				day_check = 365;
		  			return false;
		  		}
		  	});
				var date = new Date(recur_dates[0]);
				var startDate = date.setTime(date.getTime() + (7 * 24 * 60 * 60 * 1000));
				var endDate = date.setDate(date.getDate() + 7);
				date = new Date(date.setDate(date.getDate() + 7));
		    var oneDay = 24*60*60*1000;
		    var diffDays = Math.round(Math.abs((startDate - endDate)/(oneDay)));
		    if(diffDays > day_check)
		      recur_date = recur_dates[0].toString();
		 	}else{
				if(recur_dates == ''){
					start_date = new Date(course.start_date);
					recur_date = start_date.toString('MM dd');
				}else{
					recur_date = recur_dates[0].toString();
				}
			}
		}
		
		if(recur_date != ''){
			recur_date = recur_date.split(" ");
			var course_date_format = Drupal.settings.aol.course_date_format;
	    course_date_format = course_date_format.trim();
			if(course_date_format == 'j M')
				recur_date = recur_date[2]+' '+recur_date[1];
			else
				recur_date = recur_date[1]+' '+recur_date[2];
		}
		
		return recur_date;
  }
  
  function checkDayNames(course, recur_date) {
  	if(typeof recur_date != 'undefined')
  	 recur_date = false;
  	var eng_days = ['Sunday','Monday','Tuesday','Wednesday','Thursday','Friday','Saturday'];
  	var recur_display = '';
  	if(((show_course_date == 'info_sessions' && course.ctype != 344620) || show_course_date == 'all') && recur_date == false){
  		recur_display = getRecurDates(course, show_course_date);
  	}else if(show_course_date == 'show_exact_date' && recur_date == false){
			recur_display = getRecurDates(course, show_course_date);
  	}else{
  		if(course.recur_event_display != ''){
	  		recur_display = course.recur_event_display;
		  	recur_display = recur_display.replace('T000000','');
		  	if(recur_display.indexOf('FREQ') != -1){
			  	recur_display = RRule.fromString(recur_display.replace('RRULE:',''));
			  	recur_display = recur_display.toText();
			  	recur_display = recur_display.replace('every week on ','every ');
			  	var recur_display_index = recur_display.indexOf('until')-1;
			  	recur_display = recur_display.substring(0, recur_display_index);
			  	recur_display = Drupal.t(recur_display);
			  	if(!$('body').hasClass('api-course-search')){
				  	recur_display_split = recur_display.split(/ (.+)/);
				  	recur_display = Drupal.t('!repeats_every_interval Every !day_of_week', {'!repeats_every_interval ': '', '!day_of_week': recur_display_split[1]});
				  	current_language_days = Drupal.t('!day-name Sunday|Monday|Tuesday|Wednesday|Thursday|Friday|Saturday', {'!day-name' :''}).trim().split('|');
				  	for(i=0; i<7; i++){
				    	if(recur_display.indexOf(eng_days[i]) != -1){
				     		recur_display = recur_display.replace(eng_days[i], current_language_days[i]);
				     	}
				    }
				  }
			  	recur_display = recur_display.charAt(0).toUpperCase() + recur_display.slice(1);
			  }
		  }
	  }
  	return recur_display;
  }
  
  function getMonthName(format_date, recur_event){
  	if(typeof recur_event === 'undefined')
  		recur_event = false;
  	if(current_lang_months !== ""){
  		var months = jQuery.parseJSON(current_lang_months); 
	  	$.each(months, function( index, value ){
	  		if(format_date.indexOf(index) !== -1){
	  			format_date = format_date.replace(index, value);
	  		}
	  	});
	  }
  	
  	if(recur_event == false){
	  	var course_date_format = Drupal.settings.aol.course_date_format;
	    course_date_format = course_date_format.trim();
	  	format_date = format_date.replace(/\  /g, ' ');
	  	
  		var date_check = format_date.split(' ');
  		format_date_check = "";
  		if(date_check.length == 2){
  			if(!$.isNumeric(date_check[0]) && date_check[0].indexOf('-') == -1){
  				if(course_date_format == 'j M')
  					format_date_check = date_check[1]+' '+date_check[0];
  				else
  					format_date_check = date_check[0]+' '+date_check[1];
  			}else{
  				if(course_date_format == 'j M')
  					format_date_check = date_check[0]+' '+date_check[1];
  				else
  					format_date_check = date_check[1]+' '+date_check[0];
  			}
  		}else if(date_check.length == 5){
  			if(!$.isNumeric(date_check[0])){
  				if(course_date_format == 'j M')
  					format_date_check = date_check[1]+' '+date_check[0];
  				else
  					format_date_check = date_check[0]+' '+date_check[1];
  			}else{
  				if(course_date_format == 'j M')
  					format_date_check = date_check[0]+' '+date_check[1];
  				else
  					format_date_check = date_check[1]+' '+date_check[0];
  			}
  			
  			format_date_check = format_date_check+' - ';
  			
  			if(!$.isNumeric(date_check[3])){
  				if(course_date_format == 'j M')
  					format_date_check = format_date_check+date_check[4]+' '+date_check[3];
  				else
  					format_date_check = format_date_check+date_check[3]+' '+date_check[4];
  			}else{
  				if(course_date_format == 'j M')
  					format_date_check = format_date_check+date_check[3]+' '+date_check[4];
  				else
  					format_date_check = format_date_check+date_check[4]+' '+date_check[3];
  			}
	  	}
	  	if(format_date_check)
	  		format_date = format_date_check;
	  	
	  	/*if(course_date_format == 'j M'){
				if(!$.isNumeric(date_check[0]) && date_check[0].indexOf('-') == -1){
			  	if(format_date.indexOf(' - ') !== -1){
			  		format_date_check = format_date.split(' - ');
			  		format_date_check[0] = format_date_check[0].split(' ');
			  		format_date_check[0] = format_date_check[0][1]+' '+format_date_check[0][0];
			  		format_date_check[1] = format_date_check[1].split(' ');
			  		format_date_check[1] = format_date_check[1][1]+' '+format_date_check[1][0];
			  		format_date_check = format_date_check[0]+' - '+format_date_check[1];
			  	}else{
			  		format_date_check = format_date.split(' ');
			  		format_date_check = format_date_check[1]+' '+format_date_check[0];
			  	}
		  		format_date = format_date_check;
			  }
	  	}*/
	  }
  	return format_date;
  }

  return {
    initializeMap: initializeMap,
    getFormParamsFromUrl: getFormParamsFromUrl,
    initDefaultLocation: initDefaultLocation,
    isMobile: isMobile,
    mapVisible: mapVisible,
    mobileShowHideMap: mobileShowHideMap,
    activateTab: activateTab,
    tabIsActive: tabIsActive,
    getCourseDateDays: getCourseDateDays,
    checkDayNames : checkDayNames,
    getMonthName : getMonthName,
    getCourseDay:getCourseDay,
    checkManyDay:checkManyDay,
  }
})(jQuery);


jQuery.fn.toggleText = function (value1, value2) {
  return this.each(function () {
      var $this = jQuery(this),
          text = $this.text();

      if (text.indexOf(value1) > -1)
          $this.text(text.replace(value1, value2));
      else
          $this.text(text.replace(value2, value1));
  });
};

function initializeDirections(activeMarker) {
  directionsDisplay = new google.maps.DirectionsRenderer();
  var center_view = new google.maps.LatLng(activeMarker.position.lat(), activeMarker.position.lng());
  var mapOptions = {
    zoom:10,
    mapTypeId: google.maps.MapTypeId.ROADMAP,
    center: center_view,
  }
  map = new google.maps.Map(document.getElementById('geosearch-directions-map'), mapOptions);
  directionsDisplay.setMap(map);
  directionsDisplay.setPanel(document.getElementById('directions-panel'));
  return directionsDisplay;
}

function calcRoute(activeMarker, place, directionsService, directionsDisplay, travelMode, source, destination) {
  start = ('undefined' != typeof source) ? source : new google.maps.LatLng(place.geometry.location.lat(),place.geometry.location.lng());
  end = ('undefined' != typeof destination) ? destination : new google.maps.LatLng(activeMarker.position.lat(), activeMarker.position.lng());

  if ('undefined' != typeof start) {
    var request = {
      origin:start,
      destination:end,
      travelMode: google.maps.DirectionsTravelMode[travelMode]
    };

    directionsService.route(request, function(response, status) {
      if (status == google.maps.DirectionsStatus.OK) {
        directionsDisplay.setDirections(response);
      }
    });

    directionsDisplay.setPanel(document.getElementById('directions-panel'));
    }
  }

 function directionAuto(id, travelMode, activeMarker, place, directionsService, directionsDisplay) {
  var country = Drupal.settings.aol.country;
  if(country != 'global') {
    var autoOptions = {
      componentRestrictions: {country: country}
  };
  } else {
    var autoOptions = {
//        componentRestrictions: {country: 'us'}
    };
  }
  var input = jQuery(id).get(0);
  var autocomplete = new google.maps.places.Autocomplete(input, autoOptions);

  //add listiner when location is changed
  google.maps.event.addListener(autocomplete, 'place_changed', function() {
    input.className = '';
    place = autocomplete.getPlace();
    if (jQuery('form .travel-mode span.selected').size() > 0) {
      travelMode = jQuery('form .travel-mode span.selected').attr('rel');
    }
    calcRoute(activeMarker, place, directionsService, directionsDisplay, travelMode);
  });
}
function get_location_cookie(country){ 
  var cookie_name = 'latlngloc' + country.toLowerCase();
  if (jQuery.cookie(cookie_name) =='undefined' || jQuery.cookie(cookie_name) =='' || jQuery.cookie(cookie_name) == null){
  
  return 'undefined';
  }
  else{
    //console.log('cookie fetched');
    return JSON.parse(jQuery.cookie(cookie_name));
    }
}
function save_location_cookie(lat,lng,location, permanent, country){
// console.log('params : ','lat : ',lat,'lng : ',lng,'location : ',location, permanent, country);
 if(jQuery.type(lat) != 'undefined'){
 
  var savedCookie = get_location_cookie(country);
  if(typeof savedCookie != 'undefined'  && savedCookie !='' && null != savedCookie){
    var cookieLat = savedCookie.lat;
    var cookieLng = savedCookie.lng;
    var cookieLocation = savedCookie.location;
    var cookieCountry = savedCookie.country; 
  }else{
    var cookieLat = "";
    var cookieLng = "";
    var cookieLocation = "";
    var cookieCountry = ""; 
  }
  
  //compare the saved cookie data with the new data if didnt match replace cookie 
  if(cookieLat != lat || cookieLng != lng || cookieLocation != location || cookieCountry != country)
  {
  var cookie_name = 'latlngloc' + country.toLowerCase();
  var data = {lat: lat, lng: lng, location:location, country: country};
  jQuery.cookie(cookie_name, JSON.stringify(data));
  //console.log('cookie updated');
  };
  };
}
;
(function ($) {
  $.fn.bandaidSelect = function(opts){
    opts = $.extend({}, $.fn.bandaidSelect.defaults, opts);

    return this.each(function(){
      return new BandaidSelect(this, opts);
    });
  };
  var BandaidSelect = function(originalHtml, o){
    var $original = $(originalHtml),
    $inner, $checkboxes, $selectText, $doneButton, $subHeader,
    html = [],
    $form,
    checkboxesChanged = false;
    
    $form = $original.closest("form");
    $original.find(".bandai-select-p.tmp").remove();
    if ($original.find(".coldata-inner").length > 0) {
      $original = $original.find(".coldata-inner");
    }
    html.push('<div class="bandai-select-p"><div class="bandai-select"><div class="ux-select-title">' + Drupal.t('Select') + '</div></div></div>');
    html.push('<div class="bandai-select-inner" style="display:none"><div class="b-b-c">');
    html.push($original.html());
    html.push('</div><div class="clearfix"> </div><div class="b-b-d"><div class="yellow-button">' + Drupal.t('Done') + '</div></div></div">');
    $original.html(html.join(''));
    $original.show();
    $select = $original.find('div.bandai-select-p');
    $selectText = $original.find('div.bandai-select > div');
    $checkboxes = $original.find('input[type=checkbox]');
    $inner = $original.find('div.bandai-select-inner');
    $doneButton = $original.find('.b-b-d');
    $subHeader = $original.find('.bl-i');
    var updateSelected = function () {
      $checked = $checkboxes.filter(':checked'),
      numChecked = $checked.length;
      if (0 == numChecked) {
        $selectText.text(Drupal.t('Select to filter'));
      } else {
        $selectText.text(Drupal.t("@num Selected", {"@num": numChecked}));
      }
    };

    $select.bind({
      click: function(){
        $inner.trigger('toggle');
      }
    });

    $subHeader.find('.wi').bind({
      'click': function() {
        o.onSubHeaderToggle.call($(this).parent(), $form);
      }
    });

    $inner.bind({
      'toggle': function(){
        $inner.trigger( $(this).is(':hidden') ? 'open' : 'close' );
      },
      'open' : function() {
        checkboxesChanged = false;
        // use position() if inside ui-widget-content, because offset() won't cut it.
        var offset = $original.position(),
        top;

        // calculate positioning
        top = (offset.top+$original.outerHeight());

        $inner.css({
        position: 'absolute',
        top: top+'px',
        left: offset.left+'px',
        //width: width+'px'
        }).show();
        $(this).show();
      },
      'close': function() {
        if (!$(this).is(':hidden')) {
          $(this).hide();
          o.onClose.call(this, $form, checkboxesChanged);
        }
      }
    });
    $checkboxes.bind({
      'change': function() {
        checkboxesChanged = true;
        updateSelected();
      }
    });

    $doneButton.bind({
      'click': function() {
        $inner.trigger("close");
      }
    });
    updateSelected();

  }

  // close each select when clicking on any other element/anywhere else on the page
  $(document).bind('click', function(e){
    var $target = $(e.target);

    if(!$target.closest('div.coldata-inner').length && !($target.parent().hasClass('bandai-select')||$target.parent().hasClass('bandai-select-p'))){
      $('div.bandai-select-inner').trigger('close');
    }
  });

  // default options
  $.fn.bandaidSelect.defaults = {
    onClose: function(){},
    onSubHeaderToggle: function(){}
  };
  
})(jQuery);;
/*! jquery-dateformat 11-03-2018 */

var DateFormat={};!function(e){var O=["Sunday","Monday","Tuesday","Wednesday","Thursday","Friday","Saturday"],v=["Sun","Mon","Tue","Wed","Thu","Fri","Sat"],w=["Jan","Feb","Mar","Apr","May","Jun","Jul","Aug","Sep","Oct","Nov","Dec"],I=["January","February","March","April","May","June","July","August","September","October","November","December"],a={Jan:"01",Feb:"02",Mar:"03",Apr:"04",May:"05",Jun:"06",Jul:"07",Aug:"08",Sep:"09",Oct:"10",Nov:"11",Dec:"12"},u=/\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}\.?\d{0,3}[Z\-+]?(\d{2}:?\d{2})?/;DateFormat.format=function(){function o(e){return a[e]||e}function i(e){var a,r,t,n,s,o=e,i="";return-1!==o.indexOf(".")&&(o=(n=o.split("."))[0],i=n[n.length-1]),3===(s=o.split(":")).length?(a=s[0],r=s[1],t=s[2].replace(/\s.+/,"").replace(/[a-z]/gi,""),{time:o=o.replace(/\s.+/,"").replace(/[a-z]/gi,""),hour:a,minute:r,second:t,millis:i}):{time:"",hour:"",minute:"",second:"",millis:""}}function D(e,a){for(var r=a-String(e).length,t=0;t<r;t++)e="0"+e;return e}return{parseDate:function(e){var a,r,t={date:null,year:null,month:null,dayOfMonth:null,dayOfWeek:null,time:null};if("number"==typeof e)return this.parseDate(new Date(e));if("function"==typeof e.getFullYear)t.year=String(e.getFullYear()),t.month=String(e.getMonth()+1),t.dayOfMonth=String(e.getDate()),t.time=i(e.toTimeString()+"."+e.getMilliseconds());else if(-1!=e.search(u))a=e.split(/[T\+-]/),t.year=a[0],t.month=a[1],t.dayOfMonth=a[2],t.time=i(a[3].split(".")[0]);else switch(6===(a=e.split(" ")).length&&isNaN(a[5])&&(a[a.length]="()"),a.length){case 6:t.year=a[5],t.month=o(a[1]),t.dayOfMonth=a[2],t.time=i(a[3]);break;case 2:r=a[0].split("-"),t.year=r[0],t.month=r[1],t.dayOfMonth=r[2],t.time=i(a[1]);break;case 7:case 9:case 10:t.year=a[3];var n=parseInt(a[1]),s=parseInt(a[2]);n&&!s?(t.month=o(a[2]),t.dayOfMonth=a[1]):(t.month=o(a[1]),t.dayOfMonth=a[2]),t.time=i(a[4]);break;case 1:r=a[0].split(""),t.year=r[0]+r[1]+r[2]+r[3],t.month=r[5]+r[6],t.dayOfMonth=r[8]+r[9],t.time=i(r[13]+r[14]+r[15]+r[16]+r[17]+r[18]+r[19]+r[20]);break;default:return null}return t.time?t.date=new Date(t.year,t.month-1,t.dayOfMonth,t.time.hour,t.time.minute,t.time.second,t.time.millis):t.date=new Date(t.year,t.month-1,t.dayOfMonth),t.dayOfWeek=String(t.date.getDay()),t},date:function(a,e){try{var r=this.parseDate(a);if(null===r)return a;for(var t,n=r.year,s=r.month,o=r.dayOfMonth,i=r.dayOfWeek,u=r.time,c="",h="",l="",m=!1,y=0;y<e.length;y++){var d=e.charAt(y),f=e.charAt(y+1);if(m)"'"==d?(h+=""===c?"'":c,c="",m=!1):c+=d;else switch(l="",c+=d){case"ddd":h+=(S=i,O[parseInt(S,10)]||S),c="";break;case"dd":if("d"===f)break;h+=D(o,2),c="";break;case"j":if("j"===f)break;h+=parseInt(o,10),c="";break;case"d":if("d"===f)break;h+=parseInt(o,10),c="";break;case"D":h+=o=1==o||21==o||31==o?parseInt(o,10)+"st":2==o||22==o?parseInt(o,10)+"nd":3==o||23==o?parseInt(o,10)+"rd":parseInt(o,10)+"th",c="";break;case"M":if("M"===f)break;h+=(k=s,void 0,p=parseInt(k,10)-1,w[p]||k),c="";break;case"MMMM":h+=(M=s,void 0,g=parseInt(M,10)-1,I[g]||M),c="";break;case"MMM":if("M"===f)break;h+=(k=s,void 0,p=parseInt(k,10)-1,w[p]||k),c="";break;case"MM":if("M"===f)break;h+=D(s,2),c="";break;case"M":if("M"===f)break;h+=parseInt(s,10),c="";break;case"y":case"yyy":if("y"===f)break;h+=c,c="";break;case"yy":if("y"===f)break;h+=String(n).slice(-2),c="";break;case"yyyy":h+=n,c="";break;case"HH":h+=D(u.hour,2),c="";break;case"H":if("H"===f)break;h+=parseInt(u.hour,10),c="";break;case"hh":h+=D(t=0===parseInt(u.hour,10)?12:u.hour<13?u.hour:u.hour-12,2),c="";break;case"h":if("h"===f)break;t=0===parseInt(u.hour,10)?12:u.hour<13?u.hour:u.hour-12,h+=parseInt(t,10),c="";break;case"mm":h+=D(u.minute,2),c="";break;case"m":if("m"===f)break;h+=u.minute,c="";break;case"ss":h+=D(u.second.substring(0,2),2),c="";break;case"s":if("s"===f)break;h+=u.second,c="";break;case"S":case"SS":if("S"===f)break;h+=c,c="";break;case"SSS":h+=D(u.millis.substring(0,3),3),c="";break;case"a":h+=12<=u.hour?"PM":"AM",c="";break;case"p":h+=12<=u.hour?"p.m.":"a.m.",c="";break;case"E":h+=(b=i,v[parseInt(b,10)]||b),c="";break;case"'":c="",m=!0;break;default:h+=d,c=""}}return h+=l}catch(e){return console&&console.log&&console.log(e),a}var b,k,p,M,g,S},prettyDate:function(e){var a,r,t,n,s;if("string"!=typeof e&&"number"!=typeof e||(a=new Date(e)),"object"==typeof e&&(a=new Date(e.toString())),r=((new Date).getTime()-a.getTime())/1e3,t=Math.abs(r),n=Math.floor(t/86400),!isNaN(n))return s=r<0?"from now":"ago",t<60?0<=r?"just now":"in a moment":t<120?"1 minute "+s:t<3600?Math.floor(t/60)+" minutes "+s:t<7200?"1 hour "+s:t<86400?Math.floor(t/3600)+" hours "+s:1===n?0<=r?"Yesterday":"Tomorrow":n<7?n+" days "+s:7===n?"1 week "+s:n<31?Math.ceil(n/7)+" weeks "+s:"more than 5 weeks "+s},toBrowserTimeZone:function(e,a){return this.date(new Date(e),a||"MM/dd/yyyy HH:mm:ss")}}}()}(),jQuery.format=DateFormat.format;;
var a2a_config = a2a_config || {};
 a2a_config.no_3p = 1;
 var nocousePlainStatus = 0;
function a2a_add2($row) {
  if ('undefined' == typeof $row) {
    $row = jQuery("#gs-map .gs-popup");
  }
  if ($row.find('.a2a_kit2').length > 0) {
    $row.find('.a2a_kit2').removeClass('a2a_kit2').addClass('a2a_kit');

    var $email = $row.find('.adthis-share-email2');
    var url = $email.attr('href');

    $email.removeClass('adthis-share-email2').addClass('adthis-share-email');

    a2a_config.target = '.adthis-share-email';

    a2a_config.linkurl = 'http://www.artofliving.org' + url;
    a2a_config.menu_type = "mail";
    $email.attr({href: 'http://www.addtoany.com/share_save'});
//    a2a.init('page');
//    a2a.init('page');

    a2a_config.menu_type = a2a_config.target = undefined;
    a2a_config.target = '.a2a_kit';
    a2a_config.linkname = $row.find('.course-details-title').html();
    a2a_config.templates = {
      twitter: "${title} at ${link} via @artoflivingnow",
    };
    jQuery('#course-details #adthis-share', '#gs-map .gs-popup #adthis-share').attr({href: 'http://www.addtoany.com/share_save'});
    a2a_config.linkurl = 'http://www.artofliving.org' + url;
   // a2a.init('page');
//    a2a.init('page');
    jQuery('#course-details #adthis-share', '#gs-map .gs-popup #adthis-share').attr({href: jQuery('#course-details #adthis-share').attr('href')});


  }
}



(function ($) {
jQuery.fn.toggleText = function (value1, value2) {
  return this.each(function () {
      var $this = $(this),
          text = $this.text();

      if (text.indexOf(value1) > -1)
          $this.text(text.replace(value1, value2));
      else
          $this.text(text.replace(value2, value1));
  });
};

var ajaxBandaiFormId = 0;

var elemID = 'geosearch-map';
var centerID = 'geosearch-center-map';
var directionsID = 'geosearch-directions-map';
var courses = {'id': elemID, 'row': 'data'};
var centers = {'id': centerID, 'row': 'centers'};
var directions = {'id': directionsID, 'row': 'dir'};
var maps = [courses, centers, directions];
var eventsOff = true;

	function recalculateWidth() {
    var mollvalue = $('#edit-center-autocomplete-distance').val();
    //$('#slidebar-progress').progressbar({ value: mollvalue });
    var newProgress = Math.sqrt($('#edit-center-autocomplete-distance').val() );
    var progressWidth = parseInt($('.search-slidebar').css('width'));
    var sidebarHandleLeft = (newProgress/100)*progressWidth;
    $('#slidebar-handle').css('left', sidebarHandleLeft);
    var colorWidth = (sidebarHandleLeft/progressWidth)*100;
    $('.ui-progressbar-value').css('width', colorWidth+'%');
	}

/**
 * this function is called when course list has to be refreshed
 */
var ajaxBandaiForm = function($form, checkboxesChanged, pagination) {
  $form = $("#geo-search-main-form");
  if (false == checkboxesChanged) {
    return ;
  }
  //add country prefix
  //var path = "course-search/ajax";
  var path = Drupal.settings.aol.course_path;
//  if (Drupal.settings.pathPrefix) {
//    path = "/" + Drupal.settings.pathPrefix +path;
//  }
//  else {
//    path = "/" +path;
//  }

  $form.find('.loading-data').show();

  //if refresh happens multiple times we will show only last ones.
  //if multiple clicks happens ajax success callback will be called for each click
  //but then we going to check last click and only for last click we refresh html
  var myId ;
  do {
    myId = Math.floor((Math.random()*1000)+1);
  } while (myId == ajaxBandaiFormId);
  ajaxBandaiFormId = myId;

  if (undefined !== pagination) {
    path += "?page="+pagination;
  }

  $('.aol-tabs-tab .courses').show();
  if ($('#b-w .loader').size() > 0) {

  }
  else {
    $('#gs-plain-search').css('position', 'relative');
    $('#gs-plain-search').append('<div class="loader"></div>');
  }
  $('#b-w .loader').show();
  if ($('#b-w').hasClass('template-find-course')) {
   $('.form-checkbox').each(function() {
     var original_id = $(this).attr('id');
     if (original_id.indexOf('ux') != -1) {
       var pos = original_id.indexOf('ux');
           id = original_id.substring(0, pos);
           if($('#'+original_id).is(':checked')){

             $("#"+id).attr( "checked", true );

           }
           else{

             $("#"+id).attr( "checked", false );
           }
       //$("#" + id).val($(this).val());
     }
   });
  }

//++++++++++++++USING API TO FETCH DETAILS STARTS+++++++++++++++++++++++++++++++++++++
//************************************************************************************
var search ="";
  var lat = "";
  var lng = "";
  if(document.getElementsByName("center_autocomplete_distance").length)
  	var distance = document.getElementsByName("center_autocomplete_distance")[0].value;
  var only_center = document.getElementsByName("only_center")[0].value;
  if (distance==""){
    distance=100;
  }

  // gettign and setting acol value
arrColData=document.getElementsByClassName("b-show-level");
lenColData=arrColData.length;
var acol=0;
for(i=0;i<lenColData;i++){

  val=arrColData[i].value;
  if(val=='1'){
    // tab number. It's not in same order so can't use counter here
    fName=arrColData[i].name;
    fnLength=fName.length;
    acol=fName.substring(fnLength-2,fnLength-1);

  }

}

//we need to get check box values for a particular tab only
// so need to filter as pre id "edit-[acol]-"
tabId = "edit-"+acol+"-";

  /// ctypes
  var checkedValue=[];
  var allCourseTypes=[];
  var inputElements = document.getElementsByClassName('form-checkbox');
  for(var i=0; inputElements[i]; ++i){
      // pushing all values as per id to the allcourseType array
      if(inputElements[i].id.lastIndexOf(tabId, 0) === 0) {
        allCourseTypes.push(inputElements[i].value);
        if(inputElements[i].checked){
          checkedValue.push(inputElements[i].value);
        }
      }
     // pushing only selected values

  }
  var auto_complete=document.getElementsByName("center_autocomplete_google_obj")[0].value;
  ctype ="";
  apiCtype="";
  cshort ="";
  if (checkedValue.length==0){
    ctype="";
    apiCtype=getCtypes(allCourseTypes);
  }else{
    ctype=getCtypes(checkedValue);
    apiCtype=getCtypes(checkedValue);
  }

  function getCtypes(ctypes){
  	if(ctypes != ""){
      var ctype_ids = [];
      $.each(ctypes, function( index, value ) {
      	if(value != "")
        	ctype_ids.push(value);
      });
    }
    if(typeof ctype_ids != 'undefined' && ctype_ids != "")
    	ctype_ids = ctype_ids.join(",");
   	else
    	ctype_ids = "";
		return ctype_ids;
  }

  search_object={country:Drupal.settings.aol.country,ctype:apiCtype,language:Drupal.settings.aol.full_language,extend_to_limit:1};
  center_object={country:Drupal.settings.aol.country,type:"center",language:Drupal.settings.aol.full_language, order_by: 'weight'};

  if(Drupal.settings.aol.country == 'global'){
  	delete search_object.country;
  	delete center_object.country;
	}

	if ('undefined' != typeof Drupal.settings.aol.center_id) {
    search_object.center_id = Drupal.settings.aol.center_id;
    center_object.center_id = Drupal.settings.aol.center_id;
  }else if(typeof Drupal.settings.aol.is_ashram != "undefined" && Drupal.settings.aol.is_ashram !== null && typeof Drupal.settings.aol.is_ashram.center_nid != "undefined"){
    search_object.center_id = Drupal.settings.aol.is_ashram.center_nid;
    center_object.center_id = Drupal.settings.aol.is_ashram.center_nid;
  }

  var geocoder_flag = 0;
  if (auto_complete !=""){
    obj_auto_complete = $.parseJSON(auto_complete);
    var was = false;
    try {
      //country search
      if (obj_auto_complete.address_components[0].types[0] == "country") {
        cshort = obj_auto_complete.address_components[obj_auto_complete.address_components.length-1].short_name.toLowerCase()
        search_object={country:cshort,ctype:apiCtype,type:"country"};
        center_object={country:cshort,type:"center", order_by: 'weight'};
        was = true;
      }
    }
    catch (e) {//
    }

    search = obj_auto_complete.formatted_address;

    if (!was) {

      lat = obj_auto_complete.geometry.location.lat;
      lng = obj_auto_complete.geometry.location.lng;
      if(obj_auto_complete.address_components[obj_auto_complete.address_components.length-1].types[0] == 'country')
      	cshort = obj_auto_complete.address_components[obj_auto_complete.address_components.length-1].short_name.toLowerCase();
      search_object={country:Drupal.settings.aol.country,ctype:apiCtype,type:"search",lat:lat,lng:lng,distance:distance};
      if(cshort !== Drupal.settings.aol.country)
      	delete search_object.country;
      center_object={country:Drupal.settings.aol.country,type:"center",lat:lat,lng:lng,distance:distance, order_by: 'weight'};

      if(Drupal.settings.aol.country == 'global'){
		  	delete search_object.country;
		  	delete center_object.country;
			}

			if ('undefined' != typeof Drupal.settings.aol.center_id) {
		    search_object.center_id = Drupal.settings.aol.center_id;
		    center_object.center_id = Drupal.settings.aol.center_id;
		  }else if(typeof Drupal.settings.aol.is_ashram != "undefined" && Drupal.settings.aol.is_ashram !== null && typeof Drupal.settings.aol.is_ashram.center_nid != "undefined"){
		    search_object.center_id = Drupal.settings.aol.is_ashram.center_nid;
		    center_object.center_id = Drupal.settings.aol.is_ashram.center_nid;
		  }
    }
  }
  else {
    lat = $('input[name="center_autocomplete_google_lat"]').val();
    lng = $('input[name="center_autocomplete_google_lng"]').val();
    search = $('input[name="center_autocomplete_google"]').val();
    if(search == "" && Drupal.settings.aol.country_name != "Global")
  		search = Drupal.settings.aol.country_name;
    distance = $('#edit-center-autocomplete-distance').val();
    cshort = $('input[name="center_autocomplete_google_country"]').val();
    var ceFlag ={course:false,centers:false};
	var search_center = true;
	var combinedData={};
	aol = new AOL();
	var url ='';
    if (lat != "") {
    	geocoder_flag = 1;
    	var geocoder = new google.maps.Geocoder();
        geocoder.geocode({"address":search }, function(results, status) {
            if (status == google.maps.GeocoderStatus.OK) {
                var search_place = results[0];
                if (search_place.address_components[0].types[0] == "country") {
                	cshort = search_place.address_components[search_place.address_components.length-1].short_name.toLowerCase() ;
                	search_object={country:cshort,ctype:apiCtype,type:"country"};

                }else{
                	search_object={ctype:apiCtype,type:"search",lat:lat,lng:lng,distance:distance,extend_to_limit:1};
                }

            }
            else {
             search_object={ctype:apiCtype,type:"search",lat:lat,lng:lng,distance:distance,extend_to_limit:1};
            }
            if (cshort != '') {
            search_object.country = cshort;
        	}
        	if(lng !== ""){
	        	center_object.lat = lat;
	          	center_object.lng = lng;
	          	center_object.distance = distance;
        	}
        	if(stop_started_course == 1){
        	  	var now = new Date();
        	  	search_object.start_date_from = $.format.date(now, "yyyy-MM-dd");
        	  	search_object.start_date_to = $.format.date(new Date(now.getFullYear()+5,now.getMonth(),now.getDay()), "yyyy-MM-dd");
        	  }

        	  if(typeof Drupal.settings.aol.is_ashram != "undefined" && Drupal.settings.aol.is_ashram !== null){
        	  	search_object.country = Drupal.settings.aol.is_ashram.country_code;
        	  	center_object.country = Drupal.settings.aol.is_ashram.country_code;
        	  	search_object.language = Drupal.settings.aol.is_ashram.language_map[Drupal.settings.aol.full_language];
        	  	center_object.language = Drupal.settings.aol.is_ashram.language_map[Drupal.settings.aol.full_language];
        	  }

        	  if(typeof distance == 'undefined')
        	  	distance = Drupal.settings.aol.default_course_distance;
        		if(typeof search == 'undefined')
        	  	search = "";

        	  url = "#distance="+distance+"&sSearch="+search+"&st=&lat="+lat+"&lng="+lng+"&ctype="+ctype+"&acol="+acol+"&c="+cshort+"&cc=&d1=&d2=";

        	  if(distance){
        	    var centerDistance = Math.round(distance);   // / 1.609
        	    if(centerDistance != $('.miles-value').text()){
        	       $('#edit-center-autocomplete-distance').val(centerDistance);
        	     $('.miles-value').text(centerDistance );
        	      recalculateWidth();
        	    }
        	  }


        	  if(!$('body').hasClass('page-search-center') && (Drupal.settings.ajaxPageState.theme == 'unity2' || Drupal.settings.ajaxPageState.theme == 'unity3'))
        	  	search_center = false;

        	  //aol.course.search({country:Drupal.settings.aol.country,ctype:"courses"},testData);
        	  // searching course

        	  if(Drupal.settings.aol.country !== 'global'){
        	  	if(typeof search_object.language == 'undefined')
        	  		search_object.language = Drupal.settings.aol.full_language;
        	  	if(search_center == true && typeof center_object.language == 'undefined')
        	  		center_object.language = Drupal.settings.aol.full_language;
        	  }

						if ('undefined' != typeof Drupal.settings.aol.center_id) {
					    search_object.center_id = Drupal.settings.aol.center_id;
					    center_object.center_id = Drupal.settings.aol.center_id;
					  }else if(typeof Drupal.settings.aol.is_ashram != "undefined" && Drupal.settings.aol.is_ashram !== null && typeof Drupal.settings.aol.is_ashram.center_nid != "undefined"){
					    search_object.center_id = Drupal.settings.aol.is_ashram.center_nid;
					    center_object.center_id = Drupal.settings.aol.is_ashram.center_nid;
					  }

        	  if (only_center!="1"){
        	 		aol.course.search(search_object,formatCourse);
        	  }else{
        	    var tt={courses: [ ]};
        	   /* var res={};
        	    res= {data:tt,type:"courses"};*/

        	   formatCourse(tt);
        	  }

        	  if(search_center == true)
        	  	aol.course.search(center_object,formatCenters);
        });

    }
    else if (cshort != '') {
      search_object={ctype:apiCtype,type:"country",country:cshort};
      center_object={ctype:apiCtype,type:"center",country:cshort, order_by: 'weight'};
    }else{
    //else if(Drupal.settings.aol.country == "global"){
      if(Drupal.settings.aol.country == "global"){
        search_object.type = "userlocation";
        center_object.userlocation = true;
        if (typeof Drupal.settings.smart_ip !== 'undefined') {
          search_object.ip = Drupal.settings.smart_ip.location.ip_address;
          center_object.ip = Drupal.settings.smart_ip.location.ip_address;
        }
      }else if(typeof Drupal.settings.smart_ip !== 'undefined' && Drupal.settings.aol.country == Drupal.settings.smart_ip.location.country_code){
        search_object.type = "userlocation";
        center_object.userlocation = true;
        search_object.ip = Drupal.settings.smart_ip.location.ip_address;
        center_object.ip = Drupal.settings.smart_ip.location.ip_address;
      }
    }
  }
  if(geocoder_flag == 0){
  if(stop_started_course == 1){
  	var now = new Date();
  	search_object.start_date_from = $.format.date(now, "yyyy-MM-dd");
  	search_object.start_date_to = $.format.date(new Date(now.getFullYear()+5,now.getMonth(),now.getDay()), "yyyy-MM-dd");
  }

  if(typeof Drupal.settings.aol.is_ashram != "undefined" && Drupal.settings.aol.is_ashram !== null){
  	search_object.country = Drupal.settings.aol.is_ashram.country_code;
  	center_object.country = Drupal.settings.aol.is_ashram.country_code;
  	search_object.language = Drupal.settings.aol.is_ashram.language_map[Drupal.settings.aol.full_language];
  	center_object.language = Drupal.settings.aol.is_ashram.language_map[Drupal.settings.aol.full_language];
  }

  if(typeof distance == 'undefined')
  	distance = Drupal.settings.aol.default_course_distance;
	if(typeof search == 'undefined')
  	search = "";

  var url = "#distance="+distance+"&sSearch="+search+"&st=&lat="+lat+"&lng="+lng+"&ctype="+ctype+"&acol="+acol+"&c="+cshort+"&cc=&d1=&d2=";

  if(distance){
    var centerDistance = Math.round(distance);   // / 1.609
    if(centerDistance != $('.miles-value').text()){
       $('#edit-center-autocomplete-distance').val(centerDistance);
     $('.miles-value').text(centerDistance );
      recalculateWidth();
    }
  }

  var ceFlag ={course:false,centers:false};
  var search_center = true;
  if(!$('body').hasClass('page-search-center') && (Drupal.settings.ajaxPageState.theme == 'unity2' || Drupal.settings.ajaxPageState.theme == 'unity3'))
  	search_center = false;
   var combinedData={};
  aol = new AOL();
  //aol.course.search({country:Drupal.settings.aol.country,ctype:"courses"},testData);
  // searching course

  if(Drupal.settings.aol.country !== 'global'){
  	if(typeof search_object.language == 'undefined')
  		search_object.language = Drupal.settings.aol.full_language;
  	if(search_center == true && typeof center_object.language == 'undefined')
  		center_object.language = Drupal.settings.aol.full_language;
  }

	if ('undefined' != typeof Drupal.settings.aol.center_id) {
    search_object.center_id = Drupal.settings.aol.center_id;
    center_object.center_id = Drupal.settings.aol.center_id;
  }else if(typeof Drupal.settings.aol.is_ashram != "undefined" && Drupal.settings.aol.is_ashram !== null && typeof Drupal.settings.aol.is_ashram.center_nid != "undefined"){
    search_object.center_id = Drupal.settings.aol.is_ashram.center_nid;
    center_object.center_id = Drupal.settings.aol.is_ashram.center_nid;
  }

  if (only_center!="1"){
 		aol.course.search(search_object,formatCourse);
  }else{
    var tt={courses: [ ]};
   /* var res={};
    res= {data:tt,type:"courses"};*/

   formatCourse(tt);
  }

  if(search_center == true)
  	aol.course.search(center_object,formatCenters);
  }
  // searching courses

  // combined data which is passed to the template

  function setCourseData(data){
    if(data.type=="courses"){
    	combinedData.total = data.total;
    	combinedData.distance = data.distance;
    	combinedData.search_distance = data.search_distance;
      ceFlag.course=true;
      combinedData.data=data.data;
    }else if(data.type=="centers"){
      ceFlag.event=true;
      combinedData.centers=data.centers;
    }
    if(url.indexOf('distance') > -1 && typeof data.distance !== 'undefined' && typeof data.search_distance !== 'undefined'){
    	if(data.distance > data.search_distance){
	    	change_url = url.split("distance=");
	    	change_url_new = change_url[1].split("&");
	    	change_url_new[0] = data.distance;
	    	change_url_new = change_url_new.join("&");
	    	change_url = change_url[0]+"distance="+change_url_new;
	    	url = change_url;
	    }
    }
  	combinedData.center_flag =  false;
    if (ceFlag.course && ceFlag.event && search_center){
      if(typeof combinedData.data.rows != 'undefined' && combinedData.data.rows.length==0){
        delete combinedData.data.rows;
      }
      if (typeof combinedData.centers.rows != 'undefined' && combinedData.centers.rows.length==0){
        delete combinedData.centers.rows;
      }
      combinedData.url=url;
      if(typeof combinedData.data.rows == 'undefined' && typeof combinedData.centers.rows == 'undefined' && Drupal.settings.aol.country == 'global'){
      	combinedData.message = "Please enter a location.";
      	combinedData.center_flag =  true;
      }
      renderData(combinedData);
    }else if(ceFlag.course && search_center == false){
      if(typeof combinedData.data.rows != 'undefined' && combinedData.data.rows.length==0){
        delete combinedData.data.rows;
      }
      if(typeof combinedData.data.rows == 'undefined' && Drupal.settings.aol.country == 'global')
      	combinedData.message = "Please enter a location.";
      combinedData.centers = '';
      //combinedData.centers.rows = '';
      combinedData.url=url;
      renderData(combinedData);
    }
  }

  function formatCourse(data){
   var tt={rows:data.courses};
    var res={};
    res= {data:tt,type:"courses",total:data.total,distance:data.distance,search_distance:data.search_distance};

    if(data.distance){
	    var centerDistance = Math.round(data.distance);   // / 1.609
	    if(centerDistance != $('.miles-value').text()){
	       $('#edit-center-autocomplete-distance').val(centerDistance);
	     $('.miles-value').text(centerDistance );
	      recalculateWidth();
	    }
	  }

    setCourseData(res);
    //formatResponse(data,setCourseData,"courses");
  }
  // format api response compatioble to web version response
  function formatCenters(data){
    var tt={rows:data.courses};
    var res={};
    res= {centers:tt,type:"centers"};

    setCourseData(res);
  // formatResponse(data,setCourseData,"events")
  }



  function testData(data){
    var course_data={rows:data.courses};
    var center_data={rows:data.courses};
    var res={};

    if (only_center=="1"){
      course_data=[];
    }
    res= {data:course_data,centers:center_data,url:url};
    renderData(res);
  }

	//++++++++++++++USING API TO FETCH DETAILS ENDS+++++++++++++++++++++++++++++++++++++++
	//************************************************************************************
	// Following function renders data fatched using course search api.
	function renderData(response){
  	// following 4 lines are commented to use course search api.
 		/* $.post(
      path,
      $form.serialize(),
      function(response, status){*/
        if (typeof response == 'string') {
          response = $.parseJSON(response);
        }

        eventsOff = true;
        geoHelper.getFormParamsFromUrl(response.url);
        eventsOff = false;

        $('#' + elemID).html("");

        $('#aol-search-tabs ul#tabs-content li.direction-console, #aol-search-tabs .aol-tabs-tab ul li.direction').detach();
        $('#geosearch-directions-map').hide();
        $('#aol-search-tabs .aol-tabs-tab ul li:first-child').trigger('click');
        //$('#aol-search-tabs .aol-tabs-tab ul li.direction').detach();
        if (0 == $('.not-found').length) {
          if($('#course-banner-2').length > 0){
            $('<div class="not-found"> </div>').prependTo('#course-banner-2');
          }else{
            $('#geo-search-results').before('<div class="not-found"> </div>');
          }
       }else if(response.center_flag == true){
        	if($('#course-banner-2').length > 0){
            $('#course-banner-2').parent().append('<div class="not-found"> </div>');
          }
        }

        if (response.message || response.total > 100 || response.total == 0 || response.distance > response.search_distance) {
        	if(response.distance > response.search_distance)
        		$('.not-found').html(Drupal.t("No courses were found within specified distance above. Search has automatically increased  distance to find the nearest courses"));
        	else if(response.total > 100)
        		$('.not-found').html(Drupal.t("Showing only first 100 results, please Narrow down your search"));
        	else if(response.total == 0)
        		$('.not-found').html(Drupal.t("No search results were found. Please try expanding your search radius or selecting more course types."));
        	else
          	$('.not-found').html(response.message);
          $('.not-found').show();
        }
        else {
          $('.not-found').hide();
        }

        var viewHelpers = {
           checkForDayNames : function(course){
             return geoHelper.checkDayNames(course);
           }
        }
        _.extend(response.data, viewHelpers);

        var viewHelpers2 = {
           checkDateDays : function(start, start_date, end , requestFor, type) {
             return geoHelper.getCourseDateDays(start, start_date, end , requestFor, type);
           }
        }
        _.extend(response.data, viewHelpers2);

        var viewHelpers3 = {
           getMonthNames : function(format_date, recur_event) {
             return geoHelper.getMonthName(format_date, recur_event);
           }
        }
        _.extend(response.data, viewHelpers3);

        var viewHelpers4 = {
           getCourseDay : function(start_date, end_date) {
             return geoHelper.getCourseDay(start_date, end_date);
           }
        }
        _.extend(response.data, viewHelpers4);

        var viewHelpers5 = {
           checkManyDay : function(start_date, end_date) {
             return geoHelper.checkManyDay(start_date, end_date);
           }
        }
        _.extend(response.data, viewHelpers5);

        //1. if no results and not map show map
        //2. if state was saved at 1 and there are results hide map

        if (Drupal.settings.aol.no_map_current && typeof response.data.rows == 'undefined') {
          $('.show-map-toggle').find('.show-map-toggle a').trigger('click');
          Drupal.settings.aol.no_map_current = false;
          Drupal.settings.aol.no_map_saved = true;
        }
        else if (Drupal.settings.aol.no_map_saved && typeof response.data.rows != 'undefined') {
          $('.show-map-toggle').find('.show-map-toggle a').trigger('click');
          Drupal.settings.aol.no_map_current = true;
        }

        var no_map =   Drupal.settings.aol.no_map && !geoHelper.isMobile();
        $('.show-map-toggle .map-toggle').show();
        if (('undefined' == typeof response.data.rows) && ('undefined' == typeof response.centers.rows)) {
          $('#geo-search-results').hide();
          $('#b-w .loader, #gs-plain-search-rows').hide();
          $('#gs-plain-search-rows').html("");
          //return ;
        }
        else if(('undefined' == typeof response.data.rows) && ('undefined' != typeof response.centers.rows)) {
          $('#geo-search-results').show();
          var html = _.template(centers_rows_template, response.centers);
          $('#gs-centers-rows').html(html);

          var active_tab = 0;
          if ($('.h-b.active a').length>0) {
            active_tab = $('.h-b.active a').attr('href').substr(1);
            active_tab = active_tab.substr(8);
          }

          $('.show-map-toggle .map-toggle').hide();
          $('.courses-console').hide();
          $('.aol-tabs-tab .courses').hide();
          if ($('#empty-message-' + active_tab + ' #on-tour-schedule').length > 0) {
            $('#gs-plain-search').hide();
            $('#aol-search-tabs, #gs-map').hide()
            $('#gs-centers').hide();
            $('#geosearch-center-map').hide();
          }
          else {
            //$('#gs-plain-search-rows').html(html);


            $('.aol-tabs-tab .centers').click();
           // $('.aol-tabs-content .centers-console').show();
            $('#gs-plain-search').hide();
            $('#aol-search-tabs, #gs-map').show()
            $('#gs-centers').show();
            $('#geosearch-center-map').show();
          }
          if($('#geo-search-results').hasClass('unity-2-ui')){ // this is to modify the display for search/center when unity-2 design is selected
           // $('.centers-console').hide();
           // $('.centers').hide();
           // $('#gs-map').hide();
           // $('#s-down').hide();
           $('#course-table tbody').hide();
            $('#geo-search-results').addClass('no-clone');
            $('#around-text').text(Drupal.t('Search') + ' :');
            $('#u2-search-head').next().show();
            $('.search-box').hide();
          }
        }
        else if(('undefined' != typeof response.data.rows) && ('undefined' == typeof response.centers.rows)) {
          $('#gs-mixed').show();
          $('.aol-tabs-tab').hide();
          var html = _.template(mixed_rows_template, response.data);
          $('#gs-mixed-rows').html(html);

          var html = _.template(plain_rows_template, response.data);
          $('#gs-plain-search-rows').html(html);
          $('#gs-plain-search-rows').show();
//          $('#gs-plain-search').show();
          $('#geo-search-results').show();
          if (no_map) {
            $('#aol-search-tabs, #gs-map').hide();
            $('.map-toggle').text(Drupal.t("Show Map"));
            $('#gs-plain-search').show();
          }
          $('#geo-search-results').removeClass('no-clone');
        }
        else if (('undefined' != typeof response.data.rows) && ('undefined' != typeof response.centers.rows)) {
          $('.aol-tabs-tab').show();
          $('#geo-search-results').show();

          //Render courses
          var html = _.template(mixed_rows_template, response.data);
          $('#gs-mixed-rows').html(html);

          //Render Centers
          var html = _.template(centers_rows_template, response.centers);
          $('#gs-centers-rows').html(html);

          //Render without map
          var html = _.template(plain_rows_template, response.data);
          $('#gs-plain-search-rows').html(html);
          $('#geosearch-center-map').hide();
          if (no_map) {
            $('#aol-search-tabs, #gs-map').hide();
            $('.map-toggle').text(Drupal.t("Show Map"));
            $('#gs-plain-search').show();
            $('#gs-plain-search-rows').show();

          }
          //mapChange.call($('.aol-tabs-tab li.active'));
          $('#geo-search-results').removeClass('no-clone');
        }



        //if it is first call proparly those field will be empty so we need to create them
        if (typeof Drupal.settings.geofieldMap == 'undefined') {
          Drupal.settings.geofieldMap = new Object();
        }
        for (var i = 0; i < maps.length; i++) {
          var mapID = maps[i].id;
          var rowKey = maps[i].row;
          if ('undefined' == typeof response[rowKey]) {
            continue;
          }

          if ('undefined' == typeof response[rowKey].rows) {
            Drupal.settings.geofieldMap[mapID].data.geometries = [];
            continue;
          }


          if (typeof Drupal.settings.geofieldMap[mapID] == 'undefined') {
            Drupal.settings.geofieldMap[mapID] = new Object();
            Drupal.settings.geofieldMap[mapID].data = new Object();
          }

            //format data for map
          for (var i2 = 0; i2 < response[rowKey].rows.length; i2++) {
            if ('undefined' == typeof response[rowKey].rows[i2].properties) {
              response[rowKey].rows[i2].properties = new Object();
            }
            response[rowKey].rows[i2].properties.description = _.template(map_popup_template, response[rowKey].rows[i2]);

          }
          Drupal.settings.geofieldMap[mapID].data.geometries = response[rowKey].rows;
        }

        //remove classes so html get processed again
        $('.geofield-processed').removeClass('geofield-processed');
        $('.geofield-processed-processed').removeClass('geofield-processed-processed');
        $('#geo-search-map-placeholder').show();
        if ('undefined' != typeof response.data.rows) {
          $('#geosearch-map').show();
        }
        else {
          $('#geosearch-map').hide();
        }
        //attache bheaviors. map is going to be created
        Drupal.attachBehaviors();

        var paginateItems = function(page_num, Event) {
              var show_per_page = 5;
              //get the element number where to start the slice from
              start_from = page_num * show_per_page;
              //get the element number where to end the slice
              end_on = start_from + show_per_page;
              //hide all children elements of content div, get specific items and show them
              $('#gs-mixed-rows').children().css('display', 'none').slice(start_from, end_on).css('display', 'block');

            }
        /*
        paginateItems(0, null);

        $('.mixed-pagination').pagination({
            items: Drupal.settings.geofieldMap[elemID].data.geometries.length -1,
            itemsOnPage: 5,
            cssStyle: 'light-theme',
            onPageClick: paginateItems,
        });
         */
        if (myId == ajaxBandaiFormId) {
          var url = response.url;
          currentUrl = document.location.href.split("#");
          document.location.href = currentUrl[0] + url;
        }
        $('#b-w .loader').hide();
        //$('.coldata:visible').clone(true).appendTo('.bct-ch');
//          $(".loading-data").hide();


        // Following condition is to impliment a new style
        //new-unity-style-geo-search-results class added at geo-search-results.tpl.php please check there for more information
        if ($('#geo-search-results').hasClass('new-unity-style-geo-search-results'))
        {
          //$('.bandai-select-inner').addClass('telp');
          //$('.bandai-select-inner').remove();
          $('.coldata').hide();
          var active = $('.ulh li.active').attr('id');
          active= active.replace('header','data');

          var $item = $('#'+active).clone(true),
          text = $('.bct-ch').text();

          $item.removeAttr('id').appendTo('.bct-ch').addClass('new-unity-style-coldata').show();

          bandaidSelect = $('.new-unity-style-coldata').bandaidSelect({onClose: ajaxBandaiForm, onSubHeaderToggle: subHeaderToggle});
          $('.bct-ch .ux-select-title').text(text);
          $('.bct-ch .form-type-checkbox').each(function() {
            var input = $(this).find('input');
            input.attr('id', input.attr('id') + 'ux');
            var label = $(this).find('label');
            label.attr('for', label.attr('for') + 'ux');

            // second option for sticky header
            //var $table = $('table.course-list');
            //$table.floatThead();



          })
          $('#new-unity-style-coldata'+" label:first-child").hide();
          $('.bct-ch').addClass('new-unity-style-th');
          if($('body').hasClass('unity-ux')){
            $('.bandai-select-inner > .b-b-d > .yellow-button').after('<div class="close-course-filter">'+Drupal.t('Cancel')+'</div>');
          }

          $('.new-unity-style-th > .new-unity-style-coldata > .form-item > label:first').remove();
          $('.new-unity-style-th > .new-unity-style-coldata > .form-item > label:first').remove();


        }
       if ($('#geo-search-results').hasClass('unity-2-ui') && !$('#b-w').hasClass('template-find-center')) {
         $("#gs-map").hide();
         $("#gs-plain-search").show();
          $('#gs-plain-search').show()
          $('.coldata').hide();
          var active = $('.ulh li.active').attr('id');
          if(active){
          active= active.replace('header','data');
          }
          var $item = $('#'+active).clone(true);
          $('#course-filter').html('');
          var h4text = Drupal.t("COURSE (CLICK TO FILTER)");
          $('<h4><a id="program-tooltip" href="">'+h4text+'<i class="gear-icon"></i></a></h4>').appendTo('#course-filter');
          $item.removeAttr('id').appendTo('#course-filter').addClass('new-unity-style-coldata unity-2-filter').show();

          bandaidSelect = $('.new-unity-style-coldata').bandaidSelect({onClose: ajaxBandaiForm, onSubHeaderToggle: subHeaderToggle});
          //$('.bct-ch .ux-select-title').text(text);
          $('.unity-2-filter .form-type-checkbox').each(function() {
            var input = $(this).find('input');
            input.attr('id', input.attr('id') + 'ux');
            var label = $(this).find('label');
            label.attr('for', label.attr('for') + 'ux');

            // second option for sticky header
            //var $table = $('table.course-list');
            //$table.floatThead();



          })
          $('#new-unity-style-coldata'+" label:first-child").hide();
          $('.bct-ch').addClass('new-unity-style-th');
          if($('body').hasClass('unity-ux')){
            $('.bandai-select-inner > .b-b-d > .yellow-button').after('<div class="close-course-filter">'+Drupal.t('Cancel')+'</div>');
          }
          $('.ux-select-title').css({'opacity': '0','table-layout':'fixed','margin-top':'-23px'});
          $('.bandai-select-inner').css({'background-color':'#6aa0e4', 'padding':'20px'});
          $('.unity-2-filter > .form-item > label:first').remove();
          $('.unity-2-filter > .form-item > label:first').remove();
          if(!$('#geo-search-results').hasClass('no-clone')){
            $('#gs-plain-search-rows').show();
          }
          else if( $('#geo-search-results').hasClass('no-clone')){
            $('#gs-plain-search').show();
            //$('#gs-plain-search-rows').hide();

          }
        }

       $('#program-tooltip').click(function(event){

       event.preventDefault();
       //$('.search-box').toggle();
       //$('#course-banner-2').toggleClass('course-banner-2-added');
    });
	}
 // ); This line is commented because $post method is commetned to use course search api

}


/****************************************
 ************Events attached here********
 ****************************************/

Drupal.behaviors.Tabs = {
  attach: function (context, settings) {
    //popup marker on hover
    $('.gs-mixed-row').hover(function() {
      $(this).parent().find('.gs-mixed').removeClass('gs-mixed');
      $(this).addClass('gs-mixed');
      var i = $('.gs-mixed-row').index(this);
      activeMarker = Drupal.settings.geofieldMap['geosearch-map'].data.geometries[i];
      google.maps.event.trigger(Drupal.settings.geofieldMap['geosearch-map'].features[i], 'click');
    });

    $('.gs-centers-row',context).hover( function() {
      $(this).parent().find('.gs-mixed').removeClass('gs-mixed');
      $(this).addClass('gs-mixed');
      var i = $('.gs-centers-row').index(this);
      google.maps.event.trigger(Drupal.settings.geofieldMap['geosearch-center-map'].features[i], 'click');
    });
}};

$(function() {
   var activeMarker = null
   var directionsDisplay = {};//we need default value object
   var directionsService = {};
   if (typeof google != 'undefined') {
     directionsService = new google.maps.DirectionsService();
   }
   var map;
   var travelMode = 'DRIVING';
   var place = {};
   var mobile = false;

   Drupal.settings.aol.no_map = Drupal.settings.aol.no_map || $('body').hasClass('unity-ux') || Drupal.settings.ajaxPageState.theme == 'unity2';
   Drupal.settings.aol.no_map_current = Drupal.settings.aol.no_map_saved = Drupal.settings.aol.no_map;



  $('#edit-ashram-list').on('change', (function() {
    if ('' != $(this).val()) {
      window.location = '/' + $(this).val();
    }
  }));


  /****************************************************
   ***************initial behaviour********************
   ************check url. cookies. geocode*************
   **************************************************/

  eventsOff = true;
  var wasParams = geoHelper.getFormParamsFromUrl();
  if (false == wasParams) {
    geoHelper.activateTab(0);
  }
  eventsOff = false;

  if (geoHelper.tabIsActive()) {
    geoHelper.initDefaultLocation(ajaxBandaiForm, wasParams);
  }


  if  (geoHelper.isMobile()) {

     var height = $(window).height() * 0.8;
     for(var index in Drupal.settings.geofieldMap) {
       if (Drupal.settings.geofieldMap.hasOwnProperty(index)) {
         Drupal.settings.geofieldMap[index].map_settings.height = height;
       }
     }
     mobile = true;
     $("#gs-map").hide();
     $("#b-f").addClass("mobile");

     $(document).on('click', '#mobile-map-toggle, .mobile-show-map', function(e) {
       e.preventDefault();
       geoHelper.mobileShowHideMap(mapChange, true);
     });

     $(document).on('click', '.show-map-toggle a.map-toggle', function(e) {
      e.preventDefault();
      $('.mobile .aol-search-tabs, #gs-map').toggle();
      $(this).toggleText(Drupal.t("Hide Map"), Drupal.t("Show Map"));
      //mapChange.call($('.aol-tabs-tab li.active'));
      geoHelper.mobileShowHideMap(mapChange, true);
    });

   }

  /*********************************************
   *****************attaching events************
   ********************************************/

  $(".row-details, .row-social").on({
    mouseenter: function () {
      var id = 0;
      if ($(this).hasClass('row-social')) {
        id = $(this).attr('id').substr(8);
        return ;
      } else {
        id = $(this).attr('id').substr(4);
        $(".row-social").hide();
      }
      current_tr_id = id;
      $("#details-" + id ).show();
      a2a_add2($("#details-" + id ));

      $('.active-row').removeClass("active-row");
      $(this).addClass("active-row");

    },
    mouseleave: function () {

    }
  });


  subHeaderToggle = function($form) {
    $(this).find('.bl-i-inner').toggle();
  }
  if (!$('#geo-search-results').hasClass('new-unity-style-geo-search-results')&& !$('#b-w').hasClass('template-find-course')){
    if ($('.coldata').length > 0) {
      bandaidSelect = $('.coldata').bandaidSelect({onClose: ajaxBandaiForm, onSubHeaderToggle: subHeaderToggle});
    }
  }
  else {
    $('.coldata').hide();
  }
  if ($('input[name="center_autocomplete_google"]').length > 0) {
    geoHelper.initializeMap('input[name="center_autocomplete_google"]', ajaxBandaiForm);
  }
  if ($('input[name="center_autocomplete_google2"]').length > 0) {
    geoHelper.initializeMap('input[name="center_autocomplete_google2"]', ajaxBandaiForm);
  }

  if ($(".ulh li.active a").length > 0) {
    //header click
    //$('#empty-message-0').show();
    default_id = -1;
    default_tab = $('.ulh li.active a').attr('href').substr(1);
    default_id = default_tab.substr(8);
    if (default_id) {
    $('#empty-message-' + default_id + ',#views-message-' + default_id).show();
    }

    //  $('.course-desc').hide();
    $(document).on('click', '.ulh a', function() {
      if(!$('#geo-search-results').hasClass('unity-2-ui')){
      if (mobile==true && !$(this).closest('ul').hasClass('ulh-mobile')) {
         var ul = $('.ulh').clone();
         $(ul).addClass("ulh-mobile").find('.h-sp').remove();
         $('.ulh').after(ul);
      }

      if ($(this).closest('ul').hasClass('ulh-mobile')) {
          $('.ulh-mobile').remove();
      }
    }
      if ($(this).parent().hasClass('active')) return false;
      var href = $(this).attr('href').substr(1);
      var id = href.substr(8);

      geoHelper.activateTab(id, ajaxBandaiForm, $(this).closest('form'));


  //    else {
  //      $('#views-message-0').show();
  //    }
      return false;
    });
  }



  if (false == mobile) {
    $(document).on('click', '.show-map-toggle a.map-toggle', function(e) {
      e.preventDefault();
      $('#aol-search-tabs, #gs-map, #gs-plain-search').toggle();
      $(this).toggleText(Drupal.t("Hide Map"), Drupal.t("Show Map"));
      //mapChange.call($('.aol-tabs-tab li.active'));
      geoHelper.mobileShowHideMap(mapChange, true);
      $(".contact-inline-wrapper").each(function() {
        //$(this).height(jQuery(this).parent().height());
      });
    });
  }
  $('#advance_search_toggle').prev().hide();
  $(document).on('click', '#advance_search_toggle', function(e) {
    e.preventDefault();
    $(this).prev().toggle();
    //$(this).text('');
    $(this).toggleText("Advanced search", "Close advanced search");
  });

  $('.container-inline-date input[type="text"]').each(function() {
    $(this).after('<span class="select-date"></span>');
    $(this).next('.select-date').bind( "click", function() {
      $(this).prev().focus();
      $(this).prev().click();
    });
  });

  var mapChange = function() {
    var items = $(this).closest('ul').find('li');

    var index = $(items).index(this);
    var mapId = maps[index].id;

    //geoHelper.mobileShowHideMap(mapChange, false);

    $('.geofieldMap').hide();
    $('#'+ mapId).show();
    var map = Drupal.settings.geofieldMap[mapId].map;
    if (typeof google != 'undefined') {
      google.maps.event.trigger(map, 'resize');
      map.fitBounds( Drupal.settings.geofieldMap[mapId].range);
    }
  }
  var mapChangeWithMap = function() {
    mapChange.call(this);
    if (geoHelper.isMobile()) {
      geoHelper.mobileShowHideMap(mapChange, false);
    }
  }

  $('.aol-search-tabs').aol_custom_tabs({
    'tab'      : '.aol-tabs-tab li',
    'console'  : '.aol-tabs-content #tabs-content > li',
    'action'   : 'click',
    'callback' : mapChangeWithMap,
  });


  $('#edit-courese-date-start-datepicker-popup-0').change(function(){
    var minDate = $( "#edit-courese-date-start-datepicker-popup-0" ).datepicker("getDate");
    $( "#edit-courese-date-end-datepicker-popup-0" ).datepicker( "option", "minDate", new Date(minDate));
  });

  $('#edit-center-autocomplete-distance, #edit-courese-date-start-datepicker-popup-0, #edit-courese-date-end-datepicker-popup-0, #edit-find-course-for-adults, #edit-find-course-for-teens, #edit-find-course-for-child').change(function(){
    if (false == eventsOff) {
      if ($(this).attr('id') == 'edit-center-autocomplete-distance') {
        //we reset this only if location has changed
        $('input[name="address_changed"]').val(1);
      }
      ajaxBandaiForm($(this).closest('form'));
    }
  });

  $('#edit-submit').click(function(e) {
    e.preventDefault();
  });




  /***************************************************
   *********************directions********************
   **************************************************/

      //Get direction functionality
  $(document).on('click', '.get-direction', function(e) {
    e.preventDefault();
    var items = $('.aol-tabs-tab li');
    var index = items.index($('.aol-tabs-tab li.active'));
    var mapId = maps[index].id;
    activeMarker = Drupal.settings.geofieldMap[mapId].activeMarker;
    directionsDisplay = initializeDirections(activeMarker);

    $('#geo-search-map-placeholder .geofieldMap').hide();
    $('#geosearch-directions-map').show();
    //$('#gs-map').show();


    addr = activeMarker.geojsonProperties.description;

    var description = $(addr);
    description.find('.gs-mixed-line3').remove();
    dirForm = _.template(geo_direction_template, {currentAddress : $(addr).find('.gs-mixed-line1').text(), 'description' : description.html()});

    if(($('#aol-search-tabs ul#tabs-content .direction-console').size() < 1) && ($('#aol-search-tabs .aol-tabs-tab ul li.direction').size() < 1)) {
      $('#aol-search-tabs ul#tabs-content').append('<li class="direction-console" style="display: list-item;"></li>');
      $('#aol-search-tabs .aol-tabs-tab ul').append('<li class="direction"><a href="#">Direction</a></li>');
    }

    $('#aol-search-tabs ul#tabs-content .direction-console').html(dirForm);
    $('#aol-search-tabs .aol-tabs-tab ul li.direction').show();

    $('.aol-search-tabs').aol_custom_tabs({
      'tab'      : '.aol-tabs-tab li',
      'console'  : '.aol-tabs-content #tabs-content > li',
      'action'   : 'click',
      'callback' : mapChange,
    });
    $('#aol-search-tabs .aol-tabs-tab ul li.direction').trigger('click');
    directionAuto('#source_direction', travelMode, activeMarker, place, directionsService, directionsDisplay);
  })

  $(document).on('click',  'form .travel-mode span', function(e) {
    $('form .travel-mode span').removeClass('selected');
    $(this).addClass('selected');
    travelMode = $(this).attr('rel');
    calcRoute(activeMarker, place, directionsService, directionsDisplay, travelMode);
  });

  $(document).on('click', '#gs-directions .destination_switch', function() {
    src = $("div#dst-address .directions-input");
    $("div#dst-address .directions-input").detach();
    $("div#src-address .directions-input").detach().appendTo("div#dst-address");
    $(src).appendTo("div#src-address");

    switch_end = ('undefined' != typeof start) ? start : new google.maps.LatLng(place.geometry.location.lat(),place.geometry.location.lng());
    switch_start = ('undefined' != typeof end) ? end : new google.maps.LatLng(activeMarker.position.lat(), activeMarker.position.lng());
    if ($('form .travel-mode span.selected').size() > 0) {
      travelMode = $('form .travel-mode span.selected').attr('rel');
    }
    calcRoute(activeMarker, place, directionsService, directionsDisplay, travelMode, switch_start, switch_end);
  });

  $(document).ready(function() {
  	if($('#country-center-tab').length){
  		$('.form-item-center-autocomplete-google').css('margin', '0px');
		  $('.form-item-center-autocomplete-google  > label').hide();
		  $('#country-center-tab').css('background', '#6AA0E4');
		  $('#course-banner-3').hide();
		  $(".international-centers-content").show();
  	}
  });

});

eventsOff = false;

//google.maps.event.addDomListener(window, 'load', initialize);

})(jQuery);
;
(function ($, Drupal, window, document, undefined) {
  var ajaxBandaiFormId = 0;
  $(function() {
  
    var val = $('#edit-center-autocomplete-distance').val();
    var progressWidth = parseInt($('.search-slidebar').css('width'));
    $('#slidebar-handle').css('left',  Math.sqrt(val)*1.5/100*progressWidth  + "px");
    $('.miles-value').text($('#edit-center-autocomplete-distance').val());
    function recalculateWidth() {
      var progressWidth = parseInt($('.search-slidebar').css('width'));
      var newProgress = ((parseInt($('#slidebar-handle').css('left'))) / progressWidth) * 100;
      $('#slidebar-progress').progressbar({ value: newProgress });
      $('#edit-center-autocomplete-distance').val(Math.round( newProgress/1.5 * newProgress/1.5 ));
      $('.miles-value').text(Math.round($('#edit-center-autocomplete-distance').val() ));
        
    }
    
    function dragStop() {
      $('#edit-center-autocomplete-distance').change();
    }
      // course search draggable slidebar
    // TODO: fix handle position after resizing screen
    $('#slidebar-progress').progressbar({ value: $('#edit-center-autocomplete-distance').val() }); // default position
    $('#slidebar-handle').draggable({
      containment: '#slidebar-container',
      drag: recalculateWidth,
      scroll: false,
      stop: dragStop,
    });
    
    $('.search-box').click(function(){
      $(this).parent().next().show();
      $(this).hide();
    });
    $('.show-map-toggle').hide();
    //$('.not-found').prependTo('.message-box');
  });
  $(function() {
  $('.search-miles').click(function(){
    $('.miles-value').hide();
    $('.search-slidebar').hide();
    $('.miles-text').val(parseInt($('.miles-value').text()));
    $('.miles-text').show();
  });

  jQuery('.miles-text').change(function(){
    $('#edit-center-autocomplete-distance').val($('.miles-text').val());
    $('#edit-center-autocomplete-distance').change();
  });
  });
})(jQuery, Drupal, this, this.document);;
