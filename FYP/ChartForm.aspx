<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChartForm.aspx.cs" Inherits="FYP.ChartForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>

        <div class="jumbotron">
        <asp:Literal ID="lt" runat="server"></asp:Literal>
        <div id="chart_div"></div>   
           
    
    <div class="form-horizontal">
        <div class="form-group">
        <div class="col-md-9">
            <asp:Button class="btn btn-info btn-sm" ID="btnDylan" runat="server" Text="Dylan" OnClick="btnDylan_Click" />

            <asp:Button class="btn btn-info btn-sm" ID="btnChris" runat="server" Text="Chris" OnClick="btnChris_Click" />
            </div>
            
    
            
            
            

    <a href="InputPage.aspx" class="btn btn-success btn-sm">Update Details &raquo;</a>
        </div>
        </div>
            </div>

</asp:Content>
