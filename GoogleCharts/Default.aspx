<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GoogleCharts.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Google Charts with ASP.NET / C#</title>
    <!--Load the AJAX API-->
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <!--Bar Chart Div that will hold the bar chart-->
            <div id="bar_chart_div"></div>
            
            <!--Pie Chart Div that will hold the pie chart-->
            <div id="pie_chart_div"></div>
        </div>
    </form>
    <!--Literals for binding script on front end from code behind -->
    <asp:Literal ID="pieChartScript" runat="server"></asp:Literal>
    <asp:Literal ID="barChartScript" runat="server"></asp:Literal>
</body>
</html>
