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

namespace PresentationLayer.People.All.User_Control
{
    public partial class ctrlPersonCard : UserControl
    {
        private string _Title = "";
        private int _PersonID = 0;
        private clsPerson _Person =new clsPerson();
        public ctrlPersonCard()
        {
            InitializeComponent();
        }
        public clsPerson Person
        {
            get { return _Person; }
        }
        public string Title
        {
            get { return _Title; }
            set { _Title = value;
                lblTitle.Text= _Title;
            }
        }
        public void LoadPersonData(int PersonID)
        {
            _PersonID = PersonID;
            _Person = clsPerson.FindPerson(_PersonID);
            if (_Person == null)
            {
                MessageBox.Show("Error Message:Person is not exist", "Error"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblAddress.Text = _Person.Address;
            lblDateOfBirth.Text = clsUtil.ConvertToShortDateString((DateTime)_Person.DateOfBirth);
            lblEmail.Text = _Person.Email;
            lblFullName.Text = _Person.Name;
            lblPhone.Text= _Person.Phone;
            lblPersonID.Text=_Person.PersonID.ToString();
            llEditPerson.Enabled = true;
        }

        private void llEditPerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditPerson frm=new frmAddEditPerson(_PersonID);
            frm.ShowDialog();
        }
    }
}