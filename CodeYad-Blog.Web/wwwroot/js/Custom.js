$(document).ready(function () {
    LoadCkEditor4();
    $.ajax({
        url: "/index/PopularPosts",
        type:"get"
    }).done(function (data) {
        $("#PopularPosts").html(data)
    });
});





function LoadCkEditor4() {
    if(!document.getElementById("ckeditor4"))
  return;

    $("body").append("<script src='/ckeditor/ckeditor.js'></script>)");
    CKEDITOR.replace("ckeditor4",
        { customConfig:'/ckeditor/config.js'
    
        
        });
}
function ChangePage(pageId) {
    var url = new URL(window.location.href);
    var search_params = url.searchParams;
    search_params.set('pageId', pageId);
    url.search = search_params.toString();
    var newUrl = url.toString();
    window.location.replace(newUrl);


}

