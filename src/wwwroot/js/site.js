$(function(){
    var tableBody = $('#ListComments tbody');
    var urlC = '/api/v1/MovieApiController/Comment';
    $('#buttonComment').click(function() {

        var comment = new Object();
        comment.Title=$('#comTitle').val();
        comment.Content=$('#comContent').val();
        comment.ReleaseDate = new Date();
        comment.MovieId =$('[name=comMovieId]').val();
        var tokenVal = $('[name=__RequestVerificationToken]').val();

        if (comment.Title != '' && comment.Content !='')
            tableBody.append('<tr> <td>' + comment.Title + '</td>' + '<td>' + comment.Content + '</td>' + '<td>' + comment.ReleaseDate + '</td> <tr>');

        $.ajax({  
            type: "POST",  
            url: urlC,  
            data: {
                __RequestVerificationToken: tokenVal,  
                commentVM: comment
            },      
            success: function(response) {  
                if (response != null) {  
                    alert("Success");  
                } else {  
                    alert("Something went wrong");  
                }  
            },  
            failure: function(response) {  
                alert('fail');  
            },  
            error: function(response,status,error) {  
                alert('Status: ' + status + ' Error: ' + error);   
            }  
        });  

    });

}); 
