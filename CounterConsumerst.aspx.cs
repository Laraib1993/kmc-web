using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

public partial class CounterConsumerst : System.Web.UI.Page
{
    ReportDocument rpt = new ReportDocument();
    string exError;
    string crit;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usertypes"] == null )
            Response.Redirect("signin.aspx");

        if (!IsPostBack)
            txtconsumerno.Focus();
    }

    private void consumerstatment_Unload(object sender, System.EventArgs e)
    {
        rpt.Close();
        rpt.Dispose();
        GC.Collect();
    }


    private void BindReport()
    {
        try
        {
            consumerstatment.DisplayToolbar = true;
            consumerstatment.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None;
            consumerstatment.Zoom(100);
            consumerstatment.HasExportButton = true;
            consumerstatment.HasPrintButton = false;
            consumerstatment.HasToggleGroupTreeButton = false;
            consumerstatment.HasToggleParameterPanelButton = false;
            consumerstatment.HasZoomFactorList = false;
            consumerstatment.HasCrystalLogo = false;
            consumerstatment.Font.Size = 8;
            consumerstatment.GroupTreeStyle.Font.Size = 8;
            consumerstatment.GroupTreeStyle.ShowLines = false;
            consumerstatment.ToolbarStyle.Width = Unit.Parse("2046px");
            rpt.Load(Server.MapPath("~/reports/consumer_st.rpt"));
            ConnectionInfo conInfo = new ConnectionInfo();
            {
                var withBlock = conInfo;
                withBlock.ServerName = "WIN-H4F4JGGN50A";
                withBlock.DatabaseName = "kmc";
                withBlock.UserID = "sa";
                withBlock.Password = "Sprint@5555";
            }

            foreach (CrystalDecisions.CrystalReports.Engine.Table MyTable in rpt.Database.Tables)
            {
                TableLogOnInfo MyTableLogonInfo = MyTable.LogOnInfo;
                MyTableLogonInfo.ConnectionInfo = conInfo;
                MyTable.ApplyLogOnInfo(MyTableLogonInfo);
            }

            rpt.ReadRecords();
            consumerstatment.ReportSource = rpt;
            rpt.RecordSelectionFormula = "{invoice.consumer_no} = '" + txtconsumerno.Text + "'";

            consumerstatment.RefreshReport();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    protected void btnsearch_Click(object sender, System.EventArgs e)
    {
        if (txtconsumerno.Text != "")
            BindReport();
    }


}