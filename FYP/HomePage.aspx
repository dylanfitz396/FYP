<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="FYP.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>

        <div class="jumbotron">
            <div class="row">
                <div class="col-md-8">
                    <h1>Home Page</h1> 
                    <h4>Welcome to Visualise Us! Create and customise your own Skill Chart</h4> 
                </div>
            <div class="col-md-4" style="margin-left: auto; margin-right: auto; text-align: right;">
                    <asp:Image runat="server" ImageUrl="~/Images/SkillsHubLogoSmall.jpg" style="width:260px;height:95px;"></asp:Image>  
            </div>
            </div>  
            <hr />

            <div class="row"> 
            <div class="col-md-4">
                <asp:Label ID="Name" runat="server" CssClass="control-label">Employee Name:</asp:Label>
                <asp:Label ID="lblEmpName" runat="server" CssClass="control-label"></asp:Label> 
            </div>   
            <div class="col-md-4" style="margin-left: auto; margin-right: auto; text-align: center;">
                <asp:Label ID="SelectedTeam" runat="server" CssClass="control-label">Selected Team:</asp:Label>
                <asp:Label ID="lblSelectedTeam" runat="server" CssClass="control-label"></asp:Label>    
            </div>   
            <div class="col-md-4" style="margin-left: auto; margin-right: auto; text-align: right;">
                <asp:Label ID="Email" runat="server" CssClass="control-label">Email:</asp:Label>
                <asp:Label ID="lblEmail" runat="server" CssClass="control-label"></asp:Label>     
            </div>   
            </div>

            <asp:Literal ID="lt" runat="server"></asp:Literal>
            <div id="chart_div1"></div>

            
            <div class="col-md-offset-10">
                <a href="InputPage.aspx" class="btn btn-info btn-lg">Update Details &raquo;</a>
            </div>

        </div>
</asp:Content>
