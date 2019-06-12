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
