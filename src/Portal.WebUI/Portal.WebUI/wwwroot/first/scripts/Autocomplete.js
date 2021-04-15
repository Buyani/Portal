$(document).ready(function () {
    $("#txtStudents").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: '/Payment/Students',
                type: 'GET',
                cache: false,
                data: request,
                dataType: 'json',
                success: function (data) {
                    response($.map(data, function (item) {
                        return {
                            label: item,
                            value: item + ""
                        }
                    }))
                }
            });
        },
        minLength: 2,
        select: function (event, ui) {
            alert('you have selected ' + ui.item.label + ' StudentId: ' + ui.item.value);
            $('#txtSearch').val(ui.item.label);
            return false;
        }
    });
});