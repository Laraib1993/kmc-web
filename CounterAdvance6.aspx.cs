using System;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class CounterAdvance6 : System.Web.UI.Page
{
    ReportDocument rpt = new ReportDocument();
    SqlConnection con = connection.GetConnect();
    string exError;
    string crit;
    string se;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["user"] == null)
        {
            if (Session["role"] == null) { Response.Redirect("signin.aspx"); }
            else if (Session["role"].ToString() != "Billing Counter Operator") { Response.Redirect("signin.aspx"); }

        }

        se = (Session["user"]).ToString();


        if (!IsPostBack)
        {
            txtCNIC.Focus();
        }
    }

    private void GPreportdatewise_Unload(object sender, System.EventArgs e)
    {
        rpt.Close();
        rpt.Dispose();
        GC.Collect();
    }

    private void BindReport()
    {
        try
        {
            GPreportdatewise.DisplayToolbar = false;
            GPreportdatewise.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None;
            GPreportdatewise.Zoom(100);
            GPreportdatewise.HasExportButton = false;
            GPreportdatewise.HasPrintButton = false;
            GPreportdatewise.HasToggleGroupTreeButton = false;
            GPreportdatewise.HasToggleParameterPanelButton = false;
            GPreportdatewise.HasZoomFactorList = false;
            GPreportdatewise.HasCrystalLogo = false;
            GPreportdatewise.Font.Size = 8;
            GPreportdatewise.GroupTreeStyle.Font.Size = 8;
            GPreportdatewise.GroupTreeStyle.ShowLines = false;
            GPreportdatewise.ToolbarStyle.Width = Unit.Parse("2046px");
            rpt.Load(Server.MapPath("~/reports/advancebill6.rpt"));
            ConnectionInfo conInfo = new ConnectionInfo();
            {
                var withBlock = conInfo;
                withBlock.ServerName = "WIN-CFJNVMD2S5P";
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
            GPreportdatewise.ReportSource = rpt;
            rpt.RecordSelectionFormula = "{invoice.consumer_no} = '" + txtconsumerno.Text + "' and {invoice.status} = 1";

            GPreportdatewise.RefreshReport();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }


    protected void btnsearch_Click(object sender, System.EventArgs e)
    {
        if (txtconsumerno.Text != "")
        { BindReport(); }
    }

    protected void btnins_Click(object sender, System.EventArgs e)
    {
        SqlCommand cmd1;
        int ra;

        try
        {
            con.Open();
            cmd1 = new SqlCommand("insert into duplicatebill_history  (Consumer_No,Category,zone, bill_type,createdby, createdon,issuedate,duedate,cnic,phone) SELECT  consumer_no, category,zone,'6 Quater Bill', '" + se + "', GETDATE(),GETDATE(),dateadd(day, 10, (CONVERT(VARCHAR(10), getdate(), 111))),'" + txtCNIC.Value + "','" + txtphone.Value + "' FROM invoice WHERE  consumer_no = '" + txtconsumerno.Text + "'", con);
            ra = cmd1.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
        }
    }
}