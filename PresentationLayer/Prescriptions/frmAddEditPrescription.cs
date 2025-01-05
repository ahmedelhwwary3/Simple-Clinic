using BusinessLayer;
using PresentationLayer.Medical_Records_And_Prescriptions.Medical_Records;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Medical_Records_And_Prescriptions.Prescriptions
{
    public partial class frmAddEditPrescription : Form
    {
        private int _PrescriptionID = 0;
        private clsPrescription _Prescription;
        private enum enMode { AddNew,Update};
        private enMode _Mode= enMode.AddNew;
        public frmAddEditPrescription()
        {
            InitializeComponent();
             
            _Mode = enMode.AddNew;
        }
        public frmAddEditPrescription(int PrescriptionID)
        {
            InitializeComponent();
            _PrescriptionID = PrescriptionID;
            _Mode = enMode.Update;
        }
        private void _ResetDefaultValues()
        {
            _Prescription=new clsPrescription();
            this.Text = "Add New Prescription";
            dtpStart.Value = DateTime.Now;
            dtpStart.MinDate = dtpStart.Value;
            dtpEnd.Value = DateTime.Now.AddDays(7);

        }
        private void _LoadData()
        {
            _Prescription = clsPrescription.FindPrescription(_PrescriptionID);
            if(_Prescription==null)
            {
                MessageBox.Show("Error Message:Prescription is not exist","Error",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            txtMedicalRecordID.Text=_Prescription.MedicalRecordID.ToString();
            txtMedicationName.Text = _Prescription.MedicationName;
            txtDosage.Text = _Prescription.Dosage;
            txtFrequency.Text = _Prescription.Frequency;
            txtSpecialInstrictions.Text = _Prescription.SpecialInstructions;
            dtpStart.MinDate = (DateTime)_Prescription.StartDate;
            dtpStart.Value = (DateTime)_Prescription.StartDate;
            dtpEnd.Value =(DateTime) _Prescription.EndDate;
            lblPrescriptionID.Text=_Prescription.PrescriptionID.ToString();
            llAddNewMedicalRecord.Enabled = false;  


        }
        private void frmAddEditPrescription_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            if(_Mode==enMode.Update)
            {
                _LoadData();
            }





        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Error Message:Some fileds are not valid.Check the red icon messages", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _Prescription.Frequency = txtFrequency.Text.Trim();
            _Prescription.SpecialInstructions = (txtSpecialInstrictions.Text.Trim()!=string.Empty? txtSpecialInstrictions.Text.Trim():null);
            _Prescription.StartDate = dtpStart.Value;
            _Prescription.EndDate = dtpEnd.Value;
            _Prescription.Dosage = txtDosage.Text.Trim();
            _Prescription.MedicationName = txtMedicationName.Text.Trim();
            _Prescription.MedicalRecordID = int.Parse(txtMedicalRecordID.Text.Trim());
            if(!_Prescription.Save())
            {
                MessageBox.Show("Error Message:save failed", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Save succeeded", "Confirm",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            _Mode = enMode.Update;
            this.Text = "Update Prescription";
            lblTitle.Text = "Update Prescription";
            lblPrescriptionID.Text=_Prescription.PrescriptionID.ToString();
            btnSave.Enabled = false;
            llAddNewMedicalRecord.Enabled = false;






        }

        private void txtMedicationName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtMedicationName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtMedicationName,"This field is required");
                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtMedicationName,"");
            }
        }

        private void txtDosage_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtDosage.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtDosage, "This field is required");
                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtDosage, "");
            }
        }

        private void txtFrequency_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFrequency.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFrequency, "This field is required");
                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtFrequency, "");
            }
        }

        private void txtMedicalRecordID_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtMedicalRecordID.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtMedicalRecordID, "This field is required");
                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtMedicalRecordID, "");
            }
            if(!clsMedicalRecord.IsExist(int.Parse(txtMedicalRecordID.Text.Trim())))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtMedicalRecordID, "This Medical Record ID is not exist");
            }

            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtMedicalRecordID, "");
            }




        }

        private void llAddNewPerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditMedicalRecord frm=new frmAddEditMedicalRecord();
            frm.DataBack += GetMedicalRecordIDInTextBox;
            frm.ShowDialog();
        }
        private void GetMedicalRecordIDInTextBox(object sender,int MedicalRecordID)
        {
            txtMedicalRecordID.Text= MedicalRecordID.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
