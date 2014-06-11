$(document).ready(function() {

    'use strict';

    $('#inputSubText').focus();
    windowApp.submit();
    windowApp.cancelSubmit();

});

var windowApp = windowApp || {};

windowApp.submit = function() {

    $('#btnSubmit').click(function (e) {
        e.preventDefault();
        $('#output').val('');
        var subText = $('#inputSubText').val();

        $.ajax({
            type: 'POST',
            url: "/Home/GetTextMatch",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify({ subText: subText }),
            success: function (result) {

                $('#output').val(result);
                $('#inputSubText').focus();
            },
            error: function (errors) {
                console.log(errors);
            }
        });
    });
};

windowApp.cancelSubmit = function() {

    $('#btnCancel').click(function() {

        $('#output').val('');
        $('#inputSubText').val('');
        $('#inputSubText').focus();

    });
};