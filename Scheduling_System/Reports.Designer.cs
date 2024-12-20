namespace Scheduling_System
{
    partial class Reports
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rptTextBox = new System.Windows.Forms.RichTextBox();
            this.apptTypeRadio = new System.Windows.Forms.RadioButton();
            this.userScheduleRadio = new System.Windows.Forms.RadioButton();
            this.customerScheduleRadio = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // rptTextBox
            // 
            this.rptTextBox.Location = new System.Drawing.Point(12, 59);
            this.rptTextBox.Name = "rptTextBox";
            this.rptTextBox.Size = new System.Drawing.Size(776, 379);
            this.rptTextBox.TabIndex = 0;
            this.rptTextBox.Text = "";
            // 
            // apptTypeRadio
            // 
            this.apptTypeRadio.AutoSize = true;
            this.apptTypeRadio.Checked = true;
            this.apptTypeRadio.Location = new System.Drawing.Point(493, 21);
            this.apptTypeRadio.Name = "apptTypeRadio";
            this.apptTypeRadio.Size = new System.Drawing.Size(71, 17);
            this.apptTypeRadio.TabIndex = 1;
            this.apptTypeRadio.TabStop = true;
            this.apptTypeRadio.Text = "ApptType";
            this.apptTypeRadio.UseVisualStyleBackColor = true;
            this.apptTypeRadio.CheckedChanged += new System.EventHandler(this.apptTypeRadio_CheckedChanged);
            // 
            // userScheduleRadio
            // 
            this.userScheduleRadio.AutoSize = true;
            this.userScheduleRadio.Location = new System.Drawing.Point(570, 21);
            this.userScheduleRadio.Name = "userScheduleRadio";
            this.userScheduleRadio.Size = new System.Drawing.Size(95, 17);
            this.userScheduleRadio.TabIndex = 2;
            this.userScheduleRadio.Text = "User Schedule";
            this.userScheduleRadio.UseVisualStyleBackColor = true;
            this.userScheduleRadio.CheckedChanged += new System.EventHandler(this.userScheduleRadio_CheckedChanged);
            // 
            // customerScheduleRadio
            // 
            this.customerScheduleRadio.AutoSize = true;
            this.customerScheduleRadio.Location = new System.Drawing.Point(671, 21);
            this.customerScheduleRadio.Name = "customerScheduleRadio";
            this.customerScheduleRadio.Size = new System.Drawing.Size(106, 17);
            this.customerScheduleRadio.TabIndex = 3;
            this.customerScheduleRadio.Text = "User to Customer";
            this.customerScheduleRadio.UseVisualStyleBackColor = true;
            this.customerScheduleRadio.CheckedChanged += new System.EventHandler(this.customerScheduleRadio_CheckedChanged);
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.customerScheduleRadio);
            this.Controls.Add(this.userScheduleRadio);
            this.Controls.Add(this.apptTypeRadio);
            this.Controls.Add(this.rptTextBox);
            this.Name = "Reports";
            this.Text = "Reports";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rptTextBox;
        private System.Windows.Forms.RadioButton apptTypeRadio;
        private System.Windows.Forms.RadioButton userScheduleRadio;
        private System.Windows.Forms.RadioButton customerScheduleRadio;
    }
}