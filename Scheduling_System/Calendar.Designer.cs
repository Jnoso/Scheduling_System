namespace Scheduling_System
{
    partial class Calendar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvAppt = new System.Windows.Forms.DataGridView();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.addAppointment = new System.Windows.Forms.Button();
            this.updateAppointment = new System.Windows.Forms.Button();
            this.delAppointment = new System.Windows.Forms.Button();
            this.reportBtn = new System.Windows.Forms.Button();
            this.detailBtn = new System.Windows.Forms.Button();
            this.listBoxApt = new System.Windows.Forms.ListBox();
            this.listBoxBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppt)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAppt
            // 
            this.dgvAppt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppt.Location = new System.Drawing.Point(235, 16);
            this.dgvAppt.MultiSelect = false;
            this.dgvAppt.Name = "dgvAppt";
            this.dgvAppt.ReadOnly = true;
            this.dgvAppt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAppt.Size = new System.Drawing.Size(570, 329);
            this.dgvAppt.TabIndex = 2;
            // 
            // datePicker
            // 
            this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePicker.Location = new System.Drawing.Point(60, 325);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(103, 20);
            this.datePicker.TabIndex = 3;
            // 
            // addAppointment
            // 
            this.addAppointment.Location = new System.Drawing.Point(60, 16);
            this.addAppointment.Name = "addAppointment";
            this.addAppointment.Size = new System.Drawing.Size(103, 45);
            this.addAppointment.TabIndex = 4;
            this.addAppointment.Text = "Add";
            this.addAppointment.UseVisualStyleBackColor = true;
            this.addAppointment.Click += new System.EventHandler(this.addAppointment_Click);
            // 
            // updateAppointment
            // 
            this.updateAppointment.Location = new System.Drawing.Point(60, 96);
            this.updateAppointment.Name = "updateAppointment";
            this.updateAppointment.Size = new System.Drawing.Size(103, 45);
            this.updateAppointment.TabIndex = 5;
            this.updateAppointment.Text = "Update";
            this.updateAppointment.UseVisualStyleBackColor = true;
            this.updateAppointment.Click += new System.EventHandler(this.updateAppointment_Click);
            // 
            // delAppointment
            // 
            this.delAppointment.Location = new System.Drawing.Point(60, 180);
            this.delAppointment.Name = "delAppointment";
            this.delAppointment.Size = new System.Drawing.Size(103, 45);
            this.delAppointment.TabIndex = 6;
            this.delAppointment.Text = "Delete";
            this.delAppointment.UseVisualStyleBackColor = true;
            this.delAppointment.Click += new System.EventHandler(this.delAppointment_Click);
            // 
            // reportBtn
            // 
            this.reportBtn.Location = new System.Drawing.Point(60, 261);
            this.reportBtn.Name = "reportBtn";
            this.reportBtn.Size = new System.Drawing.Size(103, 45);
            this.reportBtn.TabIndex = 7;
            this.reportBtn.Text = "Reports";
            this.reportBtn.UseVisualStyleBackColor = true;
            this.reportBtn.Click += new System.EventHandler(this.reportBtn_Click);
            // 
            // detailBtn
            // 
            this.detailBtn.Location = new System.Drawing.Point(73, 361);
            this.detailBtn.Name = "detailBtn";
            this.detailBtn.Size = new System.Drawing.Size(75, 23);
            this.detailBtn.TabIndex = 8;
            this.detailBtn.Text = "Detail";
            this.detailBtn.UseVisualStyleBackColor = true;
            this.detailBtn.Click += new System.EventHandler(this.detailBtn_Click);
            // 
            // listBoxApt
            // 
            this.listBoxApt.FormattingEnabled = true;
            this.listBoxApt.Location = new System.Drawing.Point(290, 48);
            this.listBoxApt.Name = "listBoxApt";
            this.listBoxApt.Size = new System.Drawing.Size(515, 355);
            this.listBoxApt.TabIndex = 9;
            this.listBoxApt.Visible = false;
            // 
            // listBoxBtn
            // 
            this.listBoxBtn.Location = new System.Drawing.Point(707, 361);
            this.listBoxBtn.Name = "listBoxBtn";
            this.listBoxBtn.Size = new System.Drawing.Size(75, 23);
            this.listBoxBtn.TabIndex = 10;
            this.listBoxBtn.Text = "OK";
            this.listBoxBtn.UseVisualStyleBackColor = true;
            this.listBoxBtn.Visible = false;
            this.listBoxBtn.Click += new System.EventHandler(this.listBoxBtn_Click);
            // 
            // Calendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listBoxBtn);
            this.Controls.Add(this.listBoxApt);
            this.Controls.Add(this.detailBtn);
            this.Controls.Add(this.reportBtn);
            this.Controls.Add(this.delAppointment);
            this.Controls.Add(this.updateAppointment);
            this.Controls.Add(this.addAppointment);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.dgvAppt);
            this.Name = "Calendar";
            this.Size = new System.Drawing.Size(831, 431);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppt)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvAppt;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.Button addAppointment;
        private System.Windows.Forms.Button updateAppointment;
        private System.Windows.Forms.Button delAppointment;
        private System.Windows.Forms.Button reportBtn;
        private System.Windows.Forms.Button detailBtn;
        private System.Windows.Forms.ListBox listBoxApt;
        private System.Windows.Forms.Button listBoxBtn;
    }
}
