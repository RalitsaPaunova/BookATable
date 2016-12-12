$(document).ready(function () {
    $('#datetimepicker').datetimepicker({
        startDate: '+2016/08/01', allowTimes: ['06:00', '07:00', '08:00', '09:00', '10:00', '11:00', '13:00', '14:00', '15:00', '15:00', '16:00', '17:00'], minDate: Date.now

    });
})