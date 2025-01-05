using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.People.Patients.User_Control
{
    public partial class frmShowPatientCard : Form
    {
        private int _PatientID = 0;
        public frmShowPatientCard(int PatientID)
        {
            InitializeComponent();
            _PatientID = PatientID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this Patient?", "Confirm",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                if (clsPatient.Delete(_PatientID))
                {
                    MessageBox.Show("Patient was deleted successfully", "Confirm",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                MessageBox.Show("Error Message:Patient delete failed", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmShowPatientCard_Load(object sender, EventArgs e)
        {
            ctrlPatientCard1.LoadPatientData(_PatientID);
            
        }
    }
}
