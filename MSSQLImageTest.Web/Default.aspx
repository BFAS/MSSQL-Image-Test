<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MSSQLImageTest.Web.Default" %>

<%@ Register Src="~/UserControls/UcFileUpload.ascx" TagPrefix="uc1" TagName="UcFileUpload" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MSSQL Image Storage & Retrival</title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.4/jquery.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div>
        <uc1:UcFileUpload runat="server" id="UcFileUpload" />
    </div>
    </form>
</body>
</html>
