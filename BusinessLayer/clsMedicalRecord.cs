using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsMedicalRecord
    {
        private enum enMode { AddNew = 1, Update = 2 };
        private enMode _Mode = enMode.AddNew;

        public int MedicalRecordID { get; set; }

        public string VisitDescription { get; set; }
        public string Diagnosis { get; set; }
        public string AdditionalNotes { get; set; }

        private clsMedicalRecord(int MedicalRecordID, string VisitDescription, string Diagnosis, string AdditionalNotes)
        {
            this.MedicalRecordID = MedicalRecordID;

            this.VisitDescription = VisitDescription;
            this.Diagnosis = Diagnosis;
            this.AdditionalNotes = AdditionalNotes;
            _Mode = enMode.Update;
        }

        public clsMedicalRecord()
        {
            this.MedicalRecordID = 0;

            this.VisitDescription = string.Empty;
            this.Diagnosis = string.Empty;
            this.AdditionalNotes = string.Empty;
            _Mode = enMode.AddNew;
        }

        private bool _AddNewMedicalRecord()
        {
            this.MedicalRecordID = clsMedicalRecordData.AddNewMedicalRecord(this.VisitDescription, this.Diagnosis, this.AdditionalNotes);
            return (this.MedicalRecordID != 0);
        }

        private bool _UpdateMedicalRecord()
        {
            return clsMedicalRecordData.UpdateMedicalRecord(this.MedicalRecordID, this.VisitDescription, this.Diagnosis, this.AdditionalNotes);
        }

        public static clsMedicalRecord FindMedicalRecord(int MedicalRecordID)
        {

            string VisitDescription = string.Empty;
            string Diagnosis = string.Empty;
            string AdditionalNotes = string.Empty;

            bool IsFound = clsMedicalRecordData.FindMedicalRecordByID(MedicalRecordID, ref VisitDescription, ref Diagnosis, ref AdditionalNotes);

            if (IsFound)
            {
                return new clsMedicalRecord(MedicalRecordID, VisitDescription, Diagnosis, AdditionalNotes);
            }
            else
            {
                return null;
            }
        }

        public static bool IsExist(int MedicalRecordID)
        {
            return clsMedicalRecordData.IsMedicalRecordExistByID(MedicalRecordID);
        }

        public static DataTable GetAllMedicalRecords()
        {
            return clsMedicalRecordData.GetAllMedicalRecords();
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (!clsMedicalRecordData.IsMedicalRecordExistByID(this.MedicalRecordID))
                        {
                            if (_AddNewMedicalRecord())
                            {
                                _Mode = enMode.Update;
                                return true;
                            }
                        }
                        return false;
                    }
                case enMode.Update:
                    {
                        return _UpdateMedicalRecord();
                    }
                default:
                    return false;
            }
        }

        public bool Delete()
        {
            return clsMedicalRecordData.DeleteMedicalRecordByID(this.MedicalRecordID);
        }
    }
}
