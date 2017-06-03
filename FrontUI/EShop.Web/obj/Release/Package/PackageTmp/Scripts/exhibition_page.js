$(function(){
    var json=[];
    //var arr_photo=[];
    var html="";
    var pageid = getUrlVars()["id"];  

        //從網址取id value
        function getUrlVars() {
          var vars = {};
          var parts = window.location.href.replace(/[?&]+([^=&]+)=([^&]*)/gi, function(m,key,value) {
          vars[key] = value;
          });
          return vars;
        }
        
        //取json 同 id 的 photo array 
        function filterphoto(){
          var result = json.filter(function(a) {
                           return a.id == pageid;
                        })[0];
          id_photo =result.photo; //這裡就是照片的陣列了
          id_name =result.name;
          id_location =result.location;
          id_project =result.project;

          $('.btn').attr("href","exhibition_list.html?project=" + id_project);
          //console.log(id_project);
        }

        //取photo array & location & name寫入DOM
        function galleryimg(data){
          for(var i=0; i< data.length;i++){             
              html+="<img src=\""+ data[i] +"\">";
          }
          $(".gallery").html(html);
          $(".gallery-nav").html(html);
          $('.location').append(id_location);
          $('.name').append(id_name);

        }

        $.getJSON('js/data/exhibition.json',function(data){
           json=data;
           filterphoto();
           galleryimg(id_photo);
            
           console.log(id_name);

            //console.log(arr_photo);

              $('.gallery').slick({
                  slidesToShow: 1,
                  slidesToScroll: 1,
                  arrows: true,
                  fade: true,
                  asNavFor: '.slider-nav'
              });
              $('.gallery-nav').slick({
                  slidesToShow: 4,
                  slidesToScroll: 4,
                  asNavFor: '.gallery',
                 //dots: true,
                  centerMode: false,
                  arrows: false,
                  focusOnSelect: true
              });


        });


});