using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BillCounter : System.Web.UI.MasterPage
{

    protected void Page_Init(object sender, System.EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["usertypes"].ToString() == "")
            { Response.Redirect("signin.aspx"); }
            else
            {
                if (Session["role"].ToString() == "Billing Counter Operator")
                {
                    lblLoggedinAs.ForeColor = System.Drawing.Color.LightGoldenrodYellow;
                    lblLoggedinAs.Font.Bold = true;
                    lblLoggedinAs.Font.Size = 12;
                    string stype = "Billing Counter Operator";
                    lblLoggedinAs.Text = "MUCT KMC BILLING SYSTEM " + Session["user"].ToString() + " as " + stype.ToUpper() + "";
                }


                else
                {
                    Response.Redirect("signin.aspx");

                }




            }
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
