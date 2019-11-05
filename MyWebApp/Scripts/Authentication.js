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

    $("#btn-logout").click(function () {
        $.ajax({
            url: "/Authentication/DeauthenticateUser",
            dataType: "json",
            type: "POST",
            async: true,
            success: function (dados) {
                if (dados.OK)
                    window.location.href = "/Home";
            }
        });
    });

    $.ajax({
        url: "/Authentication/VerifyAuthentication",
        dataType: "json",
        type: "POST",
        async: true,
        success: function (dados) {
            if (dados.OK) {
                $(".menu").each(function () {
                    $(this).show();
                });
                $("#btn-logout").show();
                $(".btn-login").each(function () {
                    $(this).hide();
                });
                
            }
            else {
                $(".menu").each(function () {
                    $(this).hide();
                });
                $("#btn-logout").hide();
                $(".btn-login").each(function () {
                    $(this).show();
                });
            }
        }
    });
});