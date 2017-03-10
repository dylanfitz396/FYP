<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="FYP.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
            <div class="row">
                <div class="col-md-8">
                    <h1>About Us</h1> 
                    <h4>Learn more about who we are and what we do!</h4> 
                </div>
            <div class="col-md-4" style="margin-left: auto; margin-right: auto; text-align: right;">
                    <asp:Image runat="server" ImageUrl="~/Images/SkillsHubLogoSmall.jpg" style="width:260px;height:95px;"></asp:Image>  
            </div>
            </div>  
            <hr />

        <h3>How did the idea come about?</h3>
        <br />
        <div class="row"> 
            <div class="col-md-1">
                <asp:Label runat="server"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:Image runat="server" ImageUrl="~/Images/harvard-logo.jpg" style="width:260px;height:145px;"></asp:Image>
            </div>
            <div class="col-md-5" style="margin-left: auto; margin-right: auto; text-align: right;">
                    <asp:Image runat="server" ImageUrl="~/Images/WeNeedVisualization.png" style="width:400px;height:145px;"></asp:Image>  
            </div>
        </div>

        <br />
        <br />
        <br />
        <br />
        <h3>Who did I speak to about the potential for this idea?</h3>
        <br />
        <div class="row"> 
            <div class="col-md-1">
                <asp:Label runat="server"></asp:Label>
            </div>
            <div class="col-md-6">
                <br />
                <asp:Image runat="server" ImageUrl="~/Images/Fidelity_Investments.svg" style="width:450px;height:145px;"></asp:Image>
                <br />
                <br />
                <asp:Label runat="server" Text=">> My Mentor (QA Engineer)"></asp:Label>
                <br />
                <asp:Label runat="server" Text=">> My Manager (Snr. Manager)"></asp:Label>
            </div>
            <div class="col-md-5" style="margin-left: auto; margin-right: auto; text-align: left;">
                    <asp:Image runat="server" ImageUrl="~/Images/Apple_Logo.png" style="width:150px;height:175px;"></asp:Image> 
                    <br />
                    <br />
                    <asp:Label runat="server" Text=">> HR Manager"></asp:Label> 
            </div>
            
        </div>

        <br />
        <br />
        <br />
        <br />
        <h3>Feedback:</h3>
        <br />
        <div class="row"> 
        <div class="col-md-1">
            <asp:Label runat="server"></asp:Label>
        </div>
        <div class="col-md-10">
            <br />
            <asp:Image runat="server" ImageUrl="~/Images/HRInternal.jpg" style="width:750px;height:145px;"></asp:Image>
        </div>
        </div>

        <br />
        <br />
        <br />
        <br />
        <h3>Result:</h3>
        <div class="row"> 
            <div class="col-md-1">
                <asp:Label runat="server"></asp:Label>
            </div>
            <div class="col-md-10">
                <br />
                <asp:Image runat="server" ImageUrl="~/Images/SkillsHubLogo.jpg" style="width:775px;height:260px;"></asp:Image>
            </div>
            </div>

    </div>
</asp:Content>
