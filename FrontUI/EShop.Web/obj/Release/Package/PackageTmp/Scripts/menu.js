$(function(){

     //header navigator
    function header_nav_opensub(){
        $(".navigator li.event").mouseover(function(){
                $(".navigator li.event").toggleClass('clicked');
                $(".navigator ul.event_sub").toggle();
        }).mouseout(function(){
                $(".navigator li.event").toggleClass('clicked');
                $(".navigator ul.event_sub").toggle();
        });
        $(".navigator li.media").mouseover(function(){
                $(".navigator li.media").toggleClass('clicked');
                $(".navigator ul.media_sub").toggle();
        }).mouseout(function(){
                $(".navigator li.media").toggleClass('clicked');
                $(".navigator ul.media_sub").toggle();
        });
        // m header navigator  .navigator_box
        $(".navigator_box button").click(function(){
            $(".header .navigator_main").toggleClass('open'); 
            $(".header .navigator_box").toggleClass('clicked');
        });
    };



    header_nav_opensub();


});