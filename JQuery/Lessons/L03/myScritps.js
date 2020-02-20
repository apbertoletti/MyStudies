$(function(){
    $('#btnFrase1').click(function(){
        $('#frase1')
            .css("color", "blue");
    });
    $('#btnFrase2').click(function(){
        $('#frase2')
            .css("color", "red");

        $('#mensagem')
            .show()
            .text('Cor alterada com sucesso!')
            .delay(3000)
            .fadeOut(3000);
    })
});