using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class CounterPaymentHistory : System.Web.UI.Page
{

    SqlConnection con = connection.GetConnect();
    SqlDataAdapter da;
    string strSQL;

    string exError;


    public void Searchby()
    {
        if (txtconsumerno.Text != "")
            strSQL = "select * from payment_history_Main where Consumer_No = '" + txtconsumerno.Text + "' order by report_id";



        da = new SqlDataAdapter(strSQL, con);
        con.Open();
        DataSet ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            System.Threading.Thread.Sleep(100);
            gvSearch.DataSource = ds.Tables[0];
            gvSearch.DataBind();
            gvSearch.Visible = true;
            if (ds != null)
                ds.Dispose();
            ds = null/* TODO Change to default(_) if this is not a reference type */;
            if (da != null)
                da.Dispose();
            da = null;
            con.Close();
            con.Dispose();
            con = null;
        }
    }

    protected void btnsearch_Click(object sender, System.EventArgs e)
    {
        Searchby();
    }

    protected void btncancel_Click(object sender, System.EventArgs e)
    {
        ClearControls();
    }

    private void ClearControls()
    {
        gvSearch.DataSource = null;
        gvSearch.DataBind();
        gvSearch.Visible = false;
        txtconsumerno.Text = null;
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usertypes"] == null)
        { Response.Redirect("signin.aspx"); }

        if (!IsPostBack)
        { ClearControls(); }
    }
}