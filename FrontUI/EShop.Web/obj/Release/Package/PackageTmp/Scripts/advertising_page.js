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
          id_title =result.title;
        }

        //取photo array & location & name寫入DOM
        function galleryimg(data){
          for(var i=0; i< data.length;i++){             
              html+="<img src=\""+ data[i] +"\">";
          }
          $(".gallery").html(html);
          $(".gallery-nav").html(html);
          $('.title2').append(id_title);
          $('.name').append(id_name);
        }

        $.getJSON('js/data/advertising.json',function(data){
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