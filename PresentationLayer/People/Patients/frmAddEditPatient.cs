using BusinessLayer;
using PresentationLayer.People.All;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.People.Patients
{
    public partial class frmAddEditPatient : Form
    {
        private int _PatientID = 0;
        private clsPatient _Patient;
        private enum enMode { AddNew,Update};
        private enMode _Mode = enMode.AddNew;
        public frmAddEditPatient()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public frmAddEditPatient(int PatientID)
        {
            InitializeComponent();
            _PatientID = PatientID;
            _Mode= enMode.Update;
        }

        private void frmAddEditPatient_Load(object sender, EventArgs e)
        {
            lblPatientID.Text = "[????]";
            txtPersonID.Text= string.Empty;
          
             
            _Patient =new clsPatient();
            if(_Mode==enMode.Update)
            {
                llAddNewPerson.Enabled = false;
                this.Text = "Update Patient";
                lblTitle.Text = "Update Patient";
                _Patient = clsPatient.FindPatient(_PatientID);
                lblPatientID.Text=_Patient.PatientID.ToString();
                txtPersonID.Text=_Patient.PersonID.ToString();
            }
        }

        private void llAddNewPerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditPerson frm=new frmAddEditPerson();
            frm.DataBack += GetPersonIDInTextBox;
            frm.ShowDialog();
        }
        private void GetPersonIDInTextBox(object sender,int PersonID)
        {
            txtPersonID.Text=PersonID.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this Patient ?", "Confirm",
               MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                if (clsPatient.Delete(_PatientID))
                {
                    _Mode = enMode.AddNew;
                    frmAddEditPatient_Load(null,null);
                    MessageBox.Show("Delete succeeded", "Confirm",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnDelete.Enabled = false;
                    return;
                }
                MessageBox.Show("Error Message:Delete failed", "Confirm",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Error Message:Some fields are not valid.Check the red icon messages","Error",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            _Patient.PersonID = int.Parse(txtPersonID.Text.Trim());
            if(!_Patient.Save())
            {
                MessageBox.Show("Error Message:save failed", "Error",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _PatientID = _Patient.PatientID;
            MessageBox.Show("Save succeeded", "Confirm",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnSave.Enabled = false;
        }

        private void txtPersonID_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtPersonID.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPersonID, "This field is required");
                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPersonID,"");
            }
            if(!clsPerson.IsExist(int.Parse(txtPersonID.Text.Trim())))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPersonID, "This person is not exist");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPersonID, "");
            }
        }
    }
}
