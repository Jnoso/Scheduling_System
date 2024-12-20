using Scheduling_System.Classes;
using Scheduling_System.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduling_System
{
    public partial class Login : Form
    {
        private loginform loginform = new loginform();
        public Label UsernameLabel => usernameLabel;
        public Label PasswordLabel => passwordLabel;
        public Button LoginBtn => loginBtn;
        public Button CancelBtn => cancelBtn;
        private string localErrorMsg;

        //Obtain language letters
        string languageName = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;

        public Login()
        {
            InitializeComponent();

            //display region info and time
            regiontime.Text = loginform.RegionInform();

            //Perform localization
            loginform.ApplyLocalization(languageName, this, out localErrorMsg);
            
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            bool loginCorrect = loginform.LoginAttempt(usernameBox.Text, passwordBox.Text);
            
            if (loginCorrect)
            {
                //calls method to connect to database
                DBConnection.ConnectToDb();

                //opens new window
                ScheduleSystem schedulesystem = new ScheduleSystem();
                schedulesystem.Show();

                loginform.UserAlert(this);

                //calls method to create text file Login_History.txt
                loginform.LogInRecord(usernameBox.Text);
            }
            else
            {
                //Shows error message
                MessageBox.Show(localErrorMsg);
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
