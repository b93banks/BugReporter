using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using System.Configuration;

namespace CS397Midterm_bbanks {
    public partial class Manager : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                if (Session["userID"] == null) {
                    Response.Redirect("Login.aspx");
                }
                lblUser.Text = Session["name"].ToString();

                OleDbConnection conn = new OleDbConnection(ConfigurationManager.ConnectionStrings["MidtermCS"].ConnectionString);
                string qry = "select * from bugs where status='Open'";
                OleDbCommand cmd = new OleDbCommand(qry, conn);
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

                qry = "select Name, EmployeeID from Employee where type=@type";
                cmd = new OleDbCommand(qry, conn);
                cmd.Parameters.AddWithValue("@type", "Developer");
                da = new OleDbDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds, "Names");
                ddlDevs.DataSource = ds.Tables["Names"];
                ddlDevs.DataTextField = "Name";
                ddlDevs.DataValueField = "EmployeeID";
                ddlDevs.DataBind();
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

        protected void btnAssign_Click(object sender, EventArgs e) {
            if (ddlBugs.SelectedValue == "default") {
                lblError.Text = "Please select a bug.";
            }
            else {
                OleDbConnection conn = new OleDbConnection(ConfigurationManager.ConnectionStrings["MidtermCS"].ConnectionString);
                string qry = "update Bugs set AssignedTo=@devID, Status='Assigned' where BugID=@bugID";
                OleDbCommand cmd = new OleDbCommand(qry, conn);
                cmd.Parameters.AddWithValue("@devID", ddlDevs.SelectedValue.Trim());
                cmd.Parameters.AddWithValue("@bugID", ddlBugs.SelectedValue.Trim());

                conn.Open();
                int retVal = cmd.ExecuteNonQuery();
                conn.Close();
                if (retVal > 0) {
                    Response.Redirect("Manager.aspx");
                }
                else {
                    lblMessage.Text = "Error!";
                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e) {
            Response.Redirect("Login.aspx");
        }
        
    }
}