<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChartForm.aspx.cs" Inherits="FYP.ChartForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>

        <div class="jumbotron">
            <div class="form-horizontal">

            <h1>Team Charts</h1>
                <h4>View the Skills Charts of employees from different teams!</h4>
                <hr />

            <div class="form-group">
                <asp:Label ID="SelectedTeam" runat="server" CssClass="col-md-3 control-label">Selected Team:</asp:Label>
                <asp:DropDownList ID="lstSelectedTeam" runat="server" CssClass="col-md-4 form-control"></asp:DropDownList>
                <div class="col-md-2">
                <%--<asp:Label ID="Label1" runat="server" CssClass="col-sm-1 control-label"> </asp:Label>--%>
                <asp:Button ID="btnSelectTeam" CssClass="btn btn-primary btn-sm form-control" runat="server" OnClick="btnSelectTeam_Click" Text="Team Members View >>"></asp:Button>
                </div>
                <div class="col-md-1">
                <asp:Button ID="btnTeamView" CssClass="btn btn-info btn-sm form-control" runat="server" OnClick="btnTeamView_Click" Text="Team View >>"></asp:Button>
                </div>
            </div>

            <asp:Literal ID="lt" runat="server"></asp:Literal>
        
            <div class="row">
                <div class="col-md-6">
                <div class="form-group">
                    <div id="chart_div1"></div>  
                </div>
                </div> 
                <div class="col-md-6">   
                <div class="form-group"> 
                    <div id="chart_div2"></div> 
                </div>
                </div>
                <div class="col-md-6">
                <div class="form-group">
                    <div id="chart_div3"></div>
                </div> 
                </div>
                <div class="col-md-6">
                <div class="form-group">
                    <div id="chart_div4"></div>
                </div> 
                </div>
                <div class="col-md-6">
                <div class="form-group">
                    <div id="chart_div5"></div>
                </div> 
                </div>
                <div class="col-md-6">
                <div class="form-group">
                    <div id="chart_div6"></div>
                </div> 
                </div><div class="col-md-6">
                <div class="form-group">
                    <div id="chart_div7"></div>
                </div> 
                </div>
                <div class="col-md-6">
                <div class="form-group">
                    <div id="chart_div8"></div>
                </div> 
                </div>
                <div class="col-md-6">
                <div class="form-group">
                    <div id="chart_div9"></div>
                </div> 
                </div>
                <div class="col-md-6">
                <div class="form-group">
                    <div id="chart_div10"></div>
                </div> 
                </div>
            </div>
        </div>

            </div>

</asp:Content>
