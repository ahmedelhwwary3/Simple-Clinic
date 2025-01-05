namespace PresentationLayer.Medical_Records
{
    partial class frmShowMedicalRecordsList
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
            this.cmsMedicalRecords = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNewMedicalRecordToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.updateMedicalRecordToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddNewMedicalRecord = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicalRecords)).BeginInit();
            this.cmsMedicalRecords.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbFilterColumn
            // 
            this.cbFilterColumn.BackColor = System.Drawing.Color.White;
            this.cbFilterColumn.FormattingEnabled = true;
            this.cbFilterColumn.Items.AddRange(new object[] {
            "None",
            "Medical Record ID",
            "Visit Description",
            "Diagnosis",
            "Additional Notes"});
            this.cbFilterColumn.Location = new System.Drawing.Point(156, 340);
            this.cbFilterColumn.Name = "cbFilterColumn";
            this.cbFilterColumn.Size = new System.Drawing.Size(238, 21);
            this.cbFilterColumn.TabIndex = 64;
            this.cbFilterColumn.SelectedIndexChanged += new System.EventHandler(this.cbFilterColumn_SelectedIndexChanged);
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.BackColor = System.Drawing.Color.White;
            this.txtFilterValue.Location = new System.Drawing.Point(452, 340);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(237, 20);
            this.txtFilterValue.TabIndex = 63;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecords.Location = new System.Drawing.Point(127, 744);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(25, 25);
            this.lblRecords.TabIndex = 61;
            this.lblRecords.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 744);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 25);
            this.label1.TabIndex = 60;
            this.label1.Text = "Records :";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(18, 336);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(107, 25);
            this.label.TabIndex = 59;
            this.label.Text = "FilterBy :";
            // 
            // dgvMedicalRecords
            // 
            this.dgvMedicalRecords.AllowUserToAddRows = false;
            this.dgvMedicalRecords.AllowUserToDeleteRows = false;
            this.dgvMedicalRecords.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvMedicalRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedicalRecords.ContextMenuStrip = this.cmsMedicalRecords;
            this.dgvMedicalRecords.GridColor = System.Drawing.Color.Black;
            this.dgvMedicalRecords.Location = new System.Drawing.Point(8, 377);
            this.dgvMedicalRecords.Name = "dgvMedicalRecords";
            this.dgvMedicalRecords.ReadOnly = true;
            this.dgvMedicalRecords.Size = new System.Drawing.Size(1203, 358);
            this.dgvMedicalRecords.TabIndex = 57;
            // 
            // cmsMedicalRecords
            // 
            this.cmsMedicalRecords.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewMedicalRecordToolStripMenuItem1,
            this.toolStripMenuItem5,
            this.updateMedicalRecordToolStripMenuItem1});
            this.cmsMedicalRecords.Name = "contextMenuStrip1";
            this.cmsMedicalRecords.Size = new System.Drawing.Size(225, 108);
            // 
            // addNewMedicalRecordToolStripMenuItem1
            // 
            this.addNewMedicalRecordToolStripMenuItem1.Image = global::PresentationLayer.Properties.Resources.add;
            this.addNewMedicalRecordToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addNewMedicalRecordToolStripMenuItem1.Name = "addNewMedicalRecordToolStripMenuItem1";
            this.addNewMedicalRecordToolStripMenuItem1.Size = new System.Drawing.Size(224, 38);
            this.addNewMedicalRecordToolStripMenuItem1.Text = "Add New Medical Record";
            this.addNewMedicalRecordToolStripMenuItem1.Click += new System.EventHandler(this.addNewMedicalRecordToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(221, 6);
            // 
            // updateMedicalRecordToolStripMenuItem1
            // 
            this.updateMedicalRecordToolStripMenuItem1.Image = global::PresentationLayer.Properties.Resources.update;
            this.updateMedicalRecordToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.updateMedicalRecordToolStripMenuItem1.Name = "updateMedicalRecordToolStripMenuItem1";
            this.updateMedicalRecordToolStripMenuItem1.Size = new System.Drawing.Size(224, 38);
            this.updateMedicalRecordToolStripMenuItem1.Text = "Update Medical Record";
            this.updateMedicalRecordToolStripMenuItem1.Click += new System.EventHandler(this.updateMedicalRecordToolStripMenuItem1_Click);
            // 
            // btnAddNewMedicalRecord
            // 
            this.btnAddNewMedicalRecord.Image = global::PresentationLayer.Properties.Resources.add;
            this.btnAddNewMedicalRecord.Location = new System.Drawing.Point(1142, 315);
            this.btnAddNewMedicalRecord.Name = "btnAddNewMedicalRecord";
            this.btnAddNewMedicalRecord.Size = new System.Drawing.Size(69, 56);
            this.btnAddNewMedicalRecord.TabIndex = 65;
            this.btnAddNewMedicalRecord.Text = " ";
            this.btnAddNewMedicalRecord.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PresentationLayer.Properties.Resources.presc;
            this.pictureBox1.Location = new System.Drawing.Point(439, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(350, 337);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 62;
            this.pictureBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Image = global::PresentationLayer.Properties.Resources.close;
            this.btnClose.Location = new System.Drawing.Point(1142, 744);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(69, 56);
            this.btnClose.TabIndex = 58;
            this.btnClose.Text = " ";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmShowMedicalRecordsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(1221, 809);
            this.Controls.Add(this.btnAddNewMedicalRecord);
            this.Controls.Add(this.cbFilterColumn);
            this.Controls.Add(this.txtFilterValue);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvMedicalRecords);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmShowMedicalRecordsList";
            this.Text = "frmShowMedicalRecordsList";
            this.Load += new System.EventHandler(this.frmShowMedicalRecordsList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicalRecords)).EndInit();
            this.cmsMedicalRecords.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddNewMedicalRecord;
        private System.Windows.Forms.ComboBox cbFilterColumn;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvMedicalRecords;
        private System.Windows.Forms.ContextMenuStrip cmsMedicalRecords;
        private System.Windows.Forms.ToolStripMenuItem addNewMedicalRecordToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem updateMedicalRecordToolStripMenuItem1;
    }
}