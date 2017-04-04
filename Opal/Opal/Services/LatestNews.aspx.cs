﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Opal.Controls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Zamani;

public partial class Services_LatestNews : PageBaseClass
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["ArvidSMSConnectionString"].ConnectionString.ToString();
        SqlConnection sqlConnection = new SqlConnection(ConnectionString);
        sqlConnection.Open();

        if (Page.Request.QueryString.AllKeys.Contains("NewsID"))
        {
            int NewsID = Int32.Parse(Page.Request.QueryString["NewsID"]);
            string MyQuery = "SELECT * FROM LatestAnnounces WHERE ID='" + NewsID + "'";
            SqlCommand cmd0 = new SqlCommand(MyQuery, sqlConnection);
            SqlDataAdapter DA = new SqlDataAdapter(cmd0);
            SqlDataReader DR = cmd0.ExecuteReader();
            DataSet DS = new DataSet();

            if (DR.Read())
            {
                DR.Close();
                DA.Fill(DS);

                this.gvResults.DataSource = DS;
                this.gvResults.DataBind();
            }
            else
            {
                WebMsgBox.Show("موری برای شناسه وارد شده یافت نشد !");
            }
        }
        else
        {

        }
    }
}