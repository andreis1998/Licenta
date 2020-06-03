$(document).ready(function () {
    setTimeout(Temp, 5000);
    $('#highLimitError').hide();
    $('#lowLimitError').hide();
});

function Temp() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost/Licenta/Temperature/GetTemp',
        success: function (data) {
            showTemp(data);
            checkLimits();
        },
        complete: function (data) {
            setTimeout(Temp, 5000);
        }
    });
}

function showTemp(data) {
    $('#tempBox').val(data);
}

function SetLowLimit() {
    if ($('#highLimit').val() < $('#lowLimit').val()) {
        $('#lowLimitError').show();
    }
    else {
        $('#lowLimitError').hide();
        $.ajax({
            type: 'POST',
            url: 'http://localhost/Licenta/Temperature/SetLowLimit',
            data: { value: $('#lowLimit').val() }
        });
    }
}

function SetHighLimit() {
    if ($('#highLimit').val() < $('#lowLimit').val()) {
        $('#highLimitError').show();
    }
    else {
        $('#highLimitError').hide();
        $.ajax({
            type: 'POST',
            url: 'http://localhost/Licenta/Temperature/SetHighLimit',
            data: { value: $('#highLimit').val() }
        });
    }
}

function checkLimits() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost/Licenta/Temperature/CheckTemperatureLimit'
    });
}