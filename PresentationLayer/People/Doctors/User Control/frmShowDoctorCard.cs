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

namespace PresentationLayer.People.Doctors.User_Control
{
    public partial class frmShowDoctorCard : Form
    {
        private int _DoctorID = 0;
   
        public frmShowDoctorCard(int DoctorID)
        {
            InitializeComponent();
            _DoctorID = DoctorID;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this Doctor?", "Confirm",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                if (clsDoctor.Delete(_DoctorID))
                {
                    MessageBox.Show("Doctor was deleted successfully", "Confirm",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                MessageBox.Show("Error Message:Doctor delete failed", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowDoctorCard_Load(object sender, EventArgs e)
        {
            ctrlDoctorCard1.LoadDoctorData(_DoctorID);
        }
    }
}
