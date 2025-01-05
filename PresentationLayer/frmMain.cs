using PresentationLayer.Appointments;
using PresentationLayer.Medical_Records;
using PresentationLayer.Medical_Records_And_Prescriptions.Medical_Records;
using PresentationLayer.Medical_Records_And_Prescriptions.Prescriptions;
using PresentationLayer.Payments;
using PresentationLayer.People.All;
using PresentationLayer.People.Doctors;
using PresentationLayer.People.Patients;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

     

        private void showAllPeopleListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPeopleList frm = new frmShowPeopleList();
            frm.ShowDialog();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frm=new frmAddEditPerson();
            frm.ShowDialog();
        }

        private void showAllDoctorsListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowDoctorsList frm=new frmShowDoctorsList();
            frm.ShowDialog();
        }

        private void addNewDoctorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditDoctor frm=new frmAddEditDoctor();
            frm.ShowDialog();

          
        }

        

        private void addNewAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditAppointment frm=new frmAddEditAppointment();
            frm.ShowDialog();
        }

        private void showAllAppointmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowAppointmentsList frm=new frmShowAppointmentsList();
            frm.ShowDialog();
        }

        private void showAllPatientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPatientsList frm=new frmShowPatientsList();
            frm.ShowDialog();
        }

        private void addNewPatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditPatient frm=new frmAddEditPatient();
            frm.ShowDialog();
        }

        private void showAllPaymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPaymentsList frm=new frmShowPaymentsList();
            frm.ShowDialog();
        }

        private void showAllMedicalRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPrescritionsList frm=new frmShowPrescritionsList();
            frm.ShowDialog();
        }

        private void addNewPrescriptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditPrescription frm=new frmAddEditPrescription();
            frm.ShowDialog();
        }

        private void addNewMedicalRecoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditMedicalRecord frm=new frmAddEditMedicalRecord();
            frm.ShowDialog();
        }

        private void showAllMedicalRecordsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmShowMedicalRecordsList frm=new frmShowMedicalRecordsList();
            frm.ShowDialog();
        }
    }
}
