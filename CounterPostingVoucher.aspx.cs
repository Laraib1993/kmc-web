using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class CounterPostingVoucher : System.Web.UI.Page
{
    SqlConnection con = connection.GetConnect();
    SqlDataAdapter da;
    string strSQL;

    string exError;


    public void Searchby()
    {
        if (txtconsumerno.Text != "")
            strSQL = "select * from posting_voucher where Consumer_no = '" + txtconsumerno.Text + "'";



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

    private void ClearControls()
    {
        gvSearch.DataSource = null;
        gvSearch.DataBind();
        gvSearch.Visible = false;

        txtconsumerno.Text = null;
    }

    protected void btncancel_Click(object sender, System.EventArgs e)
    {
        ClearControls();
    }


    protected void btnsearch_Click(object sender, System.EventArgs e)
    {
        Searchby();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usertypes"] == null)
            Response.Redirect("signin.aspx");

        if (!IsPostBack)
            ClearControls();
    }
}