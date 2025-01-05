using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Medical_Records_And_Prescriptions.Medical_Records
{
    public partial class frmAddEditMedicalRecord : Form
    {
        public delegate void DataBackEventHandler(object sender,int MedicalRecordID);
        public DataBackEventHandler DataBack;
        private enum enMode { AddNew,Update};
        enMode _Mode = enMode.AddNew;
        private int _MedicalRecordID = 0;
        private clsMedicalRecord _MedicalRecord;
        public frmAddEditMedicalRecord()
        {
            InitializeComponent();
            _Mode=enMode.AddNew;
        }
        public frmAddEditMedicalRecord(int MedicalRecordID)
        {
            InitializeComponent();
            _MedicalRecordID= MedicalRecordID;
            _Mode = enMode.Update;
        }
        private void frmAddEditMedicalRecord_Load(object sender, EventArgs e)
        {
            _MedicalRecord=new clsMedicalRecord();
            if(_Mode==enMode.Update)
            {
                _MedicalRecord = clsMedicalRecord.FindMedicalRecord(_MedicalRecordID);
                if(_MedicalRecord==null)
                {
                    MessageBox.Show("Error Message:Medical Record is not exist","Error"
                        ,MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
                if(DataBack!=null)
                {
                    DataBack.Invoke(this,_MedicalRecord.MedicalRecordID);
                }
                txtAdditionalNotes.Text = _MedicalRecord.AdditionalNotes??"";
                txtDiagnosis.Text = _MedicalRecord.Diagnosis??"";
                txtVisitDescription.Text= _MedicalRecord.VisitDescription ?? "";
                lblMedicalRecordID.Text= _MedicalRecord.MedicalRecordID.ToString();
                lblTitle.Text = "Update Medical Record";
                this.Text = "Update Medical Record";


            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _MedicalRecord.VisitDescription=txtDiagnosis.Text.Trim();
            _MedicalRecord.Diagnosis=txtVisitDescription.Text.Trim();
            _MedicalRecord.AdditionalNotes=txtAdditionalNotes.Text.Trim();
            if(!_MedicalRecord.Save())
            {

                MessageBox.Show("Error Message:Save failed", "Error"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(DataBack!=null)
            {
                DataBack.Invoke(this, _MedicalRecord.MedicalRecordID);
            }
            MessageBox.Show("Save succeeded", "Confirm"
                   , MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Text = "Update Medical Record";
            lblMedicalRecordID.Text = _MedicalRecord.MedicalRecordID.ToString();
            lblTitle.Text = "Update Medical Record";
            _Mode = enMode.Update;
           
        }
    }
}
