using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsPatient
    {
        private enum enMode { AddNew = 1, Update = 2 };
        private enMode _Mode = enMode.AddNew;

        public int PatientID { get; set; }
        public int PersonID { get; set; }

        
        private clsPatient(int PatientID, int PersonID)
        {
            this.PatientID = PatientID;
            this.PersonID = PersonID;
            _Mode = enMode.Update;
        }

        public clsPatient()
        {
            this.PatientID = 0;
            this.PersonID = 0;
            _Mode = enMode.AddNew;
        }

        private bool _AddNewPatient()
        {
            this.PatientID = clsPatientData.AddNewPatient(this.PersonID);
            return (this.PatientID != 0);
        }

        private bool _UpdatePatient()
        {
            return clsPatientData.UpdatePatient(this.PatientID, this.PersonID);
        }

        public static clsPatient FindPatient(int PatientID)
        {
            int PersonID = 0;
            bool IsFound = clsPatientData.FindPatientByID(PatientID, ref PersonID);

            if (IsFound)
            {
                return new clsPatient(PatientID, PersonID);
            }
            else
            {
                return null;
            }
        }

        public static bool IsExist(int PatientID)
        {
            return clsPatientData.IsPatientExistByID(PatientID);
        }

        public static DataTable GetAllPatients()
        {
            return clsPatientData.GetAllPatients();
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (!clsPatientData.IsPatientExistByID(this.PatientID))
                        {
                            if(_AddNewPatient())
                            {
                                _Mode = enMode.Update;
                                return true;
                            }
                        
                           
                        }
                        return false;
                    }
                case enMode.Update:
                    {
                        return _UpdatePatient();
                    }
                default:
                    return false;
            }
        }

        public static bool Delete(int PatientID)
        {
            return clsPatientData.DeletePatientByID(PatientID);
        }
    }
}
