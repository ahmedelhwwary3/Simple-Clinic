using BusinessLayer;
using PresentationLayer.People.All.User_Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.People.All
{
    public partial class frmShowPeopleList : Form
    {
        private DataTable _dtAllPoepleList = new DataTable();
        public frmShowPeopleList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson();
            frm.ShowDialog();
            frmShowPeopleList_Load(null, null);
        }

        private void frmShowPeopleList_Load(object sender, EventArgs e)
        {
            _dtAllPoepleList = clsPerson.GetAllPeople();
            dgvPeople.DataSource= _dtAllPoepleList;
            cbFilterColumn.Text = "None";
            txtFilterValue.Visible = ((cbFilterColumn.Text != "None") && dgvPeople.Rows.Count > 0);
            if (dgvPeople.Rows.Count > 0)
            {
                dgvPeople.Columns[0].HeaderText = "Person ID";
                dgvPeople.Columns[0].Width = 70;

                dgvPeople.Columns[1].HeaderText = "Name";
                dgvPeople.Columns[1].Width = 190;

                dgvPeople.Columns[2].HeaderText = "Date Of Birth";
                dgvPeople.Columns[2].Width = 120;

                dgvPeople.Columns[3].HeaderText = "Gender";
                dgvPeople.Columns[3].Width = 70;

                dgvPeople.Columns[4].HeaderText = "Phone Number";
                dgvPeople.Columns[4].Width = 130;

                dgvPeople.Columns[5].HeaderText = "Email";
                dgvPeople.Columns[5].Width = 130;

                dgvPeople.Columns[6].HeaderText = "Address";
                dgvPeople.Columns[6].Width = 130;


            }
            lblRecords.Text = dgvPeople.Rows.Count.ToString();
        }

        private void cbFilterColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = ((cbFilterColumn.Text != "None") && dgvPeople.Rows.Count > 0);
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
                case "Person ID":
                    {
                        FilterColumn = "PersonID";
                        break;
                    }
                case "Name":
                    {
                        FilterColumn = "Name";
                        break;
                    }
                case "Date Of Birth":
                    {
                        FilterColumn = "DateOfBirth";
                        break;
                    }
                case "Gender":
                    {
                        FilterColumn = "Gender";
                        break;
                    }
                case "Phone Number":
                    {
                        FilterColumn = "PhoneNumber";
                        break;
                    }
                case "Email":
                    {
                        FilterColumn = "Email";
                        break;
                    }
                case "Address":
                    {
                        FilterColumn = "Address";
                        break;
                    }
                default:
                    FilterColumn = "";
                    break;

            }

            if (txtFilterValue.Text.Trim()==""|| cbFilterColumn.Text == "None")
            {
                _dtAllPoepleList.DefaultView.RowFilter = string.Empty;
                lblRecords.Text = _dtAllPoepleList.Rows.Count.ToString();
                return;
            }
            if (cbFilterColumn.Text== "Person ID")
            {
                _dtAllPoepleList.DefaultView.RowFilter = string.Format("[{0}]={1}", FilterColumn, txtFilterValue.Text.Trim());
                lblRecords.Text = _dtAllPoepleList.Rows.Count.ToString();
                return;
            }

            _dtAllPoepleList.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", FilterColumn, txtFilterValue.Text.Trim());
            lblRecords.Text = _dtAllPoepleList.Rows.Count.ToString();
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frm=new frmAddEditPerson();
            frm.ShowDialog();
            frmShowPeopleList_Load(null,null);
        }

        private void updatePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID =(int) dgvPeople.CurrentRow.Cells[0].Value;
            frmAddEditPerson frm = new frmAddEditPerson(PersonID);
            frm.ShowDialog();
            frmShowPeopleList_Load(null, null);
        }

        private void deletePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvPeople.CurrentRow.Cells[0].Value;
            if (MessageBox.Show("Are you sure you want to delete this person?","Confirm",
                MessageBoxButtons.OKCancel,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.OK)
            {
                if(clsPerson.DeletePerson(PersonID))
                {
                    MessageBox.Show("Person was deleted successfully","Confirm",
                        MessageBoxButtons.OK,MessageBoxIcon.Information);
                    frmShowPeopleList_Load(null, null);
                    return;
                }
                MessageBox.Show("Error Message:Person delete failed","Error",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void showPersonCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvPeople.CurrentRow.Cells[0].Value;
            frmShowPersonCard frm = new frmShowPersonCard(PersonID);
            frm.ShowDialog();
            frmShowPeopleList_Load(null,null);
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbFilterColumn.Text=="Person ID")
            {
                e.Handled=!char.IsDigit(e.KeyChar)&&!char.IsControl(e.KeyChar);
            }
        }
    }
}
