<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChartForm.aspx.cs" Inherits="FYP.ChartForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>

        <div class="jumbotron">
            <div class="form-horizontal">

            <h1>Team Charts</h1>
                <h4>View the charts of employees from different teams!</h4>
                <hr />

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

    
    <div class="form-horizontal">
        <div class="form-group">
        <div class="col-md-9">
            <%--<asp:Button class="btn btn-info btn-sm" ID="btnDylan" runat="server" Text="Dylan" OnClick="btnDylan_Click" />
            <asp:Button class="btn btn-info btn-sm" ID="btnSarah" runat="server" Text="Sarah" OnClick="btnSarah_Click" />
            <asp:Button class="btn btn-info btn-sm" ID="btnMegan" runat="server" Text="Megan" OnClick="btnMegan_Click" />
            <asp:Button class="btn btn-info btn-sm" ID="btnChris" runat="server" Text="Chris" OnClick="btnChris_Click" />--%>
        </div>
            
    
            
            
            

    <a href="InputPage.aspx" class="btn btn-info btn-sm">Update Details &raquo;</a>
        </div>
        </div>
            </div>

</asp:Content>
