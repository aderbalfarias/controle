$(function () {
    $("#ProjetoId").change(function () {
        $.ajax({
            url: UrlRota("CarregarUsuarios", "Permissao"),
            type: "GET",
            data: { id: $(this).val() },
            dataType: "json",
            cache: false,
            success: function (data) {
                $("#UsuarioId").reloadSelect(data);
            },
            error: function () {
                $("#UsuarioId").reloadSelect(undefined);
                ShowMessage("Error", 'Ocorreu um problema ao tentar listar permissões do projeto', '');
            }
        });

        $.ajax({
            url: UrlRota("CarregarPermissoes", "Permissao"),
            type: "GET",
            data: { id: $(this).val() },
            dataType: "html",
            cache: false,
            success: function (data) {
                $("#DivList").html(data);
            },
            error: function () {
                ShowMessage("Error", 'Ocorreu um problema ao tentar listar permissões', '');
            }
        });
    });
});

function ConfirmDelete(url, mensagem) {
    bootbox.confirm("Deseja realmente excluir " + mensagem + " ?", function (result) {
        if (result) {
            document.location.href = url;
        }
    });
}