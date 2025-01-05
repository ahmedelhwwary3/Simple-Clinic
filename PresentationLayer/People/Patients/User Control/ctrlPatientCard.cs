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

namespace PresentationLayer.People.Patients.User_Control
{
    public partial class ctrlPatientCard : UserControl
    {
        private int _PatientID = 0;
        private clsPatient _Patient = new clsPatient();
        public clsPatient Patient
        {
            get { return _Patient; }
        }
        public ctrlPatientCard()
        {
            InitializeComponent();
        }
        public void LoadPatientData(int PatientID)
        {
            ctrlPersonCard1.Title = "Patient Card";
            _PatientID = PatientID;

            if (clsPatient.IsExist(_PatientID) == false)
            {
                MessageBox.Show("Error Message:Patient is not exist", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            _Patient = clsPatient.FindPatient(PatientID);
            ctrlPersonCard1.LoadPersonData(_Patient.PersonID);
            
            lblPatientID.Text = _Patient.PatientID.ToString();
        }
    }
}
