using BusinessLayer;
using BusinessLayer.BusinessLayer;
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

namespace PresentationLayer.Payments
{
    public partial class frmAddEditPayment : Form
    {
        private int _PaymentID = 0;
        private int _AppointmentID = 0;
        private clsPayment _Payment;
        private clsAppointment _Appointment=new clsAppointment();
        private enum enMode { AddNew,Update};
        private enMode _Mode = enMode.AddNew;
        public frmAddEditPayment(int appointmentID)
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
            _AppointmentID = appointmentID;
        }
        public frmAddEditPayment(int PaymentID,int AppointmentID)
        {
            InitializeComponent();
            _PaymentID = PaymentID;
            _Mode = enMode.Update;
            _AppointmentID=AppointmentID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddEditPayment_Load(object sender, EventArgs e)
        {
            cbPaymentMethod.SelectedIndex = 0;
            dtpPaymentDate.Value = DateTime.Now;
            dtpPaymentDate.MinDate = dtpPaymentDate.Value;
            txtAdditionalNotes.Text = "Full Paid";
            txtAmountPaid.Text = (250).ToString();
            _Payment = new clsPayment();
            if(_Mode==enMode.Update)
            {
                _Payment=clsPayment.FindPayment(_PaymentID);
                if(_Payment==null)
                {
                    MessageBox.Show("Error Message:Payment is not exist","Error",
                        MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
                lblPaymentID.Text=_Payment.PaymentID.ToString();
                txtAdditionalNotes.Text = _Payment.AdditionalNotes;
                txtAmountPaid.Text = _Payment.AmountPaid.ToString();
                dtpPaymentDate.MinDate = (DateTime)_Payment.PaymentDate;
                dtpPaymentDate.Value=(DateTime)_Payment.PaymentDate;
               
                cbPaymentMethod.SelectedIndex = cbPaymentMethod.FindString(clsPayment.GetPaymentMethodName((clsPayment.enPaymentMethod)_Payment.PaymentMethod));
                lblTitle.Text = "Update Payment";
                this.Text = "Update Payment";
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
            _Payment.PaymentMethod = clsPayment.GetPaymentMethodEnumByName(cbPaymentMethod.Text);
            _Payment.AdditionalNotes = (txtAdditionalNotes.Text.Trim()!=""? txtAdditionalNotes.Text.Trim():null);
            _Payment.AmountPaid=decimal.Parse(txtAmountPaid.Text.Trim());
            _Payment.PaymentDate = dtpPaymentDate.Value;


            
            if (_Payment.Save())
            {
                _Appointment = clsAppointment.FindAppointment(_AppointmentID);
                _Appointment.PaymentID = _Payment.PaymentID;
                if(_Appointment.Save())
                {
                    _Mode = enMode.Update;
                    btnSave.Enabled = false;
                    this.Text = "Update Payment";
                    lblTitle.Text = "Update Payment";
                    lblPaymentID.Text = _Payment.PaymentID.ToString();
                }
                else
                {
                    MessageBox.Show("Error Message:Appointment Save failed", "Error",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
            }
            else
            {
                MessageBox.Show("Error Message:Payment Save failed", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Save succeeded","Confirm",
                MessageBoxButtons.OK,MessageBoxIcon.Information);
          




        }

        private void txtAmountPaid_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtAmountPaid.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtAmountPaid,"This field is required");
                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtAmountPaid, null);
            }
            if(!clsValidation.IsValidNumber(txtAmountPaid.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtAmountPaid, "Invalid Amount");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtAmountPaid, null);
            }
        }
    }
}
