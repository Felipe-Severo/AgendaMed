// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function getPictureData(table, field, id) {
    var fileModel = {
        Table: table,
        Column: field,
        Id: id,
    };

    $.ajax({
        url: '/Files/GetPictureData',
        type: 'GET',
        data: fileModel,
        success: function (data) {
            document.getElementById('fotoDisplay').src = data.data;
        }
    });
}

function previewFoto() {
    var input = document.getElementById('uploadFoto');
    var preview = document.getElementById('fotoDisplay');
    var file = input.files[0];
    var reader = new FileReader();

    reader.onloadend = function () {
        preview.src = reader.result;
    };

    if (file) {
        reader.readAsDataURL(file);
    } else {
        preview.src = "/img/userIcon.svg"; // Imagem padrão se nenhum arquivo for selecionado
    }
}

//function showChangePassword() {
//    $.post('Account/ChangePassword', function (response) {
//        $("#changePassword").html(response);
//    }).done(function () { $("#changePassword").modal("show"); }).fail(function () { })
//}

//function showChangePassword() {
//    $.post('Account/ChangePassword', function (response) {
//        $("#changePassword").html(response);
//        $("#changePassword").modal("show");
//    }).fail(function () {
//        console.error("Erro ao carregar a página de alteração de senha.");
//    });
//}
//function previewUrl(url) {
//    $('#changePassword').load(url).modal("show")
//}