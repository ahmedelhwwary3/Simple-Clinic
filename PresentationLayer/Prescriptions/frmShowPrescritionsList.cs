using BusinessLayer;
using PresentationLayer.Medical_Records_And_Prescriptions.Medical_Records;
using PresentationLayer.Medical_Records_And_Prescriptions.Prescriptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Medical_Records
{
    public partial class frmShowPrescritionsList : Form
    {
        private DataTable _dtPrescriptions=new DataTable();
        public frmShowPrescritionsList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
                case "Medical Record ID":
                    {
                        FilterColumn = "MedicalRecordID";
                        break;
                    }
                 
                case "Prescription ID":

                    {
                        FilterColumn = "PrescriptionID";
                        break;
                    }

                case "Medication Name":

                    {
                        FilterColumn = "MedicationName";
                        break;
                    }
                case "Dosage":

                    {
                        FilterColumn = "Dosage";
                        break;
                    }
                case "Frequency":

                    {
                        FilterColumn = "Frequency";
                        break;
                    }
                case "Start Date":

                    {
                        FilterColumn = "StartDate";
                        break;
                    }
                case "End Date":


                    {
                        FilterColumn = "EndDate";
                        break;
                    }
                case "Special Instructions":

                    {
                        FilterColumn = "SpecialInstructions";
                        break;
                    }
                default:
                    FilterColumn = "";
                    break;
            }
            if (cbFilterColumn.Text == "None" || txtFilterValue.Text.Trim() == string.Empty)
            {
                _dtPrescriptions.DefaultView.RowFilter = "";
                lblRecords.Text = dgvMedicalRecords.Rows.Count.ToString();
                return;
            }
            if (cbFilterColumn.Text == "Medical Record ID" || cbFilterColumn.Text == "Prescription ID")
            {
                _dtPrescriptions.DefaultView.RowFilter = string.Format("[{0}]={1}", FilterColumn, txtFilterValue.Text.Trim());
                lblRecords.Text = dgvMedicalRecords.Rows.Count.ToString();
                return;
            }
            _dtPrescriptions.DefaultView.RowFilter = string.Format("[{0}] like ['{1}%']", FilterColumn, txtFilterValue.Text.Trim());
            lblRecords.Text = dgvMedicalRecords.Rows.Count.ToString();
            return;
        }
        private void _FillFilterComboBoxPrescriptions()
        {
            cbFilterColumn.Items.Clear();
            cbFilterColumn.Items.Add("None");
            cbFilterColumn.Items.Add("Prescription ID"); 
            cbFilterColumn.Items.Add("Medical Record ID");
            cbFilterColumn.Items.Add("Medication Name");
            cbFilterColumn.Items.Add("Dosage");
            cbFilterColumn.Items.Add("Frequency");
            cbFilterColumn.Items.Add("Start Date");
            cbFilterColumn.Items.Add("End Date");
            cbFilterColumn.Items.Add("Special Instructions");
        }             
        private void frmShowMedicalRecordsAndPrescritionsLists_Load(object sender, EventArgs e)
        {
            cbFilterColumn.Text = "None";
            txtFilterValue.Visible = (cbFilterColumn.Text!="None");
            _FillFilterComboBoxPrescriptions();
            _dtPrescriptions = clsPrescription.GetAllPrescriptions();
            dgvMedicalRecords.DataSource = _dtPrescriptions;
            if (dgvMedicalRecords.Rows.Count > 0)
            {
                dgvMedicalRecords.Columns[0].HeaderText = "Prescription ID";
                dgvMedicalRecords.Columns[0].Width = 70;

                dgvMedicalRecords.Columns[1].HeaderText = "Medical Record ID";
                dgvMedicalRecords.Columns[1].Width = 70;

                dgvMedicalRecords.Columns[2].HeaderText = "MedicationName";
                dgvMedicalRecords.Columns[2].Width = 140;

                dgvMedicalRecords.Columns[3].HeaderText = "Dosage";
                dgvMedicalRecords.Columns[3].Width = 120;

                dgvMedicalRecords.Columns[4].HeaderText = "Frequency";
                dgvMedicalRecords.Columns[4].Width = 120;

                dgvMedicalRecords.Columns[5].HeaderText = "Start Date";
                dgvMedicalRecords.Columns[5].Width = 120;

                dgvMedicalRecords.Columns[6].HeaderText = "End Date";
                dgvMedicalRecords.Columns[6].Width = 120;

                dgvMedicalRecords.Columns[7].HeaderText = "Special Instructions";
                dgvMedicalRecords.Columns[7].Width = 170;

                lblRecords.Text = dgvMedicalRecords.Rows.Count.ToString();
            }

        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbFilterColumn.Text == "Medical Record ID" || cbFilterColumn.Text == "Prescription ID")
            {
                e.Handled=!char.IsDigit(e.KeyChar)&&!char.IsControl (e.KeyChar);
            }
        }

       
   

        private void addNewMedicalRecordToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddEditPrescription frm = new frmAddEditPrescription();
            frm.ShowDialog();
            frmShowMedicalRecordsAndPrescritionsLists_Load(null, null);
        }

        private void updateMedicalRecordToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddEditPrescription frm = new frmAddEditPrescription((int)dgvMedicalRecords.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmShowMedicalRecordsAndPrescritionsLists_Load(null, null);
        }

        private void btnAddNewPrescription_Click(object sender, EventArgs e)
        {
            frmAddEditPrescription frm = new frmAddEditPrescription();
            frm.ShowDialog();
            frmShowMedicalRecordsAndPrescritionsLists_Load(null, null);
        }
    }
}
