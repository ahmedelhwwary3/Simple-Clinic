using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsAppointment
    {
        public enum enStatus { Pending = 1, Confirmed = 2, Completed = 3, Cancelled = 4, Rescheduled = 5, NoShow = 6 };


        private enum enMode { AddNew = 1, Update = 2 };
        private enMode _Mode = enMode.AddNew;
        public int AppointmentID { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public DateTime AppointmentDateTime { get; set; }
        public enStatus AppointmentStatus { get; set; }
        public int? MedicalRecordID { get; set; }   
        public int? PaymentID { get; set; }         

        // Constructor
        private clsAppointment(int AppointmentID, int PatientID, int DoctorID, DateTime AppointmentDateTime, enStatus AppointmentStatus, int? MedicalRecordID, int? PaymentID)
        {
            this.AppointmentID = AppointmentID;
            this.PatientID = PatientID;
            this.DoctorID = DoctorID;
            this.AppointmentDateTime = AppointmentDateTime;
            this.AppointmentStatus = AppointmentStatus;
            this.MedicalRecordID = MedicalRecordID;
            this.PaymentID = PaymentID;
            _Mode = enMode.Update;

        }
        public clsAppointment()
        {
            this.AppointmentID = 0;
            this.PatientID = 0;
            this.DoctorID = 0;
            this.AppointmentDateTime = DateTime.MinValue;
            this.AppointmentStatus = enStatus.Pending;
            this.MedicalRecordID = null;
            this.PaymentID = null;
            _Mode = enMode.AddNew;
        }
        private bool _AddNewAppointment()
        {
            this.AppointmentID = clsAppointmentData.AddNewAppointment(this.PatientID, this.DoctorID, this.AppointmentDateTime,(byte)this.AppointmentStatus, this.MedicalRecordID, this.PaymentID);
            return (this.AppointmentID != 0);
        }
        private bool _UpdateAppointment()
        {

            return clsAppointmentData.UpdateAppointment(this.AppointmentID, this.PatientID, this.DoctorID, this.AppointmentDateTime, (byte)this.AppointmentStatus, this.MedicalRecordID, this.PaymentID);
        }
        public static DataTable GetAllAppointments()
        {
            return clsAppointmentData.GetAllAppointments();
        }
        public bool IsExist(int AppointmentID)
        {
            return clsAppointmentData.IsAppointmentExistByID(AppointmentID);
        }
        public static clsAppointment FindAppointment(int AppointmentID)
        {
            int PatientID=0,DoctorID=0;
            DateTime AppointmentDateTime = DateTime.MinValue;
            byte AppointmentStatus=0;
            int? MedicalRecordID=null, PaymentID = null;
            bool IsFound =clsAppointmentData.FindAppointmentByID(AppointmentID, ref PatientID, ref DoctorID, ref AppointmentDateTime, ref AppointmentStatus, ref MedicalRecordID, ref PaymentID);
            return (IsFound == true ? new clsAppointment(AppointmentID, PatientID, DoctorID, AppointmentDateTime, (enStatus)AppointmentStatus, MedicalRecordID, PaymentID):null);
        }
        public static int GetStatusIDByName(string StatusName)
        {
            switch(StatusName)
            {
                case "Pending":
                    return 1;
                case "Confirmed":
                    return 2;
                case "Completed":
                    return 3;
                case "Cancelled":
                    return 4;
                case "Rescheduled":
                    return 5;
                case "No Show":
                    return 6;
                default:
                    return 0;
            }
        }

        public static int GetAppointmentIDForPayment(int PaymentID)
        {
            return clsAppointmentData.GetAppointmentIDForPayment(PaymentID);
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if(!clsAppointmentData.IsAppointmentExistByID(this.AppointmentID))
                        {
                          if(_AddNewAppointment())
                            {
                                _Mode = enMode.Update;
                                return true;
                            }
                        }
                        return false;
                    }
                case enMode.Update:
                    {
                        return _UpdateAppointment();
                    }
                default:
                    return false;
            }

        }





    }


}
