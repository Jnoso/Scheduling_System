using MySql.Data.MySqlClient;
using Scheduling_System.Classes;
using Scheduling_System.DBClasses;
using Scheduling_System.Properties;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduling_System.Controller
{
    public class loginform
    {
        ApptInfoQuery apptInfoQuery = new ApptInfoQuery();
        
        //Validates username and password
        public bool LoginAttempt(string username, string password)
        {
            string userInput = username.ToLower();
            string dbUser = " ";
            string dbPassword = " ";

            string query = @"SELECT userName, password, userId FROM user WHERE userName = @userName";

            using (MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn))
            {
                cmd.Parameters.AddWithValue("@userName", userInput);

                try
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            dbUser = reader["userName"].ToString();
                            dbPassword = reader["password"].ToString();
                        }

                        if (userInput == dbUser && password == dbPassword)
                        {
                            int userId = Convert.ToInt32(reader["userId"]);
                            UserLogin.UserId = userId;
                            return true;
                        }
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            return false;
        }

        //Obtain and display region + time
        public string RegionInform()
        {
            string time = DateTime.Now.ToString("HH:mm:ss tt");
            string region = RegionInfo.CurrentRegion.ThreeLetterISORegionName;

            return region + " " + time;
        }

        //Apply Localization to Login Form and error message
        public void ApplyLocalization (string languageLetter, Login login, out string localErrorMsg)
        {
            //Set the language
            CultureInfo.CurrentUICulture = new CultureInfo(languageLetter);

            //Update Label/Strings
            login.UsernameLabel.Text = Resources.username;
            login.PasswordLabel.Text = Resources.password;
            login.LoginBtn.Text = Resources.login;
            login.CancelBtn.Text = Resources.cancel;

            //Output local error msg
            localErrorMsg = Resources.errorMsg;
        }

        //Create and append to log username and time
        public void LogInRecord(string username)
        {
            string path = Path.Combine(Application.StartupPath, "Records");

            //Create "Records" folder if it doesn't exist
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string filepath = Path.Combine(path, "Login_History.txt");

            string log = string.Format("{0, -10} {1, -20}", username, DateTime.Now.ToString("HH:MM:ss tt"));

            //Create and write || append to existing .txt
            if (File.Exists(filepath))
            {
                using (StreamWriter appendLog = File.AppendText(filepath))
                {
                    appendLog.WriteLine(log);
                }
            }
            else
            {
                using (StreamWriter newFile = new StreamWriter(filepath))
                {
                    newFile.WriteLine(log);
                }
            }
        }

        public void UserAlert(Login login)
        {
            int userId = UserLogin.UserId;

            var startTimeList = apptInfoQuery.UserAppointmentAlert(userId);

            foreach(var time in startTimeList)
            {
                TimeSpan timeDifference = time - DateTime.Now;

                if (timeDifference.TotalMinutes < 15 && timeDifference.TotalMinutes > 0)
                {
                    MessageBox.Show("There is an appointment within 15minutes", "Appontment Alarm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }
    }
}
