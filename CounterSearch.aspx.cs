using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class CounterSearch : System.Web.UI.Page
{
    SqlConnection con = connection.GetConnect();
    SqlDataAdapter da;
    string strSQL;

    string exError;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usertypes"] == null)
        { Response.Redirect("signin.aspx"); }

        if (!IsPostBack)
            ClearControls();
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
        txtaddress.Text = null;
        txtconsumerno.Text = null;
        txtname.Text = null;
        ddtown.SelectedValue = null;
    }


    public void Searchby()
    {
        if (txtconsumerno.Text != "")
            strSQL = "select * from invoice where consumer_no = '" + txtconsumerno.Text + "'";

        if (txtname.Text != "")
            strSQL = "select * from invoice where consumer_name like '%" + txtname.Text + " %' AND town = '" + ddtown.SelectedValue + "'";

        if (txtaddress.Text != "")
            strSQL = "select * from invoice where consumer_address like '%" + txtaddress.Text + " %' AND town = '" + ddtown.SelectedValue + "'";

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

}