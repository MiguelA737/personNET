$(document).ready(function () {
    $("#status").hide();
    $("#btn-enter").click(function () {
        $.ajax({
            url: "/Authentication/AuthenticateUser",
            data: { email: $("#txtEmail").val(), pass: $("#txtPass").val(), persist: $("#chkpersist").prop("checked")},
            dataType: "json",
            type: "POST",
            async: true,
            beforeSend: function () {
                $("#status").html("Autenticando usuário...");
                $("#status").show();
            },
            success: function (dados) {
                if (dados.OK) {
                    $("#status").html(dados.Mensagem)
                    setTimeout(function () { window.location.href = "/Home" }, 2000);
                    $("#status").show();
                } else {
                    $("#status").html(dados.Mensagem);
                    $("#status").show();
                }
            },
            error: function (dados) {
                $("#status").html("Erro na autenticação.");
                $("#status").show();
            }
        });
    });
});