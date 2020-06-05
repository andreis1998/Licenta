$(document).ready(function () {
    setTimeout(Temp, 8000);
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
        error: function (data) {
            TempExternal();
        },
        complete: function (data) {
            setTimeout(Temp, 8000);
        }
    });
}

function TempExternal() {
    $.ajax({
        type: 'GET',
        url: 'https://smarthouselicenta.azurewebsites.net/Temperature/GetTemp',
        success: function (data) {
            showTemp(data);
            checkLimits();
        },
        complete: function (data) {
            setTimeout(Temp, 8000);
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
            data: { value: $('#lowLimit').val() },
            error: function (data) {
                SetLowLimitExternal();
            }
        });
    }
}

function SetLowLimitExternal() {
    if ($('#highLimit').val() < $('#lowLimit').val()) {
        $('#lowLimitError').show();
    }
    else {
        $('#lowLimitError').hide();
        $.ajax({
            type: 'POST',
            url: 'https://smarthouselicenta.azurewebsites.net/Temperature/SetLowLimit',
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
            data: { value: $('#highLimit').val() },
            error: function (data) {
                SetHighLimitExternal();
            }
        });
    }
}

function SetHighLimitExternal() {
    if ($('#highLimit').val() < $('#lowLimit').val()) {
        $('#highLimitError').show();
    }
    else {
        $('#highLimitError').hide();
        $.ajax({
            type: 'POST',
            url: 'https://smarthouselicenta.azurewebsites.net/Temperature/SetHighLimit',
            data: { value: $('#highLimit').val() }
        });
    }
}

function checkLimits() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost/Licenta/Temperature/CheckTemperatureLimit',
        error: function (data) {
            checkLimitsExternal();
        }
    });
}

function checkLimitsExternal() {
    $.ajax({
        type: 'GET',
        url: 'https://smarthouselicenta.azurewebsites.net/Temperature/CheckTemperatureLimit'
    });
}

function DecreaseTemp() {
    var temp = $('#tempSet').val();
    if (temp > "20") {
        $('#tempSet').val(temp - 0.5);
        $.ajax({
            type: 'POST',
            url: 'http://localhost/Licenta/Temperature/SetTemperature',
            data: { value: $('#tempSet').val() },
            error: function (data) {
                SetTempExternal();
            }
        });
    }
}

function SetTempExternal() {
    $.ajax({
        type: 'POST',
        url: 'https://smarthouselicenta.azurewebsites.net/Temperature/SetTemperature',
        data: { value: $('#tempSet').val() }
    });
}

function IncreaseTemp() {
    var temp = parseFloat($('#tempSet').val());
    if (temp < "28") {
        $('#tempSet').val(temp + 0.5);
        $.ajax({
            type: 'POST',
            url: 'http://localhost/Licenta/Temperature/SetTemperature',
            data: { value: $('#tempSet').val() },
            error: function (data) {
                SetTempExternal();
            }
        });
    }
}