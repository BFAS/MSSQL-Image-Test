<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcFileUpload.ascx.cs" Inherits="MSSQLImageTest.Web.UserControls.UcFileUpload" %>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.4/jquery.min.js"></script>

<asp:UpdatePanel runat="server" ID="updFileUpload" UpdateMode="Conditional">
    <ContentTemplate>
        
        <div style="border: 1px solid silver; padding: 10px;">
            <div style="float: left;"><input type="file" id="fileUpload" multiple /></div>
            <div><asp:Button runat="server" ID="btnUpload" Text="Upload" OnClick="btnUpload_Click" /></div>
        </div>
        <div><asp:Label runat="server" ID="lblMessage" ></asp:Label></div>

        <div>
            <asp:PlaceHolder runat="server" ID="plcDataFiles"></asp:PlaceHolder>    
        </div>

    </ContentTemplate>
</asp:UpdatePanel>



<script type="text/javascript">

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

            // Make Ajax request with the contentType = false, and procesDate = false
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
</script>
