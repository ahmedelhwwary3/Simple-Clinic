using BusinessLayer;
using PresentationLayer.Payments;
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
    public partial class frmShowAppointmentsList : Form
    {
        private DataTable _dtAllAppointments=new DataTable();
        public frmShowAppointmentsList()
        {
            InitializeComponent();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddEditAppointment frm=new frmAddEditAppointment();
            frm.ShowDialog();
            frmShowAppointmentsList_Load(null, null);
        }

        private void frmShowAppointmentsList_Load(object sender, EventArgs e)
        {
            _dtAllAppointments = clsAppointment.GetAllAppointments();
            foreach(DataRow row in _dtAllAppointments.Rows)
            {
                if (row["MedicalRecordID"]==null)
                {
                    row["MedicalRecordID"] = 0;
                }
                if (row["PaymentID"]==null)
                {
                    row["PaymentID"] = 0;
                }
            }
            dgvAppointments.DataSource = _dtAllAppointments;
            cbFilterColumn.SelectedIndex = 0;
            txtFilterValue.Visible = (cbFilterColumn.SelectedIndex != 0);//Not none
            if (dgvAppointments.Rows.Count > 0)
            {
                dgvAppointments.Columns[0].HeaderText = "Appointment ID";
                dgvAppointments.Columns[0].Width = 70;

                dgvAppointments.Columns[1].HeaderText = "Patient ID";
                dgvAppointments.Columns[1].Width = 70;

                dgvAppointments.Columns[2].HeaderText = "Appointment ID";
                dgvAppointments.Columns[2].Width = 70;

                dgvAppointments.Columns[3].HeaderText = "Appointment Date Time";
                dgvAppointments.Columns[3].Width = 130;

                dgvAppointments.Columns[4].HeaderText = "Appointment Status";
                dgvAppointments.Columns[4].Width = 100;

                dgvAppointments.Columns[5].HeaderText = "Medical Record ID";
                dgvAppointments.Columns[5].Width = 70;

                dgvAppointments.Columns[6].HeaderText = "Payment ID";
                dgvAppointments.Columns[6].Width = 70;

                lblRecords.Text = dgvAppointments.Rows.Count.ToString();
            }
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

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            switch (cbFilterColumn.Text)
            {
                case "Appointment ID":
                    {
                        FilterColumn = "AppointmentID";
                        break;
                    }
                case "Doctor ID":
                    {
                        FilterColumn = "DoctorID";
                        break;
                    }
                case "Patient ID":
                    {
                        FilterColumn = "PatientID";
                        break;
                    }
                case "Appointment Date Time":
                    {
                        FilterColumn = "AppointmentDateTime";
                        break;
                    }
                case "Appointment Status":
                    {
                        FilterColumn = "AppointmentStatus";
                        break;
                    }
                case "Medical Record ID":
                    {
                        FilterColumn = "MedicalRecordID";
                        break;
                    }
                case "Payment ID":
                    {
                        FilterColumn = "PaymentID";
                        break;
                    }
                default:
                    FilterColumn = "";
                    break;
            }
            if (cbFilterColumn.Text == "None" || txtFilterValue.Text.Trim() == string.Empty)
            {
                _dtAllAppointments.DefaultView.RowFilter = "";
                lblRecords.Text = dgvAppointments.Rows.Count.ToString();
                return;
            }
            if (cbFilterColumn.Text != "Appointment Date Time")
            {
                _dtAllAppointments.DefaultView.RowFilter = string.Format("[{0}]={1}", FilterColumn, txtFilterValue.Text.Trim());
                lblRecords.Text = dgvAppointments.Rows.Count.ToString();
                return;
            }
            _dtAllAppointments.DefaultView.RowFilter = string.Format("[{0}] like ['{1}%']", FilterColumn, txtFilterValue.Text.Trim());
            lblRecords.Text = dgvAppointments.Rows.Count.ToString();

        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbFilterColumn.Text!= "Appointment Date Time")
            {
                e.Handled=!char.IsDigit(e.KeyChar)&&!char.IsControl(e.KeyChar);
            }
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditAppointment frm=new frmAddEditAppointment();
            frm.ShowDialog();
            frmShowAppointmentsList_Load(null, null);
        }

        private void CancelAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsAppointment Appointment = clsAppointment.FindAppointment((int)dgvAppointments.CurrentRow.Cells[0].Value);
            if (MessageBox.Show("Are you sure you want to cancel this appointment?", "Confirm"
               , MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                Appointment.AppointmentStatus = (clsAppointment.enStatus)4;
                if (Appointment.Save())
                {
                    MessageBox.Show("Cancel succeeded", "Confirm",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmShowAppointmentsList_Load(null, null);
                    return;
                }
                MessageBox.Show("Error Message:Cancel failed", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            clsAppointment Appointment = clsAppointment.FindAppointment((int)dgvAppointments.CurrentRow.Cells[0].Value);
            if (Appointment.AppointmentStatus==clsAppointment.enStatus.Cancelled)
            {
                updateDoctorToolStripMenuItem.Enabled = false;
                CancelAppointmentToolStripMenuItem.Enabled = false;
            }
            else
            {
                updateDoctorToolStripMenuItem.Enabled = true;
                CancelAppointmentToolStripMenuItem.Enabled = true;
            }

            if(Appointment.PaymentID!=null)
            {
                payForAppointmentToolStripMenuItem.Enabled = false;
            }
            else
            {
                payForAppointmentToolStripMenuItem.Enabled = true;
            }




        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void payForAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int AppointmentID = (int)dgvAppointments.CurrentRow.Cells[0].Value;
            frmAddEditPayment frm=new frmAddEditPayment(AppointmentID);
            frm.ShowDialog();
            frmShowAppointmentsList_Load(null, null);
        }

        private void updateDoctorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditAppointment frm = new frmAddEditAppointment((int)dgvAppointments.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmShowAppointmentsList_Load(null, null);
        }
    }
}
