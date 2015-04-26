$(document).ready(function () {
    $("input[type=datetime]").datetimepicker({
        locale: "pt-br",
        icons: {
            time: "fa fa-clock-o",
            date: "fa fa-calendar",
            up: "fa fa-arrow-up",
            down: "fa fa-arrow-down"
        },
    });

    $("#DataInicio").datetimepicker();
    $("#DataFim").datetimepicker();

    //$("#DataInicio").change(function () {
    //    $(this).datetimepicker('hide');
    //});

    //$("#DataFim").change(function () {
    //    $(this).datetimepicker('hide');
    //});
});
