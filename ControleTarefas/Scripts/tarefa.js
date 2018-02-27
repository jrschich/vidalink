function pesquisar() {
    var param = $('#txtPesquisar').val();
    $.ajax({
        url: 'Home/Filtro',
        data: { filtro: param },
        dataType: 'json',
        type: 'POST',
        success: function (data) {
            var teste = "";
        }
    });
}