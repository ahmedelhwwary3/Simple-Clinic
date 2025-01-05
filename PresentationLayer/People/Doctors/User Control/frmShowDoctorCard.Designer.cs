namespace PresentationLayer.People.Doctors.User_Control
{
    partial class frmShowDoctorCard
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
            this.ctrlDoctorCard1 = new PresentationLayer.People.Doctors.ctrlDoctorCard();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlDoctorCard1
            // 
            this.ctrlDoctorCard1.BackColor = System.Drawing.Color.White;
            this.ctrlDoctorCard1.Location = new System.Drawing.Point(3, 2);
            this.ctrlDoctorCard1.Name = "ctrlDoctorCard1";
            this.ctrlDoctorCard1.Size = new System.Drawing.Size(847, 543);
            this.ctrlDoctorCard1.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::PresentationLayer.Properties.Resources.delete_big;
            this.btnDelete.Location = new System.Drawing.Point(744, 552);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 73);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = " ";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::PresentationLayer.Properties.Resources.close_big;
            this.btnClose.Location = new System.Drawing.Point(633, 552);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 73);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = " ";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmShowDoctorCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(849, 633);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlDoctorCard1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmShowDoctorCard";
            this.Text = "frmShowDoctorCard";
            this.Load += new System.EventHandler(this.frmShowDoctorCard_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlDoctorCard ctrlDoctorCard1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
    }
}