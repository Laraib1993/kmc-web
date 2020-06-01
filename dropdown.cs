using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Configuration;
using System;
/// <summary>
/// Summary description for dropdown
/// </summary>
public class dropdown
{
    



    public static List<ListItem> listEmplMUCT()
    {

        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["kmcConnectionString"].ConnectionString;
        using (SqlCommand cmd = new SqlCommand("sp_empMUCT", conn))
        {
            List<ListItem> div = new List<ListItem>();



            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();



            using (SqlDataReader sdr = cmd.ExecuteReader())
            {
                while (sdr.Read())
                {
                    div.Add(new ListItem
                    {
                        Value = sdr[2].ToString(),
                        Text = sdr[1].ToString()
                    });
                }
            }

            return div;


        }


    }
}