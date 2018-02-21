$(document).ready(function () {
    alert("test 12")
    set_dates();
}
);
set_dates = function () {

    $("#FromDate").datepicker({
        changeMonth: true,
        changeYear: true,
        dateFormat: 'mm/dd/yy',
        gotoCurrent: true
    });
    $("#FromDate").attr('maxlength', '10');
    $("#FromDate").val("@ViewData["fromdate"].ToString()");

    $("#ToDate").datepicker({
        changeMonth: true,
        changeYear: true,
        dateFormat: 'mm/dd/yy',
        gotoCurrent: true
    });
    $("#ToDate").attr('maxlength', '10');
    $("#ToDate").val("@ViewData["todate"].ToString()");
}

ToFromDate = {
    get_from_date_val: function () {
        return $("#FROM_DATE").val();
    },
    get_to_date_val: function () {
        return $("#TO_DATE").val();
    }
}