

$(document.body).on('focusout ', '.date', function () {
    var inputDate = $(".date").val();
    if ((new Date(inputDate) !== "Invalid Date") && !isNaN(new Date(inputDate))) {
        $.get('/Home/APOD', { date: inputDate }, function (response) {
            $('.apod').html($(response).find('.apod').html());
        })
    }
}).on('click ', '.download-asteroids', function () {
    var page = $('.self-link').attr('data-id');
    if (page != undefined) {
        var downloadLink = $('.download-asteroids').attr("href").split("page=");
        $('.download-asteroids').attr("href", downloadLink[0] + "page=" + page);
    }
}).on('click ', '.pagination-numbers', function () {
    var page = $(this).attr('data-id');
    $.get('/Home', { page: page }, function (response) {
        $('.asteroids-table').html($(response).find('.asteroids-table').html());
    })
})
