<%@ Page Title="Enter Your Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EnterDetailsPage.aspx.cs" Inherits="FYP.EnterDetailsPage" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="jumbotron">
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <div class="row">
        <h4>Create a new account</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />

        
        <div class="col-md-5"> 
            <div class="form-group">
            <asp:Label ID="Skill1" runat="server" CssClass="col-md-2 control-label">Skill 1:</asp:Label>
            <asp:TextBox ID="txtSkill1" runat="server" CssClass="form-control" Width="280px"></asp:TextBox>
            </div>

            <div class="form-group">
            <asp:Label ID="Skill2" runat="server" CssClass="col-md-2 control-label">Skill 2:</asp:Label>
            <asp:TextBox ID="txtSkill2" runat="server" CssClass="form-control" Width="280px"></asp:TextBox>
            </div>

            <div class="form-group">
            <asp:Label ID="Skill3" runat="server" CssClass="col-md-2 control-label">Skill 3:</asp:Label>
            <asp:TextBox ID="txtSkill3" runat="server" CssClass="form-control" Width="280px"></asp:TextBox>
            </div>
        </div>

        <div class="col-md-7"> 
            <div class="form-group">
            <asp:Label ID="ExpertiseLevel1" runat="server" CssClass="col-md-3 control-label">Expertise Level 1:</asp:Label>
            <asp:TextBox ID="txtExpertiseLevel1" runat="server" CssClass="form-control" Width="280px"></asp:TextBox>
            </div>

            <div class="form-group">
            <asp:Label ID="ExpertiseLevel2" runat="server" CssClass="col-md-3 control-label">Expertise Level 2:</asp:Label>
            <asp:TextBox ID="txtExpertiseLevel2" runat="server" CssClass="form-control" Width="280px"></asp:TextBox>
            </div>

            <div class="form-group">
            <asp:Label ID="ExpertiseLevel3" runat="server" CssClass="col-md-3 control-label">Expertise Level 3:</asp:Label>
            <asp:TextBox ID="txtExpertiseLevel3" runat="server" CssClass="form-control" Width="280px"></asp:TextBox>
            </div>
        </div>
        
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
    </div>

    </div>

</asp:Content>
