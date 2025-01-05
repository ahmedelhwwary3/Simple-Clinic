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

namespace PresentationLayer.People.Doctors
{
    public partial class frmAddEditDoctor : Form
    {
        private enum enMode { AddNew,Update};
        private enMode _Mode = enMode.AddNew;
        private int _DoctorID = 0;
        private clsDoctor _Doctor;
        public frmAddEditDoctor()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public frmAddEditDoctor(int DoctorID)
        {
            InitializeComponent();
            _DoctorID = DoctorID;
            _Mode = enMode.Update;
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson();
            frm.DataBack += GetPersonIDInTextBox;
            frm.ShowDialog();
        }
        private void GetPersonIDInTextBox(object sender,int PersonID)
        {
            txtPersonID.Text = PersonID.ToString();
            txtPersonID.Focus();
        }

        private void txtPersonID_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtPersonID.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPersonID,"This field is required");
                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPersonID, "");
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
        private void _LoadData()
        {
            _Doctor = clsDoctor.FindDoctor(_DoctorID);
            if(_Doctor==null)
            {
                MessageBox.Show("Error Message:Doctor is not exist","Error",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            this.Text = "Update Doctor";
            lblTitle.Text = "Update Doctor";
            cbSpecialization.SelectedIndex = cbSpecialization.FindString(_Doctor.Specialization);
            txtPersonID.Text=_Doctor.PersonID.ToString();
        }
        private void frmAddEditDoctor_Load(object sender, EventArgs e)
        {
            txtPersonID.Text = "";
            txtPersonID.Focus();
            cbSpecialization.SelectedIndex = 0;
            _Doctor=new clsDoctor();
            llAddNewPerson.Enabled = (_Mode==enMode.AddNew);
            if(_Mode==enMode.Update)
            {
                _LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to delete this doctor ?","Confirm",
                MessageBoxButtons.OKCancel,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.OK)
            {
                if(clsDoctor.Delete(_DoctorID))
                {
                    _Mode = enMode.AddNew;
                    frmAddEditDoctor_Load(null,null);
                    MessageBox.Show("Delete succeeded","Confirm",
                        MessageBoxButtons.OK,MessageBoxIcon.Information);
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
                MessageBox.Show("Error Message:Person ID is needed","Error",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            _Doctor.PersonID = int.Parse(txtPersonID.Text.Trim());
            _Doctor.Specialization=cbSpecialization.Text;
            if(!_Doctor.Save())
            {
                MessageBox.Show("Error Message:Doctor save failed","Error",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Save succeeded", "Confirm",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
            _Mode = enMode.Update;
            btnSave.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
