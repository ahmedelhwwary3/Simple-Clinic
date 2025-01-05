using BusinessLayer;
using PresentationLayer.People.All.User_Control;
using PresentationLayer.People.Doctors.User_Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.People.Doctors
{
    public partial class frmShowDoctorsList : Form
    {
        private DataTable _dtAllDoctors=new DataTable();
        public frmShowDoctorsList()
        {
            InitializeComponent();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddEditDoctor frm = new frmAddEditDoctor();
            frm.ShowDialog();
            frmShowDoctorsList_Load(null, null);
        }

        private void frmShowDoctorsList_Load(object sender, EventArgs e)
        {
            _dtAllDoctors=clsDoctor.GetAllDoctors();
            dgvDoctors.DataSource= _dtAllDoctors;
            cbFilterColumn.SelectedIndex = 0;
            txtFilterValue.Visible = (cbFilterColumn.SelectedIndex!=0);//Not none
            if(dgvDoctors.Rows.Count>0)
            {
                dgvDoctors.Columns[0].HeaderText = "Doctor ID";
                dgvDoctors.Columns[0].Width = 70;

                dgvDoctors.Columns[1].HeaderText = "Person ID";
                dgvDoctors.Columns[1].Width = 60;

                dgvDoctors.Columns[2].HeaderText = "Specialization";
                dgvDoctors.Columns[2].Width = 150;

                lblRecords.Text=dgvDoctors.Rows.Count.ToString();
            }
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditDoctor frm=new frmAddEditDoctor();
            frm.ShowDialog();
            frmShowDoctorsList_Load(null, null);
        }

        
        private void cbFilterColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFilterColumn.SelectedIndex != 0);
            if(txtFilterValue.Visible)
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
                case "Doctor ID":
                    {
                        FilterColumn = "DoctorID";
                        break;
                    }
                case "Person ID":
                    {
                        FilterColumn = "PersonID";
                        break;
                    }
                case "Specialization":
                    {
                        FilterColumn = "Specialization";
                        break;
                    }
                default:
                    FilterColumn = "";
                    break;
            }
            if(cbFilterColumn.Text=="None"||txtFilterValue.Text.Trim()==string.Empty)
            {
                _dtAllDoctors.DefaultView.RowFilter = "";
                lblRecords.Text = dgvDoctors.Rows.Count.ToString();
                return;
            }
            if(cbFilterColumn.Text!="Specialization")
            {
                _dtAllDoctors.DefaultView.RowFilter = string.Format("[{0}]={1}",FilterColumn,txtFilterValue.Text.Trim());
                lblRecords.Text = dgvDoctors.Rows.Count.ToString();
                return;
            }
            _dtAllDoctors.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", FilterColumn, txtFilterValue.Text.Trim());
            lblRecords.Text = dgvDoctors.Rows.Count.ToString();

        }

        private void showDoctorCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowDoctorCard frm=new frmShowDoctorCard((int)dgvDoctors.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmShowDoctorsList_Load(null, null);
        }

        private void updateDoctorToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmAddEditDoctor frm = new frmAddEditDoctor((int)dgvDoctors.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmShowDoctorsList_Load(null, null);
        }

        private void deleteDoctorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this Doctor?", "Confirm",
               MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                if (clsDoctor.Delete((int)dgvDoctors.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Doctor was deleted successfully", "Confirm",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmShowDoctorsList_Load(null, null);
                    return;
                }
                MessageBox.Show("Error Message:Doctor delete failed", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterColumn.Text !="Specialization")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }
    }
    }

