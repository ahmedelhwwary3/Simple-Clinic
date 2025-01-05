namespace PresentationLayer.Medical_Records
{
    partial class frmShowPrescritionsList
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
            this.components = new System.ComponentModel.Container();
            this.cbFilterColumn = new System.Windows.Forms.ComboBox();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.lblRecords = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.dgvMedicalRecords = new System.Windows.Forms.DataGridView();
            this.cmsPrescription = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNewMedicalRecordToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.updateMedicalRecordToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddNewPrescription = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicalRecords)).BeginInit();
            this.cmsPrescription.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbFilterColumn
            // 
            this.cbFilterColumn.BackColor = System.Drawing.Color.White;
            this.cbFilterColumn.FormattingEnabled = true;
            this.cbFilterColumn.Items.AddRange(new object[] {
            "None",
            "DoctorID",
            "Specialization"});
            this.cbFilterColumn.Location = new System.Drawing.Point(157, 340);
            this.cbFilterColumn.Name = "cbFilterColumn";
            this.cbFilterColumn.Size = new System.Drawing.Size(238, 21);
            this.cbFilterColumn.TabIndex = 45;
            this.cbFilterColumn.SelectedIndexChanged += new System.EventHandler(this.cbFilterColumn_SelectedIndexChanged);
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.BackColor = System.Drawing.Color.White;
            this.txtFilterValue.Location = new System.Drawing.Point(453, 340);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(237, 20);
            this.txtFilterValue.TabIndex = 44;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecords.Location = new System.Drawing.Point(128, 744);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(25, 25);
            this.lblRecords.TabIndex = 42;
            this.lblRecords.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 744);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 25);
            this.label1.TabIndex = 41;
            this.label1.Text = "Records :";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(19, 336);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(107, 25);
            this.label.TabIndex = 40;
            this.label.Text = "FilterBy :";
            // 
            // dgvMedicalRecords
            // 
            this.dgvMedicalRecords.AllowUserToAddRows = false;
            this.dgvMedicalRecords.AllowUserToDeleteRows = false;
            this.dgvMedicalRecords.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvMedicalRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedicalRecords.ContextMenuStrip = this.cmsPrescription;
            this.dgvMedicalRecords.GridColor = System.Drawing.Color.Black;
            this.dgvMedicalRecords.Location = new System.Drawing.Point(9, 377);
            this.dgvMedicalRecords.Name = "dgvMedicalRecords";
            this.dgvMedicalRecords.ReadOnly = true;
            this.dgvMedicalRecords.Size = new System.Drawing.Size(1203, 358);
            this.dgvMedicalRecords.TabIndex = 38;
            // 
            // cmsPrescription
            // 
            this.cmsPrescription.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewMedicalRecordToolStripMenuItem1,
            this.toolStripMenuItem5,
            this.updateMedicalRecordToolStripMenuItem1});
            this.cmsPrescription.Name = "contextMenuStrip1";
            this.cmsPrescription.Size = new System.Drawing.Size(206, 86);
            // 
            // addNewMedicalRecordToolStripMenuItem1
            // 
            this.addNewMedicalRecordToolStripMenuItem1.Image = global::PresentationLayer.Properties.Resources.add;
            this.addNewMedicalRecordToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addNewMedicalRecordToolStripMenuItem1.Name = "addNewMedicalRecordToolStripMenuItem1";
            this.addNewMedicalRecordToolStripMenuItem1.Size = new System.Drawing.Size(205, 38);
            this.addNewMedicalRecordToolStripMenuItem1.Text = "Add New Prescription";
            this.addNewMedicalRecordToolStripMenuItem1.Click += new System.EventHandler(this.addNewMedicalRecordToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(202, 6);
            // 
            // updateMedicalRecordToolStripMenuItem1
            // 
            this.updateMedicalRecordToolStripMenuItem1.Image = global::PresentationLayer.Properties.Resources.update;
            this.updateMedicalRecordToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.updateMedicalRecordToolStripMenuItem1.Name = "updateMedicalRecordToolStripMenuItem1";
            this.updateMedicalRecordToolStripMenuItem1.Size = new System.Drawing.Size(205, 38);
            this.updateMedicalRecordToolStripMenuItem1.Text = "Update Prescription";
            this.updateMedicalRecordToolStripMenuItem1.Click += new System.EventHandler(this.updateMedicalRecordToolStripMenuItem1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PresentationLayer.Properties.Resources.presc;
            this.pictureBox1.Location = new System.Drawing.Point(440, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(350, 337);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 43;
            this.pictureBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Image = global::PresentationLayer.Properties.Resources.close;
            this.btnClose.Location = new System.Drawing.Point(1143, 744);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(69, 56);
            this.btnClose.TabIndex = 39;
            this.btnClose.Text = " ";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddNewPrescription
            // 
            this.btnAddNewPrescription.Image = global::PresentationLayer.Properties.Resources.add;
            this.btnAddNewPrescription.Location = new System.Drawing.Point(1143, 315);
            this.btnAddNewPrescription.Name = "btnAddNewPrescription";
            this.btnAddNewPrescription.Size = new System.Drawing.Size(69, 56);
            this.btnAddNewPrescription.TabIndex = 56;
            this.btnAddNewPrescription.Text = " ";
            this.btnAddNewPrescription.UseVisualStyleBackColor = true;
            this.btnAddNewPrescription.Click += new System.EventHandler(this.btnAddNewPrescription_Click);
            // 
            // frmShowPrescritionsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(1219, 806);
            this.Controls.Add(this.btnAddNewPrescription);
            this.Controls.Add(this.cbFilterColumn);
            this.Controls.Add(this.txtFilterValue);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvMedicalRecords);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmShowPrescritionsList";
            this.Text = "frmShowMedicalRecordsList";
            this.Load += new System.EventHandler(this.frmShowMedicalRecordsAndPrescritionsLists_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicalRecords)).EndInit();
            this.cmsPrescription.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbFilterColumn;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvMedicalRecords;
        private System.Windows.Forms.ContextMenuStrip cmsPrescription;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem addNewMedicalRecordToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem updateMedicalRecordToolStripMenuItem1;
        private System.Windows.Forms.Button btnAddNewPrescription;
    }
}