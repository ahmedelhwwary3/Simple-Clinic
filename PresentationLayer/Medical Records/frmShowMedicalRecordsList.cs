using BusinessLayer;
using PresentationLayer.Medical_Records_And_Prescriptions.Medical_Records;
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
    public partial class frmShowMedicalRecordsList : Form
    {
        private DataTable _dtMedicalRecords = new DataTable();
        public frmShowMedicalRecordsList()
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
                _dtMedicalRecords.DefaultView.RowFilter = "";
                lblRecords.Text = dgvMedicalRecords.Rows.Count.ToString();
                return;
            }
            if (cbFilterColumn.Text == "Medical Record ID" )
            {
                _dtMedicalRecords.DefaultView.RowFilter = string.Format("[{0}]={1}", FilterColumn, txtFilterValue.Text.Trim());
                lblRecords.Text = dgvMedicalRecords.Rows.Count.ToString();
                return;
            }
            _dtMedicalRecords.DefaultView.RowFilter = string.Format("[{0}] like ['{1}%']", FilterColumn, txtFilterValue.Text.Trim());
            lblRecords.Text = dgvMedicalRecords.Rows.Count.ToString();
            return;
        }

        private void frmShowMedicalRecordsList_Load(object sender, EventArgs e)
        {
            cbFilterColumn.Text = "None";
            txtFilterValue.Visible = (cbFilterColumn.Text != "None");
            _dtMedicalRecords = clsMedicalRecord.GetAllMedicalRecords();
            dgvMedicalRecords.DataSource = _dtMedicalRecords;
            if (dgvMedicalRecords.Rows.Count > 0)
            {
                dgvMedicalRecords.Columns[0].HeaderText = "MedicalRecord ID";
                dgvMedicalRecords.Columns[0].Width = 70;

                dgvMedicalRecords.Columns[1].HeaderText = "Visit Description";
                dgvMedicalRecords.Columns[1].Width = 220;

                dgvMedicalRecords.Columns[2].HeaderText = "Diagnosis";
                dgvMedicalRecords.Columns[2].Width = 110;

                dgvMedicalRecords.Columns[3].HeaderText = "Additional Notes";
                dgvMedicalRecords.Columns[3].Width = 170;

                

                lblRecords.Text = dgvMedicalRecords.Rows.Count.ToString();
            }
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterColumn.Text == "Medical Record ID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void addNewMedicalRecordToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            btnAddNewMedicalRecord.PerformClick();
        }

        private void updateMedicalRecordToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddEditMedicalRecord frm=new frmAddEditMedicalRecord((int)dgvMedicalRecords.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmShowMedicalRecordsList_Load(null, null);
        }
    }
}
