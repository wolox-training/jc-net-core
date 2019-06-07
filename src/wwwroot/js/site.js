$(function(){
    var tableBody = $('#ListComments tbody');
    var url = '@Url.Action("buttonComment", "Api/V1/MovieApiController")';
    $('#buttonComment').click(function() {
        /*$.get(url, function(response){
            tableBody.append(response);
            $('#comContent').val('');
        });*/
        $.get(url, function(response){
            alert('emtro');
        });
        alert('buton clickeado');   
    });
});    
