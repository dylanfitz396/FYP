<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InputPage.aspx.cs" Inherits="FYP.InputPage" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
<script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>
<link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/start/jquery-ui.css"
    rel="stylesheet" type="text/css" />
<script type="text/javascript">
    function ShowPopup(title, message) {
        $(function () {
            $("#dialog").html(message);
            $("#dialog").dialog({
                title: title,
                buttons: {
                    Close: function () {
                        $(this).dialog('close');
                    }
                },
                modal: true
            });
        });
    };
</script>
<div id="dialog" style="display: none">
</div>

<%--    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server"></asp:ScriptManagerProxy>
    <asp:TextBox ID="txtSkillsSearch" runat="server"></asp:TextBox>
    <cc1:AutoCompleteExtender ServiceMethod="SearchSkills"
        MinimumPrefixLength="1"
        CompletionInterval="100" EnableCaching="false" CompletionSetCount="10"
        TargetControlID="txtSkillsSearch"
        ID="AutoCompleteExtender1" runat="server" FirstRowSelected = "false">
    </cc1:AutoCompleteExtender>--%>


    <%--<link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css">--%>
    <%--<script src="http://code.jquery.com/jquery-1.9.1.js"></script>--%>
    <%--<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
    
    <script lang="javascript" type="text/javascript">
        $(function () {
            $('#<%=txtSkill.ClientID%>').autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "InputPage.aspx/GetSkill",
                        data: "{ 'pre':'" + request.term + "'}",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return { value: item }
                            }))
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert(textStatus);
                        }
                    });
                }
            });

        });
    </script>--%>

    <div class="jumbotron">

    <div class="row">
        <div class="col-md-8">
        <h1>Update Details</h1>
            <h4>Options to edit, insert and delete details to customise your profile</h4>
        </div>
            <div class="col-md-4" style="margin-left: auto; margin-right: auto; text-align: right;">
                    <asp:Image runat="server" ImageUrl="~/Images/VisualiseUsLogo.jpg" style="width:140px;height:115px;"></asp:Image>  
            </div>
        </div>

    <hr />

    

    <div class="row">
    <div class="col-md-10">
        <div class="form-horizontal">
       <div class="row">
           
        <div class="col-md-8"> 
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" CssClass="col-md-3 control-label">Employee Email:</asp:Label>
                <asp:Label ID="Label4" runat="server" CssClass="col-md-3 control-label"><%: Context.User.Identity.GetUserName() %></asp:Label>
            </div>

            <div class="form-group">
                <asp:Label ID="SelectedTeam" runat="server" CssClass="col-md-3 control-label">Selected Team:</asp:Label>
                <asp:DropDownList ID="lstSelectedTeam" runat="server" CssClass="col-md-4 form-control"></asp:DropDownList>
                <div class="col-md-5">
                <asp:Button ID="btnChangeTeam" CssClass="btn btn-primary btn-sm form-control" runat="server" OnClick="btnChangeTeam_Click" Text="<<Change Team"></asp:Button>
                </div>
            </div>

            <div class="form-group">
                <asp:Label ID="Label2" runat="server" CssClass="col-md-3 control-label">Enter Skill:</asp:Label>
                <asp:TextBox ID="txtSkill" runat="server" CssClass="col-md-5 form-control"></asp:TextBox>
                <div class="col-md-3">
                <asp:Button ID="btnInfo" CssClass="btn btn-primary btn-sm form-control" runat="server" OnClick="btnInfo_Click" Text="i"></asp:Button>
                </div>
            </div>

            <div class="form-group">
                <asp:Label ID="lblExpertiseLevel" runat="server" CssClass="col-md-3 control-label">Expertise Level:</asp:Label>
                <asp:DropDownList ID="lstExpertiseLevel" runat="server" CssClass="form-control" Width="280px"></asp:DropDownList>
            </div>

            <p>
            &nbsp;</p>

            <div class="form-group">
            <p>
                <asp:Button class="btn btn-success col-md-3" ID="btnProceed" runat="server" OnClick="btnProceed_Click" Text="Proceed"></asp:Button>
            </p>
            </div>
    
            
        </div>
            

           <div class="col-md-4"> 
               <table class="table table-striped">
                <asp:PlaceHolder ID = "PlaceHolder1" runat="server" />
                </table>
            </div>

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
                <asp:Parameter Name="ExpertiseLevelString" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="EmpName" Type="String" />
                <asp:Parameter Name="Skill" Type="String" />
                <asp:Parameter Name="ExpertiseLevel" Type="String" />
                <asp:Parameter Name="Id" Type="Int32" />
                <asp:Parameter Name="ExpertiseLevelString" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <p>
            &nbsp;</p>

        <div class="row">     
        <div class="col-md-2">
        <p>
            <asp:Button class="btn btn-info" ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update Details"/>
        </p>
        </div>
        <div class="col-md-2">
        <p>
            <asp:Button class="btn btn-info" ID="btnInsert" runat="server" OnClick="btnInsert_Click" Text="Insert New Skill"/>
        </p>
        </div>
        <div class="col-md-7">
        <p>
            <asp:Button class="btn btn-danger" ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete Skill" />
        </p>
        </div>       
            </div>
        </div>
        </div>
        </div>
        </div>
</asp:Content>
