<%@ Page Title="Enter Your Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EnterDetailsPage.aspx.cs" Inherits="FYP.EnterDetailsPage" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="jumbotron">
    

    <div class="form-horizontal">
        <div class="row">
        <h2><%: Title %>.</h2>
        <p class="text-danger">
            <asp:Literal runat="server" ID="ErrorMessage" />
        </p>
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

            <div class="form-group">
            <asp:Label ID="Skill4" runat="server" CssClass="col-md-2 control-label" Visible="false">Skill 4:</asp:Label>
            <asp:TextBox ID="txtSkill4" runat="server" CssClass="form-control" Width="280px" Visible="false"></asp:TextBox>
            </div>

            <div class="form-group">
            <asp:Label ID="Skill5" runat="server" CssClass="col-md-2 control-label" Visible="false">Skill 5:</asp:Label>
            <asp:TextBox ID="txtSkill5" runat="server" CssClass="form-control" Width="280px" Visible="false"></asp:TextBox>
            </div>

            <div class="form-group">
            <asp:Label ID="Skill6" runat="server" CssClass="col-md-2 control-label" Visible="false">Skill 6:</asp:Label>
            <asp:TextBox ID="txtSkill6" runat="server" CssClass="form-control" Width="280px" Visible="false"></asp:TextBox>
            </div>

            <div class="form-group">
            <asp:Label ID="Skill7" runat="server" CssClass="col-md-2 control-label" Visible="false">Skill 7:</asp:Label>
            <asp:TextBox ID="txtSkill7" runat="server" CssClass="form-control" Width="280px" Visible="false"></asp:TextBox>
            </div>

            <div class="form-group">
            <asp:Label ID="Skill8" runat="server" CssClass="col-md-2 control-label" Visible="false">Skill 8:</asp:Label>
            <asp:TextBox ID="txtSkill8" runat="server" CssClass="form-control" Width="280px" Visible="false"></asp:TextBox>
            </div>

            <div class="form-group">
            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
            </div>

            <div class="form-group">
            <div class="col-md-offset-1 col-md-2">
                <asp:Button ID="btnAddSkill" runat="server" Text="Add Skill" onclick="AddSkill_Click" CssClass="btn btn-info" />
            </div>
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

            <div class="form-group">
            <asp:Label ID="ExpertiseLevel4" runat="server" CssClass="col-md-3 control-label" Visible="false">Expertise Level 4:</asp:Label>
            <asp:TextBox ID="txtExpertiseLevel4" runat="server" CssClass="form-control" Width="280px" Visible="false"></asp:TextBox>
            </div>

            <div class="form-group">
            <asp:Label ID="ExpertiseLevel5" runat="server" CssClass="col-md-3 control-label" Visible="false">Expertise Level 5:</asp:Label>
            <asp:TextBox ID="txtExpertiseLevel5" runat="server" CssClass="form-control" Width="280px" Visible="false"></asp:TextBox>
            </div>

            <div class="form-group">
            <asp:Label ID="ExpertiseLevel6" runat="server" CssClass="col-md-3 control-label" Visible="false">Expertise Level 6:</asp:Label>
            <asp:TextBox ID="txtExpertiseLevel6" runat="server" CssClass="form-control" Width="280px" Visible="false"></asp:TextBox>
            </div>

            <div class="form-group">
            <asp:Label ID="ExpertiseLevel7" runat="server" CssClass="col-md-3 control-label" Visible="false">Expertise Level 7:</asp:Label>
            <asp:TextBox ID="txtExpertiseLevel7" runat="server" CssClass="form-control" Width="280px" Visible="false"></asp:TextBox>
            </div>

            <div class="form-group">
            <asp:Label ID="ExpertiseLevel8" runat="server" CssClass="col-md-3 control-label" Visible="false">Expertise Level 8:</asp:Label>
            <asp:TextBox ID="txtExpertiseLevel8" runat="server" CssClass="form-control" Width="280px" Visible="false"></asp:TextBox>
            </div>

            <div class="form-group">
            <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
            </div>

            <div class="form-group">
            <div class="col-md-offset-8 col-md-3">
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="Create Account" CssClass="btn btn-success btn-lg" />
            </div>
            </div>

        </div>
        
        
    </div>
    </div>


</asp:Content>
