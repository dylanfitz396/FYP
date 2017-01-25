<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="FYP.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>

        <div class="jumbotron">
        <h1>Your Home Page</h1>
            <hr />

            <asp:Label ID="SelectedTeam" runat="server" CssClass="control-label">Selected Team:</asp:Label>
            <asp:Label ID="lblSelectedTeam" runat="server" CssClass="control-label"></asp:Label>        

            <asp:Literal ID="lt" runat="server"></asp:Literal>
            <div id="chart_div1"></div>

            
            <div class="col-md-offset-10">
                <a href="InputPage.aspx" class="btn btn-info btn-lg">Update Details &raquo;</a>
            </div>

        </div>
</asp:Content>
