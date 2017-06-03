$(function(){
        var json=[];
        var html="";

        //getJSON data to youtube list
        function sketchfablist(data){
            for(var i=0,k=data.length;i<k;i++){
                html+="<a href=\"" + data[i].url + "\">" + data[i].title +"</a>"; 
            }
            $(".right_box.sketchfab").html(html);
        }

        //getJSON data
        $.getJSON("js/data/sketchfab.json",function(data){
            json=data;
            sketchfablist(json);
            sketchfabclick();
        });

        //get sketchfab url id to iframe and click first film
        function sketchfabclick(){
            $(".right_box.sketchfab a").click(function(e){
                var _sketchfaburl=$(this).attr("href");
                var _sketchfabhref=_sketchfaburl+"/embed";
                $(".sketchfab-container iframe").attr("src",_sketchfabhref);
                 $(this).addClass("clicked").siblings().removeClass("clicked");
                return false;

            });
            $(".right_box.sketchfab a").eq(0).click();
            
        }
         
});