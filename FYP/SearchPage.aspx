<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchPage.aspx.cs" Inherits="FYP.SearchPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>

        <div class="jumbotron">
            <div class="form-horizontal">

            <div class="row">
            <div class="col-md-8">
            <h1>Search Page</h1>
                <h4>Search by Skills, Team or Employee Name!</h4>
            </div>
            <div class="col-md-4" style="margin-left: auto; margin-right: auto; text-align: right;">
                    <asp:Image runat="server" ImageUrl="~/Images/SkillsHubLogoSmall.jpg" style="width:260px;height:95px;"></asp:Image>  
            </div>
            </div>
                <hr />

            <div class="form-group">
                <asp:Label ID="SelectedTeam" runat="server" CssClass="col-md-5 control-label">Search By:</asp:Label>
                <asp:DropDownList ID="lstSearchBy" runat="server" CssClass="col-md-2 form-control"></asp:DropDownList>

                <div class="col-md-1">
                    <asp:Button ID="btnChangeSearchByQuery" CssClass="btn btn-primary btn-sm form-control" runat="server" Visible="false" OnClick="btnChangeSearchByQuery_Click" Text="<< Change"></asp:Button>
                </div>

                <div class="col-md-2">
                    <asp:Button ID="btnProceed" CssClass="btn btn-success form-control" runat="server" OnClick="btnProceed_Click" Text="Proceed"></asp:Button>
                </div>   
            </div>

            <div class="form-group">
                <asp:Label ID="lblEnterCriteria" runat="server" CssClass="col-md-5 control-label" Visible="false">Enter Skill:</asp:Label>
                <asp:DropDownList ID="lstEnterCriteria" runat="server" CssClass="col-md-2 form-control" Visible="false"></asp:DropDownList>
            </div>

            <div class="form-group">
                <asp:Button ID="btnSearch" CssClass="btn btn-success btn-lg col-md-offset-6" runat="server" Visible="false" OnClick="btnSearch_Click" Text="Search"></asp:Button>
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
