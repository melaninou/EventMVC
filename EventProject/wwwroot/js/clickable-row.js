//jQuery(document).ready(function($){
//    $('*[data-href]').onclick(function() {
//        window.location;
//    });
//});

    $(document).ready(function () {
        $(".clickable-row").click(function () {
            window.document.location = $(this).data("href");
        });
    })