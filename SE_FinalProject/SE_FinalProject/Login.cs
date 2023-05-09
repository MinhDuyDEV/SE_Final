using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SE_FinalProject
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            textBoxUsername.Focus();
            textBoxPassword.UseSystemPasswordChar = true;
        }

        public bool VerifyAccount(string username, string password)
        {
            try
            {
                DataTable dt = ConnectionString.SelectQuery("select * from Agent where AgentAccount = '" + username + "' and AgentPassword =  '" + password + "'");
                if (dt.Rows.Count > 0 )
                {
                    return true;
                } else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;
            if (VerifyAccount(username, password))
            {
                MessageBox.Show("Logged in successfully!");
                this.Hide();
                Warehouse wh = new Warehouse();
                wh.Show();
            }
            else
            {
                MessageBox.Show("Login unsuccessful! Please check your account or password again.");
            }
        }

        private void textBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonLogin_Click(sender, e);
            }
        }

        
    }
}
