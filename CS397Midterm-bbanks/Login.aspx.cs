using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace CS397Midterm_bbanks {
    public partial class Login : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            Session.Timeout = 30;
        }

        protected void btnLogin_Click(object sender, EventArgs e) {
            OleDbConnection conn = new OleDbConnection(ConfigurationManager.ConnectionStrings["MidtermCS"].ConnectionString);
            string qry = "select Password, Type, EmployeeID, Name from Employee where Login=@uName";
            OleDbCommand cmd = new OleDbCommand(qry, conn);
            cmd.Parameters.AddWithValue("@uName", tbxUsername.Text);
            conn.Open();
            OleDbDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            if (rdr.HasRows) {
                MD5 md5 = new MD5CryptoServiceProvider();
                md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(tbxPassword.Text));
                byte[] result = md5.Hash;

                StringBuilder strBuilder = new StringBuilder();
                for (int i = 0; i < result.Length; i++) {
                    strBuilder.Append(result[i].ToString("x2"));
                }

                if (rdr["Password"].ToString().Equals(strBuilder.ToString())) {
                    lblMessage.Text = "Successful!";
                    Session["uName"] = tbxUsername.Text;
                    Session["userID"] = rdr["EmployeeID"];
                    Session["name"] = rdr["Name"];
                    if (rdr["Type"].ToString().ToLower() == "developer") {
                        Response.Redirect("Developer.aspx");
                    }
                    else if (rdr["Type"].ToString().ToLower() == "manager") {
                        Response.Redirect("Manager.aspx");
                    }
                    else {
                        Response.Redirect("Tester.aspx");
                    }
                }
                else {
                    lblMessage.Text = "Username and Password do not match";
                }
            }
            else {
                lblMessage.Text = "Username and Password do not match";
            }
            rdr.Close();
            conn.Close();
        }
    }
}