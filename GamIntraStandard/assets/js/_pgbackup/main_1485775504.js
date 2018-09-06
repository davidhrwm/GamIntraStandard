$(document).ready(function(){

  $("#btnMenu").click(function(){
    //alert("Aqui");
    $(".menum").velocity({ opacity: 1 }, { duration: 500 }).velocity({ top: '0%' }, { duration: 500 });
  });

  $("#cerrarmenu").click(function(){
    //alert("Aqui");
    $(".menum").velocity({ opacity: 0 }, { duration: 500 })
    $(".menum").velocity({ top: '100%' }, { duration: 500 });
  });

});
