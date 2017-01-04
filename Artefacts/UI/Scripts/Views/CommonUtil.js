(function ($) {

    $.fn.ClearText = function () {
        $(this).each(function () {
            $(this).val('');
        });
    };
    
}(jQuery));

/*
This approach also work but not aligned with modern Jquery 
function ChangeFormAttribute (str)
{
    alert('Hi');
    $('form').attr('action', str);
}*/

function ButtonPostActionTo(clickedButton, urlToPost) {
    $(clickedButton).closest('form').attr('action', urlToPost);
}


