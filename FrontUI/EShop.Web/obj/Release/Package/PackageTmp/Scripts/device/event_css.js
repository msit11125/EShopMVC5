   //判斷裝置套用的CSS
      var w = screen.width;
      var h = screen.height;
      var url = location.search;
      var agent = navigator.userAgent.toLowerCase();
      var mobile_css ="<link rel=\"stylesheet\" type=\"text/css\" href=\"css/m_event.css\" />"
      var desktop_css ="<link rel=\"stylesheet\" type=\"text/css\" href=\"css/event.css\" />"

      if(agent.match("iphone")) {
               //console.log("iphone");
               document.write(mobile_css);
      }else if(agent.match("android")){
              if(w==800 && h==1280 || w==1280 && h==800 ){
                // console.log("tablet");
                document.write(mobile_css);
              }else{
                // console.log("android phone");
                document.write(mobile_css);
              };
      }else if(agent.match("ipad")){
              // console.log("ipad");
              document.write(mobile_css);
      }else{
      		  // console.log("desktop");
      	 	  document.write(desktop_css);
      }