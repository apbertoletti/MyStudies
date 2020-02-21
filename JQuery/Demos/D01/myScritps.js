$(function(){
    $('#l1').click(function(){
        $('#i1').fadeIn();
        $('#i2').fadeOut();
        $('#i3').fadeOut();
        $('#i4').fadeOut();
    });

    $('#l2').click(function(){
        $('#i1').fadeOut();
        $('#i2').fadeIn();
        $('#i3').fadeOut();
        $('#i4').fadeOut();
    });

    $('#l3').click(function(){
        $('#i1').fadeOut();
        $('#i2').fadeOut();
        $('#i3').fadeIn();
        $('#i4').fadeOut();
    });

    $('#l4').click(function(){
        $('#i1').fadeOut();
        $('#i2').fadeOut();
        $('#i3').fadeOut();
        $('#i4').fadeIn();
    });
});