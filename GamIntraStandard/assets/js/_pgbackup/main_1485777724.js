$(document).ready(function(){
var menu = false;
  $("#btnMenu").click(function(){
    //alert("Aqui");
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
});
