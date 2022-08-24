using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;
using MySql.Data.MySqlClient;

namespace SchedulingApplication
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void showCorrectLanguage()
        { switch (RegionInfo.CurrentRegion.EnglishName)
            {
                case "United States":
                    showInEnglish();
                    break;
                case "French":
                    showInFrench();
                    break;
                default:
                    showInEnglish();
                    break;
            }
        }
        private void showInEnglish()
        {
            this.Text = "Log in";
            lblAccountName.Text = "Username";
            lblPassword.Text = "Password";
            btnLogIn.Text = "Sign in";
        }
        private void showInFrench()
        {
            this.Text = "Log in";
            lblAccountName.Text = "Nom de l’utilisateur";
            lblPassword.Text = "mot de passe";
            btnLogIn.Text = "Connexion";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string userName = tbAccountName.Text;
            string password = tbPassword.Text;

            MySqlCommand cmd = new MySqlCommand();
            cmd = (SELECT count(*) FROM user WHERE userName = tbAccountName.Text AND password = tbPassword.Text, DBConnection.conn);
            adap.Fill(dt);
            
            /*if (read.HasRows)
            {
                while (read.Read())
                { 
                    Data.setCurrentUser(Convert.ToInt32(read.GetString(0)));
                }
                Main ss = new Main();
                ss.Show();
            }/*
            /*else
            {
            MessageBox.Show("Incorrect Username or Password");
            }*/
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        
    }
}
