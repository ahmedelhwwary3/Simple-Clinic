using BusinessLayer;
using PresentationLayer.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.People.All
{
    public partial class frmAddEditPerson : Form
    {
        private int _PersonID = 0;
        private clsPerson _Person;
        private enum enMode { AddNew,Update};
        private enMode _Mode = enMode.AddNew;




        public delegate void DataBackEventHandler(object sender,int PersonID);
        public DataBackEventHandler DataBack;
        public frmAddEditPerson()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public frmAddEditPerson(int PersonID)
        {
            InitializeComponent();
            this._PersonID = PersonID;
            _Mode = enMode.Update;
        }
        private void _ResetDefaultValues()
        {
            lblPersonID.Text = "[????]";
            this.Text = "Add New Person";
            lblTitle.Text = "Add New Person";
            txtAddress.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            dtpDateOfBirth.Value = DateTime.Now.AddYears(-15);
            _Person=new clsPerson();
        }
        private void _LoadData()
        {
            _Person = clsPerson.FindPerson(_PersonID);
            if(_Person==null)
            {
                MessageBox.Show("Error Message:This person is not exist","Error",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            lblPersonID.Text =_Person.PersonID.ToString();
            this.Text = "Update Person";
            lblTitle.Text= "Update Person";
            txtAddress.Text = _Person.Address;
            txtEmail.Text = _Person.Email;
            txtName.Text = _Person.Name;
            txtPhone.Text = _Person.Phone;
            dtpDateOfBirth.Value=(DateTime) _Person.DateOfBirth;
            if(_Person.Gender=="Male")
            {
                rbMale.Checked = true;
            }
            else
            {
                rbFemale.Checked = true;
            }







        }
        private void frmAddEditPerson_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            if(_Mode==enMode.Update)
            {
                _LoadData();
            }
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtName,"This field is required");
                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtName,"");
            }
            if (_Mode==enMode.AddNew&& clsPerson.IsExist(txtName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtName,"This Name is taken by another person.Write Full Name");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtName, "");
            }




        }

        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtAddress.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtAddress, "This field is required");
                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtAddress, "");
            }
            



        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "This field is required");
                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtEmail, "");
            }

            if (!clsValidation.IsValidEmail(txtEmail.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "This email is not valid");
            }

            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtEmail, "");
            }
        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPhone.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPhone, "This field is required");
                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPhone, "");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
       
            if (MessageBox.Show("Are you sure you want to delete this person?", "Confirm",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                if (clsPerson.DeletePerson(_PersonID))
                {
                    _ResetDefaultValues();
                    MessageBox.Show("Person was deleted successfully", "Confirm",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                MessageBox.Show("Error Message:Person delete failed", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Error Message:Some fileds is empty.Check the red icon messages","Error",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            _Person.Email=txtEmail.Text.Trim();
            _Person.Name=txtName.Text.Trim();
            _Person.Address=txtAddress.Text.Trim();
            _Person.DateOfBirth = dtpDateOfBirth.Value;
            _Person.Phone = txtPhone.Text.Trim();
            _Person.Gender = (rbMale.Checked==true?"Male":"Female");
            if(!_Person.Save())
            {
                MessageBox.Show("Error Message:Person update failed", "Error",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(DataBack!=null)
            {
                DataBack.Invoke(this, _Person.PersonID);
            }_PersonID = _Person.PersonID;
            lblPersonID.Text = _Person.PersonID.ToString();
            MessageBox.Show("Person was updated successfully", "Confirm",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);
            _Mode = enMode.Update;
            this.Text = "Update Person";
            lblTitle.Text = "Update Person";
            btnSave.Enabled = false;





        }
    }
}
