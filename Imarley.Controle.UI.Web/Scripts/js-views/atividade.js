$(document).ready(function () {
    if ($("#ProjetoId").val() > 0) {
        var model = $("#FormAtividade").serialize();

        $.ajax({
            url: UrlRota("List", "Atividade"),
            type: "POST",
            data: model,
            dataType: "html",
            cache: false,
            async: true,
            success: function (data) {
                $("#DivListAtividade").html(data);
            },
            error: function () {
                ShowMessage("Error", 'Ocorreu um problema ao tentar listar atividades do projeto', '');
            }
        });
    }

    $("input[type=submit]").click(function () {
        if ($("#ProjetoId").val() > 0) {
            Loading("#DivListAtividade");
        }
    });
});
