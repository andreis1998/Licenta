$(document).ready(function () {
    setTimeout(Temp, 5000);
});

function Temp() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost/Licenta/Temperature/GetTemp',
        success: function (data) {
            showTemp(data);
        },
        complete: function (data) {
            setTimeout(Temp, 5000);
        }
    });
}

function showTemp(data) {
    $('#tempBox').val(data);
}