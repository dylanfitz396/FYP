<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="FYP.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>Column chart using Google Visualization</title>     
     <script type="text/javascript" src="https://www.google.com/jsapi"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Literal ID="lt" runat="server"></asp:Literal>
        <div id="chart_div"></div>    
    </div>     
        <p>
            <asp:Button ID="btnDylan" runat="server" Text="Dylan" OnClick="btnDylan_Click" />
        </p>
        <p>
            <asp:Button ID="btnChris" runat="server" Text="Chris" OnClick="btnChris_Click" />
        </p>
 </form>
</body>
</html>
