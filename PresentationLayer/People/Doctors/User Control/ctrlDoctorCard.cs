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

namespace PresentationLayer.People.Doctors
{
    public partial class ctrlDoctorCard : UserControl
    {
        private int _DoctorID = 0;
        private clsDoctor _Doctor=new clsDoctor();
        public clsDoctor Doctor
        {
            get { return _Doctor; }
        }
        public ctrlDoctorCard()
        {
            InitializeComponent();
        }
        public void LoadDoctorData(int DoctorID)
        {
            ctrlPersonCard1.Title = "Doctor Card";
            _DoctorID=DoctorID;
            
            if(clsDoctor.IsExist(_DoctorID)==false)
            {
                MessageBox.Show("Error Message:Doctor is not exist","Error",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
               
                return;
            }
            _Doctor = clsDoctor.FindDoctor(DoctorID);
            ctrlPersonCard1.LoadPersonData(_Doctor.PersonID);
            lblSpecialization.Text= _Doctor.Specialization;
            lblDoctorID.Text=_Doctor.DoctorID.ToString();
        }
    }
}
