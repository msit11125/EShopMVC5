$(function(){
        var json=[];
        var html="";

        //getJSON data to youtube list
        function youtubelist(data){
            for(var i=0;i<data.length;i++){
                html+="<a href=\"" + data[i].url + "\">" + data[i].title +"</a>"; 
            }
            $(".right_box.movie").html(html);
        }

        //getJSON data
        $.getJSON("js/data/youtube.json",function(data){
            json=data;
            youtubelist(json);
            youtubeclick();

        });

        //get youtube url id to iframe and click first film
        function youtubeclick(){
            $(".right_box.movie a").click(function(e){
                var _youtubeurl=$(this).attr("href");
                var _string=_youtubeurl.substr(32,42);//get youtube id
                var _youtubehref="https://www.youtube.com/embed/"+_string+"?rel=0";
                $(".video-container iframe").attr("src",_youtubehref);
                $(this).addClass("clicked").siblings().removeClass("clicked");

                return false;
            });
            $(".right_box.movie a").eq(0).click();
        }
        
    });