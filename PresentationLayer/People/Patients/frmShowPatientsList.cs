using BusinessLayer;
using PresentationLayer.People.All;
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

namespace PresentationLayer.People.Patients
{
    
    public partial class frmShowPatientsList : Form
    {
        private DataTable _dtAllPatients;
        public frmShowPatientsList()
        {
            InitializeComponent();
        }

        private void frmShowPatientsList_Load(object sender, EventArgs e)
        {
             
            _dtAllPatients = clsPatient.GetAllPatients();
            dgvPatients.DataSource = _dtAllPatients;
            cbFilterColumn.SelectedIndex = 0;
            txtFilterValue.Visible = (cbFilterColumn.SelectedIndex != 0);//Not none
            if (dgvPatients.Rows.Count > 0)
            {
                dgvPatients.Columns[0].HeaderText = "Patient ID";
                dgvPatients.Columns[0].Width = 70;

                dgvPatients.Columns[1].HeaderText = "Person ID";
                dgvPatients.Columns[1].Width = 60;

                 
                
            }
            lblRecords.Text = dgvPatients.Rows.Count.ToString();
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
                case "Payment ID":
                    {
                        FilterColumn = "PatientID";
                        break;
                    }
                case "Person ID":
                    {
                        FilterColumn = "PersonID";
                        break;
                    }
                 
                default:
                    FilterColumn = "";
                    break;
            }
            if (cbFilterColumn.Text == "None" || txtFilterValue.Text.Trim() == string.Empty)
            {
                _dtAllPatients.DefaultView.RowFilter = "";
                lblRecords.Text = dgvPatients.Rows.Count.ToString();
                return;
            }
            
                _dtAllPatients.DefaultView.RowFilter = string.Format("[{0}]={1}", FilterColumn, txtFilterValue.Text.Trim());
                lblRecords.Text = dgvPatients.Rows.Count.ToString();
           
            //_dtAllPatients.DefaultView.RowFilter = string.Format("[{0}] like ['{1}%']", FilterColumn, txtFilterValue.Text.Trim());
            //lblRecords.Text = dgvPatients.Rows.Count.ToString();

        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddEditPatient frm=new frmAddEditPatient();
            frm.ShowDialog();
            frmShowPatientsList_Load(null,null);
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditPatient frm = new frmAddEditPatient();
            frm.ShowDialog();
            frmShowPatientsList_Load(null, null);
        }

        private void updatePatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditPatient frm = new frmAddEditPatient((int)dgvPatients.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmShowPatientsList_Load(null, null);
        }

        private void deletePatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this Patient?", "Confirm",
               MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                if (clsPatient.Delete((int)dgvPatients.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Patient was deleted successfully", "Confirm",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmShowPatientsList_Load(null, null);
                    return;
                }
                MessageBox.Show("Error Message:Patient delete failed", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void showPatientCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PatientID = (int)dgvPatients.CurrentRow.Cells[0].Value;
            frmShowPatientCard frm = new frmShowPatientCard(PatientID);
            frm.ShowDialog();
        }
    }
}
