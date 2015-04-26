$(document).ready(function () {
    $("#ProjetoId").change(function () {
        $.ajax({
            url: UrlRota("CarregarAtividades", "Relatorio"),
            type: "GET",
            data: { id: $(this).val() },
            dataType: "json",
            cache: false,
            success: function (data) {
                $("#AtividadeId").reloadSelect(data);
            },
            error: function () {
                $("#AtividadeId").reloadSelect(undefined);
                ShowMessage("Error", 'Ocorreu um problema ao tentar listar atividades do projeto', '');
            }
        });
    });

    $("#BotaoGerarExcelAdministrativo").click(function() {
        $("#FormExportExcel #ProjetoId").val($("#FormRelatorioAdministrativo #ProjetoId").val());
        $("#FormExportExcel #AtividadeId").val($("#FormRelatorioAdministrativo #AtividadeId").val());
        $("#FormExportExcel #StatusId").val($("#FormRelatorioAdministrativo #StatusId").val());
        $("#FormExportExcel #UsuarioId").val($("#FormRelatorioAdministrativo #UsuarioId").val());

        //$("#FormRelatorioAdministrativo").append("<div id='load' class='load text-center' tabindex='-1' role='dialog' aria-hidden='false'><i class='fa fa-spinner fa-pulse fa-5x'></i></div>");
        
        $("form#FormExportExcel").serialize();
        $("form#FormExportExcel").submit();
        
        //$("div").remove(".load");
    });

    $("div").remove("#load");
});
