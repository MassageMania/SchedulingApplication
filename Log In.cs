using MySql.Data.MySqlClient;
using System;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduling_Appointment
{
    public partial class LogIn : Form
    {
        //private List<User> users;
        private string culture;

        public LogIn()
        {
            InitializeComponent();
            //CultureInfo.CurrentCulture = new CultureInfo("fr");     //For testing purposes only Remove before submission.

            //Language check here.
            if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "fr")
            {
                lblRegion.Text = ("Region");
                lblPassword.Text = ("Mot de passe ");
                lblUsername.Text = ("Nom d'utiliasateur");
                btnLogIn.Text = ("S'identifier");
                btnCancel.Text = ("Annuler");
            }
        }

        private void LoginToFrench()
        {
            lblRegion.Text = ("Region");
            lblPassword.Text = ("Mot de passe ");
            lblUsername.Text = ("Nom d'utiliasateur");
            btnLogIn.Text = ("S'identifier");
            btnCancel.Text = ("Annuler");
        }
        private void LogIn_Load(object sender, EventArgs e)
        {
            //culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            ////users = DBconnection.getAllUsers();
            //if (culture == "FR")
            //{
            //    LoginToFrench();
            //}
        }

        static public int FindUser(string userName, string password)
        {
            string query = @"SELECT userID FROM user WHERE userName = @userName AND password = @password";
            MySqlCommand cmd = new MySqlCommand(query, DBconnection.conn);
            

            cmd.Parameters.AddWithValue("userName", userName);
            cmd.Parameters.AddWithValue("password", password);

            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                DBconnection.SetUserId(Convert.ToInt32(reader[0]));
                DBconnection.SetUserName(userName);
                reader.Close();
                return DBconnection.GetUserID();
            }
            return 0;
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            try
            {
                if (FindUser(tbUsername.Text, tbPassword.Text) !=0)
                {
                    var MainMenu = new MainMenu();
                    MainMenu.Show();
                    this.Hide();



                    //if (culture == "FR")
                    //{
                    //    throw new LoginException("Doit avoir un nom d'utilisateur et un mot de passe pour se connecter.");
                    //}
                    //throw new LoginException("Must have username and password to log in.");
                }

                else 
                {
                    if (culture == "FR")
                    {
                        throw new LoginException("Nom d'utilisateur ou mot de passe incorrect.");
                    }
                    throw new LoginException("Username or password incorrect.");
                }
                //Todo Fix Log Activity
                //ToLog.logActivity(DBconnection.GetUserID());

                //var MainMenu = new MainMenu();
                //MainMenu.Show();
                //this.Hide();
            }

            catch (LoginException error)
            {
                lblError.Text = error.Message;
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}