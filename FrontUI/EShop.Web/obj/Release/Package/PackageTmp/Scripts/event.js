$(function(){
    var json=[];
       
       //event list
        function build(data,parent){
          var html="";
           for (var i=0,k=data.length;i<k;i++) {
            if (data[i].parent == parent) {        
              html+="<a href=\"event_page.html?id=" + data[i].id +"\"";
              html+="data-img=\"" +data[i].photo[0] +"\""+ "data-word=\"@"+ data[i].year +data[i].location + "\">";
              html+= data[i].location +"</a>";
            }
          }
          return html;
        }


        $.getJSON('js/data/event.json',function(data){
            json=data;
            for(var i=0;i<4;i++){
              $(".content").eq(i).html(build(data, i));
            };
            pic();

        });


        function pic(){
            $(".section a").mouseover(function(){
              var dataimg = $(this).attr("data-img");
              var dataword = $(this).attr("data-word");
              $(".right_box.event img").attr("src",dataimg);
              $(".right_box.event span").html(dataword);
            });
            //先選出第一張
            var firstword=$(".section a").first().attr("data-word");
            var firstimg=$(".section a").first().attr("data-img");
            //alert(firstimg);
            $(".right_box.event img").attr("src",firstimg);
            $(".right_box.event span").html(firstword);
        }



});