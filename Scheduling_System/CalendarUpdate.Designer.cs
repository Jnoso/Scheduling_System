namespace Scheduling_System
{
    partial class CalendarUpdate
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
            this.dgvApptCustomer = new System.Windows.Forms.DataGridView();
            this.timeZone2 = new System.Windows.Forms.Label();
            this.timeZone1 = new System.Windows.Forms.Label();
            this.cancAddBtn = new System.Windows.Forms.Button();
            this.applyAddBtn = new System.Windows.Forms.Button();
            this.endTimePicker = new System.Windows.Forms.DateTimePicker();
            this.startTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.typeBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.endDatePicker = new System.Windows.Forms.DateTimePicker();
            this.startDatePicker = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApptCustomer)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvApptCustomer
            // 
            this.dgvApptCustomer.AllowUserToAddRows = false;
            this.dgvApptCustomer.AllowUserToDeleteRows = false;
            this.dgvApptCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApptCustomer.Location = new System.Drawing.Point(405, 14);
            this.dgvApptCustomer.MultiSelect = false;
            this.dgvApptCustomer.Name = "dgvApptCustomer";
            this.dgvApptCustomer.ReadOnly = true;
            this.dgvApptCustomer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvApptCustomer.Size = new System.Drawing.Size(496, 322);
            this.dgvApptCustomer.TabIndex = 31;
            // 
            // timeZone2
            // 
            this.timeZone2.AutoSize = true;
            this.timeZone2.Location = new System.Drawing.Point(65, 267);
            this.timeZone2.Name = "timeZone2";
            this.timeZone2.Size = new System.Drawing.Size(35, 13);
            this.timeZone2.TabIndex = 30;
            this.timeZone2.Text = "label7";
            // 
            // timeZone1
            // 
            this.timeZone1.AutoSize = true;
            this.timeZone1.Location = new System.Drawing.Point(65, 213);
            this.timeZone1.Name = "timeZone1";
            this.timeZone1.Size = new System.Drawing.Size(35, 13);
            this.timeZone1.TabIndex = 29;
            this.timeZone1.Text = "label6";
            // 
            // cancAddBtn
            // 
            this.cancAddBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancAddBtn.Location = new System.Drawing.Point(826, 364);
            this.cancAddBtn.Name = "cancAddBtn";
            this.cancAddBtn.Size = new System.Drawing.Size(75, 33);
            this.cancAddBtn.TabIndex = 28;
            this.cancAddBtn.Text = "Cancel";
            this.cancAddBtn.UseVisualStyleBackColor = true;
            this.cancAddBtn.Click += new System.EventHandler(this.cancAddBtn_Click);
            // 
            // applyAddBtn
            // 
            this.applyAddBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applyAddBtn.Location = new System.Drawing.Point(733, 364);
            this.applyAddBtn.Name = "applyAddBtn";
            this.applyAddBtn.Size = new System.Drawing.Size(75, 33);
            this.applyAddBtn.TabIndex = 27;
            this.applyAddBtn.Text = "Apply";
            this.applyAddBtn.UseVisualStyleBackColor = true;
            this.applyAddBtn.Click += new System.EventHandler(this.applyAddBtn_Click);
            // 
            // endTimePicker
            // 
            this.endTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.endTimePicker.Location = new System.Drawing.Point(286, 238);
            this.endTimePicker.Name = "endTimePicker";
            this.endTimePicker.ShowUpDown = true;
            this.endTimePicker.Size = new System.Drawing.Size(91, 20);
            this.endTimePicker.TabIndex = 26;
            // 
            // startTimePicker
            // 
            this.startTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.startTimePicker.Location = new System.Drawing.Point(286, 185);
            this.startTimePicker.Name = "startTimePicker";
            this.startTimePicker.ShowUpDown = true;
            this.startTimePicker.Size = new System.Drawing.Size(91, 20);
            this.startTimePicker.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 239);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 20);
            this.label5.TabIndex = 24;
            this.label5.Text = "End";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 20);
            this.label4.TabIndex = 23;
            this.label4.Text = "Start";
            // 
            // textDescription
            // 
            this.textDescription.Location = new System.Drawing.Point(12, 143);
            this.textDescription.Name = "textDescription";
            this.textDescription.Size = new System.Drawing.Size(365, 20);
            this.textDescription.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 20);
            this.label3.TabIndex = 21;
            this.label3.Text = "Description(Optional)";
            // 
            // typeBox
            // 
            this.typeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeBox.FormattingEnabled = true;
            this.typeBox.Items.AddRange(new object[] {
            "Meeting",
            "Consultation",
            "Check Up"});
            this.typeBox.Location = new System.Drawing.Point(12, 77);
            this.typeBox.Name = "typeBox";
            this.typeBox.Size = new System.Drawing.Size(365, 21);
            this.typeBox.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 20);
            this.label2.TabIndex = 19;
            this.label2.Text = "Type";
            // 
            // endDatePicker
            // 
            this.endDatePicker.Location = new System.Drawing.Point(68, 239);
            this.endDatePicker.Name = "endDatePicker";
            this.endDatePicker.Size = new System.Drawing.Size(200, 20);
            this.endDatePicker.TabIndex = 18;
            // 
            // startDatePicker
            // 
            this.startDatePicker.Location = new System.Drawing.Point(68, 185);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.Size = new System.Drawing.Size(200, 20);
            this.startDatePicker.TabIndex = 17;
            // 
            // CalendarUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 407);
            this.Controls.Add(this.dgvApptCustomer);
            this.Controls.Add(this.timeZone2);
            this.Controls.Add(this.timeZone1);
            this.Controls.Add(this.cancAddBtn);
            this.Controls.Add(this.applyAddBtn);
            this.Controls.Add(this.endTimePicker);
            this.Controls.Add(this.startTimePicker);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textDescription);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.typeBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.endDatePicker);
            this.Controls.Add(this.startDatePicker);
            this.Name = "CalendarUpdate";
            this.Text = "Update Appointment";
            ((System.ComponentModel.ISupportInitialize)(this.dgvApptCustomer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvApptCustomer;
        private System.Windows.Forms.Label timeZone2;
        private System.Windows.Forms.Label timeZone1;
        private System.Windows.Forms.Button cancAddBtn;
        private System.Windows.Forms.Button applyAddBtn;
        private System.Windows.Forms.DateTimePicker endTimePicker;
        private System.Windows.Forms.DateTimePicker startTimePicker;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox typeBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker endDatePicker;
        private System.Windows.Forms.DateTimePicker startDatePicker;
    }
}