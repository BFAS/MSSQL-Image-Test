$(document).ready(function() {
    rebindFileUpload();
});
    
Sys.WebForms.PageRequestManager.getInstance().add_endRequest(rebindFileUpload);

function rebindFileUpload() {

    $("[id*='btnUpload']").on('click', function (evt) {

        //alert('click');

        var data = new window.FormData();

        var files = $("#fileUpload").get(0).files;

        // Add the uploaded image content to the form data collection
        if (files.length > 0) {
            data.append("UploadedImage", files[0]);
            //alert('file');
        }

        // Make Ajax request with the contentType = false, and processData = false
        var ajaxRequest = $.ajax({
            type: "POST",
            url: "/Handlers/hanFileUpload.ashx",
            async: false,
            contentType: false,
            processData: false,
            data: data,
            success: function(data) {
                //alert('success');
            }
        });

        ajaxRequest.done(function (xhr, textStatus) {
            //alert('done');
        });
    });
}

