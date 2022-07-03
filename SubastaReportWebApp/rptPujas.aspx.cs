using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SubastaReportWebApp
{
    public partial class rptPujas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //string cs = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=SubastaDB2;Integrated Security=True;";
                ////SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=WinFormsClass;Integrated Security=True");
                //SqlConnection connection = new SqlConnection(cs);
                //connection.Open();

                //SqlDataAdapter da = new SqlDataAdapter("Select * from Puja where ItemID = 2", connection);
                //DataSet ds = new DataSet();

                //da.Fill(ds);
                //ReportDataSource dataSource = new ReportDataSource("Puja", (DataTable)ds.Tables[0]);

                //ReportViewer1.LocalReport.DataSources.Add(dataSource);
                //ReportViewer1.LocalReport.Refresh();
            }
 
        }

        protected void ObjectDataSource2_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {

        }
    }
}