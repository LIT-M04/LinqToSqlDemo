$(function () {
    $(".delete").on('click', function () {
        $(this).button('loading');
        var id = $(this).data('person-id');
        $.post('/home/delete', { personId: id }, function() {
            window.location.reload();
        });
    });
});