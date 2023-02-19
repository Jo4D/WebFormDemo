using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo.WebForm
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           var datalink = ConfigurationManager.ConnectionStrings["DBWF"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(datalink))
            {
                #region ExcuteReader
                SqlCommand command = new SqlCommand();
                command.CommandText = "Select * From Book";
                command.Connection = connection;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                DetailsView1.DataSource = reader;
                DetailsView1.DataBind();
                #endregion

                // SqlCommand sqlCommand = new SqlCommand();
                // sqlCommand.Connection = connection;
                // sqlCommand.CommandText = "Select count(BookId) From Book";
                // connection.Open();
                //int TotalRows = (int)sqlCommand.ExecuteScalar();
                // Response.Write($"The total rows is {TotalRows}");

            }


        }
    }
}