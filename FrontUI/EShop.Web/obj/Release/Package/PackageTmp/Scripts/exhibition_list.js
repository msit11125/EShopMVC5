$(function(){
    var json=[];
    var html="";
    var urlproject = getUrlVars()["project"];
    var val;
    var result_year=[];
    var result=[];
    var getyear;

    //alert(urlproject);
     //從網址取project參數
    function getUrlVars() {
            var vars = {};
            var parts = window.location.href.replace(/[?&]+([^=&]+)=([^&]*)/gi, function(m,key,value) {
            vars[key] = value;
        });
            return vars;
    }


       //event company list
        function buildjson(data){

            //從網址取project參數過濾原json後 存入 result成新物件
           result = json.filter(function(a) {
                           return a.project == urlproject;
                        });
           //console.log(result);

           //取sub_title value
           pj_loaction = result[0].location;
            //console.log( pj_loaction);
            //寫入sub_title
           $(".location_title").append(pj_loaction);

           //存該project 年份的陣列
           var g_YearsArray = [];

            //各年分取一存入result
            $.each(result, function (index) {
                var iYear = result[index].year;
                   //console.log(iYear);
                   //https://api.jquery.com/jQuery.inArray/
                if ($.inArray(iYear, g_YearsArray) == -1) {
                    g_YearsArray.push(iYear);
                    // console.log(iYear);
                }
            });
            //年份陣列由大到小排列
            g_YearsArray.sort(function(a, b){return b-a});
            //console.log(g_YearsArray[0]);

            getyear = g_YearsArray[0];

            getresultyear();
            
            
           

            //將陣列寫入下拉選單
            $.each(g_YearsArray, function (i) {
                $("#DropDown_Year").append('<option value="' + g_YearsArray[i] + '">' + g_YearsArray[i] + '</option>');
            });


          }
           
        function getresultyear(){
          //取最新的年份的物件
            result_year = result.filter(function(a) {
                           return a.year == getyear;   
                        });
            //console.log(result_year);
        }

       
  
        //寫入頁面
        function htmlpg(){

            for (var i=0,k=result_year.length;i<k;i++) {
              html+= "<a href=\"exhibition_page.html?id=" + result_year[i].id +"\">";
              html+= "<span>" + result_year[i].name +"</span>";
              html+= "<img src=\"" + result_year[i].photo[0] + "\"";
              html+= "</a>";
            }
           // console.log(result_year);
           // return html;
          $(".company").html(html);
          console.log(html);

        }

        $(document).on('change', "#DropDown_Year", function() {
          val = $(this).val();
                getyear = val;
                getresultyear();
                $(".company").empty();
                html="";
                //console.log(html);
                htmlpg();

        });


        $.getJSON('js/data/exhibition.json',function(data){
           json=data;
           htmlpg(buildjson(getresultyear(result_year)));
          //console.log(result_year);
        });


});