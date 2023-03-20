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
using System.IO;

namespace Scheduling_Appointment
{
    public partial class LogIn : Form
    {
        //MySqlConnection conn; 
        //string connString;
        string invalidLoginHeader = "Login Error";
        string invalidLogin = "Invalid user credentials entered.  Please try again.";

        public LogIn()
        {
            InitializeComponent();

            //Language check here.
            if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "fr")
            {
                lblPassword.Text = ("Mot de passe ");
                lblUsername.Text = ("Nom d'utiliasateur");
                btnLogIn.Text = ("S'identifier");
                btnCancel.Text = ("Annuler");
                invalidLogin = "Informations d’identification utilisateur entrées non valides.  Veuillez réessayer.";
                invalidLoginHeader = "Erreur de connexion";
            }
        }


        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string userName = tbUsername.Text;
            string password = tbPassword.Text;
            
            string loginQuery = @"SELECT * FROM user WHERE username = @userName and password = @password";

            DataTable dataTable = new DataTable();

            MySqlCommand mySqlCommand = new MySqlCommand(loginQuery, DBconnection.conn);
            mySqlCommand.Parameters.AddWithValue("@userName", userName);
            mySqlCommand.Parameters.AddWithValue("@password", password);

            //mySqlCommand.Connection = conn;
            _ = new MySqlDataAdapter(mySqlCommand).Fill(dataTable);


            string folderPath = @"C:\UserLoginLog";
            string fileName = @"\LoginLog.txt";
            fileName = folderPath + fileName;

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            if (dataTable.Rows.Count <= 0)
            {
                MessageBox.Show(invalidLogin);

                using (StreamWriter userLoginFile = File.AppendText(fileName))
                {
                    string loginResult = "Failed login for user: " + userName + DateTime.UtcNow.ToString("yyyy.MM.dd hh:mm:ss");

                    userLoginFile.WriteLine(loginResult);
                    userLoginFile.Close();
                }
                return;
            }
            else
            {
                using (StreamWriter userLoginFile = File.AppendText(fileName))
                {
                    string loginResult = "User " + userName + " logged in at " + DateTime.UtcNow.ToString("yyyy.MM.dd hh:mm:ss");

                    userLoginFile.WriteLine(loginResult);
                    userLoginFile.Close();
                }

                Appointments appointments = new Appointments();
                appointments.Show();
                this.Hide();
            }
        }

        


        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}