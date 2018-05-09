using System;
using System.Data;
using System.Text;

namespace GoogleCharts
{
    public partial class Default : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPieChart();
                LoadBarChart();
            }
        }

        //Create Google Pie Chart
        protected void LoadPieChart()
        {
            DBClass objDB = new DBClass(); //Database Class for dynamic data
            DataTable recTable = new DataTable();   
            recTable=objDB.GetDataTable(); //Get Table from database

            StringBuilder chartString = new StringBuilder();
            chartString.Append(" <script type='text/javascript'>");

            chartString.Append(" google.charts.load('current', { 'packages': ['corechart'] });");
            chartString.Append(" google.charts.setOnLoadCallback(drawChart);");
            
            chartString.Append(" function drawChart() {");
            chartString.Append(" var data = new google.visualization.DataTable();");
            chartString.Append(" data.addColumn('string', 'Province');");
            chartString.Append(" data.addColumn('number', 'Population');");
            chartString.Append(" data.addRows([");

            foreach (DataRow row in recTable.Rows)
            {
                foreach (DataColumn column in recTable.Columns)
                {
                    chartString.Append(" ['" + column.ColumnName + "', "+row[column.ColumnName]+"],");
                }
            }
            
            chartString.Append(" ]);");
            chartString.Append(" var options = {");
            chartString.Append(" 'title': 'Pakistan Population',");
            chartString.Append(" is3D: true,");
            chartString.Append(" 'width': 800,");
            chartString.Append(" 'height': 400");
            chartString.Append(" };");

            chartString.Append(" var chart = new google.visualization.PieChart(document.getElementById('pie_chart_div'));");
            chartString.Append(" chart.draw(data, options);");
            chartString.Append(" }");
            chartString.Append(" </script>");

            pieChartScript.Text = chartString.ToString();  //Bind Script to front end literals
        }

        //Load Google Bar Chart
        protected void LoadBarChart()
        {
            DBClass objDB = new DBClass(); //Database Class for dynamic data
            DataTable recTable = new DataTable();
            recTable = objDB.GetDataTable(); //Get Table from database

            StringBuilder chartString = new StringBuilder();
            chartString.Append(" <script type='text/javascript'>");

            chartString.Append(" google.load('visualization', '1', {packages:['columnchart']});");
            chartString.Append(" google.setOnLoadCallback(drawChart);");

            chartString.Append(" function drawChart() {");
            chartString.Append(" var data = google.visualization.arrayToDataTable([");
            chartString.Append(" ['Province', 'Population'],");

            foreach (DataRow row in recTable.Rows)
            {
                foreach (DataColumn column in recTable.Columns)
                {
                    chartString.Append(" ['" + column.ColumnName + "', " + row[column.ColumnName] + "],");
                }
            }
            
            chartString.Append(" ]);");

            chartString.Append(" var chart = new google.visualization.ColumnChart(document.getElementById('bar_chart_div'));");
            chartString.Append(" chart.draw(data, {width: 600, height: 300, is3D: true, title: 'Pakistan Population'});");
            chartString.Append(" }");
            chartString.Append(" </script>");

            barChartScript.Text = chartString.ToString(); //Bind Script to front end literals
        }
    }
}