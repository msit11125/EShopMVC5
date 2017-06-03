$(function(){
    var json=[];
    var jsonimg=[];
    var exhibition=[]; 
    var currentproject;  
    var result;

       //event list
        function build(data,season){
            var html="";
            for (var i=0,k=data.length;i<k;i++) {
 
                if (data[i].season == season) { 
                   
                    $.each(data, function () {
                          var exhibition_title = data[i].location;
                            // console.log(data);
                             //https://api.jquery.com/jQuery.inArray/
                          if ($.inArray(exhibition_title, exhibition) == -1) {
                              exhibition.push(exhibition_title);
                              //console.log(exhibition_title);
                              html+="<a href=\"exhibition_list.html?project=" + data[i].project +"\"" + " data-project=\""+ data[i].project +"\">";
                              html+= data[i].location +"</a>";
                          }
                    });
                }

          }
          return html;
        }

        
        $.getJSON('js/data/exhibition.json',function(data){
            json=data;
            for(var i=0;i<4;i++){
              $(".content").eq(i).html(build(data, i));
            };
        });

        $.getJSON('js/data/exhibition_img.json',function(data){
            jsonimg=data;

             $(".section a").mouseover(function(){

                currentproject = $(this).attr("data-project");
                filterphoto(); 
                //console.log(id_photo);
             });
            //取season1 第一個展覽的圖片為進版圖片
            id0_photo =data[0].photo; 
            id0_location =data[0].title;
            $(".right_box.event img").attr("src",id0_photo);
            $(".right_box.event span").html(id0_location);
            
        });

        //過濾 滑鼠指的項目取 project 對照同project取圖片及文字 
        function filterphoto(){
            result = jsonimg.filter(function(a) {
                             return a.project == currentproject;
                          })[0];
           
            id_photo =result.photo; 
            id_location =result.location;
            $(".right_box.event img").attr("src",id_photo);
            $(".right_box.event span").html(id_location);

        }

       
      
         


});