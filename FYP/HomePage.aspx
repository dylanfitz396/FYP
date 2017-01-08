<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="FYP.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>

        <div class="jumbotron">
            <h1>Your Home Page</h1>
        <asp:Literal ID="lt" runat="server"></asp:Literal>
        <div id="chart_div"></div>
            </div>
</asp:Content>
