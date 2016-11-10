<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TeamView.aspx.cs" Inherits="FYP.TeamView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>

        <div class="jumbotron">
        <asp:Literal ID="lt" runat="server"></asp:Literal>
            <div id="chart_div"></div> 
            <br/>
            <asp:Literal ID="lt2" runat="server"></asp:Literal>
            <div id="chart_div"></div> 
            <br/>
            <asp:Literal ID="lt3" runat="server"></asp:Literal>
            <div id="chart_div"></div> 
            <br/>
            <asp:Literal ID="lt1" runat="server"></asp:Literal>
        <div id="chart_div"></div> 

            <a href="InputPage.aspx" class="btn btn-success btn-sm">Update Details &raquo;</a> 

            </div>
</asp:Content>
