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
    public partial class Developer : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                if (Session["userID"] == null) {
                    Response.Redirect("Login.aspx");
                }
                lblUser.Text = Session["name"].ToString();

                OleDbConnection conn = new OleDbConnection(ConfigurationManager.ConnectionStrings["MidtermCS"].ConnectionString);
                string qry = "select * from Bugs where AssignedTo=@userID and status='Assigned'";
                OleDbCommand cmd = new OleDbCommand(qry, conn);
                string userID = Session["userID"].ToString();
                cmd.Parameters.AddWithValue("@userID", Session["userID"].ToString());
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();

                da.Fill(ds, "Subjects");
                ddlBugs.DataSource = ds.Tables["Subjects"];
                ddlBugs.DataTextField = "Subject";
                ddlBugs.DataValueField = "BugID";
                ddlBugs.DataBind();

                ListItem def = new ListItem("Choose Bug", "default", true);
                def.Selected = true;
                ddlBugs.Items.Add(def);
            }
        }

        protected void btnFix_Click(object sender, EventArgs e) {
            if (ddlBugs.SelectedValue == "default") {
                lblError.Text = "Please select a bug.";
            }
            else {
                string bugID = ddlBugs.SelectedValue.Trim();
                string changes = tbxChanges.Text;

                OleDbConnection conn = new OleDbConnection(ConfigurationManager.ConnectionStrings["MidtermCS"].ConnectionString);
                string qry = "update Bugs set Status='Completed', Changes=@changes where BugID=@bugID";
                OleDbCommand cmd = new OleDbCommand(qry, conn);
                cmd.Parameters.AddWithValue("@changes", changes);
                cmd.Parameters.AddWithValue("@BugID", bugID);

                conn.Open();
                int retVal = cmd.ExecuteNonQuery();
                conn.Close();
                if (retVal > 0) {
                    Response.Redirect("Developer.aspx");
                }
                else {
                    lblMessage.Text = "Error!";
                }
            }    
        }

        protected void ddlBugs_SelectedIndexChanged(object sender, EventArgs e) {
            OleDbConnection conn = new OleDbConnection(ConfigurationManager.ConnectionStrings["MidtermCS"].ConnectionString);
            string qry = "Select * from bugs where BugID=@bugID";
            OleDbCommand cmd = new OleDbCommand(qry, conn);
            cmd.Parameters.AddWithValue("@bugID", ddlBugs.SelectedValue.Trim());
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dvDisplay.DataSource = ds;
            dvDisplay.DataBind();
        }

        protected void btnLogout_Click(object sender, EventArgs e) {
            Response.Redirect("Login.aspx");
        }
    }
}