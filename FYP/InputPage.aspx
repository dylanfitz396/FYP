<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InputPage.aspx.cs" Inherits="FYP.InputPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
    <h1>Update Details</h1>

    <hr />
    <div class="row">
    <div class="col-md-8">
        <div class="form-horizontal">
            
    <div class="form-group">
        <asp:Label ID="Label1" runat="server" CssClass="col-md-3 control-label">Employee Name</asp:Label>
        <asp:TextBox ID="txtEmpName" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Label ID="Label2" runat="server" CssClass="col-md-3 control-label">Skill</asp:Label>
        <asp:TextBox ID="txtSkill" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    
    <div class="form-group">
        <asp:Label ID="Label3" runat="server" CssClass="col-md-3 control-label">Expertise Level</asp:Label>
        <asp:TextBox ID="txtExpertiseLevel" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
       

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Database1ConnectionString1 %>" DeleteCommand="DELETE FROM [Skills] WHERE [Id] = @Id" InsertCommand="INSERT INTO [Skills] ([Id], [EmpName], [Skill], [ExpertiseLevel]) VALUES (@Id, @EmpName, @Skill, @ExpertiseLevel)" ProviderName="<%$ ConnectionStrings:Database1ConnectionString1.ProviderName %>" SelectCommand="SELECT [Id], [EmpName], [Skill], [ExpertiseLevel] FROM [Skills]" UpdateCommand="UPDATE [Skills] SET [EmpName] = @EmpName, [Skill] = @Skill, [ExpertiseLevel] = @ExpertiseLevel WHERE [Id] = @Id">
            <DeleteParameters>
                <asp:Parameter Name="Id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Id" Type="Int32" />
                <asp:Parameter Name="EmpName" Type="String" />
                <asp:Parameter Name="Skill" Type="String" />
                <asp:Parameter Name="ExpertiseLevel" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="EmpName" Type="String" />
                <asp:Parameter Name="Skill" Type="String" />
                <asp:Parameter Name="ExpertiseLevel" Type="String" />
                <asp:Parameter Name="Id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>

    <div class="form-group">
        <div class="col-md-10">
        <p>
            <asp:Button class="btn btn-success btn-lg" ID="btnGenerate" runat="server" OnClick="btnGenerate_Click" Text="Generate Graph" />
        </p>
            </div>
        </div>
         </div>
        </div>
        </div>
        </div>
</asp:Content>
