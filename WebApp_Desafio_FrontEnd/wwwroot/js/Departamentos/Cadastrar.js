﻿$(document).ready(function () {
        $('#btnCancelar').click(function () {
        Swal.fire({
            html: "Deseja cancelar essa operação? O registro não será salvo.",
            type: "warning",
            showCancelButton: true,
        }).then(function (result) {
            if (result.value) {
                history.back();
            } else {
                console.log("Cancelou a inclusão.");
            }
        });
    });

    $('#btnSalvar').click(function () {

        if ($('#form').valid() != true) {
            FormularioInvalidoAlert();
            return;
        }

        let departamento = SerielizeForm($('#form'));
        let url = $('#form').attr('action');

        $.ajax({
            type: "POST",
            url: url,
            data: departamento,
            success: function (result) {

                if (result.Type === 'success') {
                    Swal.fire({
                        type: result.Type,
                        title: result.Title,
                        text: result.Message,
                    }).then(function () {
                        window.location.href = config.contextPath + result.Controller + '/' + result.Action;
                    });
                }
                else {
                    Swal.fire({
                        text: result.errors,
                        confirmButtonText: 'OK',
                        icon: 'error'
                    });
                }
            },
            error: function (result) {

                Swal.fire({
                    text: result.Message,
                    confirmButtonText: 'OK',
                    icon: 'error'
                });

            },
        });
    });

});
