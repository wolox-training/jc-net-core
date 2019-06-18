$(function(){
    var urlContact = '/api/v1/HomeApiController/Contact';
    $('#emailBtm').click(function() {
        var mail = new Object();
        mail.Name = $('#nameContact').val();
        mail.Adress = $('#adressContact').val();
        mail.Subject = $('#subjectContact').val();
        mail.Body = $('#bodyContact').val();
        var tokenVal = $('[name=__RequestVerificationToken]').val();
        $.ajax({  
            type: "POST",  
            url: urlContact,  
            data: {
                __RequestVerificationToken: tokenVal,
                email : mail
            },
            success: function(response) {  
                if (response != null) {  
                    alert("The mail was send succesfully");
                    $('#nameContact').val('');
                    $('#adressContact').val('');
                    $('#subjectContact').val('');
                    $('#bodyContact').val('');
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
    var urlDetails = '/api/v1/MovieApiController/Details';
    $('#emailDetailsBtm').click(function() {
        var mail = new Object();
        mail.Name = $('#nameDetails').val();
        mail.Adress = $('#adressDetails').val();
        mail.Body = ('Id: ' + $('[name=detailsMovieId]').val() + ' Title: ' + $('[name=detailsMovieTitle]').val() + ' Release Date: ' + $('[name=detailsMovieReleaseDate]').val() + ' Genre: ' + $('[name=detailsMovieGenre]').val() + ' Price: ' + $('[name=detailsMoviePrice]').val() + ' Rating: ' + $('[name=detailsMovieRating]').val() );
        mail.Subject = ('Information of the movie ' + $('[name=detailsMovieTitle]').val());
        var tokenVal = $('[name=__RequestVerificationToken]').val();
        if (mail.Name!='' && mail.Adress!=''){
            $.ajax({  
                type: "POST",  
                url: urlDetails,  
                data: {
                    __RequestVerificationToken: tokenVal,
                    email : mail
                },
                success: function(response) {  
                    if (response != null) {  
                        alert("The mail was send succesfully");
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
        } else {
            alert ('Complete all the fields');
        }
    });
    var tableBody = $('#ListComments tbody');
    var urlC = '/api/v1/MovieApiController/Comment';
    $('#buttonComment').click(function() {
        var comment = new Object();
        comment.Title=$('#comTitle').val();
        comment.Content=$('#comContent').val();
        comment.CreatedAt = new Date();
        var dataC = (comment.CreatedAt.getMonth() + 1) + '/' + comment.CreatedAt.getDate() + '/' +  comment.CreatedAt.getFullYear();
        comment.MovieId =$('[name=comMovieId]').val();
        var tokenVal = $('[name=__RequestVerificationToken]').val();
        $.ajax({  
            type: "POST",  
            url: urlC,  
            data: {
                __RequestVerificationToken: tokenVal,  
                commentVM: comment
            },      
            success: function(response) {  
                if (response != null) {
                    tableBody.append('<tr> <td>' + comment.Title + '</td>' + '<td>' + comment.Content + '</td>' + '<td>' + dataC + '</td> <tr>');
                    $('#comTitle').val('');
                    $('#comContent').val('');
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
