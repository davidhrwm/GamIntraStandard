// Version 2017.3.16.1A

$(document).ready(function () {
    $("#login-user").focus();
    var cont = 0;

var menu = false;
  $("#btnMenu").click(function(){
    //alert("s");
    if (menu == true) {
      $(".menum").velocity({ opacity: 0, top: "100%" }, { duration: 500 });
      menu = false;
    }else {
      $(".menum").velocity({ opacity: 1, top: "0%" }, { duration: 500 });
      menu = true;
    }

  });

  $("#cerrarmenu").click(function(){
    //alert("Aqui");
    $(".menum").velocity({ opacity: 0, top: "100%" }, { duration: 500 });
    menu = false;
  });

  var cont = 0;

  $("body").keypress(function (e) {
      if (e.which == 13) {
          if (cont != 1 && ($("#login-user").val().trim() != "")) {
              cont++;

              $("#login-user").velocity({ opacity: 0, translateX: "-250px" }, {
                  duration: 500, display: "none", complete: function () {
                      $("#login-pass").css({ "display": "block" });
                      $("#login-pass").velocity({ opacity: 1, translateX: "0px" }, { duration: 500, complete: function () { $("#login-pass").focus(); } });
                  }
              });


          } else if (cont >= 1 && ($("#login-pass").val().trim() != "")) {


              $("#login-btn").attr("type", "submit");


          }
      }
  });

  $("#login-btn").click(function (e) {

      if (cont != 1 && ($("#login-user").val().trim() != "")) {
          cont++;

          $("#login-user").velocity({ opacity: 0, translateX: "-250px" }, {
            duration: 500, display: "none", complete: function () {
                $("#login-pass").css({ "display": "block" });
                $("#login-pass").velocity({ opacity: 1, translateX: "0px" }, { duration: 500, complete: function () { $("#login-pass").focus();} });
            }
          });
          
        

      } else if (cont >= 1 && ($("#login-pass").val().trim() != "")) {

            
          $("#login-btn").attr("type", "submit");
         

      }
  });

  $(".home-agenda-btnatras").click(function(){
    //alert("Aqui");
    $(".home-agenda-animate").velocity({ opacity: 0, translateX: "-2000px" }, { duration: 500, complete: function() {
      //$(".home-agenda-animate").css({"opacity": "0", "transform": "translate(1500px,0px)"});
      $(".home-agenda-animate").velocity({ opacity: 0, translateX: "2500px" }, { duration: 1, complete: function() {

        $(".home-agenda-animate").velocity({ opacity: 1, translateX: "0px" },{ duration: 500});

      }});
    }});
  });

  $(".home-agenda-btndelate").click(function(){
    //alert("Aqui");
    $(".home-agenda-animate").velocity({ opacity: 0, translateX: "2000px" }, { duration: 500, complete: function() {
      //$(".home-agenda-animate").css({"opacity": "0", "transform": "translate(1500px,0px)"});
      $(".home-agenda-animate").velocity({ opacity: 0, translateX: "-2500px" }, { duration: 1, complete: function() {

        $(".home-agenda-animate").velocity({ opacity: 1, translateX: "0px" },{ duration: 500});

      }});
    }});
  });

});
