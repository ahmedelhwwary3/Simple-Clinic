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

namespace PresentationLayer.Appointments
{
    public partial class frmAddEditAppointment : Form
    {
        private int _AppointmentID = 0;
        private clsAppointment _Appointment;
        private enum enMode { AddNew ,Update};
        private enMode _Mode = enMode.AddNew;
        public frmAddEditAppointment()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public frmAddEditAppointment(int AppointmentID)
        {
            InitializeComponent();
            _AppointmentID = AppointmentID;
            _Mode = enMode.Update;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void _FillDoctorsNamesInComboBox()
        {
            DataTable dtDoctors=clsDoctor.GetAllDoctorsNames();
            foreach(DataRow row in dtDoctors.Rows)
            {
                cbDoctorName.Items.Add(row["Name"]);
            }
        }
         
        private void frmAddEditAppointment_Load(object sender, EventArgs e)
        {
            this.Text = "Add New Appointment";
            txtAppointmentID.Enabled = (_Mode == enMode.Update);
            _Appointment=new clsAppointment();
            dtpAppointmentDate.Value = DateTime.Now;
            dtpAppointmentDate.MinDate=dtpAppointmentDate.Value;
            _FillDoctorsNamesInComboBox();
            cbDoctorName.SelectedIndex = 0;
            cbAppointmentStatus.Text = "Confirmed";
            if (_Mode==enMode.Update)
            {
                _Appointment = clsAppointment.FindAppointment(_AppointmentID);
                if(_Appointment==null)
                {
                    MessageBox.Show("Error Message:Appointment is not exist","Error",
                        MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
                if(_Appointment.AppointmentStatus==clsAppointment.enStatus.Cancelled|| _Appointment.AppointmentStatus == clsAppointment.enStatus.Completed)
                {
                    btnCancel.Enabled = false;
                    btnSave.Enabled = false;
                }
                this.Text = "Update Appointment";
                lblTitle.Text = "Update Appointment";
                txtAppointmentID.Text=_AppointmentID.ToString();
                txtPatientID.Text=_Appointment.PatientID.ToString();
                txtMedicalRecordID.Text = (_Appointment.MedicalRecordID==null?"[????]":_Appointment.MedicalRecordID.ToString());
                txtPaymentID.Text = (_Appointment.PaymentID==null?"[????]":_Appointment.PaymentID.ToString());
                dtpAppointmentDate.MinDate = dtpAppointmentDate.Value;
                dtpAppointmentDate.Value = _Appointment.AppointmentDateTime;


            }
        }

        private void txtPatientID_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtPatientID.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPatientID,"This field is required");
                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPatientID, "");
            }
            if(!clsPatient.IsExist(int.Parse(txtPatientID.Text.Trim())))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPatientID,"This patient is not exist");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPatientID,"");
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
            _Appointment.AppointmentDateTime = dtpAppointmentDate.Value;
            _Appointment.PatientID = int.Parse(txtPatientID.Text.Trim());
            _Appointment.DoctorID = clsDoctor.FindDoctorByName(cbDoctorName.Text).DoctorID;
            _Appointment.AppointmentStatus = (clsAppointment.enStatus)clsAppointment.GetStatusIDByName(cbAppointmentStatus.Text);
           
            if(txtMedicalRecordID.Text.Trim()==string.Empty)
            {
                _Appointment.MedicalRecordID = null;
            }
            else
            {
                _Appointment.MedicalRecordID = int.Parse(txtMedicalRecordID.Text.Trim());
            }
            _Appointment.PatientID = int.Parse(txtPatientID.Text.Trim());
            if(!string.IsNullOrEmpty(txtPaymentID.Text.Trim()))
            {
                _Appointment.PaymentID = int.Parse(txtPaymentID.Text.Trim());
            }
            else
            {
                _Appointment.PaymentID = null;

            }
            if(!_Appointment.Save())
            {
                MessageBox.Show("Error Message:Appointment update failed","Error",
                    MessageBoxButtons.OK
                    ,MessageBoxIcon.Error);
                return; 
            }
            MessageBox.Show("Appointment update succeeded", "Confirm",
                   MessageBoxButtons.OK
                   , MessageBoxIcon.Information);
            _Mode = enMode.Update;
            this.Text = "Update Appointment";
            lblTitle.Text = "Update Appointment";
            btnSave.Enabled = false;


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to cancel this appointment?","Confirm"
                ,MessageBoxButtons.OKCancel,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.OK)
            {
                _Appointment.AppointmentStatus = (clsAppointment.enStatus)4;
                if (_Appointment.Save() && _Mode == enMode.Update)
                {
                    MessageBox.Show("Cancel succeeded", "Confirm",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnSave.Enabled = false;
                    return;
                }
                MessageBox.Show("Error Message:Cancel failed", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }
    }
}
