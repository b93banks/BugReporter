using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Configuration;

namespace CS397Midterm_bbanks {
    public partial class Tester : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["uName"] == null) {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack) {
                lblUser.Text = Session["name"].ToString();

                OleDbConnection conn = new OleDbConnection(ConfigurationManager.ConnectionStrings["MidtermCS"].ConnectionString);
                string qry = "select * from bugs where userID=@userID";
                OleDbCommand cmd = new OleDbCommand(qry, conn);
                cmd.Parameters.AddWithValue("@userID", Session["userID"].ToString());
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                gvDisplay.DataSource = ds;
                gvDisplay.DataBind();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e) {
            OleDbConnection conn = new OleDbConnection(ConfigurationManager.ConnectionStrings["MidtermCS"].ConnectionString);
            string qry = "insert into Bugs (EnteredBy, Subject, Priority, Description, Status) values (@eb, @sub, @pri, @des, 'Open')";
            OleDbCommand cmd = new OleDbCommand(qry, conn);
            cmd.Parameters.AddWithValue("@eb", Session["userID"].ToString());
            cmd.Parameters.AddWithValue("@sub", tbxSubject.Text);
            cmd.Parameters.AddWithValue("@pri", ddlPriority.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@des", tbxDescription.Text);

            conn.Open();
            int retVal = cmd.ExecuteNonQuery();
            conn.Close();
            if (retVal == 1) {
                lblMessage.Text = "Major has been updated";
                Response.Redirect("Tester.aspx");
            }
            else {
                lblMessage.Text = "Error!";
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e) {
            Response.Redirect("Login.aspx");
        }
    }
}