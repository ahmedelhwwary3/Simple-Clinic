using BusinessLayer;
using BusinessLayer.BusinessLayer;
using PresentationLayer.People.Patients.User_Control;
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
    public partial class frmShowPaymentsList : Form
    {
        private DataTable _dtAllPayments;
        public frmShowPaymentsList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowPaymentsList_Load(object sender, EventArgs e)
        {
            _dtAllPayments = clsPayment.GetAllPayments();
            dgvPayments.DataSource = _dtAllPayments;
            cbFilterColumn.SelectedIndex = 0;
            txtFilterValue.Visible = (cbFilterColumn.SelectedIndex != 0); 
            if (dgvPayments.Rows.Count > 0)
            {
                dgvPayments.Columns[0].HeaderText = "Payment ID";
                dgvPayments.Columns[0].Width = 70;

                dgvPayments.Columns[1].HeaderText = "Payment Date";
                dgvPayments.Columns[1].Width = 60;

                dgvPayments.Columns[2].HeaderText = "Payment Method";
                dgvPayments.Columns[2].Width = 60;

                dgvPayments.Columns[3].HeaderText = "Amount Paid";
                dgvPayments.Columns[3].Width = 60;

                dgvPayments.Columns[4].HeaderText = "Additional Notes";
                dgvPayments.Columns[4].Width = 60;

            }
            lblRecords.Text = dgvPayments.Rows.Count.ToString();
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            switch (cbFilterColumn.Text)
            {
                case "Payment ID":
                    {
                        FilterColumn = "PaymentID";
                        break;
                    }
                case "Payment Date":
                    {
                        FilterColumn = "PaymentDate";
                        break;
                    }
                case "Payment Method":
                    {
                        FilterColumn = "PaymentMethod";
                        break;
                    }
                case "Amount Paid":
                    {
                        FilterColumn = "AmountPaid";
                        break;
                    }
                case "Additional Notes":
                    {
                        FilterColumn = "AdditionalNotes";
                        break;
                    }
                default:
                    FilterColumn = "";
                    break;
            }
            if (cbFilterColumn.Text == "None" || txtFilterValue.Text.Trim() == string.Empty)
            {
                _dtAllPayments.DefaultView.RowFilter = "";
                lblRecords.Text = dgvPayments.Rows.Count.ToString();
                return;
            }
            if(cbFilterColumn.Text=="Payment ID"||cbFilterColumn.Text=="Amount Paid")
            {
                _dtAllPayments.DefaultView.RowFilter = string.Format("[{0}]={1}", FilterColumn, txtFilterValue.Text.Trim());
                lblRecords.Text = dgvPayments.Rows.Count.ToString();
                return;
            }
         

            _dtAllPayments.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", FilterColumn, txtFilterValue.Text.Trim());
            lblRecords.Text = dgvPayments.Rows.Count.ToString();

        }

        private void cbFilterColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFilterColumn.SelectedIndex != 0);
            if (txtFilterValue.Visible)
            {
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbFilterColumn.Text == "Payment ID" || cbFilterColumn.Text == "Amount Paid")
            {
                e.Handled=!char.IsControl(e.KeyChar)&&!char.IsDigit(e.KeyChar);
            }
        }

        private void showPatientCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PaymentID = (int)dgvPayments.CurrentRow.Cells[0].Value;
            int PatientID=clsPayment.GetPatientIDByPaymentID(PaymentID);
            frmShowPatientCard frm=new frmShowPatientCard(PatientID);
            frm.ShowDialog();
        }

         

        private void updatePatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PaymentID = (int)dgvPayments.CurrentRow.Cells[0].Value;
            int AppointmentID = clsAppointment.GetAppointmentIDForPayment(PaymentID);
            frmAddEditPayment frm = new frmAddEditPayment(PaymentID,AppointmentID);
            frm.ShowDialog();
            frmShowPaymentsList_Load(null, null);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            int PaymentID = (int)dgvPayments.CurrentRow.Cells[0].Value;
            clsPayment Payment = clsPayment.FindPayment(PaymentID);
            if(Payment.AdditionalNotes.Trim()=="Full Paid")
            {
                updatePatientToolStripMenuItem.Enabled = false;
            }
            else
            {
                updatePatientToolStripMenuItem.Enabled = true;
            }
        }
    }
}
