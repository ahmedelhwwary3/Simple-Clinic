namespace PresentationLayer
{
    partial class frmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.peopleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showAllPeopleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewPersonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.showAllPeopleListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doctorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewDoctorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.showAllDoctorsListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewPatientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.showAllPatientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appointmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewAppointmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.showAllAppointmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paymentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showAllPaymentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.medicalRecordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewPrescriptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewMedicalRecoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.showAllMedicalRecordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showAllMedicalRecordsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Lavender;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.peopleToolStripMenuItem,
            this.appointmentsToolStripMenuItem,
            this.paymentsToolStripMenuItem,
            this.medicalRecordsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1176, 72);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // peopleToolStripMenuItem
            // 
            this.peopleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showAllPeopleToolStripMenuItem,
            this.doctorsToolStripMenuItem,
            this.patientsToolStripMenuItem});
            this.peopleToolStripMenuItem.Image = global::PresentationLayer.Properties.Resources.People;
            this.peopleToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.peopleToolStripMenuItem.Name = "peopleToolStripMenuItem";
            this.peopleToolStripMenuItem.Size = new System.Drawing.Size(119, 68);
            this.peopleToolStripMenuItem.Text = "People";
            // 
            // showAllPeopleToolStripMenuItem
            // 
            this.showAllPeopleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewPersonToolStripMenuItem,
            this.toolStripMenuItem1,
            this.showAllPeopleListToolStripMenuItem});
            this.showAllPeopleToolStripMenuItem.Image = global::PresentationLayer.Properties.Resources.P6_RS;
            this.showAllPeopleToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showAllPeopleToolStripMenuItem.Name = "showAllPeopleToolStripMenuItem";
            this.showAllPeopleToolStripMenuItem.Size = new System.Drawing.Size(196, 38);
            this.showAllPeopleToolStripMenuItem.Text = "Public";
            // 
            // addNewPersonToolStripMenuItem
            // 
            this.addNewPersonToolStripMenuItem.Image = global::PresentationLayer.Properties.Resources.add;
            this.addNewPersonToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addNewPersonToolStripMenuItem.Name = "addNewPersonToolStripMenuItem";
            this.addNewPersonToolStripMenuItem.Size = new System.Drawing.Size(196, 38);
            this.addNewPersonToolStripMenuItem.Text = "Add New Person";
            this.addNewPersonToolStripMenuItem.Click += new System.EventHandler(this.addNewPersonToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(193, 6);
            // 
            // showAllPeopleListToolStripMenuItem
            // 
            this.showAllPeopleListToolStripMenuItem.Image = global::PresentationLayer.Properties.Resources.list;
            this.showAllPeopleListToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showAllPeopleListToolStripMenuItem.Name = "showAllPeopleListToolStripMenuItem";
            this.showAllPeopleListToolStripMenuItem.Size = new System.Drawing.Size(196, 38);
            this.showAllPeopleListToolStripMenuItem.Text = "Show All People List";
            this.showAllPeopleListToolStripMenuItem.Click += new System.EventHandler(this.showAllPeopleListToolStripMenuItem_Click);
            // 
            // doctorsToolStripMenuItem
            // 
            this.doctorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewDoctorToolStripMenuItem,
            this.toolStripMenuItem2,
            this.showAllDoctorsListToolStripMenuItem});
            this.doctorsToolStripMenuItem.Image = global::PresentationLayer.Properties.Resources.Doctor;
            this.doctorsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.doctorsToolStripMenuItem.Name = "doctorsToolStripMenuItem";
            this.doctorsToolStripMenuItem.Size = new System.Drawing.Size(196, 38);
            this.doctorsToolStripMenuItem.Text = "Doctors";
            // 
            // addNewDoctorToolStripMenuItem
            // 
            this.addNewDoctorToolStripMenuItem.Image = global::PresentationLayer.Properties.Resources.add;
            this.addNewDoctorToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addNewDoctorToolStripMenuItem.Name = "addNewDoctorToolStripMenuItem";
            this.addNewDoctorToolStripMenuItem.Size = new System.Drawing.Size(201, 38);
            this.addNewDoctorToolStripMenuItem.Text = "Add New Doctor";
            this.addNewDoctorToolStripMenuItem.Click += new System.EventHandler(this.addNewDoctorToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(198, 6);
            // 
            // showAllDoctorsListToolStripMenuItem
            // 
            this.showAllDoctorsListToolStripMenuItem.Image = global::PresentationLayer.Properties.Resources.list;
            this.showAllDoctorsListToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showAllDoctorsListToolStripMenuItem.Name = "showAllDoctorsListToolStripMenuItem";
            this.showAllDoctorsListToolStripMenuItem.Size = new System.Drawing.Size(201, 38);
            this.showAllDoctorsListToolStripMenuItem.Text = "Show All Doctors List";
            this.showAllDoctorsListToolStripMenuItem.Click += new System.EventHandler(this.showAllDoctorsListToolStripMenuItem_Click);
            // 
            // patientsToolStripMenuItem
            // 
            this.patientsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewPatientToolStripMenuItem,
            this.toolStripMenuItem3,
            this.showAllPatientsToolStripMenuItem});
            this.patientsToolStripMenuItem.Image = global::PresentationLayer.Properties.Resources.patint;
            this.patientsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.patientsToolStripMenuItem.Name = "patientsToolStripMenuItem";
            this.patientsToolStripMenuItem.Size = new System.Drawing.Size(196, 38);
            this.patientsToolStripMenuItem.Text = "Patients";
            // 
            // addNewPatientToolStripMenuItem
            // 
            this.addNewPatientToolStripMenuItem.Image = global::PresentationLayer.Properties.Resources.add;
            this.addNewPatientToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addNewPatientToolStripMenuItem.Name = "addNewPatientToolStripMenuItem";
            this.addNewPatientToolStripMenuItem.Size = new System.Drawing.Size(181, 38);
            this.addNewPatientToolStripMenuItem.Text = "Add New Patient";
            this.addNewPatientToolStripMenuItem.Click += new System.EventHandler(this.addNewPatientToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(178, 6);
            // 
            // showAllPatientsToolStripMenuItem
            // 
            this.showAllPatientsToolStripMenuItem.Image = global::PresentationLayer.Properties.Resources.list;
            this.showAllPatientsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showAllPatientsToolStripMenuItem.Name = "showAllPatientsToolStripMenuItem";
            this.showAllPatientsToolStripMenuItem.Size = new System.Drawing.Size(181, 38);
            this.showAllPatientsToolStripMenuItem.Text = "Show All Patients";
            this.showAllPatientsToolStripMenuItem.Click += new System.EventHandler(this.showAllPatientsToolStripMenuItem_Click);
            // 
            // appointmentsToolStripMenuItem
            // 
            this.appointmentsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewAppointmentToolStripMenuItem,
            this.toolStripMenuItem4,
            this.showAllAppointmentsToolStripMenuItem});
            this.appointmentsToolStripMenuItem.Image = global::PresentationLayer.Properties.Resources.Appointment;
            this.appointmentsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.appointmentsToolStripMenuItem.Name = "appointmentsToolStripMenuItem";
            this.appointmentsToolStripMenuItem.Size = new System.Drawing.Size(159, 68);
            this.appointmentsToolStripMenuItem.Text = "Appointments";
            // 
            // addNewAppointmentToolStripMenuItem
            // 
            this.addNewAppointmentToolStripMenuItem.Image = global::PresentationLayer.Properties.Resources.add;
            this.addNewAppointmentToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addNewAppointmentToolStripMenuItem.Name = "addNewAppointmentToolStripMenuItem";
            this.addNewAppointmentToolStripMenuItem.Size = new System.Drawing.Size(236, 38);
            this.addNewAppointmentToolStripMenuItem.Text = "Add New Appointment";
            this.addNewAppointmentToolStripMenuItem.Click += new System.EventHandler(this.addNewAppointmentToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(233, 6);
            // 
            // showAllAppointmentsToolStripMenuItem
            // 
            this.showAllAppointmentsToolStripMenuItem.Image = global::PresentationLayer.Properties.Resources.list;
            this.showAllAppointmentsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showAllAppointmentsToolStripMenuItem.Name = "showAllAppointmentsToolStripMenuItem";
            this.showAllAppointmentsToolStripMenuItem.Size = new System.Drawing.Size(236, 38);
            this.showAllAppointmentsToolStripMenuItem.Text = "Show All Appointments List";
            this.showAllAppointmentsToolStripMenuItem.Click += new System.EventHandler(this.showAllAppointmentsToolStripMenuItem_Click);
            // 
            // paymentsToolStripMenuItem
            // 
            this.paymentsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showAllPaymentsToolStripMenuItem});
            this.paymentsToolStripMenuItem.Image = global::PresentationLayer.Properties.Resources.Paypal;
            this.paymentsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.paymentsToolStripMenuItem.Name = "paymentsToolStripMenuItem";
            this.paymentsToolStripMenuItem.Size = new System.Drawing.Size(135, 68);
            this.paymentsToolStripMenuItem.Text = "Payments";
            // 
            // showAllPaymentsToolStripMenuItem
            // 
            this.showAllPaymentsToolStripMenuItem.Image = global::PresentationLayer.Properties.Resources.AllPay;
            this.showAllPaymentsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showAllPaymentsToolStripMenuItem.Name = "showAllPaymentsToolStripMenuItem";
            this.showAllPaymentsToolStripMenuItem.Size = new System.Drawing.Size(191, 38);
            this.showAllPaymentsToolStripMenuItem.Text = "Show All Payments";
            this.showAllPaymentsToolStripMenuItem.Click += new System.EventHandler(this.showAllPaymentsToolStripMenuItem_Click);
            // 
            // medicalRecordsToolStripMenuItem
            // 
            this.medicalRecordsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewPrescriptionToolStripMenuItem,
            this.addNewMedicalRecoToolStripMenuItem,
            this.toolStripMenuItem5,
            this.showAllMedicalRecordsToolStripMenuItem,
            this.showAllMedicalRecordsToolStripMenuItem1});
            this.medicalRecordsToolStripMenuItem.Image = global::PresentationLayer.Properties.Resources.medicalrecord;
            this.medicalRecordsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.medicalRecordsToolStripMenuItem.Name = "medicalRecordsToolStripMenuItem";
            this.medicalRecordsToolStripMenuItem.Size = new System.Drawing.Size(266, 68);
            this.medicalRecordsToolStripMenuItem.Text = "Medical Records And Prescriptions";
            // 
            // addNewPrescriptionToolStripMenuItem
            // 
            this.addNewPrescriptionToolStripMenuItem.Image = global::PresentationLayer.Properties.Resources.add;
            this.addNewPrescriptionToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addNewPrescriptionToolStripMenuItem.Name = "addNewPrescriptionToolStripMenuItem";
            this.addNewPrescriptionToolStripMenuItem.Size = new System.Drawing.Size(226, 38);
            this.addNewPrescriptionToolStripMenuItem.Text = "Add New Prescription";
            this.addNewPrescriptionToolStripMenuItem.Click += new System.EventHandler(this.addNewPrescriptionToolStripMenuItem_Click);
            // 
            // addNewMedicalRecoToolStripMenuItem
            // 
            this.addNewMedicalRecoToolStripMenuItem.Image = global::PresentationLayer.Properties.Resources.add;
            this.addNewMedicalRecoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addNewMedicalRecoToolStripMenuItem.Name = "addNewMedicalRecoToolStripMenuItem";
            this.addNewMedicalRecoToolStripMenuItem.Size = new System.Drawing.Size(226, 38);
            this.addNewMedicalRecoToolStripMenuItem.Text = "Add New Medical Record";
            this.addNewMedicalRecoToolStripMenuItem.Click += new System.EventHandler(this.addNewMedicalRecoToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(223, 6);
            // 
            // showAllMedicalRecordsToolStripMenuItem
            // 
            this.showAllMedicalRecordsToolStripMenuItem.Image = global::PresentationLayer.Properties.Resources.list;
            this.showAllMedicalRecordsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showAllMedicalRecordsToolStripMenuItem.Name = "showAllMedicalRecordsToolStripMenuItem";
            this.showAllMedicalRecordsToolStripMenuItem.Size = new System.Drawing.Size(226, 38);
            this.showAllMedicalRecordsToolStripMenuItem.Text = "Show All Prescriptions";
            this.showAllMedicalRecordsToolStripMenuItem.Click += new System.EventHandler(this.showAllMedicalRecordsToolStripMenuItem_Click);
            // 
            // showAllMedicalRecordsToolStripMenuItem1
            // 
            this.showAllMedicalRecordsToolStripMenuItem1.Image = global::PresentationLayer.Properties.Resources.list;
            this.showAllMedicalRecordsToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showAllMedicalRecordsToolStripMenuItem1.Name = "showAllMedicalRecordsToolStripMenuItem1";
            this.showAllMedicalRecordsToolStripMenuItem1.Size = new System.Drawing.Size(226, 38);
            this.showAllMedicalRecordsToolStripMenuItem1.Text = "Show All Medical Records";
            this.showAllMedicalRecordsToolStripMenuItem1.Click += new System.EventHandler(this.showAllMedicalRecordsToolStripMenuItem1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.MintCream;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::PresentationLayer.Properties.Resources.clinicBig;
            this.pictureBox1.Location = new System.Drawing.Point(0, 72);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1176, 544);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(1176, 616);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem peopleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showAllPeopleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewPersonToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem showAllPeopleListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem doctorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewDoctorToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem showAllDoctorsListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem patientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewPatientToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem showAllPatientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem medicalRecordsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewMedicalRecoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem showAllMedicalRecordsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paymentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showAllPaymentsToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem appointmentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewAppointmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem showAllAppointmentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewPrescriptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showAllMedicalRecordsToolStripMenuItem1;
    }
}

