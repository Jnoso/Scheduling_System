namespace Scheduling_System
{
    partial class CustomerUpdate
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
            this.txt_PhoneNum = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Country = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_City = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Address = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_customerName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.updateWindowBtn = new System.Windows.Forms.Button();
            this.UpdateWindowCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_PhoneNum
            // 
            this.txt_PhoneNum.Location = new System.Drawing.Point(139, 223);
            this.txt_PhoneNum.Name = "txt_PhoneNum";
            this.txt_PhoneNum.Size = new System.Drawing.Size(142, 20);
            this.txt_PhoneNum.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(41, 224);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 15);
            this.label5.TabIndex = 19;
            this.label5.Text = "Phone Number";
            // 
            // txt_Country
            // 
            this.txt_Country.Location = new System.Drawing.Point(139, 178);
            this.txt_Country.Name = "txt_Country";
            this.txt_Country.Size = new System.Drawing.Size(142, 20);
            this.txt_Country.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(84, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 15);
            this.label4.TabIndex = 17;
            this.label4.Text = "Country";
            // 
            // txt_City
            // 
            this.txt_City.Location = new System.Drawing.Point(139, 127);
            this.txt_City.Name = "txt_City";
            this.txt_City.Size = new System.Drawing.Size(142, 20);
            this.txt_City.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(106, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "City";
            // 
            // txt_Address
            // 
            this.txt_Address.Location = new System.Drawing.Point(139, 74);
            this.txt_Address.Name = "txt_Address";
            this.txt_Address.Size = new System.Drawing.Size(142, 20);
            this.txt_Address.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(81, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 15);
            this.label2.TabIndex = 13;
            this.label2.Text = "Address";
            // 
            // txt_customerName
            // 
            this.txt_customerName.Location = new System.Drawing.Point(139, 22);
            this.txt_customerName.Name = "txt_customerName";
            this.txt_customerName.Size = new System.Drawing.Size(142, 20);
            this.txt_customerName.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "Customer Name";
            // 
            // updateWindowBtn
            // 
            this.updateWindowBtn.Location = new System.Drawing.Point(173, 270);
            this.updateWindowBtn.Name = "updateWindowBtn";
            this.updateWindowBtn.Size = new System.Drawing.Size(75, 23);
            this.updateWindowBtn.TabIndex = 21;
            this.updateWindowBtn.Text = "Update";
            this.updateWindowBtn.UseVisualStyleBackColor = true;
            this.updateWindowBtn.Click += new System.EventHandler(this.updateWindowBtn_Click);
            // 
            // UpdateWindowCancel
            // 
            this.UpdateWindowCancel.Location = new System.Drawing.Point(258, 270);
            this.UpdateWindowCancel.Name = "UpdateWindowCancel";
            this.UpdateWindowCancel.Size = new System.Drawing.Size(75, 23);
            this.UpdateWindowCancel.TabIndex = 22;
            this.UpdateWindowCancel.Text = "Cancel";
            this.UpdateWindowCancel.UseVisualStyleBackColor = true;
            this.UpdateWindowCancel.Click += new System.EventHandler(this.UpdateWindowCancel_Click);
            // 
            // CustomerUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 305);
            this.Controls.Add(this.UpdateWindowCancel);
            this.Controls.Add(this.updateWindowBtn);
            this.Controls.Add(this.txt_PhoneNum);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_Country);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_City);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_Address);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_customerName);
            this.Controls.Add(this.label1);
            this.Name = "CustomerUpdate";
            this.Text = "Update";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_PhoneNum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_Country;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_City;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Address;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_customerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button updateWindowBtn;
        private System.Windows.Forms.Button UpdateWindowCancel;
    }
}