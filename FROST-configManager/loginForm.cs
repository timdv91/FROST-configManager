using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FROST_configManager
{
    public partial class loginForm : Form
    {
        //Public login vars:
        public string username;
        public string password;

        public loginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //check if textboxes contain chars:
            if (txtUserName.Text.Length > 0 && txtPassword.Text.Length > 0)
            {
                //set result values, usable in main form:
                this.username = txtUserName.Text;
                this.password = txtPassword.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else //when one or more textboxes is empty, show errorprovider:
            {
                if(txtUserName.Text.Length == 0)
                    errorProvider1.SetError(txtUserName, "Username required!");
                else if(txtPassword.Text.Length == 0)
                    errorProvider1.SetError(txtPassword, "Password required!");
            }
        }
    }
}
