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

});

$(function(){
    var urlDetails = '/api/v1/MovieApiController/Details';
    $('#emailDetailsBtm').click(function() {
        var mail = new Object();
        mail.Name = $('#nameDetails').val();
        mail.Adress = $('#adressDetails').val();
        mail.Body = ('Id: ' + $('[name=detailsMovieId]').val() + ' Title: ' + $('[name=detailsMovieTitle]').val() + ' Release Date: ' + $('[name=detailsMovieReleaseDate]').val() + ' Genre: ' + $('[name=detailsMovieGenre]').val() + ' Price: ' + $('[name=detailsMoviePrice]').val() + ' Rating: ' + $('[name=detailsMovieRating]').val() );
        mail.Subject = ('Information of the movie ' + $('[name=detailsMovieTitle]').val());
        var tokenVal = $('[name=__RequestVerificationToken]').val();
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
    });

}); 
